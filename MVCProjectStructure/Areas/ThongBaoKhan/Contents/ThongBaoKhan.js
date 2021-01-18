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

    //CKEDITOR.instances['NoiDung'].setData('');
    XuLyTimKiem(thamSo.trang);
});

function XuLyTimKiem(trang) {
    try {
        if (!trang) {
            trang = 1;
        }
        var thamSo = "?tukhoa=" + $('#TuKhoa').val() + "&nhomBanTin=" + $('#IdNhomBanTinTruyenHinhTimKiem').val();
        thamSo = thamSo + "&trang=" + trang;
        XuLyCapNhatDanhSach('ThongBaoKhan/ThongBaoKhan/XemDanhSach', thamSo);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function XuLyLamLai() {
    $("#TuKhoa").val("");
    $('#LoaiBieuMauTimKiem option:first-child').attr("selected", "selected");
    XuLyTimKiem();
}

function Them() {
    ThemCapNhat('ThongBaoKhan/ThongBaoKhan/ThongTinThemCapNhat', HamXuLy);
}
function ChinhSua(Id) {
    ThemCapNhat('ThongBaoKhan/ThongBaoKhan/ThongTinThemCapNhat', HamXuLy, Id);
}

function XuLyLayThongTinLuu() {
    return JsonInput = {
        Id: $('#Id').val(),
        TieuDe: $('#TieuDe').val(),
        DuongDanThanThien: $('#DuongDanThanThien').val(),
        NoiDungTomTat: $('#NoiDungTomTat').val(),
        NoiDung: CKEDITOR.instances['NoiDung'].getData(),
        HinhDaiDien: $('#HinhDaiDien').val(),
        DoUuTien: $('#DoUuTien').prop('checked'),
        TrangThai: $('#TrangThai').prop('checked'),
        IdNhomBanTinTruyenHinh: $('#IdNhomBanTinTruyenHinh').val(),
        Video: $('#Video').val()
    };
}
function Luu(DongModal) {
    var validate = false;
    // $('.vali').hide()
   
    if (validate) return;
    var JsonInput = XuLyLayThongTinLuu();
    XuLyThongTinThemCapNhat('ThongBaoKhan/ThongBaoKhan/XuLyLuu', JsonInput, HamXuLy, 'ThongBaoKhan/ThongBaoKhan/XemDanhSach', DongModal);
}
function LuuDong() {
    Luu(true);
    // Dong() 
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
    XuLyAPI('ThongBaoKhan/ThongBaoKhan/XuLyXoaDanhSach', input, 'html', 'POST', iXuLyXoa);
}
function iXuLyXoa(data) {
    if (data) {
        if (data.KetQua === 1) {
            $("#ModalConfirm").modal('hide');
            var duLieu = JSON.parse(data.DuLieu);
            Modal.Message(Message.XoaThanhCong + '(' + duLieu.TongSoLuong + ' dòng)');
            var thamSo = DocThamSo();
            XuLyCapNhatDanhSach('ThongBaoKhan/ThongBaoKhan/XemDanhSach', thamSo);
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


