using Common.Enum;
using MVCProjectStructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.Admin.Models
{
    public class ChucNangModel
    {
        public class ChucNangInput
        {
            #region Chức năng
            public class ThongTin : CommonInput.ChungThuc
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
                public ThongTin()
                {
                    DanhSachChucNangXuLy = new List<ChucNangXuLy>();
                }
                public class ChucNangXuLy
                {
                    public string IdChucNangXuLy { get; set; }
                    public int KichHoat { get; set; }
                }
            }
            public class DocDanhSach : CommonInput.DocDanhSach
            {

            }
            public class DocThongTinChucNangTheoMa : CommonInput.ChungThuc
            {
                public string Ma { get; set; }
            }
            #endregion
        }
        public class ChucNangOutput
        {
            #region Chức năng
            public class ThongTin
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

            public class ChucNangConOutput : ThongTin
            {
                public double NgayTao { get; set; }
                public string IdNguoiTao { get; set; }
                public double NgayCapNhat { get; set; }
                public string IdNguoiCapNhat { get; set; }
                public List<ChucNangConOutput> DanhSachChucNangCon { get; set; }
            }
            public class ChucNangLongCapOutput : ThongTin
            {
                public List<ChucNangConOutput> DanhSachChucNangCon { get; set; }
            }
            public class ChucNangNCapOutput : NhomChucNangOutput.ChucNang
            {
                public List<ChucNangNCapOutput> DanhSachChucNangCon { get; set; }
            }
            public class ChucNangMCapOutput : ThongTin
            {
                public List<ChucNangMCapOutput> DanhSachChucNangCon { get; set; }
            }

            #endregion
        }
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
                public int ViTri { get; set; }
                public string MoTa { get; set; }
            }
        }
        public class NhomChucNangDanhSachOutput
        {
            public List<NhomChucNangOutput> NhomChucNang { get; set; }
        }

        #endregion
    }
}