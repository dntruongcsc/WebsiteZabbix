using Common.Enum;
using MVCProjectStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Helpers
{
    public class NhatKy
    {
        public static void GhiNhatKy(string maLoaiNhatKy, string maChucNang, string tenFileXuLy, string tenPhuongThuc, string noiDung)
        {
            var model = new CommonOutput();
            var input = new CommonNhatKy.NhatKyInput.ThemNhatKy();
            try
            {
                input.MaUser = "user1";
                input.MaChucNang = maChucNang;
                input.MaLoaiNhatKy = maLoaiNhatKy;
                input.TenFileXuLy = tenFileXuLy;
                input.TenPhuongThuc = tenPhuongThuc;
                input.NoiDung = noiDung;
                input.TenDoiTuongThucThi = HttpContext.Current.Request.Browser.Browser + " v."+ HttpContext.Current.Request.Browser.Version; 
                var output = XuLyAPI.ApiJsonPost(APIUrl.NhatKy.Them, input) as CommonOutput;
                if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
            }
            catch (Exception ex)
            {
            }
        }
    }
}