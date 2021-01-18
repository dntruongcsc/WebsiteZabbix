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
        $("#LoaiTimKiem").val(thamSo.MaLoai);
    }
    XuLyTimKiem(thamSo.trang);
});
function XuLyDocDanhSachLoaiTheoNenTang(obj, IdLoai) {
    try {
        $('#' + IdLoai).empty();
        var MaNenTang = $(obj).val();
        var input = { "MaNenTang": MaNenTang };
        XuLyAPIOutputData('QuanLyHost/QuanLyHost/XuLyDocDanhSachLoai', input, IdLoai, iXuLyCapNhatLoai);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function iXuLyCapNhatLoai(IdLoai, data) {
    if (data) {
        if (data.KetQua === 1) {
            var danhSach = data.DuLieu;
            $('#' + IdLoai).append('<option value="">- Chọn -</option>');
            for (var i = 0; i < danhSach.length; i++) {
                $('#' + IdLoai).append('<option value="' + danhSach[i].Ma + '" data-hinh-mau-vi-tri="' + danhSach[i].HinhMauViTri + '" data-kich-thuoc-hinh="(' + danhSach[i].ChieuRong + ' x ' + danhSach[i].ChieuCao + ')">' + danhSach[i].Ten + '</option>');
            }
        }
        else {
            Modal.Message(data.ThongBao + "Đọc danh sách loại.");
        }
    }
}
function XuLyTimKiem(trang) {
    try {
        if (!trang) {
            trang = 1;
        }
        var thamSo = "?TuKhoa=" + $('#TuKhoa').val();
      //  thamSo = thamSo + "&MaNenTang=" + $('#NenTangTimKiem').val();
        //thamSo = thamSo + "&MaLoai=" + $('#LoaiTimKiem').val();
        //thamSo = thamSo + "&Trang=" + trang;
        XuLyCapNhatDanhSach('QuanLyHost/QuanLyHost/XemDanhSach', thamSo);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function XuLyLamLai() {
    $("#TuKhoa").val("");
   // $('#NenTangTimKiem option:first-child').attr("selected", "selected");
    //$('#LoaiTimKiem option:first-child').attr("selected", "selected");
    XuLyTimKiem();
}

function Them() {
    ThemCapNhat('QuanLyHost/QuanLyHost/ThongTinThemCapNhat', HamXuLy);
}
function ChinhSua(Id) {
    ThemCapNhat('QuanLyHost/QuanLyHost/ThongTinThemCapNhat', HamXuLy, Id);
}
function XuLyLayThongTinLuu() {
    return JsonInput = {
        Id: $('#Id').val(),
        IdDonVi: $('#IdDonVi').val(),
        MaNenTang: $('#NenTang').val(),
        MaLoai: $('#Loai').val(),
        TieuDe: $('#TieuDe').val(),
        MoTa: $('#MoTa').val(),
        NoiDung: CKEDITOR.instances['NoiDung'].getData(),
        ThuTuHienThi: $('#ThuTuHienThi').val(),
        KichHoat: $('#KichHoat').prop('checked'),
        UuTien: $('#UuTien').prop('checked'),
        HinhDaiDien: $('#HinhDaiDien').val(),
        DuongDan: $('#DuongDan').val(),
        TuNgay: $('#TuNgay').val(),
        DenNgay: $('#DenNgay').val()
    };
}
function Luu(DongModal) {
    var JsonInput = XuLyLayThongTinLuu();
    XuLyThongTinThemCapNhat('QuanLyHost/QuanLyHost/XuLyLuu', JsonInput, HamXuLy, 'QuanLyHost/QuanLyHost/XemDanhSach', DongModal);
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
    XuLyAPI('QuanLyHost/QuanLyHost/XuLyXoaDanhSach', input, 'html', 'POST', iXuLyXoa);
}
function iXuLyXoa(data) {
    if (data) {
        if (data.KetQua === 1) {
            $("#ModalConfirm").modal('hide');
            var duLieu = JSON.parse(data.DuLieu);
            Modal.Message(Message.XoaThanhCong + '(' + duLieu.TongSoLuong + ' dòng)');
            var thamSo = DocThamSo();
            XuLyCapNhatDanhSach('QuanLyHost/QuanLyHost/XemDanhSach', thamSo);
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

function XuLyHienThiHinhMau() {
    try {
        var src = $('#Loai option:selected').data('hinh-mau-vi-tri');
        var kichThuoc = $('#Loai option:selected').data('kich-thuoc-hinh');
        if (src || kichThuoc) {
            $('#KichThuocHinh').text('(Kích thước hình gợi ý ' + kichThuoc + ')');
            $('#HinhViTri').attr('src', src);
        }
        else {
            $('#KichThuocHinh').text('');
            $('#HinhViTri').attr('src', '');
        }
    } catch (e) {
        return;
    }
}