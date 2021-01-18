using MVCProjectStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.NguoiDung.Models
{
    public class PhanQuyenModel
    {
        public class PhanQuyenInput
        {
            public class DocThongTinTheoVaiTroVaDonVi : CommonInput.ChungThuc
            {
                public string IdVaiTro { get; set; }
                public string IdDonVi { get; set; }
            }
            public class DocDanhSach : CommonInput.DocDanhSach
            {

            }
            public class ThongTinPhanQuyen : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string TenQuyen { get; set; }
                public string MaVaiTro { get; set; }
                public string MaDonVi { get; set; }
                public List<ThongTinMenu> DanhSachMenu { get; set; }
                public class ThongTinMenu
                {
                    public string IdMenu { get; set; }
                    public string TenMenu { get; set; }
                    public int Loai { get; set; }
                    public int Nhom { get; set; }
                    public string IdMenuCha { get; set; }
                    public List<string> DanhSachMaChucNangXuLy { get; set; }
                    public ThongTinMenu()
                    {
                        DanhSachMaChucNangXuLy = new List<string>();
                    }
                }
                public ThongTinPhanQuyen()
                {
                    DanhSachMenu = new List<ThongTinMenu>();
                }
            }
        }
        public class PhanQuyenOutput
        {
            public class ThongTinPhanQuyen
            {
                public string Id { get; set; }
                public string TenQuyen { get; set; }
                public string MaVaiTro { get; set; }
                public string MaDonVi { get; set; }
                public List<ThongTinMenu> DanhSachMenu { get; set; }
                public class ThongTinMenu
                {
                    public string Id { get; set; }
                    public string Ten { get; set; }
                    public int Loai { get; set; }
                    public int Nhom { get; set; }
                    public string IdMenuCha { get; set; }
                    public List<ThongTinMenu> DanhSachMenuCon { get; set; }
                    public List<string> DanhSachMaChucNangXuLy { get; set; }
                }
            }
            public class ThongTin_ThuGon
            {
                public string Id { get; set; }
                public string TenQuyen { get; set; }
                public string MaVaiTro { get; set; }
                public string TenVaiTro { get; set; }
                public string MaDonVi { get; set; }
                public string TenDonVi { get; set; }
            }
        }
    }
}