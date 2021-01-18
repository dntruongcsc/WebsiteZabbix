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


namespace MVCProjectStructure.Areas.DiaChi.Controllers
{
    public class HuyenController : Controller
    {
        // GET: DiaChi/Huyen
        public ActionResult Index()
        {
            var inputTinh = new TinhInput.DocDanhSach();
            inputTinh.TuKhoa = "";
            var outputTinh = XuLyAPI.ApiJsonPost(APIUrl.Tinh.DocDanhSachWeb, inputTinh) as CommonOutput;
            if (outputTinh != null && outputTinh.KetQua == 1 && outputTinh.DuLieu != null)
            {
                var dsTinh = JsonConvert.DeserializeObject<CommonTinh.TinhOutput.DocDanhSachWebHuyen>(outputTinh.DuLieu.ToString());
                ViewBag.DanhSachTinh = dsTinh;
            }
            return View();
        }
        private CommonHuyen.HuyenOutput.DocDanhSach DocDanhSach(string tukhoa = "", string idTinh = "", int? trang = 1)
        {
            var currenPage = (trang == null || trang < 1) ? 1 : trang.Value;
            int soDongTrenTrang = PageNumber.Page20;
            int viTriBatDau = (currenPage - 1) * soDongTrenTrang;
            int tongSoDong = 0;
            var input = new CommonHuyen.HuyenInput.DocDanhSachWeb
            {
                TuKhoa = tukhoa.Trim().ToLower(),
                IdTinh = idTinh,
                ViTriBatDau = viTriBatDau,
                ViTriKetThuc = viTriBatDau + soDongTrenTrang
            };
            var output = XuLyAPI.ApiJsonPost(APIUrl.Huyen.DocDanhSach, input) as CommonOutput;
            if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
            if (output.KetQua != 1) throw new Exception(output.ThongBao);
            var duLieuOutput = JsonConvert.DeserializeObject<CommonHuyen.HuyenOutput.DocDanhSach>(output.DuLieu.ToString());
            var kq = new CommonHuyen.HuyenOutput.DocDanhSach();
            kq.TrangHienTai = currenPage;
            tongSoDong = duLieuOutput.TongSoDong;
            kq.TongSoTrang = (tongSoDong % soDongTrenTrang > 0) ? tongSoDong / soDongTrenTrang + 1 : tongSoDong / soDongTrenTrang;
            kq.TongSoDong = tongSoDong;
            kq.DanhSach = duLieuOutput.DanhSach;
            return kq;
        }
        public ActionResult XemDanhSach(string tukhoa = "", string idTinh = "", int? trang = 1)
        {
            var danhSachThamSo = new { tukhoa = tukhoa, idTinh = idTinh };
            ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
            TempData["returnUrl"] = Url.Action("Index", "Huyen", new { Areas = "DiaChi" });
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            //if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.QuangCao, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);
            try
            {
                var danhSach = DocDanhSach(tukhoa, idTinh, trang);
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
            var inputTinh = new TinhInput.DocDanhSach();
            inputTinh.TuKhoa = "";
            var outputTinh = XuLyAPI.ApiJsonPost(APIUrl.Tinh.DocDanhSachWeb, inputTinh) as CommonOutput;
            if (outputTinh != null && outputTinh.KetQua == 1 && outputTinh.DuLieu != null)
            {
                var dsTinh = JsonConvert.DeserializeObject<CommonTinh.TinhOutput.DocDanhSachWebHuyen>(outputTinh.DuLieu.ToString());
                ViewBag.DanhSachTinh = dsTinh;
            }
            var duLieuOutput = new CommonHuyen.HuyenOutput.ThongTinTinhWeb();
            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    var input = new CommonInput.DocThongTinInput { Id = Id };
                    var output = XuLyAPI.ApiJsonPost(APIUrl.Huyen.DocThongTin, input) as CommonOutput;
                    if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                    if (output.KetQua != 1) throw new Exception(output.ThongBao);
                    duLieuOutput = JsonConvert.DeserializeObject<CommonHuyen.HuyenOutput.ThongTinTinhWeb>(output.DuLieu.ToString());
                }
            }
            catch (Exception)
            {
            }
            return PartialView("_ThemCapNhatPartial", duLieuOutput);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult XuLyLuu(CommonHuyen.HuyenOutput.ThongTinTinhWeb input)
        {
            TempData["returnUrl"] = Url.Action("Index", "Huyen", new { Areas = "DiaChi" });
            var inputTinh = new TinhInput.DocDanhSach();
            inputTinh.TuKhoa = "";
            var outputTinh = XuLyAPI.ApiJsonPost(APIUrl.Tinh.DocDanhSachWeb, inputTinh) as CommonOutput;
            if (outputTinh != null && outputTinh.KetQua == 1 && outputTinh.DuLieu != null)
            {
                var dsTinh = JsonConvert.DeserializeObject<CommonTinh.TinhOutput.DocDanhSachWebHuyen>(outputTinh.DuLieu.ToString());
                ViewBag.DanhSachTinh = dsTinh;
            }
            var model = new CommonOutput();
            var input2 = new CommonHuyen.HuyenOutput.ThongTinTinhWeb();
            try
            {

                var url = !string.IsNullOrEmpty(input.Id) ? APIUrl.Huyen.Sua : APIUrl.Huyen.Them;
                var output = XuLyAPI.ApiJsonPost(url, input) as CommonOutput;
                if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                if (output.KetQua == 1)
                {
                    model.KetQua = 1;
                    model.ThongBao = ConstantValues.Message.ThanhCong;
                    ViewBag.KetQua = 1;
                    return PartialView("_ThemCapNhatPartial", new CommonHuyen.HuyenOutput.ThongTinTinhWeb());
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
            TempData["returnUrl"] = Url.Action("Index", "Huyen", new { Areas = "DiaChi" });
            //var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.QuangCao, QuyenHan.Ma.Xoa);
            //if(kiemTra.KetQua < 0) return Json(kiemTra);
            var model = new CommonOutput();
            try
            {
                var input = new CommonInput.XoaDanhSachInput2();
                input.Ids = danhSachId;
                var output = XuLyAPI.ApiJsonPost2(APIUrl.Huyen.XoaDanhSach, input) as CommonOutput;
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