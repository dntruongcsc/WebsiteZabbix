using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVCProjectStructure.Areas.NguoiDung.Models;
using MVCProjectStructure.Areas.Admin.Models.Menu;
using MVCProjectStructure.Areas.Admin.Models.NhatKy;
using MVCProjectStructure.Areas.ChucVu.Models;
using MVCProjectStructure.Areas.PhongBan.Models;
using MVCProjectStructure.Areas.QuangCao.Models;
using MVCProjectStructure.Areas.TinTuc.Models;
using MVCProjectStructure.Areas.Admin.Models;
using MVCProjectStructure.Areas.ThongBaoKhan.Models;

namespace MVCProjectStructure.Models
{
    public class CommonModel
    {
        #region Dùng chung
        public class CommonInput
        {
            public class ChungThuc
            {
                [ScaffoldColumn(false)]
                public string TokenNguoiDung { get; set; }
                [ScaffoldColumn(false)]
                public string TokenApi { get; set; }
            }
            public class UserToken : ChungThuc { }
            public class DocDanhSach : ChungThuc { }
            public class DocThongTin : ChungThuc
            {
                public string Id { get; set; }
            }
            public class XoaInput : ChungThuc
            {
                public string Id { get; set; }
            }
            public class XoaDanhSachInput : ChungThuc
            {
                public List<string> Ids { get; set; }
            }
            public class DocThongTinInput : ChungThuc
            {
                public string Id { get; set; }
            }
            public class TimKiem : ChungThuc
            {
                public string TuKhoa { get; set; }
                public int ViTriBatDau { get; set; }
                public int ViTriKetThuc { get; set; }
            }
            public class XoaDanhSachInput2 : ChungThuc
            {
                public List<string> Ids { get; set; }
            }
            public class DocDanhSachPhanTrangInput : ChungThuc
            {
                public int SoDong { get; set; }
                public int DongBatDau { get; set; }
            }
            #region Không chứng thực
            public class DocDanhSachKT { }
            public class DocThongTinKT
            {
                public string Id { get; set; }
            }
            #endregion
        }
        public class CommonDocDanhSachOutput
        {
            public int TrangHienTai { get; set; }
            public int TongSoDong { get; set; }
            public int TongSoTrang { get; set; }
        }
        public class CommonOutput : OutputModel
        {
            public string TongSoLuong { get; set; }
        }
        public class OutputModel
        {
            public int KetQua { get; set; }
            public string ThongBao { get; set; }
            public object DuLieu { get; set; }
            public string GhiChu { get; set; }
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

        public class Zabbix
        {

            public class Param
            {
                public string[] Output { set; get; }
            }
            
        }
        #endregion

        #region Area Admin (Người dùng, Chức năng, Biểu mẫu in ấn)
        public class CommonNguoiDung : Areas.NguoiDung.Models.NguoiDungModel { }
        public class CommonDanhMucBieuMauInAn : DanhMucBieuMauInAnModel { }
        public class CommonDanhMucLoaiBieuMauInAn : DanhMucLoaiBieuMauInAnModel { }
        public class CommonChucNang : ChucNangModel { }
        public class CommonDanhMucLoaiHuong : ChucNangModel { }
        public class CommonDanhMucLoaiHuongDan : DanhMucLoaiHuongDanModel { }
        public class CommonHuongDanSuDung : HuongDanSuDungModel { }

        #endregion
        public class CommonTaiKhoan : TaiKhoanModel { }
        public class CommonPhanQuyen : PhanQuyenModel { }
        public class CommonVaiTro : VaiTroModel { }
        public class CommonDonVi : DonViModel { }
        public class CommonChucNangXuLy : ChucNangXuLyModel { }
        public class CommonPhongBan : PhongBanModel { }

        public class CommonMenu : MenuModel { }
        public class CommonNhatKy : NhatKyModel { }
        public class CommonChucVu : ChucVuModel { }
        public class CommonQuangCao : QuangCaoModel { }
        public class CommonQuangCaoLoai : QuangCaoLoaiModel { }
        
        public class CommonNhomTin : NhomTinModel { }
        public class CommonBaiViet : BaiVietModel { }
        
