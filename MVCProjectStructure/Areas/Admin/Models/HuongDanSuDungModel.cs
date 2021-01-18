using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.Admin.Models
{
    public class HuongDanSuDungModel
    {
        public class Input
        {
            public class ThongTin : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string TuKhoa { get; set; }
                public string DuongDan { get; set; }
                public string IdDanhMucLoaiHuongDan { get; set; }
                public int ThuTu { get; set; }
                public bool KichHoat { get; set; }
                public string GhiChu { get; set; }
            }
            public class TimKiem : CommonInput.TimKiem
            {
                public string IdDanhMucLoaiHuongDanSuDung { get; set; }
            }
        }
        public class Output
        {
            public class ThongTin
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string TuKhoa { get; set; }
                public string DuongDan { get; set; }
                public string IdDanhMucLoaiHuongDan { get; set; }
                public string TenDanhMucLoaiHuongDan { get; set; }
                public int ThuTu { get; set; }
                public bool KichHoat { get; set; }
                public string GhiChu { get; set; }
            }

            public class DocDanhSach : CommonDocDanhSachOutput
            {
                public List<ThongTin> DanhSach { get; set; }
            }
        }
    }
}