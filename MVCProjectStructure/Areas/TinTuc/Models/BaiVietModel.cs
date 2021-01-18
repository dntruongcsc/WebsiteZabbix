using MVCProjectStructure.Helpers;
using MVCProjectStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.TinTuc.Models
{
    public class BaiVietModel
    {
        public class Input : CommonInput.ChungThuc
        {
            public class ThongTinBaiViet:CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string TieuDe { get; set; }
                public string TieuDeRutGon { get; set; }
                public string DuongDan { get; set; }
                public string TuKhoa { get; set; }
                public string NoiDungTomTat { get; set; }
                public string NoiDung { get; set; }
                public string HinhDaiDien { get; set; }
                public int ThuTu { get; set; }
                public bool KichHoat { get; set; }
                public bool TrangChu { get; set; }
                public bool NoiBat { get; set; }
                public bool UuTien { get; set; }
                public bool GioiHanThoiGian { get; set; }
                public string IdNhomTin { get; set; }
                public string TieuDeSeo { get; set; }
                public string MoTa { get; set; }
                public string TapTinDinhKem { get; set; }
                public string NgayTao { get; set; }
                public bool ThongBao { get; set; }
                public string IdNguoiCapNhat { get; set; }
            }
            public class TimKiemBaiViet : CommonInput.TimKiem
            {
                public int TrangHienTai { get; set; }
                public string Id { get; set; }
                public List<string> DanhSachIdDonVi { get; set; }
            }
            public class DocBaiVietNoiBat : ChungThuc
            {
                public int Trang { get; set; }
                public int SoLuong { get; set; }
                public string DuongDanNhomTin { get; set; }
            }
            public class DocDanhSachTimKiem : ChungThuc
            {
                public int Trang { get; set; }
                public int SoLuong { get; set; }
                public string TuKhoa { get; set; }
            }
        }
        public class Output
        {
            public class ThongTinDuLieu
            {
                public int TrangHienTai { get; set; }
                public List<ThongTin> DanhSachThongTinBaiViet { get; set; }
                public ThongTinDuLieu()
                {
                    DanhSachThongTinBaiViet = new List<ThongTin>();
                }
            }
            public class ThongTinKetQua
            {
                public int KetQua { get; set; }
                public string ThongBao { get; set; }
                public ThongTinDuLieu DuLieu { get; set; }
                public string GhiChu { get; set; }

                public ThongTinKetQua()
                {
                    DuLieu = new ThongTinDuLieu();
                }
            }

            public class ThongTin
            {
                public string Id { get; set; }
                public string TieuDe { get; set; }
                public string TieuDeRutGon { get; set; }
                public string DuongDan { get; set; }
                public string TuKhoa { get; set; }
                public string NoiDungTomTat { get; set; }
                public string NoiDung { get; set; }
                public string HinhDaiDien { get; set; }
                public int ThuTu { get; set; }
                public bool KichHoat { get; set; }
                public bool TrangChu { get; set; }
                public bool NoiBat { get; set; }
                public bool UuTien { get; set; }
                public bool ThongBao { get; set; }
                public bool GioiHanThoiGian { get; set; }
                public string IdNhomTin { get; set; }
                public string IdDonVi { get; set; }
                public string TenNhomTin { get; set; }
                public string TieuDeSeo { get; set; }
                public string MoTa { get; set; }
                public string TapTinDinhKem { get; set; }
                public double NgayTao { get; set; }
                public string ChuoiNgayTao { get; set; }
                public string ChuoiNgayTao1 { get; set; }
                //Bổ sung dùng cho khai thác
                public string DuongDanNhom { get; set; }
                public string NguoiCapNhat { get; set; }
            }
            public class DocDanhSach
            {
                public int TongSoTrang { get; set; }
                public int TongSoLuong { get; set; }
                public int TrangHienTai { get; set; }
                public List<ThongTin> DanhSachThongTinBaiViet { get; set; }
                public class ThongTinBaiViet : ThongTin { }
                public DocDanhSach()
                {
                    DanhSachThongTinBaiViet = new List<ThongTin>();
                }
            }
            public class TimKiemPhanTrang : DocDanhSach { }
        }

    }
}