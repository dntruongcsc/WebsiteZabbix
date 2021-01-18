using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Enum
{
    public class ChucNang
    {
        public static List<DanhMucChucNang> DanhMucDungChung = new List<DanhMucChucNang>()
        {
            new DanhMucChucNang(){MaChucNang = "0",TenChucNang = "---Chọn nhóm---"},
            new DanhMucChucNang(){MaChucNang = "PhongBan",TenChucNang = "Danh mục phòng ban"},
            new DanhMucChucNang(){MaChucNang = "ChucVu",TenChucNang = "Danh mục chức vụ"}
        };
        public class Ma
        {
            public const string BangDieuKhien = "BangDieuKhien";
            public const string BaiViet = "QuanLyBaiViet";
            public const string NhomTin = "QuanLyNhomTin";
            public const string BaiVietChoLanhDao = "BaiVietChoLanhDao";
            public const string LoaiBaoCao = "QuanLyLoaiBaoCao";
            public const string DanhMucPhongBan = "DanhMucPhongBan";
            public const string DanhMucChucVu = "DanhMucPhongBan";
            public const string HinhAnh = "QuanLyHinhAnh";
            public const string Album = "QuanLyAlbum";
            public const string Video = "QuanLyVideo";
            public const string DanhMucDungChung = "QuanLyDanhMucDungChung";
            
            public const string PhanQuyen = "QuanLyPhanQuyen";
            public const string NhatKySuDung = "NhatKySuDung";
            public const string QuangCao = "QuanLyQuangCao";
            public const string ChucVu = "QuanLyChucVu";
            public const string Menu = "QuanLyMenu";

            public const string VaiTro = "VaiTro";

            #region Thông tin người dùng
            public const string ThongTinNguoiDung = "ThongTinNguoiDung";
            public const string QuanLyTaiKhoan = "QuanLyTaiKhoan";
            public const string PhanQuyenSuDung = "PhanQuyenSuDung";
            public const string QuanLyChucVu = "QuanLyChucVu";
            #endregion

            public const string QuanLyBieuMauInAn = "QuanLyBieuMauInAn";
            public const string QuanLyBanTinTruyenHinh = "QuanLyBanTinTruyenHinh";
            public const string QuanLyThoiTietNongVu = "QuanLyThoiTietNongVu";
            public const string QuanLyThongBaoKhan = "QuanLyThongBaoKhan";
            public const string QuanLyKyThuatSanXuatNongNghiep = "QuanLyKyThuatSanXuatNongNghiep";
            public const string QuanLyDanhMucThuoc = "QuanLyDanhMucThuoc";
            public const string QuanLyDanhMucNguyenLieuThuoc = "QuanLyDanhMucNguyenLieuThuoc";

            #region Chi cục thủy sản
            public const string QuanLyDienTich = "QuanLyDienTich";
            public const string LVTSSoLieuBaoCao = "LVTSSoLieuBaoCao";
            #endregion

            #region Trồng trọ và bvtv
           
            public const string SoLieuBaoCao = "SoLieuBaoCao";
            #endregion

            #region Giá cả thị trường
            public const string DanhMucNgayTuoi = "DanhMucNgayTuoi";
            public const string QuanLyCacLoaiGiong = "QuanLyCacLoaiGiong";
            public const string DanhMucQuycach = "DanhMucQuycach";
            public const string DanhMucDonViTinh = "DanhMucDonViTinh";
            public const string DanhMucMatHang = "DanhMucMatHang";
            public const string GiaTrongTinh = "GiaTrongTinh";
            public const string GiaHiepHoi = "GiaHiepHoi";
            public const string GiaTinhLanCan = "GiaTinhLanCan";
            public const string GiaGiongNongNghiep= "GiaGiongNongNghiep";
            #endregion

            public const string ChiDaoDieuHanh = "ChiDaoDieuHanh";
            public const string PhanAnhNhanh = "PhanAnhNhanh";

            #region LVQLChatLuong
            public const string ChatLuongViPham = "ChatLuongViPham";
            public const string ThongTinCoSo = "ThongTinCoSo";
            #endregion

            #region LVLamNghiep
            public const string LamNghiepViPham = "LamNghiepViPham";
            #endregion

            #region LVThuyLoi
            public const string QuanLyCong = "QuanLyCong";
            public const string ThongKeCong = "ThongKeCong";
            public const string QuanLyKe = "QuanLyKe";
            public const string ThongKeKe = "ThongKeKe";
            #endregion

            #region Sàn Giao Dịch Nông Sản
            public const string ThanhVien = "QuanLyThanhVien";
            #endregion

            #region Hướng dẫn sử dụng
            public const string HuongDanSuDung = "HuongDanSuDung";
            #endregion

            #region Dữ liệu ngành
            public const string KeHoachNganHan = "KeHoachNganHan";
            public const string KeHoachTrungHan = "KeHoachTrungHan";
            public const string KetQuaThucHienNam = "KetQuaThucHienNam";
            public const string KetQuaThucHienThang = "KetQuaThucHienThang";
            #endregion
        }
        public class GiaoDien
        {
            public const string SBAdmin = "~/Views/Shared/_SBAdmin.cshtml";
        }
        public class DuongDan
        {
            //Cập nhật thêm dường dẫn chuyển trang khi hết session
            public const string ChuyenTrangDangNhap = "/NguoiDung/TaiKhoan/ChuyenTrangDangNhap";
            public const string DangNhap = "/NguoiDung/TaiKhoan/Login";
            public const string BangDieuKhien = "/Home/Index";
            public const string SessionTimeout = "/Home/SessionTimeout";
            public const string KhongCoQuyenTruyCap = "/Home/Index";
        }

    }
    public class QuyenHan
    {
        public class Ma
        {
            public const string Xem = "Xem";
            public const string Them = "Them";
            public const string Sua = "Sua";
            public const string Xoa = "Xoa";
            public const string PheDuyet = "Duyet";
        }
    }
    public class DanhMucChucNang
    {
        public string MaChucNang { get; set; }
        public string TenChucNang { get; set; }
    }

    public class NhatKy
    {
        public class LoaiNhatKy
        {
            public const string DangNhap = "DangNhap";
            public const string DangXuat = "DangXuat";
            public const string ThemMoi = "ThemMoi";
            public const string CapNhat = "CapNhat";
            public const string Xoa = "Xoa";
            public const string Loi = "Loi";
            public const string CanhBao = "CanhBao";
        }
    }
}
