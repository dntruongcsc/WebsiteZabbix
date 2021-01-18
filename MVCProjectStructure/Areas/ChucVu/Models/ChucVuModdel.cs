using MVCProjectStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.ChucVu.Models
{
    public class ChucVuModel
    {
        public class ChucVuInput
        {

            public class ThongTinChucVu : CommonInput.ChungThuc
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
                public string MoTa { get; set; }
                public int ThuTu { get; set; }
                public bool KichHoat { get; set; }
            }
            public class TimKiemChucVu : CommonInput.TimKiem
            {

            }
        }
        public class ChucVuOutput
        {
            public class ThongTinChucVu
            {
                public string Id { get; set; }
                public string Ten { get; set; }
                public string Ma { get; set; }
                public string MoTa { get; set; }
                public int ThuTu { get; set; }
                public bool KichHoat { get; set; }
            }
            public class DocDanhSachChucVu
            {
                public List<ThongTinChucVu> DanhSach { get; set; }
                public int TrangHienTai { get; set; }
                public int TongSoDong { get; set; }
                public int TongSoTrang { get; set; }
            }
        }
    }
}