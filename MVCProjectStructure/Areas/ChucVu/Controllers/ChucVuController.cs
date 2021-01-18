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

namespace MVCProjectStructure.Areas.ChucVu.Controllers
{
    public class ChucVuController : Controller
    {
        public ActionResult Index()
        {
            //TempData["returnUrl"] = Url.Action("Index", "Manage", new { Areas = "ChucVu" });
            ////if (Session["UserToken"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            //if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.ChucVu, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);
            try
            {
                ViewBag.Active = "ChucVu";

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
                ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
                var danhSach = DocDanhSach();
                return View(danhSach);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ConstantValues.Message.LoiDuLieu;
                return View();
            }
        }
        private CommonChucVu.ChucVuOutput.DocDanhSachChucVu DocDanhSach(string tuKhoa = "", int? trangHienTai = 1)
        {
            var currenPage = (trangHienTai == null || trangHienTai < 1) ? 1 : trangHienTai.Value;
            int soDongTrenTrang = PageNumber.Default;
            int viTriBatDau = (currenPage - 1) * soDongTrenTrang;
            int tongSoDong = 0;
            var input = new CommonChucVu.ChucVuInput.TimKiemChucVu
            {
                TuKhoa = tuKhoa.Trim().ToLower(),
                ViTriBatDau = viTriBatDau,
                ViTriKetThuc = viTriBatDau + soDongTrenTrang
            };
            var output = XuLyAPI.ApiJsonPost(APIUrl.ChucVu.DocDanhSach, input) as CommonOutput;
            if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
            if (output.KetQua != 1) throw new Exception(output.ThongBao);
            var duLieuOutput = JsonConvert.DeserializeObject<CommonChucVu.ChucVuOutput.DocDanhSachChucVu>(output.DuLieu.ToString());
            var kq = new CommonChucVu.ChucVuOutput.DocDanhSachChucVu();
            kq.TrangHienTai = currenPage;
            tongSoDong = duLieuOutput.TongSoDong;
            kq.TongSoTrang = (tongSoDong % soDongTrenTrang > 0) ? tongSoDong / soDongTrenTrang + 1 : tongSoDong / soDongTrenTrang;
            kq.TongSoDong = tongSoDong;
            kq.DanhSach = duLieuOutput.DanhSach;
            return kq;
        }
        public ActionResult XemDanhSach(string tukhoa = "", int? trang = 1)
        {
            var danhSachThamSo = new { tukhoa = tukhoa, trang = trang };
            ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
            //TempData["returnUrl"] = Url.Action("Index", "NguoiDung");
            //if (Session["UserToken"] == null) return RedirectToAction("Login", "TaiKhoan");
            //if (!TaiKhoanModel.KiemTraQuyenTruyCap("Index", "NguoiDung")) return RedirectToAction("Index", "Home");
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

        [HttpPost]
        public ActionResult ThongTinThemCapNhat(string Id)
        {
            var duLieuOutput = new CommonChucVu.ChucVuOutput.ThongTinChucVu();
            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    var input = new CommonInput.DocThongTinInput { Id = Id };
                    var output = XuLyAPI.ApiJsonPost(APIUrl.ChucVu.DocThongTin, input) as CommonOutput;
                    if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                    if (output.KetQua != 1) throw new Exception(output.ThongBao);
                    duLieuOutput = JsonConvert.DeserializeObject<CommonChucVu.ChucVuOutput.ThongTinChucVu>(output.DuLieu.ToString());
                }
            }
            catch (Exception)
            {
            }
            return PartialView("_ThemCapNhatPartial", duLieuOutput);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult XuLyLuu(CommonChucVu.ChucVuInput.ThongTinChucVu input)
        {
            var model = new CommonOutput();
            var input2 = new CommonChucVu.ChucVuOutput.ThongTinChucVu();
            ViewBag.DanhSachViTri = StaticList.ViTriChucVus();
            ViewBag.DanhSachThuocTrang = StaticList.ThuocTrangs();
            try
            {
                input2.Id = input.Id;
                input2.Ten = input.Ten;
                input2.MoTa = input.MoTa;
                input2.ThuTu = input.ThuTu;
                input2.KichHoat = input.KichHoat;
                input2.Ma = input.Ma;
                var url = !string.IsNullOrEmpty(input.Id) ? APIUrl.ChucVu.Sua : APIUrl.ChucVu.Them;
                var output = XuLyAPI.ApiJsonPost(url, input) as CommonOutput;
                if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                if (output.KetQua == 1)
                {
                    model.KetQua = 1;
                    model.ThongBao = ConstantValues.Message.ThanhCong;
                    ViewBag.KetQua = 1;
                    return PartialView("_ThemCapNhatPartial", new CommonChucVu.ChucVuOutput.ThongTinChucVu());
                }
                else
                {
                    return PartialView("_ThemCapNhatPartial", input2);
                }
            }
            catch (Exception ex)
            {
                model.KetQua = 0;
                model.ThongBao = ConstantValues.Message.ThatBai;
                return PartialView("_ThemCapNhatPartial", input2);
            }
        }
        [HttpPost]
        public ActionResult XuLyXoaDanhSach(List<string> danhSachId)
        {
            var model = new CommonOutput();
            try
            {
                var input = new CommonInput.XoaDanhSachInput2();
                input.Ids = danhSachId;
                var output = XuLyAPI.ApiJsonPost(APIUrl.ChucVu.XoaDanhSach, input) as CommonOutput;
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
            }
            return Json(model);
        }
    }
}