using Common.Enum;
using MVCProjectStructure.Models;
using Newtonsoft.Json;
using MVCProjectStructure.Areas.NguoiDung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Common.Enum.ConstantValues;
using MVCProjectStructure.Helpers;
using Common.Utilities;
using static MVCProjectStructure.Models.CommonModel;
using PagedList;

namespace MVCProjectStructure.Areas.NguoiDung.Controllers
{
    public class NguoiDungController : Controller
    {
        public ActionResult Index()
        {
            TempData["returnUrl"] = Url.Action("Index", "NguoiDung", new { Areas = "NguoiDung" });
            if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.QuanLyTaiKhoan, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);
            ViewBag.DanhSachDonVi = DocDanhSachDonVi();
            ViewBag.DanhSachVaiTro = DocDanhSachVaiTro();
            ViewBag.DanhSachTrangThai = StaticList.TrangThaiKichHoats();
            return View();
        }
        private CommonNguoiDung.NguoiDungOutput.DocDanhSach DocDanhSach(string tuKhoa = "", string maDonVi = "", string maVaiTro = "", int trangThai = -1, int? trangHienTai = 1)
        {
            var currenPage = (trangHienTai == null || trangHienTai < 1) ? 1 : trangHienTai.Value;
            int soDongTrenTrang = PageNumber.Page20;
            int viTriBatDau = (currenPage - 1) * soDongTrenTrang;
            int tongSoDong = 0;
            var input = new CommonNguoiDung.NguoiDungInput.DocDanhSachTimKiem();
            input.TuKhoa = tuKhoa;
            input.MaDonVi = maDonVi;
            input.MaVaiTro = maVaiTro;
            input.TrangThai = trangThai;
            input.ViTriBatDau = viTriBatDau;
            input.ViTriKetThuc = viTriBatDau + soDongTrenTrang;
            var output = XuLyAPI.ApiJsonPost(APIUrl.NguoiDung.DocDanhSach, input) as CommonOutput;
            if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
            if (output.KetQua != 1) throw new Exception(output.ThongBao);
            var duLieuOutput = JsonConvert.DeserializeObject<CommonNguoiDung.NguoiDungOutput.DocDanhSach>(output.DuLieu.ToString());
            duLieuOutput.TrangHienTai = currenPage;
            tongSoDong = duLieuOutput.TongSoDong;
            duLieuOutput.TongSoTrang = (tongSoDong % soDongTrenTrang > 0) ? tongSoDong / soDongTrenTrang + 1 : tongSoDong / soDongTrenTrang;
            return duLieuOutput;
        }
        [SessionCheck]
        public ActionResult XemDanhSach(string tuKhoa = "", string maDonVi = "", string maVaiTro = "", int trangThai = -1, int? trang = 1)
        {
            var danhSachThamSo = new {
                tukhoa = tuKhoa,
                maDonVi = maDonVi,
                maVaiTro = maVaiTro,
                trangThai = trangThai,
            };
            ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
            TempData["returnUrl"] = Url.Action("Index", "NguoiDung", new { Areas = "NguoiDung" });
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            //if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.NguoiDung, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);

            try
            {
                var userInfo = Session["UserInfo"] as CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan;
                if (userInfo != null && userInfo.TenTaiKhoan == "root")
                {
                    ViewBag.DuocPhepTruyCap = true;
                }
                var danhSach = DocDanhSach(tuKhoa, maDonVi, maVaiTro, trangThai,trang);
                return PartialView("_DanhSachPartial", danhSach);
            }
            catch (Exception)
            {
                //Ghi log
                TempData["Error"] = ConstantValues.Message.LoiDuLieu;
                return PartialView("_DanhSachPartial");
            }
        }

