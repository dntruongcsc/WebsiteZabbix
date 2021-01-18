using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectStructure.Helpers
{
    #region Dùng chung
    public class ChungThuc
    {
        [ScaffoldColumn(false)]
        public string TokenNguoiDung { get; set; }
        [ScaffoldColumn(false)]
        public string TokenApi { get; set; }
    }

    public class XoaInput : ChungThuc
    {
        public string Id { get; set; }
    }
    public class XoaDanhSachInput : ChungThuc
    {
        public List<string> DanhSachId { get; set; }
    }
    public class XoaDanhSachInput2 : ChungThuc// Đủ thêm
    {
        public List<string> Ids { get; set; }
    }
    public class DocThongTinInput : ChungThuc
    {
        public string Id { get; set; }
    }
    public class DangNhapTheoIdNguoiDungInput : ChungThuc
    {
        public string IdNguoiDung { get; set; }
    }
    public class ThongTinTuanInput : ChungThuc// Đủ thêm
    {
        public int Nam { get; set; }
    }
    public class DocDanhSachInput : ChungThuc {
        public List<string> DanhSachIdDonVi { get; set; }
    }
    public class DocDanhSachInputKT {
        public List<string> DanhSachIdDonVi { get; set; }
    }
    public class DocDanhSachTheoCapChaInput : ChungThuc
    {
        public string IdCha { get; set; }
    }

    public class DocDanhSachPhanTrangInput : ChungThuc
    {
        public int SoDong { get; set; }
        public int DongBatDau { get; set; }
    }
    public class TimKiemInput : ChungThuc
    {
        public string TuKhoa { get; set; }
    }
    public class TimKiemNguoiDungInput : TimKiemInput
    {
        public string IdDonVi { get; set; }
    }
    public class DocThongTinTaiKhoanInput : ChungThuc
    {
        public string Ma { get; set; }
        public string IdDonVi { get; set; }
    }
    public class NapTienInput : ChungThuc
    {
        public string Ma { get; set; }
        public string IdDonVi { get; set; }
        public string MaTheCao { get; set; }
    }
    public class CauHinhInput : ChungThuc
    {
        public string Ma { get; set; }
        public string IdDonVi { get; set; }
        public bool KiemTraTaiKhoan { get; set; }
        public bool ThucHienGiamSat { get; set; }
        public long ChuKyKiemTraTaiKhoan { get; set; }
        public long ChuKyGiamSat { get; set; }
        public long ChuKyDocThongTinCauHinh { get; set; }
    }
    public class GiamSatThietBiInput : ChungThuc
    {
        public string Ma { get; set; }
        public string IdDonVi { get; set; }
        public bool GiamSat { get; set; }
    }
    public class LichSuThietBiGiamSatInput : ChungThuc
    {
        public string Ma { get; set; }
        public bool Ngay { get; set; }
        public bool Tuan { get; set; }
        public bool Thang { get; set; }
    }
    public class DanhSachGiaGiongInput : DocDanhSachPhanTrang
    {
        public string IdTinh { get; set; }
        public string IdNhomSanPham { get; set; }
        public int Nam { get; set; }
        public int Thang { get; set; }
        public int Tuan { get; set; }
    }
    public class DanhSachGiaGiongNgayThemInput : DocDanhSachPhanTrang
    {
        public string IdTinh { get; set; }
        public string IdNhomSanPham { get; set; }
        public string NgayThem { get; set; }
    }
    public class DanhSachGiaGiongIdNgayInput : DocDanhSachPhanTrang
    {
        public string IdTinh { get; set; }
        public string IdNhomSanPham { get; set; }
        public string NgayThem { get; set; }
    }
    public class XoaGiaGiongInput : ChungThuc
    {
        public List<string> Ids { get; set; }
    }
    //set all properties
    public class FindInput : ChungThuc
    {
        public string idsanpham { get; set; }
        public string id { get; set; }// del his price 
        public string IdNhomSanPham { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
    }
    public class DocDanhSachTheoMaChucNang : ChungThuc
    {
        public string MaChucNang { get; set; }
    }
    public class DocLichSuTheoIdSanPham : ChungThuc
    {
        public string IdSanPham { get; set; }
        public string IdTinh { get; set; }
        public string IdQuyCach { get; set; }
        public string IdDonViTinh { get; set; }
        public int Nam { get; set; }
        public int Thang { get; set; }
        public int Tuan { get; set; }
        public string NgayThem { get; set; }
    }
    public class DocLichSuTheoIdSanPhamTheoIdHiepHoi : ChungThuc
    {
        public string IdSanPham { get; set; }
        public string IdHiepHoi { get; set; }
    }
    public class DocLichSuGiaTinhLanCan : ChungThuc
    {
        public int Tuan { get; set; }
        public int Nam { get; set; }
        public string IdQuyCach { get; set; }
        public string IdDonViTinh { get; set; }
        public string IdTinh { get; set; }
        public string IdSanPham { get; set; }
        public string NgayThem { get; set; }
    }
    public class DocLichSuGiaHiepHoi : ChungThuc
    {
        public int Tuan { get; set; }
        public int Nam { get; set; }
        public int Thang { get; set; }
        public string IdQuyCach { get; set; }
        public string IdDonViTinh { get; set; }
        public string IdHiepHoi { get; set; }
        public string IdSanPham { get; set; }
        public string NgayThem { get; set; }
    }
    public class DocLichSuGiaGiongTrongTinh : ChungThuc
    {
        public int Nam { get; set; }
        public int Thang { get; set; }
        public int Tuan { get; set; }
        public string IdTinh { get; set; }
        public string IdSanPham { get; set; }
        public string IdQuyCach { get; set; }
        public string IdDonViTinh { get; set; }
        public string IdCapGiong { get; set; }
        public string IdChieuCao { get; set; }
        public string IdCoBau { get; set; }
        public string IdKichCo { get; set; }
        public string IdNgayTuoi { get; set; }
        public string NgayThem { get; set; }
    }
    public class DocDanhSachThietBiInput : ChungThuc
    {
        public string IdHuyen { get; set; }
        public string IdXa { get; set; }
    }
    public class XoaLichSuGiaSanPham : ChungThuc
    {
        public string Id { get; set; }
    }
    public class XoaLichSuGia : ChungThuc
    {
        public string Id { get; set; }
    }
    public class DocDanhSachTheoDanhSachIdInput : ChungThuc
    {
        public List<string> DanhSachId { get; set; }
    }
    public class DocDanhSachTheoIdInput : ChungThuc
    {
        public string Id { get; set; }
    }
    public class DocDanhSachPhanTrang : ChungThuc
    {
        public int ViTriBatDau { get; set; }
        public int ViTriKetThuc { get; set; }
    }

    #endregion

    #region Nhóm chức năng
    public class NhomChucNangInput : ChungThuc
    {
        public string Id { get; set; }
        [Display(Name = "Tên nhóm chức năng")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
        public string Ten { get; set; }
        [Display(Name = "Danh sách chức năng")]
        public List<ChucNang> DanhSachChucNang { get; set; }
        public NhomChucNangInput()
        {
            DanhSachChucNang = new List<ChucNang>();
        }
        public class ChucNang
        {
            public string IdChucNang { get; set; }
            public string IdChucNangCha { get; set; }
        }
    }

    #endregion

    #region Chức năng
    // 05-12-2017
    public class ChucNangInput : ChungThuc
    {
        public string Id { get; set; }
        public int Loai { get; set; }
        [Display(Name = "Chức năng cha")]
        [Required(ErrorMessage = "{0} bắt buộc phải chọn")]
        public string IdChucNangCha { get; set; }

        [Display(Name = "Tên chức năng")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string Ten { get; set; }

        [Display(Name = "Biểu tượng")]
        public string BieuTuong { get; set; }

        [Display(Name = "Liên kết")]
        public string LienKet { get; set; }

        [Display(Name = "Kích hoạt")]
        [Range(0, 1, ErrorMessage = "Chỉ chấp nhận hai giá trị là 0 hoặc 1.")]
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
        public List<ChucNangXuLy> DanhSachChucNangXuLy { get; set; }
        public ChucNangInput()
        {
            DanhSachChucNangXuLy = new List<ChucNangXuLy>();
        }
        public class ChucNangXuLy
        {
            public string IdChucNangXuLy { get; set; }
            public int KichHoat { get; set; }
        }
    }
    public class DocThongTinChucNangTheoMa : ChungThuc
    {
        public string Ma { get; set; }
    }
    #endregion

    //29-11-2017
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
    public class DoiMatKhauInput : ChungThuc
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
        [System.ComponentModel.DataAnnotations.Compare("MatKhauMoi", ErrorMessage = "{0} không trùng khớp.")]
        //[Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string NhapLaiMatKhauMoi { get; set; }
    }
    public class DangXuatInput : ChungThuc { }


    public class TaiKhoanInput : ChungThuc
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
        //[System.ComponentModel.DataAnnotations.Compare("MatKhau", ErrorMessage = "{0} không trùng khớp.")]
        public string NhapLaiMatKhau { get; set; }

        [Display(Name = "Kích hoạt")]
        public int KichHoat { get; set; } // Mặc định khi mới tạo là 1
        public List<ChucNang> DanhSachChucNang { get; set; }
        public TaiKhoanInput() { DanhSachChucNang = new List<ChucNang>(); }

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
            //public List<NhomNguoiDungThongTin> NhomNguoiDung { get; set; }
            public bool LaQuanTri { get; set; }
        }
    }
    public class TaiKhoanEditInput : ChungThuc
    {
        public string Id { get; set; }
        [Display(Name = "Tên tài khoản")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
        public string TenTaiKhoan { get; set; }

        //-- reset mật khẩu (28-11-2017)
        [Display(Name = "Mật khẩu")]
        [DataType(dataType: DataType.Password)]

        public string MatKhau { get; set; }

        [Display(Name = "Nhập lại mật khẩu")]
        [DataType(dataType: DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("MatKhau", ErrorMessage = "{0} không trùng khớp.")]
        public string NhapLaiMatKhau { get; set; }
        //--------------------------------------------
        [Display(Name = "Kích hoạt")]
        public int KichHoat { get; set; } // Mặc định khi mới tạo là 1
        public bool LaQuanTri { get; set; }
        public List<TaiKhoanInput.ChucNang> DanhSachChucNang { get; set; }
        public TaiKhoanEditInput() { DanhSachChucNang = new List<TaiKhoanInput.ChucNang>(); }
    }

    #endregion

    #region Đơn vị tính
    public class DonViTinhInput : ChungThuc
    {
        public string Id { get; set; }

        [Display(Name = "Tên đơn vị tính")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
        public string Ten { get; set; }
    }
    public class DocDanhSachDonViTinh : ChungThuc { }
    public class ThemDonViTinhInput : ChungThuc
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public List<string> DanhSachMaChucNang { get; set; }
    }
    #endregion

    #region Nhóm Người Dùng

    public class NhomNguoiDungInput
    {
        public class Them : ChungThuc
        {
            [Display(Name = "Mã Nhóm Người Dùng")]
            [Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
            public string Ma { get; set; }

            [Display(Name = "Tên Nhóm Người Dùng")]
            [Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
            public string Ten { get; set; }

            [Display(Name = "Mô tả")]
            [Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
            public string MoTa { get; set; }

            [Display(Name = "Đơn Vị")]
            public string IdDonVi { get; set; }

            [Display(Name = "Nhóm chức năng")]
            public string IdNhomChucNang { get; set; }
        }

        public class Sua : ChungThuc
        {
            public string Id { get; set; }

            [Display(Name = "Mã Nhóm Người Dùng")]
            [Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
            public string Ma { get; set; }

            [Display(Name = "Tên Nhóm Người Dùng")]
            [Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
            public string Ten { get; set; }

            [Display(Name = "Mô tả")]
            [Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
            public string MoTa { get; set; }

            [Display(Name = "Đơn Vị")]
            public string IdDonVi { get; set; }

            [Display(Name = "Nhóm chức năng")]
            public string IdNhomChucNang { get; set; }
        }
    }

    #endregion

    #region Người dùng

    public class NguoiDungInput : ChungThuc
    {
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
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
        [Display(Name = "Thuộc vai trò")]
        public List<string> DanhSachIdVaiTro { get; set; }

        [Display(Name = "Tên tài khoản")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập.")]
        public string TenTaiKhoan { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(dataType: DataType.Password)]
        public string MatKhau { get; set; }

        [Display(Name = "Nhập lại mật khẩu")]
        [DataType(dataType: DataType.Password)]
        public string NhapLaiMatKhau { get; set; }

        [Display(Name = "Kích hoạt")]
        public int KichHoat { get; set; } // Mặc định khi mới tạo là 1

        [Display(Name = "Là quản trị")]
        public bool LaQuanTri { get; set; }
        [Display(Name = "Kích hoạt")]
        public List<ChucNang> DanhSachChucNang { get; set; }
        public NguoiDungInput()
        {
            DanhSachChucNang = new List<ChucNang>();
        }
        public class ChucNang
        {
            public string IdChucNang { get; set; }
            public string IdChucNangCha { get; set; }
        }
    }

    #endregion

    #region tin tức
    public class chiTietTinTucInPut : ChungThuc
    {
        public string Id { get; set; }
    }
    public class TinTuc : ChungThuc
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
        [MinLength(10, ErrorMessage = "{0} bắt buộc phải nhập")]
        public string NoiDungChiTiet { get; set; }
        [Display(Name = "Loại tin tức")]
        public string IdLoaiTin { get; set; }
        public string IdNguoiTao { get; set; }
        public List<HinhAnh> DanhSachHinhAnh { get; set; }

        public double ThoiGianTao { get; set; }
        public double ThoiGianCapNhat { get; set; }
        /// <summary>
        /// true(hiện)/false(ẩn)
        /// </summary>
        [Display(Name = "Đường dẫn")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string DuongDan { get; set; }
        [Display(Name = "Đặt làm tin chính")]
        public bool TinChinh { get; set; }
        [Display(Name = "Đặt làm tin nổi bật")]
        public bool TinNoiBat { get; set; }
        [Display(Name = "Xuất bản")]
        public bool TrangThai { get; set; }
    }
    public class HinhAnh
    {
        public string Ten { get; set; }
        public string ChieuDai { get; set; }
        public string ChieuRong { get; set; }
        public string DungLuong { get; set; }
        public string DuongDan { get; set; }
    }
    public class LuuTruHinhAnh : ChungThuc
    {
        public List<HinhAnhinput> DanhSachHinhAnh { get; set; }
    }
    public class HinhAnhinput
    {
        public byte[] DuLieu { get; set; }
        public string KieuDuLieu { get; set; }
    }
    public class TinTucTimKiemInPut : ChungThuc
    {
        public string IdLoaiTin { get; set; }
        public string IdNguoiTao { get; set; }
        public double ThoiGianTao { get; set; }
        public double ThoiGianCapNhat { get; set; }
    }
    public class TinTucTimKiemInPutTT : ChungThuc
    {
        public int ViTriBatDau { get; set; }
        public int ViTriKetThuc { get; set; }
        public string IdLoaiTin { get; set; }
        public string TieuDe { get; set; }
    }
    public class docDSTinTucPhanTrangInPut : ChungThuc
    {
        public int ViTriBatDau { get; set; }
        public int ViTriKetThuc { get; set; }
    }
    public class BannerTimKiemInPut : ChungThuc
    {
        public int ViTriBatDau { get; set; }
        public int ViTriKetThuc { get; set; }
        public string TuKhoa { get; set; }
    }

    #endregion

    #region Loai tin tức
    public class LoaiTinTuc : ChungThuc
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public string GhiChu { get; set; }
    }
    #endregion

    #region văn bản
    public class TraCuuVanBanInput : ChungThuc
    {
        public string IdLinhVuc { get; set; }
        public string IdCoQuan { get; set; }
        public double NamBanHanh { get; set; }
        public string TuKhoa { get; set; }
    }
    public class VanBanInPut : ChungThuc
    {
        public string Id { get; set; }
        [Display(Name = "Số/Kí hiệu")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string SoKiHieu { get; set; }
        [Display(Name = "Ngày ban hành")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public double NgayBanHanh { get; set; }
        [Display(Name = "Ngày có hiệu lực")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public double NgayCoHieuLuc { get; set; }
        [Display(Name = "Trích yếu")]
        public string TrichYeu { get; set; }
        [Display(Name = "Lĩnh vực")]
        public string IdLinhVuc { get; set; }
        [Display(Name = "Cơ quan")]
        public string IdCoQuan { get; set; }
        [Display(Name = "Phân loại")]
        public string PhanLoai { get; set; }
        [Display(Name = "Người ký")]
        public string NguoiKy { get; set; }
        public List<TapTinVanBanInPut> DanhSachTapTin { get; set; }

        /// <summary>
        /// true(hiện)/false(ẩn)
        /// </summary>
        public bool TrangThai { get; set; }
    }
    public class TapTinVanBanInPut
    {
        public string Ten { get; set; }
        public string Loai { get; set; }
        public string DungLuong { get; set; }
        public string DuongDan { get; set; }
    }
    #endregion

    #region banner
    public class BannerInput : ChungThuc
    {
        public string Id { get; set; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string Ten { get; set; }

        public List<HinhAnh> DanhSachHinhAnh { get; set; }

        [Display(Name = "Liên kết")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string LienKet { get; set; }
        [Display(Name = "Ví trí")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public bool ViTri { get; set; }
        [Display(Name = "Thứ tự")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public int ThuTu { get; set; }
        public bool TrangThai { get; set; }
    }
    public class docDSBannerPhanTrangInPut : ChungThuc
    {
        public int ViTriBatDau { get; set; }
        public int ViTriKetThuc { get; set; }
    }
    public class dieuKienGetBannerIDInPut : ChungThuc
    {
        public string Id { get; set; }
    }
    #endregion

    #region bannerLienKet
    public class BannerLienKetInput : ChungThuc
    {
        public string Id { get; set; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string Ten { get; set; }


        [Display(Name = "Liên kết")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public string LienKet { get; set; }

        [Display(Name = "Thứ tự")]
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        public int ThuTu { get; set; }

        public bool TrangThai { get; set; }
    }
    #endregion

    #region menu
    public class NhomTinInput : ChungThuc
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

    #region Thông tin khuyến nông

    public class PhanTrangInput
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
    }
    public class TimKiemTheoTuKhoaPhanTrang : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
    }

    #region Thông báo khẩn
    public class ThongBaoKhanInput : ChungThuc
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Đường dẫn")]
        public string DuongDanThanThien { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }
        [AllowHtml]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Hình đại diện")]
        public string HinhDaiDien { get; set; }
        [Display(Name = "Thông báo")]
        public bool DoUuTien { get; set; }
        [Display(Name = "Trạng thái")]
        public bool TrangThai { get; set; }
        public string IdNguoiTao { get; set; }
        public string IdNguoiCapNhat { get; set; }
        public string TenNguoiTao { get; set; }
        public string TenNguoiCapNhat { get; set; }
    }
    public class ThongBaoKhanInput2 : ChungThuc //Độ ưu tiên và trạng thái kiểu int
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Đường dẫn")]
        public string DuongDanThanThien { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }
        [AllowHtml]//Cho phép truyền html
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Hình đại diện")]
        public string HinhDaiDien { get; set; }
        [Display(Name = "Thông báo")]
        public int DoUuTien { get; set; }
        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }
        public string IdNguoiTao { get; set; }
        public string IdNguoiCapNhat { get; set; }
        public string TenNguoiTao { get; set; }
        public string TenNguoiCapNhat { get; set; }
    }
    public class ThongBaoKhanModel : PhanTrangInput
    {
        public List<ThongBaoKhanInput> DanhSachThongBaoKhan { get; set; }
        public ThongBaoKhanInput ThongBaoKhanHienTai { get; set; }
        public ThongBaoKhanModel()
        {
            DanhSachThongBaoKhan = new List<ThongBaoKhanInput>();
            ThongBaoKhanHienTai = new ThongBaoKhanInput();
        }

    }
    public class ThongBaoKhanModelKT : PhanTrangInput
    {
        public List<ThongBaoKhanOutput> DanhSachThongBaoKhan { get; set; }
        public ThongBaoKhanModelKT()
        {
            DanhSachThongBaoKhan = new List<ThongBaoKhanOutput>();
        }

    }
    #endregion
    #region Thời tiết nông vụ
    public class ThoiTietNongVuInput : ChungThuc
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Đường dẫn")]
        public string DuongDanThanThien { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }
        [AllowHtml]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Hình đại diện")]
        public string HinhDaiDien { get; set; }
        [Display(Name = "Thông báo")]
        public bool DoUuTien { get; set; }
        [Display(Name = "Trạng thái")]
        public bool TrangThai { get; set; }
        public string NgayTao { get; set; }
        public string IdNguoiTao { get; set; }
        public string IdNguoiCapNhat { get; set; }
        public string TenNguoiTao { get; set; }
        public string TenNguoiCapNhat { get; set; }
    }
    public class ThoiTietNongVuInput2 : ChungThuc
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Đường dẫn")]
        public string DuongDanThanThien { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }
        [AllowHtml]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Hình đại diện")]
        public string HinhDaiDien { get; set; }
        [Display(Name = "Thông báo")]
        public int DoUuTien { get; set; }
        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }
        public string NgayTao { get; set; }
        public string IdNguoiTao { get; set; }
        public string IdNguoiCapNhat { get; set; }
        public string TenNguoiTao { get; set; }
        public string TenNguoiCapNhat { get; set; }
    }
    public class ThoiTietNongVuModelInput : PhanTrangInput
    {
        public List<ThoiTietNongVuInput> DanhSachThoiTietNongVu { get; set; }
        public ThoiTietNongVuInput ThoiTietNongVuHienTai { get; set; }
        public ThoiTietNongVuModelInput()
        {
            DanhSachThoiTietNongVu = new List<ThoiTietNongVuInput>();
            ThoiTietNongVuHienTai = new ThoiTietNongVuInput();
        }

    }
    public class ThoiTietNongVuModelKT : PhanTrangInput
    {
        public List<ThoiTietNongVuOutput> DanhSachThoiTietNongVu { get; set; }
        public ThoiTietNongVuModelKT()
        {
            DanhSachThoiTietNongVu = new List<ThoiTietNongVuOutput>();
        }
    }
    #endregion 
    #region Chỉ đạo điều hành
    public class ChiDaoDieuHanhInput : ChungThuc
    {
        public string Id { get; set; }
        public string IdDonVi { get; set; }
        public string TieuDe { get; set; }
        public string DuongDan { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public bool HienThi { get; set; }
        public bool ThongBaoTBDD { get; set; }
        public bool NoiBat { get; set; }
        public string HinhAnh { get; set; }
        public string TapTinDinhKem { get; set; }
        public string ChuoiNgay { get; set; }
        public string TenDonVi { get; set; }
        public string NgayTao { get; set; }
    }
    public class ChiDaoDieuHanhDocThongTinInput : ChungThuc
    {
        public string Id { get; set; }
    }
    public class ChiDaoDieuHanhDocDanhSach 
    {
        public int TrangHienTai { get; set; }
        public int TongSoDong { get; set; }
        public int TongSoTrang { get; set; }
        public int ViTriBatDau { get; set; }
        public int ViTriKetThuc { get; set; }
        public int TongSoLuong { get; set; }
        public List<ThongTinChiDao> DanhSachThongTinChiDao { get; set; }
        public class ThongTinChiDao : ChiDaoDieuHanhInput { }
        public ChiDaoDieuHanhDocDanhSach()
        {
            DanhSachThongTinChiDao = new List<ThongTinChiDao>();
        }
    }
    public class ChiDaoDieuHanhModelInput : PhanTrangInput
    {
        public List<ChiDaoDieuHanhInput> DanhSachChiDaoDieuHanh { get; set; }
        public ChiDaoDieuHanhModelInput()
        {
            DanhSachChiDaoDieuHanh = new List<ChiDaoDieuHanhInput>();
        }
    }
    public class ChiDaoDieuHanhModelKT : PhanTrangInput
    {
        public List<ChiDaoDieuHanhInput> DanhSachChiDaoDieuHanh { get; set; }
        public ChiDaoDieuHanhOutput ChiTietChiDaoDieuHanh;
        public ChiDaoDieuHanhModelKT()
        {
            DanhSachChiDaoDieuHanh = new List<ChiDaoDieuHanhInput>();
        }
    }
    #endregion
    #region Kỹ thuật nôi trồng
    public class KyThuatNuoiTrongInput : ChungThuc
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Danh sách hình")]
        public string DanhSachHinh { get; set; }
        [Display(Name = "Danh sách tập tin")]
        public string DanhSachTapTin { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }
        [AllowHtml]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Nhóm kỹ thuật nuôi trồng")]
        public string IdNhomKyThuatNuoiTrong { get; set; }
        [Display(Name = "Hình đại diện")]
        public string HinhDaiDien { get; set; }
        [Display(Name = "Độ ưu tiên")]
        public bool DoUuTien { get; set; }
        [Display(Name = "Trạng thái")]
        public bool TrangThai { get; set; }
        [Display(Name = "Kiểu hiển thị")]
        public int HienThiNoiDung { get; set; }
        public string NgayTao { get; set; }
        public string IdNguoiTao { get; set; }
        public string IdNguoiCapNhat { get; set; }
        public string TenNguoiTao { get; set; }
        public string TenNguoiCapNhat { get; set; }

    }
    public class KyThuatNuoiTrongInput2 : ChungThuc
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Danh sách hình")]
        public List<string> DanhSachHinh { get; set; }
        [Display(Name = "Danh sách tập tin")]
        public List<string> DanhSachTapTin { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }
        [AllowHtml]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Nhóm kỹ thuật nuôi trồng")]
        public string IdNhomKyThuatNuoiTrong { get; set; }
        [Display(Name = "Hình đại diện")]
        public string HinhDaiDien { get; set; }
        [Display(Name = "Độ ưu tiên")]
        public int DoUuTien { get; set; }
        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }
        [Display(Name = "Kiểu hiển thị")]
        public int HienThiNoiDung { get; set; }
        public string NgayTao { get; set; }
        public string IdNguoiTao { get; set; }
        public string IdNguoiCapNhat { get; set; }
        public string TenNguoiTao { get; set; }
        public string TenNguoiCapNhat { get; set; }
    }
    public class KyThuatNuoiTrongModelInput : PhanTrangInput
    {
        public List<KyThuatNuoiTrongInput> DanhSachKyThuatNuoiTrong { get; set; }
        public KyThuatNuoiTrongInput KyThuatNuoiTrongHienTai { get; set; }
        public KyThuatNuoiTrongModelInput()
        {
            DanhSachKyThuatNuoiTrong = new List<KyThuatNuoiTrongInput>();
            KyThuatNuoiTrongHienTai = new KyThuatNuoiTrongInput();
        }

    }
    public class KyThuatNuoiTrongModelKT : PhanTrangInput
    {
        public List<KyThuatNuoiTrongInput> DanhSachKyThuatNuoiTrong { get; set; }
        public KyThuatNuoiTrongModelKT()
        {
            DanhSachKyThuatNuoiTrong = new List<KyThuatNuoiTrongInput>();
        }

    }
    public class DocDanhSachTheoIdNhomKyThuatNuoiTrongInput : DocDanhSachPhanTrang
    {
        public string IdNhomKyThuatNuoiTrong { get; set; }
        public string TuKhoa { get; set; }
    }
    public class TimKiemTheoTuKhoaIdNhomKyThuatNuoiTrongInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
        public string IdNhomKyThuatNuoiTrong { get; set; }
    }
    #endregion
    #region Nhóm kỹ thuật nuôi trồng
    public class NhomKyThuatNuoiTrongInput : ChungThuc
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        [Display(Name = "Tên")]
        public string Ten { get; set; }
        [Display(Name = "Icon")]
        public string Icon { get; set; }
        [Display(Name = "Mã")]
        public string Ma { get; set; }
        [Display(Name = "Vị trí")]
        public int ViTri { get; set; }
        [Display(Name = "Kích hoạt")]
        public bool KichHoat { get; set; }
    }
    public class NhomKyThuatNuoiTrongInput2 : ChungThuc
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
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
    public class BanTinTruyenHinhInput : ChungThuc
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Đường dẫn")]
        public string DuongDan { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }
        [AllowHtml]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Nhóm bản tin")]
        public string IdNhomBanTinTruyenHinh { get; set; }
        [Display(Name = "Hình đại diện")]
        public string HinhDaiDien { get; set; }
        [Display(Name = "Đường dẫn video")]
        public string Video { get; set; }
        [Display(Name = "Thông báo cho TBDĐ")]
        public bool DoUuTien { get; set; }
        [Display(Name = "Trạng thái")]
        public bool TrangThai { get; set; }
        public string NgayTao { get; set; }
        public string IdNguoiTao { get; set; }
        public string IdNguoiCapNhat { get; set; }
        public string TenNguoiTao { get; set; }
        public string TenNguoiCapNhat { get; set; }
    }
    public class BanTinTruyenHinhInput2 : ChungThuc
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Đường dẫn")]
        public string DuongDan { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }
        [AllowHtml]
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
    public class BanTinTruyenHinhModelInput : PhanTrangInput
    {
        public List<BanTinTruyenHinhInput> DanhSachBanTinTruyenHinh { get; set; }
        public BanTinTruyenHinhInput BanTinTruyenHinhHienTai { get; set; }
        public BanTinTruyenHinhModelInput()
        {
            DanhSachBanTinTruyenHinh = new List<BanTinTruyenHinhInput>();
            BanTinTruyenHinhHienTai = new BanTinTruyenHinhInput();
        }

    }
    public class DocDanhSachTheoIdNhomBanTinTruyenHinhInput : DocDanhSachPhanTrang
    {
        public string IdNhomBanTinTruyenHinh { get; set; }
    }
    public class TimKiemTheoTuKhoaIdNhomBanTinTruyenHinhInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
        public string IdNhomBanTinTruyenHinh { get; set; }
    }
    #endregion
    #region Nhóm bản tin truyền hình
    public class NhomBanTinTruyenHinhInput : ChungThuc
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        [Display(Name = "Tên")]
        public string Ten { get; set; }
        [Display(Name = "Icon")]
        public string Icon { get; set; }
        [Display(Name = "Mã")]
        public string Ma { get; set; }
        [Display(Name = "Vị trí")]
        public int ViTri { get; set; }
        [Display(Name = "Kích hoạt")]
        public bool KichHoat { get; set; }
    }
    public class NhomBanTinTruyenHinhInput2 : ChungThuc
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
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
    public class NamInput
    {
        public class DocDanhSach : ChungThuc { }
    }
    public class ThangInput
    {
        public class DocDanhSach : ChungThuc { }
    }
    public class TuanInput
    {
        public class DocDanhSach : ChungThuc { }
    }
    #endregion

    #region Tỉnh Huyện Xã Ấp 
    public class HuyenInput
    {
        public class DocDanhSach : ChungThuc
        {
            public string IdTinh { get; set; }
        }
    }

    public class TinhInput
    {
        public class DocDanhSach : ChungThuc
        {
            public string TuKhoa { get; set; }
        }
        public class DocThongTin : ChungThuc
        {
            public string Id { get; set; }
        }
    }
    #endregion

    #region Hộ Nuôi
    public class HoNuoiInput
    {
        public class DanhSachImPort : ChungThuc
        {
            public List<ThongTinImportHoNuoiAo> DanhSachHoNuoi { get; set; }
            public DanhSachImPort()
            {
                DanhSachHoNuoi = new List<ThongTinImportHoNuoiAo>();
            }
        }
        public class ThongTinImportHoNuoiAo
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
            public string TenLoaiHinhKinhTe { get; set; }
            public List<AoInput.AoTheoHoNuoiImport> DanhSachAo { get; set; }
            public List<ThaGiongThuHoach> DanhSachThaGiongThuHoach { get; set; }
            public ThongTinImportHoNuoiAo()
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
                public string GhiChu { get; set; }
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
        public class ThongTinForm
        {
            public string Id { get; set; }
            public string Ho { get; set; }
            public string Ten { get; set; }
            public string DiaChi { get; set; }
            public string DienThoai { get; set; }
            public string NgaySinh { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }
            public int LaToChuc { get; set; }
            public string IdLoaiHinhKinhTe { get; set; }
            public List<string> DanhSachIdHinhThucNuoi { get; set; }//Thêm 15/08/2018
        }
        public class HoNuoiModelInput : PhanTrangInput
        {
            public List<HoNuoiOutput.ThongTinHoNuoi> DanhSachHoNuoi { get; set; }
            public HoNuoiModelInput()
            {
                DanhSachHoNuoi = new List<HoNuoiOutput.ThongTinHoNuoi>();
            }
        }
        public class Them : ChungThuc
        {
            public string Ho { get; set; }
            public string Ten { get; set; }
            public string DiaChi { get; set; }
            public string DienThoai { get; set; }
            public double NgaySinh { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }
            public int LaToChuc { get; set; }
            public string IdLoaiHinhKinhTe { get; set; }
            public List<string> DanhSachIdHinhThucNuoi { get; set; }//Thêm 15/08/2018
            public List<string> DanhSachIdDonVi { get; set; }
            public List<string> DanhSachIdChucNang { get; set; }
            public Them()
            {
                DanhSachIdDonVi = new List<string>();
                DanhSachIdChucNang = new List<string>();
            }
        }
        public class Sua : Them
        {
            public string Id { get; set; }
        }

        public class Xoa : ChungThuc
        {
            public string Id { get; set; }
        }
        public class DocThongTin : ChungThuc
        {
            public string Id { get; set; }
        }
        public class DocDanhSach : ChungThuc { }
        public class DocDanhSachTheoXa : ChungThuc
        {
            public string IdXa { get; set; }
        }
        public class DocDanhSachPhanTrang : ChungThuc
        {
            public int SoDong { get; set; }
            public long DongBatDau { get; set; }
        }
        public class DocDanhSachTheoXaPhanTrang : ChungThuc
        {
            public string IdXa { get; set; }
            public int SoDong { get; set; }
            public long DongBatDau { get; set; }
        }
        public class DocDanhSachTheoDanhSachId : ChungThuc
        {
            public List<string> DanhSachID { get; set; }
        }

        public class DocDanhSachHoNuoiCoDieuKien : ChungThuc
        {
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }
            public int Nam { get; set; }
            public int Tuan { get; set; }
            public string TuKhoa { get; set; }
            public string IdChucNang { get; set; }
        }
        public class DocDanhSachPhanTrang2 : DocDanhSachHoNuoiCoDieuKien
        {
            public int ViTriBatDau { get; set; }
            public int ViTriKetThuc { get; set; }
        }
        public class DocDanhSachTheoChucNang : DocDanhSachHoNuoiCoDieuKien
        {
            public int ViTriBatDau { get; set; }
            public int ViTriKetThuc { get; set; }
            public string IdChucNang { get; set; }
        }

    }
    public class DocDanhSachHoNhuoiAoExport : ChungThuc
    {
        public string IdHuyen { get; set; }
        public string IdXa { get; set; }
        public string IdAp { get; set; }
    }
    #endregion
    #region Dữ liệu nông nghiệp
    public class DuLieuNongNghiepInput
    {
        public class DuLieuCacCapInput
        {
            public class DataXuatBan
            {
                public int Nam { get; set; }
                public int SauThang { get; set; }
                public int Quy { get; set; }
                public int Thang { get; set; }
                public int Tuan { get; set; }
                public string IdHinhThucNuoi { get; set; }
                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }

            }
            public class DataXuatBanInput : ChungThuc
            {
                public int Nam { get; set; }
                public int SauThang { get; set; }
                public int Quy { get; set; }
                public int Thang { get; set; }
                public int Tuan { get; set; }
                public string IdHinhThucNuoi { get; set; }
                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }
                public double NgayLapBaoCao { get; set; }
            }
            public class ThemDanhSach : ChungThuc //09/07/2018
            {
                public List<Them> DanhSachDuLieu { get; set; }
                public ThemDanhSach()
                {
                    DanhSachDuLieu = new List<Them>();
                }
            }
            public class ThemInput //09/07/2018
            {
                public string Id { get; set; }
                public string IdHoNuoi { get; set; }
                public string TenHoNuoi { get; set; }

                //Dùng cho Báo Cáo --2
                public string IdDonVi { get; set; }
                public string TenDonVi { get; set; }

                public int Nam { get; set; }
                public int SauThang { get; set; }
                public int Quy { get; set; }
                public int Thang { get; set; }
                public int Tuan { get; set; }
                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }

                public TongAoNuoi ThongTinTongAoNuoi { get; set; }
                public TongThaGiong ThongTinTongThaGiong { get; set; }
                public TongThuHoach ThongTinTongThuHoach { get; set; }
                public ThemInput()
                {
                    ThongTinTongAoNuoi = new TongAoNuoi();
                    ThongTinTongThaGiong = new TongThaGiong();
                    ThongTinTongThuHoach = new TongThuHoach();
                }
                public bool XuatBan { get; set; }
                public string GhiChu { get; set; }
                public string IdHinhThucNuoi { get; set; }
                public string DiaChi { get; set; }


                public class TongAoNuoi
                {
                    public int SoAo { get; set; }
                    public double DienTich { get; set; }
                }
                public class TongThaGiong
                {
                    public double DienTich { get; set; }
                    public double LuyKeDienTich { get; set; }
                    //public string IdSanPham { get; set; }
                    //public string TenSanPham { get; set; }
                    //public string IdNguonGoc { get; set; }
                    public double NgayTha { get; set; }
                    public double MatDo { get; set; }
                    public string ChuoiNgayTha { get; set; }
                    public List<ThongTinSanPham> DanhSachThongTinSanPham { get; set; }
                    public TongThaGiong()
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
                public class TongThuHoach
                {
                    public double DienTich { get; set; }
                    public double LuyKeDienTich { get; set; }
                    public double SanLuong { get; set; }
                    public string ChuoiNgayThu { get; set; }
                    public double NgayThu { get; set; }
                }
            }
            public class Them //09/07/2018
            {
                public string Id { get; set; }
                public string IdHoNuoi { get; set; }
                public string TenHoNuoi { get; set; }


                //Dùng cho Báo Cáo --2
                public string IdDonVi { get; set; }
                public string TenDonVi { get; set; }

                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }

                public TongAoNuoi ThongTinTongAoNuoi { get; set; }
                public TongThaGiong ThongTinTongThaGiong { get; set; }
                public TongThuHoach ThongTinTongThuHoach { get; set; }
                public Them()
                {
                    ThongTinTongAoNuoi = new TongAoNuoi();
                    ThongTinTongThaGiong = new TongThaGiong();
                    ThongTinTongThuHoach = new TongThuHoach();
                }
                public int LoaiBaoCao { get; set; }
                public bool XuatBan { get; set; }
                public double NgayLapBaoCao { get; set; }
                public string GhiChu { get; set; }
                public string IdHinhThucNuoi { get; set; }
                public string DiaChi { get; set; }


                public class TongAoNuoi
                {
                    public int SoAo { get; set; }
                    public double DienTich { get; set; }
                }
                public class TongThaGiong
                {
                    public double DienTich { get; set; }
                    public double LuyKeDienTich { get; set; }
                    //public string IdSanPham { get; set; }
                    //public string TenSanPham { get; set; }
                    public double NgayTha { get; set; }
                    public double MatDo { get; set; }
                    public string ChuoiNgayTha { get; set; }
                    //public string IdNguonGoc { get; set; }
                    public List<ThongTinSanPham> DanhSachThongTinSanPham { get; set; }
                    public TongThaGiong()
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
                public class TongThuHoach
                {
                    public double DienTich { get; set; }
                    public double LuyKeDienTich { get; set; }
                    public double SanLuong { get; set; }
                    public string ChuoiNgayThu { get; set; }
                    public double NgayThu { get; set; }
                }
            }
            public class ThongTin2 : ChungThuc
            {
                public int Nam { get; set; }
                public int SauThang { get; set; }
                public int Quy { get; set; }
                public int Thang { get; set; }
                public int Tuan { get; set; }
                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }
                public string IdHinhThucNuoi { get; set; }
            }
            public class ThongTin : ChungThuc
            {
                public int Nam { get; set; }
                public int Quy { get; set; }
                public int Thang { get; set; }
                public int Tuan { get; set; }
                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }
                public int LoaiBaoCao { get; set; }
                public string IdHinhThucNuoi { get; set; }
            }
        }
        public class CapTinhHuyen
        {
            public class ThongTinTable
            {
                public string IdBaoCao { get; set; }//Dùng cho cập nhật
                public string IdDonVi { get; set; }
                public string TenDonVi { get; set; }
                public double TongDienTich { get; set; }
                public double DienTichTha { get; set; }
                public double LuyKeTha { get; set; }
                public int SoHoThaNuoi { get; set; }
                public List<TongSanPham> DanhSachDoiTuongTha { get; set; }
                public double SoLuongConThaGiong { get; set; }

                public double DienTichThuHoach { get; set; }
                public double LuyKeThuHoach { get; set; }
                public double SanLuongThuHoach { get; set; }

                public int SoHoCoDienTichBiBenh { get; set; }
                public List<DichBenh> DanhSachDichBenh { get; set; }
                public double DienTichDichBenhTrongKy { get; set; }
                public double LuyKeDichBenh { get; set; }

                public string GhiChu { get; set; }

                public ThongTinTable()
                {
                    DanhSachDoiTuongTha = new List<TongSanPham>();
                    DanhSachDichBenh = new List<DichBenh>();
                }
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
            public class Them : ChungThuc
            {
                public string Id { get; set; }//Dùng cho cập nhật
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

                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }
                public string IdHinhThucNuoi { get; set; }

                public Them()
                {
                    ThongTinTongThaGiong = new TongThaGiong();
                    ThongTinTongDichBenh = new TongDichBenh();
                    ThongTinTongThuHoach = new TongThuHoach();
                    DanhSachTongSanPham = new List<TongSanPham>();
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
            //-----------------------------------------
            public class XuatBan : ChungThuc
            {
                public int LoaiBaoCao { get; set; }
                public double NgayLapBaoCao { get; set; }
                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }
                public string IdHinhThucNuoi { get; set; }
            }
            //-----------------------------------------
        }
        public class ThaGiongThuHoachDichBenh : ChungThuc
        {
            public int LoaiBaoCao { get; set; }
            public double NgayLapBaoCao { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdHinhThucNuoi { get; set; }
            public string NoiDungPheDuyet { get; set; }
        }
        public class CapXa
        {
            public class ThongTinTable
            {
                public string IdBaoCao { get; set; }//Dùng cho cập nhật
                public string IdDonVi { get; set; }
                public string TenDonVi { get; set; }

                public ThongTinDiaChi ThongTinDiaChi { get; set; }
                public int SoAo { get; set; }
                public double DienTichAo { get; set; }

                public int LanTha { get; set; }
                public double DienTichTha { get; set; }
                public double LuyKeTha { get; set; }
                public List<Loai> DanhSachDoiTuongTha { get; set; }
                public string NgayTha { get; set; }
                public double MatDoTha { get; set; }
                public List<NguonGiong> DanhSachNguonGiong { get; set; }

                public int LanThuHoach { get; set; }
                public double DienTichThuHoach { get; set; }
                public double LuyKeThuHoach { get; set; }
                public double SanLuongThuHoach { get; set; }
                public string NgayThuHoach { get; set; }


                public string NgayPhatHienBenh { get; set; }
                public List<DichBenh> DanhSachDichBenh { get; set; }
                public double DienTichThietHai { get; set; }
                public double LuyKeDichBenh { get; set; }

                public string GhiChu { get; set; }

                public ThongTinTable()
                {
                    ThongTinDiaChi = new ThongTinDiaChi();
                    DanhSachDoiTuongTha = new List<Loai>();
                    DanhSachNguonGiong = new List<NguonGiong>();
                    DanhSachDichBenh = new List<DichBenh>();
                }
            }
            public class ThongTinDiaChi
            {
                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }
            }
            public class Loai
            {
                public string Id { get; set; }
                public string Ten { get; set; }
            }
            public class NguonGiong
            {
                public string Id { get; set; }
                public string Ten { get; set; }
            }
            public class DichBenh
            {
                public string IdDichBenh { get; set; }
                public string TenDichBenh { get; set; }
            }
            //-----------------------------------------
            public class Them : ChungThuc
            {
                public string Id { get; set; }//Dùng cho cập nhật
                public string IdHoNuoi { get; set; }
                public string TenHoNuoi { get; set; }

                public double SoAo { get; set; }
                public double DienTichAo { get; set; }

                //public double LanTha { get; set; }
                //public double DienTichTha { get; set; }
                //public double LuyKeTha { get; set; }
                //public List<Loai> DanhSachDoiTuongTha { get; set; }
                //public double NgayTha { get; set; }
                //public double MatDoTha { get; set; }
                //public List<NguonGiong> DanhSachNguonGiong { get; set; }

                //public double LanThuHoach { get; set; }
                //public double DienTichThuHoach { get; set; }
                //public double LuyKeThuHoach { get; set; }
                //public double SanLuongThuHoach { get; set; }
                //public double NgayThuHoach { get; set; }


                //public double NgayPhatHienBenh { get; set; }
                //public List<DichBenh> DanhSachDichBenh { get; set; }
                //public double DienTichThietHai { get; set; }
                //public double LuyKeDichBenh { get; set; }

                public TongAoNuoi ThongTinTongAoNuoi { get; set; }
                public TongThaGiong ThongTinTongThaGiong { get; set; }
                public TongDichBenh ThongTinTongDichBenh { get; set; }
                public TongThuHoach ThongTinTongThuHoach { get; set; }

                public string GhiChu { get; set; }

                /// <summary>
                /// 0 : Tuần, 1 : Tháng, 2 : Quý, 3 : Năm
                /// </summary>
                public int LoaiBaoCao { get; set; }
                /// <summary>
                /// 0 : Ấp, 1 : Xã, 2 : Huyện
                /// </summary>
                public bool XuatBan { get; set; }
                public double NgayLapBaoCao { get; set; }

                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }
                public string IdHinhThucNuoi { get; set; }

                public Them()
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
                public List<ThaGiong> DanhSachThaGiong { get; set; }
                public List<int> DanhSachNguonGiong { get; set; }
                public TongThaGiong()
                {
                    DanhSachThaGiong = new List<ThaGiong>();
                    DanhSachNguonGiong = new List<int>();
                }
                public class ThaGiong
                {
                    public string IdSanPham { get; set; }
                    public string TenSanPham { get; set; }
                    public double NgayTha { get; set; }
                    public double MatDo { get; set; }
                    public string IdTinh { get; set; }
                    public string ChuoiNgayTha { get; set; }
                    public double DienTich { get; set; }
                    public double LuyKeDienTich { get; set; }
                    public int LanTha { get; set; }
                }
            }

            public class TongThuHoach
            {
                public double DienTich { get; set; }
                public double LuyKeDienTich { get; set; }
                public double SanLuong { get; set; }
                public int LanThu { get; set; }
                public string ChuoiNgayThu { get; set; }
                public double NgayThu { get; set; }
                public List<ThuHoach> DanhSachThuHoach { get; set; }
                public TongThuHoach()
                {
                    DanhSachThuHoach = new List<ThuHoach>();
                }
                public class ThuHoach
                {
                    public double DienTich { get; set; }
                    public double LuyKeDienTich { get; set; }
                    public double SanLuong { get; set; }
                    public int LanThu { get; set; }
                    public string ChuoiNgayThu { get; set; }
                    public double NgayThu { get; set; }
                }
            }

            public class TongDichBenh
            {
                public double DienTichThietHai { get; set; }
                public double LuyKeThietHai { get; set; }
                public string ChuoiNgayPhatHien { get; set; }
                public double NgayPhatHien { get; set; }
                public List<DichBenh> DanhSachDichBenh { get; set; }
                public TongDichBenh()
                {
                    DanhSachDichBenh = new List<DichBenh>();
                }
                public class DichBenh
                {
                    public string IdDichBenh { get; set; }
                    public string TenDichBenh { get; set; }
                    public string ChuoiNgayPhatHien { get; set; }
                    public double NgayPhatHien { get; set; }
                    public double DienTichThietHai { get; set; }
                    public double LuyKeThietHai { get; set; }
                }
            }
            //-----------------------------------------
            public class XuatBan : ChungThuc
            {
                public int LoaiBaoCao { get; set; }
                public double NgayLapBaoCao { get; set; }
                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }
                public string IdHinhThucNuoi { get; set; }
            }
            //-----------------------------------------
        }

        public class QuanLyDienTich
        {
            public class ThonginInput : ChungThuc
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
            public class DanhSachInput : ChungThuc
            {
                public List<ThongTinDienTichNuoi> DanhSachDuLieu { get; set; }
                public string MaHinhThucNuoi { get; set; }
                public DanhSachInput()
                {
                    DanhSachDuLieu = new List<ThongTinDienTichNuoi>();
                }
            }
            public class DanhSachQuanLyDienTich
            {
                public List<ThongTinDienTichNuoi> DanhSachNuoiQuangCanhCaiTien { get; set; }
                public List<ThongTinDienTichNuoi> DanhSachNuoiCongNghiep { get; set; }
                public List<ThongTinDienTichNuoi> DanhSachNuoiSieuThamCanh { get; set; }
                public int Loai { get; set; }
                public DanhSachQuanLyDienTich()
                {
                    DanhSachNuoiQuangCanhCaiTien = new List<ThongTinDienTichNuoi>();
                    DanhSachNuoiCongNghiep = new List<ThongTinDienTichNuoi>();
                    DanhSachNuoiSieuThamCanh = new List<ThongTinDienTichNuoi>();
                }
            }
            public class SoLuongDienTich
            {
                public double SoAo { get; set; }
                public double DienTich { get; set; }

            }
            public class ThongTinDienTichNuoi
            {
                public string Id { get; set; }
                public string IdDonVi { get; set; }
                public string TenDonVi { get; set; }
                public string IdHuyen { get; set; }
                public string IdXa { get; set; }
                public string IdAp { get; set; }
                public int Nam { get; set; }
                public int SauThang { get; set; }
                public int Quy { get; set; }
                public int Thang { get; set; }
                public int Tuan { get; set; }
                public double TongSoHo { get; set; }
                public double TongDienTich { get; set; }
                public double TongSoAo { get; set; }
                public double LuyKeTongSoHo { get; set; }
                public double LuyKeTongDienTich { get; set; }
                public int LuyKeTongSoAo { get; set; }

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
                public double QC_DienTichNuoiCaMu { get; set; }
                public double QC_DienTichNuoiCaBop { get; set; }
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

            public class ThongTinDuyetCapTinhInput : ChungThuc
            {
                public int LoaiBaoCao { get; set; }
                public string IdHinhThucNuoi { get; set; }
                public int Nam { get; set; }
                public int SauThang { get; set; }
                public int Quy { get; set; }
                public int Thang { get; set; }
                public int Tuan { get; set; }
            }
        }
    }
    #endregion
    #region Ao nuôi - Thả giống - Thu hoạch - Dịch bệnh
    public class AoInput
    {

        public class ThongTinForm
        {
            //Ao
            public string IdHoNuoi { get; set; }
            public string IdAoNuoi { get; set; }
            public string Ao_DienTich { get; set; }
            public string Ao_HinhThucNuoi { get; set; }
            public string Ao_TinhTrang { get; set; }
            public string Ao_Ten { get; set; }
            //Thả Giống
            public string IdThaGiong { get; set; }
            public int LanTha { get; set; }
            public string ThaGiong_NguonGiong { get; set; }
            public string ThaGiong_DienTichTha { get; set; }
            public string ThaGiong_LuyKe { get; set; }
            public string ThaGiong_LoaiThuySan { get; set; }
            public string ThaGiong_NgayTha { get; set; }
            public string ThaGiong_MatDo { get; set; }
            public string ThaGiong_IdTinh { get; set; }
            public int ThaGiong_TrangThai { get; set; }
            public string ThaGiong_GhiChu { get; set; }
            //Thu hoạch
            public string IdThuHoach { get; set; }
            public int LanThu { get; set; }
            public string ThuHoach_DienTich { get; set; }
            public string ThuHoach_SanLuong { get; set; }
            public string ThuHoach_NgayThuHoach { get; set; }
            public int ThuHoach_TrangThai { get; set; }
            //Dịch bệnh
            public string IdDichBenh { get; set; }
            public string DichBenh_TenBenh { get; set; }
            public string DichBenh_DienTichThietHai { get; set; }
            public string DichBenh_NgayPhatHien { get; set; }
            public int DichBenh_TrangThai { get; set; }
            public string DichBenh_GhiChu { get; set; }
        }
        public class ThongTinAo
        {
            public class Them : ChungThuc
            {
                public string Ma { get; set; }
                public double DienTich { get; set; }
                public string IdHinhThucNuoi { get; set; }
                public string IdHoNuoi { get; set; }
                public string IdTinhTrang { get; set; }
                public string Ten { get; set; }
                public string IdSanPham { get; set; }
            }
            public class Sua : Them
            {
                public string Id { get; set; }
            }
            public class Xoa : ChungThuc
            {
                public string Id { get; set; }
            }

            public class DocDanhSachNamTuanIdAo : ChungThuc
            {
                public string IdAo { get; set; }
                public int Nam { get; set; }
                public int Tuan { get; set; }
            }
            public class DocThongTin : ChungThuc
            {
                public string Id { get; set; }
            }
            public class DocDanhSach : ChungThuc { }
        }
        //---------------------------------------------
        //new 05/07/2018
        //---------------------------------------------
        public enum DieuKienNuoi
        {
            Khong, HanChe, DamBao //0:Không, 1: Hạn chế, 2: Đảm bảo
        }
        public class DanhSachThongTinAoTheoHoNuoi : ChungThuc
        {
            public List<AoTheoHoNuoi> DanhSachDulieu { get; set; }
            public DanhSachThongTinAoTheoHoNuoi()
            {
                DanhSachDulieu = new List<AoTheoHoNuoi>();
            }
        }
        public class DanhSachThongTinAoBaoCaoHoNuoi : ChungThuc
        {
            public List<BaoCaoHoNuoi> DanhSachDuLieu { get; set; }
            public DanhSachThongTinAoBaoCaoHoNuoi()
            {
                DanhSachDuLieu = new List<BaoCaoHoNuoi>();
            }
        }
        public class ThongTinLocHoNuoi : ChungThuc
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
        public class AoTheoHoNuoiImport : AoTheoHoNuoi
        {
            public string TenHinhThucNuoi { get; set; }
            public string TenTinhTrang { get; set; }
            public string IdLoaiHinhKinhTe { get; set; }

            public string TenLoaiHinhKinhTe { get; set; }
        }
        public class BaoCaoHoNuoi : ChungThuc
        {
            public string Id { get; set; }
            public string IdDonVi { get; set; }

            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }

            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdHinhThucNuoi { get; set; }

            public int TongSoHo { get; set; }
            public double TongDienTich { get; set; }
            public int TongSoAo { get; set; }
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

            public bool XuatBan { get; set; }
            public string GhiChu { get; set; }
            public int TrangThai { get; set; }
            public int LoaiDonViBaoCao { get; set; }
            public BaoCaoHoNuoi()
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
        }
        public class AoTheoHoNuoi : ChungThuc
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
        public class ThongTinHoNuoi
        {
            public string Id { get; set; }
            public string HoTen { get; set; }
            public string NamSinh { get; set; }
            public string DienThoai { get; set; }
        }
        public class SoLuongDienTich
        {
            public int SoAo { get; set; }
            public double DienTich { get; set; }

        }
        #region Thả giống thu hoạch new 09/07/2017
        public class HoNuoiThaGiongThuHoach : ChungThuc
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }
            public string IdHinhThucNuoi { get; set; }
            public string MaChucNang { get; set; }
        }
        #endregion
        #region Ao nuôi
        public class DocDanhSachAoNuoi : ChungThuc
        {
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }
            public string IdHinhThucNuoi { get; set; }
        }
        #endregion
        //---------------------------------------------
        public class ThaGiong
        {
            public class Them : ChungThuc
            {
                public string IdAo { get; set; }
                public double DienTich { get; set; }
                public double LuyKe { get; set; }
                public string IdSanPham { get; set; }
                public double NgayTha { get; set; }
                public double MatDo { get; set; }
                /// <summary>
                /// IdTinh:
                ///     0:Trong tỉnh
                ///     1:Ngoài tỉnh
                /// </summary>
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
            public class Sua : Them
            {
                public string Id { get; set; }
                public int LanTha { get; set; }
            }
            public class DocThongTin : ChungThuc
            {
                public string Id { get; set; }
            }
            public class DocDanhSach : ChungThuc
            {
                public string IdAo { get; set; }
                public int Nam { get; set; }
                public int Tuan { get; set; }
            }
        }
        public class ThuHoach
        {
            public class Them : ChungThuc
            {
                public double DienTich { get; set; }
                public double SanLuong { get; set; }
                public double NgayThuHoach { get; set; }
                public string IdAo { get; set; }
                /// <summary>
                /// TrangThai:
                ///     0: thả giống
                ///     1: đang thu hoạch
                ///     2: đã thu hoạch xong
                /// </summary>
                public int TrangThai { get; set; }
            }
            public class Sua : Them
            {
                public string Id { get; set; }
                public int LanThu { get; set; }
            }
            public class DocThongTin : ChungThuc
            {
                public string Id { get; set; }
            }
            public class DocDanhSach : ChungThuc
            {
                public string IdAo { get; set; }
                public int Nam { get; set; }
                public int Tuan { get; set; }
            }
        }
        public class DichBenh
        {
            public class Them : ChungThuc
            {
                public string IdAo { get; set; }
                public string IdDichBenh { get; set; }
                public double DienTichThietHai { get; set; }
                public double NgayPhatHien { get; set; }

                /// <summary>
                /// TrangThai:
                ///     0: chua khac phuc
                ///     1: dang khac phuc
                ///     2: da khac phuc
                /// </summary>
                public int TrangThai { get; set; }
                public string GhiChu { get; set; }
            }
            public class Sua : Them
            {
                public string Id { get; set; }
            }
            public class Xoa : ChungThuc
            {
                public string Id { get; set; }
            }
            public class XoaDanhSach : ChungThuc
            {
                public List<string> DanhSachId { get; set; }
            }
            public class DocThongTin : ChungThuc
            {
                public string Id { get; set; }
            }
            public class DocDanhSach : ChungThuc
            {
                public string IdAo { get; set; }
                public int Nam { get; set; }
                public int Tuan { get; set; }
            }
        }
    }
    #endregion

    #region Đơn vị
    public class DonViInput
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
        public class Them : ChungThuc
        {
            public string Ten { get; set; }
            public string DiaChi { get; set; }
            public string DienThoai { get; set; }
            public string Email { get; set; }
            public string Fax { get; set; }
            public string Logo { get; set; }
            public string IdDonViTrucThuoc { get; set; }
            public int Cap { get; set; }
            public CauHinhEmail CauHinhEmail { get; set; }
            public List<string> DanhSachIdTinh { get; set; }
            public List<string> DanhSachIdHuyen { get; set; }
            public List<string> DanhSachIdXa { get; set; }
            public List<string> DanhSachIdAp { get; set; }
        }
        public class Sua : Them
        {
            public string Id { get; set; }
        }
        public class DocThongTin : ChungThuc
        {
            public string Id { get; set; }
        }
        public class DocDanhSachTuDonViCha : ChungThuc
        {
            public string IdDonViCha { get; set; }
            public bool VaiTroQuanTri { get; set; }
        }
        public class DocDanhSachTuDonViChaCoPhanTrang : DocDanhSachPhanTrangInput
        {
            public string IdDonViCha { get; set; }
            public bool VaiTroQuanTri { get; set; }
        }
    }
    #endregion
    #region Sản phẩm
    public class SanPhamInput
    {
        public class Them : ChungThuc
        {
            public string Id { get; set; }
            public string Ma { get; set; }
            public string Ten { get; set; }
            public string NguonGoc { get; set; }
            public List<string> DanhSachIdQuyCach { get; set; }
            public List<string> DanhSachIdDonViTinh { get; set; }
            public string IdNhomSanPham { get; set; }
            public string IdNhomSanPhamCon { get; set; }
            public int ViTri { get; set; }
            public string MoTa { get; set; }
            public bool KichHoat { get; set; }
            public string DacTinh { get; set; }
            public string IdKyThuatNuoiTrong { get; set; }
            public List<ThongTin> DanhSachThongTinSanPham { get; set; }
            public class ThongTin
            {
                public string IdDonViTinh { get; set; }
                public string IdQuyCach { get; set; }
                public string IdCapGiong { get; set; }
                public string IdChieuCao { get; set; }
                public string IdNgayTuoi { get; set; }
                public string IdCoBau { get; set; }
                public string IdKichCo { get; set; }
            }
        }
        public class Sua : Them
        {
            public string Id { get; set; }
        }
        public class DocThongTin : ChungThuc
        {
            public string Id { get; set; }
            public string Ma { get; set; }
        }
        public class DocThongTinTheoChucNangVaBieuMau : ChungThuc
        {
            public string IdChucNang { get; set; }
            public string IdBieuMauBaoCao { get; set; }
        }
        public class DocDanhSachTheoIdNhomSanPham : ChungThuc
        {
            public string IdNhomSanPham { get; set; }
        }
        public class DocDanhSachTheoDanhSachIdNhomInput : ChungThuc
        {
            public int ViTriBatDau { get; set; }
            public int ViTriKetThuc { get; set; }
            public List<string> Ids { get; set; }
            public string IdBieuMau { get; set; }
            public string IdBieuMauCon { get; set; }
            public string TuKhoa { get; set; }
        }
        public class XoaDanhSach : ChungThuc
        {
            public List<string> Ids { get; set; }
        }
    }
    #endregion
    #region Nhóm sản phẩm
    public class NhomSanPhamInput
    {
        public class DocDanhSach : ChungThuc
        {

        }
        public class DocDanhSachTheoIdNhomSanPham : DocDanhSach
        {
            public string IdNhomSanPham { get; set; }
        }
        public class DocNhomSanPhamTheoMaSanPham : DocDanhSach
        {
            public string Ma { get; set; }
        }
        public class DocDanhSachTheoIdChucNang : DocDanhSach
        {
            public string IdChucNang { get; set; }
        }
    }
    #endregion
    #region Quy cách
    public class QuyCachInput
    {
        public class DocDanhSach : ChungThuc { }
        public class Them : ChungThuc
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public List<string> DanhSachMaChucNang { get; set; }
        }
    }
    #endregion
    #region 
    public class DocDanhSachSanPhamTheoNhomSanPhamInput : ChungThuc
    {
        public string IdNhomSanPham { get; set; }
    }
    #endregion
    #region Thêm giá thị trường trong tỉnh
    public class GiaThiTruongTrongTinh : ChungThuc
    {
        public string IdAp { get; set; }
        public string IdXa { get; set; }
        public string IdHuyen { get; set; }
        public string IdTinh { get; set; }
        public string IdSanPham { get; set; }
        public float GiaThuMuaTu { get; set; }
        public float GiaThuMuaDen { get; set; }
        public float GiaBanLeTu { get; set; }
        public float GiaBanLeDen { get; set; }
    }
    public class ReadParamProvince : DocDanhSachPhanTrang
    {
        public string IdNhomSanPham { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public string Tuan { get; set; }
        public string Nam { get; set; }

    }
    public class GiaCaThiTruongTrongTinhIntput : ChungThuc
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

        public bool TuanHienTai { get; set; }
        public double Ngay { get; set; }
        public string ChuoiNgay { get; set; }
        public string Id { get; set; }
        public bool XuatBan { get; set; }
    }
    public class GiaCaThiTruongInput
    {
        public class ThemGiaTrongTinhInput : ChungThuc
        {
            public string IdAp { get; set; }
            public string IdXa { get; set; }
            public string IdHuyen { get; set; }
            public string IdTinh { get; set; }
            public string IdSanPham { get; set; }
            public string IdQuyCach { get; set; }
            public string IdDonViTinh { get; set; }
            public float GiaThuMuaTu { get; set; }
            public float GiaThuMuaDen { get; set; }
            public float GiaBanLeTu { get; set; }
            public float GiaBanLeDen { get; set; }
            public int Nam { get; set; }
            public int Tuan { get; set; }
            public string Id { get; set; }
            public double NgayNhap { get; set; }
            public string NgayThem { get; set; }
        }
    }
    public class GiaTrongTinhModelInput : PhanTrangInput
    {
        public List<GiaCaThiTruongTrongTinhIntput> DanhSachGiaTrongTinh { get; set; }
        public GiaCaThiTruongTrongTinhIntput GiaHienTaiTrongTinh { get; set; }
        public GiaTrongTinhModelInput()
        {
            DanhSachGiaTrongTinh = new List<GiaCaThiTruongTrongTinhIntput>();
            GiaHienTaiTrongTinh = new GiaCaThiTruongTrongTinhIntput();
        }
        public class DuLieuGia : DuLieuOutputModel
        {
            public List<SanPhamOutput.DocDanhSachTheoIdNhomSanPham> ListLoai { get; set; }
            public List<GiaCaThiTruongTrongTinhIntput> ListDanhSach { get; set; }
        }
        public class DuLieuGiaKT : DuLieuOutputModel
        {
            public List<NhomSanPhamOutput.ThongTinNhomSanPham> ListNhomSanPham { get; set; }
            public List<GiaCaThiTruongTrongTinhIntput> ListDanhSach { get; set; }
        }
    }
    #endregion

    #region GIÁ Hiệp hội
    public class GiaCaThiTruongGiaHiepHoiIntput : ChungThuc
    {
        //public string IdAp { get; set; }
        //public string IdXa { get; set; }
        //public string IdHuyen { get; set; }
        //public string IdTinh { get; set; }


        //public string IdNhomSanPham { get; set; }
        //public string TenNhomSanPham { get; set; }
        //public string IdSanPham { get; set; }
        //public string TenSanPham { get; set; }
        //public string IdDonViTinh { get; set; }
        //public string TenDonViTinh { get; set; }
        //public string IdQuyCach { get; set; }
        //public string TenQuyCach { get; set; }

        //public float GiaThuMuaTu { get; set; }
        //public float GiaThuMuaDen { get; set; }
        //public float GiaBanLeTu { get; set; }
        //public float GiaBanLeDen { get; set; }

        //public bool TuanHienTai { get; set; }
        //public double Ngay { get; set; }
        //public string ChuoiNgay { get; set; }
        //public string Id { get; set; }
        public string IdHiepHoi { get; set; }
        public string TenHiepHoi { get; set; }
        public bool TuanHienTai { get; set; }

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
    public class DuLieuGiaHiepHoiKT : DuLieuOutputModel
    {
        public List<GiaCaThiTruongGiaHiepHoiIntput> DanhSachGiaHiepHoi { get; set; }
        public List<NhomSanPhamOutput.ThongTinNhomSanPham> ListNhomSanPham { get; set; }
    }
    #endregion

    #region Phản ánh nhanh
    public class PhanAnhNhanhInput
    {
        public class DocDanhSachInput : ChungThuc
        {
            public string Id { get; set; }
            public string IdLoaiPhanAnhNguoiDan { get; set; }
            public int ViTriBatDau { get; set; }
            public int ViTriKetThuc { get; set; }
            public string DiaChi { get; set; }
            public string IdAp { get; set; }
            public string IdXa { get; set; }
            public string IdHuyen { get; set; }
            public double NgayBatDau { get; set; }
            public double NgayKetThuc { get; set; }
        }
        public class CapNhatPhanAnhInput : ChungThuc
        {
            public string Id { get; set; }
            public int TrangThai { get; set; }
            public bool XuatBan { get; set; }
            public string NoiDungPhanHoi { get; set; }
            public List<TapTin> DanhSachTapTin { get; set; }
            public class TapTin
            {
                public string Ten { get; set; }
            }
        }
        public class Them : ChungThuc
        {
            public string Id { get; set; }
            public string TieuDe { get; set; }
            public string NoiDung { get; set; }
            public string TenNguoiPhanAnh { get; set; }
            public string DiaChi { get; set; }
            public string Sdt { get; set; }
            public string IdLoaiPhanAnhNguoiDan { get; set; }
            public string ToaDo { get; set; }
            public string IdAp { get; set; }
            public string IdXa { get; set; }
            public string IdHuyen { get; set; }
            public string MaMay { get; set; }
            public string IdNguoiDung { get; set; }
            public List<TapTin> DanhSachTapTin { get; set; }

            public class TapTin
            {
                public string LoaiTapTin { get; set; }
                public int DungLuong { get; set; }
                //public byte[] DuLieu { get; set; }
                public string DuLieu { get; set; }
            }
        }
    }
    public class DocDanhSachTheoIdLoaiPhanAnhNguoiDanInput : DocDanhSachPhanTrang
    {
        public string IdLoaiPhanAnhNguoiDan { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string IdAp { get; set; }
        public string IdXa { get; set; }
        public string IdHuyen { get; set; }
    }
    public class DocDanhSachTheoIdNhomSanPhamNamTuanInput : DocDanhSachPhanTrang
    {
        public string IdNhomSanPham { get; set; }
        public int Tuan { get; set; }
        public int Nam { get; set; }
        public int Thang { get; set; }
    }
    public class DocDanhSachTheoIdNhomSanPhamNgayInput : DocDanhSachPhanTrang
    {
        public string IdNhomSanPham { get; set; }
        public string NgayThem { get; set; }
    }
    public class DocDanhSachTheoIdTinhNamTuanInput : DocDanhSachPhanTrang
    {
        public string IdNhomSanPham { get; set; }
        public string IdTinh { get; set; }
        public int Tuan { get; set; }
        public int Nam { get; set; }
        public int Thang { get; set; }
    }
    public class DocDanhSachTheoIdTinhInput : DocDanhSachPhanTrang
    {
        public string IdNhomSanPham { get; set; }
        public string IdTinh { get; set; }
        public string NgayThem { get; set; }
    }
    public class DocDanhSachTheoIdHiepHoiNamTuanInput : DocDanhSachPhanTrang
    {
        public string IdNhomSanPham { get; set; }
        public string IdHiepHoi { get; set; }
        public int Tuan { get; set; }
        public int Nam { get; set; }
        public int Thang { get; set; }
    }
    public class DocDanhSachTheoIdHiepHoiInput : DocDanhSachPhanTrang
    {
        public string IdNhomSanPham { get; set; }
        public string IdHiepHoi { get; set; }
        public string NgayThem { get; set; }
    }
    public class PhanAnhNhanhModelInput : PhanTrangInput
    {
        public List<PhanAnhNhanhOutput.ThongTinPhanAnh> DanhSachPhanAnhNhanh { get; set; }
        public PhanAnhNhanhOutput.ThongTinPhanAnh PhanAnhNhanhHienTai { get; set; }
        public PhanAnhNhanhModelInput()
        {
            DanhSachPhanAnhNhanh = new List<PhanAnhNhanhOutput.ThongTinPhanAnh>();
            PhanAnhNhanhHienTai = new PhanAnhNhanhOutput.ThongTinPhanAnh();
        }

    }
    #endregion

    #region Thông tin sản xuất trồng trọt cho người dân
    public class ThongTinSanXuatTrongTrotChoNguoiDanInput
    {
        public class Them : ChungThuc
        {
            public string Id { get; set; }
            public string IdNhomThongTin { get; set; }
            public string TieuDe { get; set; }
            public string DuongDanThanThien { get; set; }
            public string NoiDungTomTat { get; set; }
            public string NoiDung { get; set; }
            public string HinhDaiDien { get; set; }
            public int DoUuTien { get; set; }
            public int TrangThai { get; set; }
            public int Tuan { get; set; }
            public int Thang { get; set; }
            public int Nam { get; set; }
        }
        public class DocDanhSach : ChungThuc
        {
            public string TuKhoa { get; set; }
            public int Nam { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdNhomThongTin { get; set; }
            public int ViTriBatDau { get; set; }
            public int ViTriKetThuc { get; set; }
        }
    }
    #endregion

    #region Thông tin chăn nuôi thú y cho người dân
    public class ThongTinChanNuoiThuYChoNguoiDanInput
    {
        public class Them : ChungThuc
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
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
        }
        public class DocDanhSach : ChungThuc
        {
            public int Nam { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string TuKhoa { get; set; }
            public string IdNhomThongTin { get; set; }
            public int ViTriBatDau { get; set; }
            public int ViTriKetThuc { get; set; }
        }
    }
    #endregion
    #region Sản xuất trồng trọt
    public class SanXuatTrongTrotInput
    {
        public class ThongTinDocLuyKeSauBenh
        {
            public string IdXa { get; set; }
            public string IdHuyen { get; set; }
            public string IdBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public int Tuan { get; set; }
            public int Thang { get; set; }
            public int Quy { get; set; }
            public int SauThang { get; set; }
            public int Nam { get; set; }
            public string IdAp { get; set; }
            public string IdSauBenh { get; set; }
            public string IdSanPham { get; set; }
        }
        public class DocLuyKeSauBenh : ThongTinDocLuyKeSauBenh
        {
            [ScaffoldColumn(false)]
            public string TokenNguoiDung { get; set; }
            [ScaffoldColumn(false)]
            public string TokenApi { get; set; }
        }
        public class PheDuyet : ChungThuc
        {
            public string NoiDungPheDuyet { get; set; }
            public int LoaiBaoCao { get; set; }
            public double NgayLapBaoCao { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdBieuMauBaoCaoSanXuatTrongTrot { get; set; }
        }
        public class ThongTinInput
        {
            public int LoaiBaoCao { get; set; }
            public int Nam { get; set; }
            public int SauThang { get; set; }//Bo sung 6 thang , quy
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdBieuMauBaoCao { get; set; }
            public bool XuatBan { get; set; }
        }
        public class ThongTinDuyetCapTinhInput : ChungThuc
        {
            public int LoaiBaoCao { get; set; }
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdBieuMauBaoCaoSanXuatTrongTrot { get; set; }
        }
        public class ThongTinXuatBanInput : ChungThuc
        {
            public string IdXa { get; set; }
            public string IdHuyen { get; set; }
            public string IdBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public int Tuan { get; set; }
            public int Thang { get; set; }
            public int Quy { get; set; }//Hiện tại chưa có quý
            public int SauThang { get; set; }
            public int Nam { get; set; }
            public string IdAp { get; set; }
        }
        public class ThongTinXuatBanCapTinhInput : ChungThuc
        {
            public string IdBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public int Tuan { get; set; }
            public int Thang { get; set; }
            public int Quy { get; set; }//Hiện tại chưa có quý
            public int SauThang { get; set; }
            public int Nam { get; set; }
        }
        public class Them : ChungThuc
        {
            public string TieuDe { get; set; }
            public string DuongDanThanThien { get; set; }
            public string NoiDungTomTat { get; set; }
            public string NoiDung { get; set; }
            public string HinhDaiDien { get; set; }
            public int DoUuTien { get; set; }
            public int TrangThai { get; set; }
            public string IdNhomThongTin { get; set; }
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
        }
        public class Sua : Them
        {
            public string Id { get; set; }
        }
        public class DocThongTin : ChungThuc
        {
            public string Nam { get; set; }
            public string Thang { get; set; }
            public string Tuan { get; set; }
            public string IdBieuMauBaoCao { get; set; }
            public int LoaiBaoCao { get; set; }
        }
        public class DocThongTin2 : ChungThuc
        {
            public int Nam { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdBieuMauBaoCao { get; set; }
            public int LoaiBaoCao { get; set; }
        }
        public class DocDanhSachThongTinSanXuatTrongTrot : ChungThuc
        {
            public int Nam { get; set; }
            public int LoaiBaoCao { get; set; }
            public string TuKhoa { get; set; }
            public int ViTriBatDau { get; set; }
            public int ViTriKetThuc { get; set; }
        }
        public class DocThongTinChiTiet : DocThongTinInput
        {
            //public string LoaiDoiTuong { get; set; }
        }

        public class TienDoSanXuat : ChungThuc
        {
            public string Id { get; set; }
            public double XuongGiong { get; set; }
            public double XuongGiongTrongTuan { get; set; }

            public double Ma { get; set; }
            public double DeNhanh { get; set; }
            public double DungCaiLamDong { get; set; }
            public double LamDongTro { get; set; }
            public double Chin { get; set; }

            public double ThuHoach { get; set; }
            public double KeHoach { get; set; }
            public double ThuHoachTrongTuan { get; set; }


            public double LuyKeThuHoach { get; set; }
            public double LuyKeXuongGiong { get; set; }

            public string IdDonVi { get; set; }//loại 1
            public string TenDonVi { get; set; }
            public string IdSanPham { get; set; }//loại 2
            public string IdHuyen { get; set; }//Thêm
            public string IdXa { get; set; }//Thêm
        }
        public class ThemTienDoSanXuat : TienDoSanXuat
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdBieuMauBaoCaoSanXuatTrongTrot { get; set; }
        }
        public class ThemTienDoSanXuat2 : ThemTienDoSanXuat
        {
            public int LoaiBaoCao { get; set; }
            public bool XuatBan { get; set; }
            //public int LoaiDonViBaoCao { get; set; }
        }
        public class ThemDanhSachTienDoSanXuat2 : ChungThuc
        {
            public List<ThemTienDoSanXuat2> DanhSachDuLieu { get; set; }
            public ThemDanhSachTienDoSanXuat2()
            {
                DanhSachDuLieu = new List<ThemTienDoSanXuat2>();
            }
        }
        public class ThongTinDocDanhSach : ChungThuc
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdBieuMauBaoCaoSanXuatTrongTrot { get; set; }
            public int LoaiBaoCao { get; set; }
            public string IdXa { get; set; }
            public string TenDonVi { get; set; }
            public string IdHuyen { get; set; }
            public string IdSanPham { get; set; }//Them
        }
        public class ThemTinhHinhSauBenh : TinhHinhSauBenh
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdBieuMauBaoCaoSanXuatTrongTrot { get; set; }
        }

        public class ThemDanhSachTinhHinhSauBenh2 : ChungThuc
        {
            public List<ThemTinhHinhSauBenh2> DanhSachDuLieu { get; set; }
            public ThemDanhSachTinhHinhSauBenh2()
            {
                DanhSachDuLieu = new List<ThemTinhHinhSauBenh2>();
            }
        }

        public class ThemTinhHinhSauBenh2 : ThemTinhHinhSauBenh
        {
            public int LoaiBaoCao { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public bool XuatBan { get; set; }
            public int LoaiDonViBaoCao { get; set; }
        }
        public class TinhHinhSauBenh : ChungThuc
        {
            public string Id { get; set; }
            public ThongTin ThongTinDienTichNhiem { get; set; }
            public ThongTin ThongTinDaTru { get; set; }
            public List<DanhSachMatDoTiLeTheoGiaiDoan> DanhSachThongTinMatDoTiLeTheoGiaiDoan { get; set; }

            public double DienTichConLai { get; set; }
            public double DienTichLuyKe { get; set; }

            public string IdSauBenh { get; set; }
            public List<string> DanhSachIdTuoiSauCapBenh { get; set; }
            public string IdSanPham { get; set; }
            public string NoiPhanBo { get; set; }

            public string IdTinhHinhSauBenh { get; set; }
            public TinhHinhSauBenh()
            {
                ThongTinDienTichNhiem = new ThongTin();
                ThongTinDaTru = new ThongTin();
                DanhSachThongTinMatDoTiLeTheoGiaiDoan = new List<DanhSachMatDoTiLeTheoGiaiDoan>();
                DanhSachIdTuoiSauCapBenh = new List<string>();
            }
        }
        public class ThongTin
        {
            public double Tong { get; set; }
            public double Nhe { get; set; }
            public double Tb { get; set; }
            public double Nang { get; set; }
        }
        public class DanhSachMatDoTiLeTheoGiaiDoan
        {
            //public int LoaiGiaiDoanSinhTruong { get; set; }
            public List<string> DanhSachIdGiaiDoanSinhTruong { get; set; }
            public double PhoBien { get; set; }
            public double Cao { get; set; }
            public string IdQuyCach { get; set; }
            public string TenQuyCach { get; set; }
        }

        public class DocDanhSachSauBenhGDSTQuyCachTuoiSau : ChungThuc
        {
            public string IdBieuMauBaoCao { get; set; }
            public string IdSanPham { get; set; }
        }
        public class DocDanhSachCayTrong : ChungThuc
        {
            public string MaChucNang { get; set; }
        }

        public class XuatExcel
        {
            public class TienDoXuongGiong
            {
                public string DonVi { get; set; }
                public double XuongGiong { get; set; }
                public double DungCaiLamDong { get; set; }
                public double Tro { get; set; }
                public double Chin { get; set; }
                public double LuyKe { get; set; }
            }
            public class TienDoXuongGiongRauMau
            {
                public string LoaiCayTrong { get; set; }
                public double SoLieuXuongGiong { get; set; }
                public double LuyKeXuongGiong { get; set; }
                public double SoLieuThuHoach { get; set; }
                public double LuyKeThuHoach { get; set; }
            }
            public class TinhHinhDichHai
            {
                public string DichHai { get; set; }
                public string GDST { get; set; }
                public string PhoBien { get; set; }
                public string Cao { get; set; }
                public double TongSo_Nhiem { get; set; }
                public double Nhe_Nhiem { get; set; }
                public double TrungBinh_Nhiem { get; set; }
                public double Nang_Nhiem { get; set; }
                public string TuoiSauCapBenh { get; set; }
                public double DienTichLuyKe { get; set; }
                public double TongSo_DaTru { get; set; }
                public double Nhe_DaTru { get; set; }
                public double TrungBinh_DaTru { get; set; }
                public double Nang_DaTru { get; set; }
                public double DienTichConLai { get; set; }
                public string NoiPhanBo { get; set; }
            }
        }
    }

    #endregion
    #region Sâu bệnh, loại sâu bệnh
    public class SauBenhInput
    {
        public class DocDanhSach : ChungThuc
        {
            public string IdSanPham { get; set; }
            public string IdBieuMauBaoCao { get; set; }
            public string TuKhoa { get; set; }
            public int ViTriBatDau { get; set; }
            public int ViTriKetThuc { get; set; }
        }
        public class Them : ChungThuc
        {
            public string IdLoaiSauBenh { get; set; }
            public string Ten { get; set; }
            public string Ma { get; set; }
            public string Icon { get; set; }
            public int ViTri { get; set; }
            public int KichHoat { get; set; }
            public List<string> DanhSachIdSanPham { get; set; }
            public string IdBieuMauBaoCao { get; set; }
            public List<ThongTin> DanhSachThongTinDichBenh { get; set; }
            public class ThongTin
            {
                public string IdQuyCach { get; set; }
                public string IdDonViTinh { get; set; }
            }
        }
        public class Sua : Them
        {
            public string Id { get; set; }
        }
        public class DocDanhSachTheoIdLoaiSauBenh : ChungThuc
        {
            public string Id { get; set; }
        }
    }
    #endregion

    #region Thông báo
    public class ThongBaoInput
    {
        public class GuiTatCa : ChungThuc
        {
            public string IdLoaiThongBao { get; set; }
            public string Id { get; set; }
            public string TieuDe { get; set; }
            public string NoiDungTomTat { get; set; }
            public string NoiDung { get; set; }
            public string IdTaiKhoan { get; set; }
            public string IdNguoiDung { get; set; }
            public string IdDuLieu { get; set; }
            public string AnhDaiDien { get; set; }
        }
    }
    #endregion
    #region Chăn nuôi thú y
    public class ChanNuoiThuYInput
    {
        public class DocDanhSachDuLieuTheoIdBieuMauBaoCaoGomNhomTheoBieuMau : ChungThuc
        {
            public int LoaiBaoCao { get; set; }
            public string IdBieuMauBaoCao { get; set; }
            public string MaBieuMauBaoCao { get; set; }
            public string IdDonVi { get; set; }
            public string IdChucNang { get; set; }
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string LoaiDonVi { get; set; }
        }
        public class DocDanhSachCoDieuKien : ChungThuc
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string TuKhoa { get; set; }
            public int TrangThai { get; set; }
            public int ViTriBatDau { get; set; }
            public int ViTriKetThuc { get; set; }
            public int LoaiBaoCao { get; set; }
        }
        public class Them : ChungThuc
        {
            public string TieuDe { get; set; }
            public string DuongDanThanThien { get; set; }
            public string NoiDungTomTat { get; set; }
            public string NoiDung { get; set; }
            public string HinhDaiDien { get; set; }
            public int DoUuTien { get; set; }
            public int TrangThai { get; set; }
            public int Nam { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int LoaiBaoCao { get; set; }
        }
        public class Sua : Them
        {
            public string Id { get; set; }
        }
        public class DocDanhSachDuLieuDichBenhGiaSuc : ChungThuc
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
            public string IdAp { get; set; }
            public string IdXa { get; set; }
            public string IdHuyen { get; set; }
            public string IdTinh { get; set; }
            public string IdSanPham { get; set; }
            public bool LaQuanTri { get; set; }
        }
        public class DocDanhSachDuLieuDichBenhThuySan : ChungThuc
        {
            public string IdTinh { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public int Nam { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdAp { get; set; }
            public int SauThang { get; set; }
            public string IdChucNang { get; set; }
            public string IdBieuMauBaoCao { get; set; }
            public bool LaQuanTri { get; set; }
        }
        public class TongHopSoLieuDichBenhThuySan : ChungThuc
        {
            public string IdHuyen { get; set; }
            public string IdTinh { get; set; }
            public int Nam { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public int SauThang { get; set; }
            public string Nhom { get; set; }
            public string IdBieuMauBaoCao { get; set; }
        }
        public class DocDanhSachDuLieuTiemPhong : ChungThuc
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdBieuMauBaoCaoTiemPhong { get; set; }
            public string MaBieuMauBaoCaoTiemPhong { get; set; }
            public string IdXa { get; set; }
            public string IdHuyen { get; set; }
            public string IdTinh { get; set; }
            public string IdSanPham { get; set; }
            public bool LaQuanTri { get; set; }
        }
        public class DocDanhSachDuLieuKiemDich : ChungThuc
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdBieuMauBaoCaoKiemDich { get; set; }
            public bool LaQuanTri { get; set; }
        }
        public class DocDanhSachDuLieuGietMo : ChungThuc
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdBieuMauBaoCaoGietMo { get; set; }
            public string IdAp { get; set; }
            public string IdXa { get; set; }
            public string IdHuyen { get; set; }
            public string IdTinh { get; set; }
            public bool LaQuanTri { get; set; }
        }
        public class DocDanhSachDuLieuDieuTraTongDan : ChungThuc
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public string IdBieuMauBaoCao { get; set; }
            public string IdSanPham { get; set; }
            public bool LaQuanTri { get; set; }
        }
        public class TongHopDuLieuThongTinGietMo : ChungThuc
        {
            public string IdHuyen { get; set; }
            public string IdTinh { get; set; }
            public int Nam { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public int SauThang { get; set; }
            public string IdBieuMauBaoCaoGietMo { get; set; }
        }
        public class DocDanhSachThuySanDichBenhHoNuoiHinhThucNuoiMucDichNuoi : ChungThuc
        {
            public string IdBieuMauBaoCao { get; set; }
            public string IdChucNang { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }
        }
        public class PheDuyetDuLieu
        {
            public class ThongTinTiemPhong : ChungThuc
            {
                public string NoiDungPheDuyet { get; set; }
                public int Nam { get; set; }
                public int SauThang { get; set; }
                public int Quy { get; set; }
                public int Thang { get; set; }
                public int Tuan { get; set; }
                public string IdBieuMauBaoCaoTiemPhong { get; set; }
                public string IdHuyen { get; set; }
                public string IdTinh { get; set; }
                public bool XuatBan { get; set; }
            }
            public class ThongTinGietMo : ChungThuc
            {
                public int Nam { get; set; }
                public int SauThang { get; set; }
                public int Quy { get; set; }
                public int Thang { get; set; }
                public int Tuan { get; set; }
                public string IdBieuMauBaoCaoGietMo { get; set; }
                public string IdHuyen { get; set; }
                public string IdTinh { get; set; }
                public bool XuatBan { get; set; }
                public string NoiDungPheDuyet { get; set; }
            }
            public class ThongTinKiemDich : ChungThuc
            {
                public int Nam { get; set; }
                public int SauThang { get; set; }
                public int Quy { get; set; }
                public int Thang { get; set; }
                public int Tuan { get; set; }
                public string IdBieuMauBaoCaoKiemDich { get; set; }
                public string NoiDungPheDuyet { get; set; }
                public bool XuatBan { get; set; }
            }
            public class ThongTinDichBenhThuY : ChungThuc
            {
                public int Nam { get; set; }
                public int SauThang { get; set; }
                public int Quy { get; set; }
                public int Thang { get; set; }
                public int Tuan { get; set; }
                public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
                public string IdAp { get; set; }
                public string IdXa { get; set; }
                public string IdHuyen { get; set; }
                public string IdTinh { get; set; }
                public string IdSanPham { get; set; }
                public string NoiDungPheDuyet { get; set; }
                public bool XuatBan { get; set; }
            }
            public class ThongTinDichBenhThuySan : ChungThuc
            {
                public string IdHuyen { get; set; }
                public int Nam { get; set; }
                public int SauThang { get; set; }
                public int Quy { get; set; }
                public int Thang { get; set; }
                public int Tuan { get; set; }
                public string IdTinh { get; set; }
                public bool XuatBan { get; set; }
                public string NoiDungPheDuyet { get; set; }
                public string IdBieuMauBaoCao { get; set; }
            }
            public class ThongTinDieuTraTongDan : ChungThuc
            {
                public string NoiDungPheDuyet { get; set; }
                public int Nam { get; set; }
                public int SauThang { get; set; }
                public int Quy { get; set; }
                public int Thang { get; set; }
                public string IdBieuMauBaoCao { get; set; }
                public bool XuatBan { get; set; }
            }
        }
    }
    #endregion

    #region Giá tỉnh lân cận
    public class GiaCaThiTruongTinhLanCanIntput : ChungThuc
    {
        public string IdAp { get; set; }
        public string IdXa { get; set; }
        public string IdHuyen { get; set; }
        public string IdTinh { get; set; }
        public string TenTinh { get; set; }
        public bool TuanHienTai { get; set; }

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
        public float GiaThuMuaCuTu { get; set; }
        public float GiaThuMuaCuDen { get; set; }
        public float GiaBanLeCuTu { get; set; }
        public float GiaBanLeCuDen { get; set; }
    }
    public class GiaTinhLanCanModelInput : PhanTrangInput
    {
        public List<GiaCaThiTruongTinhLanCanIntput> DanhSachGiaTinhLanCan { get; set; }
        public List<NhomSanPhamOutput.ThongTinNhomSanPham> ListNhomSanPham { get; set; }
        public GiaTinhLanCanModelInput()
        {
            DanhSachGiaTinhLanCan = new List<GiaCaThiTruongTinhLanCanIntput>();
            ListNhomSanPham = new List<NhomSanPhamOutput.ThongTinNhomSanPham>();
        }
        //public class DuLieuGia : DuLieuOutputModel
        //{
        //    public List<SanPhamOutput.DocDanhSachTheoIdNhomSanPham> ListLoai { get; set; }
        //    public List<GiaCaThiTruongTrongTinhIntput> ListDanhSach { get; set; }
        //}
        //public class DuLieuGiaKT : DuLieuOutputModel
        //{
        //    public List<NhomSanPhamOutput.ThongTinNhomSanPham> ListNhomSanPham { get; set; }
        //    public List<GiaCaThiTruongTrongTinhIntput> ListDanhSach { get; set; }
        //}
    }
    #endregion
    #region Giá hiệp hội
    public class GiaCaThiTruongGiaHiepHoiInput : ChungThuc
    {
        public string IdHiepHoi { get; set; }
        public bool TuanHienTai { get; set; }

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

        public float GiaThuMuaCuTu { get; set; }
        public float GiaThuMuaCuDen { get; set; }
        public float GiaBanLeCuTu { get; set; }
        public float GiaBanLeCuDen { get; set; }
        public string Id { get; set; }
    }
    public class GiaHiepHoiModelInput : PhanTrangInput
    {
        public List<GiaCaThiTruongGiaHiepHoiInput> DanhSachGiaHiepHoi { get; set; }
        public GiaHiepHoiModelInput()
        {
            DanhSachGiaHiepHoi = new List<GiaCaThiTruongGiaHiepHoiInput>();
        }
    }
    #endregion
    #region Thông tin dịch bệnh thú y
    public class ThongTinDichBenhThuYInput
    {
        public class ThongTinDichBenh : ChungThuc
        {
            public string Id { get; set; }
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public int LoaiBaoCao { get; set; }
            public string IdChanNuoiThuY { get; set; }
            public string IdLoaiDichBenhThuY { get; set; }
            public string IdSanPham { get; set; }
            public string IdTinh { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }
            public long TongSoLuongBenh { get; set; }
            public long TongSoLuongChet { get; set; }
            public string GhiChu { get; set; }
            public long TongSoLuongBenhLuyKeDauNam { get; set; }
            public long TongSoLuongChetLuyKeDauNam { get; set; }
            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
            public string IdDonVi { get; set; }
            public string TenDonVi { get; set; }
            public int LoaiDonViBaoCao { get; set; }
        }
        public class Them : ThongTinDichBenh { }
        public class ThemDanhSach : ChungThuc
        {
            public List<ThongTinDichBenh> DanhSachThongTinDichBenh { get; set; }
        }
        public class XoaDanhSach : ChungThuc
        {
            public List<string> DanhSachId { get; set; }
        }
    }
    #endregion
    #region Thông tin tiêm phòng
    public class ThongTinTiemPhongInput
    {
        public class ThongTinTiemPhong : ChungThuc
        {
            public string Id { get; set; }
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdSanPham { get; set; }
            public string IdLoaiTiemPhong { get; set; }
            public long TongSoLuong { get; set; }
            public string GhiChu { get; set; }
            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
            public double SoLuongTrongTuan { get; set; }
            public double LuyKeDauNam { get; set; }
            public string IdDonViTinh { get; set; }
            public string IdChanNuoiThuY { get; internal set; }
            public string IdTinh { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }
            public string IdDonVi { get; set; }
            public string TenDonVi { get; set; }
            public int LoaiDonViBaoCao { get; set; }
        }
        public class Them : ThongTinTiemPhong { }
        public class ThemDanhSach : ChungThuc
        {
            public List<ThongTinTiemPhong> DanhSachThongTinTiemPhong { get; set; }
        }
    }
    #endregion
    #region Thông tin Kiểm dịch
    public class ThongTinKiemDichInput
    {
        public class ThongTinKiemDich : ChungThuc
        {
            public string Id { get; set; }
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdSanPham { get; set; }
            public string idChatLuong { get; set; }
            public string IdChanNuoiThuY { get; set; }
            public string IdTieuChuanKiemDich { get; set; }
            public double TongSoLuong { get; set; }
            public double TongSoLuongKiemDich { get; set; }
            public List<string> DanhSachIdTinhXuat { get; set; }
            public List<string> DanhSachIdTinhDen { get; set; }
            public string GhiChu { get; set; }
            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
            public double SoLuongLuyKeDauNam { get; set; }
            public double SoLuongSoVoiCungKy { get; set; }
            public double SoLuongTrongTuan { get; set; }
            public double SoLuongTuanTruoc { get; set; }
            public string ThongTinGiaCa { get; set; }
            public double TongSoLuongConDuc { get; set; }
            public double TongSoLuongConCai { get; set; }
            public double TongSoLuongDatChuan { get; set; }
            public double TongSoLuongDatChuanLuyKe { get; set; }
            public double TongSoLuongDatChuanTrongTuan { get; set; }
            public double TongSoLuongKhongDatChuan { get; set; }
            public double TongSoLuongKhongDatChuanTrongTuan { get; set; }
            public double TongSoLuongKhongDatChuanLuyKe { get; set; }
            public double TongSoLuongConCaiLuyKe { get; set; }
            public double TongSoLuongConDucTrongTuan { get; set; }
            public double TongSoLuongConDucLuyKe { get; set; }
            public double TongSoLuongConCaiTrongTuan { get; set; }
            public string IdDonVi { get; set; }
            public string TenDonVi { get; set; }
            public int LoaiDonViBaoCao { get; set; }
            public string ChuoiDanhSachIdTinhDen { get; set; }
            public string ChuoiDanhSachIdTinhXuat { get; set; }
        }
        public class Them : ThongTinKiemDich { }
        public class ThemDanhSach : ChungThuc
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
            public List<ThongTinKiemDich> DanhSachThongTinKiemDich { get; set; }
        }
        public class XoaDanhSach : ChungThuc
        {
            public List<string> DanhSachId { get; set; }
        }
    }
    #endregion
    #region Thông tin giết mổ
    public class ThongTinGietMoInput
    {
        public class ThongTinGietMo : ChungThuc
        {
            public string Id { get; set; }
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdSanPham { get; set; }
            public string IdLoaiTiemPhong { get; set; }
            public long TongSoLuong { get; set; }
            public string GhiChu { get; set; }
            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
            public double SoLuongTrongTuan { get; set; }
            public double SoLuongLuyKeDauNam { get; set; }
            public string IdDonViTinh { get; set; }
            public string IdChanNuoiThuY { get; internal set; }
            public string IdTinh { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }
            public string IdDonVi { get; set; }
            public string TenDonVi { get; set; }
            public int LoaiDonViBaoCao { get; set; }
        }
        public class Them : ThongTinGietMo { }
        public class ThemDanhSach : ChungThuc
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
            public string IdDonVi { get; set; }
            public List<ThongTinGietMo> DanhSachThongTinGietMo { get; set; }
        }
        public class XoaDanhSach : ChungThuc
        {
            public List<string> DanhSachId { get; set; }
        }
    }
    #endregion
    #region Thông tin Điều tra tổng đàn
    public class ThongTinDieuTraTongDanInput
    {
        public class ThongTinDieuTraTongDan : ChungThuc
        {
            public string Id { get; set; }
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int LoaiBaoCao { get; set; }
            public string IdSanPham { get; set; }
            public double TongSoLuong { get; set; }
            public double KeHoachNam { get; set; }
            public double SoVoiCungKy { get; set; }
            public double SoVoiKeHoach { get; set; }
            public string GhiChu { get; set; }
            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
        }
        public class Them : ThongTinDieuTraTongDan { }
        public class ThemDanhSach : ChungThuc
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
            public List<ThongTinDieuTraTongDan> DanhSachThongTinDieuTraTongDan { get; set; }
        }
        public class XoaDanhSach : ChungThuc
        {
            public List<string> DanhSachId { get; set; }
        }
    }
    #endregion

    #region Loại tiêm phòng
    public class LoaiTiemPhongInput
    {
        public class Them : ChungThuc
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string TenVietTat { get; set; }
            public string MoTa { get; set; }
            public string GhiChu { get; set; }
            public string IdDonViTinh { get; set; }
        }
    }
    #endregion
    #region Giá tỉnh lân cận
    public class GiaTinhLanCanInput : ChungThuc
    {
        public string IdHuyen { get; set; }
        public string IdTinh { get; set; }
        public string IdSanPham { get; set; }
        public string IdNhomSanPham { get; set; }
        public string IdQuyCach { get; set; }
        public string IdDonViTinh { get; set; }
        public float GiaThuMuaTu { get; set; }
        public float GiaThuMuaDen { get; set; }
        public float GiaBanLeTu { get; set; }
        public float GiaBanLeDen { get; set; }
        public int Nam { get; set; }
        public int Tuan { get; set; }
        public string Id { get; set; }
        public double NgayNhap { get; set; }
        public string NgayThem { get; set; }
    }
    #endregion
    #region Giá hiệp hội
    public class GiaHiepHoiInput : ChungThuc
    {
        public string IdHiepHoi { get; set; }
        public string IdSanPham { get; set; }
        public string IdNhomSanPham { get; set; }
        public float GiaThuMuaTu { get; set; }
        public float GiaThuMuaDen { get; set; }
        public float GiaBanLeTu { get; set; }
        public float GiaBanLeDen { get; set; }
        public string IdQuyCach { get; set; }
        public string IdDonViTinh { get; set; }
        public int Nam { get; set; }
        public int Tuan { get; set; }
        public string Id { get; set; }
        public double NgayNhap { get; set; }
        public string NgayThem { get; set; }
    }
    #endregion
    #region Giá giống nông nghiệp
    public class GiaGiongTrongTinhModelInput : PhanTrangInput
    {
        public List<GiaGiongTrongTinhIntput> DanhSachGiaTrongTinh { get; set; }
        public List<NhomSanPhamOutput.ThongTinNhomSanPham> ListNhomSanPham { get; set; }
        public GiaGiongTrongTinhModelInput()
        {
            DanhSachGiaTrongTinh = new List<GiaGiongTrongTinhIntput>();
            ListNhomSanPham = new List<NhomSanPhamOutput.ThongTinNhomSanPham>();
        }
    }
    public class DuLieuGiaGiongKT : DuLieuOutputModel
    {
        public List<NhomSanPhamOutput.ThongTinNhomSanPham> ListNhomSanPham { get; set; }
        public List<GiaGiongTrongTinhIntput> DanhSachGiaTrongTinh { get; set; }
    }
    public class GiaGiongTrongTinhIntput : ChungThuc
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
        public double NgayNhap { get; set; }
        public string NgayThem { get; set; }
        public string IdNhomSanPham { get; set; }

        //Doc danh sach
        public string TenDonViTinh { get; set; }
        public string TenQuyCach { get; set; }
        public string TenSanPham { get; set; }
        public string TenNhomSanPham { get; set; }
        public string TenCapGiong { get; set; }
        public string TenChieuCao { get; set; }
        public string TenCoBau { get; set; }
        public string TenKichCo { get; set; }
        public string TenNgayTuoi { get; set; }
        public double NgayCapNhat { get; set; }
        public string ChuoiNgayCapNhat { get; set; }
        public string NguonGoc { get; set; }
        public string DacTinh { get; set; }
        public bool XuatBan { get; set; }
        public bool TuanHienTai { get; set; }
        public string GhiChu { get; set; }
    }
    #endregion

    #region Thong Ke Mo Hinh San Xuat Co Hieu Qua
    public class ThongKeMoHinhSanXuatCoHieuQuaInput
    {
        public class Them : ChungThuc
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
        public class DocDanhSach : ChungThuc
        {
            public int ViTriBatDau { get; set; }
            public int ViTriKetThuc { get; set; }
            public string TuKhoa { get; set; }
            public string IdTinh { get; set; }
            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }
        }
    }
    #endregion
    #region Thống kê mô hình sản xuất có hiệu quả
    public class DocDanhSachMoHinhSanXuatCoHieuQuaInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
        public string IdTinh { get; set; }
        public string IdHuyen { get; set; }
        public string IdXa { get; set; }
        public string IdAp { get; set; }
    }
    public class ThongKeMoHinhSanXuatCoHieuQuaModelInput : PhanTrangInput
    {
        public List<ThongKeMoHinhSanXuatCoHieuQuaKTInput> MoHinhSanXuatCoHieuQua { get; set; }
        public ThongKeMoHinhSanXuatCoHieuQuaModelInput()
        {
            MoHinhSanXuatCoHieuQua = new List<ThongKeMoHinhSanXuatCoHieuQuaKTInput>();
        }

    }
    public class ThongKeMoHinhSanXuatCoHieuQuaKTInput : ChungThuc
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
    public class DocDanhSachBaiVietMoHinhSanXuatCoHieuQuaInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
        public string IdTinh { get; set; }
        public string IdHuyen { get; set; }
        public string IdXa { get; set; }
        public string IdAp { get; set; }
    }
    public class BaiVietMoHinhSanXuatCoHieuQuaModelInput : PhanTrangInput
    {
        public List<BaiMoHinhSanXuatCoHieuQuaKTInput> MoHinhSanXuatCoHieuQua { get; set; }
        public BaiMoHinhSanXuatCoHieuQuaKTInput ChiTietMoHinhSanXuatCoHieuQua { get; set; }
        public BaiVietMoHinhSanXuatCoHieuQuaModelInput()
        {
            MoHinhSanXuatCoHieuQua = new List<BaiMoHinhSanXuatCoHieuQuaKTInput>();
            ChiTietMoHinhSanXuatCoHieuQua = new BaiMoHinhSanXuatCoHieuQuaKTInput();
        }

    }
    public class BaiMoHinhSanXuatCoHieuQuaKTInput : ChungThuc
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} bắt buộc phải nhập")]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Display(Name = "Đường dẫn")]
        public string DuongDanThanThien { get; set; }
        [Display(Name = "Nội dung tóm tắt")]
        public string NoiDungTomTat { get; set; }
        [AllowHtml]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
        [Display(Name = "Hình đại diện")]
        public string HinhDaiDien { get; set; }
        [Display(Name = "Thông báo")]
        public int DoUuTien { get; set; }
        [Display(Name = "Trạng thái")]
        public string NgayTao { get; set; }
        public int TrangThai { get; set; }
        public string IdTinh { get; set; }
        public string IdHuyen { get; set; }
        public string IdXa { get; set; }
        public string IdAp { get; set; }
        public string DiaChi { get; set; }
        public string IdNguoiTao { get; set; }
        public string IdNguoiCapNhat { get; set; }
        public string TenNguoiTao { get; set; }
        public string TenNguoiCapNhat { get; set; }
    }
    #endregion
    #region Nhóm sử dụng phân bón thuốc trừ sâu
    public class DocDanhSachNhomSuDungPhanBonThuocInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
    }
    public class NhomSuDungPhanBonThuocModelInput : PhanTrangInput
    {
        public List<NhomSuDungPhanBonThuocInput> NhomSuDungPhanBonThuoc { get; set; }
        public NhomSuDungPhanBonThuocInput ChiTietNhomSuDungPhanBonThuoc { get; set; }
        public NhomSuDungPhanBonThuocModelInput()
        {
            NhomSuDungPhanBonThuoc = new List<NhomSuDungPhanBonThuocInput>();
            ChiTietNhomSuDungPhanBonThuoc = new NhomSuDungPhanBonThuocInput();
        }

    }
    public class NhomSuDungPhanBonThuocInput : ChungThuc
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public int ViTri { get; set; }
        public string MoTa { get; set; }
        public string Icon { get; set; }
        public bool CamSuDung { get; set; }
    }
    #endregion
    #region Nhóm phân bón thuốc trừ sâu được sử dụng 
    public class DocDanhSachNhomPhanBonThuocDuocSuDungInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
        public string IdNhomSuDungPhanBonThuoc { get; set; }
    }
    public class DanhSachNhomPhanBonThuocDuocSuDungInput : ChungThuc
    {
        public string IdNhomSuDungPhanBonThuoc { get; set; }
    }
    public class NhomPhanBonThuocDuocSuDungModelInput : PhanTrangInput
    {
        public List<NhomPhanBonThuocDuocSuDungInput> NhomPhanBonThuocDuocSuDung { get; set; }
        public NhomPhanBonThuocDuocSuDungInput ChiTietNhomPhanBonThuocDuocSuDung { get; set; }
        public NhomPhanBonThuocDuocSuDungModelInput()
        {
            NhomPhanBonThuocDuocSuDung = new List<NhomPhanBonThuocDuocSuDungInput>();
            ChiTietNhomPhanBonThuocDuocSuDung = new NhomPhanBonThuocDuocSuDungInput();
        }

    }
    public class NhomPhanBonThuocDuocSuDungInput : ChungThuc
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public int ViTri { get; set; }
        public string MoTa { get; set; }
        public string Icon { get; set; }
        public string IdNhomSuDungPhanBonThuoc { get; set; }
    }
    #endregion
    #region Nhóm phân bón thuốc trừ sâu
    public class DocDanhSachNhomPhanBonThuocInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
        public string IdNhomSuDungPhanBonThuoc { get; set; }
        public string IdSuDungPhanBonThuoc { get; set; }
    }
    public class DanhSachNhomPhanBonThuocInput : DocDanhSachPhanTrang
    {
        public string IdNhomSuDungPhanBonThuoc { get; set; }
        public string IdSuDungPhanBonThuoc { get; set; }
    }
    public class NhomPhanBonThuocModelInput : PhanTrangInput
    {
        public List<NhomPhanBonThuocInput> NhomPhanBonThuoc { get; set; }
        public NhomPhanBonThuocInput ChiTietNhomPhanBonThuoc { get; set; }
        public NhomPhanBonThuocModelInput()
        {
            NhomPhanBonThuoc = new List<NhomPhanBonThuocInput>();
            ChiTietNhomPhanBonThuoc = new NhomPhanBonThuocInput();
        }

    }
    public class NhomPhanBonThuocInput : ChungThuc
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public int ViTri { get; set; }
        public string MoTa { get; set; }
        public string Icon { get; set; }
        public bool CamSuDung { get; set; }
        public string IdNhomSuDungPhanBonThuoc { get; set; }
        public string IdSuDungPhanBonThuoc { get; set; }
    }
    #endregion
    #region Nguyên liệu phân bón thuốc trừ sâu
    public class DocDanhSachNguyenLieuInput : ChungThuc
    {
        public string TuKhoa { get; set; }
    }
    public class DocDanhSachNguyenLieuPhanBonThuocInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
        public string IdNhomPhanBonThuoc { get; set; }
        public string IdNhomSuDungPhanBonThuoc { get; set; }
    }
    public class NguyenLieuPhanBonThuocModelInput : PhanTrangInput
    {
        public List<NguyenLieuPhanBonThuocInput> NguyenLieuPhanBonThuoc { get; set; }
        public NguyenLieuPhanBonThuocInput ChiTietNguyenLieuPhanBonThuoc { get; set; }
        public NguyenLieuPhanBonThuocModelInput()
        {
            NguyenLieuPhanBonThuoc = new List<NguyenLieuPhanBonThuocInput>();
            ChiTietNguyenLieuPhanBonThuoc = new NguyenLieuPhanBonThuocInput();
        }

    }
    public class NguyenLieuPhanBonThuocInput : ChungThuc
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public int ViTri { get; set; }
        public string MoTa { get; set; }
        public string Icon { get; set; }
        public bool CamSuDung { get; set; }
        public string IdNhomPhanBonThuoc { get; set; }
        public string IdNhomSuDungPhanBonThuoc { get; set; }
    }
    #endregion
    #region Phân bón thuốc trừ sâu
    public class DocDanhSachPhanBonThuocInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
        public string IdNhomSuDungPhanBonThuoc { get; set; }
        public string IdSuDungPhanBonThuoc { get; set; }
        public string IdNhomPhanBonThuoc { get; set; }
        public string IdNguyenLieuPhanBonThuoc { get; set; }
    }
    public class PhanBonThuocModelInput : PhanTrangInput
    {
        public List<PhanBonThuocInput> PhanBonThuoc { get; set; }
        public PhanBonThuocInput ChiTietPhanBonThuoc { get; set; }
        public PhanBonThuocModelInput()
        {
            PhanBonThuoc = new List<PhanBonThuocInput>();
            ChiTietPhanBonThuoc = new PhanBonThuocInput();
        }

    }
    public class PhanBonThuocModelKTInput : PhanTrangInput
    {
        public List<DocDanhSachPhanBonThuoc> PhanBonThuoc { get; set; }
        public PhanBonThuocModelKTInput()
        {
            PhanBonThuoc = new List<DocDanhSachPhanBonThuoc>();
        }

    }
    public class PhanBonThuocInput : ChungThuc
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public int ViTri { get; set; }
        public string DoiTuongPhongTru { get; set; }
        public string ToChucDeNghiDangKy { get; set; }
        public string Icon { get; set; }
        public bool CamSuDung { get; set; }
        public string IdNhomSuDungPhanBonThuoc { get; set; }
        public string IdSuDungPhanBonThuoc { get; set; }
        public string IdNhomPhanBonThuoc { get; set; }
        //public string IdNguyenLieuPhanBonThuoc { get; set; }
        public List<string> DanhSachIdNguyenLieuPhanBonThuoc { get; set; }
    }
    public class NguyenLieu
    {
        public string Id { get; set; }
        public string Ten { get; set; }
    }

    public class DocDanhSachPhanBonThuoc
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public int ViTri { get; set; }
        public string Icon { get; set; }
        public bool CamSuDung { get; set; }
        public string Ma { get; set; }
        public string DoiTuongPhongTru { get; set; }
        public string ToChucDeNghiDangKy { get; set; }
        public List<NguyenLieu> DanhSachNguyenLieu { get; set; }
        public string IdNhomPhanBonThuoc { get; set; }
        public string TenNhomPhanBonThuoc { get; set; }
        public string IdSuDungPhanBonThuoc { get; set; }
        public string TenSuDungPhanBonThuoc { get; set; }
        public string GhiChu { get; set; }
        public string TenNhomSuDungPhanBonThuoc { get; internal set; }
        public string IdNhomSuDungPhanBonThuoc { get; set; }

        public DocDanhSachPhanBonThuoc()
        {
            DanhSachNguyenLieu = new List<NguyenLieu>();
        }
    }
    #endregion
    #region Thông tin sâu bệnh
    public class DocDanhSachSauBenhInput : DocDanhSachPhanTrang
    {
        public string IdSanPham { get; set; }
        public string IdBieuMauBaoCao { get; set; }
        public string TuKhoa { get; set; }
    }
    public class SauBenhModelInput : PhanTrangInput
    {
        public List<ThongTinSauBenhInput> DanhSachSauBenh { get; set; }
        public SauBenhModelInput()
        {
            DanhSachSauBenh = new List<ThongTinSauBenhInput>();
        }

    }
    public class ThongTinSauBenhInput : ChungThuc
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public int KichHoat { get; set; }
        public List<string> DanhSachIdSanPham { get; set; }
        public List<ThongTin> DanhSachThongTinDichBenh { get; set; }
        public ThongTinSauBenhInput()
        {
            DanhSachThongTinDichBenh = new List<ThongTin>();
        }
        public class ThongTin
        {
            public string IdQuyCach { get; set; }
            public string IdDonViTinh { get; set; }
        }
        public List<SanPham> DanhSachSanPham { get; set; }
        public class SanPham
        {
            public string Id { get; set; }
            public string Ten { get; set; }

        }
    }
    #endregion
    #region Giai đoạn sinh trưởng
    public class DocGiaiDoanSinhTruongInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
    }
    public class GiaiDoanSinhTruongModelInput : PhanTrangInput
    {
        public List<GiaiDoanSinhTruongInput.DocDanhSach> DanhSachGiaiDoanSinhTruong { get; set; }
        public GiaiDoanSinhTruongModelInput()
        {
            DanhSachGiaiDoanSinhTruong = new List<GiaiDoanSinhTruongInput.DocDanhSach>();
        }

    }
    public class GiaiDoanSinhTruongInput : ChungThuc
    {
        public class DocDanhSach : ChungThuc
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string Ma { get; set; }
            public bool DaXoa { get; set; }
            public List<string> DanhSachIdSanPham { get; set; }
            public string GhiChu { get; set; }
            public string MoTa { get; set; }
            public List<SanPham> DanhSachSanPham { get; set; }
        }
        public class SanPham
        {
            public string Id { get; set; }
            public string Ten { get; set; }
        }
    }
    #endregion
    #region Mặt hàng sản xuất trồng trọt
    public class DocDanhSachMatHangSXTTInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
        public string IdNhomSanPham { get; set; }
    }
    public class DanhSachMatHangSXTTInput : ChungThuc
    {
        public string IdNhomSanPham { get; set; }
    }
    public class MatHangSXTTModelInput : PhanTrangInput
    {
        public List<MatHangSXTTInput> MatHangSXTT { get; set; }
        public MatHangSXTTModelInput()
        {
            MatHangSXTT = new List<MatHangSXTTInput>();
        }

    }
    public class MatHangSXTTInput : ChungThuc
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
    }
    #endregion
    #region Dịch bệnh thú y
    public class DichBenhThuYInput : ChungThuc
    {
        public class ThongTinDichBenhThuY : ChungThuc
        {
            public string Id { get; set; }
            public string Ten { get; set; }
            public string TenVietTat { get; set; }
            public string MoTa { get; set; }
            public string GhiChu { get; set; }
        }
        public class CapNhat : ThongTinDichBenhThuY { }

    }
    public class DocDanhSachLoaiDichBenhThuYInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
        public string IdNhomSanPham { get; set; }
    }
    public class DanhSachLoaiDichBenhThuYInput : ChungThuc
    {
        public string IdNhomSanPham { get; set; }
    }
    public class LoaiDichBenhThuYModelInput
    {
        public List<LoaiDichBenhThuYInput> DanhSachLoaiDichBenhThuY { get; set; }
        public LoaiDichBenhThuYModelInput()
        {
            DanhSachLoaiDichBenhThuY = new List<LoaiDichBenhThuYInput>();
        }

    }
    public class LoaiDichBenhThuYInput : ChungThuc
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public string TenVietTat { get; set; }
        public string MoTa { get; set; }
        public string GhiChu { get; set; }
    }

    #endregion
    #region Kiểm dịch
    public class DocDanhSachKiemDichInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
    }
    public class KiemDichModelInput
    {
        public List<KiemDichInput> DanhSachKiemDich { get; set; }
        public KiemDichModelInput()
        {
            DanhSachKiemDich = new List<KiemDichInput>();
        }
    }
    public class KiemDichInput : ChungThuc
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public string TenVietTat { get; set; }
        public string MoTa { get; set; }
        public string GhiChu { get; set; }
    }
    public class ChatLuongInput
    {
        public class Them : ChungThuc
        {
            public string Ten { get; set; }
            public string TenVietTat { get; set; }
            public string MoTa { get; set; }
            public string GhiChu { get; set; }
        }
        public class Sua : Them
        {
            public string Id { get; set; }
        }
        public class DocDanhSach : ChungThuc { }
    }
    #endregion
    #region Tiêm phòng
    public class DocDanhSachTiemPhongInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
    }
    public class TiemPhongModelInput
    {
        public List<TiemPhongInput> DanhSachTiemPhong { get; set; }
        public TiemPhongModelInput()
        {
            DanhSachTiemPhong = new List<TiemPhongInput>();
        }
    }
    public class TiemPhongInput : ChungThuc
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public string TenVietTat { get; set; }
        public string MoTa { get; set; }
        public string GhiChu { get; set; }
    }
    #endregion

    #region Thống kế người sử dụng app 
    public class DanhSachNguoiSuDungAppInput : ChungThuc
    {
        public string IdHuyen { get; set; }
        public string IdXa { get; set; }
        public string IdAp { get; set; }
    }
    public class DanhSachNguoiSuDungAppOutput
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public int TongSoThietBi { get; set; }
    }
    #endregion
    #region Hộ nuôi dịch bệnh thủy sản
    public class HoNuoiDichBenhThuySanInput
    {
        public class TongAoNuoi
        {
            public int SoAo { get; set; }
            public double DienTich { get; set; }
        }

        public class TongDichBenh
        {
            public double DienTich { get; set; }
            public double LuyKeDienTich { get; set; }
            public double TuNgay { get; set; }
            public double DenNgay { get; set; }
            public string IdDichBenh { get; set; }
            public string TenDichBenh { get; set; }
            public string IdSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string NgayTuoi { get; set; }
            public string BBHT { get; set; }
            public string IdHinhThucNuoi { get; set; }
            public string NgayPhatHienBenh { get; set; }
            public string TenHinhThucNuoi { get; set; }
        }
        public class ThongTinHoNuoiDichBenhThuySan : ChungThuc
        {
            public string Id { get; set; }
            public string IdDonVi { get; set; }
            public string TenDonVi { get; set; }
            public string IdHoNuoi { get; set; }
            public string TenHoNuoi { get; set; }

            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }

            public TongAoNuoi ThongTinTongAoNuoi { get; set; }

            public TongDichBenh ThongTinTongDichBenh { get; set; }
            public int TrangThai { get; set; }
            public int LoaiBaoCao { get; set; }
            public bool XuatBan { get; set; }

            public double NgayLapBaoCao { get; set; }
            public string NoiDungPheDuyet { get; set; }
            public string GhiChu { get; set; }
            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
        }
        public class ThongTinHoNuoiDichBenhThuySanFormInput
        {
            public string Id { get; set; }
            public string IdDonVi { get; set; }
            public string TenDonVi { get; set; }
            public string IdHoNuoi { get; set; }
            public string TenHoNuoi { get; set; }

            public string IdHuyen { get; set; }
            public string IdXa { get; set; }
            public string IdAp { get; set; }

            public int SoAo { get; set; }
            public double DienTich { get; set; }

            public double DienTichDichBenh { get; set; }
            public double LuyKeDienTich { get; set; }
            public double TuNgay { get; set; }
            public double DenNgay { get; set; }
            public string IdDichBenh { get; set; }
            public string TenDichBenh { get; set; }
            public string IdSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string NgayTuoi { get; set; }
            public string BBHT { get; set; }
            public string IdHinhThucNuoi { get; set; }
            public string NgayPhatHienBenh { get; set; }
            public string TenHinhThucNuoi { get; set; }
            public string NoiDungPheDuyet { get; set; }
            public string GhiChu { get; set; }
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
        }
        public class Them : ThongTinHoNuoiDichBenhThuySan
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string LoaiXuLy { get; set; }
        }

        public class ThemDanhSach : ChungThuc
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public List<ThongTinHoNuoiDichBenhThuySan> DanhSachHoNuoiDichBenhThuySan { get; set; }
        }
        public class XoaDanhSach : ChungThuc
        {
            public List<string> DanhSachId { get; set; }
        }
    }
    #endregion
    #region Báo cáo Hộ nuôi dịch bệnh thủy sản
    public class BaoCaoHoNuoiDichBenhThuySanInput
    {
        public class TongAoNuoi
        {
            public int SoAo { get; set; }
            public double DienTich { get; set; }
        }

        public class TongDichBenh
        {
            public double DienTich { get; set; }
            public double DienTichDangNuoi { get; set; }
            public double LuyKeDienTich { get; set; }
            public double TuNgay { get; set; }
            public double DenNgay { get; set; }
            public List<string> DanhSachIdDichBenh { get; set; }
            //public string TenDichBenh { get; set; }
            public List<string> DanhSachIdSanPham { get; set; }
            //public string TenSanPham { get; set; }
            public string NgayTuoi { get; set; }
            //public string BBHT { get; set; }
            public List<string> DanhSachIdHinhThucNuoi { get; set; }
            public string MucDichNuoi { get; set; }
            public string NgayPhatHienBenh { get; set; }
        }
        public class ThongTinBaoCaoHoNuoiDichBenhThuySan : ChungThuc
        {
            public string Id { get; set; }
            public string IdDonVi { get; set; }
            public string TenDonVi { get; set; }

            public string IdHuyen { get; set; }
            public string IdXa { get; set; }

            public TongAoNuoi ThongTinTongAoNuoi { get; set; }
            public TongDichBenh ThongTinTongDichBenh { get; set; }

            public int LoaiBaoCao { get; set; }
            public bool XuatBan { get; set; }
            public double NgayLapBaoCao { get; set; }
            public string GhiChu { get; set; }
            public int TrangThai { get; set; }
            public string NoiDungPheDuyet { get; set; }
            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
        }
        public class ThongTinBaoCaoHoNuoiDichBenhThuySanFormInput
        {
            public string Id { get; set; }
            public string IdDonVi { get; set; }
            public string TenDonVi { get; set; }

            public string IdHuyen { get; set; }
            public string IdXa { get; set; }

            public int SoAo { get; set; }
            public double DienTich { get; set; }
            public double DienTichDichBenh { get; set; }
            public double DienTichDangNuoi { get; set; }
            public double LuyKeDienTich { get; set; }
            public double TuNgay { get; set; }
            public double DenNgay { get; set; }
            public List<string> DanhSachIdDichBenh { get; set; }
            //public string TenDichBenh { get; set; }
            public List<string> DanhSachIdSanPham { get; set; }
            //public string TenSanPham { get; set; }
            public string NgayTuoi { get; set; }
            //public string BBHT { get; set; }
            public List<string> DanhSachIdHinhThucNuoi { get; set; }
            public string MucDichNuoi { get; set; }
            public string NgayPhatHienBenh { get; set; }

            public int LoaiBaoCao { get; set; }
            public bool XuatBan { get; set; }
            public double NgayLapBaoCao { get; set; }
            public string GhiChu { get; set; }
            public int TrangThai { get; set; }
            public string NoiDungPheDuyet { get; set; }
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string IdBieuMauBaoCaoChanNuoiThuY { get; set; }
        }
        public class Them : ThongTinBaoCaoHoNuoiDichBenhThuySan
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string LoaiXuLy { get; set; }
        }

        public class ThemDanhSach : ChungThuc
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public List<ThongTinBaoCaoHoNuoiDichBenhThuySan> DanhSachBaoCaoHoNuoiDichBenhThuySan { get; set; }
        }
        public class XoaDanhSach : ChungThuc
        {
            public List<string> DanhSachId { get; set; }
        }
    }
    #endregion
    #region Phê duyệt giá
    public class PheDuyetGia : ChungThuc
    {
        public int Tuan { get; set; }
        public int Nam { get; set; }
        public int Thang { get; set; }
        public List<ThongTinSanPham> DanhSachThongTinSanPham { get; set; }
        public class ThongTinSanPham
        {
            public string IdTinh { get; set; }
            public string IdSanPham { get; set; }
            public string IdQuyCach { get; set; }
            public string IdDonViTinh { get; set; }

        }
    }
    #endregion
    #region Phê duyệt giá giống
    public class PheDuyetGiaGiong : ChungThuc
    {
        public int Tuan { get; set; }
        public int Nam { get; set; }
        public int Thang { get; set; }
        public List<ThongTinSanPham> DanhSachThongTinSanPham { get; set; }
        public class ThongTinSanPham
        {
            public string IdTinh { get; set; }
            public string IdSanPham { get; set; }
            public string IdQuyCach { get; set; }
            public string IdDonViTinh { get; set; }
            public string IdCapGiong { get; set; }
            public string IdChieuCao { get; set; }
            public string IdCoBau { get; set; }
            public string IdKichCo { get; set; }
            public string IdNgayTuoi { get; set; }
        }
    }
    #endregion
    #region Sở Nông Nghiệp
    public class SoNongNghiepInput
    {
        public class DocDanhSachTheoLoaiBaoCao : ChungThuc
        {
            public string TuKhoa { get; set; }
            public int Nam { get; set; }
            public int LoaiBaoCao { get; set; }
            public int ViTriBatDau { get; set; }
            public int ViTriKetThuc { get; set; }
        }
        public class DocDanhSachCoDieuKien : ChungThuc
        {
            public int Nam { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public string TuKhoa { get; set; }
            public int TrangThai { get; set; }
            public int ViTriBatDau { get; set; }
            public int ViTriKetThuc { get; set; }
        }
        public class Them : ChungThuc
        {
            public string TieuDe { get; set; }
            public string DuongDanThanThien { get; set; }
            public string NoiDungTomTat { get; set; }
            public string NoiDung { get; set; }
            public string HinhDaiDien { get; set; }
            public int DoUuTien { get; set; }
            public int TrangThai { get; set; }
            public int Nam { get; set; }
            public int Thang { get; set; }
            public int Tuan { get; set; }
            public int SauThang { get; set; }
            public int Quy { get; set; }
            public int LoaiBaoCao { get; set; }
        }
        public class Sua : Them
        {
            public string Id { get; set; }
        }
    }
    #endregion
    #region Nhóm thông tin cho người dân
    public class DocDanhSachNhomBaiVietChoNguoiDanInput : DocDanhSachPhanTrang
    {
        public string TuKhoa { get; set; }
    }
    public class NhomBaiVietChoNguoiDanModelInput : PhanTrangInput
    {
        public List<NhomBaiVietChoNguoiDan> DanhSachNhomBaiVietChoNguoiDan { get; set; }
        public NhomBaiVietChoNguoiDanModelInput()
        {
            DanhSachNhomBaiVietChoNguoiDan = new List<NhomBaiVietChoNguoiDan>();
        }

    }
    public class NhomBaiVietChoNguoiDan : ChungThuc
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public string Ma { get; set; }
        public string MoTa { get; set; }
        public bool KichHoat { get; set; }
        public bool DaXoa { get; set; }
        public string GhiChu { get; set; }
        public int ViTri { get; set; }
    }
    #endregion
    #region Bài viết cho người dân
    public class BaiVietChoNguoiDan : ChungThuc
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
        public string IdNhomBaiVietChoNguoiDan { get; set; }
    }
    public class DocDanhSachBaiVietChoNguoiDan : ChungThuc
    {
        public string TuKhoa { get; set; }
        public string IdNhomBaiVietChoNguoiDan { get; set; }
        public int ViTriBatDau { get; set; }
        public int ViTriKetThuc { get; set; }
    }
    #endregion
    #region Thông tin năm
    public class DocDanhSachTuanInput : ChungThuc
    {
        public int Nam { get; set; }
    }
    #endregion

}