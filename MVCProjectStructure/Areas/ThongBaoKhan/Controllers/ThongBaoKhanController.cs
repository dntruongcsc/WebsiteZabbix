using Common.Enum;
using Common.Utilities;
using MVCProjectStructure.Helpers;
using MVCProjectStructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MVCProjectStructure.Models.CommonModel;
using static MVCProjectStructure.Models.CommonModel.CommonInput;

namespace MVCProjectStructure.Areas.ThongBaoKhan.Controllers
{
    public class ThongBaoKhanController : Controller
    {
        // GET: ThongBaoKhan/ThongBaoKhan
        public ActionResult Index()
        {
            try
            {
                if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
                
                string tuKhoa = "";
                int trang = 1;
                if (!string.IsNullOrEmpty(Request.QueryString["tukhoa"]))
                {
                    tuKhoa = Request.QueryString["tukhoa"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["trang"]))
                {
                    trang = int.Parse(Request.QueryString["trang"]);
                }
                var danhSachThamSo = new
                {
                    tukhoa = tuKhoa
                };
                // ViewBag.DanhSachLoaiBieuMauInAn = DocDanhSachLoaiBieuMauInAn();
                //var danhSach = DocDanhSach();
                return View();
            }
            catch (Exception)
            {
                TempData["Error"] = ConstantValues.Message.LoiDuLieu;
                return View();
            }
        }



        #region Đọc danh sách
        [SessionCheck]
        public ActionResult XemDanhSach(string tukhoa = "", string nhomBanTin = "", int? trang = 1)
        {
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            var danhSachThamSo = new { tukhoa = tukhoa, nhomBanTin = nhomBanTin };
            //ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
            //var danhSachThamSo = new { tukhoa = tukhoa };
            ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
            TempData["returnUrl"] = Url.Action("Index", "BanTinTruyenHinh", new { Areas = "LVKhuyenNong" });
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            //if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.QuangCao, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            try
            {
                var danhSach = DocDanhSach(tukhoa, trang);
                return PartialView("_DanhSachPartial", danhSach);
            }
            catch (Exception ex)
            {
                //Ghi log
                TempData["Error"] = ConstantValues.Message.LoiDuLieu;
                return PartialView("_DanhSachPartial");
            }
        }

        private dynamic DocDanhSach(string tuKhoa = "", int? trangHienTai = 1)
        {
            var currenPage = (trangHienTai == null || trangHienTai < 1) ? 1 : trangHienTai.Value;
            int soDongTrenTrang = PageNumber.Default;
            int viTriBatDau = (currenPage - 1) * soDongTrenTrang;
            int tongSoDong = 0;
            var input = new TimKiem
            {
                TuKhoa = tuKhoa.Trim().ToLower(),
             
                ViTriBatDau = viTriBatDau,
                ViTriKetThuc = viTriBatDau + soDongTrenTrang
            };
            var output = XuLyAPI.ApiJsonPost(APIUrl.ThongBaoKhan.DocDanhSachPhanTrang, input) as CommonOutput;
            if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
            if (output.KetQua != 1) throw new Exception(output.ThongBao);
            var duLieuOutput = JsonConvert.DeserializeObject<Models.ThongBaoKhanModel.Output.DocDanhSach>(output.DuLieu.ToString());
            var kq = new Models.ThongBaoKhanModel.Output.DocDanhSach();
            kq.TrangHienTai = currenPage;
            tongSoDong = duLieuOutput.TongSoDong;
            kq.TongSoTrang = (tongSoDong % soDongTrenTrang > 0) ? tongSoDong / soDongTrenTrang + 1 : tongSoDong / soDongTrenTrang;
            kq.TongSoDong = tongSoDong;
            kq.DanhSach = duLieuOutput.DanhSach;
            return kq;
        }

        #endregion


