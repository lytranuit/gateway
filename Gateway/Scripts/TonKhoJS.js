function openCity(evt, cityName) {
    var i, x, tablinks;
    x = document.getElementsByClassName("city");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablink");
    for (i = 0; i < x.length; i++) {
        //tablinks[i].className = tablinks[i].className.replace("w3-blue", "w3-gray");
        tablinks[i].className = tablinks[i].className.replace("w3-blue", "background1");
    }
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className = evt.currentTarget.className.replace("background1", "w3-blue");
}
$(document).ready(function () {
    $("#checkAll").change(function () {
        $(".Checkboxlist1").prop('checked', $(this).prop("checked"));
    });
    $("#MIENTRUNG").change(function () {
        $(".TRUNG").prop('checked', $(this).prop("checked"));
    });
    $("#MIENNAM").change(function () {
        $(".NAM").prop('checked', $(this).prop("checked"));
    });
    $("#MIENBAC").change(function () {
        $(".BẮC").prop('checked', $(this).prop("checked"));
    });
    $("#tonghop").change(function () {
        document.getElementById('id01').style.display = 'block';
    });
    $("#submit").click(function (e) {
        if ($('#denngay').val() == "") {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Lỗi. Bạn chưa chọn ngày!',
                size: 'small'
            });
        }
        else if ($("#chitiet").is(":checked") && $('#donvi').val() == 0) {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Lỗi. Bạn chưa chọn đơn vị!',
                size: 'small'
            });
        }
        else if ($(".Checkboxlist1").is(":checked") == false && $("#tonghop").is(":checked") == true) {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Lỗi. Bạn chưa chọn chi nhánh!',
                size: 'small'
            });
        }
        else if ($("#tonghop").is(":checked") == false && $("#chitiet").is(":checked") == false) {
            e.preventDefault();
            bootbox.alert({
                message: '<i class="fa fa-exclamation-triangle" aria-hidden="true"></i>Lỗi. Bạn chưa chọn tổng hợp hoặc chi tiết!',
                size: 'small'
            });
        }
        else {
            document.getElementById('preload').style.display = 'block';
        }

    });
    $('*[data-validation="digit"]').keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                (e.keyCode == 65 && e.ctrlKey === true) ||
                (e.keyCode >= 35 && e.keyCode <= 40) || (e.keyCode == 191) || (e.keyCode == 111)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });
});
