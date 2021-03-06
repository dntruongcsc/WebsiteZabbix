﻿var HamXuLy = {
    Luu: "Luu",
    LuuDong: "LuuDong",
    Dong: "Dong"
};
$(document).ready(function () {
    var thamSo = DocThamSoTraVeObject(location.search);
    if (thamSo.tukhoa) {
        $("#NoiDungTim").val(thamSo.tukhoa);
    }
    if (thamSo.IdNhomTin) {
        $("#DanhSachNhomTin").val(thamSo.IdNhomTin);
    }
    XuLyTimKiem();
});

function XuLyTimKiem(trang) {
    try {
        if (!trang) {
            trang = 1;
        }
        var thamSo = "?tukhoa=" + $('#NoiDungTim').val();
        thamSo = thamSo + "&IdDonVi=" + $('#IdLinhVucTim').val();
        thamSo = thamSo + "&IdNhomTin=" + $('#DanhSachNhomTin').val();
        thamSo = thamSo + "&trang=" + trang;
        XuLyCapNhatDanhSach('TinTuc/TinTucChoLanhDao/XemDanhSachBaiViet', thamSo);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function XuLyLamLai() {
    $("#TuKhoa").val("");
    $('#DanhSachNhomTin option:first-child').attr("selected", "selected");
    XuLyTimKiem();
}

function Them() {
    ThemCapNhat('TinTuc/TinTucChoLanhDao/ThongTinThemCapNhatBaiViet', HamXuLy);
}
function ChinhSua(Id) {
    ThemCapNhat('TinTuc/TinTucChoLanhDao/ThongTinThemCapNhatBaiViet', HamXuLy, Id);
}
function XuLyLayThongTinLuu() {
    return JsonInput = {
        Id: $('#Id').val(),
        TieuDe: $('#TieuDe').val(),
        TieuDeRutGon: $('#TieuDeRutGon').val(),
        ThuTu: $('#ThuTu').val(),
        DuongDan: $('#Duong_Dan').val(),
        NoiDungTomTat: $('#NoiDungTomTat').val(),
        NoiDung: CKEDITOR.instances['NoiDung'].getData(),
        HinhDaiDien: $('#HinhDaiDien').val(),
        IdNhomTin: $('#IdNhomTin').val(),
        //MoTa: $('#MoTa').val(),
        KichHoat: $('#KichHoat').prop('checked'),
        //TrangChu: $('#TrangChu').prop('checked'),
        //UuTien: $('#UuTien').prop('checked'),
        //NoiBat: $('#NoiBat').prop('checked'),
        //GioiHanThoiGian: $('#GioiHanThoiGian').prop('checked'),
        //TuKhoa: $('#TuKhoa').val(),
        //TieuDeSeo: $('#TieuDeSeo').val(),
        TapTinDinhKem: $('#TapTinDinhKem').val(),
        NgayTao: $('#NgayTao').val(),
    };
}
function Luu(DongModal) {
    var JsonInput = XuLyLayThongTinLuu();
    XuLyThongTinThemCapNhat('TinTuc/TinTucChoLanhDao/XuLyLuuBaiViet', JsonInput, HamXuLy, 'TinTuc/TinTucChoLanhDao/XemDanhSachBaiViet', DongModal);
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
    XuLyAPI('TinTuc/TinTucChoLanhDao/XuLyXoaDanhSachBaiViet', input, 'html', 'POST', iXuLyXoa);
}
function iXuLyXoa(data) {
    if (data) {
        if (data.KetQua === 1) {
            $("#ModalConfirm").modal('hide');
            var duLieu = JSON.parse(data.DuLieu);
            Modal.Message(Message.XoaThanhCong + '(' + duLieu.TongSoLuong + ' dòng)');
            var thamSo = DocThamSo();
            XuLyCapNhatDanhSach('TinTuc/TinTucChoLanhDao/XemDanhSachBaiViet', thamSo);
        }
        if (data.KetQua === 0) {
            Modal.Message(Message.XoaThatBai);
        }
    }
}
function HuyBo() {
    DongModalConfirm();
}