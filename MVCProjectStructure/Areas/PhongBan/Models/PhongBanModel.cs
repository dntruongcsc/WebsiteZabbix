using MVCProjectStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.PhongBan.Models
{
    public class PhongBanModel
    {
        public class PhongBanInput
        {
            public class DocDanhSach : CommonInput.DocDanhSach
            {

            }
            public class ThongTinPhongBan : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
                public string MoTa { get; set; }
                public int ThuTu { get; set; }
                public bool KichHoat { get; set; }
            }
            public class TimKiemPhongBan : CommonInput.TimKiem
            {
                public string NenTang { get; set; }
                public string ThuocTrang { get; set; }
                
            }
        }
        public class PhongBanOutput
        {
            public class ThongTinPhongBan
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
                public string MoTa { get; set; }
                public int ThuTu { get; set; }
                public bool KichHoat { get; set; }
            }
            public class DocDanhSachPhongBan: CommonDocDanhSachOutput
            {
                public List<ThongTinPhongBan> DanhSach { get; set; }
            }
            public class DocDanhSach
            {
                public List<ThongTinPhongBan> DanhSach { get; set; }
            }
        }
    }
}