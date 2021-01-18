using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.Admin.Models
{
    public class DanhMucBieuMauInAnModel
    {
        public class DanhMucBieuMauInAnInput
        {
            public class ThongTin : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
                public string TuKhoa { get; set; }
                public string IdDanhMucLoaiBieuMauInAn { get; set; }
                public string MaLinhVuc { get; set; }
                public string CSS { get; set; }
                public string Script { get; set; }
                public string JsonData { get; set; }
                public string Body { get; set; }
                public int ThuTu { get; set; }
                public bool KichHoat { get; set; }
                public bool TrangThai { get; set; }
                public string GhiChu { get; set; }
            }
            public class TimKiem : CommonInput.TimKiem
            {
                public string IdLoaiBieuMauInAn { get; set; }
            }
        }
        public class DanhMucBieuMauInAnOutput
        {
            public class ThongTin
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
                public string TuKhoa { get; set; }
                public string IdDanhMucLoaiBieuMauInAn { get; set; }
                public string MaLinhVuc { get; set; }
                public string CSS { get; set; }
                public string Script { get; set; }
                public string JsonData { get; set; }
                public string Body { get; set; }
                public string DuongDanAPI { get; set; }
                public int ThuTu { get; set; }
                public bool KichHoat { get; set; }
                public bool TrangThai { get; set; }
                public string GhiChu { get; set; }
            }

            public class DocDanhSach : CommonDocDanhSachOutput
            {
                public List<ThongTin> DanhSach { get; set; }
            }
        }
    }
}