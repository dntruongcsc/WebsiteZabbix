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

function XuLyTimKiem(trang) {
    try {
        if (!trang) {
            trang = 1;
        }
        var thamSo = "?tukhoa=" + $('#TuKhoa').val();
        thamSo = thamSo + "&idLoaiBieuMauInAn=" + $('#LoaiBieuMauInAnTimKiem').val();
        thamSo = thamSo + "&trang=" + trang;
        XuLyCapNhatDanhSach('Admin/QuanLyBieuMauInAn/XemDanhSach', thamSo);
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
    ThemCapNhat('Admin/QuanLyBieuMauInAn/ThongTinThemCapNhat', HamXuLy);
}
function ChinhSua(Id) {
    ThemCapNhat('Admin/QuanLyBieuMauInAn/ThongTinThemCapNhat', HamXuLy, Id);
}

function XuLyLayThongTinLuu() {
    return JsonInput = {
        Id: $('#Id').val(),
        Ten: $('#Ten').val(),
        CSS: $('#CSS').val(),
        Script: $('#Script').val(),
        JsonDaTa: $('#JsonData').val(),
        GhiChu: $('#GhiChu').val(),
        Body: CKEDITOR.instances['NoiDung'].getData(),
        ThuTu: $('#ThuTu').val(),
        IdDanhMucLoaiBieuMauInAn: $('#LoaiBieuMauInAn').val()
    };
}
function Luu(DongModal) {
    var JsonInput = XuLyLayThongTinLuu();
    XuLyThongTinThemCapNhat('Admin/QuanLyBieuMauInAn/XuLyLuu', JsonInput, HamXuLy, 'Admin/QuanLyBieuMauInAn/XemDanhSach', DongModal);
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
    XuLyAPI('Admin/QuanLyBieuMauInAn/XuLyXoaDanhSach', input, 'html', 'POST', iXuLyXoa);
}
function iXuLyXoa(data) {
    if (data) {
        if (data.KetQua === 1) {
            $("#ModalConfirm").modal('hide');
            var duLieu = JSON.parse(data.DuLieu);
            Modal.Message(Message.XoaThanhCong + '(' + duLieu.TongSoLuong + ' dòng)');
            var thamSo = DocThamSo();
            XuLyCapNhatDanhSach('Admin/QuanLyBieuMauInAn/XemDanhSach', thamSo);
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

function XemTruoc(Id) {
    var input = { "Id": Id };
    XuLyAPI('Admin/QuanLyBieuMauInAn/XemTruoc', input, 'html', 'POST', iXuLyXemTruoc);
}
function iXuLyXemTruoc(data) {
    try {
        $("#XemModalBody").html('');
        if (data) {
            if (data.KetQua === 1) {
                var thongTin = jQuery.parseJSON(data.DuLieu);
                var jquery331 = '<script src="../../../Scripts/jquery-3.3.1.min.js"></script>';
                var s = '';
                s += '<html lang="en">'
                    +'<head>'
                    +'<meta charset="UTF-8">'
                    +'<meta name="viewport" content="width=device-width, initial-scale=1.0">'
                    +'<meta http-equiv="X-UA-Compatible" content="ie=edge">'
                    + '<title>' + thongTin.Ten +'</title>'
                    + '<style>' + thongTin.CSS + '</style>'
                    + '</head>'
                    + '<body>' + thongTin.Body + jquery331 + '<script>$(document).ready(function(){' + thongTin.JsonData + thongTin.Script + '});</script>' + '</body>'
                    + '</html>';
                //$("#XemModalBody").html(s);
                //$('#Xem_ModalXemTruoc').modal('show');
                var html = $("#XemModalBody").html();
                var win = window.open("", "", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=823.67,height=" + (screen.height - 100) + ",top=0" + ",left=" + (screen.width / 2 - 400));
                win.document.write(s);
                //win.document.body.innerHTML = html;
                win.document.close();
            }
        }
    } catch (e) {
        //alert(Message.LoiDuLieu);
        Modal.Message(Message.LoiDuLieu);
    }
    
}
