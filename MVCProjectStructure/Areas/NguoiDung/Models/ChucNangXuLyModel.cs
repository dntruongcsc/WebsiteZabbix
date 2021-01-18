using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.NguoiDung.Models
{
    public class ChucNangXuLyModel
    {
        public class ChucNangXuLyInput
        {
            public class ThongTin
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
                public int ViTri { get; set; }
                public string Icon { get; set; }
                public string BieuTuong { get; set; }
            }
            public class DocDanhSach : CommonInput.DocDanhSach
            {

            }
        }
        public class ChucNangXuLyOutput
        {
            public class ThongTin
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
                public int ViTri { get; set; }
                public string Icon { get; set; }
                public string BieuTuong { get; set; }
            }
        }
    }
}