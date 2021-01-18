using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.QuangCao.Models
{
    public class QuangCaoLoaiModel
    {
        public class Input
        {
            public class ThongTin : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string MaNenTang { get; set; }
                public string Ma { get; set; }
                public string Ten { get; set; }
                public string MoTa { get; set; }
                public int ChieuRong { get; set; }
                public int ChieuCao { get; set; }
                public string HinhMauViTri { get; set; }
                public int ThuTu { get; set; }
            }
            public class DocDanhSach : CommonInput.ChungThuc
            {
                public string MaNenTang { get; set; }
            }
        }
        public class Output
        {
            public class ThongTin
            {
                public string Id { get; set; }
                public string MaNenTang { get; set; }
                public string Ma { get; set; }
                public string Ten { get; set; }
                public string MoTa { get; set; }
                public int ChieuRong { get; set; }
                public int ChieuCao { get; set; }
                public string HinhMauViTri { get; set; }
                public int ThuTu { get; set; }
            }

            public class DocDanhSach : CommonDocDanhSachOutput
            {
                public List<ThongTin> DanhSach { get; set; }
            }
        }
    }
}