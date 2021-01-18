var HamXuLy = {
    Luu: "Luu",
    LuuDong: "LuuDong",
    Dong: "Dong"
};
$(document).ready(function () {
    var thamSo = DocThamSoTraVeObject(location.search);
    $("#TuKhoa").val(thamSo.tukhoa);
    if (thamSo.NenTang) {
        $("#LoaiHuongDanTimKiem").val(thamSo.LoaiHuongDan);
    }
    XuLyTimKiem(thamSo.trang);
});

function XuLyTimKiem(trang) {
    
    try {
        if (!trang) {
            trang = 1;
        }
        var thamSo = "?tukhoa=" + $('#TuKhoa').val();
        thamSo = thamSo + "&idLoaiHuongDan=" + $('#LoaiHuongDanTimKiem').val();
        thamSo = thamSo + "&trang=" + trang;
        XuLyCapNhatDanhSach('Admin/HuongDanSuDung/XemDanhSach', thamSo);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function XuLyLamLai() {
    $("#TuKhoa").val("");
    $('#LoaiHuongDanTimKiem option:first-child').attr("selected", "selected");
    XuLyTimKiem();
}

function Them() {
    ThemCapNhat('Admin/HuongDanSuDung/ThongTinThemCapNhat', HamXuLy);
}
function ChinhSua(Id) {
    ThemCapNhat('Admin/HuongDanSuDung/ThongTinThemCapNhat', HamXuLy, Id);
}

function XuLyLayThongTinLuu() {
    return JsonInput = {
        Id: $('#Id').val(),
        Ten: $('#Ten').val(),
        IdDanhMucLoaiHuongDan: $('#LoaiHuongDan').val(),
        DuongDan: $('#DuongDan').val(),
        GhiChu: $('#GhiChu').val(),
        ThuTu: $('#ThuTu').val()
    };
}
function Luu(DongModal) {
    var JsonInput = XuLyLayThongTinLuu();
    XuLyThongTinThemCapNhat('Admin/HuongDanSuDung/XuLyLuu', JsonInput, HamXuLy, 'Admin/HuongDanSuDung/XemDanhSach', DongModal);
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
    XuLyAPI('Admin/HuongDanSuDung/XuLyXoaDanhSach', input, 'html', 'POST', iXuLyXoa);
}
function iXuLyXoa(data) {
    if (data) {
        if (data.KetQua === 1) {
            $("#ModalConfirm").modal('hide');
            var duLieu = JSON.parse(data.DuLieu);
            Modal.Message(Message.XoaThanhCong + '(' + duLieu.TongSoLuong + ' dòng)');
            var thamSo = DocThamSo();
            XuLyCapNhatDanhSach('Admin/HuongDanSuDung/XemDanhSach', thamSo);
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
