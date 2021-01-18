$(document).ready(function () {
    //replace đường dẫn khi phân trang, tìm kiếm
    $(window).on('popstate', function (e) {
        var state = e.originalEvent.state;
        if (state !== null) {
            location.replace(location.pathname + location.search);
        }
    });
});
const DuongDan = {
    DangNhap: '/NguoiDung/TaiKhoan/DangNhap',
    BangDieuKhien: '/Home/Index',
    ImageDefault01: '/Content/Data/he-thong/images_web/no-image01.jpg',
    ImageDefault02: '/Content/Data/he-thong/images_web/no-image02.jpg'
};

/**
 * 
 * @param {any} arr
 * Truyền mảng bất kỳ vào, sẽ loại bỏ những phần tử giống nhau
 */
function PhanTuTrung(arr) {
    let isExist = (arr, x) => arr.includes(x);
    let ans = [];

    arr.forEach(element => {
        if (!isExist(ans, element)) ans.push(element);
    });

    return ans;
}


//định dạng số decimal n là giá trị nhập, l là số chữ số sau dấu thập phân
function tonumberstring(n, l = 0) {
    
    l = (n - parseInt(n)) === 0 ? 0 : l
   // if (parseFloat(n).toFixed(l) == 0) return '';
    var value = n.toLocaleString(
        'de-DE', // leave undefined to use the browser's locale,
        // or use a string like 'en-US' to override it.
        { minimumFractionDigits: l, maximumFractionDigits: l }
    );
    return value;
}
//Dữ liệu đưa vào dạng Json
//Đỗ Dữ liệu cho biểu mẫu in ấn



/**
 * Gọi API xử lý trả về kết quả, dữ liệu trả về là Object:
 * KetQua: 1 (thành công), 0 (thất bại)
 * ThongBao: nôi dung thông báo
 * DuLieu: Object
 * Lưu ý: Dùng khi xuất ra html
 * @param {string} url đường dẫn
 * @param {JSON} JsonInput tham số truyền vào
 * @param {string} dataType 'json'(mặc định), 'html'(chuỗi html)
 * @param {string} type 'POST'(mặc định),'GET'
 * @param {string} callback tên hàm xử lý tiếp theo
 * @returns {void}
 */
function XuLyAPI(url, JsonInput, dataType, type, callback) {
    if (!type) {
        type = "POST";
    }
    if (!dataType) {
        dataType = "json";
    }
    var result = {};
    url = XuLyTaoDuongDan(url);
    $.ajax({
        type: type,
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: dataType,
        data: JSON.stringify(JsonInput),
        success: function(data) {
            result = {
                KetQua: 1,
                ThongBao: Message.ThanhCong,
                DuLieu: data
            };
            if (callback && typeof(callback) === "function") {
                callback(result);
            }
        },
        error: function(xhr, status, error) {
            //+ xhr.responseText
            Loadding.Hide();
            result = {
                KetQua: 0,
                ThongBao: Message.LoiAjax,
                DuLieu: null
            };
            if (callback && typeof(callback) === "function") {
                callback(result);
            }
        }
    });
    return result;
}

/**
 * Gọi API xử lý trả về kết quả, dữ liệu trả về là Object:
 * KetQua: 1 (thành công), 0 (thất bại)
 * ThongBao: nôi dung thông báo
 * DuLieu: Object
 * Lưu ý: Dùng khi xuất dữ liệu thông thường
 * @param {string} url đường dẫn
 * @param {JSON} JsonInput tham số truyền vào
 * @param {JSON} dataParam dữ liệu tham số
 * @param {string} callback tên hàm xử lý tiếp theo
 * @returns {void}
 */
function XuLyAPIOutputData(url, JsonInput, dataParam, callback) {
    url = XuLyTaoDuongDan(url);
    var result = {};
    $.ajax({
        type: "POST",
        url: url,
        dataType: "json",
        data: JsonInput,
        async: false,
        success: function(data) {
            result = {
                KetQua: data.KetQua,
                ThongBao: data.ThongBao,
                DuLieu: data.DuLieu
            };
            if (callback && typeof(callback) === "function") {
                callback(dataParam, result);
            }
        },
        error: function(xhr, status, error) {
            //+ xhr.responseText
            Loadding.Hide();
            result = {
                KetQua: 0,
                ThongBao: Message.LoiAjax,
                DuLieu: null
            };
            if (callback && typeof(callback) === "function") {
                callback(dataParam, result);
            }
        }
    });
    return result;
}

