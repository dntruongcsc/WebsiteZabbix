
using Common.Enum;
using Common.Utilities;
using MVCProjectStructure.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Web.Mvc;
using ZabbixApi.Zabbix;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.NguoiDung.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: NguoiDung/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DoiMatKhau()
        {
            var model = new CommonNguoiDung.NguoiDungInput.DoiMatKhau();
            try
            {
                if (Session["UserInfo"]!=null)
                {
                    var userInfo = Session["UserInfo"] as CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan;
                    model.TenTaiKhoan = userInfo.TenTaiKhoan;
                }
            }
            catch (Exception ex)
            { }
            return View(model);
        }
        [HttpPost]
        public ActionResult DoiMatKhau(string TenTaiKhoan, string MatKhau,string MatKhauMoi, string NhapLaiMatKhau)
        {
            var model = new CommonNguoiDung.NguoiDungInput.DoiMatKhau();
            ViewBag.ThongBao = "Vui lòng nhập đầy đủ thông tin!";
            try
            {
                if (string.IsNullOrEmpty(MatKhau.Trim()))
                {
                    ViewBag.ThongBao = "Vui lòng nhập mật khẩu!";
                    return View(model);
                }
                if (!string.IsNullOrEmpty(MatKhauMoi.Trim()) && MatKhauMoi == NhapLaiMatKhau)
                {
                    
                    model.TenTaiKhoan = TenTaiKhoan;
                    model.MatKhau = Utility.MD5(MatKhau);
                    model.MatKhauMoi = MatKhauMoi;
                    model.NhapLaiMatKhau = NhapLaiMatKhau;

                    var input = new CommonNguoiDung.NguoiDungInput.DoiMatKhau();
                    input.TenTaiKhoan = TenTaiKhoan;
                    input.MatKhau = Utility.MD5(MatKhau);
                    input.MatKhauMoi = Utility.MD5(MatKhauMoi);
                    input.NhapLaiMatKhau = NhapLaiMatKhau;

                    var output = XuLyAPI.ApiJsonPost(APIUrl.NguoiDung.DoiMatKhau, input) as CommonOutput;
                    if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                    if (output.KetQua == 1)
                    {
                        // Thành công
                        TempData["returnUrl"] = null;
                        Session.Clear();
                        return Redirect("~/TrangChu/Index");
                    }
                    else
                    {
                        ViewBag.ThongBao = "Đổi mật khẩu không thành công. Vui lòng kiểm tra lại!";
                    }
                }
                else
                {
                    ViewBag.ThongBao = "Nhập lại mật khẩu không đúng!";
                }
            }
            catch (Exception ex)
            {}
            return View(model);
        }

        #region 1- Đăng nhập vào tài khoản
        public ActionResult Login(string ReturnUrl = "")
        {
            if (Session["UserToken"] != null)
            {
                return Redirect("/");
            }
            if (ReturnUrl == "")
                ViewBag.ReturnUrl = TempData["returnUrl"];
            else
                ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CommonTaiKhoan.TaiKhoanInput.DangNhapInput model, string returnUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(returnUrl))returnUrl = ChucNang.DuongDan.BangDieuKhien;
                if (ModelState.IsValid)
                {
                    var matKhauGoc = model.MatKhau;
                    model.MatKhau = Utility.MD5(model.MatKhau);
                    var output = XuLyAPI.ApiJsonPost(APIUrl.TaiKhoan.DangNhap, model, false) as CommonOutput;
                    if (output == null) throw new Exception("Lỗi Server");
                    if (output.KetQua != 1) throw new Exception(output.ThongBao);
                    //Thành công
                    string url = ConfigurationManager.AppSettings["urlSv"];
                    var Zabbix = new ApiClient(url, model.TenTaiKhoan, matKhauGoc);
                    Zabbix.Login();
                    Session["Zabbix"] = Zabbix;
                    var userLogin = JsonConvert.DeserializeObject<CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan>(output.DuLieu.ToString());
                    Session["UserToken"] = new CommonInput.UserToken { TokenApi = userLogin.TokenApi, TokenNguoiDung = userLogin.TokenNguoiDung };
                    Session["UserInfo"] = userLogin;
                    Session["MaDonVi"] = userLogin.MaDonVi;
                    Session["MaVaiTro"] = userLogin.MaVaiTro;
                    Session["TenNguoiDung"] = userLogin.Ten;
                    
                    var input = new CommonTinh.TinhInput.DocThongTin();
                    var outputTinh = XuLyAPI.ApiJsonPost(APIUrl.Tinh.DocThongTin, input) as CommonOutput;
                    if (outputTinh != null /*&& output.KetQua == 1*/)
                        Session["Tinh"] = JsonConvert.DeserializeObject<CommonTinh.TinhOutput.ThongTinTinh>(outputTinh.DuLieu.ToString());
                    else
                        Session["Tinh"] = null;
                    try
                    {
                        returnUrl = TempData["returnUrl"].ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    return RedirectToLocal(returnUrl);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ThongBao = string.Format("Đăng nhập <b>{0}</b>!", ex.Message);
            }
            return View();
        }
        
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion
        #region 2- Đăng xuất khỏi tài khoản
        public ActionResult Logout()
        {
            try
            {
                //var input = new CommonTaiKhoan.TaiKhoanInput.DangXuatInput();
                //var output = XuLyAPI.ApiJsonPost(APIUrl.TaiKhoan.DangXuat, input) as CommonOutput;
                //if (output == null) throw new Exception("Lỗi Server");
                //if (output.KetQua != 1) throw new Exception(output.ThongBao);

                // Đăng xuất thành công
                TempData["returnUrl"] = null;
                Session.Clear();
                return View("Login");
                //return RedirectToAction("Index", "TrangChu");//Tới đây
                //return Redirect("~/TrangChu/Index");//Tới đây
            }
            catch (Exception ex)
            {
                return View("ThongBaoLoi", (object)ex.Message);
            }
        }
        #endregion
        #region 3- Chuyển trang khi hết session
        public ActionResult ChuyenTrangDangNhap()
        {
            return View();
        }
        #endregion
    }
}