        #region Tỉnh/Huyện/Xã Model
        public class CommonTinh
        {
            public class TinhInput
            {
                public class DocDanhSach : CommonInput.ChungThuc
                {
                }
                public class DocDanhSachWeb : CommonInput.ChungThuc
                {
                    public string TuKhoa { get; set; }
                    public int ViTriBatDau { get; set; }
                    public int ViTriKetThuc { get; set; }
                }
                public class DocThongTin : CommonInput.ChungThuc
                {
                    public string Id { get; set; }
                }
            }
            public class XaInput
            {
                public string IdHuyen { get; set; }
            }
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
                public class ThongTinTinhWeb : CommonInput.ChungThuc
                {
                    public string Id { get; set; }
                    public string Ten { get; set; }
                    public string Ma { get; set; }
                    public bool TinhHienTai { get; set; }
                }
                public class ThongTinTinh
                {
                    public string Id { get; set; }
                    public string Ten { get; set; }
                    public string Ma { get; set; }
                    public List<Huyen> DanhSachHuyen { get; set; }
                    public ThongTinTinh()
                    {
                        DanhSachHuyen = new List<Huyen>();
                    }
                }
                public class DocDanhSach : CommonDocDanhSachOutput
                {
                    public List<ThongTinTinh> DanhSach { get; set; }
                }
                public class DocDanhSachWebHuyen : CommonDocDanhSachOutput
                {
                    public List<ThongTinTinhWeb> DanhSach { get; set; }

                }
            }
        }
        public class CommonHuyen
        {
            public class HuyenInput
            {
                public class DocDanhSachTheoIdTinh : CommonInput.ChungThuc
                {
                    public string IdTinh { get; set; }
                }
                public class DocDanhSach : CommonInput.ChungThuc
                {
                }
                public class DocDanhSachWeb : CommonInput.ChungThuc
                {
                    public string TuKhoa { get; set; }
                    public string IdTinh { get; set; }
                    public int ViTriBatDau { get; set; }
                    public int ViTriKetThuc { get; set; }
                }
                public class DocThongTin : CommonInput.ChungThuc
                {
                    public string Id { get; set; }
                }
            }
            public class HuyenOutput
            {
                public class ThongTin
                {
                    public string Id { get; set; }
                    public string Ten { get; set; }
                }
                public class ThongTinTinhWeb : CommonInput.ChungThuc
                {
                    public string Id { get; set; }
                    public string Ten { get; set; }
                    public string Ma { get; set; }
                    public string IdTinh { get; set; }
                    public string TenTinh { get; set; }
                    public string MaTinh { get; set; }

                }
                public class DocDanhSach : CommonDocDanhSachOutput
                {
                    public List<ThongTinTinhWeb> DanhSach { get; set; }
                }
            }
        }
        public class CommonXa
        {
            public class XaInput
            {
                public class DocDanhSachTheoIdHuyen : CommonInput.ChungThuc
                {
                    public string IdHuyen { get; set; }
                }
                public class DocDanhSachWeb : CommonInput.ChungThuc
                {
                    public string TuKhoa { get; set; }
                    public string IdHuyen { get; set; }
                    public int ViTriBatDau { get; set; }
                    public int ViTriKetThuc { get; set; }
                }
                public class DocThongTin : CommonInput.ChungThuc
                {
                    public string Id { get; set; }
                }
            }
            public class XaOutput
            {
                public class ThongTin
                {
                    public string Id { get; set; }
                    public string Ten { get; set; }
                }
                public class ThongTinTinhWeb : CommonInput.ChungThuc
                {
                    public string Id { get; set; }
                    public string Ten { get; set; }
                    public string Ma { get; set; }
                    public string IdHuyen { get; set; }
                    public string TenHuyen { get; set; }
                    public string MaHuyen { get; set; }

                }
                public class DocDanhSach : CommonDocDanhSachOutput
                {
                    public List<ThongTinTinhWeb> DanhSach { get; set; }
                }
            }
        }
        public class CommonAp
        {
            public class ApInput
            {
                public class DocDanhSachTheoIdXa : CommonInput.ChungThuc
                {
                    public string IdXa { get; set; }
                }
            }
            public class ApOutput
            {
                public class ThongTin
                {
                    public string Id { get; set; }
                    public string Ten { get; set; }
                }
            }
        }
        #endregion
        #region Thông tin chung
        public class CommonThongTinChung
        {
            public string Id { get; set; }
            public string Ma { get; set; }
            public string Ten { get; set; }
        }
        #endregion

        public class CommonNamThangTuan
        {
            public class ThongTinTuanInput : CommonInput.ChungThuc
            {
                public int Nam { get; set; }
            }
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
        public class CommonAo
        {
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

            }
            #endregion
        }

        public class CommonThongBaoKhan : ThongBaoKhanModel { }
        public class CommonThietBiDiDong
        {
            public class Input
            {
                public class ThongTin : CommonInput.ChungThuc
                {
                    //
                }
                public class TimKiem : CommonInput.TimKiem
                {
                    //
                }
            }
            public class Output
            {
                public class ThongTin
                {
                    //
                }

                public class DocDanhSach : CommonDocDanhSachOutput
                {
                    public List<ThongTin> DanhSach { get; set; }
                }
                public class SoLuongThietBiDiDong
                {
                    public int SoLuongThietBi { get; set; }
                    public int SoLuongThietBiApple { get; set; }
                    public int SoLuongThietBiAndroid { get; set; }
                }
            }
        }

        public class CommonDocDanhSachDanhMuc
        {
            public List<ThongTin> DanhSach { get; set; }
            public class ThongTin
            {
                public string Id { get; set; }
                public string Ma { get; set; }
                public string Ten { get; set; }
            }
        }
       
        public class CommonThoiTiet
        {
            public class Input
            {

            }
            public class Output
            {
                public class ThongTinThoiTietHienTai
                {
                    public string MaThietBi { get; set; }
                    public string TenThietBi { get; set; }
                    public string ThoiGian { get; set; }
                    public double NhietDoHienTai { get; set; }
                    public int Icon { get; set; }
                    public double DoAm { get; set; }
                    public double TocDoGio { get; set; }
                    public double SucGio { get; set; }
                    public string HuongGio { get; set; }
                    public double TiaUV { get; set; }
                    public string MotaUV { get; set; }
                    public double NangLuongMatTroi { get; set; }
                    public double LuongMua { get; set; }
                    public bool CoMua { get; set; }
                }
                public class ThoiTietTungBuoi
                {
                    public string NgayTrongTuan { set; get; }
                    public string DataTime { set; get; }
                    public string MoTaTrongNgay { set; get; }
                    public string ChuKiTrang { set; get; }
                    public int DoPhuMay { set; get; }
                    public double LuongMuaDuDoan { set; get; }
                    public double NhietDoMax { set; get; }
                    public double NhietDoMin { set; get; }
                    public string BuoiTrongNgay { set; get; }
                    public int IconCode { set; get; }
                    public string MoTaTungBuoi { set; get; }
                    public double KhaNangMua { set; get; }
                    public double DoAm { set; get; }
                    public double NhietDo { set; get; }
                    public string MoTaUV { set; get; }
                    public double NangLuongMatTroi { set; get; }
                    public double ChiSoUV { set; get; }
                    public string HuongGio { set; get; }
                    public double TocDoGio { set; get; }
                }
            }
        }
    }
}