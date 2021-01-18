using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.DiaChi.Models
{
    public class TinhModel
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
            public class Huyen
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public List<Xa> DanhSachXa { get; set; }
                public Huyen()
                {
                    DanhSachXa = new List<Xa>();
                }
            }
            public class Xa
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public List<Ap> DanhSachAp { get; set; }
                public Xa()
                {
                    DanhSachAp = new List<Ap>();
                }
            }
            public class Ap
            {
                public string Id { get; set; }
                public string Ten { get; set; }
            }

            public class ThongTinTinh
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
                public List<Huyen> DanhSachHuyen { get; set; }
                public ThongTinTinh()
                {
                    DanhSachHuyen = new List<Huyen>();
                }
            }
            public class ThongTinTinhWeb : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
                public bool TinhHienTai { get; set; }
            }
        }
    }
}