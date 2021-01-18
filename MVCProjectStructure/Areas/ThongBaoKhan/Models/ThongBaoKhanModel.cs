using MVCProjectStructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.ThongBaoKhan.Models
{
    public class ThongBaoKhanModel
    {
        public class Input
        {
            public class ThongTin:ChungThuc
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
            public class ThongTin2 : ChungThuc //Độ ưu tiên và trạng thái kiểu int
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
        }
        public class Output
        {
            public class ThongTin
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
                public string NgayTao { get; set; }
            }
            public class DocDanhSach : CommonDocDanhSachOutput
            {
                public List<ThongTin> DanhSach { get; set; }
            }
        }
    }
}