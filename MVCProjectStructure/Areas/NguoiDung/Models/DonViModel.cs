using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.NguoiDung.Models
{
    public class DonViModel
    {
        #region Đơn vị
        public class DonViInput
        {
            public class DocDanhSach : CommonInput.DocDanhSach
            {
                public List<string> DanhSachID { get; set; }
            }
        }
        public class DonViOutput
        {
            public class DocDanhSach : CommonDocDanhSachOutput
            {
                public List<ThongTinDonVi> DanhSach { get; set; }
            }
            public class CauHinhEmail
            {
                public string SMTPServer { get; set; }
                public int Port { get; set; }
                public int SSL { get; set; }
                public string TaiKhoan { get; set; }
                public string MatKhau { get; set; }
                public string EmailGui { get; set; }
                public string TenHienThi { get; set; }
            }
            public class ThongTinDonVi // : Output
            {
                public string Id { get; set; }
                public string Ma { get; set; }
                public string Ten { get; set; }

                public string DiaChi { get; set; }

                public string DienThoai { get; set; }

                public string Email { get; set; }

                public string Fax { get; set; }

                public string Logo { get; set; }
                public string IdDonVi { get; set; }

                public string MaDonViTrucThuoc { get; set; }

                public CauHinhEmail CauHinhEmail { get; set; }

                public ThongTinDonVi DonViTrucThuoc { get; set; }

                public int Cap { get; set; }
                public List<string> DanhSachIdTinh { get; set; }
                public List<string> DanhSachIdHuyen { get; set; }
                public List<string> DanhSachIdXa { get; set; }
                public List<string> DanhSachIdAp { get; set; }
                public ThongTinDonVi()
                {
                    CauHinhEmail = new CauHinhEmail();
                    DanhSachIdTinh = new List<string>();
                    DanhSachIdHuyen = new List<string>();
                    DanhSachIdXa = new List<string>();
                    DanhSachIdAp = new List<string>();
                }
            }
            public class DocDanhSachDonVi
            {
                public int ViTriBatDau;

                public int ViTriKetThuc;

                public int TongSoLuong;

                public List<ThongTinDonVi> DanhSachDonVi;

                public DocDanhSachDonVi()
                {
                    DanhSachDonVi = new List<ThongTinDonVi>();
                }
            }
            public class DanhSachDonViPhanTrang
            {
                public int TongSoTrang { get; set; }
                public List<ThongTinDonVi> DanhSachDonVi { get; set; }
            }
        }
        #endregion
    }
}