using Common.Enum;
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

namespace MVCProjectStructure.Areas.NguoiDung.Controllers
{
    public class PhanQuyenController : Controller
    {
        #region Phân quyền
        public ActionResult Index()
        {
            TempData["returnUrl"] = Url.Action("Index", "PhanQuyen", new { Areas = "NguoiDung" });
            //if (Session["UserToken"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            // if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.PhanQuyen, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);
            return View();
        }
        private List<CommonPhanQuyen.PhanQuyenOutput.ThongTin_ThuGon> DocDanhSach()
        {
            var input = new CommonInput.DocDanhSach();
            var output = XuLyAPI.ApiJsonPost(APIUrl.PhanQuyen.DocDanhSach, input) as CommonOutput;
            if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
            if (output.KetQua != 1) throw new Exception(output.ThongBao);
            var duLieuOutput = JsonConvert.DeserializeObject<List<CommonPhanQuyen.PhanQuyenOutput.ThongTin_ThuGon>>(output.DuLieu.ToString());
            return duLieuOutput;
        }
        public ActionResult XemDanhSach()
        {
            TempData["returnUrl"] = Url.Action("Index", "PhanQuyen", new { Areas = "NguoiDung" });
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            // if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.PhanQuyen, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);

            try
            {
                var danhSach = DocDanhSach();
                return PartialView("_DanhSachPartial", danhSach);
            }
            catch (Exception)
            {
                TempData["Error"] = ConstantValues.Message.LoiDuLieu;
                return PartialView("_DanhSachPartial");
            }
        }
        [HttpPost]
        public ActionResult ThongTinThemCapNhat(string Id)
        {
            var duLieuOutput = new CommonPhanQuyen.PhanQuyenOutput.ThongTinPhanQuyen();
            ViewBag.DanhSachChucNangXuLy = DocDanhSachChucNangXuLy();
            ViewBag.DanhSachVaiTro = DocDanhSachVaiTro();
            ViewBag.DanhSachDonVi = DocDanhSachDonVi();
            ViewBag.DanhSachNhom = StaticList.NhomMenus();
            ViewBag.DanhSachViTri = StaticList.ViTriMenus();
            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    var input = new CommonInput.DocThongTinInput { Id = Id };
                    var output = XuLyAPI.ApiJsonPost(APIUrl.PhanQuyen.DocThongTin, input) as CommonOutput;
                    if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                    if (output.KetQua != 1) throw new Exception(output.ThongBao);
                    duLieuOutput = JsonConvert.DeserializeObject<CommonPhanQuyen.PhanQuyenOutput.ThongTinPhanQuyen>(output.DuLieu.ToString());
                }
                else
                {
                    var input = new CommonInput.DocDanhSach();
                    var output = XuLyAPI.ApiJsonPost(APIUrl.Menu.DocDanhSachCoPhanCap, input) as CommonOutput;
                    if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                    if (output.KetQua != 1) throw new Exception(output.ThongBao);
                   var dsChucNang = JsonConvert.DeserializeObject<List<CommonPhanQuyen.PhanQuyenOutput.ThongTinPhanQuyen.ThongTinMenu>>(output.DuLieu.ToString());
                    duLieuOutput.DanhSachMenu = dsChucNang;
                }
            }
            catch (Exception)
            {
            }
            return PartialView("_ThemCapNhatPartial", duLieuOutput);
        }

        [HttpPost]
        public ActionResult XuLyLuu(CommonPhanQuyen.PhanQuyenInput.ThongTinPhanQuyen input)
        {
            TempData["returnUrl"] = Url.Action("Index", "PhanQuyen", new { Areas = "NguoiDung" });
            //var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.PhanQuyen, QuyenHan.Ma.Them);
            //ViewBag.KetQua = kiemTra.KetQua;
            //if (kiemTra.KetQua < 0) return PartialView("_ThemCapNhatPartial", new CommonPhanQuyen.PhanQuyenOutput.ThongTinPhanQuyen());

            var model = new CommonOutput();
            var input2 = new CommonPhanQuyen.PhanQuyenInput.ThongTinPhanQuyen();
            try
            {
                input2.Id = input.Id;
                input2.TenQuyen = input.TenQuyen;
                input2.MaVaiTro = input.MaVaiTro;
                input2.MaDonVi = input.MaDonVi;
                input2.DanhSachMenu = input.DanhSachMenu;
                var url = !string.IsNullOrEmpty(input.Id) ? APIUrl.PhanQuyen.Sua : APIUrl.PhanQuyen.Them;
                var output = XuLyAPI.ApiJsonPost(url, input) as CommonOutput;
                if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                if (output.KetQua == 1)
                {
                    model.KetQua = 1;
                    model.ThongBao = ConstantValues.Message.ThanhCong;
                    ViewBag.KetQua = 1;
                    return PartialView("_ThemCapNhatPartial", new CommonPhanQuyen.PhanQuyenOutput.ThongTinPhanQuyen());
                }
                else
                {
                    ViewBag.KetQua = 0;
                    return PartialView("_ThemCapNhatPartial", new CommonPhanQuyen.PhanQuyenOutput.ThongTinPhanQuyen());
                }
            }
            catch (Exception)
            {
                ViewBag.KetQua = 0;
                model.KetQua = 0;
                model.ThongBao = ConstantValues.Message.ThatBai;
                return PartialView("_ThemCapNhatPartial", new CommonPhanQuyen.PhanQuyenOutput.ThongTinPhanQuyen());
            }
        }
        [HttpPost]
        public ActionResult XuLyXoaDanhSach(List<string> danhSachId)
        {
            TempData["returnUrl"] = Url.Action("Index", "PhanQuyen", new { Areas = "NguoiDung" });
            //var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.PhanQuyen, QuyenHan.Ma.Xoa);
            //if (kiemTra.KetQua < 0) return Json(kiemTra);
            var model = new CommonOutput();
            try
            {
                var input = new CommonInput.XoaDanhSachInput2();
                input.Ids = danhSachId;
                var output = XuLyAPI.ApiJsonPost(APIUrl.PhanQuyen.XoaDanhSach, input) as CommonOutput;
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
        public ActionResult ChiTiet()
        {
            TempData["returnUrl"] = Url.Action("Index", "PhanQuyen", new { Areas = "NguoiDung" });
            //if (Session["UserToken"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            // if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.PhanQuyen, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);

            ViewBag.DanhSachVaiTro = DocDanhSachVaiTro();
            ViewBag.DanhSachDonVi = DocDanhSachDonVi();
            
            return View();
        }
        [HttpPost]
        public ActionResult CapNhat(string Id, string IdVaiTro, List<CommonPhanQuyen.PhanQuyenInput.ThongTinPhanQuyen.ThongTinMenu> DanhSachChucNang = null)
        {
            var model = new CommonOutput();
            try
            {
                var input = new CommonPhanQuyen.PhanQuyenInput.ThongTinPhanQuyen();
                input.Id = Id;
                input.MaVaiTro = IdVaiTro;
                input.DanhSachMenu = DanhSachChucNang;
                var output = XuLyAPI.ApiJsonPost(APIUrl.PhanQuyen.Sua, input) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                model.KetQua = 1;
                model.ThongBao = Message.CapNhatThanhCong;
            }
            catch (Exception)
            {
                model.KetQua = 0;
                model.ThongBao = Message.CapNhatThatBai;
            }
            return Json(model);
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
        private List<CommonChucNangXuLy.ChucNangXuLyOutput.ThongTin> DocDanhSachChucNangXuLy()
        {
            try
            {
                var input = new CommonChucNangXuLy.ChucNangXuLyInput.DocDanhSach();
                var output = XuLyAPI.ApiJsonPost(APIUrl.ChucNangXuLy.DocDanhSach, input) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var kq = JsonConvert.DeserializeObject<List<CommonChucNangXuLy.ChucNangXuLyOutput.ThongTin>>(output.DuLieu.ToString());
                return kq;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}