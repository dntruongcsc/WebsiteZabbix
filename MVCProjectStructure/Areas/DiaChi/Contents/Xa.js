var HamXuLy = {
    Luu: "Luu",
    LuuDong: "LuuDong",
    Dong: "Dong"
};
$(document).ready(function () {
    var thamSo = DocThamSoTraVeObject(location.search);
    $("#TuKhoa").val(thamSo.tukhoa);
    $('#danhSachTinhsearch').val(thamSo.IdTinh).change();
    $('#DanhSachHuyen').val(thamSo.IdHuyen);
    XuLyTimKiem(thamSo.trang);
});
function XuLyTimKiem(trang) {
    try {
        if (!trang) {
            trang = 1;
        }
        var thamSo = "?tukhoa=" + $('#TuKhoa').val();
        thamSo = thamSo + "&IdHuyen=" + $('#DanhSachHuyen').val();
        thamSo = thamSo + "&trang=" + trang;
        XuLyCapNhatDanhSach('DiaChi/Xa/XemDanhSach', thamSo);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function Them() {
    ThemCapNhat('DiaChi/Xa/ThongTinThemCapNhat', HamXuLy);
}
function ChinhSua(Id) {
    ThemCapNhat('DiaChi/Xa/ThongTinThemCapNhat', HamXuLy, Id);
}
function XuLyLayThongTinLuu() {
    return JsonInput = {
        Id: $('#IdEdit').val(),
        Ten: $('#txtTenXa').val(),
        Ma: $('#txtMaXa').val(),
        IdHuyen: $('#DanhSachHuyenThem').val(),
        MaHuyen: $('#txtMaHuyen').val(),
    };
}
function Luu(DongModal) {
    var JsonInput = XuLyLayThongTinLuu();
    XuLyThongTinThemCapNhat('DiaChi/Xa/XuLyLuu', JsonInput, HamXuLy, 'DiaChi/Xa/XemDanhSach', DongModal);
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
    XuLyAPI('DiaChi/Xa/XuLyXoaDanhSach', input, 'html', 'POST', iXuLyXoa);
}
function iXuLyXoa(data) {
    if (data) {
        if (data.KetQua === 1) {
            $("#ModalConfirm").modal('hide');
            var duLieu = JSON.parse(data.DuLieu);
            Modal.Message(Message.XoaThanhCong + '(' + duLieu.TongSoLuong + ' dòng)');
            var thamSo = DocThamSo();
            XuLyCapNhatDanhSach('DiaChi/Xa/XemDanhSach', thamSo);
        }
        if (data.KetQua === 0 || data.KetQua === -3) {
            Modal.Message(Message.XoaThatBai);
        }
        if (data.KetQua === -2) {
            location.href = window.location.protocol + "//" + window.location.host + "/" + data.GhiChu;
        }
    }
}
function HuyBo() {
    DongModalConfirm();
}
