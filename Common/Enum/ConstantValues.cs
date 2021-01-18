using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enum
{

    public class ConstantValues
    {
        public const string VaiTroQuanTriHeThong = "5872e91b7600651905cc82b5";
        public const string SessionKeyCurrentUser = "CurrentUser";
        public const string SessionKeyVaiTro = "VaiTroHeThong";
        public const string SessionKeyUserId = "userID";
        public const string SessionKeyMenu = "Menu";
        public const string SessionKeyUrl = "Url";

        public const string MaPhanCachGiaTri = "|pmks|";
        public const string MaPhanCachTuNguoiDung = "|||";

        public class Message
        {
            public const string ThanhCong = "Thành công.";
            public const string ThatBai = "Thất bại!";
            public const string LoiDuLieu = "Lỗi dữ liệu!";
            public const string LoiServer = "Lỗi server!";
            public const string LoiTruyCap = "Lỗi truy cập!";
            public const string ChuaDangNhap = "Chưa đăng nhập!";

            public const string CapNhatThanhCong = "Cập nhật thành công. ";
            public const string CapNhatThatBai = "Cập nhật thất bại! ";
            public const string KhongCoQuyen = "Bạn không có quyền truy cập chức năng này!";
            public const string DangNhapLai = "Vui lòng đăng nhập lại!";
        }
        public class LinhVuc
        {
            public const string AnToanThucPham = "AnToanThucPham";
            public const string ThuySan = "ThuySan";
            public const string LamNghiep = "LamNghiep";
        }
        public class Image
        {
            public const string Default01 = "/Content/Data/he-thong/images_web/no-image01.jpg";
            public const string Default02 = "/Content/Data/he-thong/images_web/no-image02.jpg";
        }
    }
    public enum LoaiBaoCao
    {
        BaoCaoTuan, BaoCaoThang, BaoCaoQuy, BaoCaoSauThang, BaoCaoNam
    }
    public enum LoaiDonViBaoCao
    {
        Ap, Xa, Huyen, Tinh
    }
    public class APIUrl
    {
        #region Chiều cao
        public class ChieuCao
        {
            public const string DocDanhSach = "api/ChieuCao/DocDanhSach";
        }
        #endregion
        #region Cở bầu
        public class CoBau
        {
            public const string DocDanhSach = "api/CoBau/DocDanhSach";
        }
        #endregion
        #region Cấp giống
        public class CapGiong
        {
            public const string DocDanhSach = "api/CapGiong/DocDanhSach";
        }
        #endregion
        #region Kích cỡ
        public class KichCo
        {
            public const string DocDanhSach = "api/KichCo/DocDanhSach";
        }
        #endregion
        #region Quy cách
        public class QuyCach
        {
            public const string DocDanhSach = "/api/quycach/docdanhsach";
            public const string Them = "/api/quycach/Them";
            public const string Sua = "/api/quycach/Sua";
            public const string XoaDanhSach = "/api/quycach/XoaDanhSach";
            public const string DocDanhSachPhanTrang = "/api/quycach/DocDanhSachPhanTrang";
            public const string DocThongTin = "/api/quycach/DocThongTin";
        }
        #endregion
        #region Đơn vị tính
        public class DonViTinh
        {
            public const string DocDanhSach = "/api/donvitinh/docdanhsach";
            public const string Them = "/api/donvitinh/Them";
            public const string Sua = "/api/donvitinh/Sua";
            public const string XoaDanhSach = "/api/donvitinh/XoaDanhSach";
            public const string DocThongTin = "/api/donvitinh/DocThongTinWeb";
        }
        #endregion
        #region Sản phẩm
        public class SanPham
        {
            public const string Them = "/api/sanpham/them";
            public const string Sua = "/api/sanpham/sua";
            public const string XoaDanhSach = "/api/sanpham/XoaDanhSach";
            public const string DocThongTin = "/api/sanpham/DocThongTin";
            public const string DocSanPhamTheoMa = "/api/SanPham/DocSanPhamTheoMa";
            public const string DocDanhSachTheoIdNhomSanPham = "/api/SanPham/DocDanhSachTheoIdNhomSanPham";
            public const string DocDanhSachTheoDanhSachIdNhom = "/api/sanpham/DocDanhSachTheoDanhSachIdNhom";
            public const string DocSanPhamTheoChucNangVaBieuMau = "/api/sanpham/DocSanPhamTheoChucNangVaBieuMau";
        }
        #endregion
        #region Nhóm sản phẩm
        //public class NhomSanPham
        //{
        //    public const string DocDanhSach = "/api/NhomSanPham/DocDanhSach";
        //    public const string DocDanhSachTheoIdChucNang = "/api/NhomSanPham/DocDanhSachTheoIdChucNang";
        //    public const string DocNhomSanPhamTheoMa = "/api/NhomSanPham/DocNhomSanPhamTheoMa";
        //    public const string DocDanhSachTheoMaChucNang = "api/NhomSanPham/DocDanhSachTheoMaChucNang";
        //    public const string DocDanhSachTheoDonVi = "/api/NhomSanPham/DocDanhSachTheoDonVi";
        //}
        #endregion
        #region Kỹ thuật nuôi trồng
        public class KyThuatNuoiTrong
        {
            public const string Them = "/api/KyThuatNuoiTrong/Them";
            public const string XoaDanhSach = "/api/KyThuatNuoiTrong/XoaDanhSach";
            public const string DocDanhSach = "/api/KyThuatNuoiTrong/DocDanhSach";
            public const string DocDanhSachKhongKemNoiDung = "/api/KyThuatNuoiTrong/DocDanhSachKhongKemNoiDung";
            public const string DocDanhSachTimKiem = "/api/KyThuatNuoiTrong/TimKiem";
            public const string DocThongTin = "/api/KyThuatNuoiTrong/Doc";
            public const string Sua = "/api/KyThuatNuoiTrong/Sua";
        }
        #endregion

        #region Nhóm bản tin truyền hình
        public class NhomBanTinTruyenHinh
        {
            public const string Them = "/api/NhomBanTinTruyenHinh/Them";
            public const string XoaDanhSach = "/api/NhomBanTinTruyenHinh/XoaDanhSach";
            public const string DocDanhSach = "/api/NhomBanTinTruyenHinh/DocDanhSach";
            public const string DocThongTin = "/api/NhomBanTinTruyenHinh/Doc";
            public const string Sua = "/api/NhomBanTinTruyenHinh/Sua";

            public const string DocDanhSachKT = "/api/NhomBanTinTruyenHinh/DocDanhSachKT";
        }
        #endregion
        #region Bản tin truyền hình
        public class BanTinTruyenHinh
        {
            public const string Them = "/api/BanTinTruyenHinh/Them";
            public const string XoaDanhSach = "/api/BanTinTruyenHinh/XoaDanhSach";
            public const string DocDanhSach = "/api/BanTinTruyenHinh/DocDanhSach";
            public const string DocDanhSachTimKiem = "/api/BanTinTruyenHinh/TimKiem";
            public const string DocThongTin = "/api/BanTinTruyenHinh/Doc";
            public const string Sua = "/api/BanTinTruyenHinh/Sua";
            public const string DocDanhSachPhanTrang = "/api/BanTinTruyenHinh/DocDanhSachPhanTrang";


            public const string DocDanhSachPhanTrangKT = "/api/BanTinTruyenHinh/DocDanhSachPhanTrangKT";
            public const string DocThongTinKT = "/api/BanTinTruyenHinh/DocThongTinKT";
        }
        #endregion
        #region Thông báo khẩn
        public class ThongBaoKhan
        {
            public const string Them = "/api/ThongBaoKhan/Them";
            public const string XoaDanhSach = "/api/ThongBaoKhan/XoaDanhSach";
            public const string DocDanhSach = "/api/ThongBaoKhan/DocDanhSach";
            public const string DocDanhSachWebsite = "/api/ThongBaoKhan/DocDanhSachWebsite";
            public const string DocDanhSachTimKiem = "/api/ThongBaoKhan/TimKiem";
            public const string DocThongTin = "/api/ThongBaoKhan/Doc";
            public const string Sua = "/api/ThongBaoKhan/Sua";
            public const string DocDanhSachPhanTrang = "/api/ThongBaoKhan/DocDanhSachPhanTrang";


            //Khai thác
            public const string DocDanhSachPhanTrang_KT = "/api/ThongBaoKhan/DocDanhSachPhanTrang_KT";
            public const string DocThongTin_KT = "api/ThongBaoKhan/Doc_KT";
        }
        #endregion
        #region Loại thông báo
        public class LoaiThongBao
        {
            public const string DocDanhSach = "api/thongbao/DocDanhSachLoaiThongBao";
        }
        #endregion
        #region Thông báo
        public class ThongBao
        {
            public const string GuiThongBaoChoTatCa = "api/thongbao/GuiThongBaoChoTatCa";
        }
        #endregion
        #region Tài khoản
        public class TaiKhoan
        {
            public const string DangNhap = "api/NguoiDung/DangNhap";
            public const string DangXuat = "api/TaiKhoan/DangXuat";

            // Không dùng nữa
            //public const string DocDanhSachTheoPhongBan = "api/TaiKhoan/DocDanhSachTheoPhongBan";
            //public const string DocDanhSachTheoNhomNguoiDung = "api/TaiKhoan/DocDanhSachTheoNhomNguoiDung";
            //public const string DocDanhSachTheoNhomChucNang = "api/TaiKhoan/DocDanhSachTheoNhomChucNang";
            public const string TimKiemTaiKhoan = "api/TaiKhoan/TimKiemTaiKhoan";

            public const string DocThongTin = "api/TaiKhoan/DocThongTin";
            public const string DocThongTinTuIdNguoiDung = "api/TaiKhoan/DocThongTinTuIdNguoiDung";
            public const string Them = "api/TaiKhoan/Them";
            public const string Sua = "api/TaiKhoan/Sua";
            public const string Xoa = "api/TaiKhoan/Xoa";
            public const string XoaDanhSach = "api/TaiKhoan/XoaDanhSach";

            public const string DocDanhSach = "api/TaiKhoan/DocDanhSach";
            public const string DocDanhSachPhanTrang = "api/TaiKhoan/DocDanhSachPhanTrang";

            //public const string DangNhapTheoIdNguoiDung = "api/TaiKhoan/DangNhapTheoIdNguoiDung";

        }

        #endregion

        #region Tỉnh - Huyện - Xã - Ấp
        public class Tinh
        {
            public const string DocDanhSach = "api/Tinh/DocDanhSach";
            public const string DocThongTin = "api/Tinh/DocThongTin";
            public const string DocDanhSachWeb = "api/Tinh/DocDanhSachWeb";
            public const string DocThongTinWeb = "api/Tinh/DocThongTinWeb";
            public const string DocThongTincbb = "api/Tinh/DocThongTin";
            public const string Them = "api/Tinh/ThemWeb";
            public const string Sua = "api/Tinh/SuaWeb";
            public const string XoaDanhSach = "api/Tinh/XoaDanhSach";
            public const string DocThongTinKT = "api/Tinh/DocThongTinKT";
        }
        public class Huyen
        {
            public const string DocDanhSachHienTai = "api/Huyen/DocDanhSachHienTai";
            public const string DocDanhSach = "api/Huyen/DocDanhSachWeb";
            public const string DocThongTin = "api/Huyen/DocThongTinWeb";
            public const string Them = "api/Huyen/ThemWeb";
            public const string Sua = "api/Huyen/SuaWeb";
            public const string XoaDanhSach = "api/Huyen/XoaDanhSach";
        }
        public class Xa
        {
            public const string DocDanhSachHienTai = "api/Xa/DocDanhSachHienTai";
            public const string DocDanhSach = "api/Xa/DocDanhSachWeb";
            public const string DocThongTin = "api/Xa/DocThongTinWeb";
            public const string Them = "api/Xa/ThemWeb";
            public const string Sua = "api/Xa/SuaWeb";
            public const string XoaDanhSach = "api/Xa/XoaDanhSach";
        }
        #endregion

        #region Admin
        public class Menu
        {
            public const string DocDanhSach = "/api/Menu/DocDanhSach";
            public const string DocDanhSachXuatBan = "/api/Menu/DocDanhSachXuatBan";
            public const string DocDanhSachCoPhanCap = "/api/Menu/DocDanhSachCoPhanCap";
            public const string Them = "/api/Menu/Them";
            public const string DocThongTin = "/api/Menu/DocThongTin";
            public const string CapNhat = "/api/Menu/CapNhat";
            public const string XoaDanhSach = "/api/Menu/XoaDanhSach";
            public const string CapNhatViTri = "/api/Menu/CapNhatViTri";

            public const string DocDanhSachCoPhanCapKT = "/api/Menu/DocDanhSachCoPhanCapKT";
        }

        public class NhatKy
        {
            public const string DocDanhSach = "/api/NhatKy/DocDanhSach";
            public const string XoaDanhSach = "/api/NhatKy/XoaDanhSach";
            public const string Them = "/api/NhatKy/Them";
        }

        public class DanhMucChucNang
        {
            public const string DocDanhSach = "/api/DanhMucChucNang/DocDanhSach";
        }
        #endregion

        #region Phong Ban
        public class PhongBan
        {
            public const string Them = "api/PhongBan/Them";
            public const string DocDanhSach = "api/PhongBan/DocDanhSach";
            public const string DocThongTin = "api/PhongBan/DocThongTin";
            public const string Sua = "api/PhongBan/Sua";
            public const string XoaDanhSach = "api/PhongBan/XoaDanhSach";
        }
        #endregion
        #region Phân quyền
        public class PhanQuyen
        {
            //public const string CapNhat = "api/PhanQuyen/Sua";//Thêm, sửa dùng chung
            public const string CapNhatPhongBan = "api/PhanQuyen/Sua";
            public const string DocThongTinTheoVaiTroVaDonVi = "api/PhanQuyen/DocThongTinTheoVaiTroVaDonVi";

            public const string Them = "api/PhanQuyen/Them";
            public const string DocDanhSach = "api/PhanQuyen/DocDanhSach";
            public const string DocThongTin = "api/PhanQuyen/DocThongTin";
            public const string Sua = "api/PhanQuyen/Sua";
            public const string XoaDanhSach = "api/PhanQuyen/XoaDanhSach";
        }
        #endregion
        #region Chuc Vu
        public class ChucVu
        {
            public const string Them = "api/ChucVu/Them";
            public const string DocDanhSach = "api/ChucVu/DocDanhSach";
            public const string DocThongTin = "api/ChucVu/DocThongTin";
            public const string Sua = "api/ChucVu/Sua";
            public const string XoaDanhSach = "api/ChucVu/XoaDanhSach";
        }
        #endregion
        #region Tin tức
        public class NhomTin
        {
            public const string DocDanhSach = "api/NhomTin/DocDanhSach";
            public const string DocDanhSachXuatBan = "api/NhomTin/DocDanhSachXuatBan";
            public const string TimKiemPhanTrang = "api/NhomTin/TimKiemPhanTrang";
            public const string DocThongTin = "api/NhomTin/DocThongTinNhomTin";
            public const string Them = "api/NhomTin/Them";
            public const string XoaDanhSach = "api/NhomTin/XoaDanhSach";
            public const string Sua = "api/NhomTin/CapNhat";
        }
        public class BaiViet
        {
            public const string DocDanhSach = "api/BaiViet/DocDanhSach";
            public const string DocDanhSachTinNoiBat = "api/BaiViet/DocDanhSachTinNoiBat";
            public const string DocDanhSachTinTheoNhom_KT = "api/BaiViet/DocDanhSachTinTheoNhom_KT";
            public const string DocDanhSachTinTimKiem_KT = "api/BaiViet/DocDanhSachTinTimKiem_KT";
            public const string TimKiemPhanTrang = "api/BaiViet/TimKiemPhanTrang";

            //Tìm tất cả không theo đơn vị
            public const string TimKiemPhanTrang2 = "api/BaiViet/TimKiemPhanTrang2";

            public const string DocThongTin = "api/BaiViet/DocThongTinBaiViet";
            public const string Them = "api/BaiViet/Them";
            public const string XoaDanhSach = "api/BaiViet/XoaDanhSach";
            public const string Sua = "api/BaiViet/CapNhat";

            //Không xác thực
            public const string DocDanhSachXuatBan = "api/BaiViet/DocDanhSachXuatBan";
            public const string DocThongTin_KT = "api/BaiViet/DocThongTinBaiViet_KT";
        }

        public class LoaiBaoCao
        {
            public const string DocDanhSach = "api/LoaiBaoCao/DocDanhSach";
            public const string DocDanhSachXuatBan = "api/LoaiBaoCao/DocDanhSachXuatBan";
            public const string DocDanhSachXuatBan1 = "api/LoaiBaoCao/DocDanhSachXuatBan1";
            public const string TimKiemPhanTrang = "api/LoaiBaoCao/TimKiemPhanTrang";
            public const string DocThongTin = "api/LoaiBaoCao/DocThongTinNhomTin";
            public const string Them = "api/LoaiBaoCao/Them";
            public const string XoaDanhSach = "api/LoaiBaoCao/XoaDanhSach";
            public const string Sua = "api/LoaiBaoCao/CapNhat";
        }
        public class BaiVietChoLanhDao
        {
            public const string DocDanhSach = "api/BaiVietChoLanhDao/DocDanhSach";
            public const string TimKiemPhanTrang = "api/BaiVietChoLanhDao/TimKiemPhanTrang";
            public const string DocThongTin = "api/BaiVietChoLanhDao/DocThongTinBaiViet";
            public const string Them = "api/BaiVietChoLanhDao/Them";
            public const string XoaDanhSach = "api/BaiVietChoLanhDao/XoaDanhSach";
            public const string Sua = "api/BaiVietChoLanhDao/CapNhat";
        }
        #endregion
        #region Quảng cáo
        public class QuangCao
        {
            public const string Them = "api/QuangCao/Them";
            public const string DocDanhSach = "api/QuangCao/DocDanhSach";
            public const string DocThongTin = "api/QuangCao/DocThongTin";
            public const string Sua = "api/QuangCao/Sua";
            public const string XoaDanhSach = "api/QuangCao/XoaDanhSach";
        }
        public class QuangCaoLoai
        {
            public const string Them = "api/QuangCaoLoai/Them";
            public const string DocDanhSach = "api/QuangCaoLoai/DocDanhSach";
            public const string DocThongTin = "api/QuangCaoLoai/DocThongTin";
            public const string Sua = "api/QuangCaoLoai/Sua";
            public const string XoaDanhSach = "api/QuangCaoLoai/XoaDanhSach";
        }
        public class DanhMucDungChung2
        {
            public const string Them = "api/DanhMucDungChung/Them";
            public const string DocDanhSach = "api/DanhMucDungChung/DocDanhSach";
            public const string DocThongTin = "api/DanhMucDungChung/DocThongTin";
            public const string Sua = "api/DanhMucDungChung/Sua";
            public const string XoaDanhSach = "api/DanhMucDungChung/XoaDanhSach";
            public const string DocDanhSachTheoIdChucNang = "api/DanhMucDungChung/DocDanhSachTheoIdChucNang";
        }
        #endregion

        #region Album
        public class Album
        {
            public const string DocDanhSach = "api/Album/DocDanhSach";
            public const string TimKiemPhanTrang = "api/Album/TimKiemPhanTrang";
            public const string DocThongTin = "api/Album/DocThongTinAlbum";
            public const string Them = "api/Album/Them";
            public const string XoaDanhSach = "api/Album/XoaDanhSach";
            public const string Sua = "api/Album/CapNhat";
        }
        #endregion
        #region HinhAnh
        public class HinhAnh
        {
            public const string DocDanhSach = "api/HinhAnh/DocDanhSach";
            public const string TimKiemPhanTrang = "api/HinhAnh/TimKiemPhanTrang";
            public const string DocThongTin = "api/HinhAnh/DocThongTinHinhAnh";
            public const string Them = "api/HinhAnh/Them";
            public const string XoaDanhSach = "api/HinhAnh/XoaDanhSach";
            public const string Sua = "api/HinhAnh/CapNhat";
        }
        #endregion
        #region Video
        public class Video
        {
            public const string DocDanhSach = "api/Video/DocDanhSach";
            public const string TimKiemPhanTrang = "api/Video/TimKiemPhanTrang";
            public const string DocThongTin = "api/Video/DocThongTinVideo";
            public const string Them = "api/Video/Them";
            public const string XoaDanhSach = "api/Video/XoaDanhSach";
            public const string Sua = "api/Video/CapNhat";
        }
        #endregion
        #region Người dùng, đơn vị, vai trò, thông tin về người dùng
        public class DonVi
        {
            public const string DocThongTin = "api/DonVi/DocThongTin";
            public const string Them = "api/DonVi/Them";
            public const string Sua = "api/DonVi/Sua";
            public const string Xoa = "api/DonVi/Xoa";
            public const string XoaDanhSach = "api/DonVi/XoaDanhSach";
            public const string DocDanhSach = "api/DonVi/DocDanhSach";
            public const string DocDanhSachChoChiDaoDieuHanh = "api/DonVi/DocDanhSachChoChiDaoDieuHanh";
            public const string DocDanhSachPhanTrang = "api/DonVi/DocDanhSachPhanTrang";
            public const string DocDanhSachTuDonViCha = "api/DonVi/DocDanhSachTuDonViCha";
            public const string DocDanhSachTuDonViChaCoPhanTrang = "api/DonVi/DocDanhSachTuDonViChaCoPhanTrang";
            public const string DocDanhSachTheoDanhSachId = "api/DonVi/DocDanhSachTheoDanhSachId";
        }
        public class NguoiDung
        {
            public const string DangNhap = "api/NguoiDung/DangNhap";
            public const string XoaDanhSach = "api/NguoiDung/XoaDanhSach";
            public const string DocDanhSach = "api/NguoiDung/DocDanhSach";
            public const string DocThongTin = "api/NguoiDung/DocThongTin";
            public const string Sua = "api/NguoiDung/Sua";
            public const string Them = "api/NguoiDung/Them";
            public const string DoiMatKhau = "api/NguoiDung/DoiMatKhau";
            public const string DocDanhSachPhongBan = "api/NguoiDung/DocDanhSachPhongBan";
            public const string DocDanhSachPhongBanKichHoat = "api/NguoiDung/DocDanhSachPhongBanKichHoat";


            public const string DocThongTinSua = "api/NguoiDung/DocThongTinSua";
            public const string Xoa = "api/NguoiDung/Xoa";
            public const string TimKiemTheoTen = "api/NguoiDung/TimKiemTheoTen";
            public const string TimKiemTheoMaHoacTen = "api/NguoiDung/TimKiemTheoMaHoacTen";
            public const string DocDanhSachTatCa = "api/NguoiDung/DocDanhSachTatCa";
            public const string DocDanhSachPhanTrang = "api/NguoiDung/DocDanhSachPhanTrang";

            //Chỉ dùng cho tài khoản root
            public const string DangNhapTheoIdNguoiDung = "api/NguoiDung/DangNhapTheoIdNguoiDung";
        }
        public class ChucNang
        {
            public const string DocThongTin = "api/ChucNang/DocThongTin";
            public const string DocThongTinTheoMa = "api/ChucNang/DocThongTinTheoMa";
            public const string DocThongTinSua = "api/ChucNang/DocThongTinSua";
            public const string Them = "api/ChucNang/Them";
            public const string Sua = "api/ChucNang/Sua";
            public const string Xoa = "api/ChucNang/Xoa";
            public const string XoaDanhSach = "api/ChucNang/XoaDanhSach";
            public const string DocDanhSach = "api/ChucNang/DocDanhSach";
            public const string DocDanhSachCoPhanCap = "api/ChucNang/DocDanhSachCoPhanCap";
            public const string DocDanhSachChucNangCapCha = "api/ChucNang/DocDanhSachChucNangCapCha";
            public const string DocDanhSachTheoChucNangCha = "api/ChucNang/DocDanhSachTheoChucNangCha";

        }
        public class ChucNangXuLy
        {
            public const string DocDanhSach = "api/ChucNangXuLy/DocDanhSach";
        }
        //public class NhomNguoiDung //--Chuyển sang dùng vai trò
        //{
        //    public const string DocDanhSach = "api/NhomNguoiDung/DocDanhSach";
        //    public const string DocDanhSachTuDanhSachId = "api/NhomNguoiDung/DocDanhSachTuDanhSachId";
        //    public const string DocThongTin = "api/NhomNguoiDung/DocThongTin";
        //    public const string Them = "api/NhomNguoiDung/Them";
        //    public const string Xoa = "api/NhomNguoiDung/Xoa";
        //    public const string XoaDanhSach = "api/NhomNguoiDung/XoaDanhSach";
        //    public const string Sua = "api/NhomNguoiDung/Sua";
        //}
        public class VaiTro
        {
            public const string Them = "api/VaiTro/Them";
            public const string DocDanhSach = "api/VaiTro/DocDanhSach";
        }
        //public class ChucNang
        //{
        //    public const string DocDanhSachCoPhanCap = "/api/Menu/DocDanhSachCoPhanCap";
        //    public const string Them = "/api/Menu/Them";
        //    public const string DocThongTin = "/api/Menu/DocThongTinMenu";
        //    public const string CapNhat = "/api/Menu/CapNhat";
        //    public const string XoaDanhSach = "/api/Menu/XoaDanhSach";
        //    public const string DocDanhSachTheoDieuKien = "/api/Menu/DocDanhSachTheoDieuKien";
        //    public const string DocDanhSachPhanTrang = "/api/Menu/DocDanhSachPhanTrang";

        //}
        public class ThongTinVeNguoiDung
        {
            public const string DocDanhSach = "api/ThongTinVeNguoiDung/DocDanhSach";
        }
        #endregion

        #region Thông tin năm
        public class ThongTinNam
        {
            //public const string Them = "/api/ThongTinNam/Them";
            //public const string XoaDanhSach = "/api/ThongTinNam/XoaDanhSach";
            public const string DocDanhSach = "/api/ThongTinNam/DocDanhSach";
            //public const string DocThongTin = "/api/ThongTinNam/Doc";
            //public const string Sua = "/api/ThongTinNam/Sua";
        }
        #endregion
        #region Thông tin tuần
        public class ThongTinTuan
        {
            public const string Them = "/api/ThongTinTuan/Them";
            public const string XoaDanhSach = "/api/ThongTinTuan/XoaDanhSach";
            public const string DocDanhSach = "/api/ThongTinTuan/DocDanhSach";
            public const string DocThongTin = "/api/ThongTinTuan/Doc";
            public const string Sua = "/api/ThongTinTuan/Sua";
        }
        #endregion

        #region Ao, báo cáo hộ nuôi
        public class Ao
        {
            public const string Them = "api/Ao/Them";
            public const string Sua = "api/Ao/Sua";
            public const string Xoa = "api/Ao/Xoa";
            public const string Doc = "api/Ao/Doc";
            public const string DocDanhSach = "api/Ao/DocDanhSach";
            public const string ThemDanhSach = "api/Ao/ThemDanhSach";

            public const string DocDanhSachTheoIdHoNuoi = "api/Ao/DocDanhSachTheoIdHoNuoi";
            public const string DocDanhSachTinhTrang = "api/Ao/DocDanhSachTinhTrang";
            public const string DocDanhSachHinhThucNuoi = "api/ao/DocDanhSachHinhThucNuoi";
            public const string DocDanhSachHinhThucNuoiChoNuoiTom = "api/ao/DocDanhSachHinhThucNuoiChoNuoiTom";
        }
        public class BaoCaoHoNuoi
        {
            public const string DocDanhSach = "api/BaoCaoHoNuoi/DocDanhSach";
            public const string DocDanhSachDuLieuGanNhat = "api/BaoCaoHoNuoi/DocDanhSachDuLieuGanNhat";
            public const string TongHopDuLieu = "api/BaoCaoHoNuoi/TongHopDuLieu";
            public const string ThemDanhSach = "api/BaoCaoHoNuoi/ThemDanhSach";
            public const string Xoa = "api/BaoCaoHoNuoi/Xoa";
            public const string XuatBanCapTinh = "api/BaoCaoHoNuoi/XuatBanCapTinh";
            public const string BoXuatBanCapTinh = "api/BaoCaoHoNuoi/BoXuatBanCapTinh";
        }

        public class DuLieuNongNghiep
        {
            public class ChiCucThuySan
            {
                public class QuyanLyDienTich
                {
                    public const string XuatBanCapTinh = "api/BaoCaoHoNuoiThaGiongThuHoach/XuatBanCapTinh";
                    public const string BoXuatBanCapTinh = "api/BaoCaoHoNuoiThaGiongThuHoach/BoXuatBanCapTinh";
                }
            }
        }
        #endregion

        #region Biểu mẩu in ấn
        public class BieuMauInAn
        {
            public const string Them = "api/BieuMauInAn/Them";
            public const string DocDanhSach = "api/BieuMauInAn/DocDanhSach";
            public const string DocDanhSachTheoMaLoai = "api/BieuMauInAn/DocDanhSachTheoMaLoai";
            public const string DocThongTin = "api/BieuMauInAn/DocThongTin";
            public const string Sua = "api/BieuMauInAn/Sua";
            public const string XoaDanhSach = "api/BieuMauInAn/XoaDanhSach";
        }
        public class LoaiBieuMauInAn
        {
            public const string DocDanhSach = "api/LoaiBieuMauInAn/DocDanhSach";
        }
        #endregion
        #region Hướng dẫn sử dụng
        public class HuongDanSuDung
        {
            public const string Them = "api/HuongDanSuDung/Them";
            public const string DocDanhSach = "api/HuongDanSuDung/DocDanhSach";
            public const string DocDanhSachTheoMaLoai = "api/HuongDanSuDung/DocDanhSachTheoMaLoai";
            public const string DocThongTin = "api/HuongDanSuDung/DocThongTin";
            public const string Sua = "api/HuongDanSuDung/Sua";
            public const string XoaDanhSach = "api/HuongDanSuDung/XoaDanhSach";
        }
        public class DanhMucLoaiHuongDanSuDung
        {
            public const string DocDanhSach = "api/DanhMucLoaiHuongDanSuDung/DocDanhSach";
        }
        #endregion
        #region LVKhuyenNong
        public class TuVanTrucTuyen
        {
            public const string DocDanhSach = "api/TuVanTrucTuyen/DocDanhSach";
            public const string DocThongTin = "api/TuVanTrucTuyen/DocThongTin";
            public const string Them = "api/TuVanTrucTuyen/Them";
            public const string Sua = "api/TuVanTrucTuyen/Sua";
            public const string XoaDanhSach = "api/TuVanTrucTuyen/XoaDanhSach";
            public const string DuyetCauHoi = "api/TuVanTrucTuyen/DuyetCauHoi";
            public const string XoaDanhSachCauHoi = "api/TuVanTrucTuyen/XoaDanhSachCauHoi";
            public const string GuiCauHoi = "api/TuVanTrucTuyen/GuiCauHoi";
        }
        public class ThoiTietNongVu
        {
            public const string Them = "/api/ThoiTietNongVu/Them";
            public const string XoaDanhSach = "/api/ThoiTietNongVu/XoaDanhSach";
            public const string DocDanhSach = "/api/ThoiTietNongVu/DocDanhSach";
            public const string DocDanhSachWebsite = "/api/ThoiTietNongVu/DocDanhSachWebsite";
            public const string DocDanhSachTimKiem = "/api/ThongBaoKhan/TimKiem";
            public const string DocThongTin = "/api/ThoiTietNongVu/Doc";
            public const string Sua = "/api/ThoiTietNongVu/Sua";
            public const string DocDanhSachPhanTrang = "/api/ThoiTietNongVu/DocDanhSachPhanTrang";
        }
        public class KyThuatSanXuatNongNghiep
        {
            public const string Them = "/api/KyThuatNuoiTrong/Them";
            public const string XoaDanhSach = "/api/KyThuatNuoiTrong/XoaDanhSach";
            public const string DocDanhSach = "/api/KyThuatNuoiTrong/DocDanhSach";
            public const string DocDanhSachWebsite = "/api/KyThuatNuoiTrong/DocDanhSachWebsite";
            public const string DocDanhSachTimKiem = "/api/KyThuatNuoiTrong/TimKiem";
            public const string DocThongTin = "/api/KyThuatNuoiTrong/Doc";
            public const string Sua = "/api/KyThuatNuoiTrong/Sua";
            public const string DocDanhSachPhanTrang = "/api/KyThuatNuoiTrong/DocDanhSachPhanTrang";

            //Không xác thực
            public const string DocDanhSachPhanTrangKT = "/api/KyThuatNuoiTrong/DocDanhSachPhanTrangKT";
            public const string DocThongTinKT = "/api/KyThuatNuoiTrong/DocThongTinKT";
            //public const string NhomKyThuatNuoiTrong = "/api/NhomKyThuatNuoiTrong/DocDanhSachPhanTrang";
        }

        public class DonViTrucTuyen
        {
            public const string DocDanhSach = "api/DonViTrucTuyen/DocDanhSach";

            public const string DocThongTin = "api/DonViTrucTuyen/DocThongTin";
            public const string Them = "api/DonViTrucTuyen/Them";
            public const string Sua = "api/DonViTrucTuyen/Sua";
            public const string XoaDanhSach = "api/DonViTrucTuyen/XoaDanhSach";
        }
        #endregion
        public class NhomKyThuatNuoiTrong
        {
            public const string Them = "/api/NhomKyThuatNuoiTrong/Them";
            public const string XoaDanhSach = "/api/NhomKyThuatNuoiTrong/XoaDanhSach";
            public const string DocDanhSach = "/api/NhomKyThuatNuoiTrong/DocDanhSach";
            public const string DocThongTin = "/api/NhomKyThuatNuoiTrong/Doc";
            public const string Sua = "/api/NhomKyThuatNuoiTrong/Sua";

            public const string DocDanhSachKT = "/api/NhomKyThuatNuoiTrong/DocDanhSachKT";
        }


        #region Chỉ đạo điều hành
        public class ChiDaoDieuHanh
        {
            public const string Them = "/api/ThongTinChiDao/Them";
            public const string Sua = "/api/ThongTinChiDao/sua";
            public const string XoaDanhSach = "/api/ThongTinChiDao/XoaDanhSach";
            public const string DocDanhSach = "/api/ThongTinChiDao/DocDanhSach";
            public const string DocThongTin = "/api/ThongTinChiDao/docthongtin";
            public const string DocDanhSachTimKiem = "/api/ThongTinChiDao/TimKiemPhanTrang";

            //Không xác thực
            public const string DocDanhSachPhanTrang_KT = "/api/ThongTinChiDao/DocDanhSachPhanTrang_KT";
            public const string DocThongTin_KT = "/api/ThongTinChiDao/DocThongTin_KT";
        }
        #endregion
        #region Phản ảnh nhanh
        public class PhanAnhNhanh
        {
            public const string DocDanhSach = "/api/PhanAnhNguoiDan/DocDanhSach";
            public const string Them = "/api/PhanAnhNguoiDan/Them";
            public const string Sua = "/api/PhanAnhNguoiDan/Sua";
            public const string TimKiem = "/api/PhanAnhNguoiDan/TimKiem";
            public const string DocThongTin = "/api/PhanAnhNguoiDan/DocThongTin";
            public const string DocThongTinPhanHoi = "api/PhanAnhNguoiDan/DocThongTinPhanHoi";
            public const string CapNhat = "/api/PhanAnhNguoiDan/CapNhat";
            public const string XoaDanhSach = "/api/PhanAnhNguoiDan/XoaDanhSach";
            //public const string DocDanhSachWebsite = "/api/PhanAnhNguoiDan/DocDanhSachWebsite";
            public const string DocDanhSachTheoDonVi = "/api/PhanAnhNguoiDan/DocDanhSachTheoDonVi";


            public const string DocDanhSachKT = "/api/PhanAnhNguoiDan/DocDanhSachKT";
            public const string DocThongTinKT = "/api/PhanAnhNguoiDan/DocThongTinKT";
        }
        #endregion
        #region Loại hình phản ánh
        public class LoaiHinhPhanAnh
        {
            public const string DocDanhSach = "/api/LoaiPhanAnhNguoiDan/DocDanhSach";
            public const string DocDanhSachWebsite = "/api/LoaiPhanAnhNguoiDan/DocDanhSachWebsite";

            public const string DocDanhSachKT = "/api/LoaiPhanAnhNguoiDan/DocDanhSachKT";
        }
        #endregion
        #region Thông tin giết mổ
        public class ThongTinGietMo
        {
            public const string Them = "/api/ThongTinGietMo/Them";
            public const string ThemDanhSach = "/api/ThongTinGietMo/ThemDanhSach";
            public const string DocDanhSach = "/api/ThongTinGietMo/DocDanhSach";
            public const string DocSoLieu = "/api/ThongTinGietMo/DocSoLieu";
            public const string PheDuyetDuLieu = "/api/ThongTinGietMo/PheDuyet";
            public const string TongHopDuLieu = "/api/ThongTinGietMo/TongHopDuLieu";
            public const string XoaDanhSach = "/api/ThongTinGietMo/XoaDanhSach";
        }
        #endregion
        #region Thông tin kiểm dịch
        public class ThongTinKiemDich
        {
            public const string Them = "/api/ThongTinKiemDich/Them";
            public const string ThemDanhSach = "/api/ThongTinKiemDich/ThemDanhSach";
            public const string DocDanhSach = "/api/ThongTinKiemDich/DocDanhSach";
            public const string DocSoLieu = "/api/ThongTinKiemDich/DocSoLieu";
            public const string PheDuyetDuLieu = "/api/ThongTinKiemDich/PheDuyet";
            public const string XoaDanhSach = "/api/ThongTinKiemDich/XoaDanhSach";
        }
        #endregion
        #region Hộ nuôi dịch bệnh thủy sản
        public class HoNuoiDichBenhThuySan
        {
            public const string Them = "api/HoNuoiDichBenhThuySan/Them";
            public const string ThemDanhSach = "api/HoNuoiDichBenhThuySan/ThemDanhSach";
            public const string DocDanhSach = "api/HoNuoiDichBenhThuySan/DocDanhSach";
            public const string DocDanhSachThuySanDichBenhHoNuoiHinhThucNuoiMucDichNuoi = "/api/HoNuoiDichBenhThuySan/DocDanhMucTheoIdBieuMauBaoCao";
            public const string XoaDanhSach = "api/HoNuoiDichBenhThuySan/XoaDanhSach";
        }

        #endregion
        #region Thủy sản
        public class ThuySan
        {
            public const string Them = "/api/ThuySan/Them";
            public const string Sua = "/api/ThuySan/Sua";
            public const string DocDanhSachTheoBieuMau = "/api/ThuySan/DocDanhSachDuLieuTheoIdBieuMauBaoCao";
            public const string DocDanhSachTheoNam = "/api/ThuySan/DocDanhSachTheoNam";
            public const string DocThongTin = "/api/ThuySan/DocThongTin";
            public const string DocDanhSach = "/api/ThuySan/DocDanhSach";
            public const string XoaDanhSach = "/api/ThuySan/XoaDanhSach";

        }
        #endregion
        #region Báo cáo Hộ nuôi dịch bệnh thủy sản
        public class BaoCaoHoNuoiDichBenhThuySan
        {
            public const string Them = "api/BaoCaoHoNuoiDichBenhThuySan/Them";
            public const string ThemDanhSach = "api/BaoCaoHoNuoiDichBenhThuySan/ThemDanhSach";
            public const string DocDanhSach = "api/BaoCaoHoNuoiDichBenhThuySan/DocDanhSach";
            public const string DocSoLieu = "api/BaoCaoHoNuoiDichBenhThuySan/DocSoLieu";
            public const string TongHopSoLieuTuXa = "api/BaoCaoHoNuoiDichBenhThuySan/TongHopSoLieuTuXa";
            public const string TongHopSoLieuTuHuyen = "api/BaoCaoHoNuoiDichBenhThuySan/TongHopSoLieuTuHuyen";
            public const string XoaDanhSach = "api/BaoCaoHoNuoiDichBenhThuySan/XoaDanhSach";
            public const string PheDuyetDuLieu = "/api/BaoCaoHoNuoiDichBenhThuySan/PheDuyet";
        }
        #endregion
        #region Thông tin đều tra tổng đàn
        public class ThongTinDieuTraTongDan
        {
            public const string Them = "/api/ThongTinDieuTraTongDan/Them";
            public const string ThemDanhSach = "/api/ThongTinDieuTraTongDan/ThemDanhSach";
            public const string DocDanhSach = "/api/ThongTinDieuTraTongDan/DocDanhSach";
            public const string DocSoLieu = "/api/ThongTinDieuTraTongDan/DocSoLieu";
            public const string PheDuyetDuLieu = "/api/ThongTinDieuTraTongDan/PheDuyet";
            public const string XoaDanhSach = "/api/ThongTinDieuTraTongDan/XoaDanhSach";
        }
        #endregion
        #region LV Chăn nuôi Thú Y
        public class DichBenhThuY
        {
            public const string DocDanhSach = "/api/DichBenhThuY/DocDanhSach";
            public const string DocThongTin = "/api/DichBenhThuY/DocThongTin";
            public const string Them = "/api/DichBenhThuY/Them";
            public const string Sua = "/api/DichBenhThuY/Sua";
            public const string XoaDanhSach = "/api/DichBenhThuY/XoaDanhSach";
        }
        public class ChanNuoiThuY
        {
            public const string Them = "/api/ChanNuoiThuY/Them";
            public const string Sua = "/api/ChanNuoiThuY/Sua";
            public const string DocDanhSach = "/api/ChanNuoiThuY/DocDanhSachCoDieuKien";
            public const string DocDanhSachTheoNam = "/api/ChanNuoiThuY/DocDanhSachTheoNam";
            public const string DocThongTin = "/api/ChanNuoiThuY/DocThongTin";
            public const string XoaDanhSach = "/api/ChanNuoiThuY/XoaDanhSach";
            public const string DocDanhSachDuLieuTheoIdBieuMauBaoCaoGomNhomTheoBieuMau = "/api/ChanNuoiThuY/DocDanhSachDuLieuTheoIdBieuMauBaoCaoGomNhomTheoBieuMau";
        }
        public class BieuMauBaoCaoChanNuoiThuY
        {
            public const string DocDanhSach = "/api/BieuMauBaoCaoChanNuoiThuY/DocDanhSach";
        }
        public class LoaiTiemPhong
        {
            public const string DocDanhSach = "/api/loaitiemphong/docdanhsach";
            public const string DocThongTin = "/api/loaitiemphong/DocThongTin";
            public const string Them = "/api/loaitiemphong/Them";
            public const string Sua = "/api/loaitiemphong/Sua";
        }
        #endregion
        #region quản lý chất lương
        public class ChatLuong
        {
            public const string DocDanhSach = "/api/ChatLuong/DocDanhSach";
            public const string DocThongTin = "/api/ChatLuong/DocThongTin";
            public const string Them = "/api/ChatLuong/Them";
            public const string Sua = "/api/ChatLuong/Sua";
            public const string XoaDanhSach = "/api/ChatLuong/XoaDanhSach";
        }
        public class ChatLuongChuCoSo
        {
            public const string DocDanhSach = "/api/ChatLuongChuCoSo/DocDanhSach";
            public const string DocDanhSachRutGon = "/api/ChatLuongChuCoSo/DocDanhSachRutGon";
            public const string DocThongTin = "/api/ChatLuongChuCoSo/DocThongTin";
            public const string Them = "/api/ChatLuongChuCoSo/Them";
            public const string Sua = "/api/ChatLuongChuCoSo/Sua";
            public const string XoaDanhSach = "/api/ChatLuongChuCoSo/XoaDanhSach";
        }
        public class ChatLuongCapPhep
        {
            public const string DocDanhSach = "/api/ChatLuongCapPhep/DocDanhSach";
            public const string DocDanhSachLichSuCapPhep = "/api/ChatLuongCapPhep/DocDanhSachLichSuCapPhep";
            public const string GiaHanCapPhep = "/api/ChatLuongCapPhep/GiaHanCapPhep";
            public const string DocThongTin = "/api/ChatLuongCapPhep/DocThongTin";
            public const string Them = "/api/ChatLuongCapPhep/ThemThongTin";
            public const string Sua = "/api/ChatLuongCapPhep/Sua";
            public const string XoaDanhSach = "/api/ChatLuongCapPhep/XoaDanhSach";
            public const string Xoa = "/api/ChatLuongCapPhep/Xoa";
            public const string ThongKe = "/api/ChatLuongCapPhep/ThongKe";
        }
        public class ChatLuongLoaiHinhSXKD
        {
            public const string DocDanhSach = "/api/ChatLuongLoaiHinhSXKD/DocDanhSach";
            public const string DocThongTin = "/api/ChatLuongLoaiHinhSXKD/DocThongTin";
            public const string Them = "/api/ChatLuongLoaiHinhSXKD/ThemThongTin";
            public const string Sua = "/api/ChatLuongLoaiHinhSXKD/Sua";
            public const string XoaDanhSach = "/api/ChatLuongLoaiHinhSXKD/XoaDanhSach";
        }

        public class ChatLuongHinhThucCap
        {
            public const string DocDanhSach = "/api/ChatLuongHinhThucCap/DocDanhSach";
            public const string DocThongTin = "/api/ChatLuongHinhThucCap/DocThongTin";
            public const string Them = "/api/ChatLuongHinhThucCap/ThemThongTin";
            public const string Sua = "/api/ChatLuongHinhThucCap/Sua";
            public const string XoaDanhSach = "/api/ChatLuongHinhThucCap/XoaDanhSach";
        }

        public class ChatLuongLoaiCoSo
        {
            public const string DocDanhSach = "/api/ChatLuongLoaiCoSo/DocDanhSach";
            public const string DocThongTin = "/api/ChatLuongLoaiCoSo/DocThongTin";
            public const string Them = "/api/ChatLuongLoaiCoSo/ThemThongTin";
            public const string Sua = "/api/ChatLuongLoaiCoSo/Sua";
            public const string XoaDanhSach = "/api/ChatLuongLoaiCoSo/XoaDanhSach";
        }

        public class ChatLuongCapQuanLy
        {
            public const string DocDanhSach = "/api/ChatLuongCapQuanLy/DocDanhSach";
            public const string DocThongTin = "/api/ChatLuongCapQuanLy/DocThongTin";
            public const string Them = "/api/ChatLuongCapQuanLy/ThemThongTin";
            public const string Sua = "/api/ChatLuongCapQuanLy/Sua";
            public const string XoaDanhSach = "/api/ChatLuongCapQuanLy/XoaDanhSach";
        }

        public class ChatLuongCoQuanQuanLy
        {
            public const string DocDanhSach = "/api/ChatLuongCoQuanQuanLy/DocDanhSach";
            public const string DocThongTin = "/api/ChatLuongCoQuanQuanLy/DocThongTin";
            public const string Them = "/api/ChatLuongCoQuanQuanLy/ThemThongTin";
            public const string Sua = "/api/ChatLuongCoQuanQuanLy/Sua";
            public const string XoaDanhSach = "/api/ChatLuongCoQuanQuanLy/XoaDanhSach";
        }

        public class ChatLuongCapQuyenSuDungNhanHieu
        {
            public const string DocDanhSach = "/api/ChatLuongCapQuyenSuDungNhanHieu/DocDanhSach";
            public const string DocThongTin = "/api/ChatLuongCapQuyenSuDungNhanHieu/DocThongTin";
            public const string Them = "/api/ChatLuongCapQuyenSuDungNhanHieu/Them";
            public const string Sua = "/api/ChatLuongCapQuyenSuDungNhanHieu/Sua";
            public const string XoaDanhSach = "/api/ChatLuongCapQuyenSuDungNhanHieu/XoaDanhSach";
        }

        public class ChatLuongHeThongDBCLATTP
        {
            public const string DocDanhSach = "/api/ChatLuongHeThongDBCLATTP/DocDanhSach";
            public const string DocThongTin = "/api/ChatLuongHeThongDBCLATTP/DocThongTin";
            public const string Them = "/api/ChatLuongHeThongDBCLATTP/ThemThongTin";
            public const string Sua = "/api/ChatLuongHeThongDBCLATTP/Sua";
            public const string XoaDanhSach = "/api/ChatLuongHeThongDBCLATTP/XoaDanhSach";
        }
        public class DanhMucNganhKinhTeVietNam
        {
            public const string DocDanhSachNganhNghe = "/api/DanhMucNganhKinhTeVietNam/DocDanhSachNganhNghe";
            public const string DocDanhSachLinhVucTheoNganhNghe = "/api/DanhMucNganhKinhTeVietNam/DocDanhSachLinhVucTheoNganhNghe";
        }

        public class ChatLuongXepLoai
        {
            public const string DocDanhSach = "/api/ChatLuongXepLoai/DocDanhSach";
        }

        public class ChatLuongKiemTra
        {
            public const string DocDanhSach = "/api/ChatLuongKiemTra/DocDanhSach";
            public const string DocDanhSachLichSu = "/api/ChatLuongKiemTra/DocDanhSachLichSu";
            public const string Them = "/api/ChatLuongKiemTra/Them";
            public const string Sua = "/api/ChatLuongKiemTra/Sua";
            public const string XoaDanhSach = "/api/ChatLuongKiemTra/XoaDanhSach";
            public const string DocThongTinKiemTraCoSo = "/api/ChatLuongKiemTra/DocThongTinKiemTraCoSo";
        }

        public class ThongTinXacNhanKienThucATTP
        {
            public const string DocDanhSach = "/api/ThongTinXacNhanKienThucATTP/DocDanhSach";
            public const string Them = "/api/ThongTinXacNhanKienThucATTP/Them";
            public const string DocThongTin = "/api/ThongTinXacNhanKienThucATTP/DocThongTin";
            public const string Sua = "/api/ThongTinXacNhanKienThucATTP/Sua";
            public const string XoaDanhSach = "/api/ThongTinXacNhanKienThucATTP/XoaDanhSach";
            public const string ThongKeTheoHuyen = "/api/ThongTinXacNhanKienThucATTP/ThongKeTheoHuyen";
        }

        public class ChatLuongDuLuongChatDocHai
        {
            public const string DocDanhSach = "/api/ChatLuongDuLuongChatDocHai/DocDanhSach";
            public const string Them = "/api/ChatLuongDuLuongChatDocHai/Them";
            public const string DocThongTin = "/api/ChatLuongDuLuongChatDocHai/DocThongTin";
            public const string Sua = "/api/ChatLuongDuLuongChatDocHai/Sua";
            public const string XoaDanhSach = "/api/ChatLuongDuLuongChatDocHai/XoaDanhSach";
            public const string DanhSachDoiTuong = "/api/ChatLuongDoiTuong/DocDanhSach";
        }

        public class ChatLuongCoSoTuCongBoSanPham
        {
            public const string DocDanhSachCoSo = "/api/ChatLuongCongBoSanPham/DocDanhSachKhongNoiDung";
            public const string DocThongTinCoSo = "/api/ChatLuongCongBoSanPham/DocThongTinCoSo";
            public const string DocThongTin = "/api/ChatLuongCongBoSanPham/DocThongTin";

            public const string DocDanhSach = "/api/ChatLuongCongBoSanPham/DocDanhSach";
            public const string Them = "/api/ChatLuongCongBoSanPham/Them";
            public const string Sua = "/api/ChatLuongCongBoSanPham/Sua";
            public const string XoaDanhSach = "/api/ChatLuongCongBoSanPham/XoaDanhSach";
        }

        public class ChuoiCungUng
        {
            public const string DocDanhSachLoaiSanPham = "/api/ChatLuongLoaiSanPham/DocDanhSach";
            public const string DocDanhSach = "/api/ChatLuongChuoiCungUng/DocDanhSach";
            public const string Them = "/api/ChatLuongChuoiCungUng/Them";
            public const string DocThongTin = "/api/ChatLuongChuoiCungUng/DocThongTin";
            public const string Sua = "/api/ChatLuongChuoiCungUng/Sua";
            public const string XoaDanhSach = "/api/ChatLuongChuoiCungUng/XoaDanhSach";
        }

        public class ThongKe
        {
            public const string ThongKeTheoHuyen = "/api/ThongKe/ThongKeTheoHuyen";
        }

        public class ChatLuongViPham
        {
            public const string DocDanhSachLichSu = "/api/ChatLuongViPham/DocDanhSachLichSu";
            public const string DocDanhSachCoDieuKien = "/api/ChatLuongViPham/DocDanhSachCoDieuKien";
            public const string Them = "/api/ChatLuongViPham/Them";
            public const string Xoa = "/api/ChatLuongViPham/Xoa";
            public const string XoaDanhSach = "/api/ChatLuongViPham/XoaDanhSach";
        }
        public class XuLyViPhamDanhMucDieu
        {
            public const string DocDanhSachTheoLinhVuc = "/api/XuLyViPhamDanhMucDieu/DocDanhSachTheoLinhVuc";
            public const string Them = "/api/XuLyViPhamDanhMucDieu/Them";
            public const string Sua = "/api/XuLyViPhamDanhMucDieu/Sua";
            public const string XoaDanhSach = "/api/XuLyViPhamDanhMucDieu/XoaDanhSach";
        }
        public class XuLyViPhamDanhMucKhoan
        {
            public const string DocDanhSachTheoLinhVuc = "/api/XuLyViPhamDanhMucKhoan/DocDanhSachTheoLinhVuc";
            public const string Them = "/api/XuLyViPhamDanhMucKhoan/Them";
            public const string Sua = "/api/XuLyViPhamDanhMucKhoan/Sua";
            public const string XoaDanhSach = "/api/XuLyViPhamDanhMucKhoan/XoaDanhSach";
        }
        public class XuLyViPhamDanhMucDiem
        {
            public const string DocDanhSachTheoLinhVuc = "/api/XuLyViPhamDanhMucDiem/DocDanhSachTheoLinhVuc";
            public const string Them = "/api/XuLyViPhamDanhMucDiem/Them";
            public const string Sua = "/api/XuLyViPhamDanhMucDiem/Sua";
            public const string XoaDanhSach = "/api/XuLyViPhamDanhMucDiem/XoaDanhSach";
        }

        public class BienBanInAn
        {
            public const string DocThongTin = "/api/TauCaBienBanInAn/DocThongTin";
            public const string DocDanhSachTheoIdDieuKien = "/api/TauCaBienBanInAn/DocDanhSachTheoIdDieuKien";
            public const string DocThongTinGiayChungNhanDangKyTauCa = "/api/TauCaDangKy/DocThongTinBienBanTuIdDangKy";
            public const string sua = "/api/TauCaBienBanInAn/Sua";
            public const string DocDanhSachBieuMauInAn = "api/BieuMauInAn/DocDanhSach";
            public const string DocDanhSachTheoMaLoai = "api/BieuMauInAn/DocDanhSachTheoMaLoai";
        }
        #endregion

 

        #region Thiết bị di động
        public class ThietBiDiDong
        {
            public const string DocSoLuongThietBiDiDong = "api/ThietBiDiDong/DocSoLuongThietBiDiDong";
        }
        #endregion

       

        #region Báo cáo Sở nông nghiệp
        public class BaoCaoSoNongNghiep
        {
            public const string Them = "/api/BaoCaoSoNongNghiep/Them";
            public const string Sua = "/api/BaoCaoSoNongNghiep/Sua";
            public const string DocDanhSach = "/api/BaoCaoSoNongNghiep/DocDanhSachCoDieuKien";
            public const string DocThongTin = "/api/BaoCaoSoNongNghiep/DocThongTin";
            public const string XoaDanhSach = "/api/BaoCaoSoNongNghiep/XoaDanhSach";
            public const string BaoCaoSoNongNghiepDocDanhSachTheoNam = "/api/BaoCaoSoNongNghiep/DocDanhSachTheoNam";
        }
        #endregion

        #region Dữ liệu ngành
        public class NganhKeHoachNganHan
        {
            public const string DocDanhSach = "/api/NganhKeHoachNganHan/DocDanhSach";
            public const string ThemDanhSach = "/api/NganhKeHoachNganHan/ThemDanhSach";
            public const string Xoa = "/api/NganhKeHoachNganHan/Xoa";

            public const string DocDanhSachKT = "/api/NganhKeHoachNganHan/DocDanhSachKT";
        }
        public class NganhKeHoachTrungHan
        {
            public const string DocDanhSach = "/api/NganhKeHoachTrungHan/DocDanhSach";
            public const string ThemDanhSach = "/api/NganhKeHoachTrungHan/ThemDanhSach";
            public const string Xoa = "/api/NganhKeHoachTrungHan/Xoa";

            public const string DocDanhSachKT = "/api/NganhKeHoachTrungHan/DocDanhSachKT";
        }
        public class NganhThucHienNam
        {
            public const string DocDanhSach = "/api/NganhThucHienNam/DocDanhSach";
            public const string ThemDanhSach = "/api/NganhThucHienNam/ThemDanhSach";
            public const string Xoa = "/api/NganhThucHienNam/Xoa";

            public const string DocDanhSachKT = "/api/NganhThucHienNam/DocDanhSachKT";
        }
        public class NganhThucHienThang
        {
            public const string DocDanhSach = "/api/NganhThucHienThang/DocDanhSach";
            public const string ThemDanhSach = "/api/NganhThucHienThang/ThemDanhSach";
            public const string Xoa = "/api/NganhThucHienThang/Xoa";

            public const string DocDanhSachKT = "/api/NganhThucHienThang/DocDanhSachKT";
        }

        #endregion
        #region Thiết Bị Giám Sát
        public class ThietBi
        {
            public const string DocDanhSach = "/api/ThietBi/DocDanhSachWeb";
            public const string DocThongTin = "/api/ThietBi/DocThongTin";
            public const string Them = "/api/ThietBi/Them";
            public const string Sua = "/api/ThietBi/Sua";
            public const string XoaDanhSach = "/api/ThietBi/XoaDanhSach";
        }
        #endregion
        #region Nhật Ký Thiết Bị Giám Sát
        public class NhatKyThietBi
        {
            public const string DocDanhSach = "/api/ThietBi/DocDanhSachNhatKy";
            public const string DocThongTin = "/api/ThietBi/DocThongTinNhatKy";
            public const string Them = "/api/ThietBi/Them";
            public const string Sua = "/api/ThietBi/SuaNhatKy";
            public const string XoaDanhSach = "/api/ThietBi/XoaDanhSachNhatKy";
        }
        #endregion

        #region Thời tiết
        public class ThoiTiet
        {
            public const string LayDuBaoThoiTiet5Ngay = "/api/ThoiTiet/LayDuBaoThoiTiet5Ngay";
            public const string LayThoiTietHienTai = "/api/ThoiTiet/LayThoiTietHienTai";
        }
        #endregion
        #region Zabbix
        public class Zabbix
        {
            public class Host
            {
                public const string DocDanhSach = "host.get";
                public const string Them = "host.create";
                public const string Sua = "host.update";
                public const string Xoa = "host.delete";
       
            }
            public class HostGroup
            {
                public const string DocDanhSach = "hostgroup.get";
                public const string Them = "hostgroup.create";
                public const string Sua = "hostgroup.update";
                public const string Xoa = "hostgroup.delete";
            }
            public class Template
            {
                public const string DocDanhSach = "template.get";
                public const string Them = "template.create";
                public const string Sua = "template.update";
                public const string Xoa = "template.delete";
            }
            
            //public const string DocDanhSachGroups = "hostgroup.get";
            //public const string DocDanhSachTemplate = "template.get";
           
            
        }
        #endregion
    }
}