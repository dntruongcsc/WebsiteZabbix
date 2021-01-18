var HamXuLy = {
    Luu: "Luu",
    LuuDong: "LuuDong",
    Dong: "Dong"
};

$(document).ready(function () {
    //Xử lý gán giá trị tìm kiếm cho các control
    var tk = DocThamSoTraVeObject(location.search);//.tukhoa
    $("#TuKhoa").val(tk.tukhoa);

    $('#TuNgay').datepicker({
        uiLibrary: 'bootstrap4',
        dateFormat: 'dd/mm/yyyy'
    });
    $('#DenNgay').datepicker({
        uiLibrary: 'bootstrap4',
        dateFormat: 'dd-mm-yy'
    });
    XuLyTimKiem(tk.trang);
});


function XuLyTimKiem(trang) {
    try {
        if (!trang) {
            trang = 1;
        }
        //var url = '@Url.Action("XemDanhSach", "NhatKy", new { area = "Admin" })';
        var thamSo = "?tukhoa=" + $('#TuKhoa').val();
        thamSo = thamSo + "&loai=" + $('#LoaiHeDieuHanh').val();
        thamSo = thamSo + "&tungay=" + $('#TuNgay').val();
        thamSo = thamSo + "&denngay=" + $('#DenNgay').val();
        thamSo = thamSo + "&trang=" + trang;
        XuLyCapNhatDanhSach("Admin/NhatKy/XemDanhSach", thamSo);
    } catch (e) {
        Modal.Message(Message.LoiDuLieu);
    }
}
function XuLyLamLai() {
    $("#TuKhoa").val("");
    $("#TuNgay").val("");
    $("#DenNgay").val("");
    //XuLyCapNhatDanhSach('@Url.Action("XemDanhSach", "NhatKy", new { area = "Admin" })', "");
    XuLyTimKiem();
}


function XuLyXoa() {
    Modal.AddConfirmXoa(Message.XacNhanXoa, 'XoaDanhSach()', 'HuyBo()');
}
function XoaDanhSach() {

    var danhSachId = DocDanhSachIdCanXoa();
    var input = { "danhSachId": danhSachId };
    XuLyAPI('Admin/NhatKy/XuLyXoaDanhSach', input, 'html', 'POST', iXuLyXoa);
}
function iXuLyXoa(data) {
    if (data) {
        if (data.KetQua === 1) {
            $("#ModalConfirm").modal('hide');
            var duLieu = JSON.parse(data.DuLieu);
            Modal.Message(Message.XoaThanhCong + '(' + duLieu.TongSoLuong + ' dòng)');
            var thamSo = DocThamSo();
            XuLyCapNhatDanhSach('Admin/NhatKy/XemDanhSach', thamSo);
        }
        if (data.KetQua === 0) {
            Modal.Message(Message.XoaThatBai);
        }
    }
}
function HuyBo() {
    $("#ModalConfirm").modal('hide');
}