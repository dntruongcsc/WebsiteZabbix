using MVCProjectStructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.PhanAnhNhanh.Models
{
    public class PhanAnhNhanhModel
    {
        public class Input
        {
            public class Them : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string TieuDe { get; set; }
                public string NoiDung { get; set; }
                public string Sdt { get; set; }
                public string TenNguoiPhanAnh { get; set; }
                public string IdLoaiPhanAnhNguoiDan { get; set; }
                public string DiaChi { get; set; }
                public string ThoiGian { get; set; }
                public string ToaDo { get; set; }
                public string IdAp { get; set; }
                public string IdXa { get; set; }
                public string IdHuyen { get; set; }
                public int TrangThai { get; set; }
                public bool XuatBan { get; set; }
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
                public string TenNguoiPheDuyet { get; set; }

                public class TapTin
                {
                    public string Ten { get; set; }
                    public string LoaiTapTin { get; set; }
                    public string TenThumbnail { get; set; }
                }
                public Them()
                {
                    DanhSachTapTin = new List<TapTin>();
                    ThongTinPhanHoi = new PhanHoi();
                }
            }

            public class DocDanhSach : CommonInput.ChungThuc
            {
                public int ViTriBatDau { get; set; }
                public int ViTriKetThuc { get; set; }
                public string IdAp { get; set; }
                public string IdXa { get; set; }
                public string IdHuyen { get; set; }
                public double NgayBatDau { get; set; }
                public double NgayKetThuc { get; set; }
                public int Nam { get; set; }
                public int Thang { get; set; }
                public int Tuan { get; set; }
                public string IdNguoiDung { get; set; }
                public string MaMay { get; set; }
                public string IdLoaiPhanAnhNguoiDan { get; set; }
            }
            public class DocDanhSachKT
            {
                public int ViTriBatDau { get; set; }
                public int ViTriKetThuc { get; set; }
                public string IdAp { get; set; }
                public string IdXa { get; set; }
                public string IdHuyen { get; set; }
                public double NgayBatDau { get; set; }
                public double NgayKetThuc { get; set; }
                public int Nam { get; set; }
                public int Thang { get; set; }
                public int Tuan { get; set; }
                public string IdNguoiDung { get; set; }
                public string MaMay { get; set; }
                public string IdLoaiPhanAnhNguoiDan { get; set; }
            }
            public class TimKiem : CommonInput.ChungThuc
            {
                public string IdLoaiPhanAnhNguoiDan { get; set; }
                public int Thang { get; set; }
                public int Nam { get; set; }
                public int ViTriBatDau { get; set; }
                public int ViTriKetThuc { get; set; }
                public string IdAp { get; set; }
                public string IdXa { get; set; }
                public string IdHuyen { get; set; }
            }
            //public class CapNhat : CommonInput.ChungThuc
            //{
            //    public string Id { get; set; }
            //    public int TrangThai { get; set; }
            //    public bool XuatBan { get; set; }
            //    public string NoiDungPhanHoi { get; set; }
            //    public List<TapTin> DanhSachTapTin { get; set; }
            //    public string IdLoaiPhanAnhNguoiDan { get; set; }
            //    public string IdHuyen { get; set; }
            //    public string IdXa { get; set; }
            //    public string IdAp { get; set; }
            //    public string NoiDung { get; set; }
            //    public string DiaChi { get; set; }
            //    public string TieuDe { get; set; }
            //    public string ToaDo { get; set; }
            //    public string MaMay { get; set; }
            //    public string Sdt { get; set; }
            //    public string TenNguoiPhanAnh { get; set; }
            //    public string IdNguoiDung { get; set; }

            //    public class TapTin
            //    {
            //        public string DuLieu { get; set; }
            //        public int DungLuong { get; set; }
            //        public string LoaiTapTin { get; set; }
            //        public string Ten { get; set; }
            //    }
            //}
            //public class DocTapTin : CommonInput.ChungThuc
            //{
            //    public string Ten { get; set; }
            //}

            public class DocThongTin : CommonInput.ChungThuc
            {
                public string Id { get; set; }
            }
            public class DocThongTinKT
            {
                public string Id { get; set; }
            }

            public class ThongKe : CommonInput.ChungThuc
            {
            }
            //public class DocThongTinPhanHoi : CommonInput.ChungThuc
            //{
            //    public string Id { get; set; }
            //}
            public class XoaDanhSach : CommonInput.ChungThuc
            {
                public List<string> Ids { get; set; }
            }

            public class DocDanhSachTheoTokenNguoiDung : DocDanhSach
            {
            }
        }

        public class Output
        {
            public class ThongTin
            {
                public string Id { get; set; }
                public string TieuDe { get; set; }
                public string NoiDung { get; set; }
                public string Sdt { get; set; }
                public string TenNguoiPhanAnh { get; set; }
                public LoaiPhanAnh LoaiPhanAnhNguoiDan { get; set; }
                public string DiaChi { get; set; }
                public string ThoiGian { get; set; }
                public string ToaDo { get; set; }
                public string IdAp { get; set; }
                public string IdXa { get; set; }
                public string IdHuyen { get; set; }
                public int TrangThai { get; set; }
                public bool XuatBan { get; set; }
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
                public string TenNguoiPheDuyet { get; set; }

                public ThongTin()
                {
                    DanhSachTapTin = new List<TapTin>();
                    LoaiPhanAnhNguoiDan = new LoaiPhanAnh();
                    ThongTinPhanHoi = new PhanHoi();
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
            public class DocThongTin : ThongTin { }
            public class TimKiem : ThongTin { }
            public class ThongKe
            {
                public long TongSo { get; set; }
                public long ChuaXuLy { get; set; }
                public long DangXuLy { get; set; }
                public long DaXuLy { get; set; }
            }
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

            public class DocDanhSach : CommonDocDanhSachOutput
            {
                public List<ThongTin> DanhSach { get; set; }
            }
        }
    }
}