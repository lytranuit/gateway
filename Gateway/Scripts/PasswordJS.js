$(document).ready(function () {
    $("#repassnew").keyup(function () {
        if ($("#passnew").val() == $("#repassnew").val() && $("#passnew").val() != "") {
            $("#pwmatch").removeClass("fa-remove");
            $("#pwmatch").addClass("fa-check");
            $("#pwmatch").css("color", "#00A41E");
        } else {
            $("#pwmatch").removeClass("fa-check");
            $("#pwmatch").addClass("fa-remove");
            $("#pwmatch").css("color", "#FF0004");
        }
    });
    $("#passnew").keyup(function () {
        var ucase = new RegExp("[A-Z]+");
        var lcase = new RegExp("[a-z]+");
        var num = new RegExp("[0-9]+");
        if ($("#passnew").val().length >= 6) {
            $("#6char").removeClass("fa-remove");
            $("#6char").addClass("fa-check");
            $("#6char").css("color", "#00A41E");
        } else {
            $("#6char").removeClass("fa-check");
            $("#6char").addClass("fa-remove");
            $("#6char").css("color", "#FF0004");
        }
        if (ucase.test($("#passnew").val())) {
            $("#ucase").removeClass("fa-remove");
            $("#ucase").addClass("fa-check");
            $("#ucase").css("color", "#00A41E");
        } else {
            $("#ucase").removeClass("fa-check");
            $("#ucase").addClass("fa-remove");
            $("#ucase").css("color", "#FF0004");
        }
        if (lcase.test($("#passnew").val())) {
            $("#lcase").removeClass("fa-remove");
            $("#lcase").addClass("fa-check");
            $("#lcase").css("color", "#00A41E");
        } else {
            $("#lcase").removeClass("fa-check");
            $("#lcase").addClass("fa-remove");
            $("#lcase").css("color", "#FF0004");
        }
        if (num.test($("#passnew").val())) {
            $("#num").removeClass("fa-remove");
            $("#num").addClass("fa-check");
            $("#num").css("color", "#00A41E");
        } else {
            $("#num").removeClass("fa-check");
            $("#num").addClass("fa-remove");
            $("#num").css("color", "#FF0004");
        }
        if ($("#passnew").val() == $("#repassnew").val() && $("#passnew").val() != "") {
            $("#pwmatch").removeClass("fa-remove");
            $("#pwmatch").addClass("fa-check");
            $("#pwmatch").css("color", "#00A41E");
        } else {
            $("#pwmatch").removeClass("fa-check");
            $("#pwmatch").addClass("fa-remove");
            $("#pwmatch").css("color", "#FF0004");
        }
    });
    $("#submit1").click(function (e) {
        if ($("#passnew").val() == "" || $("#repassnew").val() == "" || $("#passold").val() == "") {
            e.preventDefault();
            $.confirm({
                title: (lang == "vi") ? '<b>THÔNG BÁO</b>' : "<b>ANNOUNCEMENT</b>",
                content: (lang == "vi") ? 'Hãy điền đầy đủ thông tin mật khẩu để tiếp tục !' : "Please fill out the information completely",
                buttons: {
                    cancel: {
                        text: (lang == "vi") ? 'Đóng' : "Close",
                        btnClass: 'btn-blue',
                        keys: ['enter', 'shift'],
                        action: function () {

                        }
                    }
                }
            });
        }
        else if ($("#passnew").val() != $("#repassnew").val()) {
            e.preventDefault();
            $.confirm({
                title: (lang == "vi") ? '<b>THÔNG BÁO</b>' : "<b>ANNOUNCEMENT</b>",
                content: (lang == "vi") ? 'Nhập lại mật khẩu chưa đúng ! Xin vui lòng thử lại!' : "Re-enter incorrect password! Please try again!",
                buttons: {
                    cancel: {
                        text: (lang == "vi")?'Đóng':"Close",
                        btnClass: 'btn-blue',
                        keys: ['enter', 'shift'],
                        action: function () {

                        }
                    }
                }
            });
        }
        else {
            var hash = md5($("#passnew").val());
            $("#mahoamoi").val(hash);
            var hash1 = md5($("#passold").val());
            $("#mahoacu").val(hash1);
        }
    });
});