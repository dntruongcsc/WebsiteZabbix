using MVCProjectStructure.Models;
using System.Collections.Generic;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.Admin.Models.NhatKy
{
    public class NhatKyModel
    {
        public class NhatKyInput
        {
            public class ThongTinNhatKy : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string MaUser { get; set; }
                public string MaChucNang { get; set; }
                public string TenChucNang { get; set; }
                public string DuongDan { get; set; }
                public string MaLoaiNhatKy { get; set; }
                public string TenLoaiNhatKy { get; set; }
                public string LoaiHeDieuHanh { get; set; }
                public string PhienBanHeDieuHanh { get; set; }
                public string TenDoiTuongThucThi { get; set; }
                public string TenFileXuLy { get; set; }
                public string TenPhuongThuc { get; set; }
                public string NoiDung { get; set; }
                public double ThoiGian { get; set; }
                public string TuKhoa { get; set; }
            }
            public class TimKiemNhatKy : CommonInput.TimKiem
            {
                public string Loai { get; set; }
                public string TuNgay { get; set; }
                public string DenNgay { get; set; }
            }

            public class ThemNhatKy : CommonInput.ChungThuc
            {
                public string MaUser { get; set; }
                public string MaChucNang { get; set; }
                public string MaLoaiNhatKy { get; set; }
                public string TenDoiTuongThucThi { get; set; }
                public string TenFileXuLy { get; set; }
                public string TenPhuongThuc { get; set; }
                public string NoiDung { get; set; }
            }
        }
        public class NhatKyOutput
        {
            public class ThongTinNhatKy
            {
                public string Id { get; set; }
                public string MaUser { get; set; }
                public string MaChucNang { get; set; }
                public string TenChucNang { get; set; }
                public string DuongDan { get; set; }
                public string MaLoaiNhatKy { get; set; }
                public string TenLoaiNhatKy { get; set; }
                public string LoaiHeDieuHanh { get; set; }
                public string PhienBanHeDieuHanh { get; set; }
                public string TenDoiTuongThucThi { get; set; }
                public string TenFileXuLy { get; set; }
                public string TenPhuongThuc { get; set; }
                public string NoiDung { get; set; }
                public double ThoiGian { get; set; }
                public string TuKhoa { get; set; }
            }

            public class DocDanhSach : CommonDocDanhSachOutput
            {
                public List<ThongTinNhatKy> DanhSach { get; set; }
            }
        }
    }
}