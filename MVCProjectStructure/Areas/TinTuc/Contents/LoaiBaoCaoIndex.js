function DuongDan1() {
    var Ten = $("#Ten").val();
    if (Ten.length > 0) {
        var Duong = bodau(Ten);
        $("#DuongDan").val(Duong);
    }
};
function bodau(str) {
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/!|@@|\$|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\'| |\"|\&|\#|\[|\]|~/g, "-");
    str = str.replace(/-+-/g, "-");
    str = str.replace(/^\-+|\-+$/g, "");
    return str;
}


var HamXuLy = {
    Luu: "Luu",
    LuuDong: "LuuDong",
    Dong: "Dong"
};
$(document).ready(function () {
    var thamSo = DocThamSoTraVeObject(location.search);
    if (thamSo.tukhoa) {
        $("#NoiDungTim").val(thamSo.tukhoa);
    }
    if (thamSo.idPhongBan) {
        $("#DanhSachPhongBan").val(thamSo.idPhongBan);
    }
    XuLyTimKiem(thamSo.trang);
});

function XuLyTimKiem(trang) {
    try {
        if (!trang) {
            trang = 1;
        }
        var thamSo = "?tukhoa=" + $('#NoiDungTim').val();
        thamSo = thamSo + "&idPhongBan=" + $('#DanhSachPhongBan').val();
        thamSo = thamSo + "&trang=" + trang;
        XuLyCapNhatDanhSach('TinTuc/TinTucChoLanhDao/XemDanhSachNhomTin', thamSo);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function XuLyLamLai() {
    $("#NoiDungTim").val("");
    $('#DanhSachPhongBan option:first-child').attr("selected", "selected");
    XuLyTimKiem();
}

function Them() {
    ThemCapNhat('TinTuc/TinTucChoLanhDao/ThongTinThemCapNhatNhomTin', HamXuLy);
}
function ChinhSua(Id) {
    ThemCapNhat('TinTuc/TinTucChoLanhDao/ThongTinThemCapNhatNhomTin', HamXuLy, Id);
}
function XuLyLayThongTinLuu() {
    console.log($('#IdPhongBan').val());
    return JsonInput = {
        Id: $('#Id').val(),
        DanhSachIdPhongBan: $('#IdPhongBan').val(),
        Ten: $('#Ten').val(),
        DuongDan: $('#DuongDan').val(),
        MoTa: $('#MoTa').val(),
        KichHoat: $('#KichHoat').prop('checked'),
        ThuTu: $('#ThuTu').val(),
    };
}
function Luu(DongModal) {
    var JsonInput = XuLyLayThongTinLuu();
    XuLyThongTinThemCapNhat('TinTuc/TinTucChoLanhDao/XuLyLuuNhomTin', JsonInput, HamXuLy, 'TinTuc/TinTucChoLanhDao/XemDanhSachNhomTin', DongModal);
}
function LuuDong() {
    Luu(true);
}
function Dong() {
    DongModalThemCapNhat();
}

function XuLyXoa() {
    Modal.AddConfirmXoa(Message.XacNhanXoa, 'XoaDanhSach()', 'HuyBo()');
}
function XoaDanhSach() {
    var danhSachId = DocDanhSachIdCanXoa();
    var input = { "danhSachId": danhSachId };
    XuLyAPI('TinTuc/TinTucChoLanhDao/XuLyXoaDanhSachNhomTin', input, 'html', 'POST', iXuLyXoa);
}
function iXuLyXoa(data) {
    if (data) {
        if (data.KetQua === 1) {
            $("#ModalConfirm").modal('hide');
            var duLieu = JSON.parse(data.DuLieu);
            Modal.Message(Message.XoaThanhCong + '(' + duLieu.TongSoLuong + ' dòng)');
            var thamSo = DocThamSo();
            XuLyCapNhatDanhSach('TinTuc/TinTucChoLanhDao/XemDanhSachNhomTin', thamSo);
        }
        if (data.KetQua === 0) {
            Modal.Message(Message.XoaThatBai);
        }
    }
}
function HuyBo() {
    DongModalConfirm();
}