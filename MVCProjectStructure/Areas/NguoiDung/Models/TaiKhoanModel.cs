using MVCProjectStructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.NguoiDung.Models
{
    public class TaiKhoanModel
    {
        public class TaiKhoanInput
        {
            #region Tài khoản
            public class DangNhapInput
            {
                [Display(Name = "Tên tài khoản")]
                [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
                public string TenTaiKhoan { get; set; }

                [Display(Name = "Mật khẩu")]
                [DataType(DataType.Password)]
                [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
                public string MatKhau { get; set; }
                [Display(Name = "Nền tảng")]
                public string NenTang { get; set; }
            }
            public class DoiMatKhauInput : CommonInput.ChungThuc
            {

                [Display(Name = "Mật khẩu hiện tại")]
                [DataType(DataType.Password)]
                //[Required(ErrorMessage = "{0} bắt buộc phải nhập")]
                public string MatKhauHienTai { get; set; }

                [Display(Name = "Mật khẩu mới")]
                [DataType(DataType.Password)]
                //[Required(ErrorMessage = "{0} bắt buộc phải nhập")]
                public string MatKhauMoi { get; set; }

                [Display(Name = "Nhập lại mật khẩu mới")]
                [DataType(DataType.Password)]
                [Compare("MatKhauMoi", ErrorMessage = "{0} không trùng khớp.")]
                //[Required(ErrorMessage = "{0} bắt buộc phải nhập")]
                public string NhapLaiMatKhauMoi { get; set; }
            }
            public class DangXuatInput : CommonInput.ChungThuc { }


            public class ThongTinTaiKhoanInput : CommonInput.ChungThuc
            {
                public string Id { get; set; }

                [Display(Name = "Loại người dùng")]
                public int LoaiNguoiDung { get; set; }

                [Display(Name = "Người dùng")]
                public string IdNguoiDung { get; set; }

                [Display(Name = "Đơn vị")]
                public string IdDonVi { get; set; }

                [Display(Name = "Tên tài khoản")]
                [Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
                public string TenTaiKhoan { get; set; }

                [Display(Name = "Mật khẩu")]
                //[Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
                [DataType(dataType: DataType.Password)]
                public string MatKhau { get; set; }

                [Display(Name = "Nhập lại mật khẩu")]
                //[Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
                [DataType(dataType: DataType.Password)]
                public string NhapLaiMatKhau { get; set; }

                [Display(Name = "Kích hoạt")]
                public int KichHoat { get; set; } // Mặc định khi mới tạo là 1
                public List<ChucNang> DanhSachChucNang { get; set; }
                public ThongTinTaiKhoanInput() { DanhSachChucNang = new List<ChucNang>(); }

                public string HoTenNguoiDung { get; set; }
                public bool LaQuanTri { get; set; }

                public class ChucNang
                {
                    public string IdChucNang { get; set; }
                    public string IdChucNangCha { get; set; }
                }
                public class NguoiDung
                {
                    public string IdNguoiDung { get; set; }
                    public string HoTen { get; set; }
                    public string IdDonVi { get; set; }
                    public bool LaQuanTri { get; set; }
                }
            }
            public class TaiKhoanEditInput : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                [Display(Name = "Tên tài khoản")]
                [Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
                public string TenTaiKhoan { get; set; }

                [Display(Name = "Mật khẩu")]
                [DataType(dataType: DataType.Password)]

                public string MatKhau { get; set; }

                [Display(Name = "Nhập lại mật khẩu")]
                [DataType(dataType: DataType.Password)]
                [Compare("MatKhau", ErrorMessage = "{0} không trùng khớp.")]
                public string NhapLaiMatKhau { get; set; }
                //--------------------------------------------
                [Display(Name = "Kích hoạt")]
                public int KichHoat { get; set; } // Mặc định khi mới tạo là 1
                public bool LaQuanTri { get; set; }
                public List<ThongTinTaiKhoanInput.ChucNang> DanhSachChucNang { get; set; }
                public TaiKhoanEditInput() { DanhSachChucNang = new List<ThongTinTaiKhoanInput.ChucNang>(); }
            }

            #endregion
        }
        public class TaiKhoanOutput
        {
            #region Tài khoản - phân quyền cho tài khoản

            public class UserToken : CommonInput.ChungThuc { }

            public class DangNhapOutput : CommonInput.ChungThuc
            {
                public string HoTen { get; set; }
                public string IdNguoiDung { get; set; }
                public string IdDonVi { get; set; }
                public string Email { get; set; }
                public string Id { get; set; }
                public List<NhomNguoiDungThongTin> DanhSachNhomNguoiDung { get; set; }
                public List<ChucNangNguoiDung> DanhSachChucNang { get; set; }
                //public CommonNguoiDung.NguoiDungOutput.ThongTinNguoiDungOutput.ThongTinNguoiDung NguoiDung { get; set; }
                public string ChucNangChon { get; set; }
                public List<ThongTinTuan> DanhSachTuan { get; set; }
                public DangNhapOutput()
                {
                    DanhSachNhomNguoiDung = new List<NhomNguoiDungThongTin>();
                    DanhSachChucNang = new List<ChucNangNguoiDung>();
                   // NguoiDung = new CommonNguoiDung.NguoiDungOutput.ThongTinNguoiDungOutput.ThongTinNguoiDung();
                }
                public class NhomNguoiDungThongTin
                {
                    public string Id { get; set; }
                    public string Ma { get; set; }
                    public string Ten { get; set; }
                }

                public class ChucNangNguoiDung
                {
                    public string Id { get; set; }
                    public string Ma { get; set; }
                    public string Ten { get; set; }
                    public int ViTri { get; set; }
                    public string IdCha { get; set; }
                    public string LienKet { get; set; }
                    public string BieuTuong { get; set; }
                    public string Icon { get; set; }
                    public string MoTa { get; set; }
                    public int KichHoat { get; set; }
                    public bool Menu { get; set; }
                }
                public class ThongTinTuan
                {
                    public string Id { get; set; }
                    public string ChuoiNam { get; set; }
                    public string ChuoiThang { get; set; }
                    public string ChuoiTuan { get; set; }
                    public string ChuoiNgayBatDau { get; set; }
                    public string ChuoiNgayKetThuc { get; set; }
                    public int Nam { get; set; }
                    public int Thang { get; set; }
                    public int Tuan { get; set; }
                    public double NgayBatDau { get; set; }
                    public double NgayKetThuc { get; set; }
                    public bool TuanHienTai { get; set; }
                }
            }
            public class DangNhapModelOuput:DangNhapOutput
            {
                public List<CommonThongTinChung> DanhSachVaiTro { get; set; }
                public List<CommonThongTinChung> DanhSachPhongBan { get; set; }
                public List<CommonPhanQuyen.PhanQuyenOutput.ThongTinPhanQuyen.ThongTinMenu> DanhSachChucNangPhanQuyen { get; set; }
                public DangNhapModelOuput()
                {
                    DanhSachVaiTro = new List<CommonThongTinChung>();
                    DanhSachPhongBan = new List<CommonThongTinChung>();
                    DanhSachChucNangPhanQuyen = new List<CommonPhanQuyen.PhanQuyenOutput.ThongTinPhanQuyen.ThongTinMenu>();
                }
            }
            public class ThongTinTaiKhoanOutput
            {
                public string Id { get; set; }

                [Display(Name = "Loại người dùng")]
                public int LoaiNguoiDung { get; set; }

                [Display(Name = "Tên tài khoản")]
                public string TenTaiKhoan { get; set; }

                public string MatKhau { get; set; }

                public string IdDonVi { get; set; }

                [Display(Name = "Kích hoạt")]
                public int KichHoat { get; set; }

                [Display(Name = "Họ tên người dùng")]
                public string HoTen { get; set; }

                [Display(Name = "Email")]
                public string Email { get; set; }

                [Display(Name = "Điện thoại")]
                public string DienThoai { get; set; }

                public string IdNguoiDung { get; set; }

                [Display(Name = "Danh sách chức năng")]
                public List<ChucNang> DanhSachChucNang { get; set; }
                public List<ChucNangLienKet> DanhSachLienKet { get; set; }
                public class ChucNang
                {
                    public string IdChucNang { get; set; }
                    public string IdChucNangCha { get; set; }
                }
                public class ChucNangLienKet
                {
                    public string IdChucNang { get; set; }
                    public string TenLienKet { get; set; }
                }
            }

            public class TaiKhoanDanhSachOutput : DanhSachOutput
            {
                public List<ThongTinTaiKhoanOutput> DanhSachTaiKhoan { get; set; }
            }

            #endregion
        }
    }
}