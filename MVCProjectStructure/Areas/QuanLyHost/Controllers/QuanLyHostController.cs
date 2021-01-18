using Common.Enum;
using MVCProjectStructure.Helpers;
using MVCProjectStructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZabbixApi.Zabbix;

namespace MVCProjectStructure.Areas.QuanLyHost.Controllers
{
    public class QuanLyHostController : Controller
    {
        // GET: QuanLyHost/QuanLyHost
        public ActionResult Index()
        {
            return View();
        }

        private List<Models.HostModel.ThongTin> DocDanhSach(string TuKhoa = "")
        {


            dynamic param = new ExpandoObject();
            param.output = "extend";
            //param.output =new[] { "hostid", "proxy_hostid", "host", "name", "status", "ipmi_authtype", "ipmi_privilege",
            //        "ipmi_username", "ipmi_password", "flags", "description", "tls_connect", "tls_accept", "tls_issuer",
            //        "tls_subject", "tls_psk_identity", "tls_psk"
            //    };
            param.selectApplications = "extend";
            param.selectGroups = "extend";
            param.selectGraphs = "extend";
            param.selectInterfaces = "extend";
            param.selectItems = "extend";
            param.selectTriggers = "extend";
            param.selectDiscoveries = "extend";
            //param.templateids = "extend";
            var output = XuLyAPI.ApiJsonZabbix(APIUrl.Zabbix.Host.DocDanhSach, param) as Response;
            
            var duLieuOutput = JsonConvert.DeserializeObject<List<Models.HostModel.ThongTin>>(output.Result.ToString());
           
            return duLieuOutput;
        }
        private List<Models.HostModel.Group> DocDanhSachGroups(string TuKhoa = "")
        {


            dynamic param = new ExpandoObject();
            param.output = "extend";
           // param.filter = new ExpandoObject();
            //param.filter.name = new string[] { "Zabbix server" };
            var p = new
            {
                output = "extend",
                filter=new
                {
                    name = new string[] { "Zabbix server" }
                }
            };
            //param.filter.name.Add("Zabbix servers");
            //param.templateids = "extend";
            var output = XuLyAPI.ApiJsonZabbix(APIUrl.Zabbix.HostGroup.DocDanhSach,param) as Response;
            
            var duLieuOutput = JsonConvert.DeserializeObject<List<Models.HostModel.Group>>(output.Result.ToString());
           
            return duLieuOutput;
        }
        private List<Models.HostModel.Template> DocDanhSachTemplates(string TuKhoa = "")
        {


            dynamic param = new ExpandoObject();
            param.output = "extend";
           // param.filter = new ExpandoObject();
            //param.filter.name = new string[] { "Zabbix server" };
            var p = new
            {
                output = "extend",
                filter=new
                {
                    name = new string[] { "Zabbix server" }
                }
            };
            //param.filter.name.Add("Zabbix servers");
            //param.templateids = "extend";
            var output = XuLyAPI.ApiJsonZabbix(APIUrl.Zabbix.Template.DocDanhSach,param) as Response;
            
            var duLieuOutput = JsonConvert.DeserializeObject<List<Models.HostModel.Template>>(output.Result.ToString());
           
            return duLieuOutput;
        }

        [SessionCheck]
        public ActionResult XemDanhSach(string TuKhoa = "")
        {
          
            
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            //if (!XuLyPhanQuyen.KiemTraQuyen(ChucNang.Ma.QuangCao, QuyenHan.Ma.Xem)) return Redirect(ChucNang.DuongDan.BangDieuKhien);

            try
            {
                var danhSach = DocDanhSach(TuKhoa);
                return PartialView("_DanhSachPartial", danhSach);
            }
            catch (Exception ex)
            {
                //Ghi log
                TempData["Error"] = ConstantValues.Message.LoiDuLieu;
                return PartialView("_DanhSachPartial");
            }
        }


        
        public ActionResult ThongTinThemCapNhat(string HostId)
        {
            var duLieuOutput = new Models.HostModel.Input.Them();

            try
            {
                if (!string.IsNullOrEmpty(HostId))
                {
                    dynamic param = new ExpandoObject();
                    param.output = "extend";
                    //param.output = new[] { "hostid", "host", "name", "status", "description", "proxy_hostid", "ipmi_authtype",
                    //"ipmi_privilege", "ipmi_username", "ipmi_password", "tls_connect", "tls_accept", "tls_psk_identity",
                    //"tls_psk", "tls_issuer", "tls_subject", "flags"
                    //    };
                    param.hostids = HostId;
                    param.editable = true;
                    param.selectApplications = "extend";
                    param.selectGroups = "extend";
                    param.selectGraphs = "extend";
                    param.selectInterfaces = "extend";
                    param.selectItems = "extend";
                    param.selectTriggers = "extend";
                    param.selectDiscoveries = "extend";
                    var output = XuLyAPI.ApiJsonZabbix(APIUrl.Zabbix.Host.DocDanhSach, param) as Response;
                    var da = JsonConvert.DeserializeObject<List<Models.HostModel.ThongTin>>(output.Result.ToString());
                    //var input = new CommonInput.DocThongTin { Id = Id };
                    //var output = XuLyAPI.ApiJsonPost2(APIUrl.ThongBaoKhan.DocThongTin, input) as CommonOutput;
                    //if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                    //if (output.KetQua != 1) throw new Exception(output.ThongBao);
                    //duLieuOutput = JsonConvert.DeserializeObject<Models.ThongBaoKhanModel.Input.ThongTin>(output.DuLieu.ToString());
                }
            }
            catch (Exception e)
            {
            }
            ViewBag.Groups = DocDanhSachGroups();
            ViewBag.DanhSachTemplates = DocDanhSachTemplates();
            return View(duLieuOutput);
        }

