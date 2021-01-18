var HamXuLy = {
    Luu: "Luu",
    LuuDong: "LuuDong",
    Dong: "Dong"
};
$(document).ready(function () {
    XuLyTimKiem();
});

function XuLyTimKiem() {
    try {
        var thamSo = "";
        XuLyCapNhatDanhSach('NguoiDung/PhanQuyen/XemDanhSach', thamSo);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function XuLyLamLai() {
    XuLyTimKiem();
}

function Them() {
    ThemCapNhat('NguoiDung/PhanQuyen/ThongTinThemCapNhat', HamXuLy);
}
function ChinhSua(Id) {
    ThemCapNhat('NguoiDung/PhanQuyen/ThongTinThemCapNhat', HamXuLy, Id);
}
function XuLyLayThongTinLuu() {
    var Id = $('#BangChucNangXuLy tbody').data('id');
    var TenQuyen = $('#TenQuyen').val();
    var MaVaiTro = $('#VaiTro').val();
    var MaDonVi = $('#DonVi').val();
    var tr = $('#BangChucNangXuLy').find('tbody tr');
    var DanhSachMenu = [];
    var rowLength = tr.length;
    for (var i = 0; i < rowLength; i++) {
        var row = $(tr[i]);
        var DanhSachMaChucNangXuLy = [];
        var IdMenu = row.find('.d-menu').data('id');
        var TenMenu = row.find('.d-menu').data('ten');
        var Nhom = row.find('.d-menu').data('nhom');
        var Loai = row.find('.d-menu').data('loai');
        var IdMenuCha = row.find('.d-menu').data('id-menu-cha');
        var d_TatCa = row.find('.d-tat-ca').prop('checked');
        var d_Xem = row.find('.d-Xem').prop('checked');
        var d_Them = row.find('.d-Them').prop('checked');
        var d_Sua = row.find('.d-Sua').prop('checked');
        var d_Xoa = row.find('.d-Xoa').prop('checked');
        var d_PheDuyet = row.find('.d-PheDuyet').prop('checked');
        if (d_TatCa) {
            DanhSachMaChucNangXuLy = ["Xem", "Them", "Sua", "Xoa", "Duyet"];
        }
        else {
            if (d_Xem) {
                DanhSachMaChucNangXuLy.push("Xem");
            }
            if (d_Them) {
                DanhSachMaChucNangXuLy.push("Them");
            }
            if (d_Sua) {
                DanhSachMaChucNangXuLy.push("Sua");
            }
            if (d_Xoa) {
                DanhSachMaChucNangXuLy.push("Xoa");
            }
            if (d_PheDuyet) {
                DanhSachMaChucNangXuLy.push("PheDuyet");
            }
        }
        DanhSachMenu.push({
            "IdMenu": IdMenu,
            "TenMenu": TenMenu,
            "Nhom": Nhom,
            "Loai": Loai,
            "IdMenuCha": IdMenuCha,
            "DanhSachMaChucNangXuLy": DanhSachMaChucNangXuLy
        });
    }
    return JsonInput = {
        "Id": Id,
        "TenQuyen": TenQuyen,
        "MaVaiTro": MaVaiTro,
        "MaDonVi": MaDonVi,
        "DanhSachMenu": DanhSachMenu
    };
}

function Luu(DongModal) {
    var JsonInput = XuLyLayThongTinLuu();
    //console.log(JsonInput);
    XuLyThongTinThemCapNhat('NguoiDung/PhanQuyen/XuLyLuu', JsonInput, HamXuLy, 'NguoiDung/PhanQuyen/XemDanhSach', DongModal);
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
    XuLyAPI('NguoiDung/PhanQuyen/XuLyXoaDanhSach', input, 'html', 'POST', iXuLyXoa);
}
function iXuLyXoa(data) {
    if (data) {
        if (data.KetQua === 1) {
            $("#ModalConfirm").modal('hide');
            var duLieu = JSON.parse(data.DuLieu);
            Modal.Message(Message.XoaThanhCong + '(' + duLieu.TongSoLuong + ' dòng)');
            var thamSo = DocThamSo();
            XuLyCapNhatDanhSach('NguoiDung/PhanQuyen/XemDanhSach', thamSo);
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