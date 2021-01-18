using MVCProjectStructure.Helpers;
using MVCProjectStructure.Models;
using Common.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProjectStructure.Areas.PhanAnhNhanh.Models;
using static MVCProjectStructure.Models.CommonModel;
using Common.Utilities;

namespace MVCProjectStructure.Areas.PhanAnhNhanh.Controllers
{
    public class PhanAnhNhanhController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.DanhSachLoaiPhanAnh = DanhSachLoaiPhanAnh();
            return View();
        }


        public List<LoaiPhanAnhOutput.DocDanhSachOutput> DanhSachLoaiPhanAnh()
        {
            try
            {
                CommonInput.DocDanhSach input = new CommonInput.DocDanhSach();
                var output = new CommonOutput();
                output = XuLyAPI.ApiJsonPost2(APIUrl.LoaiHinhPhanAnh.DocDanhSach, input) as CommonOutput;
                var danhsach = JsonConvert.DeserializeObject<List<LoaiPhanAnhOutput.DocDanhSachOutput>>(JsonConvert.SerializeObject(output.DuLieu));
                return danhsach;
            }
            catch (Exception e)
            {
                //Ghi log
                return null;
            }
        }


        private PhanAnhNhanhModel.Output.DocDanhSach DocDanhSach(string tukhoa = "", string loai = "", string tinhtrang = "", int? trangHienTai = 1)
        {
            var currenPage = (trangHienTai == null || trangHienTai < 1) ? 1 : trangHienTai.Value;
            int soDongTrenTrang = PageNumber.Page20;
            int viTriBatDau = (currenPage - 1) * soDongTrenTrang;
            int tongSoDong = 0;
            var input = new PhanAnhNhanhModel.Input.DocDanhSach
            {
                ViTriBatDau = viTriBatDau,
                ViTriKetThuc = viTriBatDau + soDongTrenTrang
            };
            var output = XuLyAPI.ApiJsonPost(APIUrl.PhanAnhNhanh.DocDanhSach, input) as CommonOutput;
            if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
            if (output.KetQua != 1) throw new Exception(output.ThongBao);
            var duLieuOutput = JsonConvert.DeserializeObject<PhanAnhNhanhModel.Output.DocDanhSach>(output.DuLieu.ToString());
            var kq = new PhanAnhNhanhModel.Output.DocDanhSach();
            kq.TrangHienTai = currenPage;
            tongSoDong = duLieuOutput.TongSoDong;
            kq.TongSoTrang = (tongSoDong % soDongTrenTrang > 0) ? tongSoDong / soDongTrenTrang + 1 : tongSoDong / soDongTrenTrang;
            kq.TongSoDong = tongSoDong;
            kq.DanhSach = duLieuOutput.DanhSach;
            return kq;
        }

        [SessionCheck]
        public ActionResult XemDanhSach(string tukhoa = "", string loai = "", string tinhtrang = "", int? trang = 1)
        {
            var danhSachThamSo = new { tukhoa = tukhoa, loai = loai, tinhtrang = tinhtrang };
            ViewBag.DanhSachThamSo = Utility.ConvertOjectToGETParam(danhSachThamSo);
            TempData["returnUrl"] = Url.Action("Index", "PhanAnhNhanh", new { Areas = "PhanAnhNhanh" });
            try
            {
                var danhSach = DocDanhSach(tukhoa, loai, tinhtrang, trang);
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
            ViewBag.DanhSachLoaiPhanAnh = DanhSachLoaiPhanAnh();
            var duLieuOutput = new PhanAnhNhanhModel.Output.ThongTin();
            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    var input = new CommonInput.DocThongTinInput { Id = Id };
                    var output = XuLyAPI.ApiJsonPost(APIUrl.PhanAnhNhanh.DocThongTin, input) as CommonOutput;
                    if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                    if (output.KetQua != 1) throw new Exception(output.ThongBao);
                    duLieuOutput = JsonConvert.DeserializeObject<PhanAnhNhanhModel.Output.ThongTin>(output.DuLieu.ToString());
                }
            }
            catch (Exception ex)
            {
            }
            return PartialView("_ThemCapNhatPartial", duLieuOutput);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult XuLyLuu(PhanAnhNhanhModel.Input.Them input)
        {
            TempData["returnUrl"] = Url.Action("Index", "PhanAnhNhanh", new { Areas = "PhanAnhNhanh" });
            ViewBag.DanhSachLoaiPhanAnh = DanhSachLoaiPhanAnh();
            var model = new CommonOutput();
            try
            {
                var url = !string.IsNullOrEmpty(input.Id) ? APIUrl.PhanAnhNhanh.Sua : APIUrl.PhanAnhNhanh.Them;
                var output = XuLyAPI.ApiJsonPost(url, input) as CommonOutput;
                if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                if (output.KetQua == 1)
                {
                    model.KetQua = 1;
                    model.ThongBao = ConstantValues.Message.ThanhCong;
                    ViewBag.KetQua = 1;
                    return PartialView("_ThemCapNhatPartial", new PhanAnhNhanhModel.Output.ThongTin());
                }
                else
                {
                    ViewBag.KetQua = 0;
                    return PartialView("_ThemCapNhatPartial", input);
                }
            }
            catch (Exception)
            {
                ViewBag.KetQua = 0;
                model.KetQua = 0;
                model.ThongBao = ConstantValues.Message.ThatBai;
                return PartialView("_ThemCapNhatPartial", input);
            }
        }
        [HttpPost]
        public ActionResult XuLyXoaDanhSach(List<string> danhSachId)
        {
            TempData["returnUrl"] = Url.Action("Index", "PhanAnhNhanh", new { Areas = "PhanAnhNhanh" });
            var model = new CommonOutput();
            try
            {
                var input = new CommonInput.XoaDanhSachInput2();
                input.Ids = danhSachId;
                var output = XuLyAPI.ApiJsonPost(APIUrl.PhanAnhNhanh.XoaDanhSach, input) as CommonOutput;
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

        //public static List<TinhOutput.ThongTinTinh> DanhSachTinh = new List<TinhOutput.ThongTinTinh>();
        //public static List<PhanAnhNhanhOutput.DocDanhSach> DanhSachPhanAnh = new List<PhanAnhNhanhOutput.DocDanhSach>();
        //public static List<LoaiPhanAnhOutput.DocDanhSachOutput> DanhSachLoaiPhanAnh = new List<LoaiPhanAnhOutput.DocDanhSachOutput>();
        // GET: PhanAnhNhanh
        //public ActionResult Index(int page = 1, PhanAnhNhanhInput.DocDanhSachInput input = null, string tuKhoa = "", int trangThai = -1)
        //{
        //    TempData["returnUrl"] = Url.Action("Index", "PhanAnhNhanh");
        //    if (Session["UserToken"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
        //    if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.PhanAnhNhanh, QuyenHan.Ma.Xem)) return RedirectToAction("Index", "Home");
        //    try
        //    {
        //        if (Session["UserToken"] == null)
        //        {
        //            Session["Url"] = Request.Url.AbsolutePath;
        //            return Redirect(ChucNang.DuongDan.DangNhap);
        //        }
        //        else
        //        {
        //            //đọc danh sách tỉnh
        //            //DocDanhSachTinh();

        //            //if (DanhSachLoaiPhanAnh == null || DanhSachLoaiPhanAnh.Count == 0)
        //            //{
        //            DocDanhSachInput inputLoaiHinh = new DocDanhSachInput();
        //            var userInfo = Session["UserInfo"] as CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan;
        //            var idQuanTri = "5a28a83618e6d9409c42d5e3";

        //            inputLoaiHinh.DanhSachIdDonVi = userInfo != null ? userInfo.DanhSachIdDonViTheoPhanQuyen : null;
        //            if (inputLoaiHinh.DanhSachIdDonVi.Contains(idQuanTri))
        //            {
        //                inputLoaiHinh.DanhSachIdDonVi = new List<string>();
        //            }
        //            var outputLoaiHinh = XuLyAPI.ApiJsonPost(APIUrl.LoaiHinhPhanAnh.DocDanhSach, inputLoaiHinh) as CommonOutput;
        //            if (outputLoaiHinh.KetQua != 1) return RedirectToAction("Index", "PhanAnhNhanh");
        //            DanhSachLoaiPhanAnh = JsonConvert.DeserializeObject<List<LoaiPhanAnhOutput.DocDanhSachOutput>>(JsonConvert.SerializeObject(outputLoaiHinh.DuLieu));
        //            //}
        //            if (input == null)
        //            {
        //                input = new PhanAnhNhanhInput.DocDanhSachInput();
        //                //input.IdLoaiPhanAnhNguoiDan = DanhSachLoaiPhanAnh[0].Id;
        //            }
        //            var model = XemMotTrang(input, page, tuKhoa, trangThai);
        //            ViewBag.NoiDungTim = input;

        //            return View(model);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        TempData["Error"] = ex.Message;
        //        return View();
        //    }
        //}

        //public List<TinhOutput.ThongTinTinh> DocDanhSachTinh()
        //{
        //    try
        //    {
        //        if (DanhSachTinh == null || DanhSachTinh.Count == 0)
        //        {
        //            DocDanhSachInput inputTinh = new DocDanhSachInput();
        //            var outputTinh = XuLyAPI.ApiJsonPost(APIUrl.Tinh.DocDanhSach, inputTinh) as CommonOutput;
        //            if (outputTinh.KetQua != 1) return null;
        //            DanhSachTinh = JsonConvert.DeserializeObject<List<TinhOutput.ThongTinTinh>>(JsonConvert.SerializeObject(outputTinh.DuLieu));
        //        }
        //        return DanhSachTinh;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //    finally { GC.Collect(); }
        //}
        //[HttpPost]
        //public object DocDanhSachHuyen(string idTinh)
        //{
        //    try
        //    {
        //        DocDanhSachTinh();
        //        var tinh = DanhSachTinh.FirstOrDefault(e => e.Id.Equals(idTinh));
        //        if (tinh != null && tinh.DanhSachHuyen != null && tinh.DanhSachHuyen.Count > 0)
        //        {
        //            return JsonConvert.SerializeObject(tinh.DanhSachHuyen);
        //        }
        //        return null;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //    finally { GC.Collect(); }
        //}
        //[HttpPost]
        //public object DocDanhSachXa(string idTinh, string idHuyen)
        //{
        //    try
        //    {
        //        DocDanhSachTinh();
        //        var tinh = DanhSachTinh.FirstOrDefault(e => e.Id.Equals(idTinh));
        //        var huyen = tinh.DanhSachHuyen.FirstOrDefault(e => e.Id.Equals(idHuyen));
        //        if (huyen != null)
        //        {
        //            return JsonConvert.SerializeObject(huyen.DanhSachXa);
        //        }
        //        return null;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //    finally { GC.Collect(); }
        //}
        //[HttpPost]
        //public object DocDanhSachAp(string idTinh, string idHuyen, string idXa)
        //{
        //    try
        //    {
        //        DocDanhSachTinh();
        //        var tinh = DanhSachTinh.FirstOrDefault(e => e.Id.Equals(idTinh));
        //        var huyen = tinh.DanhSachHuyen.FirstOrDefault(e => e.Id.Equals(idHuyen));
        //        var xa = huyen.DanhSachXa.FirstOrDefault(e => e.Id.Equals(idXa));
        //        if (xa != null)
        //        {
        //            return JsonConvert.SerializeObject(xa.DanhSachAp);
        //        }
        //        return null;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //    finally { GC.Collect(); }
        //}
        //public ActionResult DanhSach(PhanAnhNhanhInput.DocDanhSachInput input = null, int page = 1, string tuKhoa = "", int trangThai = -1)
        //{
        //    TempData["returnUrl"] = Url.Action("Index", "PhanAnhNhanh");
        //    if (Session["UserToken"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
        //    if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.PhanAnhNhanh, QuyenHan.Ma.Xem)) return RedirectToAction("Index", "Home");
        //    try
        //    {
        //        if (input == null)
        //        {
        //            input = new PhanAnhNhanhInput.DocDanhSachInput();
        //        }
        //        var onePageOfData = XemMotTrang(input, page, tuKhoa, trangThai);
        //        ViewBag.NoiDungTim = input;
        //        return PartialView("_ListPartial", onePageOfData);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("Sai TokenId") || ex.Message.Contains("Phiên bản hết hạn. Vui lòng đăng nhập lại."))
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            TempData["Error"] = ex.Message;
        //            return PartialView("_ListPartial");
        //        }
        //    }
        //}
        //public List<PhanAnhNhanhOutput.DocDanhSach> DocDanhSach(PhanAnhNhanhInput.DocDanhSachInput input)
        //{
        //    try
        //    {
        //        var output = XuLyAPI.ApiJsonPost(APIUrl.PhanAnhNhanh.DocDanhSachTheoDonVi, input) as CommonOutput;
        //        if (output.KetQua != 1) return null;
        //        return JsonConvert.DeserializeObject<List<PhanAnhNhanhOutput.DocDanhSach>>(JsonConvert.SerializeObject(output.DuLieu));
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
        //private dynamic XemMotTrang(PhanAnhNhanhInput.DocDanhSachInput input, int page, string tuKhoa, int trangThai)
        //{
        //    PhanAnhNhanhModel model = new PhanAnhNhanhModel();
        //    int pageSize = PageNumber.Page20;
        //    int viTriBatDau = (page - 1) * pageSize;
        //    int totalCount = 0;
        //    int viTriKetThuc = 0;
        //    viTriKetThuc = viTriBatDau + pageSize;
        //    DanhSachPhanAnh = new List<PhanAnhNhanhOutput.DocDanhSach>();
        //    DanhSachPhanAnh = DocDanhSach(input);
        //    if (!string.IsNullOrEmpty(tuKhoa))
        //    {
        //        DanhSachPhanAnh = DanhSachPhanAnh.Where(e => e.TenNguoiPhanAnh.ToLower().Contains(tuKhoa.ToLower()) || e.Sdt.Equals(tuKhoa)).ToList();
        //    }
        //    if (trangThai >= 0)
        //    {
        //        DanhSachPhanAnh = DanhSachPhanAnh.Where(e => e.TrangThai == trangThai).ToList();
        //    }
        //    totalCount = DanhSachPhanAnh.Count;
        //    var totalPage = (totalCount % pageSize > 0) ? (totalCount / pageSize + 1) : (totalCount / pageSize);
        //    DanhSachPhanAnh = DanhSachPhanAnh.Skip(viTriBatDau).Take(viTriKetThuc - viTriBatDau).ToList();
        //    model.DanhSachPhanAnh = DanhSachPhanAnh;
        //    model.CurrentPage = page;
        //    model.TotalPage = totalPage;
        //    model.DanhSachLoaiPhanAnh = DanhSachLoaiPhanAnh;
        //    model.DanhSachTinh = DanhSachTinh;
        //    DocThongTinInput inputTinhHienTai = new DocThongTinInput();
        //    var outputTinhHienTai = XuLyAPI.ApiJsonPost(APIUrl.Tinh.DocThongTin, inputTinhHienTai) as CommonOutput;
        //    if (outputTinhHienTai.KetQua != 1) return RedirectToAction("Index", "PhanAnhNhanh");
        //    if (Session["idTinh"] == null || string.IsNullOrEmpty(Session["idTinh"].ToString()))
        //    {
        //        TinhOutput.ThongTinTinh tinh = JsonConvert.DeserializeObject<TinhOutput.ThongTinTinh>(JsonConvert.SerializeObject(outputTinhHienTai.DuLieu));
        //        if (tinh != null)
        //        {
        //            Session["idTinh"] = tinh.Id;
        //        }
        //    }
        //    model.idTinh = Session["idTinh"].ToString();
        //    model.IdHuyen = input.IdHuyen;
        //    model.IdXa = input.IdXa;
        //    model.tuKhoaTimKiem = tuKhoa;
        //    model.IdLoaiPhanAnhNguoiDan = input.IdLoaiPhanAnhNguoiDan;
        //    model.IdAp = input.IdAp;
        //    model.TrangThai = trangThai;
        //    return model;
        //}
        //[HttpPost]
        //public object DocThongTin(string id)
        //{
        //    try
        //    {
        //        if (DanhSachPhanAnh != null && DanhSachPhanAnh.Count > 0)
        //        {
        //            return DanhSachPhanAnh.FirstOrDefault(e => e.Id.Equals(id));
        //        }
        //        return -1;
        //    }
        //    catch (Exception)
        //    {
        //        return -1;
        //    }
        //}
        //[HttpGet]
        //public object XuatDanhSachHinhAnh(string id)
        //{
        //    try
        //    {
        //        var phanAnh = DanhSachPhanAnh.FirstOrDefault(e => e.Id.Equals(id.Trim()));
        //        if (phanAnh != null)
        //        {
        //            return JsonConvert.SerializeObject(phanAnh.DanhSachTapTin);
        //        }
        //        return null;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //    finally { GC.Collect(); }
        //}
        //[HttpGet]
        //public ActionResult Edit(string id)
        //{
        //    TempData["returnUrl"] = Url.Action("Index", "PhanAnhNhanh");
        //    if (Session["UserToken"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
        //    if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.PhanAnhNhanh, QuyenHan.Ma.Sua)) return RedirectToAction("Index", "Home");
        //    try
        //    {
        //        PhanAnhNhanhModel model = new PhanAnhNhanhModel();
        //        model.PhanAnhHienTai = new PhanAnhNhanhOutput.ThongTinPhanAnh();
        //        if (!string.IsNullOrEmpty(id))
        //        {
        //            if (DanhSachPhanAnh != null && DanhSachPhanAnh.Count > 0)
        //            {
        //                var phanAnh = DanhSachPhanAnh.FirstOrDefault(e => e.Id.Equals(id.Trim()));
        //                if (phanAnh != null)
        //                {
        //                    model.PhanAnhHienTai = phanAnh;
        //                }
        //            }
        //            var inputPhanHoi = new DocThongTinInput
        //            {
        //                Id = id
        //            };
        //            var outputPhanHoi = XuLyAPI.ApiJsonPost(APIUrl.PhanAnhNhanh.DocThongTinPhanHoi, inputPhanHoi) as CommonOutput;
        //            if (outputPhanHoi != null && outputPhanHoi.KetQua == 1)
        //            {
        //                model.ThongTinPhanHoi = JsonConvert.DeserializeObject<DocThongTinPhanHoi>(JsonConvert.SerializeObject(outputPhanHoi.DuLieu));
        //            }
        //        }
        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("Sai TokenId") || ex.Message.Contains("Phiên bản hết hạn. Vui lòng đăng nhập lại."))
        //        {
        //            //TempData["returnUrl"] = Url.Action("Index", "NguoiDung");
        //            return Redirect(ChucNang.DuongDan.DangNhap);
        //        }
        //        else
        //        {
        //            return Redirect(ChucNang.DuongDan.DangNhap);
        //        }
        //    }
        //    finally { GC.Collect(); }
        //}
        //[HttpPost]
        //[ValidateInput(false)]
        //public object CapNhatPhanHoi(string id, int trangThai, string tapTin, string noiDungPhanHoi, bool xuatBan)
        //{
        //    TempData["returnUrl"] = Url.Action("Index", "PhanAnhNhanh");
        //    if (Session["UserToken"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
        //    if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.PhanAnhNhanh, QuyenHan.Ma.Sua)) return RedirectToAction("Index", "Home");
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(id))
        //        {
        //            PhanAnhNhanhInput.CapNhatPhanAnhInput input = new PhanAnhNhanhInput.CapNhatPhanAnhInput
        //            {
        //                DanhSachTapTin = new List<PhanAnhNhanhInput.CapNhatPhanAnhInput.TapTin>(),
        //                Id = id,
        //                XuatBan = xuatBan,
        //                TrangThai = trangThai,
        //                NoiDungPhanHoi = noiDungPhanHoi
        //            };
        //            if (!string.IsNullOrEmpty(tapTin))
        //            {
        //                input.DanhSachTapTin.Add(new PhanAnhNhanhInput.CapNhatPhanAnhInput.TapTin
        //                {
        //                    Ten = tapTin
        //                });
        //            }
        //            var output = XuLyAPI.ApiJsonPost(APIUrl.PhanAnhNhanh.CapNhat, input) as CommonOutput;
        //            if (output == null) throw new Exception("Lỗi server");
        //            if (output.KetQua != 1) return null;
        //            return output.KetQua;
        //        }
        //        return null;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //    finally { GC.Collect(); }
        //}
        //[HttpPost]
        //public object Xoa(XoaDanhSachInput2 input)
        //{
        //    TempData["returnUrl"] = Url.Action("Index", "PhanAnhNhanh");
        //    if (Session["UserToken"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
        //    if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.PhanAnhNhanh, QuyenHan.Ma.Xem)) return RedirectToAction("Index", "Home");
        //    try
        //    {
        //        if (input != null && input.Ids != null && input.Ids.Any())
        //        {
        //            var output = XuLyAPI.ApiJsonPost(APIUrl.PhanAnhNhanh.XoaDanhSach, input) as CommonOutput;
        //            if (output == null) return 0;
        //            if (output.KetQua != 1) return 0;
        //            DanhSachPhanAnh.Clear();
        //            return output.DuLieu;
        //        }
        //        return 0;
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //    }
        //    finally { GC.Collect(); }
        //}
        //[HttpPost]
        //public ActionResult Them(PhanAnhNhanhInput.Them model)
        //{
        //    if (Session["UserToken"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
        //    if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.PhanAnhNhanh, QuyenHan.Ma.Them)) return RedirectToAction("Index", "Home");
        //    var thongBao = "";
        //    var userInfo = Session["UserInfo"] as CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan;
        //    try
        //    {
        //        model.IdNguoiDung = userInfo.Id;
        //        var input = new PhanAnhNhanhInput.Them();
        //        input.IdHuyen = model.IdHuyen;
        //        input.IdXa = model.IdXa;
        //        input.IdAp = model.IdAp;
        //        input.DiaChi = model.DiaChi;
        //        input.ToaDo = model.ToaDo;
        //        input.TenNguoiPhanAnh = model.TenNguoiPhanAnh;
        //        input.Sdt = model.Sdt;
        //        input.TieuDe = model.TieuDe;
        //        input.NoiDung = model.NoiDung;
        //        input.MaMay = model.MaMay;
        //        input.IdNguoiDung = model.IdNguoiDung;
        //        input.IdLoaiPhanAnhNguoiDan = model.IdLoaiPhanAnhNguoiDan;
        //        input.DanhSachTapTin = model.DanhSachTapTin;
        //        var output = XuLyAPI.ApiJsonPost(APIUrl.PhanAnhNhanh.Them, input) as CommonOutput;
        //        if (output == null) throw new Exception("Lỗi Server");
        //        if (output.KetQua != 1) throw new Exception(output.ThongBao);
        //        // Ghi thành công
        //        thongBao = output.KetQua + "";
        //    }
        //    catch (Exception ex)
        //    {
        //        thongBao = string.Format("Lỗi ghi dữ liệu:{0}.", ex.Message);
        //    }
        //    return Json(thongBao);
        //}
        //[HttpPost]
        //public ActionResult CapNhat(PhanAnhNhanhInput.Them model)
        //{
        //    if (Session["UserToken"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
        //    if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.PhanAnhNhanh, QuyenHan.Ma.Sua)) return RedirectToAction("Index", "Home");
        //    var thongBao = "";
        //    var userInfo = Session["UserInfo"] as CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan;
        //    try
        //    {
        //        model.IdNguoiDung = userInfo.Id;
        //        var input = new PhanAnhNhanhInput.Them();
        //        input.Id = model.Id;
        //        input.IdHuyen = model.IdHuyen;
        //        input.IdXa = model.IdXa;
        //        input.IdAp = model.IdAp;
        //        input.DiaChi = model.DiaChi;
        //        input.ToaDo = model.ToaDo;
        //        input.TenNguoiPhanAnh = model.TenNguoiPhanAnh;
        //        input.Sdt = model.Sdt;
        //        input.TieuDe = model.TieuDe;
        //        input.NoiDung = model.NoiDung;
        //        input.MaMay = model.MaMay;
        //        input.IdNguoiDung = model.IdNguoiDung;
        //        input.IdLoaiPhanAnhNguoiDan = model.IdLoaiPhanAnhNguoiDan;
        //        input.DanhSachTapTin = model.DanhSachTapTin;
        //        var output = XuLyAPI.ApiJsonPost(APIUrl.PhanAnhNhanh.Sua, input) as CommonOutput;
        //        if (output == null) throw new Exception("Lỗi Server");
        //        if (output.KetQua != 1) throw new Exception(output.ThongBao);
        //        // Ghi thành công
        //        thongBao = output.KetQua + "";
        //    }
        //    catch (Exception ex)
        //    {
        //        thongBao = string.Format("Lỗi ghi dữ liệu:{0}.", ex.Message);
        //    }
        //    return Json(thongBao);
        //}
        //[HttpPost]
        //public JsonResult DocChiTietPhanAnh(string Id)
        //{
        //    try
        //    {
        //        var input = new DocThongTinInput()
        //        {
        //            Id = Id
        //        };
        //        var output = XuLyAPI.ApiJsonPost(APIUrl.PhanAnhNhanh.DocThongTin, input) as CommonOutput;
        //        if (output == null) throw new Exception("Lỗi Server");
        //        if (output.KetQua != 1) throw new Exception(output.ThongBao);
        //        var ChiTietPhanAnh = JsonConvert.DeserializeObject<PhanAnhNhanhOutput.ThongTinPhanAnh>(output.DuLieu.ToString());

        //        return Json(ChiTietPhanAnh);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json((object)ex.Message, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}