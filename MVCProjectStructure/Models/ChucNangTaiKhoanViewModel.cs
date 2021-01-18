using Common.Enum;
using MVCProjectStructure.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Models
{
    public class ChucNangViewModel
    {
        #region Đọc danh sách chức năng theo phân hệ - Lồng cấp
        private static void DocDanhSachChucNangConMCap(List<ChucNangMCapOutput> danhsach, List<ChucNangMCapOutput> danhsachMCap)
        {
            foreach (var item in danhsachMCap)
            {
                var dscncon = danhsach.FindAll(p => p.IdChucNangCha == item.Id)
                                      .OrderBy(p => p.ViTri).ToList();
                if (dscncon.Count > 0)
                {
                    item.DanhSachChucNangCon.AddRange(dscncon);
                    DocDanhSachChucNangConMCap(danhsach, dscncon);
                }
            }
        }
        public static List<ChucNangMCapOutput> DocDanhSachChucNangMCap(List<DangNhapOutput.ChucNangNguoiDung> dsChucNang)
        {
            try
            {

                // Đọc dữ liệu từ API về chuyển kiểu
                List<ChucNangMCapOutput> dscn = new List<ChucNangMCapOutput>();
                if (dsChucNang == null)
                {
                    var input = new DocDanhSachInput();
                    var output = XuLyAPI.ApiJsonPost(APIUrl.ChucNang.DocDanhSach, input) as CommonModel.CommonOutput;//29-11-2017
                    if (output != null && output.KetQua == 1)
                    {
                        var chucNangs = JsonConvert.DeserializeObject<List<ChucNangOutput>>(output.DuLieu.ToString());
                        dscn = chucNangs.Select(c => new ChucNangMCapOutput
                        {
                            Id = c.Id,
                            IdChucNangCha = c.IdChucNangCha,
                            Ten = c.Ten,
                            BieuTuong = c.BieuTuong,
                            KichHoat = c.KichHoat,
                            Icon = c.Icon,
                            ViTri = c.ViTri,
                            Menu = c.Menu,
                            MoTa = c.MoTa,
                            Ma = !string.IsNullOrEmpty(c.Ma) ? c.Ma : "",
                            LienKet = c.LienKet,
                            DanhSachThongTinChucNangXuLy = new List<ChucNangXuLyOutput>(),
                            DanhSachChucNangCon = new List<ChucNangMCapOutput>()
                        }).ToList();
                    }
                }
                else
                {
                    dscn = dsChucNang.Select(c => new ChucNangMCapOutput
                    {
                        Id = c.Id,
                        IdChucNangCha = c.IdCha,
                        Ten = c.Ten,
                        BieuTuong = c.BieuTuong,
                        KichHoat = c.KichHoat,
                        Icon = c.Icon,
                        ViTri = c.ViTri,
                        Menu = c.Menu,
                        MoTa = c.MoTa,
                        Ma = !string.IsNullOrEmpty(c.Ma) ? c.Ma : "",
                        LienKet = c.LienKet,
                        DanhSachThongTinChucNangXuLy = new List<ChucNangXuLyOutput>(),
                        DanhSachChucNangCon = new List<ChucNangMCapOutput>()
                    }).ToList();
                }
                // Tạo danh sách chức năng gốc
                var dscnMCap = dscn.FindAll(p => p.IdChucNangCha.Equals("0")).OrderBy(p => p.ViTri).ToList();
                // Tạo danh sách chức năng con
                DocDanhSachChucNangConMCap(dscn, dscnMCap);
                return dscnMCap;
            }
            catch (Exception ex) { throw ex; }
        }

        private static void DocDanhSachChucNangConNCap(List<ChucNangNCapOutput> danhsach, List<ChucNangNCapOutput> danhsachNCap)
        {
            foreach (var item in danhsachNCap)
            {
                var dscncon = danhsach.FindAll(p => p.IdChucNangCha == item.IdChucNang)
                                      .OrderBy(p => p.ViTri).ToList();
                if (dscncon.Count > 0)
                {
                    item.DanhSachChucNangCon.AddRange(dscncon);
                    DocDanhSachChucNangConNCap(danhsach, dscncon);
                }
            }
        }

        public static List<ChucNangNCapOutput> DocDanhSachChucNangNCap(bool RootNode = false)
        {
            try
            {
                var input = new DocDanhSachInput();
                var output = XuLyAPI.ApiJsonPost(APIUrl.ChucNang.DocDanhSach, input) as CommonModel.CommonOutput;//29-11-2017
                if (output == null) throw new Exception("Lỗi Server");
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var outputDuLieu = JsonConvert.DeserializeObject<List<ChucNangOutput>>(output.DuLieu.ToString());
                // Đọc dữ liệu từ API về chuyển kiểu
                var dscn = outputDuLieu.Select(c => new ChucNangNCapOutput
                {
                    IdChucNang = c.Id,
                    IdChucNangCha = c.IdChucNangCha,
                    Loai = c.Loai,
                    Ten = c.Ten,
                    ViTri = c.ViTri,
                    MoTa = c.MoTa,
                    DanhSachChucNangCon = new List<ChucNangNCapOutput>()
                }).OrderBy(p => p.ViTri).ToList();

                // Tạo danh sách chức năng gốc
                // Sử dụng IdChucNangCha=Id của chức năng "Quản lý Tổng thể nhà trường"

                List<ChucNangNCapOutput> dscnNCap = new List<ChucNangNCapOutput>();
                /*
                if (RootNode)
                {
                    dscnNCap.Add(dscn.Find(p => p.IdChucNang == APIUrl.PhanHe));
                }
                else
                {
                    dscnNCap = dscn.FindAll(p => p.IdChucNangCha == APIUrl.PhanHe);
                }
                */
                dscnNCap = dscn.FindAll(p => p.IdChucNangCha == "0");
                // Tạo danh sách chức năng con
                DocDanhSachChucNangConNCap(dscn, dscnNCap);
                return dscnNCap;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Đọc danh sách chức năng theo phân hệ


        public static List<ChucNangOutput> DocDanhSachChucNangTTNT()
        {
            List<ChucNangOutput> dscn = null;
            try
            {
                string idTTNT = "0";//APIUrl.PhanHe;
                dscn = DocDanhSachChucNangTheoPhanHe(idTTNT);
            }
            catch (Exception ex) { throw ex; }
            return dscn;
        }
        private static void DocDanhSachChucNangConTheoPhanHe(List<ChucNangOutput> danhsach, List<ChucNangOutput> dscnCha, List<ChucNangOutput> dscnKQ)
        {
            foreach (var item in dscnCha)
            {
                var dscncon = danhsach.FindAll(p => p.IdChucNangCha == item.Id)
                                      .ToList();
                if (dscncon.Count > 0)
                {
                    dscnKQ.AddRange(dscncon);
                    DocDanhSachChucNangConTheoPhanHe(danhsach, dscncon, dscnKQ);
                }
            }
        }
        private static List<ChucNangOutput> DocDanhSachChucNangTheoPhanHe(string id)
        {
            try
            {
                var input = new DocDanhSachInput();
                var output = XuLyAPI.ApiJsonPost(APIUrl.ChucNang.DocDanhSach, input) as CommonModel.CommonOutput;
                if (output == null) throw new Exception("Lỗi Server");
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var outputDuLieu = JsonConvert.DeserializeObject<List<ChucNangOutput>>(output.DuLieu.ToString());
                // Đọc dữ liệu từ API về chuyển kiểu
                var dscn = outputDuLieu;

                // Tạo danh sách chức năng gốc
                // Sử dụng IdChucNangCha=Id của chức năng "Quản lý Tổng thể nhà trường"
                var dscnCha = new List<ChucNangOutput>();
                var dscnKQ = new List<ChucNangOutput>();

                dscnCha = dscn.FindAll(p => p.IdChucNangCha == id);
                dscnKQ.AddRange(dscnCha);
                DocDanhSachChucNangConTheoPhanHe(dscn, dscnCha, dscnKQ);
                return dscnKQ;
            }
            catch (Exception ex) { throw ex; }
        }


        #endregion


    }
    public class XuLyTaiKhoanModel //Thay đổi từ TaiKhoanModel sang XuLyTaiKhoanModel do bị trùng
    {
        public static bool KiemTraQuyenQuanTri()
        {
            var userInfo = HttpContext.Current.Session["UserInfo"] as CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan;// DangNhapOutput;
            bool kq = true;// userInfo.DanhSachVaiTro.Any(p => p.Ma == "QuanTri");
            return kq;
        }
        public static bool KiemTraQuyenTruyCap(string ActionName, string ControllerName)
        {
            var userInfo = HttpContext.Current.Session["UserInfo"] as CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan;// DangNhapOutput;
            bool kq = true;//userInfo.DanhSachVaiTro.Any(p => p.Ma == "QuanTri");
            if (kq == false)
            {
                string lienKet = string.Format("{0}/{1}", ControllerName, ActionName);
                kq = true;//userInfo.DanhSachChucNang.Any(p => p.LienKet == lienKet);
            }
            return kq;
        }

        //public static void DocDanhSachChucNang(DangNhapOutput userLogin)
        //{
        //    var taiKhoan = DocThongTinTaiKhoan(userLogin.Id);
        //    var dsID = taiKhoan.DanhSachLienKet.Select(p => p.IdChucNang).ToList();
        //    var dsLK = taiKhoan.DanhSachLienKet.Select(p => p.TenLienKet).ToList();
        //    //userLogin.DanhSachChucNangId.AddRange(dsID);
        //    //userLogin.DanhSachChucNangLk.AddRange(dsLK);
        //}
        //public static List<string> DocDanhSachChucNangId(string id)
        //{
        //    List<String> dsID = null;
        //    var taiKhoan = DocThongTinTaiKhoan(id);
        //    dsID = taiKhoan.DanhSachChucNang.Select(p => p.IdChucNang).ToList();
        //    return dsID; 
        //}
        private static TaiKhoanOutput DocThongTinTaiKhoan(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) throw new Exception("Lỗi truy cập dữ liệu");
                var input = new DocThongTinInput { Id = id };
                var output = XuLyAPI.ApiJsonPost(APIUrl.TaiKhoan.DocThongTin, input) as CommonModel.CommonOutput;
                if (output == null) throw new Exception("Lỗi Server");
                if (output.KetQua != 1) throw new Exception(output.ThongBao);

                var taiKhoan = JsonConvert.DeserializeObject<TaiKhoanOutput>(output.DuLieu.ToString());

                return taiKhoan;
            }
            catch (Exception ex) { throw ex; }
        }

        #region Đủ thêm 01/08/2018
        #region Enum
        public enum DonVi
        {
            Huyen,
            Xa,
            Ap
        }
        public enum MaNhomNguoiDung
        {
            QuanTri,
            LanhDao,
            LanhDaoChiCuc,
            CanBoChiCuc,
            CanBoHuyen,
            CanBoXa,
            UBNDTinh,
            ChuyenVienSo
        }
        /// <summary>
        /// ThaoTac
        ///     0: Thêm
        ///     1: Cập nhật
        ///     2: Xóa
        ///     3: Duyệt
        ///     4: Bỏ duyệt
        ///     5: Quản lý số liệu
        ///     6: Quản lý danh mục
        /// </summary>
        public enum ThaoTac
        {
            Them,
            CapNhat,
            Xoa,
            Duyet,
            BoDuyet,
            QuanLySoLieu,
            QuanLyDanhMuc
        }
        #endregion

        #region Xử lý
        /// <summary>
        /// Dùng khi lưu có huyện xã
        /// </summary>
        /// <param name="IdHuyen">Id Huyện</param>
        /// <param name="IdXa">Id Xã</param>
        /// <returns>true/false</returns>
        public static bool KiemTraQuyenLuuTheoHuyenXa(string IdHuyen, string IdXa)
        {
            var userInfo = HttpContext.Current.Session["UserInfo"] as DangNhapOutput;
            var root = userInfo.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.QuanTri.ToString());
            if (root) return true;
            var idHuyen = userInfo.NguoiDung.IdHuyen;
            var idXa = userInfo.NguoiDung.IdXa;
            if (userInfo.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.CanBoXa.ToString()) && IdXa == idXa
                || userInfo.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.CanBoHuyen.ToString()) && IdHuyen == idHuyen
                || userInfo.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.CanBoChiCuc.ToString())
                || userInfo.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.LanhDaoChiCuc.ToString())
                || userInfo.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.ChuyenVienSo.ToString()))
            {
                return true;
            }
            return false;
        }
        public static bool KiemTraQuyenLuuDuyetCapTinh(string ActionName, string ControllerName)
        {
            var userInfo = HttpContext.Current.Session["UserInfo"] as DangNhapOutput;
            var kq = userInfo.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.QuanTri.ToString());
            if (kq) return true;
            if (KiemTraLienKet(ActionName, ControllerName))
            {
                if (userInfo.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.LanhDaoChiCuc.ToString() || p.Ma == MaNhomNguoiDung.ChuyenVienSo.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool KiemTraLienKet(string ActionName, string ControllerName)
        {
            var userInfo = HttpContext.Current.Session["UserInfo"] as DangNhapOutput;
            var kq = userInfo.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.QuanTri.ToString());
            if (kq) return true;

            string lienKet = string.Format("{0}/{1}", ControllerName, ActionName);
            kq = userInfo.DanhSachChucNang.Any(p => p.LienKet == lienKet);

            return kq;
        }

        /// <summary>
        /// Kiểm tra quyền truy cập khi dùng Ajax
        /// </summary>
        /// <param name="ActionName">Tên hành động</param>
        /// <param name="ControllerName">Tên Controller</param>
        /// <param name="duLieuOutputModel">DuLieuOutputModel</param>
        /// <returns>true/false</returns>
        public static bool KiemTraQuyenTruyCapAjax(string ActionName, string ControllerName, out DuLieuOutputModel duLieuOutputModel, string IdHuyen = "", string IdXa = "", string IdAp = "")
        {
            duLieuOutputModel = new DuLieuOutputModel();
            var userInfo = HttpContext.Current.Session["UserInfo"] as DangNhapOutput;
            bool kq = userInfo.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.QuanTri.ToString());
            if (kq == false)
            {
                string lienKet = string.Format("{0}/{1}", ControllerName, ActionName);
                kq = userInfo.DanhSachChucNang.Any(p => p.LienKet == lienKet);
                //Cán bộ chi cục
                if (userInfo.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.CanBoChiCuc.ToString())) return true;
                if (!string.IsNullOrEmpty(IdHuyen))
                    kq = userInfo.NguoiDung.DonVi.DanhSachIdHuyen.Any(p => p == IdHuyen);
                if (!string.IsNullOrEmpty(IdXa))
                    kq = userInfo.NguoiDung.DonVi.DanhSachIdXa.Any(p => p == IdXa);
                if (!string.IsNullOrEmpty(IdAp))
                    kq = userInfo.NguoiDung.DonVi.DanhSachIdAp.Any(p => p == IdAp);
                if (kq == false)
                {
                    duLieuOutputModel.KetQua = -3;
                    duLieuOutputModel.GhiChu = "";
                }
            }
            return kq;
        }

        /// <summary>
        /// Dùng để lọc đơn vị(Huyện,xã) được hiển thị lên dropdown
        /// </summary>
        /// <param name="danhSachTruyenVao">Danh sách đơn vị</param>
        /// <param name="donVi">Đơn vị (huyện, xã)</param>
        /// <returns>List<DanhMucDropDown></returns>
        public static List<DanhMucDropDown> XuLyDanhSachCacCap(List<DanhMucDropDown> danhSachTruyenVao, DonVi donVi)
        {
            List<DanhMucDropDown> danhSach = new List<DanhMucDropDown>();
            try
            {
                DangNhapOutput nguoiDung = (DangNhapOutput)HttpContext.Current.Session["UserInfo"];
                bool kq = nguoiDung.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.QuanTri.ToString());
                if (kq) return danhSachTruyenVao;
                var danhSachDuocHienThi = new List<string>();
                if (donVi == DonVi.Huyen)
                {
                    if (nguoiDung.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.CanBoHuyen.ToString() || p.Ma == MaNhomNguoiDung.CanBoXa.ToString()))
                    {
                        danhSachDuocHienThi.Add(nguoiDung.NguoiDung.IdHuyen);
                    }
                    else return danhSachTruyenVao;
                }
                else if (donVi == DonVi.Xa)
                {
                    if (nguoiDung.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.CanBoXa.ToString()))
                    {
                        danhSachDuocHienThi.Add(nguoiDung.NguoiDung.IdXa);
                    }
                    else
                    {
                        List<string> danhSachIdXa = new List<string>();
                        danhSachIdXa = nguoiDung.NguoiDung.DonVi.DanhSachIdXa;
                        danhSachDuocHienThi = danhSachIdXa;
                    }
                }
                else if (donVi == DonVi.Ap)
                {
                    List<string> danhSachIdAp = new List<string>();
                    danhSachIdAp = nguoiDung.NguoiDung.DonVi.DanhSachIdAp;
                    danhSachDuocHienThi = danhSachIdAp;
                }
                if (danhSachTruyenVao != null)
                {
                    foreach (var a in danhSachTruyenVao)
                    {
                        foreach (var b in danhSachDuocHienThi)
                        {
                            if (a.Id == b)
                            {
                                danhSach.Add(a);
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
            return danhSach;
        }

        /// <summary>
        /// Xử lý phân cấp cho hiển thị giao diện 
        /// </summary>
        /// <returns>(1: Duyệt; 2:Thao tác lưu, lưu và báo cáo)</returns>
        public static List<int> XuLyPhanCap()
        {
            List<int> kq = new List<int>();
            try
            {
                DangNhapOutput nguoiDung = (DangNhapOutput)HttpContext.Current.Session["UserInfo"];
                bool qt = nguoiDung.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.QuanTri.ToString());

                if (qt)
                {
                    //default
                    kq.Add(1); kq.Add(2);
                }
                if (nguoiDung.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.LanhDaoChiCuc.ToString()))
                {
                    kq.Add(1);
                }
                if (nguoiDung.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.CanBoChiCuc.ToString()
                                                            || p.Ma == MaNhomNguoiDung.CanBoHuyen.ToString()
                                                            || p.Ma == MaNhomNguoiDung.CanBoXa.ToString()))
                {
                    kq.Add(2);
                }
            }
            catch (Exception) { }
            return kq;
        }
        public static List<ThaoTac> XuLyDocDanhSachThaoTac()
        {
            List<ThaoTac> kq = new List<ThaoTac>();
            try
            {
                DangNhapOutput nguoiDung = (DangNhapOutput)HttpContext.Current.Session["UserInfo"];
                bool qt = nguoiDung.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.QuanTri.ToString());

                if (qt)
                {
                    return new List<ThaoTac>() {
                    ThaoTac.Them,
                    ThaoTac.CapNhat,
                    ThaoTac.Xoa,
                    ThaoTac.Duyet,
                    ThaoTac.BoDuyet,
                    ThaoTac.QuanLySoLieu,
                    ThaoTac.QuanLyDanhMuc
                    };
                }
                var nhomnguoiDung = nguoiDung.DanhSachVaiTroNguoiDung.FirstOrDefault();
                if (nhomnguoiDung.Ma == MaNhomNguoiDung.LanhDao.ToString())
                {
                    return kq;//Lãnh đạo chỉ vào xem thông tin
                }
                if (nhomnguoiDung.Ma == MaNhomNguoiDung.CanBoChiCuc.ToString())
                {
                    return new List<ThaoTac>() {
                    ThaoTac.Them,
                    //ThaoTac.CapNhat,
                    ThaoTac.Xoa,
                    ThaoTac.QuanLySoLieu,
                    ThaoTac.QuanLyDanhMuc
                    };
                }
                if (nhomnguoiDung.Ma == MaNhomNguoiDung.CanBoHuyen.ToString())
                {
                    return new List<ThaoTac>() {
                    ThaoTac.Them,
                    ThaoTac.CapNhat,
                    ThaoTac.Xoa,
                    ThaoTac.QuanLySoLieu
                    };
                }
                if (nhomnguoiDung.Ma == MaNhomNguoiDung.CanBoXa.ToString())
                {
                    return new List<ThaoTac>() {
                    ThaoTac.Them,
                    ThaoTac.CapNhat,
                    ThaoTac.Xoa,
                    ThaoTac.QuanLySoLieu
                    };
                }
                if (nhomnguoiDung.Ma == MaNhomNguoiDung.ChuyenVienSo.ToString())
                {
                    return new List<ThaoTac>() {
                    ThaoTac.Them,
                    ThaoTac.CapNhat,
                    ThaoTac.Xoa,
                    ThaoTac.Duyet,
                    ThaoTac.BoDuyet,
                    ThaoTac.QuanLySoLieu,
                    ThaoTac.QuanLyDanhMuc
                    };
                }
                if (nhomnguoiDung.Ma == MaNhomNguoiDung.LanhDaoChiCuc.ToString())
                {
                    return new List<ThaoTac>() {
                    ThaoTac.Them,
                    ThaoTac.CapNhat,
                    ThaoTac.Xoa,
                    ThaoTac.Duyet,
                    ThaoTac.BoDuyet,
                    ThaoTac.QuanLySoLieu,
                    ThaoTac.QuanLyDanhMuc
                    };
                }

            }
            catch (Exception) { }
            return kq;
        }
        public static bool KiemTraThaoTac(List<ThaoTac> danhSachThaoTac, ThaoTac thaoTac)
        {
            bool kq = false;
            try
            {
                DangNhapOutput nguoiDung = (DangNhapOutput)HttpContext.Current.Session["UserInfo"];
                bool qt = nguoiDung.DanhSachVaiTroNguoiDung.Any(p => p.Ma == MaNhomNguoiDung.QuanTri.ToString());

                if (qt)
                {
                    return true;
                }
                foreach (var item in danhSachThaoTac)
                {
                    if (item == thaoTac)
                    {
                        kq = true;
                        break;
                    }
                }
            }
            catch (Exception) { }
            return kq;
        }
        #endregion
        #endregion
    }
}