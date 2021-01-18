using Common.Enum;
using MVCProjectStructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ZabbixApi.Zabbix;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Models
{
    public class XuLyAPI
    {
        /// <summary>
        /// Dùng để post về API (cho cả Đọc và Ghi)
        /// </summary>
        /// <param name="apiUrl">Đường dẫn API</param>
        /// <param name="input">Tham số truyền vào API</param>
        /// <param name="useToken">true(mặc định), false: Dùng cho đăng nhập</param>
        /// <returns>Trả ra object (Chú ý sử dụng CommonModel.CommonOutput khi out ra dữ liệu)</returns>
        public static object ApiJsonPost(string apiUrl, dynamic input, bool useToken = true)
        {
            CommonModel.CommonOutput kq = new CommonOutput();
            try
            {
                if (useToken)
                {
                    var user = HttpContext.Current.Session["UserToken"] as CommonInput.UserToken;
                    if (user == null)
                    {
                        //HttpContext.Current.Response.RedirectToRoute(new { controller = "TaiKhoan", action = "Login" });
                        HttpContext.Current.Response.RedirectToRoute(ChucNang.DuongDan.BangDieuKhien);
                        kq.KetQua = -10;
                        kq.ThongBao = "Vui lòng đăng nhập lại!";
                        kq.DuLieu = ChucNang.DuongDan.BangDieuKhien;
                        return kq;
                    }
                    input.TokenApi = user.TokenApi;
                    input.TokenNguoiDung = user.TokenNguoiDung;
                }
                HttpClient client = new HttpClient();
                string http = ConfigurationManager.AppSettings["APIBaseUrl"];
                client.BaseAddress = new Uri(http);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(apiUrl, (object)input).Result;

                if (response.IsSuccessStatusCode)
                {
                    kq = response.Content.ReadAsAsync<CommonModel.CommonOutput>().Result;
                    return kq;
                }
            }
            catch (Exception ex){}
            finally{ GC.Collect(); }
            return null;
        }
        public static object ApiJsonZabbix(string apiUrl, dynamic input)
        {
           // CommonModel.CommonOutput kq = new CommonOutput();
            try
            {

                var zab = HttpContext.Current.Session["Zabbix"] as ApiClient;
                var kq = zab.Call(apiUrl, input);

               

                    return kq;
                
            }
            catch (Exception ex){
                throw new Exception(ex.Message);
            }
            finally{ GC.Collect(); }
            
        }
        public static object ApiJsonPost2(string apiUrl, dynamic input, bool useToken = true)
        {
            CommonModel.CommonOutput kq = null;
            try
            {
               
                input.TokenApi = "111";
                input.TokenNguoiDung = "222";
                HttpClient client = new HttpClient();
                string http = ConfigurationManager.AppSettings["APIBaseUrl2"];
                client.BaseAddress = new Uri(http);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(apiUrl, (object)input).Result;

                if (response.IsSuccessStatusCode)
                {
                    kq = response.Content.ReadAsAsync<CommonModel.CommonOutput>().Result;
                    return kq;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                GC.Collect();

            }
        }
        #region Xử lý thông tin tuần
        public static List<CommonNamThangTuan.TuanOutput> DocDanhSachTuan(int Nam)
        {
            try
            {
                var input = new CommonNamThangTuan.ThongTinTuanInput { Nam = Nam };
                var output = XuLyAPI.ApiJsonPost(APIUrl.ThongTinTuan.DocDanhSach, input) as CommonOutput;
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var danhSachTuan = JsonConvert.DeserializeObject<List<CommonNamThangTuan.ThongTinTuanOutput>>(output.DuLieu.ToString());
                if (danhSachTuan != null)
                {
                    var kq = new List<CommonNamThangTuan.TuanOutput>();
                    foreach (var item in danhSachTuan)
                    {
                        var i = new CommonNamThangTuan.TuanOutput();
                        i.Value = item.Tuan.ToString();
                        i.Text = item.ChuoiTuan + " (" + item.ChuoiNgayBatDau + " - " + item.ChuoiNgayKetThuc + ")";
                        i.TuanHienTai = item.TuanHienTai;
                        kq.Add(i);
                    }
                    return kq;
                }
            }
            catch (Exception) { }
            return null;
        }
        #endregion
        #region Xử lý xóa
        public static string XoaDanhSach(string url, List<String> danhSachId, string ghiChu = "")
        {
            string kq = null;
            if (danhSachId != null && danhSachId.Count > 0)
            {
                var input = new CommonInput.XoaDanhSachInput { Ids = danhSachId };
                var output = ApiJsonPost(url, input) as CommonOutput;
                if (output.KetQua != 1) throw new Exception(output.ThongBao);

                var n = JsonConvert.DeserializeObject<int>(output.DuLieu.ToString());
                kq = string.Format("Số thông tin {0} đã bị xóa là:{1}.", ghiChu, n);
            }
            return kq;
        }
        #endregion
        
    }
}
