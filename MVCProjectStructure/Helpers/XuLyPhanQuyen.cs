using Common.Enum;
using MVCProjectStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using static MVCProjectStructure.Areas.NguoiDung.Models.TaiKhoanModel.TaiKhoanOutput;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Helpers
{
    public class XuLyPhanQuyen
    {
        /// <summary>
        /// Kiểm tra và trả về kết quả True|False
        /// </summary>
        /// <param name="maChucNang">Mã chức năng trong bảng <strong>Danh mục chức năng</strong></param>
        /// <param name="maQuyen">Mã quyền gồm: xem, them, sua, xoa, pheduyet (Common.Enum.ChucNang.QuyenHan.Xem|Them|...</param>
        /// <returns>true: nếu được quyền; false: nếu không được quyền</returns>
        public static bool KiemTraQuyen(string maChucNang = "", string maQuyen = "")
        {
            bool kq = true;
            //try
            //{
            //    var userInfo = HttpContext.Current.Session["UserInfo"] as CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan;
            //    if (userInfo == null) return kq;
            //    if (userInfo.TenTaiKhoan == "root") return true;
            //    //kq = userInfo.DanhSachVaiTro.Any(p => p.Ma == "QuanTri");

            //    if (kq == false)
            //    {
            //        foreach (var item in userInfo.DanhSachMenu)
            //        {
            //            if (item.Ma == maChucNang)
            //            {
            //                kq = item.DanhSachMaChucNangXuLy.Any(p => p == maQuyen);
            //                if (kq)
            //                {
            //                    break;
            //                }
                           
            //            }
            //        }
            //    }
            //    return kq; 
            //}
            //catch (Exception){}
            //finally{ GC.Collect(); }
            return kq;
        }
        /// <summary>
        /// Kiểm tra quyền truy cập (Dùng cho trường hợp trả kết quả ra Ajax)
        /// </summary>
        /// <param name="maChucNang">Mã chức năng trong bảng <strong>Danh mục chức năng</strong></param>
        /// <param name="maQuyen">Mã quyền gồm: xem, them, sua, xoa, pheduyet (Common.Enum.ChucNang.QuyenHan.Xem|Them|...</param>
        /// <returns>Trả về dạng Object bao gồm kết quả, thông báo, ghi chú</returns>
        public static CommonOutput KiemTraQuyenTruyCap(string maChucNang = "", string maQuyen = "")
        {
            var model = new CommonOutput();
            if (HttpContext.Current.Session["UserInfo"] == null)
            {
                model.KetQua = -2;
                model.ThongBao = "Vui lòng đăng nhập lại!";
                model.GhiChu = ChucNang.DuongDan.DangNhap;
                return model;
            }
            if (!KiemTraQuyen(maChucNang, maQuyen))
            {
                model.KetQua = -3;
                model.ThongBao = "Không có quyền truy cập!";
                model.GhiChu = ChucNang.DuongDan.KhongCoQuyenTruyCap;
            }
            return model;
        }
        public static List<int> DocDanhSachChucNangPhanQuyen(string chucNang)
        {
            var dsChucNangPhanQuyen = new List<int>();
            try
            {
                //CommonTaiKhoan.TaiKhoanOutput.DangNhapModelOuput nguoiDung = (CommonTaiKhoan.TaiKhoanOutput.DangNhapModelOuput)HttpContext.Current.Session["UserInfo"];
                //if (nguoiDung.DanhSachChucNangPhanQuyen != null)
                //{
                //    foreach (var item in nguoiDung.DanhSachChucNangPhanQuyen)
                //    {
                //        if (item.MaChucNang == chucNang)
                //        {
                //            foreach (var quyen in item.DanhSachQuyen)
                //            {
                //                /// Quyền hạn
                //                ///     0: Thêm
                //                ///     1: Cập nhật
                //                ///     2: Xóa
                //                ///     3: Duyệt
                //                ///     4: Bỏ duyệt
                //                ///     5: Quản lý số liệu
                //                ///     6: Quản lý danh mục
                //                ///     10: Xem
                //                switch (quyen)
                //                {
                //                    case "Xem":
                //                        dsChucNangPhanQuyen.Add(10);
                //                        break;
                //                    case "Them":
                //                        dsChucNangPhanQuyen.Add(0);
                //                        break;
                //                    case "Sua":
                //                        dsChucNangPhanQuyen.Add(1);
                //                        break;
                //                    case "Xoa":
                //                        dsChucNangPhanQuyen.Add(2);
                //                        break;
                //                    case "PheDuyet"://Duyệt (3) và bỏ duyệt (4) 
                //                        dsChucNangPhanQuyen.Add(3);
                //                        dsChucNangPhanQuyen.Add(4);
                //                        break;
                //                    case "QuanLySoLieu":
                //                        dsChucNangPhanQuyen.Add(5);
                //                        break;
                //                    case "QuanLyDanhMuc":
                //                        dsChucNangPhanQuyen.Add(6);
                //                        break;
                //                    default:
                //                        break;
                //                }
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception)
            {

            }
            return dsChucNangPhanQuyen;
        }
    }
}