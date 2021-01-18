
/**
 * --------------------------------------------------------------------------
 * Modal
 * --------------------------------------------------------------------------
 */
const ModalType = {
    ThanhCong1: 'primary',
    ThanhCong2: 'success',
    Loi: 'danger',
    CanhBao: 'warning',
    ThongTin: 'info',
    MauXam: 'secondary',
    MauTrang: 'light',
    MauDen: 'dark'
};
var Modal = new Modals();
function Modals() {
    this.AddDefault = function (ModalId, ModalTitle, ModalContent) {
        if ($('#' + ModalId)) {
            $('#' + ModalId).remove();
        }
        if (!ModalTitle) {
            ModalTitle = 'Thông báo';
        }
        var s = '<div class="modal fade" id="' + ModalId + '" tabindex="-1" role="dialog" aria-hidden="true">' +
            '<div class="modal-dialog" role="document">' +
            '<div class="modal-content">' +
            '<div class="modal-header">' +
            '<h4 class="modal-title">' + ModalTitle + '</h4>' +
            '<button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
            '<span aria-hidden="true">&times;</span>' +
            '</button>' +
            '</div>' +
            '<div class="modal-body">' +
            ModalContent +
            '</div>' +
            '<div class="modal-footer">' +
            '<button type="button" class="btn btn-secondary" data-dismiss="modal">Đóng</button>' +
            '<button type="button" class="btn btn-primary">Lưu</button>' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>';
        return s;
    },
    this.Remove = function (ModalId) {
        $('#' + ModalId).remove();
    },
    this.FrameTop = function (ModalId, ModalContent, ModalButtonName, ButtonType) {
        if ($('#' + ModalId)) {
            $('#' + ModalId).remove();
        }
        if (!ModalButtonName) {
            ModalButtonName = 'Xem thông tin';
        }
        if (!ButtonType) {
            ButtonType = 'btn-info';
        }

        var s = '<div class="modal fade top" id="' + ModalId + '" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="false">' +
            '<div class="modal-dialog modal-frame modal-top modal-notify" role="document">' +
            '<div class="modal-content">' +
            '<div class="modal-body">' +
            '<div class="row d-flex justify-content-center align-items-center">' +
            '<p class="pt-3 pr-2">' + ModalContent + '</p>' +
            '<a role="button" class="btn ' + ButtonType + '">' + ModalButtonName + '<i class="fa fa-diamond ml-1"></i></a>' +
            '<a role="button" class="btn btn-outline-info waves-effect" data-dismiss="modal">Đóng</a>' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>';
        return s;
    },
    this.AddConfirmXoa = function (ModalContentMessage, fc_DongY, fc_HuyBo) {
        if (!ModalContentMessage) {
            ModalContentMessage = Message.XacNhanXoa;
        }
        $('#ModalConfirm').remove();
        var s = '<div class="modal fade" id="ModalConfirm" tabindex="-1" role="dialog" aria-hidden="true">' +
            '<div class="modal-dialog" role="document">' +
            '<div class="modal-content">' +
            '<div class="modal-header">' +
            '<h4 class="modal-title">Thông báo</h4>' +
            '<button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
            '<span aria-hidden="true">&times;</span>' +
            '</button>' +
            '</div>' +
            '<div class="modal-body">' +
            ModalContentMessage +
            '</div>' +
            '<div class="modal-footer">' +
            '<button id="btnDongY" type="button" class="btn btn-primary btn-ok">Đồng ý</button>' +
            '<button id="btnHuyBo" type="button" class="btn btn-secondary">Đóng</button>' +
            '</div>' +
            '</div>' +
            '</div>' +
            '</div>';
        $('#divModalConfirm').append(s);
        $("#ModalConfirm").modal();
        if (!(typeof fc_DongY === 'undefined') && fc_DongY !== '') {
            if (fc_DongY.indexOf('(') > 0) {
                $('#btnDongY').attr('onclick', fc_DongY);
            }
        }
        if (!(typeof fc_HuyBo === 'undefined') && fc_HuyBo !== '') {
            if (fc_DongY.indexOf('(') > 0) {
                $('#btnHuyBo').attr('onclick', fc_HuyBo);
            }
        }
    },
    this.Message = function (Content, AutoClose, TimeOut) {
        if (Content) {
            $('#ModalMessage').find('.modal-body').empty();
            $('#ModalMessage').find('.modal-body').append(Content);
            $("#ModalMessage").modal();
            if (AutoClose === true) {
                setTimeout(function () { $('#ModalMessage').modal('hide'); }, TimeOut > 0 ? TimeOut : 3000);
            }
        }

    },
    this.Them = function (ParentId, Title, FunOrLinkSave, FunOrLinkClose) {
        var Div = document.getElementById(ParentId);
        if (Div) {
            if (!Title) {
                Title = 'Thêm/Chỉnh sửa';
            }
            var Body = $('#' + ParentId).html();
            $('#' + ParentId).empty();
            var s = '<div class="modal fade" id="ModalThemChinhSua" tabindex="-1" role="dialog" aria-hidden="true">' +
                '<div class="modal-dialog" role="document">' +
                '<div class="modal-content">' +
                '<div class="modal-header">' +
                '<h4 class="modal-title">' + Title + '</h4>' +
                '<button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
                '<span aria-hidden="true">&times;</span>' +
                '</button>' +
                '</div>' +
                '<div class="modal-body">' +
                Body +
                '</div>' +
                '<div class="modal-footer">' +
                '<button type="button" class="btn btn-primary btn-ok"><i class="fa fa-save">&nbsp;</i>Lưu</button>' +
                '<button type="button" class="btn btn-secondary btn-cancel" data-dismiss="modal"><i class="fa fa-close">&nbsp;</i>Đóng</button>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>';
            $('#DivThemChinhSua').append(s);
            $('#ModalThemChinhSua').modal();
            $('#ModalThemChinhSua').on('show.bs.modal', function (e) {
                $(this).find('.btn-ok').on('click', function () {
                    if (!(typeof FunOrLinkSave === 'undefined') && FunOrLinkSave !== '') {
                        if (FunOrLinkSave.indexOf('(') > 0) {
                            var tmpFunc = new Function(FunOrLinkSave);
                            tmpFunc();
                        }
                        else {
                            window.location.href = FunOrLinkSave;
                        }
                    }
                }),
                    $(this).find('.btn-cancel').on('click', function () {
                        if (!(typeof FunOrLinkClose === 'undefined') && FunOrLinkClose !== '') {
                            if (FunOrLinkSave.indexOf('(') > 0) {
                                var tmpFunc = new Function(FunOrLinkClose);
                                tmpFunc();
                            }
                            else {
                                window.location.href = FunOrLinkClose;
                            }
                        }
                    });
            });
        }
    },
    this.ChinhSua = function (ParentId, Title, FunOrLinkSave, FunOrLinkClose) {
            var idModalThemChinhSua = document.getElementById(ParentId);
            if (!idModalThemChinhSua) {
                var Div = document.getElementById(ParentId);
                if (Div) {
                    if (!Title) {
                        Title = 'Thêm/Chỉnh sửa';
                    }
                    var Body = $('#' + ParentId).html();
                    $('#' + ParentId).empty();
                    var s = '<div class="modal fade" id="ModalThemChinhSua" tabindex="-1" role="dialog" aria-hidden="true">' +
                        '<div class="modal-dialog" role="document">' +
                        '<div class="modal-content">' +
                        '<div class="modal-header">' +
                        '<h4 class="modal-title">' + Title + '</h4>' +
                        '<button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
                        '<span aria-hidden="true">&times;</span>' +
                        '</button>' +
                        '</div>' +
                        '<div class="modal-body">' +
                        Body +
                        '</div>' +
                        '<div class="modal-footer">' +
                        '<button type="button" class="btn btn-primary btn-ok"><i class="fa fa-save">&nbsp;</i>Lưu</button>' +
                        '<button type="button" class="btn btn-secondary btn-cancel" data-dismiss="modal"><i class="fa fa-close">&nbsp;</i>Đóng</button>' +
                        '</div>' +
                        '</div>' +
                        '</div>' +
                        '</div>';
                    $('#DivThemChinhSua').append(s);
                    $('#ModalThemChinhSua').modal();
                    $('#ModalThemChinhSua').on('show.bs.modal', function (e) {
                        $(this).find('.btn-ok').on('click', function () {
                            if (!(typeof FunOrLinkSave === 'undefined') && FunOrLinkSave !== '') {
                                if (FunOrLinkSave.indexOf('(') > 0) {
                                    var tmpFunc = new Function(FunOrLinkSave);
                                    tmpFunc();
                                }
                                else {
                                    window.location.href = FunOrLinkSave;
                                }
                            }
                        }),
                            $(this).find('.btn-cancel').on('click', function () {
                                if (!(typeof FunOrLinkClose === 'undefined') && FunOrLinkClose !== '') {
                                    if (FunOrLinkSave.indexOf('(') > 0) {
                                        var tmpFunc = new Function(FunOrLinkClose);
                                        tmpFunc();
                                    }
                                    else {
                                        window.location.href = FunOrLinkClose;
                                    }
                                }
                            });
                    });
                }
            }
    };
}

