using MVCProjectStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.NguoiDung.Models
{
    public class VaiTroModel
    {
        public class VaiTroInput
        {
            public class DocDanhSach: CommonInput.DocDanhSach
            {

            }
            public class ThongTinVaiTro : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
            }
            public class TimKiemVaiTro : CommonInput.TimKiem
            {
                public string IdDonVi { get; set; }
            }
        }
        public class VaiTroOutput
        {
            public class ThongTinChucNang
            {
                public string IdChucNang { get; set; }
                public string ViTri { get; set; }
                public string IdChucNangCha { get; set; }
            }
            public class ThongTinVaiTro
            {
                public string Id { get; set; }
                public string Ma { get; set; }
                public string Ten { get; set; }
                public string MoTa { get; set; }
                public int ThuTu { get; set; }
            }
            public class DocDanhSach : CommonDocDanhSachOutput
            {
                public List<ThongTinVaiTro> DanhSach { get; set; }
            }
        }
    }
}