var HamXuLy = {
    Luu: "Luu",
    LuuDong: "LuuDong",
    Dong: "Dong"
};
$(document).ready(function () {
    var tk = DocThamSoTraVeObject(location.search);
    $("#TuKhoa").val(tk.tukhoa);
    //$("#Nhom").val(tk.Nhom);
    $("#Loai").val(tk.Loai);
    XuLyTimKiem(tk.trang);
});

function XuLyTimKiem(trang) {
    try {
        if (!trang) {
            trang = 1;
        }
        var thamSo = "?tukhoa=" + $('#TuKhoa').val();
        thamSo = thamSo + "&nhom=" + $('#Nhom').val();
        thamSo = thamSo + "&loai=" + $('#Loai').val();
        thamSo = thamSo + "&trang=" + trang;
        XuLyCapNhatDanhSach("Admin/Menu/XemDanhSach", thamSo);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function XuLyLamLai() {
    $("#TuKhoa").val("");
    $('#Nhom option:first-child').attr("selected", "selected");
    $('#Loai option:first-child').attr("selected", "selected");
    XuLyTimKiem();
}

function Them() {
    //ThemCapNhat('@Url.Action("ThemCapNhatMenu", "Menu", new { area = "Admin" })', 'Luu()', 'LuuDong()', 'Dong()');
    ThemCapNhat('Admin/Menu/ThemCapNhatMenu', HamXuLy);
}

function ChinhSua(Id) {
    ThemCapNhat('Admin/Menu/ThemCapNhatMenu', HamXuLy, Id);
}

function XuLyLayThongTinLuu() {
    var kichHoat = 0;
    if ($('#KichHoat').prop('checked')) {
        kichHoat = 1;
    }
    return JsonInput = {
        Id: $('#Id').val(),
        Ten: $('#Ten').val(),
        Ma: $('#Ma').val(),
        Icon: $('#Icon').val(),
        IdMenuCha: $('#IdMenuCha').val() == null ? "" : $('#IdMenuCha').val(),
        LienKet: $('#UrlLienKet').val(),
        Nhom: $('#NhomThem').val(),
        Loai: $('#LoaiThem').val(),
        ViTri: $('#ViTri').val(),
        KichHoat: kichHoat,
        MoTa: $('#MoTa').val(),
        BieuTuong: $('#BieuTuong').val(),
        KieuHienThi: $('#KieuHienThi').val(),
        IdDonVi: $('#IdDonVi').val(),
    };
}


function Luu(DongModal) {
    //var JsonInput = XuLyLayThongTinLuu();
    //XuLyThongTinThemCapNhat(
    //    '@Url.Action("XuLyLuu", "Menu", new { area = "Admin" })',
    //    JsonInput,
    //    'Luu()',
    //    'LuuDong()',
    //    'Dong()',
    //    '@Url.Action("XemDanhSach", "Menu", new { area = "Admin" })',
    //    Dong);

    var JsonInput = XuLyLayThongTinLuu();
    XuLyThongTinThemCapNhat('Admin/Menu/XuLyLuu', JsonInput, HamXuLy, 'Admin/Menu/XemDanhSach', DongModal);
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
    //var url = '@Url.Action("XuLyXoaDanhSach", "Menu", new { area = "Admin" })';
    XuLyAPI('Admin/Menu/XuLyXoaDanhSach', input, 'html', 'POST', iXuLyXoa);
}
danhSachViTri = [];
function ThemDanhSachViTri(ths) {
    let json = {
        Id: ths.dataset.id,
        ViTri: ths.value,
    }
    let kiemTra = danhSachViTri.find(x => x.Id == json.Id);
    if (kiemTra == undefined) {
        danhSachViTri.push(json);
    }
}
//function DocDanhSachViTriThayDoi() {
//    //var ds = [];
//    //ds_ = $(".vi-tri");
//    ds_ = danhSachViTri;
//    for (i = 0; i < ds_.length; i++) {
//        let json = {
//            Id: ds_[i].dataset.id,
//            ViTri: ds_[i].value,
//        }
//        ds.push(json);
//    }
//    return ds;
//}

function LuuThayDoiViTri() {
    //var danhSachViTri = DocDanhSachViTriThayDoi();
    var inputVitri = { "DanhSachViTri": danhSachViTri };
    XuLyAPI('Admin/Menu/XuLyCapNhatViTri', inputVitri, 'html', 'POST', iXuLyCapNhatViTri);
}

function iXuLyCapNhatViTri(data) {
    if (data) {
        if (data.KetQua == 1) {
            var duLieu = JSON.parse(data.DuLieu);
            Modal.Message("Cập nhật thành công " + '(' + duLieu.TongSoLuong + ' dòng)');
            danhSachViTri = [];
            var thamSo = DocThamSo();
            XuLyCapNhatDanhSach('Admin/Menu/XemDanhSach', thamSo);
        }
        if (data.KetQua === 0 || data.KetQua === -3) {
            Modal.Message("Cập nhật lỗi");
        }
        if (data.KetQua === -2) {
            location.href = window.location.protocol + "//" + window.location.host + "/" + data.GhiChu;
        }
    }
}

function iXuLyXoa(data) {
    if (data) {
        if (data.KetQua == 1) {
            $("#ModalConfirm").modal('hide');
            var duLieu = JSON.parse(data.DuLieu);
            Modal.Message(Message.XoaThanhCong + '(' + duLieu.TongSoLuong + ' dòng)');
            var thamSo = DocThamSo();
            XuLyCapNhatDanhSach('Admin/Menu/XemDanhSach', thamSo);
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