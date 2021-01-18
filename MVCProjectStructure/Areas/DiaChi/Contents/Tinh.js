var HamXuLy = {
    Luu: "Luu",
    LuuDong: "LuuDong",
    Dong: "Dong"
};
$(document).ready(function () {
    var thamSo = DocThamSoTraVeObject(location.search);
    $("#TuKhoa").val(thamSo.tukhoa);
    XuLyTimKiem(thamSo.trang);
});
function XuLyTimKiem(trang) {
    try {
        if (!trang) {
            trang = 1;
        }
        var thamSo = "?tukhoa=" + $('#TuKhoa').val();
        thamSo = thamSo + "&trang=" + trang;
        XuLyCapNhatDanhSach('DiaChi/Tinh/XemDanhSach', thamSo);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function Them() {
    ThemCapNhat('DiaChi/Tinh/ThongTinThemCapNhat', HamXuLy);
}
function ChinhSua(Id) {
    ThemCapNhat('DiaChi/Tinh/ThongTinThemCapNhat', HamXuLy, Id);
}
function XuLyLayThongTinLuu() {
    return JsonInput = {
        Id: $('#IdEdit').val(),
        Ten: $('#txtTenTinh').val(),
        Ma: $('#txtMaTinh').val(),
        TinhHienTai: $('#txtTinhHienTai').prop('checked')
    };
}
function Luu(DongModal) {
    var JsonInput = XuLyLayThongTinLuu();
    XuLyThongTinThemCapNhat('DiaChi/Tinh/XuLyLuu', JsonInput, HamXuLy, 'DiaChi/Tinh/XemDanhSach', DongModal);
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
    XuLyAPI('DiaChi/Tinh/XuLyXoaDanhSach', input, 'html', 'POST', iXuLyXoa);
}
function iXuLyXoa(data) {
    if (data) {
        if (data.KetQua === 1) {
            $("#ModalConfirm").modal('hide');
            var duLieu = JSON.parse(data.DuLieu);
            Modal.Message(Message.XoaThanhCong + '(' + duLieu.TongSoLuong + ' dòng)');
            var thamSo = DocThamSo();
            XuLyCapNhatDanhSach('DiaChi/Tinh/XemDanhSach', thamSo);
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
