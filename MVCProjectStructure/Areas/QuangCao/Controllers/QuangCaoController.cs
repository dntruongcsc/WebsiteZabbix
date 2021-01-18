 using Common.Enum;
using Common.Utilities;
using MVCProjectStructure.Areas.QuangCao.Models;
using MVCProjectStructure.Helpers;
using MVCProjectStructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Common.Enum.ConstantValues;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.QuangCao.Controllers
{
    //[RouteArea("QuangCao", AreaPrefix ="quang-cao")]
    //[RoutePrefix("quan-ly")]
    //[Route("{action}")]
    public class QuangCaoController : Controller
    {
        //[Route("")]
        //[Route("xem-danh-sach/{id}")]
        public ActionResult Index()
        {
            TempData["returnUrl"] = Url.Action("Index", "QuangCao", new { Areas = "QuangCao" });
            if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.QuangCao, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);

            try
            {
                string tuKhoa = "";
                int trang = 1;
                if (!string.IsNullOrEmpty(Request.QueryString["Tukhoa"]))
                {
                    tuKhoa = Request.QueryString["Tukhoa"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["Trang"]))
                {
                    trang = int.Parse(Request.QueryString["Trang"]);
                }
                var danhSachThamSo = new
                {
                    Tukhoa = tuKhoa
                };
                //ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
                var DanhSachNenTang = StaticList.NenTangs();
                ViewBag.DanhSachNenTangTimKiem = DanhSachNenTang;
                ViewBag.DanhSachLoaiTimKiem = DocDanhSachLoai();
                //var danhSach = DocDanhSach();
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ConstantValues.Message.LoiDuLieu;
                return View();
            }
        }
        private List<CommonDonVi.DonViOutput.ThongTinDonVi> DocDanhSachDonVi()
        {
            try
            {
                var input = new CommonDonVi.DonViInput.DocDanhSach();
                var output = XuLyAPI.ApiJsonPost(APIUrl.DonVi.DocDanhSach, input) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var kq = JsonConvert.DeserializeObject<List<CommonDonVi.DonViOutput.ThongTinDonVi>>(output.DuLieu.ToString());
                return kq;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private List<CommonQuangCaoLoai.Output.ThongTin> DocDanhSachLoai(string MaNenTang = "")
        {
            try
            {
                var input = new CommonQuangCaoLoai.Input.DocDanhSach();
                input.MaNenTang = MaNenTang;
                var output = XuLyAPI.ApiJsonPost(APIUrl.QuangCaoLoai.DocDanhSach, input) as CommonOutput;
                if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var duLieuOutput = JsonConvert.DeserializeObject<CommonQuangCaoLoai.Output.DocDanhSach>(output.DuLieu.ToString());
                if (duLieuOutput!=null)
                {
                    return duLieuOutput.DanhSach;
                }
            }
            catch (Exception) { }
            return null;
        }
        private CommonQuangCao.QuangCaoOutput.DocDanhSach DocDanhSach(string TuKhoa = "", string MaNenTang = "", string MaLoai = "", int? Trang = 1)
        {
            var currenPage = (Trang == null || Trang < 1) ? 1 : Trang.Value;
            int soDongTrenTrang = PageNumber.Default;
            int viTriBatDau = (currenPage - 1) * soDongTrenTrang;
            int tongSoDong = 0;
            var input = new CommonQuangCao.QuangCaoInput.TimKiemQuangCao
            {
                TuKhoa = TuKhoa.Trim().ToLower(),
                MaNenTang = MaNenTang,
                MaLoai = MaLoai,
                ViTriBatDau = viTriBatDau,
                ViTriKetThuc = viTriBatDau + soDongTrenTrang
            };
            var output = XuLyAPI.ApiJsonPost(APIUrl.QuangCao.DocDanhSach, input) as CommonOutput;
            if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
            if (output.KetQua != 1) throw new Exception(output.ThongBao);
            var duLieuOutput = JsonConvert.DeserializeObject<CommonQuangCao.QuangCaoOutput.DocDanhSach>(output.DuLieu.ToString());
            var kq = new CommonQuangCao.QuangCaoOutput.DocDanhSach();
            kq.TrangHienTai = currenPage;
            tongSoDong = duLieuOutput.TongSoDong;
            kq.TongSoTrang = (tongSoDong % soDongTrenTrang > 0) ? tongSoDong / soDongTrenTrang + 1 : tongSoDong / soDongTrenTrang;
            kq.TongSoDong = tongSoDong;
            kq.DanhSach = duLieuOutput.DanhSach;
            return kq;
        }

        [SessionCheck]
        public ActionResult XemDanhSach(string TuKhoa = "", string MaNenTang = "", string MaLoai = "", int? Trang = 1)
        {
            var danhSachThamSo = new { TuKhoa = TuKhoa, MaNenTang = MaNenTang, MaLoai = MaLoai };
            ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
            TempData["returnUrl"] = Url.Action("Index", "QuangCao", new { Areas = "QuangCao" });
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.QuangCao, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);

            try
            {
                var danhSach = DocDanhSach(TuKhoa, MaNenTang, MaLoai, Trang);
                return PartialView("_DanhSachPartial", danhSach);
            }
            catch (Exception ex)
            {
                //Ghi log
                TempData["Error"] = ConstantValues.Message.LoiDuLieu;
                return PartialView("_DanhSachPartial");
            }
        }
        [HttpPost]
        public ActionResult XuLyDocDanhSachLoai(string MaNenTang)
        {
            var model = new CommonOutput();
            try
            {
                var danhSach = DocDanhSachLoai(MaNenTang);
                model.KetQua = 1;
                model.ThongBao = ConstantValues.Message.ThanhCong;
                model.DuLieu = danhSach;
            }
            catch (Exception)
            {
                model.KetQua = 0;
                model.ThongBao = ConstantValues.Message.ThatBai;
                model.DuLieu = null;
            }
            return Json(model);
        }
        [HttpPost]
        public ActionResult ThongTinThemCapNhat(string Id)
        {
            var duLieuOutput = new CommonQuangCao.QuangCaoOutput.ThongTinQuangCao();
            ViewBag.DanhSachDonVi = DocDanhSachDonVi();
            var danhSachNenTang = StaticList.NenTangs();
            ViewBag.DanhSachNenTang = danhSachNenTang;
            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    var input = new CommonInput.DocThongTinInput { Id = Id };
                    var output = XuLyAPI.ApiJsonPost(APIUrl.QuangCao.DocThongTin, input) as CommonOutput;
                    if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                    if (output.KetQua != 1) throw new Exception(output.ThongBao);
                    duLieuOutput = JsonConvert.DeserializeObject<CommonQuangCao.QuangCaoOutput.ThongTinQuangCao>(output.DuLieu.ToString());
                    if (!string.IsNullOrEmpty(duLieuOutput.MaNenTang))
                    {
                        ViewBag.DanhSachLoai = DocDanhSachLoai(duLieuOutput.MaNenTang);
                    }
                }
            }
            catch (Exception)
            {
            }
            return PartialView("_ThemCapNhatPartial", duLieuOutput);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult XuLyLuu(CommonQuangCao.QuangCaoInput.ThongTinQuangCao input)
        {
            TempData["returnUrl"] = Url.Action("Index", "QuangCao", new { Areas = "QuangCao" });
            var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.QuangCao, QuyenHan.Ma.Them);
            ViewBag.KetQua = kiemTra.KetQua;
            if (kiemTra.KetQua < 0) return PartialView("_ThemCapNhatPartial", new CommonQuangCao.QuangCaoOutput.ThongTinQuangCao());

            var model = new CommonOutput();
            var input2 = new CommonQuangCao.QuangCaoOutput.ThongTinQuangCao();
            ViewBag.DanhSachViTri = StaticList.ViTriQuangCaos();
            var danhSachNenTang = StaticList.NenTangs();
            ViewBag.DanhSachNenTang = danhSachNenTang;
            ViewBag.DanhSachThuocTrang = StaticList.ThuocTrangs().Where(n => n.MaNenTang == danhSachNenTang.FirstOrDefault().Value.ToString()).ToList();
            try
            {
                input2.Id = input.Id;
                input2.IdDonVi = input.IdDonVi;
                input2.MaNenTang = input.MaNenTang;
                input2.MaLoai = input.MaLoai;
                input2.TieuDe = input.TieuDe;
                input2.MoTa = input.MoTa;
                input2.NoiDung = input.NoiDung;
                input2.ThuTuHienThi = input.ThuTuHienThi;
                input2.KichHoat = input.KichHoat;
                input2.UuTien = input.UuTien;
                input2.HinhDaiDien = input.HinhDaiDien;
                input2.DuongDan = input.DuongDan;
                input2.ChuoiTuNgay = input.TuNgay;
                input2.ChuoiDenNgay = input.DenNgay;
                //input2.SoLuotClick = input.SoLuotClick;
                //input2.SoLuotHienThi = input.SoLuotHienThi;

                var url = !string.IsNullOrEmpty(input.Id) ? APIUrl.QuangCao.Sua : APIUrl.QuangCao.Them;
                var output = XuLyAPI.ApiJsonPost(url, input) as CommonOutput;
                if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                if (output.KetQua == 1)
                {
                    model.KetQua = 1;
                    model.ThongBao = ConstantValues.Message.ThanhCong;
                    ViewBag.KetQua = 1;
                    return PartialView("_ThemCapNhatPartial", new CommonQuangCao.QuangCaoOutput.ThongTinQuangCao());
                }
                else
                {
                    ViewBag.KetQua = 0;
                    return PartialView("_ThemCapNhatPartial", input2);
                }
            }
            catch (Exception)
            {
                ViewBag.KetQua = 0;
                model.KetQua = 0;
                model.ThongBao = ConstantValues.Message.ThatBai;
                return PartialView("_ThemCapNhatPartial", input2);
            }
        }
        [HttpPost]
        public ActionResult XuLyXoaDanhSach(List<string> danhSachId)
        {
            TempData["returnUrl"] = Url.Action("Index", "QuangCao", new { Areas = "QuangCao" });
            var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.QuangCao, QuyenHan.Ma.Xoa);
            if(kiemTra.KetQua < 0) return Json(kiemTra);
            var model = new CommonOutput();
            try
            {
                var input = new CommonInput.XoaDanhSachInput2();
                input.Ids = danhSachId;
                var output = XuLyAPI.ApiJsonPost(APIUrl.QuangCao.XoaDanhSach, input) as CommonOutput;
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
    }
}