        [HttpPost]
        public ActionResult ThongTinThemCapNhat(string Id)
        {
            TempData["returnUrl"] = Url.Action("Index", "NguoiDung", new { Areas = "NguoiDung" });
            if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.QuanLyTaiKhoan, QuyenHan.Ma.Them)) return Redirect(ChucNang.DuongDan.BangDieuKhien);
            var duLieuOutput = new CommonNguoiDung.NguoiDungOutput.ThongTin();
            try
            {
                ViewBag.DanhSachVaiTro = DocDanhSachVaiTro();
                ViewBag.DanhSachDonVi = DocDanhSachDonVi();
                ViewBag.DanhSachPhanQuyen = DocDanhSachPhanQuyen();
                ViewBag.DanhSachHuyen = XuLyTinhHuyenXa.DocDanhSachCacCap("Huyen");
                if (!string.IsNullOrEmpty(Id))
                {
                    var input = new CommonInput.DocThongTinInput { Id = Id };
                    var output = XuLyAPI.ApiJsonPost(APIUrl.NguoiDung.DocThongTin, input) as CommonOutput;
                    if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                    if (output.KetQua != 1) throw new Exception(output.ThongBao);
                    duLieuOutput = JsonConvert.DeserializeObject<CommonNguoiDung.NguoiDungOutput.ThongTin>(output.DuLieu.ToString());
                }
            }
            catch (Exception)
            {
            }
            return PartialView("_ThemCapNhatPartial", duLieuOutput);
        }
        private List<CommonVaiTro.VaiTroOutput.ThongTinVaiTro> DocDanhSachVaiTro()
        {
            try
            {
                var input = new CommonVaiTro.VaiTroInput.DocDanhSach();
                var output = XuLyAPI.ApiJsonPost(APIUrl.VaiTro.DocDanhSach, input) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var kq = JsonConvert.DeserializeObject<List<CommonVaiTro.VaiTroOutput.ThongTinVaiTro>>(output.DuLieu.ToString());
                return kq;
            }
            catch (Exception)
            {
                return null;
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
        private List<CommonPhanQuyen.PhanQuyenOutput.ThongTinPhanQuyen> DocDanhSachPhanQuyen()
        {
            try
            {
                var input = new CommonDonVi.DonViInput.DocDanhSach();
                var output = XuLyAPI.ApiJsonPost(APIUrl.PhanQuyen.DocDanhSach, input) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var kq = JsonConvert.DeserializeObject<List<CommonPhanQuyen.PhanQuyenOutput.ThongTinPhanQuyen>>(output.DuLieu.ToString());
                return kq;
            }
            catch (Exception)
            {
                return null;
            }
        }
        [HttpPost]
        public ActionResult XuLyDocDanhSachHuyenXaAp(string Loai, string Id)
        {
            var model = new CommonOutput();
            var quyenTruyCap = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.QuanLyTaiKhoan, QuyenHan.Ma.Xoa);
            if (quyenTruyCap != null && quyenTruyCap.KetQua < 1) {
                model.KetQua = 0;
                model.ThongBao = ConstantValues.Message.KhongCoQuyen;
                model.DuLieu = null;
                return Json(model);
            }
            try
            {
                var input = new CommonHuyen.HuyenInput.DocDanhSachTheoIdTinh();
                var ds = XuLyTinhHuyenXa.DocDanhSachCacCap(Loai, Id);
                if (ds != null)
                {
                    model.KetQua = 1;
                    model.ThongBao = ConstantValues.Message.ThanhCong;
                    model.DuLieu = ds;
                }
            }
            catch (Exception ex)
            {
                model.KetQua = 0;
                model.ThongBao = ConstantValues.Message.ThatBai;
                model.DuLieu = null;
            }
            return Json(model);
        }
        [HttpPost]
        public ActionResult XuLyLuu(CommonNguoiDung.NguoiDungInput.ThongTin input)
        {
            TempData["returnUrl"] = Url.Action("Index", "NguoiDung", new { Areas = "NguoiDung" });
            var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.QuanLyTaiKhoan, !string.IsNullOrEmpty(input.Id) ? QuyenHan.Ma.Them : QuyenHan.Ma.Sua);
            ViewBag.KetQua = kiemTra.KetQua;
            if (kiemTra.KetQua < 0) return PartialView("_ThemCapNhatPartial", new CommonNguoiDung.NguoiDungOutput.ThongTin());

            var model = new CommonOutput();
            try
            {
                var url = !string.IsNullOrEmpty(input.Id) ? APIUrl.NguoiDung.Sua : APIUrl.NguoiDung.Them;
                input.IdTinh = "5a2a4172e08157ab8aa47d26";//Mặc định là tỉnh Cà Mau
                if (!string.IsNullOrEmpty(input.MatKhau))
                {
                    input.MatKhau = Utility.MD5(input.MatKhau);
                }
                var output = XuLyAPI.ApiJsonPost(url, input) as CommonOutput;
                if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                if (output.KetQua == 1)
                {
                    model.KetQua = 1;
                    model.ThongBao = ConstantValues.Message.ThanhCong;
                    ViewBag.KetQua = 1;
                    return PartialView("_ThemCapNhatPartial", new CommonNguoiDung.NguoiDungOutput.ThongTin());
                }
                else
                {
                    ViewBag.KetQua = 0;
                    return PartialView("_ThemCapNhatPartial", new CommonNguoiDung.NguoiDungOutput.ThongTin());
                }
            }
            catch (Exception ex)
            {
                ViewBag.KetQua = 0;
                model.KetQua = 0;
                model.ThongBao = ConstantValues.Message.ThatBai;
                return PartialView("_ThemCapNhatPartial", new CommonNguoiDung.NguoiDungOutput.ThongTin());
            }
        }
        [HttpPost]
        public ActionResult XuLyXoaDanhSach(List<string> danhSachId)
        {
            var model = new CommonOutput();
            TempData["returnUrl"] = Url.Action("Index", "NguoiDung", new { Areas = "NguoiDung" });
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.QuanLyTaiKhoan, QuyenHan.Ma.Xoa))
            {
                model.KetQua = 0;
                model.ThongBao = ConstantValues.Message.KhongCoQuyen;
                model.TongSoLuong = "";
                return Json(model);
            }
            
            try
            {
                var input = new CommonInput.XoaDanhSachInput2();
                input.Ids = danhSachId;
                var output = XuLyAPI.ApiJsonPost(APIUrl.NguoiDung.XoaDanhSach, input) as CommonOutput;
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

        #region Đăng nhập trực tiếp thông qua chọn tên tài khoản của quản trị
        [HttpPost]
        public ActionResult DangNhapTheoIdNguoiDung(string IdNguoiDung)
        {
            //TempData["returnUrl"] = Url.Action("Index", "NguoiDung");
            if (Session["UserToken"] == null) return Json(false);
            var quyenTruyCap = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.QuanLyTaiKhoan, QuyenHan.Ma.Xoa);
            if (quyenTruyCap == null || quyenTruyCap.KetQua < 0) return Json(false);
            try
            {
                //Đọc thông tin tài khoản
                var input = new DangNhapTheoIdNguoiDungInput();
                input.IdNguoiDung = IdNguoiDung;
                var output = XuLyAPI.ApiJsonPost(APIUrl.NguoiDung.DangNhapTheoIdNguoiDung, input) as CommonOutput;
                Session.Clear();

                // Thành công
                var userLogin = JsonConvert.DeserializeObject<CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan>(output.DuLieu.ToString());
                Session["UserToken"] = new CommonInput.UserToken { TokenApi = userLogin.TokenApi, TokenNguoiDung = userLogin.TokenNguoiDung };
                Session["UserInfo"] = userLogin;
                Session["MaDonVi"] = userLogin.MaDonVi;
                Session["TenNguoiDung"] = userLogin.Ten;
                var input2 = new CommonTinh.TinhInput.DocThongTin();
                var outputTinh = XuLyAPI.ApiJsonPost(APIUrl.Tinh.DocThongTin, input2) as CommonOutput;
                if (outputTinh != null /*&& output.KetQua == 1*/)
                    Session["Tinh"] = JsonConvert.DeserializeObject<CommonTinh.TinhOutput.ThongTinTinh>(outputTinh.DuLieu.ToString());
                else
                    Session["Tinh"] = null;
                return Json(true);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Json(false);
            }
        }
        #endregion
    }
}