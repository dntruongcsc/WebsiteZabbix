using MVCProjectStructure.Models;
using System.Collections.Generic;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.QuangCao.Models
{
    public class QuangCaoModel
    {
        public class QuangCaoInput
        {
            public class ThongTinQuangCao : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string IdDonVi { get; set; }
                public string MaNenTang { get; set; }
                public string MaLoai { get; set; }
                public string TieuDe { get; set; }
                public string MoTa { get; set; }
                public string NoiDung { get; set; }
                public int ThuTuHienThi { get; set; }
                public bool KichHoat { get; set; }
                public bool UuTien { get; set; }
                public string HinhDaiDien { get; set; }
                public string DuongDan { get; set; }
                public string TuNgay { get; set; }
                public string DenNgay { get; set; }
                public int SoLuotClick { get; set; }
                public int SoLuotHienThi { get; set; }
            }
            public class TimKiemQuangCao : CommonInput.TimKiem
            {
                public string MaNenTang { get; set; }
                public string MaLoai { get; set; }
            }
        }
        public class QuangCaoOutput
        {
            public class ThongTinQuangCao
            {
                public string Id { get; set; }
                public string IdDonVi { get; set; }
                public string MaNenTang { get; set; }
                public string MaLoai { get; set; }
                public string TieuDe { get; set; }
                public string MoTa { get; set; }
                public string NoiDung { get; set; }
                public int ThuTuHienThi { get; set; }
                public bool KichHoat { get; set; }
                public bool UuTien { get; set; }
                public ThongTinLoai Loai { get; set; }
                public string HinhDaiDien { get; set; }
                public string DuongDan { get; set; }
                public double TuNgay { get; set; }
                public string ChuoiTuNgay { get; set; }
                public double DenNgay { get; set; }
                public string ChuoiDenNgay { get; set; }
                public int SoLuotClick { get; set; }
                public int SoLuotHienThi { get; set; }

                public class ThongTinLoai
                {
                    public string Id { get; set; }
                    public string Ten { get; set; }
                    public string MoTa { get; set; }
                    public int ChieuRong { get; set; }
                    public int ChieuCao { get; set; }
                    public string HinhMauViTri { get; set; }
                }
            }

            public class DocDanhSach : CommonDocDanhSachOutput
            {
                public List<ThongTinQuangCao> DanhSach { get; set; }
                public DocDanhSach()
                {
                    DanhSach = new List<ThongTinQuangCao>();
                }
            }
        }
    }
}