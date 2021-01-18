using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectStructure.Areas.Admin.Models
{
    public class DanhMucLoaiBieuMauInAnModel
    {
        public class DanhMucLoaiBieuMauInAnInput
        {

        }
        public class DanhMucLoaiBieuMauInAnOutput
        {
            public class ThongTin
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
                public int ThuTu { get; set; }
                public bool TrangThai { get; set; }
                public string GhiChu { get; set; }
            }
        }
    }
}