/**
 * Xử lý cập nhật danh sách
 * @param {string} url đường dẫn
 * @param {string} thamSo tham số dạng ?Id=123456
 */
function XuLyCapNhatDanhSach(url, thamSo) {
    if (history.pushState) {
        var newurl = window.location.protocol + "//" + window.location.host + window.location.pathname + thamSo;
        window.history.pushState({ path: newurl }, '', newurl);
    }
    XuLyAPI(url + thamSo, null, 'html', 'GET', XuLyKetQuaDocDanhSachCapNhat);
}

function XuLyKetQuaDocDanhSachCapNhat(data) {
    if (data) {
        if (data.KetQua === 1) {
            $('#DanhSach_CapNhat').fadeOut(100).fadeIn(100).html(data.DuLieu);
        } else {
            Modal.Message(data.ThongBao);
        }
    }
}
function XuLyTaoDuongDan(pathname) {
    return window.location.protocol + "//" + window.location.host + "/" + pathname;
}
/**
 * Tạo mới editer
 * @param {string} id IdNoiDung
 * @param {string} path đường dẫn thư mục hình cho từng chi cục
 * @returns {void}
 */
function createEditor(id) {
    var editor = CKEDITOR.replace( id, {language: 'vi'});
}

/*Xử lý thêm cập nhật---------------------------------------------------------------------*/
/**
 * Xử lý thêm thông tin phần thân cho modal
 * @param {string} u_ThongTinThemCapNhat Đường dẫn xử lý thông tin thêm cập nhật
 * @param {JSON} HamXuLy Tên hàm xử lý (Luu, LuuDong, Dong)
 * @param {string} Id Truyền Id nếu là chỉnh sửa
 * @returns {void}
 */
function ThemCapNhat(u_ThongTinThemCapNhat, HamXuLy, Id) {
    if (!Id) {
        Id = "";
    }
    var JsonInput = { Id };
    XuLyThongTinThemCapNhat(u_ThongTinThemCapNhat, JsonInput, HamXuLy, '', false);
}

/**
 * Xử lý thông tin thêm cập nhật
 * @param {string} u_ThongTinThemCapNhat Đường dẫn xử lý thông tin thêm cập nhật
 * @param {JSON} JsonInput Tham số đầu vào
 * @param {JSON} HamXuLy Tên hàm xử lý (Luu, LuuDong, Dong)
 * @param {string} u_DocDanhSach Đường dẫn đọc danh sách --> return partial
 * @param {boolean} DongModal Đóng modal (True/false)
 * Lưu ý: Tên hàm dạng string có dấu ()
 */
function XuLyThongTinThemCapNhat(u_ThongTinThemCapNhat, JsonInput, HamXuLy, u_DocDanhSach, DongModal) {
    try {
        XuLyDocLaiThongTinPartial(u_ThongTinThemCapNhat, JsonInput, HamXuLy, u_DocDanhSach, DongModal, iXuLyTaoLaiModal);
    } catch (e) {
        Modal.Message(Message.LoiXuLyThongTin);
    }
}

function XuLyDocLaiThongTinPartial(u_ThongTinThemCapNhat, JsonInput, HamXuLy, u_DocDanhSach, DongModal, callback) {
    url = XuLyTaoDuongDan(u_ThongTinThemCapNhat);
    $.ajax({
        type: 'POST',
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: 'html',
        data: JSON.stringify(JsonInput),
        success: function(data) {
            result = {
                KetQua: 1,
                ThongBao: Message.ThanhCong,
                DuLieu: data
            };
            if (callback && typeof(callback) === "function") {
                callback(result, HamXuLy, u_DocDanhSach, DongModal, iXuLyCapNhatDanhSach);
            }
        },
        error: function(xhr, status, error) {
            //+ xhr.responseText
            Loadding.Hide();
            result = {
                KetQua: 0,
                ThongBao: Message.LoiAjax,
                DuLieu: null
            };
            if (callback && typeof(callback) === "function") {
                callback(result, HamXuLy, u_DocDanhSach, DongModal, iXuLyCapNhatDanhSach);
            }
        }
    });
}

