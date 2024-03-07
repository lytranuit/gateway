function openCity(evt, cityName) {

    var i, x, tablinks;
    x = document.getElementsByClassName("city");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablink");
    for (i = 0; i < x.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" w3-gray", "");
    }
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " w3-gray";
}
$(document).ready(function () {
    $("#CheckAll5").change(function () {
        if ($("#CheckAll5").is(":checked")) {
            $(".Checkboxlist5").prop('checked', false);
            $(".Checkboxlist5").prop('disabled', true);
        }
        else {
            $(".Checkboxlist5").prop('disabled', false);
        }
    });
    $("#CheckAll52").change(function () {
        if ($("#CheckAll52").is(":checked")) {
            $(".Checkboxlist52").prop('checked', false);
            $(".Checkboxlist52").prop('disabled', true);
        }
        else {
            $(".Checkboxlist52").prop('disabled', false);
        }
    });
    $("#CheckAll6").change(function () {
        if ($("#CheckAll6").is(":checked")) {
            $(".Checkboxlist6").prop('checked', false);
            $(".Checkboxlist6").prop('disabled', true);
        }
        else {
            $(".Checkboxlist6").prop('disabled', false);
        }
    });
    $("#CheckAll62").change(function () {
        if ($("#CheckAll62").is(":checked")) {
            $(".Checkboxlist62").prop('checked', false);
            $(".Checkboxlist62").prop('disabled', true);
        }
        else {
            $(".Checkboxlist62").prop('disabled', false);
        }
    });
    $("#CheckAll8").change(function () {
        if ($("#CheckAll8").is(":checked")) {
            $(".Checkboxlist8").prop('checked', false);
            $(".Checkboxlist8").prop('disabled', true);
        }
        else {
            $(".Checkboxlist8").prop('disabled', false);
        }
    });
    $("#CheckAll82").change(function () {
        if ($("#CheckAll82").is(":checked")) {
            $(".Checkboxlist82").prop('checked', false);
            $(".Checkboxlist82").prop('disabled', true);
        }
        else {
            $(".Checkboxlist82").prop('disabled', false);
        }
    });
    $("#editmatkhau").change(function () {
        if ($("#editmatkhau").is(":checked")) {
            $(".matkhau").prop('disabled', false);
        }
        else {
            $(".matkhau").prop('disabled', true);
        }
    });
    $("#example23").on("click", ".btnedit", function () {
        $("#matkhauedit").val("");
        $("#rematkhauedit").val("");
        $(".matkhau").prop('disabled', true);
        $("#editmatkhau").prop("checked", false);
        $('#id04').css("display", "block");
        $("#hovatenedit").val($(this).closest('tr').find('td:eq(0)').text());
        $("#tentaikhoanedit").val($(this).closest('tr').find('td:eq(1)').text());
    });
    $("#example23").on("click", ".btnview", function () {
        $('#taikhoan3').text($(this).closest('tr').find('td:eq(1)').text());
        $('#viewphanloai').val($(this).closest('tr').find('td:eq(3)').text());
        $('#viewreadonly').val($(this).closest('tr').find('td:eq(4)').text());
        $('#viewpdf').val($(this).closest('tr').find('td:eq(5)').text());
        $('#viewexcel').val($(this).closest('tr').find('td:eq(6)').text());
        $('#viewword').val($(this).closest('tr').find('td:eq(7)').text());
        $('#viewmacn').val($(this).closest('tr').find('td:eq(8)').text());
        $('#viewmahh').val($(this).closest('tr').find('td:eq(9)').text());
        $('#viewmatinh').val($(this).closest('tr').find('td:eq(10)').text());
        $('#viewmatdv').val($(this).closest('tr').find('td:eq(11)').text());
        $('#viewmaquan').val($(this).closest('tr').find('td:eq(12)').text());
         $('#viewdathang').val($(this).closest('tr').find('td:eq(13)').text());
          $('#viewmatdvdathang').val($(this).closest('tr').find('td:eq(14)').text());
        $('#id03').css("display", "block");
    });
    $("#pageheader").text("Quản lý tài khoản");
    
    $("#MIENTRUNG").change(function () {
        $(".TRUNG").prop('checked', $(this).prop("checked"));
    });
    $("#MIENNAM").change(function () {
        $(".NAM").prop('checked', $(this).prop("checked"));
    });
    $("#MIENBAC").change(function () {
        $(".BẮC").prop('checked', $(this).prop("checked"));
    });
    $("#checkAll").change(function () {
        $(".Checkboxlist1").prop('checked', $(this).prop("checked"));
    });
    $("#MIENTRUNG2").change(function () {
        $(".TRUNG2").prop('checked', $(this).prop("checked"));
    });
    $("#MIENNAM2").change(function () {
        $(".NAM2").prop('checked', $(this).prop("checked"));
    });
    $("#MIENBAC2").change(function () {
        $(".BẮC2").prop('checked', $(this).prop("checked"));
    });
    $("#checkAll2").change(function () {
        $(".Checkboxlist12").prop('checked', $(this).prop("checked"));
    });
    $("#sanpham").change(function () {
        document.getElementById('id05').style.display = 'block';
    });
    $("#trinhduocvien").change(function () {
        if ($("#trinhduocvien").is(":checked")) {
            document.getElementById('id08').style.display = 'block';
            $(".Checkboxlist8").attr("disabled", false);
            $(".Checkboxlist1").attr("disabled", true);
        }
        else {
            $(".Checkboxlist8").attr("disabled", true);
            $(".Checkboxlist1").attr("disabled", false);
        }
    });
    $("#quan").change(function () {
        if ($("#quan").is(":checked")) {
            document.getElementById('id09').style.display = 'block';
            $(".Checkboxlist9").attr("disabled", false);
            $(".Checkboxlist1").attr("disabled", true);
        }
        else {
            $(".Checkboxlist9").attr("disabled", true);
            $(".Checkboxlist1").attr("disabled", false);
        }
    });
    $("#khuvuc").change(function () {
        document.getElementById('id06').style.display = 'block';
    });
    $("#sanpham2").change(function () {
        document.getElementById('id052').style.display = 'block';
    });
    $("#trinhduocvien2").change(function () {
        if ($("#trinhduocvien2").is(":checked")) {
            document.getElementById('id082').style.display = 'block';
            $(".Checkboxlist82").attr("disabled", false);
            $(".Checkboxlist12").attr("disabled", true);
        }
        else {
            $(".Checkboxlist82").attr("disabled", true);
            $(".Checkboxlist12").attr("disabled", false);
        }
    });
    $("#quan2").change(function () {
        if ($("#quan2").is(":checked")) {
            document.getElementById('id092').style.display = 'block';
            $(".Checkboxlist92").attr("disabled", false);
            $(".Checkboxlist12").attr("disabled", true);
        }
        else {
            $(".Checkboxlist92").attr("disabled", true);
            $(".Checkboxlist12").attr("disabled", false);
        }
    });
    $("#khuvuc2").change(function () {
        document.getElementById('id062').style.display = 'block';
    });
    $("#submit1").click(function (e) {
        if ($("#tentaikhoan").val() == "" || $("#hovaten").val() == "") {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Bạn chưa điền đủ thông tin!',
                size: 'small'
            });
        }
        else if ($("#matkhau").val() == "" || $("#rematkhau").val() == "") {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Bạn chưa điền mật khẩu!',
                size: 'small'
            });
        }
        else if ($("#matkhau").val() != $("#rematkhau").val()) {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Nhập lại mật khẩu không đúng!',
                size: 'small'
            });
        }
        else if ($(".Checkboxlist1").is(":checked") == false && $("#trinhduocvien").is(":checked") == false) {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Lỗi. Bạn chưa chọn chi nhánh!',
                size: 'small'
            });
        }
        else if ($("#quyen").val() == "") {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Bạn chưa chọn quyền',
                size: 'small'
            });
        }
        else if ($("#phanloai").val() == "") {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Bạn chưa chọn phân loại',
                size: 'small'
            });
        }
        else if ($(".Checkboxlist5").is(":checked") == false && $("#CheckAll5").is(":checked") == false) {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Lỗi. Bạn chưa chọn phân quyền sản phẩm!',
                size: 'small'
            });
        }
        else if ($(".Checkboxlist6").is(":checked") == false && $("#CheckAll6").is(":checked") == false) {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Lỗi. Bạn chưa chọn phân quyền khu vực!',
                size: 'small'
            });
        }

        else {
            var hash = md5($("#matkhau").val());
            $("#password").val(hash);
        }

    });
    $("#submit2").click(function (e) {
        if ($("#tentaikhoan").val() == "" || $("#hovaten").val() == "") {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Bạn chưa điền đủ thông tin!',
                size: 'small'
            });
        }
        else if ($("#matkhau").val() == "" || $("#rematkhau").val() == "") {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Bạn chưa điền mật khẩu!',
                size: 'small'
            });
        }
        else if ($("#matkhau").val() != $("#rematkhau").val()) {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Nhập lại mật khẩu không đúng!',
                size: 'small'
            });
        }
        else if ($(".Checkboxlist1").is(":checked") == false && $("#trinhduocvien").is(":checked") == false && $("#quan").is(":checked") == false) {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Lỗi. Bạn chưa chọn chi nhánh!',
                size: 'small'
            });
        }
        else if ($("#quyen").val() == "") {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Bạn chưa chọn quyền',
                size: 'small'
            });
        }
        else if ($("#phanloai").val() == "") {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Bạn chưa chọn phân loại',
                size: 'small'
            });
        }
        else {
            var hash = md5($("#matkhau").val());
            $("#password").val(hash);
        }

    });
});