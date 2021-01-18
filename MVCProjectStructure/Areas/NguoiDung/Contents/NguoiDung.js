var HamXuLy = {
    Luu: "Luu",
    LuuDong: "LuuDong",
    Dong: "Dong"
};
$(document).ready(function () {
    var thamSo = DocThamSoTraVeObject(location.search);
    $("#TuKhoa").val(thamSo.tukhoa);
    if (thamSo.maDonVi) {
        $("#DonViTimKiem").val(thamSo.maDonVi);
    }
    if (thamSo.maVaiTro) {
        $("#VaiTroTimKiem").val(thamSo.maVaiTro);
    }
    if (thamSo.trangThai) {
        $("#TrangThaiTimKiem").val(thamSo.trangThai);
    }
    XuLyTimKiem();
});

function XuLyTimKiem() {
    try {
        var thamSo = "?tukhoa=" + $('#TuKhoa').val();
        thamSo = thamSo + "&maDonVi=" + $('#DonViTimKiem').val();
        thamSo = thamSo + "&maVaiTro=" + $('#VaiTroTimKiem').val();
        thamSo = thamSo + "&trangThai=" + $('#TrangThaiTimKiem').val();
        XuLyCapNhatDanhSach('NguoiDung/NguoiDung/XemDanhSach', thamSo);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function XuLyLamLai() {
    $("#TuKhoa").val("");
    $('#DonViTimKiem option:first-child').attr("selected", "selected");
    $('#VaiTroTimKiem option:first-child').attr("selected", "selected");
    $('#TrangThaiTimKiem option:first-child').attr("selected", "selected");
    XuLyTimKiem();
}

function Them() {
    ThemCapNhat('NguoiDung/NguoiDung/ThongTinThemCapNhat', HamXuLy);
}
function ChinhSua(Id) {
    ThemCapNhat('NguoiDung/NguoiDung/ThongTinThemCapNhat', HamXuLy, Id);
}
function XuLyDocDanhSachIdPhanQuyenDuocChon() {
    var danhSachId = [];
    ds_check_box = $(".checkbox-quyen");
    for (i = 0; i < ds_check_box.length; i++) {
        if (ds_check_box[i].checked === true) {
            danhSachId.push(ds_check_box[i].value);
        }
    }
    return danhSachId;
}
function XuLyLayThongTinLuu() {
    var danhSachIdPhanQuyen = XuLyDocDanhSachIdPhanQuyenDuocChon();
    var danhSachIdVaiTro = [];
    idVaiTro = $("#VaiTro option:selected").data('id');
    danhSachIdVaiTro.push(idVaiTro);
    return JsonInput = {
        Id: $('#Id').val(),
        Ten: $('#Ten').val(),
        Email: $('#Email').val(),
        NgaySinh: $('#NgaySinh').val(),
        DienThoai: $('#DienThoai').val(),
        DiaChi: $('#DiaChi').val(),
        //IdAp: $('#Ap').val(),
        IdXa: $('#Xa').val(),
        IdHuyen: $('#Huyen').val(),
        DanhSachIdVaiTro: danhSachIdVaiTro,
        MaVaiTro: $('#VaiTro').val(),
        IdDonVi: $("#DonVi option:selected").data('id'),
        MaDonVi: $('#DonVi').val(),
        TenTaiKhoan: $('#TenTaiKhoan').val(),
        MatKhau: $('#MatKhau').val(),
        NhapLaiMatKhau: $('#NhapLaiMatKhau').val(),
        KichHoat: $('#KichHoat').prop('checked'),
        DanhSachIdPhanQuyen: danhSachIdPhanQuyen
    };
}
function XuLyDocDanhSachHuyenXaAp(obj, Loai, DropdownId) {
    try {
        $('#' + DropdownId).empty();
        var Id = $(obj).val();
        var input = { "Loai": Loai, "Id": Id };
        XuLyAPIOutputData('NguoiDung/NguoiDung/XuLyDocDanhSachHuyenXaAp', input, DropdownId, iXuLyCapNhatHuyenXaAp);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function iXuLyCapNhatHuyenXaAp(DropdownId, data) {
    if (data) {
        $('#' + DropdownId).append('<option value="">-- Chọn --</option>');
        if (data.KetQua === 1) {
            var danhSach = data.DuLieu;
            for (var i = 0; i < danhSach.length; i++) {
                $('#' + DropdownId).append('<option value="' + danhSach[i].Id + '">' + danhSach[i].Ten + '</option>');
            }
            $('#' + DropdownId).change();
        }
        //else {
        //    Modal.Message(data.ThongBao + " Đọc danh sách.");
        //}
    }
}
function Luu(DongModal) {
    var JsonInput = XuLyLayThongTinLuu();
    if (JsonInput.TenTaiKhoan || (JsonInput.MatKhau && JsonInput.MatKhau === JsonInput.NhapLaiMatKhau)) {
        XuLyThongTinThemCapNhat('NguoiDung/NguoiDung/XuLyLuu', JsonInput, HamXuLy, 'NguoiDung/NguoiDung/XemDanhSach', DongModal);
    } else {
        if (!JsonInput.Ten || !JsonInput.TenTaiKhoan || !JsonInput.MatKhau) {
            Alert.Add('ThongBao_Modal', "Vui lòng nhập đầy đủ thông tin!", MessageType.danger);
        } else {
            Alert.Add('ThongBao_Modal', "Nhập lại mật khẩu không đúng!", MessageType.danger);
        }
    }
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
    XuLyAPI('NguoiDung/NguoiDung/XuLyXoaDanhSach', input, 'html', 'POST', iXuLyXoa);
}
function iXuLyXoa(data) {
    if (data) {
        if (data.KetQua === 1) {
            $("#ModalConfirm").modal('hide');
            var duLieu = JSON.parse(data.DuLieu);
            Modal.Message(Message.XoaThanhCong + '(' + duLieu.TongSoLuong + ' dòng)');
            var thamSo = DocThamSo();
            XuLyCapNhatDanhSach('NguoiDung/NguoiDung/XemDanhSach', thamSo);
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

function DangNhapTrucTiep(obj) {
    var IdNguoiDung = $(obj).data('id');
    var tenTaiKhoan = $(obj).text();
    Modal.AddConfirmXoa('Bạn muốn đăng nhập bằng tài khoản "' + tenTaiKhoan.trim() + '" không?', 'DongYDangNhap("' + IdNguoiDung + '")', 'HuyBo()');
}
function DongYDangNhap(IdNguoiDung) {
    var input = { "IdNguoiDung": IdNguoiDung };
    XuLyAPI('NguoiDung/NguoiDung/DangNhapTheoIdNguoiDung', input, 'html', 'POST', iXuLyDangNhap);
}
function iXuLyDangNhap(data) {
    if (data) {
        window.location.replace(DuongDan.BangDieuKhien);
    }
}