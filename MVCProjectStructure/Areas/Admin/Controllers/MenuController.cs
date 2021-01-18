using Common.Enum;
using Common.Utilities;
using MVCProjectStructure.Areas.Admin.Models.Menu;
using MVCProjectStructure.Helpers;
using MVCProjectStructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static Common.Enum.ConstantValues;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.Admin.Controllers
{
    //[RoutePrefix("quan-tri")]
    //[RouteArea("Admin", AreaPrefix = "quan-tri")]
    public class MenuController : Controller
    {
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

        public CommonMenu.MenuOutput.DocDanhSach DocDanhSach(string tuKhoa = "", int nhom = 0, int loai = 0)
        {

            var input = new CommonMenu.MenuInput.TimKiemMenu
            {
                TuKhoa = tuKhoa.Trim().ToLower(),
                Nhom = nhom,
                Loai = loai
            };
            var url = APIUrl.Menu.DocDanhSach;
            var output = XuLyAPI.ApiJsonPost(url, input) as CommonOutput;
            if (output == null)
                return null;
            if (output.KetQua != 1) throw new Exception(output.ThongBao);
            var duLieuOutput = JsonConvert.DeserializeObject<CommonMenu.MenuOutput.DocDanhSach>(output.DuLieu.ToString());
            var kq = new CommonMenu.MenuOutput.DocDanhSach();
            kq.DanhSach = duLieuOutput.DanhSach;
            return kq;
        }

        [SessionCheck]
        public ActionResult XemDanhSach(string tukhoa = "", int nhom = 0, int loai = 0)
        {
            var danhSachThamSo = new { tukhoa = tukhoa };
            ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
            TempData["returnUrl"] = Url.Action("Index", "Menu", new { Areas = "Admin" });
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.Menu, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);

            try
            {
                var danhSach = DocDanhSach(tukhoa, nhom, loai);
                return PartialView("_PartialDanhSach", danhSach);
            }
            catch (Exception ex)
            {
                //Ghi log
                TempData["Error"] = Message.LoiDuLieu;
                return PartialView("_PartialDanhSach");
            }
        }

        //[Route("trang-chu")]
        public ActionResult Index()
        {
            TempData["returnUrl"] = Url.Action("Index", "Menu", new { Areas = "Admin" });
            if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.Menu, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);

            try
            {
                string tuKhoa = "";
                int nhom = 0;
                int loai = 0;
                if (!string.IsNullOrEmpty(Request.QueryString["tukhoa"]))
                {
                    tuKhoa = Request.QueryString["tukhoa"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["nhom"]))
                {
                    nhom = int.Parse(Request.QueryString["nhom"]);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["loai"]))
                {
                    loai = int.Parse(Request.QueryString["loai"]);
                }
                var danhSach = DocDanhSach(tuKhoa, nhom, loai);
                return View(danhSach);
            }
            catch (Exception ex)
            {
                TempData["Error"] = Message.LoiDuLieu;
                return View();
            }
        }
        [SessionCheck]
        public ActionResult PartialMenuLeft()
        {
            var danhSach = new List<MenuModel.MenuOutput.ThongTinMenuPhanCap>();
            if (Session["UserInfo"] != null)
            {
                var userInfo = Session["UserInfo"] as CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan;
                if (userInfo.DanhSachMenuPhanCap != null)
                {
                    danhSach = userInfo.DanhSachMenuPhanCap;
                }
            }
            //var danhSach = DocDanhSach("", 0, 0);
            
            return PartialView("_PartialMenuLeft", danhSach);
        }

        private CommonMenu.MenuOutput.DanhSachDanhMucChucNang DocDanhMucChucNang()
        {
            var input = new CommonMenu.MenuInput.TimKiemMenu
            {
                TuKhoa = ""
            };
            var kq = new CommonMenu.MenuOutput.DanhSachDanhMucChucNang();
            var output = XuLyAPI.ApiJsonPost(APIUrl.DanhMucChucNang.DocDanhSach, input, false) as CommonOutput;
            if (output == null) return kq;
            if (output.KetQua != 1) return kq;
            var duLieuOutput = JsonConvert.DeserializeObject<CommonMenu.MenuOutput.DanhSachDanhMucChucNang>(output.DuLieu.ToString());
            
            kq.DanhSach = duLieuOutput.DanhSach;
            return kq;
        }

        [HttpPost]
        public ActionResult ThongTinThemCapNhat(string Id)
        {
            var duLieuOutput = new CommonMenu.MenuOutput.ThongTin();
            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    var input = new CommonInput.DocThongTinInput { Id = Id };
                    var output = XuLyAPI.ApiJsonPost(APIUrl.Menu.DocThongTin, input) as CommonOutput;
                    if (output == null) throw new Exception(Message.LoiServer);
                    if (output.KetQua != 1) throw new Exception(output.ThongBao);
                    duLieuOutput = JsonConvert.DeserializeObject<CommonMenu.MenuOutput.ThongTin>(output.DuLieu.ToString());
                }
            }
            catch (Exception)
            {
            }
            return PartialView("_PartialThemCapNhat", duLieuOutput);
        }

        [HttpPost]
        public ActionResult ThemCapNhatMenu(string id)
        {
            ViewBag.DanhSachDonVi = DocDanhSachDonVi();

            var danhsach = DocDanhSach("", 0, 0);
            var data = new MenuModel.MenuOutput.ThemCapNhatMenu();
            data.DanhSachMenu = danhsach.DanhSach;
            var thongtin = new MenuModel.MenuOutput.ThongTin();
            var outputDanhMucChucNang = DocDanhMucChucNang();
            if (outputDanhMucChucNang != null)
            {
                data.DanhMucChucNang = outputDanhMucChucNang.DanhSach;
            }
            if (!string.IsNullOrEmpty(id))
            {
                var input = new CommonInput.DocThongTinInput();
                input.Id = id;
                var output = XuLyAPI.ApiJsonPost(APIUrl.Menu.DocThongTin, input) as CommonOutput;
                if (output.KetQua == 1)
                {
                    thongtin = JsonConvert.DeserializeObject<MenuModel.MenuOutput.ThongTin>(output.DuLieu.ToString());
                    data.ThongTinMenu = thongtin;
                }
            }
            return PartialView("_PartialThemCapNhat", data);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult XuLyLuu(CommonMenu.MenuInput.ThongTin input)
        {
            
            TempData["returnUrl"] = Url.Action("Index", "Menu", new { Areas = "Admin" });
            var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.QuangCao, QuyenHan.Ma.Them);
            ViewBag.KetQua = kiemTra.KetQua;
            if (kiemTra.KetQua < 0) return PartialView("_PartialThemCapNhat", new CommonMenu.MenuOutput.ThongTin());

            var danhsach = DocDanhSach("", 0, 0);
            var data = new MenuModel.MenuOutput.ThemCapNhatMenu();
            data.DanhSachMenu = danhsach.DanhSach;
            var thongtin = new MenuModel.MenuOutput.ThongTin();
            var outputDanhMucChucNang = DocDanhMucChucNang();
            if (outputDanhMucChucNang != null)
            {
                data.DanhMucChucNang = outputDanhMucChucNang.DanhSach;
            }
            

            var model = new CommonOutput();
            var input2 = new CommonMenu.MenuOutput.ThongTin();
            try
            {
                input2.Id = input.Id;
                input2.Ten = input.Ten;
                input2.Ma = input.Ma;
                input2.Icon = input.Icon;
                input2.IdMenuCha = input.IdMenuCha;
                input2.LienKet = input.LienKet;
                input2.Nhom = input.Nhom;
                input2.Loai = input.Loai;
                input2.ViTri = input.ViTri;
                input2.KichHoat = input.KichHoat;
                input2.MoTa = input.MoTa;
                input2.BieuTuong = input.BieuTuong;
                input2.KieuHienThi = input.KieuHienThi;
                var url = !string.IsNullOrEmpty(input.Id) ? APIUrl.Menu.CapNhat : APIUrl.Menu.Them;
                var output = XuLyAPI.ApiJsonPost(url, input) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua == 1)
                {
                    model.KetQua = 1;
                    model.ThongBao = Message.ThanhCong;
                    ViewBag.KetQua = 1;

                    return PartialView("_PartialThemCapNhat", data);
                }
                else
                {
                    ViewBag.KetQua = 0;
                    data.ThongTinMenu = input2;
                    return PartialView("_PartialThemCapNhat", data);
                }
            }
            catch (Exception ex)
            {
                ViewBag.KetQua = 0;
                model.KetQua = 0;
                model.ThongBao = Message.ThatBai;
                return PartialView("_PartialThemCapNhat", input2);
            }
        }

        [HttpPost]
        public ActionResult XuLyXoaDanhSach(List<string> danhSachId)
        {
            TempData["returnUrl"] = Url.Action("Index", "Menu", new { Areas = "Admin" });
            var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.Menu, QuyenHan.Ma.Xoa);
            if (kiemTra.KetQua < 0) return Json(kiemTra);
            var model = new CommonOutput();
            try
            {
                var input = new CommonInput.XoaDanhSachInput2();
                input.Ids = danhSachId;
                var output = XuLyAPI.ApiJsonPost(APIUrl.Menu.XoaDanhSach, input) as CommonOutput;
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

        [HttpPost]
        public ActionResult XuLyCapNhatViTri(MenuModel.MenuInput.CapNhatViTri danhSachId)
        {
            TempData["returnUrl"] = Url.Action("Index", "Menu", new { Areas = "Admin" });
            var model = new CommonOutput();
            try
            {
                var output = XuLyAPI.ApiJsonPost(APIUrl.Menu.CapNhatViTri, danhSachId) as CommonOutput;
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
            catch (Exception ex)
            {
                model.KetQua = 0;
                model.ThongBao = Message.ThatBai;
                model.ThongBao = ex.ToString();
            }
            return Json(model);
        }

        [HttpPost]
        public ActionResult DocDanhSachLienKet(string DuongDan)
        {
            try
            {
                //APIUrl.BaiViet.DocDanhSach
                var input = new CommonInput.ChungThuc();
                //var output = XuLyAPI.ApiJsonPost(DuongDan, input) as MVCProjectStructure.Models.Common.Output;
                //var danhsach = JsonConvert.DeserializeObject<BaiVietModel.Output.ThongTinKetQua>(output.DuLieu.ToString());
                var output = XuLyAPI.ApiJsonPost(DuongDan, input) as CommonOutput;
                var danhsach = JsonConvert.DeserializeObject<MenuModel.MenuOutput.DuLieu>(output.DuLieu.ToString());
                return Json(danhsach.DanhSach);
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        [HttpPost]
        public ActionResult DocDanhSachFormThemSua(string tukhoa = "", int nhom = 0, int loai = 0)
        {
            try
            {
                var input = new CommonMenu.MenuInput.TimKiemMenu
                {
                    TuKhoa = tukhoa.Trim().ToLower(),
                    Nhom = nhom,
                    Loai = loai
                };
                var url = APIUrl.Menu.DocDanhSach;
                var output = XuLyAPI.ApiJsonPost(url, input) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var danhSach = JsonConvert.DeserializeObject<CommonMenu.MenuOutput.DocDanhSach>(output.DuLieu.ToString());
                return Json(danhSach.DanhSach);
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}