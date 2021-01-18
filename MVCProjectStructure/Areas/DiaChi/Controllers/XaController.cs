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
    public class XaController : Controller
    {
        // GET: DiaChi/Xa
        #region Huyện Xã Ấp
        private List<SelectListItem> LayDuLieuHuyen(string chuThich)
        {
            try
            {
                List<SelectListItem> lsNam = new List<SelectListItem>();
                //lsNam.Add(new SelectListItem() { Value = "0", Text = chuThich });
                var tinh = Session["Tinh"] as CommonTinh.TinhOutput.ThongTinTinh;
                if (tinh != null)
                {
                    lsNam.Add(new SelectListItem() { Value = tinh.Id, Text = "---Toàn tỉnh---" });

                    foreach (var huyen in tinh.DanhSachHuyen)
                    {
                        lsNam.Add(new SelectListItem() { Value = huyen.Id, Text = huyen.Ten });
                    }

                }
                return lsNam;
            }
            catch (Exception e)
            {
                return new List<SelectListItem>();
            }
        }
        public ActionResult DocDanhSachHuyenXaAp(string Loai = "", string Id = "")
        {
            SanXuatTrongTrotOutput.DanhSachHuyenCaMau duLieuOutput = new SanXuatTrongTrotOutput.DanhSachHuyenCaMau();
            if (Session["UserToken"] == null)
            {
                duLieuOutput.KetQua = -1;
                duLieuOutput.ThongBao = "Vui lòng đăng nhập lại!";
                return Json(duLieuOutput);
            }
            try
            {
                duLieuOutput.DuLieu = DocDanhSachCacCap(Loai, Id);
                duLieuOutput.KetQua = 1;

            }
            catch (Exception)
            {
                duLieuOutput.KetQua = 0;
                duLieuOutput.ThongBao = "Lỗi dữ liệu. ";
            }
            return Json(duLieuOutput);
        }
        private dynamic DocDanhSachCacCap(string Loai = "", string Id = "")
        {
            dynamic DanhSach = null;
            try
            {
                var input = new DocThongTinInput();
                input.Id = Id;
                var output = XuLyAPI.ApiJsonPost(APIUrl.Tinh.DocThongTincbb, input) as CommonOutput;
                if (output == null) throw new Exception("Lỗi Server");
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                if (output.DuLieu != null)
                {
                    var data = JsonConvert.DeserializeObject<TinhOutput.ThongTinTinh>(output.DuLieu.ToString());

                    if (Loai == "Huyen" && Id != "")
                    {
                        DanhSach = data.DanhSachHuyen;
                    }
                    else
                    {
                        foreach (var Huyen in data.DanhSachHuyen)
                        {
                            if (Loai == "Xa" && Id != "" && Id == Huyen.Id)//Id Huyen
                            {
                                DanhSach = Huyen.DanhSachXa;
                            }
                            else
                            {
                                foreach (var Xa in Huyen.DanhSachXa)
                                {
                                    if (Loai == "Ap" && Id != "" && Id == Xa.Id)//Id xã
                                    {
                                        DanhSach = Xa.DanhSachAp;
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception) { }
            return DanhSach;
        }
        #endregion
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
        private CommonXa.XaOutput.DocDanhSach DocDanhSach(string tukhoa = "", string idHuyen = "", int? trang = 1)
        {
            var currenPage = (trang == null || trang < 1) ? 1 : trang.Value;
            int soDongTrenTrang = PageNumber.Page20;
            int viTriBatDau = (currenPage - 1) * soDongTrenTrang;
            int tongSoDong = 0;
            var input = new CommonXa.XaInput.DocDanhSachWeb
            {
                TuKhoa = tukhoa.Trim().ToLower(),
                IdHuyen = idHuyen,
                ViTriBatDau = viTriBatDau,
                ViTriKetThuc = viTriBatDau + soDongTrenTrang
            };
            var output = XuLyAPI.ApiJsonPost(APIUrl.Xa.DocDanhSach, input) as CommonOutput;
            if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
            if (output.KetQua != 1) throw new Exception(output.ThongBao);
            var duLieuOutput = JsonConvert.DeserializeObject<CommonXa.XaOutput.DocDanhSach>(output.DuLieu.ToString());
            var kq = new CommonXa.XaOutput.DocDanhSach();
            kq.TrangHienTai = currenPage;
            tongSoDong = duLieuOutput.TongSoDong;
            kq.TongSoTrang = (tongSoDong % soDongTrenTrang > 0) ? tongSoDong / soDongTrenTrang + 1 : tongSoDong / soDongTrenTrang;
            kq.TongSoDong = tongSoDong;
            kq.DanhSach = duLieuOutput.DanhSach;
            return kq;
        }
        public ActionResult XemDanhSach(string tukhoa = "", string idHuyen = "", int? trang = 1)
        {
            var danhSachThamSo = new { tukhoa = tukhoa, idHuyen = idHuyen };
            ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
            TempData["returnUrl"] = Url.Action("Index", "Xa", new { Areas = "DiaChi" });
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            //if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.QuangCao, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);
            try
            {
                var danhSach = DocDanhSach(tukhoa, idHuyen, trang);
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
            ViewBag.DanhSachHuyen = LayDuLieuHuyen("");
            var duLieuOutput = new CommonXa.XaOutput.ThongTinTinhWeb();
            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    var input = new CommonInput.DocThongTinInput { Id = Id };
                    var output = XuLyAPI.ApiJsonPost(APIUrl.Xa.DocThongTin, input) as CommonOutput;
                    if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                    if (output.KetQua != 1) throw new Exception(output.ThongBao);
                    duLieuOutput = JsonConvert.DeserializeObject<CommonXa.XaOutput.ThongTinTinhWeb>(output.DuLieu.ToString());
                }
            }
            catch (Exception)
            {
            }
            return PartialView("_ThemCapNhatPartial", duLieuOutput);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult XuLyLuu(CommonXa.XaOutput.ThongTinTinhWeb input)
        {
            TempData["returnUrl"] = Url.Action("Index", "Xa", new { Areas = "DiaChi" });
            var inputTinh = new TinhInput.DocDanhSach();
            inputTinh.TuKhoa = "";
            var outputTinh = XuLyAPI.ApiJsonPost(APIUrl.Tinh.DocDanhSachWeb, inputTinh) as CommonOutput;
            if (outputTinh != null && outputTinh.KetQua == 1 && outputTinh.DuLieu != null)
            {
                var dsTinh = JsonConvert.DeserializeObject<CommonTinh.TinhOutput.DocDanhSachWebHuyen>(outputTinh.DuLieu.ToString());
                ViewBag.DanhSachTinh = dsTinh;
            }
            ViewBag.DanhSachHuyen = LayDuLieuHuyen("");
            var model = new CommonOutput();
            var input2 = new CommonXa.XaOutput.ThongTinTinhWeb();
            try
            {

                var url = !string.IsNullOrEmpty(input.Id) ? APIUrl.Xa.Sua : APIUrl.Xa.Them;
                var output = XuLyAPI.ApiJsonPost(url, input) as CommonOutput;
                if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                if (output.KetQua == 1)
                {
                    model.KetQua = 1;
                    model.ThongBao = ConstantValues.Message.ThanhCong;
                    ViewBag.KetQua = 1;
                    return PartialView("_ThemCapNhatPartial", new CommonXa.XaOutput.ThongTinTinhWeb());
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
            TempData["returnUrl"] = Url.Action("Index", "Xa", new { Areas = "DiaChi" });
            //var kiemTra = XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.QuangCao, QuyenHan.Ma.Xoa);
            //if(kiemTra.KetQua < 0) return Json(kiemTra);
            var model = new CommonOutput();
            try
            {
                var input = new CommonInput.XoaDanhSachInput2();
                input.Ids = danhSachId;
                var output = XuLyAPI.ApiJsonPost2(APIUrl.Xa.XoaDanhSach, input) as CommonOutput;
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