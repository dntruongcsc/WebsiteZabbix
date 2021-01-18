using Common.Enum;
using MVCProjectStructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Helpers
{
    public class XuLyTinhHuyenXa
    {
        public static dynamic DocDanhSachCacCap(string Loai = "", string Id = "")
        {
            dynamic DanhSach = null;
            try
            {
                var input = new CommonInput.DocDanhSach();
                DanhSach = XuLyDocDaanhSachCacCap(Loai, Id, DanhSach, input);
            }
            catch (Exception) { }
            return DanhSach;
        }
        public static dynamic DocDanhSachCacCapKT(string Loai = "", string Id = "")
        {
            dynamic DanhSach = null;
            try
            {
                var input = new CommonInput.DocDanhSach();
                DanhSach = XuLyDocDaanhSachCacCap(Loai, Id, DanhSach, input, false);
            }
            catch (Exception) { }
            return DanhSach;
        }

        private static dynamic XuLyDocDaanhSachCacCap(string Loai, string Id, dynamic DanhSach, CommonInput.DocDanhSach input, bool useToken = true)
        {
            var duongDan = useToken ? APIUrl.Tinh.DocThongTin : APIUrl.Tinh.DocThongTinKT;
            var output = XuLyAPI.ApiJsonPost(duongDan, input, useToken) as CommonOutput;
            if (output == null) throw new Exception("Lỗi Server");
            if (output.KetQua != 1) throw new Exception(output.ThongBao);
            if (output.DuLieu != null)
            {
                var data = JsonConvert.DeserializeObject<CommonTinh.TinhOutput.ThongTinTinh>(output.DuLieu.ToString());

                if (Loai == "Huyen" && Id == "")
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

            return DanhSach;
        }
    }
}