        #region Thêm sửa xóa
        [HttpPost]
        public ActionResult ThongTinThemCapNhat(string Id)
        {
            var duLieuOutput = new Models.ThongBaoKhanModel.Input.ThongTin();

            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    var input = new CommonInput.DocThongTin { Id = Id };
                    var output = XuLyAPI.ApiJsonPost2(APIUrl.ThongBaoKhan.DocThongTin, input) as CommonOutput;
                    if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                    if (output.KetQua != 1) throw new Exception(output.ThongBao);
                    duLieuOutput = JsonConvert.DeserializeObject<Models.ThongBaoKhanModel.Input.ThongTin>(output.DuLieu.ToString());
                }
            }
            catch (Exception)
            {
            }
            return PartialView("_ThemCapNhatPartial", duLieuOutput);
        }

        [HttpPost]
        [SessionCheck]
        public ActionResult XuLyLuu(Models.ThongBaoKhanModel.Input.ThongTin input)
        {
            TempData["returnUrl"] = Url.Action("Index", "ThoiTietNongVu", new { Areas = "LVKhuyenNong" });
            var kiemTra = Helpers.XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.QuanLyThongBaoKhan, QuyenHan.Ma.Them);
            ViewBag.KetQua = kiemTra.KetQua;
            //if (kiemTra.KetQua < 0) return PartialView("_ThemCapNhatPartial", new CommonBieuMauInAn.BieuMauInAnOutput.ThongTin());
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            var model = new CommonOutput();
            var input2 = new ThongBaoKhan.Models.ThongBaoKhanModel.Input.ThongTin2();
            try
            {
                input2.Id = input.Id;
                //input2.Ten = input.Ten;
                //input2.TenVietTat = input.TenVietTat;


                //input2.Ma = string.IsNullOrEmpty(input.Ma) ? "" : input.Ma.Replace(" ", "");

                //input2.ThuTu = input.ThuTu;

                //input2.GhiChu = input.GhiChu;
                //var input = new ThoiTietNongVuInput2();
                input2.HinhDaiDien = input.HinhDaiDien;
                input2.DuongDanThanThien = input.DuongDanThanThien;
                input2.TieuDe = input.TieuDe;
                input2.NoiDungTomTat = input.NoiDungTomTat;
                input2.NoiDung = input.NoiDung;
                input2.TrangThai = 0;
                if (input.TrangThai) input2.TrangThai = 1;
                input2.DoUuTien = 0;
                if (input.DoUuTien) input2.DoUuTien = 1;
                var url = !string.IsNullOrEmpty(input.Id) ? APIUrl.ThongBaoKhan.Sua : APIUrl.ThongBaoKhan.Them;
                var output = XuLyAPI.ApiJsonPost(url, input2) as CommonOutput;
                if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                if (output.KetQua == 1)
                {
                    if (input.DoUuTien )
                    {
                        GuiThongBao(input2, output);
                    }
                    model.KetQua = 1;
                    model.ThongBao = ConstantValues.Message.ThanhCong;
                    ViewBag.KetQua = 1;
                    return PartialView("_ThemCapNhatPartial", new Models.ThongBaoKhanModel.Input.ThongTin());
                }
                else
                {
                    ViewBag.KetQua = 0;
                    return PartialView("_ThemCapNhatPartial", input);
                }
            }
            catch (Exception ex)
            {
                ViewBag.KetQua = 0;
                model.KetQua = 0;
                model.ThongBao = ConstantValues.Message.ThatBai;
                return PartialView("_ThemCapNhatPartial", input);
            }
        }
        public void GuiThongBao(Models.ThongBaoKhanModel.Input.ThongTin2 input, CommonOutput output)
        {
            var thongBaoKhan = JsonConvert.DeserializeObject<Models.ThongBaoKhanModel.Input.ThongTin2>(JsonConvert.SerializeObject(output.DuLieu));
            var inputLoaiThongBao = new DocDanhSach();
            var outputLoaiThongBao = XuLyAPI.ApiJsonPost(APIUrl.LoaiThongBao.DocDanhSach, inputLoaiThongBao, false) as CommonOutput;
            if (outputLoaiThongBao.KetQua != 1) throw new Exception(outputLoaiThongBao.ThongBao);
            List<LoaiThongBaoOutput.DocDanhSach> danhSachLoaiThongBao = new List<LoaiThongBaoOutput.DocDanhSach>();
            danhSachLoaiThongBao = JsonConvert.DeserializeObject<List<LoaiThongBaoOutput.DocDanhSach>>(JsonConvert.SerializeObject(outputLoaiThongBao.DuLieu));
            if (danhSachLoaiThongBao.Any())
            {
                var loaiThongBao = danhSachLoaiThongBao.FirstOrDefault(e => e.Ma.Equals("ThongBaoKhan"));
                if (loaiThongBao != null)
                {
                    if (Session["UserInfo"] != null)
                    {
                        DangNhapOutput userInfo = Session["UserInfo"] as DangNhapOutput;
                        //if (userInfo != null)
                        {
                            var inputGuiTatCa = new ThongBaoInput.GuiTatCa
                            {
                                IdLoaiThongBao = loaiThongBao.Id,
                                //IdNguoiDung = userInfo.IdNguoiDung,
                                //IdTaiKhoan = userInfo.Id,
                                NoiDung = input.TieuDe,
                                TieuDe = "Thông tin khẩn cấp",
                                Id = thongBaoKhan.Id,
                                IdDuLieu = thongBaoKhan.Id,
                                AnhDaiDien = thongBaoKhan.HinhDaiDien
                            };
                            var outputThongBao = XuLyAPI.ApiJsonPost(APIUrl.ThongBao.GuiThongBaoChoTatCa, inputGuiTatCa, false) as CommonOutput;
                            if (outputThongBao == null) throw new Exception("Lỗi Server");
                            if (outputThongBao.KetQua != 1) throw new Exception(outputThongBao.ThongBao);
                        }
                    }
                }
            }
        }
        [HttpPost]
        public ActionResult XuLyXoaDanhSach(List<string> danhSachId)
        {
            TempData["returnUrl"] = Url.Action("Index", "ThongBaoKhan", new { Areas = "ThongBaoKhan" });
            //var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.QuanLyBieuMauInAn, QuyenHan.Ma.Xoa);
            //if (kiemTra.KetQua < 0) return Json(kiemTra);
            var model = new CommonOutput();
            try
            {
                var input = new CommonInput.XoaDanhSachInput2();
                input.Ids = danhSachId;
                var output = XuLyAPI.ApiJsonPost2(APIUrl.ThongBaoKhan.XoaDanhSach, input) as CommonOutput;
                if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                if (output.KetQua == 1)
                {
                    model.KetQua = 1;
                    model.ThongBao = ConstantValues.Message.ThanhCong;
                    model.TongSoLuong = output.DuLieu.ToString();

                }
                else
                {
                    model.KetQua = 0;
                    model.ThongBao = ConstantValues.Message.ThatBai;
                }
            }
            catch (Exception)
            {
                model.KetQua = 0;
                model.ThongBao = ConstantValues.Message.ThatBai;
            }
            return Json(model);
        }
        #endregion
    }
}