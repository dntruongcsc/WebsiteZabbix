using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVCProjectStructure.Helpers
{
    #region Dùng chung
    public class Output
    {
        public int KetQua { get; set; }
        public string ThongBao { get; set; }
        public object DuLieu { get; set; }
        public string GhiChu { get; set; }
        public string TongSoLuong { get; set; }
    }
    public class DanhSachOutput
    {
        public int ViTriBatDau { get; set; }
        public int ViTriKetThuc { get; set; }
        public int TongSoLuong { get; set; }
    }

    public class TimKiemOutput
    {
        public string Id { get; set; }
        public string ThongTin { get; set; }
    }
    public class AjaxPostError
    {
        public string ErrorMessage { get; set; }
        public string RedirectUrl { get; set; }
    }
    public class ThongBaoLoiOutput
    {
        public const string KhongCoQuyen = "Bạn không có quyền truy cập chức năng này!";
        public const string DangNhapLai = "Vui lòng đăng nhập lại!";
    }
    #endregion

    //29-11-2017
    #region Nhóm chức năng
    public class NhomChucNangOutput
    {
        public string Id { get; set; }
        [Display(Name = "Tên nhóm chức năng")]
        public string Ten { get; set; }
        public List<ChucNang> DanhSachChucNang { get; set; }
        public class ChucNang
        {
            public string IdChucNang { get; set; }
            [Display(Name = "Tên chức năng")]
            public string Ten { get; set; }
            public int Loai { get; set; }
            public string IdChucNangCha { get; set; }
            public int ViTri { get; set; } //4-12-2017
            public string MoTa { get; set; } //5-12-2017
        }
    }


    public class NhomChucNangDanhSachOutput
    {
        public List<NhomChucNangOutput> NhomChucNang { get; set; }
    }

    #endregion

    //29-11-2017
    #region Chức năng
    public class ChucNangOutput
    {
        public string Id { get; set; }
        public string Ma { get; set; }
        /// <summary>
        /// Loai: 
        ///     0: Web
        ///     1: Mobile
        /// </summary>
        public int Loai { get; set; }
        [Display(Name = "Chức năng cha")]
        public string IdChucNangCha { get; set; }
        [Display(Name = "Tên chức năng")]
        public string Ten { get; set; }
        [Display(Name = "Biểu tượng")]
        public string BieuTuong { get; set; }
        [Display(Name = "Liên kết")]
        public string LienKet { get; set; }
        [Display(Name = "Kích hoạt")]
        public int KichHoat { get; set; }
        [Display(Name = "Vị trí")]
        public int ViTri { get; set; }
        [Display(Name = "Icon")]
        public string Icon { get; set; }
        [Display(Name = "Menu")]
        public bool Menu { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [Display(Name = "Danh sách chức năng xử lý")]
        public List<ChucNangXuLyOutput> DanhSachThongTinChucNangXuLy { get; set; }

    }
    public class ChucNangXuLyOutput
    {
        public class ThongTinChucNangXuly
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public int ViTri { get; set; }
            public string Icon { get; set; }
            public string BieuTuong { get; set; }
            public int KichHoat { get; set; }
        }

        public class DocDanhSachPhanTrang
        {
            public int TongSoTrang { get; set; }
            public List<ThongTinChucNangXuly> DanhSachChucNangXuLy { get; set; }
            public DocDanhSachPhanTrang()
            {
                DanhSachChucNangXuLy = new List<ThongTinChucNangXuly>();
            }
        }

    }

    public class ChucNangConOutput : ChucNangOutput
    {
        public double NgayTao { get; set; }
        public string IdNguoiTao { get; set; }
        public double NgayCapNhat { get; set; }
        public string IdNguoiCapNhat { get; set; }
        public List<ChucNangConOutput> DanhSachChucNangCon { get; set; }
    }
    public class ChucNangLongCapOutput : ChucNangOutput
    {
        public List<ChucNangConOutput> DanhSachChucNangCon { get; set; }
    }
    public class ChucNangNCapOutput : NhomChucNangOutput.ChucNang
    {
        public List<ChucNangNCapOutput> DanhSachChucNangCon { get; set; }
    }
    public class ChucNangMCapOutput : ChucNangOutput
    {
        public List<ChucNangMCapOutput> DanhSachChucNangCon { get; set; }
    }

    #endregion

    //29-11-2017
    #region Tài khoản - phân quyền cho tài khoản

    public class UserToken : ChungThuc { }

    public class DangNhapOutput : ChungThuc
    {
        public string HoTen { get; set; }
        public string IdNguoiDung { get; set; }
        public string IdDonVi { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public List<VaiTroNguoiDungThongTin> DanhSachVaiTroNguoiDung { get; set; }
        public List<ChucNangNguoiDung> DanhSachChucNang { get; set; }
        public NguoiDungOutput.ThongTinNguoiDung NguoiDung { get; set; }
        public string ChucNangChon { get; set; }
        public List<ThongTinTuan> DanhSachTuan { get; set; }
        public DangNhapOutput()
        {
            DanhSachVaiTroNguoiDung = new List<VaiTroNguoiDungThongTin>();
            DanhSachChucNang = new List<ChucNangNguoiDung>();
            NguoiDung = new NguoiDungOutput.ThongTinNguoiDung();
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

    public class TaiKhoanOutput
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
        public List<TaiKhoanOutput> DanhSachTaiKhoan { get; set; }
    }

    #endregion

    #region Đơn vị tính

    public class DonViTinhOutput
    {
        public class DocDanhSach
        {
            public string Id { get; set; }
            [Display(Name = "Đơn vị tính")]
            public string Ten { get; set; }
            public List<string> DanhSachMaChucNang { get; set; }
            public string ChuoiDanhSachTenChucNang { get; set; }
        }
    }
    public class DonViTinhDanhSachOutput : DanhSachOutput
    {
        public List<DonViTinhOutput> DanhSachDonViTinh { get; set; }
    }


    #endregion

    #region Đơn vị
    public class DonViOutput
    {
        public class CauHinhEmail
        {
            public string SMTPServer { get; set; }
            public int Port { get; set; }
            public int SSL { get; set; }
            public string TaiKhoan { get; set; }
            public string MatKhau { get; set; }
            public string EmailGui { get; set; }
            public string TenHienThi { get; set; }
        }
        public class ThongTinDonVi // : Output
        {
            public string Id { get; set; }
            //public string Ma { get; set; }
            [Display(Name = "Đơn vị")]
            public string Ten { get; set; }

            public string DiaChi { get; set; }

            public string DienThoai { get; set; }

            public string Email { get; set; }

            public string Fax { get; set; }

            public string Logo { get; set; }
            public string IdDonVi { get; set; }

            public string MaDonViTrucThuoc { get; set; }

            public CauHinhEmail CauHinhEmail { get; set; }

            public ThongTinDonVi DonViTrucThuoc { get; set; }

            public int Cap { get; set; }
            public List<string> DanhSachIdTinh { get; set; }
            public List<string> DanhSachIdHuyen { get; set; }
            public List<string> DanhSachIdXa { get; set; }
            public List<string> DanhSachIdAp { get; set; }
            public ThongTinDonVi()
            {
                CauHinhEmail = new CauHinhEmail();
                DanhSachIdTinh = new List<string>();
                DanhSachIdHuyen = new List<string>();
                DanhSachIdXa = new List<string>();
                DanhSachIdAp = new List<string>();
            }
        }
        public class DocDanhSachDonVi
        {
            public int ViTriBatDau;

            public int ViTriKetThuc;

            public int TongSoLuong;

            public List<ThongTinDonVi> DanhSachDonVi;

            public DocDanhSachDonVi()
            {
                DanhSachDonVi = new List<ThongTinDonVi>();
            }
        }
        public class DanhSachDonViPhanTrang
        {
            public int TongSoTrang { get; set; }
            public List<ThongTinDonVi> DanhSachDonVi { get; set; }
        }
    }
    #endregion

    #region Người dùng

    public class NguoiDungOutput
    {
        public class ThongTinTaiKhoan
        {
            public string Id { get; set; }
            [Display(Name = "Tài khoản")]
            public string TenTaiKhoan { get; set; }
            public string IdDonVi { get; set; }
            [Display(Name = "Kích hoạt")]
            public bool KichHoat { get; set; }
        }
        public class ThongTinNguoiDung
        {
            [Display(Name = "ID")]
            public string Id { get; set; }

            [Display(Name = "Họ và tên")]
            public string Ten { get; set; }

            [Display(Name = "Địa chỉ")]
            public string DiaChi { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Số điện thoại")]
            public string DienThoai { get; set; }

            [Display(Name = "Đơn vị")]
            public string IdDonVi { get; set; }
            [Display(Name = "Xóm|Ấp")]
            public string IdAp { get; set; }

            [Display(Name = "Phường|Xã")]
            public string IdXa { get; set; }
            [Display(Name = "Quận|Huyện")]
            public string IdHuyen { get; set; }

            [Display(Name = "Tỉnh")]
            public string IdTinh { get; set; }

            [Display(Name = "Xóm|Ấp")]
            public string TenAp { get; set; }

            [Display(Name = "Phường|Xã")]
            public string TenXa { get; set; }
            [Display(Name = "Quận|Huyện")]
            public string TenHuyen { get; set; }

            [Display(Name = "Tỉnh")]
            public string TenTinh { get; set; }
            [Display(Name = "Nhóm người dùng")]
            public List<VaiTroNguoiDungThongTin> DanhSachVaiTroNguoiDung { get; set; }
            /// <summary>
            /// Đ4 gom tài khoản vào người dùng
            /// </summary>
            public string TenTaiKhoan { get; set; }
            public bool KichHoat { get; set; }

            public DonViOutput.ThongTinDonVi DonVi { get; set; }
            public ThongTinNguoiDung()
            {
                DanhSachVaiTroNguoiDung = new List<VaiTroNguoiDungThongTin>();
                DonVi = new DonViOutput.ThongTinDonVi();
            }
        }

        public class DocDanhSach : ThongTinNguoiDung { }

        public class DocDanhSachPhanTrang
        {
            public int TongSoTrang { get; set; }
            public List<ThongTinNguoiDung> DanhSachNguoiDung { get; set; }
            public DocDanhSachPhanTrang()
            {
                DanhSachNguoiDung = new List<ThongTinNguoiDung>();
            }
        }
    }

    public class VaiTroNguoiDungThongTin
    {
        public string Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
    }

    public class NhomNguoiDung
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }

        public string IdDonVi { get; set; }

        public string DanhSachIdNguoiDung { get; set; }

    }

    public class ThongTinVeNguoiDungOutput
    {
        public List<ThongTin> DanhSachTonGiao { get; set; }
        public List<ThongTin> DanhSachDoanDoi { get; set; }
        public List<ThongTin> DanhSachKhuyetTat { get; set; }
        public List<ThongTin> DanhSachDienChinhSach { get; set; }
        public List<ThongTin> DanhSachDanToc { get; set; }
        public List<ThongTin> DanhSachNgoaiNgu { get; set; }
        public List<ThongTin> DanhSachTrinhDo { get; set; }

        public class ThongTin
        {
            public string Id { get; set; }
            public string Ten { get; set; }
        }
    }
    #endregion

    #region Nhóm người dùng --> Vai trò

    //public class NhomNguoiDungOutput //--Chuyển qua dùng vai trò
    //{
    //    public int TongSoLuong;

    //    public List<ThongTinNhomNguoiDung> DanhSachNhomNguoiDung;

    //    public class ThongTinNhomNguoiDung
    //    {
    //        public string Id { get; set; }
    //        public string Ten { get; set; }
    //        public string Ma { get; set; }
    //        public string MoTa { get; set; }
    //        public string IdDonVi { get; set; }
    //        public List<string> DanhSachIdNguoiDung { get; set; }
    //        public string TenDonVi { get; set; }
    //    }
    //}
    public class VaiTroNguoiDungOutput
    {
        public int TongSoLuong;

        public List<ThongTinVaiTroNguoiDung> DanhSachNhomNguoiDung;

        public class ThongTinVaiTroNguoiDung
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string Ma { get; set; }
            public string MoTa { get; set; }
            public string IdDonVi { get; set; }
            public List<string> DanhSachIdNguoiDung { get; set; }
            public string TenDonVi { get; set; }
        }
    }
    #endregion

    #region Tin tuc
    public class LoaiTinTucOutput : ChungThuc
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public string GhiChu { get; set; }
    }
    public class TraCuuTinTuc2
    {
        public int ViTriBatDau { get; set; }
        public int ViTriKetThuc { get; set; }
        public int TongSoLuong { get; set; }
        public List<TinTucTimOutPut> DanhSachTinTuc { get; set; }

    }
    public class TinTucTimOutPut
    {
        public string Id { get; set; }
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string TieuDe { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string NoiDungTomTat { get; set; }
        [Display(Name = "Nội dung chi tiết")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        [MinLength(20, ErrorMessage = "{0} bắt buộc phải nhập")]
        public string NoiDungChiTiet { get; set; }
        [Display(Name = "Loại tin tức")]
        public string IdLoaiTin { get; set; }
        public string TenLoaiTin { get; set; }
        public string IdNguoiTao { get; set; }
        public string TenNguoiTao { get; set; }
        public List<HinhAnh> DanhSachHinhAnh { get; set; }

        public double ThoiGianTao { get; set; }
        public double ThoiGianCapNhat { get; set; }
        public string dateThoiGianTao { get; set; }
        public string dateThoiGianCapNhat { get; set; }
        /// <summary>
        /// true(hiện)/false(ẩn)
        /// </summary>
        [Display(Name = "Đường dẫn")]
        public string DuongDan { get; set; }
        [Display(Name = "Đặt làm tin chính")]
        public bool TinChinh { get; set; }
        [Display(Name = "Đặt làm tin nổi bật")]
        public bool TinNoiBat { get; set; }
        [Display(Name = "Xuất bản")]
        public bool TrangThai { get; set; }
    }
    public class TinTucOutPut : ChungThuc
    {
        public string Id { get; set; }
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string TieuDe { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string NoiDungTomTat { get; set; }
        [Display(Name = "Nội dung chi tiết")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        [MinLength(20, ErrorMessage = "{0} bắt buộc phải nhập")]
        public string NoiDungChiTiet { get; set; }
        [Display(Name = "Loại tin tức")]
        public string IdLoaiTin { get; set; }
        public string TenLoaiTin { get; set; }
        public string IdNguoiTao { get; set; }
        public string TenNguoiTao { get; set; }
        public List<HinhAnh> DanhSachHinhAnh { get; set; }

        public double ThoiGianTao { get; set; }
        public double ThoiGianCapNhat { get; set; }
        public string dateThoiGianTao { get; set; }
        public string dateThoiGianCapNhat { get; set; }
        [Display(Name = "Đường dẫn")]
        public string DuongDan { get; set; }
        [Display(Name = "Đặt làm tin chính")]
        public bool TinChinh { get; set; }
        [Display(Name = "Đặt làm tin nổi bật")]
        public bool TinNoiBat { get; set; }
        [Display(Name = "Xuất bản")]
        public bool TrangThai { get; set; }
    }
    public class HinhAnhOutPut
    {
        public string Ten { get; set; }
        public string ChieuDai { get; set; }
        public string ChieuRong { get; set; }
        public string DungLuong { get; set; }
        public string DuongDan { get; set; }
    }
    #endregion

    #region banner
    public class DocDanhSachBannerOutput
    {
        public int ViTriBatDau { get; set; }
        public int ViTriKetThuc { get; set; }
        public int TongSoLuong { get; set; }
        public List<BannerInput> DanhSachBanner { get; set; }
    }

    public class DocDanhSachBannerLienKetOutput
    {
        public int ViTriBatDau { get; set; }
        public int ViTriKetThuc { get; set; }
        public int TongSoLuong { get; set; }
        public List<BannerLienKetInput> DanhSachLienKet { get; set; }
    }
    #endregion

    #region Nhóm Tin
    public class DocDanhSachNhomTinPhanTrang
    {
        public int ViTriBatDau { get; set; }
        public int ViTriKetThuc { get; set; }
        public int TongSoLuong { get; set; }
        public List<NhomTinInput> DanhSachMenu { get; set; }

    }
    public class NhomTinCha
    {
        public string Id { get; set; }
        [Display(Name = "Tên nhóm")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string TenNhom { get; set; }

        [Display(Name = "Tên hiển thị trên menu")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string TenHienThiTrenMenu { get; set; }
        [Display(Name = "Nhóm cha")]
        public string ThuocNhomCha { get; set; }

        [Display(Name = "Đường dẫn")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string DuongDan { get; set; }

        [Display(Name = "Định dạng")]
        public int DinhDang { get; set; }

        [Display(Name = "Hiển thị trên menu")]
        public bool HienThiTrenMenu { get; set; }

        [Display(Name = "Thứ tự")]
        public int ThuTu { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool KichHoat { get; set; }

        [Display(Name = "Hiển thị trên trang chủ")]
        public bool HienThiTrenTrangChu { get; set; }
        public List<NhomTin> DanhSachMenuCon { get; set; }
    }
    public class NhomTin
    {
        public string Id { get; set; }
        [Display(Name = "Tên nhóm")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string TenNhom { get; set; }

        [Display(Name = "Tên hiển thị trên menu")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string TenHienThiTrenMenu { get; set; }
        [Display(Name = "Nhóm cha")]
        public string ThuocNhomCha { get; set; }

        [Display(Name = "Đường dẫn")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string DuongDan { get; set; }

        [Display(Name = "Định dạng")]
        public int DinhDang { get; set; }

        [Display(Name = "Hiển thị trên menu")]
        public bool HienThiTrenMenu { get; set; }

        [Display(Name = "Thứ tự")]
        public int ThuTu { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool KichHoat { get; set; }

        [Display(Name = "Hiển thị trên trang chủ")]
        public bool HienThiTrenTrangChu { get; set; }
    }
    #endregion

    #region Tinh - huyện - Xã - Ấp
    public class TinhOutput
    {
        public class OutputId
        {
            public string Id { get; set; }
        }
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
            public bool TinhHienTai { get; set; }
            public List<Huyen> DanhSachHuyen { get; set; }
            public ThongTinTinh()
            {
                DanhSachHuyen = new List<Huyen>();
            }
        }
    }

    public class ChiTietTinhOutput
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public List<Huyen> DanhSachHuyen { get; set; }
        public class Huyen
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public List<Xa> DanhSachXa { get; set; }
            public class Xa
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public List<Ap> DanhSachAp { get; set; }
            }
            public class Ap
            {
                public string Id { get; set; }
                public string Ten { get; set; }
            }
        }
    }

    #endregion

    #region Thông tin khuyến nông
    #region Thông báo khẩn
    public class ThongBaoKhanOutput
    {
        public string Id { get; set; }
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Đường dẫn")]
        public string DuongDanThanThien { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Hình đại diện")]
        public string HinhDaiDien { get; set; }
        [Display(Name = "Thông báo cho thiết bị di động")]
        public int DoUuTien { get; set; }
        [Display(Name = "Kích hoạt")]
        public int TrangThai { get; set; }
        public string NgayTao { get; set; }
    }
    #endregion
    #region Thời tiết nông vụ
    public class ThoiTietNongVuOutput
    {
        public string Id { get; set; }
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Đường dẫn")]
        public string DuongDanThanThien { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Hình đại diện")]
        public string HinhDaiDien { get; set; }
        [Display(Name = "Thông báo cho thiết bị di động")]
        public int DoUuTien { get; set; }
        [Display(Name = "Kích hoạt")]
        public int TrangThai { get; set; }
        public string NgayTao { get; set; }
        public string IdNguoiTao { get; set; }
        public string IdNguoiCapNhat { get; set; }
        public string TenNguoiTao { get; set; }
        public string TenNguoiCapNhat { get; set; }
    }
    #endregion
    #region Kỹ thuật nôi trồng
    public class KyThuatNuoiTrongOutput : ChungThuc
    {
        public string Id { get; set; }
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Danh sách hình")]
        public List<string> DanhSachHinh { get; set; }
        [Display(Name = "Danh sách tập tin")]
        public List<string> DanhSachTapTin { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Nhóm kỹ thuật nuôi trồng")]
        public string IdNhomKyThuatNuoiTrong { get; set; }
        [Display(Name = "Hình đại diện")]
        public string HinhDaiDien { get; set; }
        [Display(Name = "Thông báo cho thiết bị di động")]
        public int DoUuTien { get; set; }
        [Display(Name = "Kích hoạt")]
        public int TrangThai { get; set; }
        [Display(Name = "Hiển thị nội dung")]
        public int HienThiNoiDung { get; set; }
        public string NgayTao { get; set; }
        public string IdNguoiTao { get; set; }
        public string IdNguoiCapNhat { get; set; }
        public string TenNguoiTao { get; set; }
        public string TenNguoiCapNhat { get; set; }
        public KyThuatNuoiTrongOutput()
        {
            DanhSachHinh = new List<string>();
            DanhSachTapTin = new List<string>();
        }
    }
    #endregion
    #region Nhóm kỹ thuật nuôi trồng
    public class NhomKyThuatNuoiTrongOutput : ChungThuc
    {
        public string Id { get; set; }
        [Display(Name = "Tên")]
        public string Ten { get; set; }
        [Display(Name = "Icon")]
        public string Icon { get; set; }
        [Display(Name = "Mã")]
        public string Ma { get; set; }
        [Display(Name = "Vị trí")]
        public int ViTri { get; set; }
        [Display(Name = "Kích hoạt")]
        public int KichHoat { get; set; }
    }
    #endregion
    #region Bản tin truyền hình
    public class BanTinTruyenHinhOutput : ChungThuc
    {
        public string Id { get; set; }
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Đường dẫn")]
        public string DuongDan { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Nhóm bản tin")]
        public string IdNhomBanTinTruyenHinh { get; set; }
        [Display(Name = "Hình đại diện")]
        public string HinhDaiDien { get; set; }
        [Display(Name = "Đường dẫn video")]
        public string Video { get; set; }
        [Display(Name = "Độ ưu tiên")]
        public int DoUuTien { get; set; }
        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }
        public string NgayTao { get; set; }
        public string IdNguoiTao { get; set; }
        public string IdNguoiCapNhat { get; set; }
        public string TenNguoiTao { get; set; }
        public string TenNguoiCapNhat { get; set; }
    }

    #endregion
    #region Nhóm bản tin truyền hình
    public class NhomBanTinTruyenHinhOutput : ChungThuc
    {
        public string Id { get; set; }
        [Display(Name = "Tên")]
        public string Ten { get; set; }
        [Display(Name = "Icon")]
        public string Icon { get; set; }
        [Display(Name = "Mã")]
        public string Ma { get; set; }
        [Display(Name = "Vị trí")]
        public int ViTri { get; set; }
        [Display(Name = "Kích hoạt")]
        public int KichHoat { get; set; }
    }

    #endregion

    #endregion

    #region Năm, quý, tháng, tuần
    public class NamQuyThangTuanOutput
    {
        public class Nam
        {
            public string Id { get; set; }
            public string Ten { get; set; }
        }

        public class Thang
        {
            public string Id { get; set; }
            public string Ten { get; set; }
        }

        public class Tuan
        {
            public string Id { get; set; }
            public string Ten { get; set; }
        }
    }
    #endregion

    #region Hộ nuôi
    public class HoNuoiOutput
    {
        public class ThongTinHoNuoi
        {
            public string Id { get; set; }
            [Display(Name = "Họ")]
            public string Ho { get; set; }
            [Display(Name = "Tên")]
            public string Ten { get; set; }
            [Display(Name = "Ngày sinh")]
            public string NgaySinh { get; set; }
            [Display(Name = "Địa chỉ")]
            public string DiaChi { get; set; }
            [Display(Name = "Điện thoại")]
            public string DienThoai { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }
            [Display(Name = "Huyện")]
            public string TenHuyen { get; set; }
            [Display(Name = "Xã")]
            public string TenXa { get; set; }
            [Display(Name = "Ấp")]
            public string TenAp { get; set; }
            [Display(Name = "Tổng số ao")]
            public double TongSoAo { get; set; }
            [Display(Name = "Tổng diện tích")]
            public double TongDienTich { get; set; }
            [Display(Name = "Là tổ chức")]
            public int LaToChuc { get; set; }
            public string IdLoaiHinhKinhTe { get; set; }//Thêm 22/08/2018
            [Display(Name = "Loại hình kinh tế")]
            public string TenLoaiHinhKinhTe { get; set; }//Thêm 22/08/2018
            public List<string> DanhSachIdHinhThucNuoi { get; set; }
            public List<ThongTinAoTheoHoNuoi> DanhSachAo { get; set; }
            public List<HinhThucNuoi> DanhSachHinhThucNuoi { get; set; }
            public class HinhThucNuoi
            {
                public string Id { get; set; }
                public string Ten { get; set; }
            }
            public ThongTinHoNuoi()
            {
                DanhSachHinhThucNuoi = new List<HinhThucNuoi>();
                DanhSachAo = new List<ThongTinAoTheoHoNuoi>();
            }
        }
        public class ThongTinAoTheoHoNuoi : AoTheoHoNuoi
        {
            public string TenHinhThucNuoi { get; set; }
            public string TenTinhTrang { get; set; }
            public string IdLoaiHinhKinhTe { get; set; }

            public string TenLoaiHinhKinhTe { get; set; }
        }
        public class AoTheoHoNuoi
        {
            public string Id { get; set; }
            public string IdHinhThucNuoi { get; set; }

            public string IdTinhTrang { get; set; }
            public double DienTich { get; set; }
            public string IdHoNuoi { get; set; }
            public SoLuongDienTich AoUong { get; set; }
            public SoLuongDienTich AoNuoi { get; set; }
            public SoLuongDienTich AoLangTho { get; set; }
            public SoLuongDienTich AoLangXuLy { get; set; }
            public SoLuongDienTich AoSanSang { get; set; }
            public SoLuongDienTich AoXuLyThai { get; set; }
            public SoLuongDienTich AoChuaBunThai { get; set; }

            public int DatTieuChuanMoiTruong { get; set; }
            public int DatTieuChuanDien { get; set; }
            public int DatTieuChuanDichBenh { get; set; }
            public int QuyHoach { get; set; }
            public int Khac { get; set; }
            public int DuDieuKien { get; set; }
            public string GhiChu { get; set; }
            public AoTheoHoNuoi()
            {
                AoUong = new SoLuongDienTich();
                AoNuoi = new SoLuongDienTich();
                AoLangTho = new SoLuongDienTich();
                AoLangXuLy = new SoLuongDienTich();
                AoSanSang = new SoLuongDienTich();
                AoXuLyThai = new SoLuongDienTich();
                AoChuaBunThai = new SoLuongDienTich();
            }
        }
        public class SoLuongDienTich
        {
            public double SoAo { get; set; }
            public double DienTich { get; set; }

        }
        public class DocThongTin : ThongTinHoNuoi { }
        public class DocDanhSach : ThongTinHoNuoi { }
        public class DocDanhSachTheoXa : ThongTinHoNuoi { }
        public class DanhSachHoNuoi : DuLieuOutputModel { }
        public class DocDanhSachPhanTrang
        {
            public int TongSoTrang { get; set; }
            public List<ThongTinHoNuoi> DanhSachHoNuoi { get; set; }
            public DocDanhSachPhanTrang()
            {
                DanhSachHoNuoi = new List<ThongTinHoNuoi>();
            }
        }

        public class DocDanhSachTheoXaPhanTrang
        {
            public int TongSoTrang { get; set; }
            public List<ThongTinHoNuoi> DanhSachHoNuoi { get; set; }
            public DocDanhSachTheoXaPhanTrang()
            {
                DanhSachHoNuoi = new List<ThongTinHoNuoi>();
            }
        }

        //Dùng cho doc danh sach ho nuoi co dieu kien
        public class DanhSachHoNuoiCoDieuKien
        {
            public List<ThongTinHoNuoi2> DanhSachThongTinHoNuoi { get; set; }
        }
        public class ThongTinHoNuoi2
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string DiaChi { get; set; }
            public string Sdt { get; set; }
            public List<ThongTinAoNuoi> DanhSachThongTinAoNuoi { get; set; }
        }

        public class ThongTinAoNuoi
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public double DienTich { get; set; }
            public List<ThongTinThaGiong> DanhSachThongTinThaGiong { get; set; }
            public List<ThongTinThuHoach> DanhSachThongTinThuHoach { get; set; }
            public List<ThongTinDichBenh> DanhSachThongTinDichBenh { get; set; }
        }
        public class ThongTinThaGiong
        {
            public string Id { get; set; }
            public int LanTha { get; set; }
            public string IdAo { get; set; }
            public double DienTich { get; set; }
            public double LuyKe { get; set; }
            public string IdSanPham { get; set; }
            public string TenSanPham { get; set; }
            public double NgayTha { get; set; }
            public string ChuoiNgayTha { get; set; }
            public double MatDo { get; set; }
            public string IdTinh { get; set; }
            public string TenTinh { get; set; }
            public string GhiChu { get; set; }
            public int TrangThai { get; set; }//
        }
        public class ThongTinThuHoach
        {
            public string Id { get; set; }
            public int LanThu { get; set; }
            public string IdAo { get; set; }
            public double DienTich { get; set; }
            public double LuyKe { get; set; }
            public double SanLuong { get; set; }
            public double NgayThuHoach { get; set; }
            public string ChuoiNgayThuHoach { get; set; }
            public int TrangThai { get; set; }//
        }
        public class ThongTinDichBenh
        {
            public string Id { get; set; }
            public string IdAo { get; set; }
            public string IdAp { get; set; }
            public string TenAp { get; set; }
            public string IdXa { get; set; }
            public string IdHuyen { get; set; }
            public string IdTinh { get; set; }
            public string IdDichBenh { get; set; }
            public string TenDichBenh { get; set; }
            public string IdThaGiong { get; set; }
            public double DienTichThietHai { get; set; }
            public double LuyKe { get; set; }
            public double NgayPhatHien { get; set; }
            public string ChuoiNgayPhatHien { get; set; }
            public int TrangThai { get; set; }
            public string GhiChu { get; set; }
        }
    }
    #region Loai hình kinh tế
    public class LoaiHinhKinhTeOutput
    {
        public class ThongTin
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string Ma { get; set; }
        }
    }
    #endregion
    #endregion
    #region Ao
    public class AoOutput
    {
        public class DanhSachQuanLyHoNuoiVaBaoCao
        {
            public DocDanhSach DanhSachHoNuoi { get; set; }
            public List<AoTheoHoNuoiCacCap> DanhSachBaoCao { get; set; }
            public int Loai { get; set; }
            public DanhSachQuanLyHoNuoiVaBaoCao()
            {
                DanhSachHoNuoi = new DocDanhSach();
                DanhSachBaoCao = new List<AoTheoHoNuoiCacCap>();
            }
        }
        public class DocDanhSachCacCap
        {
            public List<AoTheoHoNuoiCacCap> DanhSachAo { get; set; }
            public DocDanhSachCacCap()
            {
                DanhSachAo = new List<AoTheoHoNuoiCacCap>();
            }
        }
        public class AoTheoHoNuoiCacCap
        {
            public string Id { get; set; }
            public string IdDonVi { get; set; }
            public string TenDonVi { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }
            public double TongSoHo { get; set; }
            public double TongDienTich { get; set; }
            public double TongSoAo { get; set; }
            public double LuyKeTongSoHo { get; set; }
            public double LuyKeTongDienTich { get; set; }
            public double LuyKeTongSoAo { get; set; }

            public SoLuongDienTich AoUong { get; set; }
            public SoLuongDienTich AoNuoi { get; set; }
            public SoLuongDienTich AoLangTho { get; set; }
            public SoLuongDienTich AoLangXuLy { get; set; }
            public SoLuongDienTich AoSanSang { get; set; }
            public SoLuongDienTich AoXuLyThai { get; set; }
            public SoLuongDienTich AoChuaBunThai { get; set; }

            public int LoaiBaoCao { get; set; }
            public bool XuatBan { get; set; }
            public double NgayLapBaoCao { get; set; }
            public string GhiChu { get; set; }
            public string IdHinhThucNuoi { get; set; }
            public int TrangThai { get; set; }
            public string NoiDungPheDuyet { get; set; }
            public int LoaiDonViBaoCao { get; set; }
            public string IdNguoiPheDuyet { get; set; }
            public AoTheoHoNuoiCacCap()
            {
                AoUong = new SoLuongDienTich();
                AoNuoi = new SoLuongDienTich();
                AoLangTho = new SoLuongDienTich();
                AoLangXuLy = new SoLuongDienTich();
                AoSanSang = new SoLuongDienTich();
                AoXuLyThai = new SoLuongDienTich();
                AoChuaBunThai = new SoLuongDienTich();
            }
            public class ThongTinSoHoDienTich
            {
                public int SoHo { get; set; }
                public double DienTich { get; set; }
            }
            public class ThongTinDonVi
            {
                public string Id { get; set; }
                public string Ten { get; set; }
            }
        }

        public class DocDanhSach
        {
            public List<AoTheoHoNuoi> DanhSachAo { get; set; }
            public List<ThongTinTinhTrang> DanhSachTinhTrangAo { get; set; }
            public DocDanhSach()
            {
                DanhSachAo = new List<AoTheoHoNuoi>();
                DanhSachTinhTrangAo = new List<ThongTinTinhTrang>();
            }
        }
        public class AoTheoHoNuoi
        {
            public string Id { get; set; }
            public ThongTinHinhThucNuoi HinhThucNuoi { get; set; }
            public double DienTich { get; set; }
            public ThongTinTinhTrang TinhTrang { get; set; }
            public ThongTinHoNuoi HoNuoi { get; set; }
            public SoLuongDienTich AoUong { get; set; }
            public SoLuongDienTich AoNuoi { get; set; }
            public SoLuongDienTich AoLangTho { get; set; }
            public SoLuongDienTich AoLangXuLy { get; set; }
            public SoLuongDienTich AoSanSang { get; set; }
            public SoLuongDienTich AoXuLyThai { get; set; }
            public SoLuongDienTich AoChuaBunThai { get; set; }

            public int DatTieuChuanMoiTruong { get; set; }
            public int DatTieuChuanDien { get; set; }
            public int DatTieuChuanDichBenh { get; set; }
            public int QuyHoach { get; set; }
            public int Khac { get; set; }
            public int DuDieuKien { get; set; }
            public string GhiChu { get; set; }
            public AoTheoHoNuoi()
            {
                HinhThucNuoi = new ThongTinHinhThucNuoi();
                HoNuoi = new ThongTinHoNuoi();
                AoUong = new SoLuongDienTich();
                AoNuoi = new SoLuongDienTich();
                AoLangTho = new SoLuongDienTich();
                AoLangXuLy = new SoLuongDienTich();
                AoSanSang = new SoLuongDienTich();
                AoXuLyThai = new SoLuongDienTich();
                AoChuaBunThai = new SoLuongDienTich();
            }
        }

        public class ThongTinHoNuoi
        {
            public string Id { get; set; }
            public string HoTen { get; set; }
            public string Ho { get; set; }
            public string Ten { get; set; }
            public string NamSinh { get; set; }
            public string DiaChi { get; set; }
            public string DienThoai { get; set; }
            public string TenXa { get; set; }
            public string TenAp { get; set; }

        }
        public class SoLuongDienTich
        {
            public double SoAo { get; set; }
            public double DienTich { get; set; }

        }
        public class OutputId
        {
            public string Id { get; set; }
        }

        public class ThongTinHinhThucNuoi
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string Ma { get; set; }
            public List<string> DanhSachIdBieuMauBaoCao { get; set; }
        }
        public class ThongTinTinhTrang
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string Ma { get; set; }
        }
        public class ThongTinAo
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public double DienTich { get; set; }
            public ThongTin HinhThucNuoi { get; set; }
            public ThongTin TinhTrang { get; set; }
        }
        public class ThongTin
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string Ma { get; set; }
        }
        public class ThongTinThaGiong
        {
            public string Id { get; set; }
            public int LanTha { get; set; }
            public string IdAo { get; set; }
            public double DienTich { get; set; }
            public double LuyKe { get; set; }
            public string IdSanPham { get; set; }
            public string TenSanPham { get; set; }
            public double NgayTha { get; set; }
            public string ChuoiNgayTha { get; set; }
            public double MatDo { get; set; }
            public string IdTinh { get; set; }
            /// <summary>
            /// TrangThai:
            ///     0: thả giống
            ///     1: đang thu hoạch
            ///     2: đã thu hoạch xong
            /// </summary>
            public int TrangThai { get; set; }
            public string GhiChu { get; set; }
        }
        public class ThongTinThuHoach
        {
            public string Id { get; set; }
            public int LanThu { get; set; }
            public double LuyKe { get; set; }
            public double DienTich { get; set; }
            public double SanLuong { get; set; }
            public double NgayThuHoach { get; set; }
            public double ChuoiNgayThuHoach { get; set; }
            public string IdAo { get; set; }
            /// <summary>
            /// TrangThai:
            ///     0: chua khac phuc
            ///     1: dang khac phuc
            ///     2: da khac phuc
            /// </summary>
            public int TrangThai { get; set; }
        }
        public class ThongTinDichBenh
        {
            public string Id { get; set; }
            public int LanBenh { get; set; }
            public double LuyKe { get; set; }
            public string IdThaGiong { get; set; }
            public string IdDichBenh { get; set; }
            public double DienTichThietHai { get; set; }
            public double NgayPhatHien { get; set; }
            public double ChuoiNgayPhatHien { get; set; }
            /// <summary>
            /// TrangThai:
            ///     0: chua khac phuc
            ///     1: dang khac phuc
            ///     2: da khac phuc
            /// </summary>
            public int TrangThai { get; set; }
            public string GhiChu { get; set; }
        }
        public class AoDocThongTinModel
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public double DienTich { get; set; }
            public string IdHinhThucNuoi { get; set; }
            public string IdTinhTrang { get; set; }
            public List<HoNuoiOutput.ThongTinThaGiong> DanhSachThongTinThaGiong { get; set; }
            public List<HoNuoiOutput.ThongTinThuHoach> DanhSachThongTinThuHoach { get; set; }
            public List<HoNuoiOutput.ThongTinDichBenh> DanhSachThongTinDichBenh { get; set; }
        }
    }
    #endregion

    #region Danh sách giá cả thị trường trong tỉnh
    public class DanhSachGiaCaThiTruongTrongTinhOutput
    {
        public string Id { get; set; }
        public string IdAp { get; set; }
        public string IdXa { get; set; }
        public string IdHuyen { get; set; }
        public string IdTinh { get; set; }
        public string IdNhomSanPham { get; set; }
        [Display(Name = "Tên nhóm sản phẩm")]
        public string TenNhomSanPham { get; set; }
        public string IdSanPham { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string TenSanPham { get; set; }
        public string IdDonViTinh { get; set; }
        [Display(Name = "Tên đơn vị tính")]
        public string TenDonViTinh { get; set; }
        public string IdQuyCach { get; set; }
        [Display(Name = "Tên quy cách")]
        public string TenQuyCach { get; set; }

        [Display(Name = "Giá thu mua từ")]
        public float GiaThuMuaTu { get; set; }
        [Display(Name = "Giá thu mua đến")]
        public float GiaThuMuaDen { get; set; }
        [Display(Name = "Giá bán lẻ từ")]
        public float GiaBanLeTu { get; set; }
        [Display(Name = "Giá bán lẻ đến")]
        public float GiaBanLeDen { get; set; }

        public double Ngay { get; set; }
        [Display(Name = "Ngày báo cáo")]
        public string ChuoiNgay { get; set; }
    }



    public class GiaCaThiTruongTrongTinhOutput
    {
        public string Id { get; set; }
        public string IdAp { get; set; }
        public string IdXa { get; set; }
        public string IdHuyen { get; set; }
        public string IdTinh { get; set; }


        public string IdNhomSanPham { get; set; }
        public string TenNhomSanPham { get; set; }
        public string IdSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string IdDonViTinh { get; set; }
        public string TenDonViTinh { get; set; }
        public string IdQuyCach { get; set; }
        public string TenQuyCach { get; set; }

        public float GiaThuMuaTu { get; set; }
        public float GiaThuMuaDen { get; set; }
        public float GiaBanLeTu { get; set; }
        public float GiaBanLeDen { get; set; }

        public double Ngay { get; set; }
        public string ChuoiNgay { get; set; }
    }
    #endregion

    #region Sản phẩm
    public class SanPhamOutput
    {
        public class ThongTinSanPham
        {
            public string Id { get; set; }
            public string Ma { get; set; }
            public string Ten { get; set; }
            public string NguonGoc { get; set; }
            public List<ThongTin> DanhSachThongTinSanPham { get; set; }
            public class ThongTin
            {
                public string IdQuyCach { get; set; }
                public string TenQuyCach { get; set; }
                public string IdDonViTinh { get; set; }
                public string TenDonViTinh { get; set; }
                public string IdNgayTuoi { get; set; }
                public string IdCapGiong { get; set; }
                public string IdChieuCao { get; set; }
                public string IdCoBau { get; set; }
                public string TenNgayTuoi { get; set; }
                public string IdKichCo { get; set; }
            }
            public string IdNhomSanPham { get; set; }
            public string TenNhomSanPham { get; set; }
            public string MoTa { get; set; }
            public string DacTinh { get; set; }
            public bool KichHoat { get; set; }
            public int ViTri { get; set; }
            public string IdKyThuatNuoiTrong { get; set; }
        }
        public class Them : ThongTinSanPham { }
        public class Sua : ThongTinSanPham { }
        public class DocDanhSachTheoIdNhomSanPham : ThongTinSanPham { }
        public class DanhSachSanPhamTheoNhom
        {
            public string IdNhomSanPham { get; set; }
            public string TenNhomSanPham { get; set; }
            public List<SanPhamOutput.DocDanhSachTheoIdNhomSanPham> DanhSachSanPham { get; set; }
            public DanhSachSanPhamTheoNhom()
            {
                DanhSachSanPham = new List<SanPhamOutput.DocDanhSachTheoIdNhomSanPham>();
            }
        }
        //public class ThongTinSanPhamCoQuyCach: ThongTinSanPham
        //{

        //}
    }
    #endregion
    #region Nhóm sản phẩm
    public class NhomSanPhamOutput
    {
        public class ThongTinNhomSanPham
        {
            public string Id { get; set; }
            public string Ma { get; set; }
            public string Ten { get; set; }
            public string Icon { get; set; }
            public string ViTri { get; set; }
            public List<string> DanhSachMaChucNang { get; set; }
            public List<string> DanhSachIdChucNang { get; set; }
            public List<string> DanhSachIdBieuMau { get; set; }
            public List<string> DanhSachIdDonVi { get; set; }
        }
        public class DocDanhSach : ThongTinNhomSanPham { }
    }
    public class DaysWeek
    {
        public class InfoDaysweek
        {
            public string time { get; set; }
            public string strtime { get; set; }
        }
        public class ReadList : InfoDaysweek { }
    }
    #endregion

    #region Thông tin dịch bệnh Thú Y
    public class ThongTinDichBenhThuYOutput
    {
        public class DocDanhSach
        {
            public string Id { get; set; }
            public double ThoiGianBatDau { get; set; }
            public double ThoiGianKetThuc { get; set; }
            public string IdChanNuoiThuY { get; set; }
            public string IdLoaiDichBenhThuY { get; set; }
            public string TenLoaiDichBenhThuY { get; set; }
            public string IdSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string IdTinh { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }
            public long TongSoLuongBenh { get; set; }
            public long TongSoLuongChet { get; set; }
            public string GhiChu { get; set; }
            public string NgayTao { get; set; }
            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
            public long TongSoLuongBenhLuyKeDauNam { get; set; }
            public long TongSoLuongChetLuyKeDauNam { get; set; }
            public string MaBieuMauBaoCaoChanNuoiThuY { get; set; }
            public string TenBieuMauBaoCaoChanNuoiThuY { get; set; }
            public string LoaiBieuMauBaoCaoChanNuoiThuY { get; set; }
        }

        public class DocDanhSachBieuMauBaoCaoChanNuoiThuY
        {

            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
            public string MaBieuMauBaoCaoChanNuoiThuY { get; set; }
            public string TenBieuMauBaoCaoChanNuoiThuY { get; set; }
            public string LoaiBieuMauBaoCaoChanNuoiThuY { get; set; }
            public List<DocDanhSach> DanhSachSoLieuBaoCao { get; set; }
        }
    }
    #endregion

    #region Dịch bệnh thủy sản
    public class DichBenhThuySanOutput
    {
        public class ThongTinDichBenhThuySan
        {
            public string Id { get; set; }
            public string Ma { get; set; }
            public string Ten { get; set; }
            public string HuongKhacPhuc { get; set; }
            public string GhiChu { get; set; }
        }
    }
    #endregion

    #region Quy cách
    public class QuyCachOutput
    {
        public class DocThongTin
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public List<string> DanhSachMaChucNang { get; set; }
            public string ChuoiDanhSachTenChucNang { get; set; }
        }
        public class DocDanhSach : DocThongTin { }
    }
    #endregion

    #region Nhóm sản phẩm
    public class NhomSanPham
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public string Icon { get; set; }
        public string Ma { get; set; }
        public int ViTri { get; set; }
    }
    #endregion
    #region sản phẩm
    public class SanPham
    {
        public string Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string IdDonViTinh { get; set; }
        public string IdQuyCach { get; set; }
        public string IdNhomSanPham { get; set; }
    }
    #endregion
    #region Định nghĩa thông báo khẩn
    public class DinhNghiaThongBaoKhanOutput
    {
        public ThongBaoKhanOutput ChiTietThongBaoKhan;
        public List<ThongBaoKhanOutput> DanhSachThongBaoKhan;
    }
    #endregion
    #region Định nghĩa thời tiết nông vụ
    public class DinhNghiaThoiTietNongVuOutput
    {
        public ThoiTietNongVuOutput ChiTietThoiTietNongVu;
        public List<ThoiTietNongVuOutput> DanhSachThoiTietNongVu;
    }
    #endregion
    //#region Định nghĩa chỉ đạo điều hành
    //public class DinhNghiaChiDaoDieuHanhOutput
    //{
    //    public ChiDaoDieuHanhOutput ChiTietChiDaoDieuHanh;
    //    public List<ChiDaoDieuHanhInput> DanhSachChiDaoDieuHanh;
    //}
    //#endregion
    #region Định nghĩa kỹ thuật nuôi trồng
    public class DinhNghiaKyThuatNuoiTrongOutput
    {
        public List<KyThuatNuoiTrongOutput> DanhSachKyThuatNuoiTrong;
        public List<NhomKyThuatNuoiTrongOutput> DanhSachNhomKTNT;
    }
    public class DinhNghiaChiTietKyThuatNuoiTrongOutput
    {
        public KyThuatNuoiTrongOutput ChiTietKyThuatNuoiTrong;
        public List<KyThuatNuoiTrongOutput> DanhSachKyThuatNuoiTrong;
        public DinhNghiaChiTietKyThuatNuoiTrongOutput()
        {
            ChiTietKyThuatNuoiTrong = new KyThuatNuoiTrongOutput();
            DanhSachKyThuatNuoiTrong = new List<KyThuatNuoiTrongOutput>();
        }
    }
    #endregion
    #region
    //Tấn - 27/3/2018 - Giá trong tỉnh 
    public class GiaTrongTinhOutput
    {
        public class DocThongTin
        {

            public string Id { get; set; }
            public string ChuoiThang { get; set; }
            public string ChuoiNgay { get; set; }
            public string IdNhomSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string TenQuyCach { get; set; }
            public string TenDonViTinh { get; set; }
            [DisplayFormat(DataFormatString = "{0:P2}")]
            public decimal GiaThuMuaTu { get; set; }
            [DisplayFormat(DataFormatString = "{0:P2}")]
            public decimal GiaThuMuaDen { get; set; }
            [DisplayFormat(DataFormatString = "{0:P2}")]
            public decimal GiaBanLeTu { get; set; }
            [DisplayFormat(DataFormatString = "{0:P2}")]
            public decimal GiaBanLeDen { get; set; }
            public string IdQuyCach { get; set; }
            public string IdDonViTinh { get; set; }
            public string IdSanPham { get; set; }
            public bool TuanHienTai { get; set; }
        }

        public class DocDanhSach : DocThongTin { }
        public class Authentication : ChungThuc { }
        public class ReadPriceSplitPage
        {
            // public int TotalPage { get; set; }
            public List<GiaTrongTinhOutput.DocThongTin> ListPrice { get; set; }
            public ReadPriceSplitPage()
            {
                ListPrice = new List<GiaTrongTinhOutput.DocThongTin>();
            }
        }

    }
    #endregion
    #region Giá tỉnh lân cận
    public class GiaTinhLanCanOutput
    {
        public string IdAp { get; set; }
        public string IdXa { get; set; }
        public string IdHuyen { get; set; }
        public string IdTinh { get; set; }


        public string IdNhomSanPham { get; set; }
        public string TenNhomSanPham { get; set; }
        public string IdSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string IdDonViTinh { get; set; }
        public string TenDonViTinh { get; set; }
        public string IdQuyCach { get; set; }
        public string TenQuyCach { get; set; }

        public float GiaThuMuaTu { get; set; }
        public float GiaThuMuaDen { get; set; }
        public float GiaBanLeTu { get; set; }
        public float GiaBanLeDen { get; set; }

        public double Ngay { get; set; }
        public string ChuoiNgay { get; set; }
        public string Id { get; set; }
    }
    #endregion
    #region giá hiệp hội
    public class GiaHiepHoiOutput
    {
        public string IdHiepHoi { get; set; }


        public string IdNhomSanPham { get; set; }
        public string TenNhomSanPham { get; set; }
        public string IdSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string IdDonViTinh { get; set; }
        public string TenDonViTinh { get; set; }
        public string IdQuyCach { get; set; }
        public string TenQuyCach { get; set; }

        public float GiaThuMuaTu { get; set; }
        public float GiaThuMuaDen { get; set; }
        public float GiaBanLeTu { get; set; }
        public float GiaBanLeDen { get; set; }

        public double Ngay { get; set; }
        public string ChuoiNgay { get; set; }
        public string Id { get; set; }
    }
    #endregion
    #region Phản ánh nhanh
    public class PhanAnhNhanhOutput
    {
        public class ThongTinPhanAnh
        {
            public string Id { get; set; }
            public string TieuDe { get; set; }
            public string TenNguoiPheDuyet { get; set; }
            public string NoiDung { get; set; }
            public string Sdt { get; set; }
            public string TenNguoiPhanAnh { get; set; }
            public LoaiPhanAnh LoaiPhanAnhNguoiDan { get; set; }
            public string DiaChi { get; set; }
            public string ThoiGian { get; set; }
            public string ToaDo { get; set; }
            public string IdAp { get; set; }
            public string IdXa { get; set; }
            public bool XuatBan { get; set; }
            public string IdHuyen { get; set; }
            public int TrangThai { get; set; }
            public string DuongDanHinhAnh { get; set; }
            public PhanHoi ThongTinPhanHoi { get; set; }
            public class PhanHoi
            {
                public string NoiDung { get; set; }
                public List<TapTin> DanhSachTapTin { get; set; }
                public class TapTin
                {
                    public string Ten { get; set; }
                }
                public PhanHoi()
                {
                    DanhSachTapTin = new List<TapTin>();
                }
            }
            public List<TapTin> DanhSachTapTin { get; set; }
            public string TenHuyen { get; set; }
            public string TenXa { get; set; }
            public string TenAp { get; set; }

            public ThongTinPhanAnh()
            {
                DanhSachTapTin = new List<TapTin>();
                LoaiPhanAnhNguoiDan = new LoaiPhanAnh();
                DuongDanHinhAnh = ConfigurationManager.AppSettings["PhanAnhNhanhImageUrl"];
            }

            public class LoaiPhanAnh
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
            }

            public class TapTin
            {
                public string Ten { get; set; }
                public string LoaiTapTin { get; set; }
                public string TenThumbnail { get; set; }
            }
        }
        public class DocDanhSach : ThongTinPhanAnh { }
        public class DocDanhSachKT
        {
            public List<ThongTinPhanAnh> DanhSach { get; set; }
            public int TongSoDong { get; set; }
        }
        public class DocDanhSach2
        {
            public int TrangHienTai { get; set; }
            public int TongSoDong { get; set; }
            public int TongSoTrang { get; set; }
            public List<ThongTinPhanAnh> DanhSach { get; set; }
        }
    }
    #endregion
    #region Định nghĩa phản ánh nhanh
    public class DinhNghiaPhanAnhNhanhOutput
    {
        public PhanAnhNhanhOutput.ThongTinPhanAnh ChiTietPhanAnhNhanh;
        public List<PhanAnhNhanhOutput.ThongTinPhanAnh> DanhSachPhanAnhNhanh;
    }
    #endregion
    #region Loại phản ánh
    public class LoaiPhanAnhOutput
    {
        public class DocDanhSachOutput
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public List<string> DanhSachIdDonVi { get; set; }
        }
    }
    #endregion
    #region Thông tin phản hồi
    public class DocThongTinPhanHoi
    {
        public string Id { get; set; }
        public string NoiDung { get; set; }
        public List<TapTin> DanhSachTapTin { get; set; }
        public class TapTin
        {
            public string Ten { get; set; }
        }
        public DocThongTinPhanHoi()
        {
            DanhSachTapTin = new List<TapTin>();
        }
    }
    #endregion

    #region Sản xuất trồng trọt
    public class BieuMauBaoCaoSanXuatTrongTrotOutput
    {
        public class DocDanhSachOutput
        {
            public string Id { get; set; }
            public string Loai { get; set; }
            public string Ma { get; set; }
            public string Ten { get; set; }
            public string IdLoaiSauBenh { get; set; }
            public string MaLoaiSauBenh { get; set; }
            public string IdBieuMauInAn { get; set; }
        }
    }
    public class SanXuatTrongTrotOutput
    {
        public class ThongTinDocDanhSachTienDoSanXuatCoPheDuyet
        {
            public bool XuatBan { get; set; }
            public bool XuatBanCapTinh { get; set; }
            public string TenNguoiPheDuyet { get; set; }
            public int TrangThai { get; set; }
            public string NoiDungPheDuyet { get; set; }
            public List<ThongTinDocDanhSachTienDoSanXuat> DuLieu { get; set; }
        }

        public class ThongTinDocDanhSachTienDoSanXuat
        {
            public string IdBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public string MaBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public string TenBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public string LoaiBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public List<TienDoXuongSanXuat2> DanhSachSoLieuBaoCao { get; set; }
            public ThongTinDocDanhSachTienDoSanXuat()
            {
                DanhSachSoLieuBaoCao = new List<TienDoXuongSanXuat2>();
            }
        }
        public class TienDoXuongSanXuat
        {
            public string Id { get; set; }
            public string IdBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public double XuongGiong { get; set; }
            public double Ma { get; set; }
            public double DeNhanh { get; set; }
            public double DungCaiLamDong { get; set; }
            public double LamDongTro { get; set; }
            public double Chin { get; set; }

            public double LuyKeXuongGiong { get; set; }
            public double LuyKeDeNhanh { get; set; }
            public double LuyKeDungCaiLamDong { get; set; }
            public double LuyKeLamDongTro { get; set; }
            public double LuyKeChin { get; set; }
            public double LuyKeThuHoach { get; set; }

            public double ThuHoach { get; set; }
            public double KeHoach { get; set; }

            public double XuongGiongTrongTuan { get; set; }
            public double ThuHoachTrongTuan { get; set; }

            public string IdHuyen { get; set; }
            public string TenHuyen { get; set; }

            public string IdXa { get; set; }
            public string TenXa { get; set; }

            public string IdAp { get; set; }
            public string TenAp { get; set; }

            public string IdSanPham { get; set; }
            public string TenSanPham { get; set; }

            public string IdTienDoSanXuat { get; set; }
            public string MaBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public string TenBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public string LoaiBieuMauBaoCaoSanXuatTrongTrot { get; set; }

            public string NgayTao { get; set; }
            public double ThoiGianBatDau { get; set; }
            public double ThoiGianKetThuc { get; set; }
        }
        public class TienDoXuongSanXuat2 : TienDoXuongSanXuat
        {
            public string IdDonVi { get; set; }
            public string TenDonVi { get; set; }
            public int LoaiDonViBaoCao { get; set; }
            public bool XuatBan { get; set; }
        }
        //==================
        public class TinhHinhSauBenh
        {
            public string Id { get; set; }
            public string IdBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public ThongTin ThongTinDienTichNhiem { get; set; }
            public ThongTin ThongTinDaTru { get; set; }
            public List<DanhSachMatDoTiLeTheoGiaiDoan> DanhSachThongTinMatDoTiLeTheoGiaiDoan { get; set; }

            public double DienTich { get; set; }
            public double DienTichConLai { get; set; }
            public double DienTichLuyKe { get; set; }

            public string IdSauBenh { get; set; }
            public string TenSauBenh { get; set; }
            public List<ThongTinQuyCach> DanhSachQuyCach { get; set; }
            public List<string> DanhSachIdTuoiSauCapBenh { get; set; }
            public List<string> DanhSachTenTuoiSauCapBenh { get; set; }
            public string NoiPhanBo { get; set; }

            public string IdSanPham { get; set; }
            public string TenSanPham { get; set; }

            public string IdTinhHinhSauBenh { get; set; }
            public string MaBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public string TenBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public string LoaiBieuMauBaoCaoSanXuatTrongTrot { get; set; }

            public string NgayTao { get; set; }
            public double ThoiGianBatDau { get; set; }
            public double ThoiGianKetThuc { get; set; }
            public class ThongTinQuyCach
            {
                public string Id { get; set; }
                public string Ten { get; set; }
            }
            public TinhHinhSauBenh()
            {
                ThongTinDienTichNhiem = new ThongTin();
                ThongTinDaTru = new ThongTin();
                DanhSachThongTinMatDoTiLeTheoGiaiDoan = new List<DanhSachMatDoTiLeTheoGiaiDoan>();
            }
        }
        public class TinhHinhSauBenh2 : TinhHinhSauBenh
        {
            public string IdDonVi { get; set; }
            public string TenDonVi { get; set; }
            public int LoaiDonViBaoCao { get; set; }
            public bool XuatBan { get; set; }
        }
        public class ThongTinDocDanhSachTinhHinhSauBenhCoPheDuyet
        {
            public bool XuatBan { get; set; }
            public bool XuatBanCapTinh { get; set; }
            public string TenNguoiPheDuyet { get; set; }
            public int TrangThai { get; set; }
            public string NoiDungPheDuyet { get; set; }
            public List<ThongTinDocDanhSachTinhHinhSauBenh> DuLieu { get; set; }
        }

        public class ThongTinDocDanhSachTinhHinhSauBenh
        {
            public string IdBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public string MaBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public string TenBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public string LoaiBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public List<TinhHinhSauBenh2> DanhSachSoLieuBaoCao { get; set; }
            public ThongTinDocDanhSachTinhHinhSauBenh()
            {
                DanhSachSoLieuBaoCao = new List<TinhHinhSauBenh2>();
            }
        }

        //===========================
        public class ThongTin
        {
            public double Tong { get; set; }
            public double Nhe { get; set; }
            public double Tb { get; set; }
            public double Nang { get; set; }
        }
        public class DanhSachMatDoTiLeTheoGiaiDoan
        {
            public int LoaiGiaiDoanSinhTruong { get; set; }
            public List<string> DanhSachIdGiaiDoanSinhTruong { get; set; }
            public double PhoBien { get; set; }
            public double Cao { get; set; }
            public string IdQuyCach { get; set; }
            public string TenQuyCach { get; set; }
            public List<GiaiDoanSinhTruong> DanhSachGiaiDoanSinhTruong { get; set; }
        }
        public class GiaiDoanSinhTruong
        {
            public string Id { get; set; }
            public string Ten { get; set; }
        }
        public class DuLieuThongTinModel
        {
            public List<ThongTinSanXuatTrongTrot> DuLieu { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPage { get; set; }
            public int KetQua { get; set; }
            public string GhiChu { get; set; }
        }
        public class ThongTinSanXuatTrongTrot
        {
            public string LoaiDoiTuong { get; set; }
            public string Id { get; set; }
            public string TieuDe { get; set; }
            public string NoiDungTomTat { get; set; }
            public string NoiDung { get; set; }
            public string HinhDaiDien { get; set; }
            public bool DoUuTien { get; set; }
            public bool TrangThai { get; set; }
            public string NgayTao { get; set; }
            public string DuongDanThanThien { get; set; }
            //public string IdNhomThongTin { get; set; }
            public int LoaiBaoCao { get; set; }
            public double ThoiGian { get; set; }
            public string TenNguoiCapNhat { get; set; }
        }
        public class PhanLoaiBaoCao
        {
            public DuLieuThongTinModel DuLieuTuan { get; set; }
            public List<ThongTinSanXuatTrongTrot> DanhSachDuLieuThang { get; set; }
            public List<ThongTinSanXuatTrongTrot> DanhSachDuLieuQuy { get; set; }
            public List<ThongTinSanXuatTrongTrot> DanhSachDuLieuSauThang { get; set; }
            public List<ThongTinSanXuatTrongTrot> DanhSachDuLieuNam { get; set; }
            public PhanLoaiBaoCao()
            {
                DuLieuTuan = new DuLieuThongTinModel();
                DanhSachDuLieuThang = new List<ThongTinSanXuatTrongTrot>();
                DanhSachDuLieuQuy = new List<ThongTinSanXuatTrongTrot>();
                DanhSachDuLieuSauThang = new List<ThongTinSanXuatTrongTrot>();
                DanhSachDuLieuNam = new List<ThongTinSanXuatTrongTrot>();
            }
        }
        public class ChiTietSanXuatTrongTrotModel
        {
            public ThongTinSanXuatTrongTrot ThongTin { get; set; }
            public List<ThongTinSanXuatTrongTrot> DanhSach { get; set; }
            public string KetQua { get; set; }
            public ChiTietSanXuatTrongTrotModel()
            {
                DanhSach = new List<ThongTinSanXuatTrongTrot>();
            }
        }
        public class DanhSachHuyenCaMau : DuLieuOutputModel { }
        public class DanhSachCayTrongCaMau : DuLieuOutputModel { }
        public class DanhSachDichHaiCaMau : DuLieuOutputModel { }

        public class DocDanhMucTheoIdBieuMauBaoCao
        {
            public List<DanhMucDropDown> DanhSachSauBenh { get; set; }
            public List<DanhMucDropDown> DanhSachQuyCach { get; set; }
            public List<DanhMucDropDown> DanhSachTuoiCapSauBenh { get; set; }
            public List<DanhMucDropDown> DanhSachNhomCayTrong { get; set; }
            public List<DanhMucDropDown> DanhSachGiaiDoanSinhTruong { get; set; }

            public DocDanhMucTheoIdBieuMauBaoCao()
            {
                DanhSachSauBenh = new List<DanhMucDropDown>();
                DanhSachQuyCach = new List<DanhMucDropDown>();
                DanhSachTuoiCapSauBenh = new List<DanhMucDropDown>();
                DanhSachNhomCayTrong = new List<DanhMucDropDown>();
                DanhSachGiaiDoanSinhTruong = new List<DanhMucDropDown>();
            }
        }

    }
    #region Chức năng trong bảng sản phẩm
    public class ChucNangSanPhamOutput
    {
        public class ChucnangCoNhomOutput
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string IdNhomSanPham { get; set; }
            public string TenNhomSanPham { get; set; }
            public string MaNhomSanPham { get; set; }
            public bool KichHoat { get; set; }
        }
    }
    #endregion
    #endregion
    #region Dùng cho Danh mục Dropdown
    public class DanhMucDropDown
    {
        public string Id { get; set; }
        public string Ten { get; set; }
    }
    #endregion
    #region Dữ liệu nông nghiệp
    public class DuLieuNongNghiepOutput
    {
        #region Export danh sách thông tin hộ nuôi, ao
        public class DocDanhSachHoNuoiVaHeThongAo : ChungThuc
        {
            public List<ThongTinExportHoNuoiAo> DanhSachHoNuoi { get; set; }
            public DocDanhSachHoNuoiVaHeThongAo()
            {
                DanhSachHoNuoi = new List<ThongTinExportHoNuoiAo>();
            }
        }
        public class ThongTinExportHoNuoiAo
        {
            public string Ho { get; set; }
            public string Ten { get; set; }
            public string DiaChi { get; set; }
            public string DienThoai { get; set; }
            public string NgaySinh { get; set; }
            public string TenHuyen { get; set; }
            public string TenXa { get; set; }
            public string TenAp { get; set; }
            public int LaToChuc { get; set; }
            public List<AoInput.AoTheoHoNuoiImport> DanhSachAo { get; set; }
            public List<ThaGiongThuHoach> DanhSachThaGiongThuHoach { get; set; }
            public ThongTinExportHoNuoiAo()
            {
                DanhSachAo = new List<AoInput.AoTheoHoNuoiImport>();
                DanhSachThaGiongThuHoach = new List<ThaGiongThuHoach>();
            }
            public class ThaGiongThuHoach
            {
                public TongAoNuoi ThongTinTongAoNuoi { get; set; } //Thông tin này bên api tự tạo
                public TongThaGiong ThongTinTongThaGiong { get; set; }
                public TongThuHoach ThongTinTongThuHoach { get; set; }
                public int LoaiBaoCao { get; set; }
                public bool XuatBan { get; set; }
                public double NgayLapBaoCao { get; set; }
                public string GhiChu { get; set; }
                public string DiaChi { get; set; }
                public string TenHinhThucNuoi { get; set; }
                public ThaGiongThuHoach()
                {
                    ThongTinTongAoNuoi = new TongAoNuoi();
                    ThongTinTongThaGiong = new TongThaGiong();
                    ThongTinTongThuHoach = new TongThuHoach();
                }
                public class TongAoNuoi
                {
                    public float SoAo { get; set; }
                    public double DienTich { get; set; }
                }
                public class TongThaGiong
                {
                    public double DienTich { get; set; }
                    public double LuyKeDienTich { get; set; }
                    public string TenSanPham { get; set; }
                    public string TenNguonGoc { get; set; }
                    public string NgayTha { get; set; }
                    public double MatDo { get; set; }
                    public string ChuoiNgayTha { get; set; }

                }
                public class TongThuHoach
                {
                    public double DienTich { get; set; }
                    public double LuyKeDienTich { get; set; }
                    public string NgayThu { get; set; }
                    public double SanLuong { get; set; }
                    public string ChuoiNgayThu { get; set; }

                }
            }
        }
        #endregion
        public class DocDanhMuc
        {
            public List<DanhMucDropDown> DanhSachHinhThucNuoi { get; set; }
            public List<DanhMucDropDown> DanhSachLoaiThuySan { get; set; }
            public List<DanhMucDropDown> DanhSachTinhTrangAo { get; set; }
            public List<DanhMucDropDown> DanhSachNguonGoc { get; set; }
            public List<DanhMucDropDown> DanhSachLoaiHinhKinhTe { get; set; }
            public DocDanhMuc()
            {
                DanhSachHinhThucNuoi = new List<DanhMucDropDown>();
                DanhSachLoaiThuySan = new List<DanhMucDropDown>();
                DanhSachTinhTrangAo = new List<DanhMucDropDown>();
                DanhSachNguonGoc = new List<DanhMucDropDown>();
                DanhSachLoaiHinhKinhTe = new List<DanhMucDropDown>();
            }
        }
        public class DuLieuCacCapOutput
        {
            public class ThongTin
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public double TongDienTich { get; set; }
                public double SoHoThaNuoi { get; set; }
                public double SoHoCoDienTichBiBenh { get; set; }
                public double SoLuongConThaGiong { get; set; }
                public ThongTinTongThaGiong ThongTinTongThaGiong { get; set; }
                public ThongTinTongThuHoach ThongTinTongThuHoach { get; set; }
                public ThongTinTongDichBenh ThongTinTongDichBenh { get; set; }
                public List<ThongTinSanPham> DanhSachThongTinSanPham { get; set; }
                public ThongTin()
                {
                    ThongTinTongThaGiong = new ThongTinTongThaGiong();
                    ThongTinTongThuHoach = new ThongTinTongThuHoach();
                    ThongTinTongDichBenh = new ThongTinTongDichBenh();
                    DanhSachThongTinSanPham = new List<ThongTinSanPham>();
                }
            }
            public class DuLieuThongTin2
            {
                public int TrangThai { get; set; }
                public string NoiDungPheDuyet { get; set; }
                public List<ThongTin2> DuLieu { get; set; }
                public DuLieuThongTin2()
                {
                    DuLieu = new List<ThongTin2>();
                }
            }
            public class ThongTin2 : ThongTin
            {
                public string IdBaoCao { get; set; }
                public List<DichBenh> DanhSachDichBenh { get; set; }
                public int LoaiBaoCao { get; set; }// 0 : Tuần, 1 : Tháng, 2 : Quý, 3 : Năm
                public int LoaiDonViBaoCao { get; set; }// 0 : Ấp, 1 : Xã, 2 : Huyện
                public bool XuatBan { get; set; }
                public double NgayLapBaoCao { get; set; }

                public ThongTin2()
                {
                    DanhSachDichBenh = new List<DichBenh>();
                }
                public class DichBenh
                {
                    public string IdDichBenh { get; set; }
                    public string TenDichBenh { get; set; }
                }
            }
            public class ThongTinTongThaGiong
            {
                public double DienTich { get; set; }
                public double LuyKe { get; set; }
            }
            public class ThongTinTongThuHoach
            {
                public double DienTich { get; set; }
                public double LuyKeDienTich { get; set; }
                public double SanLuong { get; set; }
            }
            public class ThongTinTongDichBenh
            {
                public string IdDichBenh { get; set; }
                public string TenDichBenh { get; set; }
                public double DienTichThietHai { get; set; }
                public double LuyKe { get; set; }
            }

            public class ThongTinSanPham
            {
                public string Id { get; set; }
                public string Ten { get; set; }
            }
            public class DuLieuThaGiongThuHoachDichBenh
            {
                public int TrangThai { get; set; }
                public string NoiDungPheDuyet { get; set; }
                public List<ThaGiongThuHoachDichBenh> DuLieu { get; set; }
                public DuLieuThaGiongThuHoachDichBenh()
                {
                    DuLieu = new List<ThaGiongThuHoachDichBenh>();
                }
            }
            public class ThaGiongThuHoachDichBenh
            {
                public string Id { get; set; }
                public string IdDonVi { get; set; }
                public string TenDonVi { get; set; }
                public double TongDienTich { get; set; }
                public int SoHoThaNuoi { get; set; }
                public int SoHoCoDienTichBiBenh { get; set; }
                public double SoLuongConThaGiong { get; set; }

                public TongThaGiong ThongTinTongThaGiong { get; set; }
                public TongDichBenh ThongTinTongDichBenh { get; set; }
                public TongThuHoach ThongTinTongThuHoach { get; set; }
                public List<TongSanPham> DanhSachTongSanPham { get; set; }

                /// <summary>
                /// 0 : Tuần, 1 : Tháng, 2 : Quý, 3 : Năm
                /// </summary>
                public int LoaiBaoCao { get; set; }
                /// <summary>
                /// 0 : Ấp, 1 : Xã, 2 : Huyện
                /// </summary>
                public int LoaiDonViBaoCao { get; set; }
                public bool XuatBan { get; set; }
                public double NgayLapBaoCao { get; set; }

                public ThaGiongThuHoachDichBenh()
                {
                    ThongTinTongThaGiong = new TongThaGiong();
                    ThongTinTongDichBenh = new TongDichBenh();
                    ThongTinTongThuHoach = new TongThuHoach();
                    DanhSachTongSanPham = new List<TongSanPham>();
                }
                public class DichBenh
                {
                    public string IdDichBenh { get; set; }
                    public string TenDichBenh { get; set; }
                }
                public class TongSanPham
                {
                    public string Id { get; set; }
                    public string Ten { get; set; }
                }
                public class TongThaGiong
                {
                    public double DienTich { get; set; }
                    public double LuyKeDienTich { get; set; }
                }
                public class TongThuHoach
                {
                    public double DienTich { get; set; }
                    public double LuyKeDienTich { get; set; }
                    public double SanLuong { get; set; }
                }
                public class TongDichBenh
                {
                    public double DienTichThietHai { get; set; }
                    public double LuyKeThietHai { get; set; }
                    public List<DichBenh> DanhSachDichBenh { get; set; }
                }
            }

            public class HoNuoiThaGiongThuHoachDichBenh
            {
                public class DuLieuHoNuoiThaGiongThuHoachDichBenh
                {
                    public int TrangThai { get; set; }
                    public string NoiDungPheDuyet { get; set; }
                    public List<DocDanhSach> DuLieu { get; set; }
                    public DuLieuHoNuoiThaGiongThuHoachDichBenh()
                    {
                        DuLieu = new List<DocDanhSach>();
                    }
                }
                public class DocDanhSach
                {
                    public string IdHoNuoi { get; set; }
                    public string TenHoNuoi { get; set; }

                    public string IdHuyen { get; set; }
                    public string IdXa { get; set; }
                    public string IdAp { get; set; }

                    public TongAoNuoi ThongTinTongAoNuoi { get; set; }
                    public TongThaGiong ThongTinTongThaGiong { get; set; }
                    public TongDichBenh ThongTinTongDichBenh { get; set; }
                    public TongThuHoach ThongTinTongThuHoach { get; set; }

                    public int LoaiBaoCao { get; set; }
                    public bool XuatBan { get; set; }

                    public double NgayLapBaoCao { get; set; }
                    public string Id { get; set; }
                    public string GhiChu { get; set; }
                    public DocDanhSach()
                    {
                        ThongTinTongAoNuoi = new TongAoNuoi();
                        ThongTinTongThaGiong = new TongThaGiong();
                        ThongTinTongDichBenh = new TongDichBenh();
                        ThongTinTongThuHoach = new TongThuHoach();
                    }
                }
                public class TongAoNuoi
                {
                    public int SoAo { get; set; }
                    public double DienTich { get; set; }
                }

                public class TongThaGiong
                {
                    public int LanTha { get; set; }
                    public double DienTich { get; set; }
                    public double LuyKeDienTich { get; set; }
                    public string IdSanPham { get; set; }
                    public string TenSanPham { get; set; }
                    public double NgayTha { get; set; }
                    public double MatDo { get; set; }
                    public string IdTinh { get; set; }
                    public string ChuoiNgayTha { get; set; }
                    public List<DotTha> DanhSachThaGiong { get; set; }
                    public List<int> DanhSachNguonGiong { get; set; }
                }

                public class DotTha
                {
                    public string IdSanPham { get; set; }
                    public string TenSanPham { get; set; }
                    public double NgayTha { get; set; }
                    public double MatDo { get; set; }
                    public string IdTinh { get; set; }
                    public string ChuoiNgayTha { get; set; }
                }
                public class TongThuHoach
                {
                    public double DienTich { get; set; }
                    public double LuyKeDienTich { get; set; }
                    public double SanLuong { get; set; }
                    public double LanThu { get; set; }
                    public string ChuoiNgayThu { get; set; }
                    public double NgayThu { get; set; }
                    public List<ThuHoach> DanhSachThuHoach { get; set; }
                }
                public class ThuHoach
                {
                    public double LanThu { get; set; }
                    public string ChuoiNgayThu { get; set; }
                    public double NgayThu { get; set; }
                }
                public class DichBenh
                {
                    public string IdDichBenh { get; set; }
                    public string TenDichBenh { get; set; }
                    public string ChuoiNgayPhatHien { get; set; }
                    public double NgayPhatHien { get; set; }
                }
                public class TongDichBenh
                {
                    public List<DichBenh> DanhSachDichBenh { get; set; }
                    public double DienTichThietHai { get; set; }
                    public double LuyKeThietHai { get; set; }
                    public string ChuoiNgayPhatHien { get; set; }
                    public double NgayPhatHien { get; set; }
                }
            }
        }

        public class ThaGiongThuHoachOutput
        {
            public class DocDanhSachModel
            {
                public int LoaiBaoCao { get; set; }
                public DocDanhSach DanhSachDuLieu { get; set; }
                public DocDanhSachBaoCao DanhSachDuLieuBaoCao { get; set; }
                public DocDanhSachModel()
                {
                    DanhSachDuLieu = new DocDanhSach();
                    DanhSachDuLieuBaoCao = new DocDanhSachBaoCao();
                }
            }
            public class DocDanhSach
            {
                public bool XuatBanCapTinh { get; set; }
                public string TenNguoiPheDuyet { get; set; }
                public List<ThongTinThaGiongThuHoach> DuLieu { get; set; }
                public List<DanhMucDropDown> DanhSachSanPham { get; set; }
                public List<DanhMucDropDown> DanhSachNguonGoc { get; set; }
                public DocDanhSach()
                {
                    DuLieu = new List<ThongTinThaGiongThuHoach>();
                    DanhSachSanPham = new List<DanhMucDropDown>();
                    DanhSachNguonGoc = new List<DanhMucDropDown>();
                }
            }
            public class DocDanhSachBaoCao
            {
                public bool XuatBanCapTinh { get; set; }
                public string TenNguoiPheDuyet { get; set; }
                public List<ThongTinThaGiongThuHoach2> DuLieu { get; set; }
                public List<DanhMucDropDown> DanhSachSanPham { get; set; }
                public List<DanhMucDropDown> DanhSachNguonGoc { get; set; }
                public DocDanhSachBaoCao()
                {
                    DuLieu = new List<ThongTinThaGiongThuHoach2>();
                    DanhSachSanPham = new List<DanhMucDropDown>();
                    DanhSachNguonGoc = new List<DanhMucDropDown>();
                }
            }
            public class ThongTinThaGiongThuHoach2//Dùng cho cấp đơn vị
            {
                public string Id { get; set; }
                public string IdDonVi { get; set; }
                public string TenDonVi { get; set; }
                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }
                public int TrangThai { get; set; }
                public int LoaiBaoCao { get; set; }
                public bool XuatBan { get; set; }
                public string NgayLapBaoCao { get; set; }
                public string GhiChu { get; set; }

                public ThongTinTongAoNuoi ThongTinTongAoNuoi { get; set; }
                public ThongTinTongThaGiongBaoCao ThongTinTongThaGiong { get; set; }
                public ThongTinTongThuHoach ThongTinTongThuHoach { get; set; }
                public ThongTinThaGiongThuHoach2()
                {
                    ThongTinTongAoNuoi = new ThongTinTongAoNuoi();
                    ThongTinTongThaGiong = new ThongTinTongThaGiongBaoCao();
                    ThongTinTongThuHoach = new ThongTinTongThuHoach();
                }
            }
            public class ThongTinThaGiongThuHoach
            {
                public string Id { get; set; }
                public string IdHoNuoi { get; set; }
                public string TenHoNuoi { get; set; }
                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }
                public string DiaChi { get; set; }
                public int TrangThai { get; set; }
                public int LoaiBaoCao { get; set; }
                public bool XuatBan { get; set; }
                public string NgayLapBaoCao { get; set; }
                public string GhiChu { get; set; }

                public ThongTinTongAoNuoi ThongTinTongAoNuoi { get; set; }
                public ThongTinTongThaGiong ThongTinTongThaGiong { get; set; }
                public ThongTinTongThuHoach ThongTinTongThuHoach { get; set; }
                public ThongTinThaGiongThuHoach()
                {
                    ThongTinTongAoNuoi = new ThongTinTongAoNuoi();
                    ThongTinTongThaGiong = new ThongTinTongThaGiong();
                    ThongTinTongThuHoach = new ThongTinTongThuHoach();
                }
            }
            public class ThongTinTongAoNuoi
            {
                public double SoAo { get; set; }
                public double DienTich { get; set; }
            }
            public class ThongTinTongThaGiongBaoCao
            {
                public double DienTich { get; set; }
                public double LuyKeDienTich { get; set; }
                public List<ThongTinSanPham> DanhSachThongTinSanPham { get; set; }
                public string NgayTha { get; set; }
                public double MatDo { get; set; }
                public string ChuoiNgayTha { get; set; }
                public ThongTinTongThaGiongBaoCao()
                {
                    DanhSachThongTinSanPham = new List<ThongTinSanPham>();
                }
            }
            public class ThongTinSanPham
            {
                public string IdSanPham { get; set; }
                public string TenSanPham { get; set; }
                public string IdNguonGoc { get; set; }
            }
            public class ThongTinTongThaGiong
            {
                public double DienTich { get; set; }
                public double LuyKeDienTich { get; set; }
                public string IdSanPham { get; set; }
                public string TenSanPham { get; set; }
                public string NgayTha { get; set; }
                public double MatDo { get; set; }
                public string ChuoiNgayTha { get; set; }
                public string IdNguonGoc { get; set; }
            }
            public class ThongTinTongThuHoach
            {
                public double DienTich { get; set; }
                public double LuyKeDienTich { get; set; }
                public double SanLuong { get; set; }
                public string ChuoiNgayThu { get; set; }
                public string NgayThu { get; set; }
            }
        }

        public class QuanLyDienTich
        {
            public class Thongin : ChungThuc
            {
                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }
                public string Nam { get; set; }
                public string SauThang { get; set; }
                public string Quy { get; set; }
                public string Thang { get; set; }
                public string Tuan { get; set; }
                public string IdHinhThucNuoi { get; set; }
            }
            public class ThongTinQuanLyDienTich
            {
                public bool XuatBanCapTinh { get; set; }
                public string TenNguoiPheDuyet { get; set; }
                public DanhSachQuanLyDienTich DuLieu { get; set; }
                public ThongTinQuanLyDienTich()
                {
                    DuLieu = new DanhSachQuanLyDienTich();
                }
            }
            public class DanhSachQuanLyDienTich
            {
                public List<ThongTinDienTichNuoi> DanhSachNuoiQuangCanh { get; set; }
                public List<ThongTinDienTichNuoi> DanhSachNuoiQuangCanhCaiTien { get; set; }
                public List<ThongTinDienTichNuoi> DanhSachNuoiCongNghiep { get; set; }
                public List<ThongTinDienTichNuoi> DanhSachNuoiSieuThamCanh { get; set; }
                public List<ThongTinDienTichNuoi> DanhSachNuoiQuangCanhTomRungTomLua { get; set; }
                public List<ThongTinDienTichNuoi> DanhSachNuoiQuangCanhKhac { get; set; }
                public int Loai { get; set; }
                public DanhSachQuanLyDienTich()
                {
                    DanhSachNuoiQuangCanh = new List<ThongTinDienTichNuoi>();
                    DanhSachNuoiQuangCanhCaiTien = new List<ThongTinDienTichNuoi>();
                    DanhSachNuoiCongNghiep = new List<ThongTinDienTichNuoi>();
                    DanhSachNuoiSieuThamCanh = new List<ThongTinDienTichNuoi>();
                    DanhSachNuoiQuangCanhTomRungTomLua = new List<ThongTinDienTichNuoi>();
                    DanhSachNuoiQuangCanhKhac = new List<ThongTinDienTichNuoi>();
                }
            }
            public class SoLuongDienTich
            {
                public double SoAo { get; set; }
                public double DienTich { get; set; }

            }
            public class ThongTinDocDanhSach
            {
                public bool XuatBanCapTinh { get; set; }
                public string TenNguoiPheDuyet { get; set; }
                public List<ThongTinDienTichNuoi> DuLieu { get; set; }
                public ThongTinDocDanhSach()
                {
                    DuLieu = new List<ThongTinDienTichNuoi>();
                }
            }
            public class ThongTinDienTichNuoi
            {
                public string Id { get; set; }
                public string IdDonVi { get; set; }
                public string TenDonVi { get; set; }
                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }
                public double TongSoHo { get; set; }
                public double TongDienTich { get; set; }
                public double TongSoAo { get; set; }
                public double LuyKeTongSoHo { get; set; }
                public double LuyKeTongDienTich { get; set; }
                public double LuyKeTongSoAo { get; set; }

                public SoLuongDienTich AoUong { get; set; }
                public SoLuongDienTich AoNuoi { get; set; }
                public SoLuongDienTich AoLangTho { get; set; }
                public SoLuongDienTich AoLangXuLy { get; set; }
                public SoLuongDienTich AoSanSang { get; set; }
                public SoLuongDienTich AoXuLyThai { get; set; }
                public SoLuongDienTich AoChuaBunThai { get; set; }

                public int LoaiBaoCao { get; set; }
                public bool XuatBan { get; set; }
                public double NgayLapBaoCao { get; set; }
                public string GhiChu { get; set; }
                public string IdHinhThucNuoi { get; set; }
                public int TrangThai { get; set; }
                public string NoiDungPheDuyet { get; set; }
                public int LoaiDonViBaoCao { get; set; }
                public string IdNguoiPheDuyet { get; set; }

                public double DienTichNamTruoc { get; set; }
                public double CungKy { get; set; }
                public double ChiTieuTangMoiDienTichNamHienTai { get; set; }
                public double ChiTieuDienTichNamHienTai { get; set; }
                public double DienTichTangThem { get; set; }
                public double DienTichLuyKe { get; set; }
                public double PhanTramDienTichSoVoiChiTieu { get; set; }
                public double DienTichThaNuoi { get; set; }



                #region Quảng canh (tôm rừng, tôm lúa)
                public double QC_DienTichTomRung { get; set; }
                public double QC_DienTichTomLua { get; set; }
                public double QC_DienTichKetHopTomCuaCa { get; set; }
                public double QC_DienTichTongSo { get; set; }
                public double QC_DienTichLoaiKhac { get; set; }

                public double QC_DienTichTomRungNamTruoc { get; set; }
                public double QC_DienTichTomLuaNamTruoc { get; set; }
                public double QC_DienTichKetHopTomCuaCaNamTruoc { get; set; }
                public double QC_DienTichTongSoNamTruoc { get; set; }
                public double QC_DienTichLoaiKhacNamTruoc { get; set; }
                #endregion
                #region Quảng canh (thuỷ sản khác)
                public double QC_DienTichNuoiCuaNamTruoc { get; set; }
                public double QC_DienTichNuoiNgheuNamTruoc { get; set; }
                public double QC_DienTichNuoiCaLongBeNamTruoc { get; set; }
                public double QC_DienTichNuoiCaChinhNamTruoc { get; set; }
                public double QC_DienTichNuoiCua { get; set; }
                public double QC_DienTichNuoiCaBongTuong { get; set; }
                public double QC_DienTichNuoiSo { get; set; }
                public double QC_DienTichNuoiNgheu { get; set; }
                public double QC_DienTichNuoiCaLongBe { get; set; }
                public double QC_DienTichNuoiCaBop { get; set; }
                public double QC_DienTichNuoiCaMu { get; set; }
                public double QC_DienTichNuoiCaChem { get; set; }
                public double QC_DienTichNuoiCaChinh { get; set; }
                #endregion
                public ThongTinDienTichNuoi()
                {
                    AoUong = new SoLuongDienTich();
                    AoNuoi = new SoLuongDienTich();
                    AoLangTho = new SoLuongDienTich();
                    AoLangXuLy = new SoLuongDienTich();
                    AoSanSang = new SoLuongDienTich();
                    AoXuLyThai = new SoLuongDienTich();
                    AoChuaBunThai = new SoLuongDienTich();
                }
            }
        }
    }
    #endregion
    #region Excel
    public class ExcelErrorOutput
    {
        public class DanhSachHoNuoiVaHeThongAoLoi
        {
            public List<HoNuoi> DanhSachHoNuoi { get; set; }
            public class HoNuoi
            {
                public string Id { get; set; }
                public int ViTri { get; set; }
                public string Ho { get; set; }
                public string Ten { get; set; }
                public string TenHuyen { get; set; }
                public string TenXa { get; set; }
                public string TenAp { get; set; }
                public List<Ao> DanhSachAo { get; set; }
                public class Ao
                {
                    public string Id { get; set; }
                    public int ViTri { get; set; }
                    public string TenHinhThucNuoi { get; set; }
                    public float DienTich { get; set; }
                    public float SoAo { get; set; }
                    public string TenTinhTrang { get; set; }
                }
            }
        }
        public class Error
        {
            public int SoDong { get; set; }
            public string TenHoNuoi { get; set; }
        }
    }
    #endregion
    #region Sâu bẹnh, loại sâu bệnh
    public class SauBenhOutput
    {
        public class ThongTinSauBenh
        {
            //public string Id { get; set; }
            //public string Ma { get; set; }
            //public string Ten { get; set; }

            public string Id { get; set; }
            public string IdLoaiSauBenh { get; set; }
            public string TenLoaiSauBenh { get; set; }
            public string Ten { get; set; }
            public string Ma { get; set; }
            public string TenBieuMauBaoCao { get; set; }
            public string Icon { get; set; }
            public int ViTri { get; set; }
            public int KichHoat { get; set; }
            public string IdBieuMauBaoCao { get; set; }
            public List<string> DanhSachIdSanPham { get; set; }
            public List<ThongTin> DanhSachThongTinDichBenh { get; set; }
            public class ThongTin
            {
                public string IdQuyCach { get; set; }
                public string TenQuyCach { get; set; }
                public string IdDonViTinh { get; set; }
                public string TenDonViTinh { get; set; }
            }
            public List<SanPham> DanhSachSanPham { get; set; }
            public class SanPham
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public List<ThongTin> DanhSachThongTinSanPham { get; set; }
                public class ThongTin
                {
                    public string IdQuyCach { get; set; }
                    public string TenQuyCach { get; set; }
                    public string IdDonViTinh { get; set; }
                    public string TenDonViTinh { get; set; }
                }
                public SanPham()
                {
                    DanhSachThongTinSanPham = new List<ThongTin>();
                }
            }
            public ThongTinSauBenh()
            {
                DanhSachIdSanPham = new List<string>();
                DanhSachThongTinDichBenh = new List<ThongTin>();
                DanhSachSanPham = new List<SanPham>();
            }
        }

        public class ThongTinSauBenhKemGiaiDoanCayTrong
        {
            public string Id { get; set; }
            public string Ma { get; set; }
            public string Ten { get; set; }
            public string IdSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string IdQuyCach { get; set; }
            public string TenQuyCach { get; set; }
        }
        public class DocDanhSachTheoIdNhomSanPham : ThongTinSauBenh { }
    }
    public class LoaiSauBenhOutput
    {
        public class ThongTinLoaiSauBenh
        {
            public string Id { get; set; }
            public string Ma { get; set; }
            public string Ten { get; set; }
        }
    }
    #endregion
    #region Dùng chung cho output ajax
    public class DuLieuOutputModel
    {
        public dynamic DuLieu { get; set; }
        public int KetQua { get; set; }
        public string GhiChu { get; set; }
        public string ThongBao { get; set; }
    }
    #endregion
    #region message
    public class Message_OutPut
    {
        public const string Finish_Delete = "Bạn đã xóa thành công !";
        public const string Finish_New = "Bạn đã thêm thành công !";
        public const string Error_Server = "Không thể truy cập vào Server!";
    }
    #endregion

    #region Chỉ đạo điều hành
    public class ChiDaoDieuHanhOutput
    {
        public string Id { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public bool HienThi { get; set; }
        public bool ThongBaoTBDD { get; set; }
        public bool NoiBat { get; set; }
        public string HinhAnh { get; set; }
        public string TapTin { get; set; }
        public string ChuoiNgay { get; set; }
    }
    #endregion

    #region Loại thông báo
    public class LoaiThongBaoOutput
    {
        public class DocDanhSach
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string Icon { get; set; }
            public string MauNen { get; set; }
            public string Ma { get; set; }
        }
    }
    #endregion

    #region Thông báo
    public class ThongBaoOutput
    {
        public class GuiTatCa
        {

        }
    }
    #endregion
    #region Chăn nuôi thú y
    public class ChanNuoiThuYOutput
    {
        public class DuLieuThongTinModel
        {
            public List<DocThongTin> DuLieu { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPage { get; set; }
        }
        public class PhanLoaiBaoCao
        {
            public DuLieuThongTinModel DuLieuTuan { get; set; }
            public List<DocThongTin> DanhSachDuLieuThang { get; set; }
            public List<DocThongTin> DanhSachDuLieuQuy { get; set; }
            public List<DocThongTin> DanhSachDuLieuSauThang { get; set; }
            public List<DocThongTin> DanhSachDuLieuNam { get; set; }
            public PhanLoaiBaoCao()
            {
                DuLieuTuan = new DuLieuThongTinModel();
                DanhSachDuLieuThang = new List<DocThongTin>();
                DanhSachDuLieuQuy = new List<DocThongTin>();
                DanhSachDuLieuSauThang = new List<DocThongTin>();
                DanhSachDuLieuNam = new List<DocThongTin>();
            }
        }
        public class DocThongTin
        {
            public string Id { get; set; }
            public string LoaiDoiTuong { get; set; }
            public string Ten { get; set; }
            public string MoTa { get; set; }
            public string NoiDung { get; set; }
            public string HinhDaiDien { get; set; }
            public int DoUuTien { get; set; }
            public int KichHoat { get; set; }
            public string GhiChu { get; set; }
            public string DuongDanThanThien { get; set; }
            public string TieuDe { get; set; }
            public string NoiDungTomTat { get; set; }
            public int TrangThai { get; set; }
            public string NgayTao { get; set; }
            public int Nam { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public double ThoiGianBatDau { get; set; }
            public double ThoiGianKetThuc { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int LoaiBaoCao { get; set; }
            public string TenNguoiCapNhat { get; set; }
        }
        public class ThongTinChoNguoiDanModel
        {
            public List<ThongTinChoNguoiDanOutput> DuLieu { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPage { get; set; }
            public int KetQua { get; set; }
            public string GhiChu { get; set; }
            public ThongTinChoNguoiDanModel()
            {
                DuLieu = new List<ThongTinChoNguoiDanOutput>();
            }
        }
        public class ThongTinChoNguoiDanOutput
        {
            public string Id { get; set; }
            public string TieuDe { get; set; }
            public string DuongDanThanThien { get; set; }
            public string NoiDungTomTat { get; set; }
            public string NoiDung { get; set; }
            public string HinhDaiDien { get; set; }
            public int DoUuTien { get; set; }
            public int TrangThai { get; set; }
            public string IdNhomThongTin { get; set; }
            public int LoaiBaoCao { get; set; }
            public string TenNguoiCapNhat { get; set; }
        }
        public class DocDanhMucTheoIdBieuMauBaoCao
        {
            public List<DanhMucDropDown> DanhSachThuySan { get; set; }
            public List<DanhMucDropDown> DanhSachDichBenh { get; set; }
            public List<DanhMucDropDown> DanhSachHoNuoi { get; set; }
            public List<DanhMucDropDown> DanhSachHinhThucNuoi { get; set; }
            public List<DanhMucDropDown> DanhSachMucDichNuoi { get; set; }

            public DocDanhMucTheoIdBieuMauBaoCao()
            {
                DanhSachThuySan = new List<DanhMucDropDown>();
                DanhSachDichBenh = new List<DanhMucDropDown>();
                DanhSachHoNuoi = new List<DanhMucDropDown>();
                DanhSachHinhThucNuoi = new List<DanhMucDropDown>();
                DanhSachMucDichNuoi = new List<DanhMucDropDown>();
            }
        }
    }
    #endregion

    #region Giá cả thị trường
    public class GiaCaThiTruongTrongTinhOutPut
    {
        public string IdAp { get; set; }
        public string IdXa { get; set; }
        public string IdHuyen { get; set; }
        public string IdTinh { get; set; }


        public string IdNhomSanPham { get; set; }
        public string TenNhomSanPham { get; set; }
        public string IdSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string IdDonViTinh { get; set; }
        public string TenDonViTinh { get; set; }
        public string IdQuyCach { get; set; }
        public string TenQuyCach { get; set; }

        public string GiaThuMua { get; set; }
        public string GiaThapNhat { get; set; }
        public string GiaCaoNhat { get; set; }
        public float GiaThuMuaTu { get; set; }
        public float GiaThuMuaDen { get; set; }
        public float GiaBanLeTu { get; set; }
        public float GiaBanLeDen { get; set; }

        public bool TuanHienTai { get; set; }
        public double Ngay { get; set; }
        public string ChuoiNgay { get; set; }
        public string Id { get; set; }
    }
    #endregion


    #region Loại dịch bệnh thú y
    public class LoaiDichBenhThuYOutput
    {
        public class DocThongTin
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string TenVietTat { get; set; }
            public string MoTa { get; set; }
            public string NgayTao { get; set; }
            public string GhiChu { get; set; }
        }
    }
    #endregion
    #region Hiệp hội
    public class HiepHoi
    {
        public string Id { get; set; }
        public string Ten { get; set; }
    }
    #endregion
    #region Thiết bị
    public class ThietBi
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public string Ma { get; set; }
        public string TenDonVi { get; set; }
        public string ThoiGian { get; set; }
        public double NgayTao { get; set; }
        public string IdDonVi { get; set; }
        public double NhietDo { get; set; }
        public double DoPh { get; set; }
        public double DoMan { get; set; }
        public double SongGsm { get; set; }
        public double DoAm { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public int LoaiThietBi { get; set; }
        public string DiaChi { get; set; }
        public string IdTinh { get; set; }
        public string IdHuyen { get; set; }
        public string IdXa { get; set; }
        public string IdAp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<string> DanhSachHinhAnh { get; set; }
        public double NhietDoDat { get; set; }
        public double DoAmDat { get; set; }
        public string TenAp { get; set; }
        public string TenXa { get; set; }
        public string TenHuyen { get; set; }
        public string TenTinh { get; set; }


        public long ChuKyKiemTraTaiKhoan { get; set; }
        public bool ThucHienGiamSat { get; set; }
        public long ChuKyGiamSat { get; set; }
        public long ChuKyDocThongTinCauHinh { get; set; }
    }
    public class LichSuThietBi
    {
        public string Ten { get; set; }
        public string Ma { get; set; }
        public string TenDonVi { get; set; }
        public string ThoiGian { get; set; }
        public string IdDonVi { get; set; }
        public double NhietDo { get; set; }
        public double DoPh { get; set; }
        public double DoMan { get; set; }
        public double SongGsm { get; set; }
        public double DoAm { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public int LoaiThietBi { get; set; }
        public string DiaChi { get; set; }
        public string IdTinh { get; set; }
        public string IdHuyen { get; set; }
        public string IdXa { get; set; }
        public string IdAp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Id { get; set; }
        public List<string> DanhSachHinhAnh { get; set; }
    }
    #endregion
    #region Loại tiêm phòng
    public class LoaiTiemPhongOutput
    {
        public class DocThongTin
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string TenVietTat { get; set; }
            public string MoTa { get; set; }
            public string IdDonViTinh { get; set; }
            public string TenDonViTinh { get; set; }
            public string NgayTao { get; set; }
            public string GhiChu { get; set; }
        }
    }
    #endregion

    #region Loại quy cách
    public class LoaiQuyCachOutput
    {
        public class DocDanhSach
        {
            public string Id { get; set; }
            public string Ma { get; set; }
            public string Ten { get; set; }
            public List<string> DanhSachIdChucNang { get; set; }
        }
    }
    #endregion

    #region GiaGiong
    public class GiaGiongTrongTinhOutput
    {
        public class DocThongTin
        {

            public string Id { get; set; }

            public string ChuoiThang { get; set; }
            public string IdNhomSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string TenQuyCach { get; set; }
            public string TenDonViTinh { get; set; }
            [DisplayFormat(DataFormatString = "{0:P2}")]
            public decimal GiaThuMuaTu { get; set; }
            [DisplayFormat(DataFormatString = "{0:P2}")]
            public decimal GiaThuMuaDen { get; set; }
            [DisplayFormat(DataFormatString = "{0:P2}")]
            public decimal GiaBanLeTu { get; set; }
            [DisplayFormat(DataFormatString = "{0:P2}")]
            public decimal GiaBanLeDen { get; set; }
            public string IdQuyCach { get; set; }
            public string IdDonViTinh { get; set; }
            public string IdSanPham { get; set; }
            public bool TuanHienTai { get; set; }
        }

    }
    #endregion

    #region Nhóm thông tin
    public class NhomThongTinOutput
    {
        public class DocDanhSach
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string Ma { get; set; }
            public string MaChucNang { get; set; }
            public string IdCha { get; set; }
        }
        public class DocDanhSachPhanCap
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string Ma { get; set; }
            public string MaChucNang { get; set; }
            public string IdCha { get; set; }
            public List<DocDanhSach> DanhSachNhomCon { get; set; }
        }
    }
    #endregion
    #region Giá giống trong tỉnh
    public class GiaGiongTrongTinhOutPut
    {
        public string Id { get; set; }
        public string IdAp { get; set; }
        public string IdXa { get; set; }
        public string IdHuyen { get; set; }
        public string IdTinh { get; set; }
        public string IdSanPham { get; set; }
        public string IdQuyCach { get; set; }
        public string IdDonViTinh { get; set; }

        public string IdCapGiong { get; set; }
        public string IdChieuCao { get; set; }
        public string IdCoBau { get; set; }
        public string IdKichCo { get; set; }
        public string IdNgayTuoi { get; set; }

        public float Gia { get; set; }
        public float GiaCu { get; set; }
        public int Nam { get; set; }
        public int Tuan { get; set; }
        public int Thang { get; set; }
        public string IdNhomSanPham { get; set; }
        public string TenDonViTinh { get; set; }
        public string TenQuyCach { get; set; }
        public string TenSanPham { get; set; }
        public string TenNhomSanPham { get; set; }
        public string TenCapGiong { get; set; }
        public string TenChieuCao { get; set; }
        public string TenCoBau { get; set; }
        public string TenKichCo { get; set; }
        public double NgayCapNhat { get; set; }
        public string ChuoiNgayCapNhat { get; set; }
        public string NguonGoc { get; set; }
        public string TenNgayTuoi { get; set; }
        public string GhiChu { get; set; }
    }
    public class DocNhatKyGiaGiongTrongTinh
    {
        public string Id { get; set; }
        public string IdAp { get; set; }
        public string IdXa { get; set; }
        public string IdHuyen { get; set; }
        public string IdTinh { get; set; }
        public string IdSanPham { get; set; }
        public string IdQuyCach { get; set; }
        public string IdDonViTinh { get; set; }

        public string IdCapGiong { get; set; }
        public string IdChieuCao { get; set; }
        public string IdCoBau { get; set; }
        public string IdKichCo { get; set; }

        public float Gia { get; set; }
        public string IdNhomSanPham { get; set; }
        public string TenDonViTinh { get; set; }
        public string TenQuyCach { get; set; }
        public string TenSanPham { get; set; }
        public string TenNhomSanPham { get; set; }
        public string TenCapGiong { get; set; }
        public string TenChieuCao { get; set; }
        public string TenCoBau { get; set; }
        public string TenKichCo { get; set; }
        public double NgayCapNhat { get; set; }
        public string ChuoiNgayCapNhat { get; set; }
        public string NguonGoc { get; set; }
        public string IdNgayTuoi { get; set; }
        public string TenNgayTuoi { get; set; }

        public double Thang { get; set; }
        public string ChuoiThang { get; set; }
        public string ChuoiNgay { get; set; }
        public int DemNhatKy { get; set; }
        public string TenTinh { get; set; }
        public bool TuanHienTai { get; set; }
        public string GhiChu { get; set; }
    }
    public class DocTenNguoiPheDuyet
    {
        public string Id { get; set; }
        public string Ten { get; set; }
    }
    #endregion

    #region Dùng chung cho Giá giống
    public class DungChungGiaGiongOutput
    {
        public class ThongTin
        {
            public string Id { get; set; }
            public string Ten { get; set; }
        }
    }
    #endregion

    #region Thong Ke Mo Hinh San Xuat Co Hieu Qua
    public class ThongKeMoHinhSanXuatCoHieuQuaOutput
    {
        public class DocThongTin
        {
            public string Id { get; set; }
            public string HoTen { get; set; }
            public string IdTinh { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }
            public string DiaChi { get; set; }
            public string DienTich { get; set; }
            public string DoiTuongSX { get; set; }
            public string LoaiHinh { get; set; }
            public string ThoiGianSX { get; set; }
            public string NangSuat { get; set; }
            public string LoiNhuan { get; set; }
            public string DanhGia { get; set; }
        }
    }
    #endregion
    #region Thả giống, thu hoạch và ao nuôi
    public class DinhNghiaThaGiongThuHoachAoNuoiOutput
    {
        public DuLieuNongNghiepOutput.ThaGiongThuHoachOutput.DocDanhSach DanhSachThaGiongThuHoach;
        public AoOutput.DocDanhSach DanhSachAoNuoi;
        //public DocDanhSachThongKeTieuChuanAo DanhSachThongKeTieuChuanAo;
        public List<ThongKeTieuChuanAo> DanhSachThongKeTieuChuanAo;
        public DinhNghiaThaGiongThuHoachAoNuoiOutput()
        {
            DanhSachThaGiongThuHoach = new DuLieuNongNghiepOutput.ThaGiongThuHoachOutput.DocDanhSach();
            DanhSachAoNuoi = new AoOutput.DocDanhSach();
            //DanhSachThongKeTieuChuanAo = new DocDanhSachThongKeTieuChuanAo();
            DanhSachThongKeTieuChuanAo = new List<ThongKeTieuChuanAo>();
        }
    }
    #endregion
    #region Chất lượng
    public class ChatLuongOutput
    {
        public class ThongTinKiemdich
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string TenVietTat { get; set; }
            public string MoTa { get; set; }
            public string GhiChu { get; set; }
        }
    }
    #endregion
    #region Thống kê
    public class DocDanhSachThongKeTieuChuanAo
    {
        public List<ThongKeTieuChuanAo> DanhSachThongKeTieuChuanAo { get; set; }
        public DocDanhSachThongKeTieuChuanAo()
        {
            DanhSachThongKeTieuChuanAo = new List<ThongKeTieuChuanAo>();
        }

    }
    public class ThongKeTieuChuanAo
    {
        //public string IdDonVi { get; set; }
        //public string TenDonVi { get; set; }
        //public double TongDienTich { get; set; }
        //public double TongSoAo { get; set; }
        //public double TongDatTieuChuanMoiTruong { get; set; }
        //public double TongDatTieuChuanDien { get; set; }
        //public double TongDatTieuChuanDichBenh { get; set; }
        //public double TongQuyHoach { get; set; }
        //public double TongDuDieuKien { get; set; }
        //public double TongHoNuoi { get; set; }

        public object IdDonVi { get; set; }
        public object TongHoNuoi { get; set; }
        public object TongSoAo { get; set; }
        public object TongDienTich { get; set; }
        public object TongDienTichDamBao { get; set; }
        public object TongSoHoDamBao { get; set; }
        public object TongDienTichHanChe { get; set; }
        public object TongSoHoHanChe { get; set; }
        public object TongDienTichKhong { get; set; }
        public object TongSoHoKhong { get; set; }
        public string TenDonVi { get; set; }
    }
    public class DinhNghiaThongKeThaGiongThuHoachAoNuoiOutput
    {
        public ThaGiongThuHoach DanhSachThaGiongThuHoach;
        public List<ThongKeDanhSachAoNuoiTheoDiaChi> DanhSachAoNuoi;
        //public DocDanhSachThongKeTieuChuanAo DanhSachThongKeTieuChuanAo;
        public List<ThongKeTieuChuanAo> DanhSachThongKeTieuChuanAo;
        public DinhNghiaThongKeThaGiongThuHoachAoNuoiOutput()
        {
            DanhSachThaGiongThuHoach = new ThaGiongThuHoach();
            DanhSachAoNuoi = new List<ThongKeDanhSachAoNuoiTheoDiaChi>();
            //DanhSachThongKeTieuChuanAo = new DocDanhSachThongKeTieuChuanAo();
            DanhSachThongKeTieuChuanAo = new List<ThongKeTieuChuanAo>();
        }
    }
    public class ThongKeDanhSachAoNuoiTheoDiaChi
    {
        public double TongDienTich { get; set; }
        public double AoUong_TongSoAo { get; set; }
        public double AoUong_TongDienTich { get; set; }
        public double AoNuoi_TongSoAo { get; set; }
        public double AoNuoi_TongDienTich { get; set; }
        public double AoLangTho_TongSoAo { get; set; }
        public double AoLangTho_TongDienTich { get; set; }
        public double AoLangXuLy_TongSoAo { get; set; }
        public double AoLangXuLy_TongDienTich { get; set; }
        public double AoSanSang_TongSoAo { get; set; }
        public double AoSanSang_TongDienTich { get; set; }
        public double AoXuLyThai_TongSoAo { get; set; }
        public double AoXuLyThai_TongDienTich { get; set; }
        public double AoChuaBunThai_TongSoAo { get; set; }
        public double AoChuaBunThai_TongDienTich { get; set; }
        public int TongDatTieuChuanMoiTruong { get; set; }
        public int TongDatTieuChuanDien { get; set; }
        public int TongDatTieuChuanDichBenh { get; set; }
        public int TongQuyHoach { get; set; }
        public int TongDuDieuKien { get; set; }
        public List<string> DanhSachIdTinhTrang { get; set; }
        public List<string> DanhSachTenTinhTrang { get; set; }
        public List<string> DanhSachGhiChu { get; set; }
        public string IdDonVi { get; set; }
        public string TenDonVi { get; set; }
    }
    public class ThaGiongThuHoach
    {
        public List<ThongTin> DuLieu { get; set; }

        public List<DanhMucNguonGoc> DanhSachNguonGoc { get; set; }
        public List<DanhMucSanPham> DanhSachSanPham { get; set; }

        public class DanhMucNguonGoc
        {
            public string Id { get; set; }
            public string Ten { get; set; }
        }
        public class DanhMucSanPham
        {
            public string Id { get; set; }
            public string Ten { get; set; }
        }
        public class TongAoNuoi
        {
            public double SoAo { get; set; }
            public double DienTich { get; set; }
        }

        public class TongThaGiong
        {
            public double DienTich { get; set; }
            public double LuyKeDienTich { get; set; }
            public List<ThongTinSanPham> DanhSachThongTinSanPham { get; set; }
            public double NgayTha { get; set; }
            public double MatDo { get; set; }
            public int Dem { get; set; }
            public string ChuoiNgayTha { get; set; }
        }

        public class ThongTinSanPham
        {
            public string IdSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string IdNguonGoc { get; set; }
        }


        public class TongThuHoach
        {
            public double DienTich { get; set; }
            public double LuyKeDienTich { get; set; }
            public double SanLuong { get; set; }
            public string ChuoiNgayThu { get; set; }
            public double NgayThu { get; set; }
        }



        public class ThongTin
        {
            public string IdDonVi { get; set; }
            public string TenDonVi { get; set; }

            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }

            public TongAoNuoi ThongTinTongAoNuoi { get; set; }
            public TongThaGiong ThongTinTongThaGiong { get; set; }
            public TongThuHoach ThongTinTongThuHoach { get; set; }


            public int TrangThai { get; set; }
            public int LoaiBaoCao { get; set; }
            public bool XuatBan { get; set; }

            public double NgayLapBaoCao { get; set; }
            public string Id { get; set; }
            public string GhiChu { get; set; }
        }
    }
    public class DinhNghiaThongKeTHThaGiongThuHoachAoNuoiOutput
    {
        public ThaGiongThuHoach DanhSachThaGiongThuHoach;
        public List<ThongKeDanhSachAoNuoiTheoDiaChi> DanhSachAoNuoi;
        public List<ThongKeTieuChuanAo> DanhSachThongKeTieuChuanAo;
        public List<SanXuatTrongTrotOutput.TienDoXuongSanXuat2> DanhSachTienDoXuongGiongLua;
        public List<SanXuatTrongTrotOutput.TienDoXuongSanXuat2> DanhSachSanXuatRauMau;
        public List<SanXuatTrongTrotOutput.TinhHinhSauBenh2> DanhSachDichHaiTrenLuaHeThu;
        public List<SanXuatTrongTrotOutput.TinhHinhSauBenh2> DanhSachDichHaiTrenRauMau;
        public List<SanXuatTrongTrotOutput.TinhHinhSauBenh2> DanhSachDichHaiTrenMia;
        public List<SanXuatTrongTrotOutput.TinhHinhSauBenh2> DanhSachDichHaiTrenCayLamNghiep;
        public List<SanXuatTrongTrotOutput.TinhHinhSauBenh2> DanhSachDichHaiTrenCayAnTrai;
        public List<SanXuatTrongTrotOutput.TinhHinhSauBenh2> DanhSachDichHaiTrenLuaXuanHe;
        public List<SanXuatTrongTrotOutput.TinhHinhSauBenh2> DanhSachDichHaiTrenLuaDongXuan;
        public List<SanXuatTrongTrotOutput.TinhHinhSauBenh2> DanhSachDichHaiTrenLuaThuDong;
        public List<SanXuatTrongTrotOutput.TinhHinhSauBenh2> DanhSachDichHaiTrenLuaMua;
        public List<SanXuatTrongTrotOutput.TinhHinhSauBenh2> DanhSachDichHaiTrenLuaTom;
        public object DanhSachTiemPhongTrenGiaCam;
        public object DanhSachTiemPhongTrenGiaSuc;
        public object DanhSachDichBenhTrenHeo;
        public object DanhSachDichBenhTrenThuySan;
        public object DanhSachGietMoGiaCam;
        public object DanhSachGietMoGiaSuc;
        public object DanhSachKiemDichXuatTinhDongVat;
        public object DanhSachKiemDichTomGiongCaGiong;
        public object DanhSachKiemDichTomSuBoMe;
        public object DanhSachKiemDichNhapTinhDongVat;
        public DinhNghiaThongKeTHThaGiongThuHoachAoNuoiOutput()
        {
            DanhSachThaGiongThuHoach = new ThaGiongThuHoach();
            DanhSachAoNuoi = new List<ThongKeDanhSachAoNuoiTheoDiaChi>();
            DanhSachThongKeTieuChuanAo = new List<ThongKeTieuChuanAo>();
            DanhSachTienDoXuongGiongLua = new List<SanXuatTrongTrotOutput.TienDoXuongSanXuat2>();
            DanhSachSanXuatRauMau = new List<SanXuatTrongTrotOutput.TienDoXuongSanXuat2>();
            DanhSachDichHaiTrenLuaHeThu = new List<SanXuatTrongTrotOutput.TinhHinhSauBenh2>();
            DanhSachDichHaiTrenRauMau = new List<SanXuatTrongTrotOutput.TinhHinhSauBenh2>();
            DanhSachDichHaiTrenMia = new List<SanXuatTrongTrotOutput.TinhHinhSauBenh2>();
            DanhSachDichHaiTrenCayLamNghiep = new List<SanXuatTrongTrotOutput.TinhHinhSauBenh2>();
            DanhSachDichHaiTrenCayAnTrai = new List<SanXuatTrongTrotOutput.TinhHinhSauBenh2>();
            DanhSachDichHaiTrenLuaXuanHe = new List<SanXuatTrongTrotOutput.TinhHinhSauBenh2>();
            DanhSachDichHaiTrenLuaDongXuan = new List<SanXuatTrongTrotOutput.TinhHinhSauBenh2>();
            DanhSachDichHaiTrenLuaThuDong = new List<SanXuatTrongTrotOutput.TinhHinhSauBenh2>();
            DanhSachDichHaiTrenLuaMua = new List<SanXuatTrongTrotOutput.TinhHinhSauBenh2>();
            DanhSachDichHaiTrenLuaTom = new List<SanXuatTrongTrotOutput.TinhHinhSauBenh2>();
            DanhSachTiemPhongTrenGiaCam = new object();
            DanhSachTiemPhongTrenGiaSuc = new object();
            DanhSachDichBenhTrenHeo = new object();
            DanhSachDichBenhTrenThuySan = new object();
            DanhSachGietMoGiaCam = new object();
            DanhSachGietMoGiaSuc = new object();
            DanhSachKiemDichXuatTinhDongVat = new object();
            DanhSachKiemDichTomGiongCaGiong = new object();
            DanhSachKiemDichTomSuBoMe = new object();
            DanhSachKiemDichNhapTinhDongVat = new object();
        }
    }
    public class DocDanhSachBieuMauBaoCaoChanNuoiThuYOutput
    {
        public string Id { get; set; }
        public string Loai { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
    }
    #endregion
    #region Sở nông nghiệp
    public class SoNongNghiepOutput
    {
        public class DocThongTin
        {
            public string Id { get; set; }
            public string LoaiDoiTuong { get; set; }
            public string Ten { get; set; }
            public string MoTa { get; set; }
            public string NoiDung { get; set; }
            public string HinhDaiDien { get; set; }
            public int DoUuTien { get; set; }
            public int KichHoat { get; set; }
            public string GhiChu { get; set; }
            public string DuongDanThanThien { get; set; }
            public string TieuDe { get; set; }
            public string NoiDungTomTat { get; set; }
            public int TrangThai { get; set; }
            public string NgayTao { get; set; }
            public int Nam { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public double ThoiGianBatDau { get; set; }
            public double ThoiGianKetThuc { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int LoaiBaoCao { get; set; }

        }
    }
    #endregion
    public class ChiTietBaoCaoSoNongNghiepModel
    {
        public SoNongNghiepOutput.DocThongTin ThongTin { get; set; }
        public List<SoNongNghiepOutput.DocThongTin> DanhSach { get; set; }
        public string KetQua { get; set; }
        public ChiTietBaoCaoSoNongNghiepModel()
        {
            DanhSach = new List<SoNongNghiepOutput.DocThongTin>();
        }
    }
    #region Bài viết cho người dân
    public class DuLieuBaiVietChoNguoiDanModel
    {
        public List<BaiVietChoNguoiDanOutput> DuLieu { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int KetQua { get; set; }
        public string GhiChu { get; set; }
    }
    public class BaiVietChoNguoiDanOutput
    {
        public string TieuDe { get; set; }
        public string TuKhoa { get; set; }
        public string DuongDanThanThien { get; set; }
        public string NoiDungTomTat { get; set; }
        public string NoiDung { get; set; }
        public string HinhDaiDien { get; set; }
        public int DoUuTien { get; set; }
        public int TrangThai { get; set; }
        public double ThoiGianBatDau { get; set; }
        public double ThoiGianKetThuc { get; set; }
        public string Id { get; set; }
    }
    #endregion
    #region Năm Tháng Tuần
    public class ThongTinNamOutput
    {
        public string Id { get; set; }
        public string ChuoiNam { get; set; }
        public int Nam { get; set; }
        public bool NamHienTai { get; set; }
    }
    public class NamOutput
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public string Ma { get; set; }
        public bool NamHienTai { get; set; }
    }
    public class DanhSachTuan
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
    public class ThongTinTuanOutput
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
    public class TuanOutput
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public bool TuanHienTai { get; set; }
    }
    #endregion
}