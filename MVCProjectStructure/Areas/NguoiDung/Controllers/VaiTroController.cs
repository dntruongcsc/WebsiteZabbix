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

namespace MVCProjectStructure.Areas.NguoiDung.Controllers
{
    public class VaiTroController : Controller
    {
        public ActionResult Index()
        {
            TempData["returnUrl"] = Url.Action("Index", "VaiTro", new { Areas = "NguoiDung" });
            if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            //if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.VaiTro, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);

            try
            {
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
                var DanhSachDonVi = DocDanhSachDonVi();
                ViewBag.DanhSachDonViTimKiem = DanhSachDonVi;
                //var danhSach = DocDanhSach();
                return View();
            }
            catch (Exception)
            {
                TempData["Error"] = ConstantValues.Message.LoiDuLieu;
                return View();
            }
        }
        private CommonVaiTro.VaiTroOutput.DocDanhSach DocDanhSach(string tuKhoa = "", string DonVi = "", int? trangHienTai = 1)
        {
            var currenPage = (trangHienTai == null || trangHienTai < 1) ? 1 : trangHienTai.Value;
            int soDongTrenTrang = PageNumber.Default;
            int viTriBatDau = (currenPage - 1) * soDongTrenTrang;
            int tongSoDong = 0;
            var input = new CommonVaiTro.VaiTroInput.TimKiemVaiTro
            {
                TuKhoa = tuKhoa.Trim().ToLower(),
                IdDonVi = DonVi,
                ViTriBatDau = viTriBatDau,
                ViTriKetThuc = viTriBatDau + soDongTrenTrang
            };
            var output = XuLyAPI.ApiJsonPost(APIUrl.VaiTro.DocDanhSach, input) as CommonOutput;
            if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
            if (output.KetQua != 1) throw new Exception(output.ThongBao);
            var duLieuOutput = JsonConvert.DeserializeObject<List<CommonVaiTro.VaiTroOutput.ThongTinVaiTro>>(output.DuLieu.ToString());
            var kq = new CommonVaiTro.VaiTroOutput.DocDanhSach();
            kq.TrangHienTai = currenPage;
            tongSoDong = duLieuOutput.Count;
            kq.TongSoTrang = (tongSoDong % soDongTrenTrang > 0) ? tongSoDong / soDongTrenTrang + 1 : tongSoDong / soDongTrenTrang;
            kq.TongSoDong = tongSoDong;
            kq.DanhSach = duLieuOutput;
            return kq;
        }
        private List<CommonDonVi.DonViOutput.ThongTinDonVi> DocDanhSachDonVi()
        {
            var kq = new List<CommonDonVi.DonViOutput.ThongTinDonVi> ();
            try
            {
                var input = new CommonDonVi.DonViInput.DocDanhSach();
                var output = XuLyAPI.ApiJsonPost(APIUrl.DonVi.DocDanhSach, input) as CommonOutput;
                if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var duLieuOutput = JsonConvert.DeserializeObject<List<CommonDonVi.DonViOutput.ThongTinDonVi>>(output.DuLieu.ToString());
                kq = duLieuOutput;
            }
            catch (Exception ex)
            {
            }
            return kq;
        }
        [SessionCheck]
        public ActionResult XemDanhSach(string tukhoa = "", string DonVi = "", int? trang = 1)
        {
            var danhSachThamSo = new { tukhoa = tukhoa, NenTang = DonVi };
            ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
            TempData["returnUrl"] = Url.Action("Index", "VaiTro", new { Areas = "NguoiDung" });
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            //if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.VaiTro, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);

            try
            {
                var danhSach = DocDanhSach(tukhoa, DonVi, trang);
                return PartialView("_DanhSachPartial", danhSach);
            }
            catch (Exception)
            {
                //Ghi log
                TempData["Error"] = ConstantValues.Message.LoiDuLieu;
                return PartialView("_DanhSachPartial");
            }
        }
        [SessionCheck]
        public ActionResult ThemCapNhat(string Id)
        {
            TempData["returnUrl"] = Url.Action("Index", "VaiTro", new { Areas = "NguoiDung" });
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            //if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.VaiTro, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);
            var model = new CommonModel.CommonVaiTro.VaiTroOutput.ThongTinVaiTro();
            try
            {
                
                var DanhSachDonVi = DocDanhSachDonVi();
                ViewBag.DanhSachDonVi = DanhSachDonVi;
                //var danhSach = DocDanhSach();
                return View(model);
            }
            catch (Exception)
            {
                TempData["Error"] = ConstantValues.Message.LoiDuLieu;
                return View(model);
            }
        }
        
        [HttpPost]
        public ActionResult XuLyXoaDanhSach(List<string> danhSachId)
        {
            TempData["returnUrl"] = Url.Action("Index", "QuangCao", new { Areas = "QuangCao" });
            var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.QuangCao, QuyenHan.Ma.Xoa);
            if (kiemTra.KetQua < 0) return Json(kiemTra);
            var model = new CommonOutput();
            try
            {
                var input = new CommonInput.XoaDanhSachInput2();
                input.Ids = danhSachId;
                var output = XuLyAPI.ApiJsonPost2(APIUrl.QuangCao.XoaDanhSach, input) as CommonOutput;
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