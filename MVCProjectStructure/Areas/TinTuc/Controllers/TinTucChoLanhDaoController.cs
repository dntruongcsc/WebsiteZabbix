using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Common.Enum.ConstantValues;
using MVCProjectStructure.Helpers;
using Newtonsoft.Json;
using Common.Enum;
using MVCProjectStructure.Models;
using Common.Utilities;
using static MVCProjectStructure.Models.CommonModel;
using MVCProjectStructure.Areas.TinTuc.Models;

namespace MVCProjectStructure.Areas.TinTuc.Controllers
{
    public class TinTucChoLanhDaoController : Controller
    {
        public ActionResult NhomTin()
        {
            TempData["returnUrl"] = Url.Action("NhomTin", "TinTuc", new { Areas = "TinTucChoLanhDao" });
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            //if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.NhomTin, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);


            TempData["returnUrl"] = Url.Action("Index", "NhomTin", new { Areas = "TinTucChoLanhDao" });
            try
            {
                ViewBag.Active = "NhomTin";

                string tuKhoa = "";
                string idPhongBan = "";
                int trang = 1;
                if (!string.IsNullOrEmpty(Request.QueryString["NoiDungTim"]))
                {
                    tuKhoa = Request.QueryString["NoiDungTim"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["IdPhongBan"]))
                {
                    idPhongBan = Request.QueryString["IdPhongBan"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["trang"]))
                {
                    trang = int.Parse(Request.QueryString["trang"]);
                }
                var danhSachThamSo = new
                {
                    tukhoa = tuKhoa,
                    idPhongBan = idPhongBan
                };
                var DanhSachPhongBan = DocDanhSachDonVi();
                ViewBag.DanhSachPhongBan = new SelectList(DanhSachPhongBan, "Value", "Text", "Ma");
                ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
                var danhSach = DocDanhSachNhomTin(tuKhoa, idPhongBan, trang);
                return View(danhSach);
            }
            catch (Exception ex)
            {
                TempData["Error"] = Message.LoiDuLieu;
                return View();
            }
        }
        private Models.NhomTinModel.NhomTinOutput.DocDanhSach DocDanhSachNhomTin(string tuKhoa = "", string idPhongBan = "", int? trangHienTai = 1)
        {
            var currenPage = (trangHienTai == null || trangHienTai < 1) ? 1 : trangHienTai.Value;
            int soDongTrenTrang = PageNumber.Page20;
            int viTriBatDau = (currenPage - 1) * soDongTrenTrang;
            var input = new Models.NhomTinModel.NhomTinInput.TimKiemNhomTin
            {
                TuKhoa = tuKhoa,
                IdPhongBan = idPhongBan,
                ViTriBatDau = viTriBatDau,
                ViTriKetThuc = viTriBatDau + soDongTrenTrang,
                TrangHienTai = trangHienTai.Value,
            };
            var DanhSachPhongBan = DocDanhSachDonVi();
            ViewBag.IdPhongBan = new SelectList(DanhSachPhongBan, "Value", "Text", "Ma");
            var output = XuLyAPI.ApiJsonPost2(APIUrl.LoaiBaoCao.TimKiemPhanTrang, input, false) as CommonOutput;
            if (output == null) throw new Exception(Message.LoiServer);
            if (output.KetQua != 1) throw new Exception(output.ThongBao);
            var duLieuOutput = JsonConvert.DeserializeObject<Models.NhomTinModel.NhomTinOutput.DocDanhSach>(output.DuLieu.ToString());
            return duLieuOutput;
        }
        [SessionCheck]
        public ActionResult XemDanhSachNhomTin(string tukhoa = "", string idPhongBan = "", int? trang = 1)
        {
            TempData["returnUrl"] = Url.Action("NhomTin", "TinTuc", new { Areas = "TinTuc" });
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            //if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.NhomTin, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);

            var danhSachThamSo = new { tukhoa = tukhoa, idPhongBan = idPhongBan };
            ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
            //TempData["returnUrl"] = Url.Action("Index", "NguoiDung");
            try
            {
                var danhSach = DocDanhSachNhomTin(tukhoa, idPhongBan, trang);
                return PartialView("_DanhSachNhomTinPartial", danhSach);
            }
            catch (Exception ex)
            {
                //Ghi log
                TempData["Error"] = Message.LoiDuLieu;
                return PartialView("_DanhSachNhomTinPartial");
            }
        }
        [HttpPost]
        public ActionResult XuLyDanhSachPhanTrangNhomTin(int? trang = 1, string danhSachThamSo = "")
        {
            //TempData["returnUrl"] = Url.Action("Index", "NguoiDung");
            try
            {
                var danhSach = DocDanhSachNhomTin("", "", trang);
                return PartialView("_DanhSachNhomTinPartial", danhSach);
            }
            catch (Exception)
            {
                TempData["Error"] = Message.LoiDuLieu;
                return PartialView("_DanhSachNhomTinPartial");
            }
        }
        [HttpPost]
        public ActionResult ThongTinThemCapNhatNhomTin(string Id)
        {
            var duLieuOutput = new Models.NhomTinModel.NhomTinOutput.ThongTin();
            var DanhSachPhongBan = DocDanhSachDonVi();
            ViewBag.IdPhongBan = new SelectList(DanhSachPhongBan, "Value", "Text", "Ma");
            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    var input = new CommonInput.DocThongTinInput { Id = Id };
                    var output = XuLyAPI.ApiJsonPost2(APIUrl.LoaiBaoCao.DocThongTin, input, false) as CommonOutput;
                    if (output == null) throw new Exception(Message.LoiServer);
                    if (output.KetQua != 1) throw new Exception(output.ThongBao);
                    duLieuOutput = JsonConvert.DeserializeObject<Models.NhomTinModel.NhomTinOutput.ThongTin>(output.DuLieu.ToString());
                }
            }
            catch (Exception)
            {
            }
            return PartialView("_ThemCapNhatNhomTinPartial", duLieuOutput);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult XuLyLuuNhomTin(CommonNhomTin.NhomTinInput.ThongTinNhomTin input)
        {
            TempData["returnUrl"] = Url.Action("NhomTin", "TinTuc", new { Areas = "TinTuc" });
            //var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.NhomTin, QuyenHan.Ma.Them);
            //ViewBag.KetQua = kiemTra.KetQua;
            //if (kiemTra.KetQua < 0) return PartialView("_ThemCapNhatPartial", new CommonNhomTin.NhomTinOutput.ThongTin());

            var model = new CommonOutput();
            var input2 = new Models.NhomTinModel.NhomTinOutput.ThongTin();
            var DanhSachPhongBan = DocDanhSachDonVi();
            ViewBag.IdPhongBan = new SelectList(DanhSachPhongBan, "Value", "Text", "Ma");
            try
            {
                input2.Id = input.Id;
                input2.Ten = input.Ten;
                input2.DuongDan = input.DuongDan;
                input2.ThuTu = input.ThuTu;
                input2.MoTa = input.MoTa;
                input2.KichHoat = input.KichHoat;
                var ids = new List<string>();
                if (input.DanhSachIdPhongBan != null)
                {
                    foreach (var id in input.DanhSachIdPhongBan)
                    {
                        ids.Add(id);
                    }
                }

                input2.DanhSachIdPhongBan = ids;
                var url = !string.IsNullOrEmpty(input.Id) ? APIUrl.LoaiBaoCao.Sua : APIUrl.LoaiBaoCao.Them;
                var output = XuLyAPI.ApiJsonPost(url, input, false) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua == 1)
                {
                    model.KetQua = 1;
                    model.ThongBao = Message.ThanhCong;
                    ViewBag.KetQua = 1;
                    return PartialView("_ThemCapNhatNhomTinPartial", new Models.NhomTinModel.NhomTinOutput.ThongTin());
                }
                else
                {
                    return PartialView("_ThemCapNhatNhomTinPartial", input2);
                }
            }
            catch (Exception ex)
            {
                model.KetQua = 0;
                model.ThongBao = Message.ThatBai;
                return PartialView("_ThemCapNhatNhomTinPartial", input2);
            }
        }
        [HttpPost]
        public ActionResult XuLyXoaDanhSachNhomTin(List<string> danhSachId)
        {
            TempData["returnUrl"] = Url.Action("NhomTin", "TinTuc", new { Areas = "TinTuc" });
            //var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.NhomTin, QuyenHan.Ma.Xoa);
            //if (kiemTra.KetQua < 0) return Json(kiemTra);

            var model = new CommonOutput();
            try
            {
                var input = new CommonInput.XoaDanhSachInput2();
                input.Ids = danhSachId;
                var output = XuLyAPI.ApiJsonPost2(APIUrl.LoaiBaoCao.XoaDanhSach, input) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua == 1)
                {
                    model.KetQua = 1;
                    model.ThongBao = Message.ThanhCong;
                    model.TongSoLuong = output.DuLieu.ToString();

                }
                else
                {
                    model.KetQua = 0;
                    model.ThongBao = Message.ThatBai;
                }
            }
            catch (Exception)
            {
            }
            return Json(model);
        }
        public List<PhongBan.Models.PhongBanModel.PhongBanOutput.ThongTinPhongBan> DocDanhSachPhongBan()
        {
            try
            {
                PhongBan.Models.PhongBanModel.PhongBanInput.DocDanhSach input = new PhongBan.Models.PhongBanModel.PhongBanInput.DocDanhSach();
                //input.IdChucNang = "PhongBan";
                var output = new CommonOutput();
                output = XuLyAPI.ApiJsonPost2(APIUrl.NguoiDung.DocDanhSachPhongBan, input, false) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var danhsach = JsonConvert.DeserializeObject<PhongBan.Models.PhongBanModel.PhongBanOutput.DocDanhSach>(JsonConvert.SerializeObject(output.DuLieu));
                return danhsach.DanhSach;
            }
            catch (Exception e)
            {
                //Ghi log
                return null;
            }
        }
        private List<CommonDonVi.DonViOutput.ThongTinDonVi> DocDanhSachDonVi()
        {
            try
            {
                var userInfo = Session["UserInfo"] as CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan;
                var input = new CommonDonVi.DonViInput.DocDanhSach();
                var idQuanTri = "5a28a83618e6d9409c42d5e3";

                input.DanhSachID = userInfo != null ? userInfo.DanhSachIdDonViTheoPhanQuyen : null;
                if (input.DanhSachID.Contains(idQuanTri))
                {
                    input.DanhSachID = new List<string>();
                }
                var output = XuLyAPI.ApiJsonPost(APIUrl.DonVi.DocDanhSachTheoDanhSachId, input) as CommonOutput;
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

        public ActionResult BaiViet()
        {
            TempData["returnUrl"] = Url.Action("BaiViet", "TinTuc", new { Areas = "TinTuc" });
            if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            //if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.BaiViet, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);

            TempData["returnUrl"] = Url.Action("Index", "BaiViet", new { Areas = "TinTuc" });
            try
            {
                string tuKhoa = "";
                string IdNhomTin = "";
                int trang = 1;
                if (!string.IsNullOrEmpty(Request.QueryString["NoiDungTim"]))
                {
                    tuKhoa = Request.QueryString["NoiDungTim"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["DanhSachNhomTin"]))
                {
                    IdNhomTin = Request.QueryString["DanhSachNhomTin"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["trang"]))
                {
                    trang = int.Parse(Request.QueryString["trang"]);
                }
                var danhSachThamSo = new
                {
                    tukhoa = tuKhoa,
                    idnhomtin = IdNhomTin
                };
                var DanhSachNhomTin = DocDanhSachNhomTin();
                ViewBag.DanhSachPhongBan = DocDanhSachDonVi();
                //ViewBag.DanhSachNhomTin = new SelectList(DanhSachNhomTin, "Value", "Text", "Ma");
                ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
                //var danhSach = DocDanhSachBaiViet(tuKhoa,IdNhomTin,trang);
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = Message.LoiDuLieu;
                return View();
            }
        }
        private Models.BaiVietModel.Output.DocDanhSach DocDanhSachBaiViet(string tuKhoa = "", string IdDonVi = "", string IdNhomTin = "", int? trangHienTai = 1)
        {
            try
            {
                var userInfo = Session["UserInfo"] as CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan;
                var currenPage = (trangHienTai == null || trangHienTai < 1) ? 1 : trangHienTai.Value;
                int soDongTrenTrang = PageNumber.Page10;
                int viTriBatDau = (currenPage - 1) * soDongTrenTrang;
                var listDV = new List<string>();
                if (!string.IsNullOrEmpty(IdDonVi))
                {
                    listDV.Add(IdDonVi);
                }
                else
                {
                    if (userInfo != null)
                        if (userInfo.DanhSachIdDonViTheoPhanQuyen != null)
                            foreach (var item in userInfo.DanhSachIdDonViTheoPhanQuyen)
                            {
                                listDV.Add(item);
                            }
                }
                var input = new Models.BaiVietModel.Input.TimKiemBaiViet
                {
                    Id = IdNhomTin,
                    TuKhoa = tuKhoa,
                    ViTriBatDau = viTriBatDau,
                    ViTriKetThuc = viTriBatDau + soDongTrenTrang,
                    TrangHienTai = trangHienTai.Value,
                    DanhSachIdDonVi = listDV
                };
                var DanhSachNhomTin = DocDanhSachNhomTin();
                ViewBag.IdNhomTin = new SelectList(DanhSachNhomTin, "Value", "Text", "Ma");
                var output = XuLyAPI.ApiJsonPost2(APIUrl.BaiVietChoLanhDao.TimKiemPhanTrang, input) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var duLieuOutput = JsonConvert.DeserializeObject<Models.BaiVietModel.Output.DocDanhSach>(output.DuLieu.ToString());
                return duLieuOutput;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        [SessionCheck]
        public ActionResult XemDanhSachBaiViet(string tukhoa = "", string IdDonVi = "", string IdNhomTin = "", int? trang = 1)
        {
            TempData["returnUrl"] = Url.Action("BaiViet", "TinTuc", new { Areas = "TinTuc" });
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            //if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.BaiViet, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);

            var danhSachThamSo = new { tukhoa = tukhoa, iddonvi = IdDonVi, idnhomtin = IdNhomTin };
            ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
            //TempData["returnUrl"] = Url.Action("Index", "NguoiDung");
            try
            {
                var danhSach = DocDanhSachBaiViet(tukhoa, IdDonVi, IdNhomTin, trang);
                return PartialView("_DanhSachBaiVietPartial", danhSach);
            }
            catch (Exception ex)
            {
                //Ghi log
                TempData["Error"] = Message.LoiDuLieu;
                return PartialView("_DanhSachBaiVietPartial");
            }
        }
        //[HttpPost]
        //public ActionResult XuLyDanhSachPhanTrangBaiViet(int? trang = 1, string danhSachThamSo = "")
        //{
        //    //TempData["returnUrl"] = Url.Action("Index", "NguoiDung");
        //    try
        //    {
        //        var danhSach = DocDanhSachBaiViet("", "", trang);
        //        return PartialView("_DanhSachBaiVietPartial", danhSach);
        //    }
        //    catch (Exception)
        //    {
        //        TempData["Error"] = Message.LoiDuLieu;
        //        return PartialView("_DanhSachBaiVietPartial");
        //    }
        //}
        [HttpPost]
        public ActionResult ThongTinThemCapNhatBaiViet(string Id)
        {
            var duLieuOutput = new Models.BaiVietModel.Output.ThongTin();
            //if (string.IsNullOrEmpty(Id))
            //{
            //    ViewBag.DanhSachPhongBan = DocDanhSachDonVi();
            //}
            //else
            //{
            //    ViewBag.DanhSachNhomTin = DocDanhSachNhomTin();
            //}
            ViewBag.DanhSachPhongBan = DocDanhSachDonVi();
            ViewBag.DanhSachNhomTin = DocDanhSachNhomTin();
            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    var input = new CommonInput.DocThongTinInput { Id = Id };
                    var output = XuLyAPI.ApiJsonPost2(APIUrl.BaiVietChoLanhDao.DocThongTin, input) as CommonOutput;
                    if (output == null) throw new Exception(Message.LoiServer);
                    if (output.KetQua != 1) throw new Exception(output.ThongBao);
                    duLieuOutput = JsonConvert.DeserializeObject<Models.BaiVietModel.Output.ThongTin>(output.DuLieu.ToString());
                }
            }
            catch (Exception)
            {
            }
            return PartialView("_ThemCapNhatBaiVietPartial", duLieuOutput);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult XuLyLuuBaiViet(CommonBaiViet.Input.ThongTinBaiViet input)
        {
            TempData["returnUrl"] = Url.Action("BaiViet", "TinTucChoLanhDao", new { Areas = "TinTuc" });
            //var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.BaiViet, QuyenHan.Ma.Them);
            //ViewBag.KetQua = kiemTra.KetQua;
            //if (kiemTra.KetQua < 0) return PartialView("_ThemCapNhatPartial", new CommonBaiViet.Output.ThongTin());
            var userInfo = Session["UserInfo"] as CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan;
            if (userInfo != null)
            {
                input.IdNguoiCapNhat = userInfo.Id;
            }
            var model = new CommonOutput();
            var input2 = new Models.BaiVietModel.Output.ThongTin();
            var DanhSachNhomTin = DocDanhSachNhomTin();
            ViewBag.IdNhomTin = new SelectList(DanhSachNhomTin, "Value", "Text", "Ma");
            try
            {
                input2.Id = input.Id;
                input2.TieuDe = input.TieuDe;
                input2.TieuDeRutGon = input.TieuDeRutGon;
                input2.DuongDan = input.DuongDan;
                input2.ThuTu = input.ThuTu;
                input2.NoiDungTomTat = input.NoiDungTomTat;
                input2.HinhDaiDien = input.HinhDaiDien;
                input2.MoTa = input.MoTa;
                input2.KichHoat = input.KichHoat;
                input2.TrangChu = input.TrangChu;
                input2.UuTien = input.UuTien;
                input2.NoiBat = input.NoiBat;
                input2.GioiHanThoiGian = input.GioiHanThoiGian;
                input2.NoiDung = input.NoiDung;
                input2.IdNhomTin = input.IdNhomTin;
                input2.TuKhoa = input.TuKhoa;
                input2.TieuDeSeo = input.TieuDeSeo;
                var url = !string.IsNullOrEmpty(input.Id) ? APIUrl.BaiVietChoLanhDao.Sua : APIUrl.BaiVietChoLanhDao.Them;
                var output = XuLyAPI.ApiJsonPost2(url, input) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua == 1)
                {
                    model.KetQua = 1;
                    model.ThongBao = Message.ThanhCong;
                    ViewBag.KetQua = 1;
                    return PartialView("_ThemCapNhatBaiVietPartial", new Models.BaiVietModel.Output.ThongTin());
                }
                else
                {
                    return PartialView("_ThemCapNhatBaiVietPartial", input2);
                }
            }
            catch (Exception ex)
            {
                model.KetQua = 0;
                model.ThongBao = Message.ThatBai;
                return PartialView("_ThemCapNhatBaiVietPartial", input2);
            }
        }
        [HttpPost]
        public ActionResult XuLyXoaDanhSachBaiViet(List<string> danhSachId)
        {
            TempData["returnUrl"] = Url.Action("BaiViet", "TinTuc", new { Areas = "TinTuc" });
            //var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.BaiViet, QuyenHan.Ma.Xoa);
            //if (kiemTra.KetQua < 0) return Json(kiemTra);

            var model = new CommonOutput();
            try
            {
                var input = new CommonInput.XoaDanhSachInput2();
                input.Ids = danhSachId;
                var output = XuLyAPI.ApiJsonPost2(APIUrl.BaiVietChoLanhDao.XoaDanhSach, input) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua == 1)
                {
                    model.KetQua = 1;
                    model.ThongBao = Message.ThanhCong;
                    model.TongSoLuong = output.DuLieu.ToString();

                }
                else
                {
                    model.KetQua = 0;
                    model.ThongBao = Message.ThatBai;
                }
            }
            catch (Exception)
            {
            }
            return Json(model);
        }
        public List<Models.NhomTinModel.NhomTinOutput.ThongTin> DocDanhSachNhomTin()
        {
            try
            {
                var input = new TinTucModel.Input.DocDanhSach();
                var userInfo = Session["UserInfo"] as CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan;
                var idQuanTri = "5a28a83618e6d9409c42d5e3";

                input.DanhSachIdDonVi = userInfo != null ? userInfo.DanhSachIdDonViTheoPhanQuyen : null;
                if (input.DanhSachIdDonVi.Contains(idQuanTri))
                {
                    input.DanhSachIdDonVi = new List<string>();
                }
                var output = new CommonOutput();
                output = XuLyAPI.ApiJsonPost2(APIUrl.LoaiBaoCao.DocDanhSach, input) as CommonOutput;
                var danhsach = JsonConvert.DeserializeObject<Models.NhomTinModel.NhomTinOutput.ThongTinKetQua>(JsonConvert.SerializeObject(output));
                //var ds = JsonConvert.DeserializeObject<List<NhomTinModel.Output.ThongTin>>(JsonConvert.SerializeObject(danhsach.DuLieu.DuLieu));
                return danhsach.DuLieu.DuLieu;
            }
            catch (Exception e)
            {
                //Ghi log
                return null;
            }
        }

        [HttpPost]
        public ActionResult DocDanhSachNhomTinTheoDonVi(string idPhongBan)
        {
            try
            {
                var input = new Models.NhomTinModel.NhomTinInput.TimKiemNhomTin
                {
                    IdPhongBan = idPhongBan
                };
                var output = new CommonOutput();
                output = XuLyAPI.ApiJsonPost2(APIUrl.LoaiBaoCao.DocDanhSachXuatBan1, input) as CommonOutput;
                var danhsach = new Models.NhomTinModel.NhomTinOutput.DocDanhSach();
                if (output.DuLieu != null)
                {
                    danhsach = JsonConvert.DeserializeObject<Models.NhomTinModel.NhomTinOutput.DocDanhSach>(JsonConvert.SerializeObject(output.DuLieu));
                }
                return Json(danhsach.DanhSachThongTinNhomTin);
            }
            catch (Exception e)
            {
                //Ghi log
                return null;
            }
        }
    }
}