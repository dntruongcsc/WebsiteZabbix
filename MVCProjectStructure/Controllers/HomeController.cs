using Common.Enum;
using MVCProjectStructure.Helpers;
using MVCProjectStructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Common.Enum.ConstantValues;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Controllers
{
    //[RoutePrefix("trang-chu")]
    public class HomeController : Controller
    {
        // GET: Home
        //[Route("xem")]
        public ActionResult Index()
        {
            if (Session["UserInfo"] == null) return Redirect(ChucNang.DuongDan.DangNhap);
            ViewBag.DocSoLuongThietBiDiDong = DocSoLuongThietBiDiDong();
            ViewBag.DocDanhSachThongBaoKhan = DocDanhSachThongBaoKhan();
            ViewBag.DocDanhSachBaiViet = DocDanhSachBaiViet();
            int soLuongChiDao = 0;
            ViewBag.DocDanhSachChiDaoDieuHanh = DocDanhSachChiDaoDieuHanh(out soLuongChiDao);
            ViewBag.SoLuongChiDao = soLuongChiDao;
            var danhSachPhanAnh = DocDanhSachPhanAnhNhanh();
            ViewBag.SoLuongPhanAnh = danhSachPhanAnh != null ? danhSachPhanAnh.Count : 0;
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult SesstionTimeout()
        {
            
            return View();
        }
        #region Các xử lý
        private dynamic DocDanhSachThongBaoKhan()
        {
            try
            {
                var currenPage = 1;
                int soDongTrenTrang = PageNumber.Default;
                int viTriBatDau = (currenPage - 1) * soDongTrenTrang;
                int tongSoDong = 0;
                var input = new CommonInput.TimKiem
                {
                    TuKhoa = "",
                    ViTriBatDau = viTriBatDau,
                    ViTriKetThuc = viTriBatDau + soDongTrenTrang
                };
                var output = XuLyAPI.ApiJsonPost(APIUrl.ThongBaoKhan.DocDanhSachPhanTrang, input) as CommonOutput;
                if (output == null) throw new Exception(ConstantValues.Message.LoiServer);
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var duLieuOutput = JsonConvert.DeserializeObject<CommonThongBaoKhan.Output.DocDanhSach>(output.DuLieu.ToString());
                var kq = new CommonThongBaoKhan.Output.DocDanhSach();
                kq.TrangHienTai = currenPage;
                tongSoDong = duLieuOutput.TongSoDong;
                kq.TongSoTrang = (tongSoDong % soDongTrenTrang > 0) ? tongSoDong / soDongTrenTrang + 1 : tongSoDong / soDongTrenTrang;
                kq.TongSoDong = tongSoDong;
                kq.DanhSach = duLieuOutput.DanhSach;
                return kq;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private CommonBaiViet.Output.DocDanhSach DocDanhSachBaiViet()
        {
            try
            {
                var userInfo = Session["UserInfo"] as CommonNguoiDung.NguoiDungOutput.DangNhapTaiKhoan;
                var currenPage = 1;
                int soDongTrenTrang = PageNumber.Page10;
                int viTriBatDau = (currenPage - 1) * soDongTrenTrang;
                var input = new CommonBaiViet.Input.TimKiemBaiViet
                {
                    Id = "",
                    TuKhoa = "",
                    ViTriBatDau = viTriBatDau,
                    ViTriKetThuc = viTriBatDau + soDongTrenTrang,
                    TrangHienTai = currenPage
                };
                var output = XuLyAPI.ApiJsonPost(APIUrl.BaiViet.TimKiemPhanTrang2, input) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var duLieuOutput = JsonConvert.DeserializeObject<CommonBaiViet.Output.DocDanhSach>(output.DuLieu.ToString());
                return duLieuOutput;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private CommonThietBiDiDong.Output.SoLuongThietBiDiDong DocSoLuongThietBiDiDong()
        {
            try
            {
                var input = new CommonInput.DocDanhSach();
                var output = XuLyAPI.ApiJsonPost(APIUrl.ThietBiDiDong.DocSoLuongThietBiDiDong, input) as CommonOutput;
                if (output == null) throw new Exception(Message.LoiServer);
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var duLieuOutput = JsonConvert.DeserializeObject<CommonThietBiDiDong.Output.SoLuongThietBiDiDong>(output.DuLieu.ToString());
                return duLieuOutput;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        private ChiDaoDieuHanhModelInput DocDanhSachChiDaoDieuHanh(out int soLuong)
        {
            ChiDaoDieuHanhModelInput model = new ChiDaoDieuHanhModelInput();
            soLuong = 0;
            try
            {
                var page = 1;
                int pageSize = PageNumber.Page20;
                int viTriBatDau = (1 - 1) * pageSize;
                int totalCount = 0;
                int viTriKetThuc = 0;
                viTriKetThuc = viTriBatDau + pageSize;
                var output = new CommonOutput();
                DocDanhSachPhanTrang input = new DocDanhSachPhanTrang { ViTriBatDau = viTriBatDau, ViTriKetThuc = viTriKetThuc };
                output = XuLyAPI.ApiJsonPost(APIUrl.ChiDaoDieuHanh.DocDanhSach, input) as CommonOutput;
                var danhsach = JsonConvert.DeserializeObject<ChiDaoDieuHanhDocDanhSach>(JsonConvert.SerializeObject(output.DuLieu));
                if (danhsach != null)
                {
                    totalCount = danhsach.TongSoLuong;
                    soLuong = danhsach.TongSoLuong;
                    var totalPage = (totalCount % pageSize > 0) ? (totalCount / pageSize + 1) : (totalCount / pageSize);
                    List<ChiDaoDieuHanhDocDanhSach.ThongTinChiDao> DanhSachThongTinChiDao = new List<ChiDaoDieuHanhDocDanhSach.ThongTinChiDao>();
                    List<ChiDaoDieuHanhInput> DanhSach = new List<ChiDaoDieuHanhInput>();
                    if (danhsach.DanhSachThongTinChiDao != null && danhsach.DanhSachThongTinChiDao.Count > 0)
                    {
                        foreach (var chiDao in danhsach.DanhSachThongTinChiDao)
                        {
                            ChiDaoDieuHanhInput themChiDao = new ChiDaoDieuHanhInput
                            {
                                HienThi = chiDao.HienThi,
                                Id = chiDao.Id,
                                MoTa = chiDao.MoTa,
                                NoiBat = chiDao.NoiBat,
                                NoiDung = chiDao.NoiDung,
                                IdDonVi = chiDao.IdDonVi,
                                ThongBaoTBDD = chiDao.ThongBaoTBDD,
                                TieuDe = chiDao.TieuDe,
                                HinhAnh = chiDao.HinhAnh,
                                TapTinDinhKem = chiDao.TapTinDinhKem
                            };
                            DanhSach.Add(themChiDao);
                        }
                    }
                    model.DanhSachChiDaoDieuHanh = DanhSach;
                    model.TotalPage = totalPage;
                    model.CurrentPage = page;
                }
                else
                {
                    model.DanhSachChiDaoDieuHanh = new List<ChiDaoDieuHanhInput>();
                    model.TotalPage = 0;
                    model.CurrentPage = page;
                }
                return model;
            }
            catch (Exception)
            {
                return new ChiDaoDieuHanhModelInput();
            }
        }
        public List<PhanAnhNhanhOutput.DocDanhSach> DocDanhSachPhanAnhNhanh()
        {
            try
            {
                var input = new PhanAnhNhanhInput.DocDanhSachInput();
                var output = XuLyAPI.ApiJsonPost(APIUrl.PhanAnhNhanh.DocDanhSachTheoDonVi, input) as CommonOutput;
                if (output.KetQua != 1) return null;
                return JsonConvert.DeserializeObject<List<PhanAnhNhanhOutput.DocDanhSach>>(JsonConvert.SerializeObject(output.DuLieu));
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}