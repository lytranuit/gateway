$(document).ready(function () {
    $("#btnsubmit").click(function (e) {
        if ($("#tungay").val() == "" || $("#denngay").val() == "") {
            e.preventDefault();
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": true,
                "progressBar": true,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            Command: toastr["warning"]("Bạn chưa chọn từ ngày, đến ngày để tìm kiếm !", "Thông báo")
        }
    });
    $('.NGAY').datepicker({
        format: 'dd/mm/yyyy',
        todayHighlight: true,
        autoclose: true,
    })
    $("#loctrangthai").change(function () {
        if ($("#loctrangthai").val() != '1') {
            $('#example23').DataTable().column(7).search($("#loctrangthai").val()).draw();
        }
        else {
            $('#example23').DataTable().column(7).search("").draw();
        }
    });
});
String.prototype.lpad = function (padString, length) {
    var str = this;
    while (str.length < length)
        str = padString + str;
    return str;
}
Number.prototype.format = function () {
    try {
        var text = this.toString().split(/(?=(?:\d{3})+(?:\.|$))/g).join(",");
        if (text != "NaN") {
            return text + ".00";
        }
        else {
            return text;
        }
    }
    catch (ex) {
        return text + "0.00";
    }
};
function validate(evt) {
    var theEvent = evt || window.event;
    // Handle paste
    if (theEvent.type === 'paste') {
        key = event.clipboardData.getData('text/plain');
    } else {
        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
    }
    var regex = /[0-9]|\./;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}
