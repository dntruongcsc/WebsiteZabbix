using Common.Enum;
using MVCProjectStructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Helpers
{
    public class StaticList
    {
        public class ItemOutput
        {
            public dynamic Value { get; set; }
            public string Text { get; set; }
            public string Ma { get; set; }
        }
        public class ItemNenTangOutput : ItemOutput
        {
            public string MaNenTang { get; set; }
        }
        public static List<ItemOutput> NenTangs()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = "Web",Text = "Web" },
                    new ItemOutput{Value = "Mobile",Text = "Mobile"}
                };
            return items;
        }
        public static List<ItemNenTangOutput> ThuocTrangs()
        {
            var items = new List<ItemNenTangOutput> {
                    new ItemNenTangOutput{Value = "TrangChu", Text = "Trang chủ", MaNenTang = "Windows"},
                    new ItemNenTangOutput{Value = "ThongTinThuySan", Text = "Thông tin thủy sản", MaNenTang = "Windows"},
                    new ItemNenTangOutput{Value = "ThongTinTrongTrot", Text = "Thông tin trồng trọt", MaNenTang = "Windows"},
                    new ItemNenTangOutput{Value = "ThongTinThuY", Text = "Thông tin thú y", MaNenTang = "Windows"},
                    new ItemNenTangOutput{Value = "ThongTinKhuyenNong", Text = "Thông tin khuyến nông", MaNenTang = "Windows"}
                };
            return items;
        }
        public static List<ItemOutput> ViTriChucVus()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = "Tren",Text = "Trên", Ma = "/Image/Hinh01.jpg" },
                    new ItemOutput{Value = "Duoi",Text = "Dưới", Ma = "/Image/Hinh02.jpg" },
                    new ItemOutput{Value = "Trai",Text = "Trái", Ma = "/Image/Hinh03.jpg" },
                    new ItemOutput{Value = "Phai",Text = "Phải", Ma = "/Image/Hinh04.jpg" },
                    new ItemOutput{Value = "Giua",Text = "Giữa", Ma = "/Image/Hinh05.jpg" }
                };
            return items;
        }
        public static List<ItemOutput> ViTriQuangCaos()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = "Tren",Text = "Trên", Ma = "/Image/Hinh01.jpg" },
                    new ItemOutput{Value = "Duoi",Text = "Dưới", Ma = "/Image/Hinh02.jpg" },
                    new ItemOutput{Value = "Trai",Text = "Trái", Ma = "/Image/Hinh03.jpg" },
                    new ItemOutput{Value = "Phai",Text = "Phải", Ma = "/Image/Hinh04.jpg" },
                    new ItemOutput{Value = "Giua",Text = "Giữa", Ma = "/Image/Hinh05.jpg" }
                };
            return items;
        }
        public static List<ItemOutput> ViTriPhongBans()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = "Tren",Text = "Trên", Ma = "/Image/Hinh01.jpg" },
                    new ItemOutput{Value = "Duoi",Text = "Dưới", Ma = "/Image/Hinh02.jpg" },
                    new ItemOutput{Value = "Trai",Text = "Trái", Ma = "/Image/Hinh03.jpg" },
                    new ItemOutput{Value = "Phai",Text = "Phải", Ma = "/Image/Hinh04.jpg" },
                    new ItemOutput{Value = "Giua",Text = "Giữa", Ma = "/Image/Hinh05.jpg" }
                };
            return items;
        }
        public static List<ItemOutput> ViTriNguoiDungs()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 0,Text = "Vị trí 1", Ma = "/Image/Hinh01" },
                    new ItemOutput{Value = 1,Text = "Vị trí 2", Ma = "/Image/Hinh01" }
                };
            return items;
        }
        public static List<ItemOutput> ViTriDanhMucs()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 0,Text = "Vị trí 1", Ma = "/Image/Hinh01" },
                    new ItemOutput{Value = 1,Text = "Vị trí 2", Ma = "/Image/Hinh01" },
                    new ItemOutput{Value = 3,Text = "Vị trí 3", Ma = "/Image/Hinh01" },
                    new ItemOutput{Value = 4,Text = "Vị trí 4", Ma = "/Image/Hinh01" },
                    new ItemOutput{Value = 5,Text = "Vị trí 5", Ma = "/Image/Hinh01" },
                    new ItemOutput{Value = 6,Text = "Vị trí 6", Ma = "/Image/Hinh01" },
                    new ItemOutput{Value = 7,Text = "Vị trí 7", Ma = "/Image/Hinh01" },
                    new ItemOutput{Value = 8,Text = "Vị trí 8", Ma = "/Image/Hinh01" },
                };
            return items;
        }
        public static List<ItemOutput> ViTriAlbums()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = "2018",Text = "2018", Ma = "2018" },
                    new ItemOutput{Value = "Video",Text = "Video", Ma = "Video" },
                    new ItemOutput{Value = "CamNangHocTap",Text = "Cẩm nang học tập", Ma = "CamNangHocTap" }
                };
            return items;
        }
        public static List<ItemOutput> LoaiAlbum()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = "HinhAnh",Text = "Hình ảnh", Ma = "HinhAnh" },
                    new ItemOutput{Value = "Video",Text = "Video", Ma = "Video" }
                };
            return items;
        }
        public static List<ItemOutput> ThuocAlbumHinhAnhs()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = "2018",Text = "2018", Ma = "2018" },
                    new ItemOutput{Value = "Video",Text = "Video", Ma = "Video" },
                    new ItemOutput{Value = "CamNangHocTap",Text = "Cẩm nang học tập", Ma = "CamNangHocTap" }
                };
            return items;
        }
        public static List<ItemOutput> ThuocAlbumVideos()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = "2018",Text = "2018", Ma = "2018" },
                    new ItemOutput{Value = "Video",Text = "Video", Ma = "Video" },
                    new ItemOutput{Value = "CamNangHocTap",Text = "Cẩm nang học tập", Ma = "CamNangHocTap" }
                };
            return items;
        }

        #region GĐ 1
        public static List<ItemOutput> LoaiBaoCaos()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 0,Text = "Báo cáo tuần", Ma = "Tuan" },
                    new ItemOutput{Value = 1,Text = "Báo cáo tháng", Ma = "Thang" },
                    new ItemOutput{Value = 2,Text = "Báo cáo quý", Ma = "Quy" },
                    new ItemOutput{Value = 3,Text = "Báo cáo 6 tháng", Ma = "SauThang" },
                    new ItemOutput{Value = 4,Text = "Báo cáo năm", Ma = "Nam" }
                };
            return items;
        }
        public static List<ItemOutput> SauThangs()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 1,Text = "Báo cáo 6 tháng đầu năm"},
                    new ItemOutput{Value = 2,Text = "Báo cáo sáu tháng cuối năm"}
                };
            return items;
        }
        public static List<ItemOutput> LoaiThongKes()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = "Tuan",Text = "Theo tuần" },
                    new ItemOutput{Value = "Thang",Text = "Theo tháng"},
                    new ItemOutput{Value = "Quy",Text = "Theo quý"},
                    new ItemOutput{Value = "Nam",Text = "Theo năm"}
                };
            return items;
        }
        public static List<ItemOutput> Quys()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 1,Text = "Quý 01" },
                    new ItemOutput{Value = 2,Text = "Quý 02"},
                    new ItemOutput{Value = 3,Text = "Quý 03"},
                    new ItemOutput{Value = 4,Text = "Quý 04"}
                };
            return items;
        }
        public static List<ItemOutput> Thangs()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 1,Text = "Tháng 01" },
                    new ItemOutput{Value = 2,Text = "Tháng 02"},
                    new ItemOutput{Value = 3,Text = "Tháng 03"},
                    new ItemOutput{Value = 4,Text = "Tháng 04"},
                    new ItemOutput{Value = 5,Text = "Tháng 05"},
                    new ItemOutput{Value = 6,Text = "Tháng 06"},
                    new ItemOutput{Value = 7,Text = "Tháng 07"},
                    new ItemOutput{Value = 8,Text = "Tháng 08"},
                    new ItemOutput{Value = 9,Text = "Tháng 09"},
                    new ItemOutput{Value = 10,Text = "Tháng 10"},
                    new ItemOutput{Value = 11,Text = "Tháng 11"},
                    new ItemOutput{Value = 12,Text = "Tháng 12"}
                };
            return items;
        }
        public static List<ItemOutput> Tuans()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 1,Text = "Tuần 01" },
                    new ItemOutput{Value = 2,Text = "Tuần 02"},
                    new ItemOutput{Value = 3,Text = "Tuần 03"},
                    new ItemOutput{Value = 4,Text = "Tuần 04"},
                    new ItemOutput{Value = 5,Text = "Tuần 05"},
                    new ItemOutput{Value = 6,Text = "Tuần 06"},
                    new ItemOutput{Value = 7,Text = "Tuần 07"},
                    new ItemOutput{Value = 8,Text = "Tuần 08"},
                    new ItemOutput{Value = 9,Text = "Tuần 09"},
                    new ItemOutput{Value = 10,Text = "Tuần 10"},

                    new ItemOutput{Value = 11,Text = "Tuần 11" },
                    new ItemOutput{Value = 12,Text = "Tuần 12"},
                    new ItemOutput{Value = 13,Text = "Tuần 13"},
                    new ItemOutput{Value = 14,Text = "Tuần 14"},
                    new ItemOutput{Value = 15,Text = "Tuần 15"},
                    new ItemOutput{Value = 16,Text = "Tuần 16"},
                    new ItemOutput{Value = 17,Text = "Tuần 17"},
                    new ItemOutput{Value = 18,Text = "Tuần 18"},
                    new ItemOutput{Value = 19,Text = "Tuần 19"},
                    new ItemOutput{Value = 20,Text = "Tuần 20"},

                    new ItemOutput{Value = 21,Text = "Tuần 21" },
                    new ItemOutput{Value = 22,Text = "Tuần 22"},
                    new ItemOutput{Value = 23,Text = "Tuần 23"},
                    new ItemOutput{Value = 24,Text = "Tuần 24"},
                    new ItemOutput{Value = 25,Text = "Tuần 25"},
                    new ItemOutput{Value = 26,Text = "Tuần 26"},
                    new ItemOutput{Value = 27,Text = "Tuần 27"},
                    new ItemOutput{Value = 28,Text = "Tuần 28"},
                    new ItemOutput{Value = 29,Text = "Tuần 29"},
                    new ItemOutput{Value = 30,Text = "Tuần 30"},

                    new ItemOutput{Value = 31,Text = "Tuần 31" },
                    new ItemOutput{Value = 32,Text = "Tuần 32"},
                    new ItemOutput{Value = 33,Text = "Tuần 33"},
                    new ItemOutput{Value = 34,Text = "Tuần 34"},
                    new ItemOutput{Value = 35,Text = "Tuần 35"},
                    new ItemOutput{Value = 36,Text = "Tuần 36"},
                    new ItemOutput{Value = 37,Text = "Tuần 37"},
                    new ItemOutput{Value = 38,Text = "Tuần 38"},
                    new ItemOutput{Value = 39,Text = "Tuần 39"},
                    new ItemOutput{Value = 40,Text = "Tuần 40"},

                    new ItemOutput{Value = 41,Text = "Tuần 41" },
                    new ItemOutput{Value = 42,Text = "Tuần 42"},
                    new ItemOutput{Value = 43,Text = "Tuần 43"},
                    new ItemOutput{Value = 44,Text = "Tuần 44"},
                    new ItemOutput{Value = 45,Text = "Tuần 45"},
                    new ItemOutput{Value = 46,Text = "Tuần 46"},
                    new ItemOutput{Value = 47,Text = "Tuần 47"},
                    new ItemOutput{Value = 48,Text = "Tuần 48"},
                    new ItemOutput{Value = 49,Text = "Tuần 49"},
                    new ItemOutput{Value = 50,Text = "Tuần 50"},

                    new ItemOutput{Value = 51,Text = "Tuần 51"},
                    new ItemOutput{Value = 52,Text = "Tuần 52"}
                };
            return items;
        }
        public static List<CommonNamThangTuan.NamOutput> Nams()
        {
            try
            {
                var input = new CommonInput.DocDanhSach();
                var output = XuLyAPI.ApiJsonPost(APIUrl.ThongTinNam.DocDanhSach, input) as CommonOutput;
                if (output.KetQua != 1) throw new Exception(output.ThongBao);
                var danhSachNam = JsonConvert.DeserializeObject<List<CommonNamThangTuan.ThongTinNamOutput>>(output.DuLieu.ToString());
                if (danhSachNam != null)
                {
                    var kq = new List<CommonNamThangTuan.NamOutput>();
                    foreach (var item in danhSachNam)
                    {
                        var i = new CommonNamThangTuan.NamOutput();
                        i.Value = item.Nam;
                        i.Text = item.ChuoiNam;
                        i.NamHienTai = item.NamHienTai;
                        kq.Add(i);
                    }
                    kq = kq.OrderByDescending(e => e.Value).ToList();
                    return kq;
                }
            }
            catch (Exception) { }
            return null;
        }
        public static List<ItemOutput> ChiTieus()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 1,Text = "Tiến độ xuống giống" },
                    new ItemOutput{Value = 2,Text = "Tình hình sản xuất rau màu"},
                    new ItemOutput{Value = 3,Text = "Tình hình dịch hại trên lúa"},
                    new ItemOutput{Value = 4,Text = "Tình hình dịch hại trên rau màu"},
                    new ItemOutput{Value = 5,Text = "Tình hình dịch hại trên cây mía"},
                    new ItemOutput{Value = 6,Text = "Tình hình dịch hại trên cây lăm nghiệp"}
                };
            return items;
        }
        /// <summary>
        /// Hiển thị combobox bên trang quản lý mặt hàng
        /// </summary>
        /// <returns></returns>
        public static List<ItemOutput> NhomChucNangSanPhams()
        {
            var items = new List<ItemOutput>
            {
                new ItemOutput {Value = 1,Text="Giá cả thị trường" },
                new ItemOutput {Value = 2,Text="Sản xuất và trồng trọt" },
                new ItemOutput {Value = 3,Text = "Chăn nuôi và thú y" },
                new ItemOutput {Value = 4,Text = "Nuôi tôm" }
            };
            return items;
        }
        public static List<ItemOutput> MaChucNang()
        {
            var items = new List<ItemOutput>
            {
                new ItemOutput {Value="GiaCaThiTruong",Text="Giá cả thị trường" },
                new ItemOutput {Value="SanXuatTrongTrot",Text="Sản xuất trồng trọt" },
                new ItemOutput {Value="ChanNuoiThuY",Text="Chăn nuôi và thú y" },
                new ItemOutput {Value="DanhMucCacLoaiTom",Text="Danh mục các loại tôm" },
                new ItemOutput {Value="GiaGiongNongNghiep",Text="Giá giống nông nghiệp" }
            };
            return items;
        }
        public static List<ItemOutput> NguonGiongs()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 0,Text = "Trong tỉnh" },
                    new ItemOutput{Value = 1,Text = "Ngoài tỉnh"}
                };
            return items;
        }

        public static List<ItemOutput> TrangThais()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 0,Text = "Thả giống" },
                    new ItemOutput{Value = 1,Text = "Đang thu hoạch" },
                    new ItemOutput{Value = 2,Text = "Đã thu hoạch"}
                };
            return items;
        }
        public static List<ItemOutput> TrangThaiDichBenhs()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 0,Text = "Chưa khắc phục" },
                    new ItemOutput{Value = 1,Text = "Đang khắc phục" },
                    new ItemOutput{Value = 2,Text = "Đã khắc phục"}
                };
            return items;
        }
        public static List<ItemOutput> KichHoats()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 1, Text = "Kích hoạt" },
                    new ItemOutput{Value = 0, Text = "Không kích hoạt" }
            };
            return items;
        }
        public static List<ItemOutput> LoaiChucNangs()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 0, Text = "Web", Ma = "Web" },
                    new ItemOutput{Value = 1, Text = "Mobile", Ma = "Mobile" }
            };
            return items;
        }
        public static List<ItemOutput> NhomMenus()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 1, Text = "Quản trị", Ma = "QuanTri" },
                    new ItemOutput{Value = 2, Text = "Khai thác", Ma = "KhaiThac" },
                    new ItemOutput{Value = 3, Text = "Mobile", Ma = "Mobile" },
                    new ItemOutput{Value = 4, Text = "Quản trị tàu cá", Ma = "QuanTriTauCa" }
            };
            return items;
        }
        public static List<ItemOutput> ViTriMenus()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 2, Text = "Trái", Ma = "Mobile" },
                    new ItemOutput{Value = 3, Text = "Phải", Ma = "Mobile" },
                    new ItemOutput{Value = 1, Text = "Trên", Ma = "QuanTri" },
                    new ItemOutput{Value = 4, Text = "Dưới", Ma = "Web" },
                    new ItemOutput{Value = 5, Text = "Giữa", Ma = "Mobile" }
            };
            return items;
        }
        public static List<ItemOutput> TrangThaiKichHoats()
        {
            var items = new List<ItemOutput> {
                    new ItemOutput{Value = 1, Text = "Kích hoạt" },
                    new ItemOutput{Value = 0, Text = "Chưa kích hoạt"}
            };
            return items;
        }
        #endregion

    }
}