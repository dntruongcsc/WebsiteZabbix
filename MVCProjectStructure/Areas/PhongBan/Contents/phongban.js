var HamXuLy = {
    Luu: "Luu",
    LuuDong: "LuuDong",
    Dong: "Dong"
};
$(document).ready(function () {
    var thamSo = DocThamSoTraVeObject(location.search);
    $("#TuKhoa").val(thamSo.tukhoa);
    if (thamSo.NenTang) {
        $("#NenTangTimKiem").val(thamSo.NenTang);
    }
    if (thamSo.NenTang) {
        $("#ThuocTrangTimKiem").val(thamSo.ThuocTrang);
    }
    XuLyTimKiem(thamSo.trang);
});
function XuLyDocDanhSachThuocTrangTheoNenTang(obj, ThuocTrangId) {
    try {
        $('#' + ThuocTrangId).empty();
        var MaNenTang = $(obj).val();
        var input = { "MaNenTang": MaNenTang };
        XuLyAPIOutputData('PhongBan/PhongBan/XuLyDocDanhSachNenTang', input, ThuocTrangId, iXuLyCapNhatThuocTrang);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function iXuLyCapNhatThuocTrang(ThuocTrangId, data) {
    if (data) {
        if (data.KetQua === 1) {
            var danhSach = data.DuLieu;
            for (var i = 0; i < danhSach.length; i++) {
                $('#' + ThuocTrangId).append('<option value="' + danhSach[i].Value + '">' + danhSach[i].Text + '</option>');
            }
        }
        else {
            Modal.Message(data.ThongBao + "Đọc danh sách thuộc trang.");
        }
    }
}
function XuLyTimKiem(trang) {
    try {
        if (!trang) {
            trang = 1;
        }
        var thamSo = "?tukhoa=" + $('#TuKhoa').val();
        XuLyCapNhatDanhSach('PhongBan/PhongBan/XemDanhSach', thamSo);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function XuLyLamLai() {
    $("#TuKhoa").val("");
    $('#NenTangTimKiem option:first-child').attr("selected", "selected");
    $('#ThuocTrangTimKiem option:first-child').attr("selected", "selected");
    XuLyTimKiem();
}

function Them() {
    ThemCapNhat('PhongBan/PhongBan/ThongTinThemCapNhat', HamXuLy);
}
function ChinhSua(Id) {
    ThemCapNhat('PhongBan/PhongBan/ThongTinThemCapNhat', HamXuLy, Id);
}
function XuLyLayThongTinLuu() {
    return JsonInput = {
        Id: $('#Id').val(),
        Ten: $('#Ten').val(),
        Ma: $('#Ma').val(),
        MoTa: $('#MoTa').val(),
        ThuTu: $('#ThuTu').val(),
        KichHoat: $('#KichHoat').prop('checked')      
    };
}
function Luu(DongModal) {
    var JsonInput = XuLyLayThongTinLuu();
    XuLyThongTinThemCapNhat('PhongBan/PhongBan/XuLyLuu', JsonInput, HamXuLy, 'PhongBan/PhongBan/XemDanhSach', DongModal);
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
    XuLyAPI('PhongBan/PhongBan/XuLyXoaDanhSach', input, 'html', 'POST', iXuLyXoa);
}
function iXuLyXoa(data) {
    if (data) {
        if (data.KetQua === 1) {
            $("#ModalConfirm").modal('hide');
            var duLieu = JSON.parse(data.DuLieu);
            Modal.Message(Message.XoaThanhCong + '(' + duLieu.TongSoLuong + ' dòng)');
            var thamSo = DocThamSo();
            XuLyCapNhatDanhSach('PhongBan/PhongBan/XemDanhSach', thamSo);
        }
        if (data.KetQua === 0) {
            Modal.Message(Message.XoaThatBai);
        }
    }
}
function HuyBo() {
    DongModalConfirm();
}