        [HttpPost]
        [SessionCheck]
        public ActionResult XuLyLuu(Models.HostModel.Input.Them input)
        {
           // TempData["returnUrl"] = Url.Action("Index", "ThoiTietNongVu", new { Areas = "LVKhuyenNong" });
           // var kiemTra = Helpers.XuLyPhanQuyen.KiemTraQuyenTruyCap(ChucNang.Ma.QuanLyThongBaoKhan, QuyenHan.Ma.Them);
           // ViewBag.KetQua = kiemTra.KetQua;
            //if (kiemTra.KetQua < 0) return PartialView("_ThemCapNhatPartial", new CommonBieuMauInAn.BieuMauInAnOutput.ThongTin());
            //if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            var model = new CommonModel.CommonOutput();
            
            var input2 = new ThongBaoKhan.Models.ThongBaoKhanModel.Input.ThongTin2();
            try
            {
                //input2.Id = input.Id;
                //input2.Ten = input.Ten;
                //input2.TenVietTat = input.TenVietTat;


                //input2.Ma = string.IsNullOrEmpty(input.Ma) ? "" : input.Ma.Replace(" ", "");

                //input2.ThuTu = input.ThuTu;

                //input2.GhiChu = input.GhiChu;
                //var input = new ThoiTietNongVuInput2();
                //input2.HinhDaiDien = input.HinhDaiDien;
                //input2.DuongDanThanThien = input.DuongDanThanThien;
                //input2.TieuDe = input.TieuDe;
                //input2.NoiDungTomTat = input.NoiDungTomTat;
                //input2.NoiDung = input.NoiDung;
                //input2.TrangThai = 0;
                //if (input.TrangThai) input2.TrangThai = 1;
                //input2.DoUuTien = 0;
                //if (input.DoUuTien) input2.DoUuTien = 1;
                dynamic param = new ExpandoObject();
                param.host = input.host;
                param.inventory_mode = 0;
                param.interfaces = new List<ExpandoObject>();
                foreach (var item in input.interfaces)
                {
                    dynamic inf = new ExpandoObject();
                    inf.type = Convert.ToInt32(item.type);
                    inf.main = 1;
                    inf.useip = item.useip;
                    inf.ip = string.IsNullOrEmpty(item.ip) ? "" : item.ip;
                    inf.dns = string.IsNullOrEmpty(item.dns) ? "" : item.dns;
                    inf.port = item.port;
                    param.interfaces.Add(inf);
                }
                param.groups = new List<ExpandoObject>();
                foreach (var item in input.groups)
                {
                    dynamic inf = new ExpandoObject();
                    inf.groupid = item.groupid;

                    param.groups.Add(inf);
                }
                //param.output = "extend";
                //// param.filter = new ExpandoObject();
                ////param.filter.name = new string[] { "Zabbix server" };
                //var p = new
                //{
                //    output = "extend",
                //    filter = new
                //    {
                //        name = new string[] { "Zabbix server" }
                //    }
                //};
                //param.filter.name.Add("Zabbix servers");
                //param.templateids = "extend";
                //input.macros = new List<Models.HostModel.Input.Macro>();
                //input.inventory = new Models.HostModel.Input.Inventory();
                //input.tags = new List<Models.HostModel.Input.Tag>();
                //input.templates = new List<Models.HostModel.Input.Template>();
                //input.inventory_mode = 1;
                input.interfaces.FirstOrDefault().dns = "";
                //param.host = "abcd";
                var output = XuLyAPI.ApiJsonZabbix(APIUrl.Zabbix.Host.Them, param) as Response;
                ViewBag.KetQua = 0;
                model.KetQua = 1;
                model.ThongBao = ConstantValues.Message.ThanhCong;

            }
            catch (Exception ex)
            {
                ViewBag.KetQua = 0;
                model.KetQua = 0;
                model.ThongBao = ConstantValues.Message.ThatBai;
                model.DuLieu = ex.Message;
            }
            return Json(model);
        }


    }
}