using MVCProjectStructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.NguoiDung.Models
{
    public class NguoiDungModel
    {
        public class NguoiDungInput
        {
            public class DocDanhSachTimKiem : CommonInput.TimKiem
            {
                public string MaDonVi { get; set; }
                public string MaVaiTro { get; set; }
                public int TrangThai { get; set; }
            }
            public class ThongTin : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string Ho { get; set; }
                public string Ten { get; set; }
                public string HinhAnh { get; set; }
                public string Email { get; set; }
                public double NgaySinh { get; set; }
                public string DienThoai { get; set; }
                public string DiaChi { get; set; }
                public string IdAp { get; set; }
                public string IdXa { get; set; }
                public string IdHuyen { get; set; }
                public string IdTinh { get; set; }
                public string MaVaiTro { get; set; }
                public List<string> DanhSachIdVaiTro { get; set; }
                public string IdDonVi { get; set; }
                public string MaDonVi { get; set; }
                public string TenTaiKhoan { get; set; }
                public string MatKhau { get; set; }
                public string NhapLaiMatKhau { get; set; }
                public bool KichHoat { get; set; }
                public List<string> DanhSachIdPhanQuyen { get; set; }
                public ThongTin()
                {
                    DanhSachIdVaiTro = new List<string>();
                    DanhSachIdPhanQuyen = new List<string>();
                }
            }
            public class DoiMatKhau:CommonInput.ChungThuc
            {
                public string TenTaiKhoan { get; set; }
                public string MatKhau { get; set; }
                public string MatKhauMoi { get; set; }
                public string NhapLaiMatKhau { get; set; }
            }
        }
        public class NguoiDungOutput
        {
            public class ThongTin
            {
                public string Id { get; set; }
                public string Ho { get; set; }
                public string Ten { get; set; }
                public string HinhAnh { get; set; }
                public string Email { get; set; }
                public double NgaySinh { get; set; }
                public string DienThoai { get; set; }
                public string DiaChi { get; set; }
                public string IdAp { get; set; }
                public string IdXa { get; set; }
                public string IdHuyen { get; set; }
                public string IdTinh { get; set; }
                public string MaVaiTro { get; set; }
                public List<string> DanhSachIdVaiTro { get; set; }
                public string IdDonVi { get; set; }
                public string MaDonVi { get; set; }
                public string TenTaiKhoan { get; set; }
                public string MatKhau { get; set; }
                public bool KichHoat { get; set; }

                public string TenVaiTro { get; set; }
                public string TenDonVi { get; set; }
                public string ChuoiNgayTao { get; set; }
                public List<string> DanhSachIdPhanQuyen { get; set; }
                public List<string> DanhSachMaDonViTheoPhanQuyen { get; set; }
                public List<string> DanhSachIdDonViTheoPhanQuyen { get; set; }
                public ThongTin()
                {
                    DanhSachIdVaiTro = new List<string>();
                    DanhSachIdPhanQuyen = new List<string>();
                    DanhSachMaDonViTheoPhanQuyen = new List<string>();
                    DanhSachIdDonViTheoPhanQuyen = new List<string>();
                }
            }
            public class DocDanhSach : CommonDocDanhSachOutput
            {
                public List<ThongTin> DanhSach { get; set; }
            }
            public class DangNhapTaiKhoan: ThongTin
            {
                public string TokenNguoiDung { get; set; }
                public string TokenApi { get; set; }
                public string HoTen { get; set; }
                public List<CommonMenu.MenuOutput.ThongTinMenuPhanCap> DanhSachMenu { get; set; }
                public List<CommonMenu.MenuOutput.ThongTinMenuPhanCap> DanhSachMenuPhanCap { get; set; }
                public DangNhapTaiKhoan()
                {
                    DanhSachMenu = new List<Admin.Models.Menu.MenuModel.MenuOutput.ThongTinMenuPhanCap>();
                    DanhSachMenuPhanCap = new List<Admin.Models.Menu.MenuModel.MenuOutput.ThongTinMenuPhanCap>();
                }
            }
        }
    }
}