function iXuLyTaoLaiModal(data, HamXuLy, u_DocDanhSach, DongModal, callback) {
    if (data !== null) {
        if (data.KetQua === 0) {
            Modal.Message(data.ThongBao);
        }
        $('#ModalBody_ThemCapNhat').html(data.DuLieu);
        if (!(typeof HamXuLy.Luu === 'undefined') && HamXuLy.Luu !== '') {
            $('#btnLuu').attr('onclick', HamXuLy.Luu + '()');
        }
        if (!(typeof HamXuLy.LuuDong === 'undefined') && HamXuLy.LuuDong !== '') {
            $('#btnLuuDong').attr('onclick', HamXuLy.LuuDong + '()');
        }
        if (!(typeof HamXuLy.Dong === 'undefined') && HamXuLy.Dong !== '') {
            $('#btnDong').attr('onclick', HamXuLy.Dong + '()');
        }
        $('#ModalThemCapNhat').modal(); // Không thay đổi
        var ketQua = $('#KetQuaOutput').data('ketqua');
        if (ketQua === 1) {
            callback(1, DongModal, u_DocDanhSach);
        }
        if (ketQua === -3) {
            callback(0, DongModal, u_DocDanhSach, "Không có quyền truy cập!");
        }
        if (ketQua === 0) {
            callback(0, DongModal, u_DocDanhSach);
        }
        if (ketQua === -2) {
            location.href = window.location.protocol + "//" + window.location.host + DuongDan.DangNhap;
        }
    } else {
        callback(0, DongModal, u_DocDanhSach);
    }
}

function iXuLyCapNhatDanhSach(data, DongModal, u_DocDanhSach, ghiChu) {
    if (u_DocDanhSach) {
        if (data === 1) {
            var thamSo = location.search;
            XuLyCapNhatDanhSach(u_DocDanhSach, thamSo);
            if (DongModal === true) {
                DongModalThemCapNhat();
                Alert.Add('ThongBao_Index', Message.LuuThanhCong, MessageType.success);
            } else {
                Alert.Add('ThongBao_Modal', Message.LuuThanhCong, MessageType.success);
            }
        } else {
            Alert.Add('ThongBao_Modal', Message.LuuThatBai + (ghiChu ?  ghiChu : ""), MessageType.warning);
        }
    }
}

/*End xử lý thêm cập nhật-------------------------------------------------------------------*/

function DongModalThemCapNhat() {
    $('#ModalThemCapNhat').modal('hide');
}
function DongModalConfirm() {
    $('#ModalConfirm').modal('hide');
}

/*Xử lý xóa---------------------------------------------------------------------------------*/
/**
 * Xử lý chọn xóa tất cả, chọn check box xóa
 */
function XuLyChonTatCa() {
    so_luong_dang_check = 0;
    $("#chonXoaTatCa").prop('checked', false);
    $("#btnXoa")[0].disabled = true;
    $("#chonXoaTatCa").change(function () {
        if ($(this)[0].checked === true) {
            $(".checkbox_xoa").prop('checked', true);
            if ($(".checkbox_xoa").length > 0)
                $("#btnXoa")[0].disabled = false;
            else
                $("#chonXoaTatCa").prop('checked', false);
        } else {
            $(".checkbox_xoa").prop('checked', false);
            $("#btnXoa")[0].disabled = true;
        }
    });

    $(".checkbox_xoa").change(function () {
        //console.log($(".checkbox_xoa"));
        ds_check_box = $(".checkbox_xoa");
        so_luong_dang_check = 0;

        for (i = 0; i < ds_check_box.length; i++) {
            if (ds_check_box[i].checked === true) {
                so_luong_dang_check++;
            }
        }

        if (so_luong_dang_check === ds_check_box.length) {
            $("#chonXoaTatCa").prop('checked', true);
        } else {
            $("#chonXoaTatCa").prop('checked', false);
        }
        if (so_luong_dang_check > 0)
            $("#btnXoa")[0].disabled = false;
        else
            $("#btnXoa")[0].disabled = true;
    });
}

function DocDanhSachIdCanXoa() {
    var danhSachId = [];
    ds_check_box = $(".checkbox_xoa");
    for (i = 0; i < ds_check_box.length; i++) {
        if (ds_check_box[i].checked === true) {
            danhSachId.push(ds_check_box[i].value);
        }
    }
    return danhSachId;
}
/*End xử lý xóa-----------------------------------------------------------------------------*/

/*Xử lý phân trang--------------------------------------------------------------------------*/

/**
 * Trả về tất cả các tham số trên thanh URL (?id=n&tukhoa=abc&....)
 * @returns {string} Trả về tất cả các tham số trên thanh URL
 */
function DocThamSo() {
    return location.search;
}

/**
 * Xử lý button chuyển trang
 * @param {object} obj Đối tương được chọn
 * @returns {void}
 */
