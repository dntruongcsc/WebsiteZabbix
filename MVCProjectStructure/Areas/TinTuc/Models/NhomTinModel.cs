using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProjectStructure.Models;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.TinTuc.Models
{
    public class NhomTinModel
    {
        public class NhomTinInput
        {
            public class ThongTinNhomTin:CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string Ma { get; set; }
                public string DuongDan { get; set; }
                public string Ten { get; set; }
                public string MoTa { get; set; }
                public int ThuTu { get; set; }
                public bool KichHoat { get; set; }
                public List<string> DanhSachIdPhongBan { get; set; }
            }
            public class TimKiemNhomTin : CommonInput.TimKiem
            {
                public int TrangHienTai { get; set; }
                public string IdPhongBan { get; set; }
            }
        }
        public class NhomTinOutput
        {
            public class ThongTinDuLieu
            {
                public List<ThongTin> DuLieu { get; set; }
                public ThongTinDuLieu()
                {
                    DuLieu = new List<ThongTin>();
                }
            }
            public class ThongTinKetQua
            {
                public int KetQua { get; set; }
                public string ThongBao { get; set; }
                public ThongTinDuLieu DuLieu { get; set; }
                public string GhiChu { get; set; }

                public ThongTinKetQua()
                {
                    DuLieu = new ThongTinDuLieu();
                }
            }

            public class ThongTin
            {
                public string Id { get; set; }
                public string Ma { get; set; }
                public string Ten { get; set; }
                public string DuongDan { get; set; }
                public string MoTa { get; set; }
                public int ThuTu { get; set; }
                public List<string> DanhSachIdPhongBan { get; set; }
                public bool KichHoat { get; set; }
            }
            public class DocDanhSach
            {
                public int TongSoTrang { get; set; }
                public int TongSoLuong { get; set; }
                public int TrangHienTai { get; set; }
                public List<ThongTin> DanhSachThongTinNhomTin { get; set; }
                public class ThongTinNhomTin : ThongTin { }
                public DocDanhSach()
                {
                    DanhSachThongTinNhomTin = new List<ThongTin>();
                }
            }
            public class TimKiemPhanTrang : DocDanhSach { }
        }

    }
}