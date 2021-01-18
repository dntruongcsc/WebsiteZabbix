using MVCProjectStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.Admin.Models.Menu
{
    public class MenuModel
    {
        public class MenuInput
        {
            public class ThongTin : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string IdMenuCha { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
                public int Nhom { get; set; }
                public string LienKet { get; set; }
                public int KichHoat { get; set; }
                public int ViTri { get; set; }
                public string Icon { get; set; }
                public string MoTa { get; set; }
                public int Loai { get; set; }
                public string BieuTuong { get; set; }
                public int KieuHienThi { get; set; }
                public string IdDonVi { get; set; }
            }

            public class TimKiemMenu : CommonInput.ChungThuc
            {
                public string TuKhoa { get; set; }
                public int Nhom { get; set; }
                public int Loai { get; set; }
            }

            public class CapNhatViTri : CommonInput.ChungThuc
            {
                public List<ViTriCapNhat> DanhSachViTri { get; set; }
                public class ViTriCapNhat
                {
                    public string Id { get; set; }
                    public int ViTri { get; set; }
                }
                public CapNhatViTri()
                {
                    DanhSachViTri = new List<ViTriCapNhat>();
                }
            }

            public class DocChucNangTheoMa : CommonInput.ChungThuc
            {
                public string Ma { get; set; }
            }
        }
        public class MenuOutput
        {
            public class ThongTin
            {
                public string Id { get; set; }
                public string IdMenuCha { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
                public string TuKhoa { get; set; }
                public int Nhom { get; set; }
                public string LienKet { get; set; }
                public int KichHoat { get; set; }
                public int ViTri { get; set; }
                public string Icon { get; set; }
                public string MoTa { get; set; }
                public int Loai { get; set; }
                public string BieuTuong { get; set; }
                public int KieuHienThi { get; set; }
                public string IdDonVi { get; set; }
            }


            public class ThongTinMenuOngNoi : ThongTin
            {
                public List<ThongTinMenuCha> DsMenuCha { get; set; }
                public ThongTinMenuOngNoi()
                {
                    DsMenuCha = new List<ThongTinMenuCha>();
                }
            }
            public class ThongTinMenuCha : ThongTin
            {
                public List<ThongTinMenuCon> DsMenuCon { get; set; }
                public ThongTinMenuCha()
                {
                    DsMenuCon = new List<ThongTinMenuCon>();
                }
            }
            public class ThongTinMenuCon : ThongTin
            {
                public List<ThongTinMenuChau> DsMenuChau { get; set; }
                public ThongTinMenuCon()
                {
                    DsMenuChau = new List<ThongTinMenuChau>();
                }
            }
            public class ThongTinMenuChau : ThongTin
            {
                public List<ThongTin> DsMenu { get; set; }
                public ThongTinMenuChau()
                {
                    DsMenu = new List<ThongTin>();
                }
            }

            public class DocDanhSach
            {
                public List<ThongTinMenuOngNoi> DanhSach { get; set; }
                public DocDanhSach()
                {
                    DanhSach = new List<ThongTinMenuOngNoi>();
                }
            }
            public class DocDanhSachXuatBan: DocDanhSach
            {
                public int TongSoDong { get; set; }
            }
            /// <summary>
            /// Dùng cho xuất menu left
            /// </summary>
            public class ThongTinMenuPhanCap : ThongTin
            {
                public List<ThongTinMenuPhanCap> DanhSachMenuCon { get; set; }
                public List<string> DanhSachMaChucNangXuLy { get; set; }
                public ThongTinMenuPhanCap()
                {
                    DanhSachMenuCon = new List<ThongTinMenuPhanCap>();
                }
            }
            public class DocDanhSachTheoDieuKien
            {
                public List<ThongTin> DanhSach { get; set; }
                public DocDanhSachTheoDieuKien()
                {
                    DanhSach = new List<ThongTin>();
                }
            }

            public class ThongTinDanhMucChucNang
            {
                public string Id { get; set; }
                public string MaChucNang { get; set; }
                public string TenChucNang { get; set; }
                public string DuongDan { get; set; }
                public ThongTinThamSo ThamSo { get; set; }
                public class ThongTinThamSo
                {
                    public string Loai { get; set; }
                    public string TieuDe { get; set; }
                    public string Action { get; set; }
                }

            }

            public class DanhSachDanhMucChucNang
            {
                public List<ThongTinDanhMucChucNang> DanhSach { get; set; }
                public DanhSachDanhMucChucNang()
                {
                    DanhSach = new List<ThongTinDanhMucChucNang>();
                }
            }

            public class ThemCapNhatMenu
            {
                public ThongTin ThongTinMenu { get; set; }
                public List<ThongTinMenuOngNoi> DanhSachMenu { get; set; }
                public List<ThongTinDanhMucChucNang> DanhMucChucNang { get; set; }
                public ThemCapNhatMenu()
                {
                    ThongTinMenu = new ThongTin();
                    DanhSachMenu = new List<ThongTinMenuOngNoi>();
                    DanhMucChucNang = new List<ThongTinDanhMucChucNang>();
                }
            }
            public class XoaDanhSach
            {
                public List<string> Ids { get; set; }
            }

            public class ThongTinDanhChoMenu
            {
                public string Id { get; set; }
                public string TieuDe { get; set; }
                public string DuongDan { get; set; }
            }
            public class DuLieu
            {
                public List<ThongTinDanhChoMenu> DanhSach { get; set; }
                public DuLieu()
                {
                    DanhSach = new List<ThongTinDanhChoMenu>();
                }
            }
        }
    }
}