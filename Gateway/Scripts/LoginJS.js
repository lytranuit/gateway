setTimeout(function () {
    document.getElementById("taikhoan").readOnly = false;
    document.getElementById("pass").readOnly = false;
}, 500);
$(document).ready(function () { $("input").attr("autocomplete", "off"); });
$(document).ready(function () {
    $(window).click(function (e) {
        document.getElementById("taikhoan").readOnly = false;
        document.getElementById("pass").readOnly = false;
    });
    $(window).trigger('touchstart');
    $(window).on('touchstart', function () {
        document.getElementById("taikhoan").readOnly = false;
        document.getElementById("pass").readOnly = false;
    })
});
$(document).ready(function () {
    $("#quenmatkhau").click(function () {
       
        $.confirm({
            title: 'QUÊN MẬT KHẨU',
            content: '<div class="form-group mb-0"><label class="control-label font-italic">Nhập tài khoản của bạn để được cấp lại Mật khẩu qua Email</label><input autofocus="" type="text" id="input-name" placeholder="Nhập tên tài khoản" class="form-control"></div>',
            buttons: {
                success: {
                    text: 'Cấp lại mật khẩu',
                    btnClass: 'btn-success',
                    action: function () {
                        var input = this.$content.find('input#input-name');
                        var errorText = this.$content.find('.text-danger');
                        if (!input.val().trim()) {
                            $.alert({
                                title: "Lỗi",
                                content: "Bạn chưa nhập tên tài khoản !",
                                type: 'red'
                            });
                            return false;
                        } else {
                            $(".modal-mask").css("display", "block");
                            $.ajax({
                                type: "POST",
                                url: "/quen-mat-khau",
                                contentType: "application/json",
                                datatype: 'json',
                                data: '{taikhoan: ' + JSON.stringify(input.val()) + '}',
                                error: function () {
                                    $(".modal-mask").css("display", "none");
                                    $.confirm({
                                        title: '<b>TÀI KHOẢN BẠN NHẬP KHÔNG TỒN TẠI TRONG HỆ THỐNG</b>',
                                        content: 'Mọi thắc mắc vui lòng liên hệ - Phòng Tin Học',
                                        buttons: {
                                            cancel: {
                                                text: 'Đóng',
                                                btnClass: 'btn-blue',
                                                keys: ['enter', 'shift'],
                                                action: function () {
                                                    $("#pass").focus();
                                                }
                                            }
                                        }
                                    });
                                },
                                success: function (data) {
                                    $(".modal-mask").css("display", "none");
                                    $.confirm({
                                        title: '<b>THÔNG BÁO</b>',
                                        content: data,
                                        buttons: {
                                            cancel: {
                                                text: 'Đóng',
                                                btnClass: 'btn-blue',
                                                keys: ['enter', 'shift'],
                                                action: function () {
                                                    $("#pass").focus();
                                                }
                                            }
                                        }
                                    });
                                  
                                },
                                timeout: 5000,
                            });
                        }
                    }
                },
                cancel: {
                    text: 'Hủy',
                    btnClass: 'btn-danger',
                    action: function () {
                    }

                }
            }
        });
    });
    $("#submit").click(function (e) {
        if ($("#pass").val() == "" || $("#taikhoan").val() == "") {
            $.confirm({
                title: '<b>THÔNG BÁO</b>',
                content: 'Vui lòng điền đầy đủ thông tin tài khoản và mật khẩu !',
                buttons: {
                    cancel: {
                        text: 'Đóng',
                        btnClass: 'btn-blue',
                        keys: ['enter', 'shift'],
                        action: function () {

                        }
                    }
                }
            });
            e.preventDefault();
        }
        else {
            var pas = $("#pass").val();
            var taikhoan = $("#taikhoan").val();
            if (pas.indexOf("'") > -1 || taikhoan.indexOf("'") > -1 || pas.toUpperCase().indexOf("SELECT") > -1 || taikhoan.toUpperCase().indexOf("SELECT") > -1) {
                alert("Tài khoản hoặc mật khẩu không hợp lệ");
                close();
                e.preventDefault();
            }
            var hash = md5($("#pass").val());

            $("#hidden").val(hash);
            $(".modal-mask").css("display", "block");
        }
    });
});