function XuLyChuyenTrang(obj) {
    try {
        var url = $('#DuongDan').data('duongdan');
        var thamSo = $(obj).data('path') + "&trang=" + $(obj).data('sotrang');
        XuLyCapNhatDanhSach(url, thamSo);
        window.event.preventDefault();//Tắt href event
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
/*End xử lý phân trang-----------------------------------------------------------------------*/

/**
 * Xử lý trả về giá trị của tham số
 * @param {string} url: chuỗi tham số có dạng ?thamso1=aa&thamso2=bbb&...
 * @param {bool} decode: mặc định là true sẽ giải mã chuỗi URI
 */

function DocThamSoTraVeObject(url) {
    url = decodeURI(url);
    var queryString = url ? url.split('?')[1] : window.location.search.slice(1);
    var obj = {};
    if (queryString) {
        queryString = queryString.split('#')[0];
        var arr = queryString.split('&');
        for (var i = 0; i < arr.length; i++) {
            var a = arr[i].split('=');
            var paramName = a[0];
            var paramValue = typeof(a[1]) === 'undefined' ? "" : a[1];
            paramName = paramName;
            if (typeof paramValue === 'string') paramValue = paramValue;
            if (paramName.match(/\[(\d+)?\]$/)) {
                var key = paramName.replace(/\[(\d+)?\]/, '');
                if (!obj[key]) obj[key] = [];
                if (paramName.match(/\[\d+\]$/)) {
                    var index = /\[(\d+)\]/.exec(paramName)[1];
                    obj[key][index] = paramValue;
                } else {
                    obj[key].push(paramValue);
                }
            } else {
                if (!obj[paramName]) {
                    obj[paramName] = paramValue;
                } else if (obj[paramName] && typeof obj[paramName] === 'string') {
                    obj[paramName] = [obj[paramName]];
                    obj[paramName].push(paramValue);
                } else {
                    obj[paramName].push(paramValue);
                }
            }
        }
    }
    return obj;
}

/*Xử lý chuyển Date sang dd/mm/yyyy-----------------------------------------------------------------------*/

/**
 * Xử lý chuyển Date sang dd/mm/yyyy
 * @param {any} strDate :chuỗi date
 * @param {any} time : hiển thị thời gian T/F
 */

function ConvertDate(strDate, time = false) {
    try {
        return formatDate(new Date(parseInt(strDate.substr(6))), time ? time : false);
    } catch (e) {
        return "";
    }
}
function formatDate(date, time = false) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var seconds = date.getSeconds();
    var ampm = hours < 12 ? 'sáng' : 'chiều';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ':' + seconds + ' ' + ampm;
    return date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear() + " " + (time ? strTime : "");
}
/*End xử lý chuyển Date sang dd/mm/yyyy-----------------------------------------------------------------------*/

/*Xử lý show modal xem pdf-----------------------------------------------------------------------*/
/**
 * Lưu ý nhớ thêm modal vào layout
 * <div class="modal fade" id="XemFileModal" role="dialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 id="TenFile" class="modal-title">File pdf</h4>
                </div>
                <div id="body-view-pdf" class="modal-body b-center">
                </div>
                <div class="modal-footer">
                    <div id="pdf-phan-trang" class="b-center">
                    </div>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal"><i class="fa fa-close"></i> Đóng</button>
                </div>
            </div>
        </div>
    </div>
    Cách dùng
    <span class="tai-lieu-pdf" data-src-file="/Content/Data/ABC.pdf" data-ten-file="ABC.pdf">
        <strong>Xem file PDF</strong>
    </span>
 * @param {any} fileSrc :Đường dẫn file
 * @param {any} fileName : Tên file
 * @param {any} localTest: Dùng cho trường hợp test xem trên local thì đường dẫn mặc định http://nongnghiep.cscom.vn
 */
function XemPDF(fileSrc, fileName, localTest) {
    $('#body-view-pdf').children().remove();
    var src = fileSrc;
    $('#TenFile').text(fileName);
    var url = document.location.protocol + "//" + document.location.host;
    if (localTest == true) {
        url = "http://nongnghiep.cscom.vn";
    }
    var s2 = '<object width="100%" style="height: calc(100vh - 175px);" data="https://docs.google.com/gview?embedded=true&url=' + url + src + '"></object>';
    $('#body-view-pdf').append(s2);
    $('#XemFileModal').modal('show');
}
/*End Xử lý show modal xem pdf-----------------------------------------------------------------------*/