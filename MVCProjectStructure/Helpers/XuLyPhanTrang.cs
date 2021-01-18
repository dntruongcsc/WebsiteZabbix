using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectStructure.Helpers
{
    public class XuLyPhanTrang
    {
        /// <summary>
        /// Xử lý và trả về chuỗi HTML trong đó có phân ra thành từng trang và đường dẫn xử lý tải dữ liệu cho từng trang (thêm &trang=n vào thamSo)
        /// </summary>
        /// <param name="tongSoTrang">Tổng số trang</param>
        /// <param name="trangHienTai">Trang hiện tại đang chọn</param>
        /// <param name="duongDan">Đường dẫn tới Action</param>
        /// <param name="thamSo">Tham số (GET) (?id=n&tukhoa=abc...)</param>
        /// <returns>Chuổi HTML đã định dạng phân trang</returns>
        public static string TaoPhanTrang(int tongSoTrang, int trangHienTai, string duongDan, string thamSo)
        {
            string kq = "";
           
            if (tongSoTrang > 1)
            {
                kq += String.Format("<input id='DuongDan' data-duongdan='{0}' hidden />" +
                 "<ul class='pagination justify-content-end'>", duongDan);
                if (trangHienTai == 1)
                {
                    kq += String.Format("<li class='page-item first disabled'><a class='page-link-mac-dinh'>Trang đầu</a></li>" +
                        "<li class='page-item prev disabled'><a class='page-link-mac-dinh'>&lt;</a></li>");
                }
                else
                {
                    kq += String.Format("<li class='page-item first'><a href='?{1}&trang=1' class='page-link-mac-dinh khong-tai-trang'>Trang đầu</a></li>" +
                        "<li class='page-item prev'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang' >&lt;</a></li>", trangHienTai - 1, thamSo);
                }
                if (tongSoTrang > 10)
                {
                    if (0 < trangHienTai && trangHienTai < 11)
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            if (trangHienTai == i + 1)
                            {
                                kq += String.Format("<li class='page-item active'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                            }
                            else
                            {
                                kq += String.Format("<li class='page-item'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                            }
                        }
                        kq += String.Format("<li class='page-item {0}'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>...</a></li>", 11, thamSo);
                    }
                    else if (trangHienTai >= (tongSoTrang - 10) && trangHienTai <= tongSoTrang)
                    {
                        kq += String.Format("<li class='page-item {0}'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>...</a></li>", tongSoTrang - 11, thamSo);
                        for (int i = tongSoTrang - 10; i < tongSoTrang; i++)
                        {
                            if (trangHienTai == i + 1)
                            {

                                kq += String.Format("<li class='page-item active'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                            }
                            else
                            {
                                kq += String.Format("<li class='page-item'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                                //kq += String.Format("<li class='page-item'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>@(i + 1)</a></li>", i + 1, thamSo);
                            }
                        }
                    }
                    else if (trangHienTai >= 11 && trangHienTai < (tongSoTrang - 10))
                    {
                        var start = trangHienTai - 5;
                        var end = trangHienTai + 5;
                        kq += String.Format("<li class='page-item {0}'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>...</a></li>", start, thamSo);
                        for (int i = start; i < end; i++)
                        {
                            if (trangHienTai == i + 1)
                            {
                                kq += String.Format("<li class='page-item active'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                            }
                            else
                            {
                                kq += String.Format("<li class='page-item '><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                            }
                        }
                        kq += String.Format("<li class='page-item {0}'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>...</a></li>", end, end, thamSo);
                    }
                }
                else
                {
                    for (int i = 0; i < tongSoTrang; i++)
                    {
                        if (trangHienTai == i + 1)
                        {
                            kq += String.Format("<li class='page-item active'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                        }
                        else
                        {
                            kq += String.Format("<li class='page-item'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                        }
                    }
                }
                if (trangHienTai == tongSoTrang && tongSoTrang > 1)
                {
                    kq += String.Format("<li class='page-item next disabled'><a class='page-link-mac-dinh'>&gt;</a></li>");
                    if (tongSoTrang > 10)
                    {
                        kq += String.Format("<li class='page-item last disabled'><a class='page-link-mac-dinh'>Trang cuối ({0})</a></li>", tongSoTrang);
                    }
                    else
                    {
                        kq += String.Format("<li class='page-item last disabled'><a class='page-link-mac-dinh'>Trang cuối</a></li>");
                    }
                }
                else
                {
                    kq += String.Format("<li class='page-item next'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>&gt;</a></li>", trangHienTai + 1, thamSo);
                    if (tongSoTrang > 10)
                    {
                        kq += String.Format("<li class='page-item last'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>Trang cuối ({0})</a></li>", tongSoTrang, thamSo);
                    }
                    else
                    {
                        kq += String.Format("<li class='page-item last'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>Trang cuối</a></li>", tongSoTrang, thamSo);
                    }
                }

                kq += "</ul>";
                kq+="<script>$(\".khong-tai-trang\").on(\"click\", function(e) {"+
                    "try {"+
                    "var url = $(\"#DuongDan\").data(\"duongdan\");"+
                    "var thamSo = $(this).attr(\"href\");"+
                    "XuLyCapNhatDanhSach(url, thamSo);"+
                    "e.preventDefault();"+
                    "} catch (e) {"+
                    "Modal.Message(Message.LoiDuLieu);"+
                    "}"+
                    "})</script>";
            }
            else{
                kq = String.Empty;
            }
            //Sử dụng hàm javascript XuLyChuyenTrang ở bên csc/csc.xuly-1.0.2.js
            return kq;
        }

        public static string TaoPhanTrangChoMobile(int tongSoTrang, int trangHienTai, string duongDan, string thamSo)
        {
            string kq = "";

            if (tongSoTrang > 1)
            {
                kq += String.Format("<input id='DuongDan' data-duongdan='{0}' hidden />" +
                 "<ul class='pagination justify-content-end'>", duongDan);
                if (trangHienTai == 1)
                {
                    kq += String.Format("<li class='page-item first disabled'><a class='page-link-mac-dinh'><<</a></li>" +
                        "<li class='page-item prev disabled'><a class='page-link-mac-dinh'>&lt;</a></li>");
                }
                else
                {
                    kq += String.Format("<li class='page-item first'><a href='?{1}&trang=1' class='page-link-mac-dinh khong-tai-trang'><<</a></li>" +
                        "<li class='page-item prev'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang' >&lt;</a></li>", trangHienTai - 1, thamSo);
                }
                if (tongSoTrang > 3)
                {
                    if (0 < trangHienTai && trangHienTai < 4)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (trangHienTai == i + 1)
                            {
                                kq += String.Format("<li class='page-item active'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                            }
                            else
                            {
                                kq += String.Format("<li class='page-item'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                            }
                        }
                        kq += String.Format("<li class='page-item {0}'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>...</a></li>", 4, thamSo);
                    }
                    else if (trangHienTai >= (tongSoTrang - 3) && trangHienTai <= tongSoTrang)
                    {
                        kq += String.Format("<li class='page-item {0}'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>...</a></li>'", tongSoTrang - 4, thamSo);
                        for (int i = tongSoTrang - 3; i < tongSoTrang; i++)
                        {
                            if (trangHienTai == i + 1)
                            {

                                kq += String.Format("<li class='page-item active'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                            }
                            else
                            {
                                kq += String.Format("<li class='page-item'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                                //kq += String.Format("<li class='page-item'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>@(i + 1)</a></li>", i + 1, thamSo);
                            }
                        }
                    }
                    else if (trangHienTai >= 3 && trangHienTai < (tongSoTrang - 3))
                    {
                        var start = trangHienTai - 2;
                        var end = trangHienTai + 2;
                        kq += String.Format("<li class='page-item {0}'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>...</a></li>", start, thamSo);
                        for (int i = start; i < end; i++)
                        {
                            if (trangHienTai == i + 1)
                            {
                                kq += String.Format("<li class='page-item active'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                            }
                            else
                            {
                                kq += String.Format("<li class='page-item '><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                            }
                        }
                        kq += String.Format("<li class='page-item {0}'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>...</a></li>", end, end, thamSo);
                    }
                }
                else
                {
                    for (int i = 0; i < tongSoTrang; i++)
                    {
                        if (trangHienTai == i + 1)
                        {
                            kq += String.Format("<li class='page-item active'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                        }
                        else
                        {
                            kq += String.Format("<li class='page-item'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>{0}</a></li>", i + 1, thamSo);
                        }
                    }
                }
                if (trangHienTai == tongSoTrang && tongSoTrang > 1)
                {
                    kq += String.Format("<li class='page-item next disabled'><a class='page-link-mac-dinh'>&gt;</a></li>");
                    if (tongSoTrang > 3)
                    {
                        kq += String.Format("<li class='page-item last disabled'><a class='page-link-mac-dinh'>>></a></li>", tongSoTrang);
                    }
                    else
                    {
                        kq += String.Format("<li class='page-item last disabled'><a class='page-link-mac-dinh'>>></a></li>");
                    }
                }
                else
                {
                    kq += String.Format("<li class='page-item next'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>&gt;</a></li>", trangHienTai + 1, thamSo);
                    if (tongSoTrang > 3)
                    {
                        kq += String.Format("<li class='page-item last'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>>></a></li>", tongSoTrang, thamSo);
                    }
                    else
                    {
                        kq += String.Format("<li class='page-item last'><a href='?{1}&trang={0}' class='page-link-mac-dinh khong-tai-trang'>>></a></li>", tongSoTrang, thamSo);
                    }
                }

                kq += "</ul>";
                kq += "<script>$(\".khong-tai-trang\").on(\"click\", function(e) {" +
                    "try {" +
                    "var url = $(\"#DuongDan\").data(\"duongdan\");" +
                    "var thamSo = $(this).attr(\"href\");" +
                    "XuLyCapNhatDanhSach(url, thamSo);" +
                    "e.preventDefault();" +
                    "} catch (e) {" +
                    "Modal.Message(Message.LoiDuLieu);" +
                    "}" +
                    "})</script>";
            }
            else
            {
                kq = String.Empty;
            }
            //Sử dụng hàm javascript XuLyChuyenTrang ở bên csc/csc.xuly-1.0.2.js
            return kq;
        }
    }
}