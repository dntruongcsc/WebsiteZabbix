using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.DiaChi.Models
{
    public class Xa
    {
        public class Input
        {
            public class DocDanhSach : CommonInput.ChungThuc
            {
            }
            public class DocThongTin : CommonInput.ChungThuc
            {
                public string Id { get; set; }
            }
        }
        public class Output
        {
            public class ThongTinTinhWeb : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
                public string IdHuyen { get; set; }
                public string TenHuyen { get; set; }
                public string MaHuyen { get; set; }

            }
        }
    }
}