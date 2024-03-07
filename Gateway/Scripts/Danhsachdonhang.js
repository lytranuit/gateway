function myFunction() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("timkiem");
    filter = input.value.toUpperCase();
    table = document.getElementById("dmhh");
    tr = table.getElementsByClassName("checkbox-primary");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("label")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
Number.prototype.format = function () {
    try
    {
        var text = this.toString().split(/(?=(?:\d{3})+(?:\.|$))/g).join(",");
        if (text != "NaN") {
            return text + ".00";
        }
        else {
            return text;
        }
    }
    catch(ex)
    {
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
$(document).ready(function () {
    $('.selectpicker').selectpicker();
    $("#btnclear").click(function () {
        $("#timkiem").val("");
        myFunction();
    });
    $('.form-control1').datepicker({
        format: 'dd/mm/yyyy',
        todayHighlight: true,
        autoclose: true,
    });
    $("#btnthemhh").click(function () {
        var height = screen.height - 210;
        $("#dmhh").css("height", height + "px");
    });
    $(".Checkboxlist2").change(function () {
        if ($('input[name=mahh]:checked').length >= 11) {
            $.confirm({
                title: '<b>THÔNG BÁO</b>',
                content: 'Bạn đã chọn đủ tối đa 10 sản phẩm, hãy chọn lưu và tiếp tục để tạo sang đơn hàng mới !',
                buttons: {
                    confirm: {
                        text: 'Đóng',
                        btnClass: 'btn-primary',
                        keys: ['enter'],
                        action: function () {

                        }
                    }
                }
            });
            $(this).prop('checked', false);
        }
    });
    $("#btnthem").click(function () {
        $('input[name=mahh]:checked').each(function () {
            if ($('#tablehanghoa > tbody > tr').length == 10) {
                $.confirm({
                    title: '<b>THÔNG BÁO</b>',
                    content: 'Bạn đã chọn đủ tối đa 10 sản phẩm, hãy chọn lưu và tiếp tục để tạo sang đơn hàng mới !',
                    buttons: {
                        confirm: {
                            text: 'Đóng',
                            btnClass: 'btn-primary',
                            keys: ['enter'],
                            action: function () {

                            }
                        }

                    }
                });
                return false;
            }
            if ($(this).val() == '60.T07' || $(this).val() == '60.P41' || $(this).val() == '60.P53') {
                $('#tablehanghoa > tbody').append('<tr>'
           + '<td class="left strong hanghoa text-dark" data-dvt="' + $(this).attr("data-dvt") + '" data-kiemsoat="' + $(this).attr("data-kiemsoat") + '" data-tenhh="' + $(this).attr("data-tenhh") + '" data-mahh="' + $(this).val() + '">' + $(this).val() + " - " + $(this).attr("data-tenhh") + '</td>'
              + '<td class="text-right paddingleft2 paddingright2"><input onkeypress="validate(event)" data-sl="1" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl1"></td>'
          + '<td class="text-right paddingleft2 paddingright2"><input placeholder="Viên" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl3") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl2"></td>'
         + '<td class="text-right paddingleft2 paddingright2"><span data-sl="' + $(this).attr("data-sl3") + '" class="sl3 text-dark">0</span></td>'
           + '<td hidden class="text-right paddingleft2 paddingright2">' + $(this).attr("data-giaban").replace(/[^\d.]/g, '') + '</td>'
           + '<td hidden class="text-right paddingleft2 paddingright2">0</td>'
             + '<td hidden class="text-right paddingleft2 paddingright2">0</td>'
           + '<td class="paddingleft2 paddingright2 text-center"><button type="button" class="btn btn-sm btn-danger waves-effect transition-3d-hover btnxoahh"><i class="fa fa-2x fa-times"></i></button></td>'
           + '</tr>');
                $(this).prop('checked', false);
            }
            else {
                $('#tablehanghoa > tbody').append('<tr>'
           + '<td class="left strong hanghoa text-dark" data-dvt="' + $(this).attr("data-dvt") + '" data-kiemsoat="' + $(this).attr("data-kiemsoat") + '" data-tenhh="' + $(this).attr("data-tenhh") + '" data-mahh="' + $(this).val() + '">' + $(this).val() + " - " + $(this).attr("data-tenhh") + '</td>'
               + '<td class="text-right paddingleft2 paddingright2"><input onkeypress="validate(event)" data-sl="1" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl1"></td>'
           + '<td class="text-right paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl2") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl2"></td>'
       + '<td class="text-right paddingleft2 paddingright2"><span data-sl="' + $(this).attr("data-sl3") + '" class="sl3 text-dark">0</span></td>'
           + '<td hidden class="text-right paddingleft2 paddingright2">' + $(this).attr("data-giaban").replace(/[^\d.]/g, '') + '</td>'
           + '<td hidden class="text-right paddingleft2 paddingright2">0</td>'
             + '<td hidden class="text-right paddingleft2 paddingright2">0</td>'
           + '<td class="paddingleft2 paddingright2 text-center"><button type="button" class="btn btn-sm btn-danger waves-effect transition-3d-hover btnxoahh"><i class="fa fa-2x fa-times"></i></button></td>'
           + '</tr>');
                $(this).prop('checked', false);
            }
        });
        $("#modalhh").modal("hide");
        $("#slsp").text($('#tablehanghoa > tbody > tr').length);
    });
    $("#vat").change(function () {
        var float = parseInt($("#vat").val()) / (100 + parseInt($("#vat").val()));
        var count = 0;
        $('#tablehanghoa > tbody  > tr').each(function () {
            count = count + parseInt($(this).find("td:eq(4)").text().replace(/[^\d.]/g, ''));
        });
        $("#tongtien").text(count.format());
        $("#tienvat").text(Math.floor(parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) * float).format());
        $("#thanhtien").text((parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) - Math.floor(parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) * float)).format());
    });
    $("table").on("focus", "input:text", function () { $(this).select(); });
    $("#tablehanghoa").on("change", ".sl2", function () {
        var x = $(this).closest('tr');
        if ($(this).val() == "") {
            $(this).val('0');
        }
        else {
            var number = parseInt($(this).val().toString().replace(/[^\d.]/g, ''));
            if (number > 2147483647) {
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
                Command: toastr["warning"]("Số lượng bạn nhập quá lớn !", "Cảnh báo")
                $(this).val("");
            }
            else {
                $(this).val(number);

                x.find(".sl3").text((number * x.find(".sl3").attr("data-sl") / $(this).attr("data-sl")) + (x.find(".sl1").val().toString().replace(/[^\d.]/g, '') * x.find(".sl3").attr("data-sl") / x.find(".sl1").attr("data-sl")));
                x.find("td:eq(5)").text((parseInt(x.find("td:eq(4)").text().toString().replace(/[^\d.]/g, '')) * parseInt(x.find(".sl3").text().toString().replace(/[^\d.]/g, ''))));
                if (typeof $("#khuyenmai option:selected").attr("data-tichdiem") != "undefined") {
                    if ($("#khuyenmai option:selected").attr("data-tichdiem") != "")
                    {
                        $.ajax({
                            url: '/crm/GetDiemtichluy',
                            type: "POST",
                            datatype: 'json',
                            contentType: "application/json",
                            data: '{mahh: ' + JSON.stringify(x.find("td:eq(0)").attr("data-mahh")) + ', hop: ' + JSON.stringify(number) + ', mactkm: ' + JSON.stringify($("#khuyenmai").val()) + '}',
                            success: function (data) {
                                x.find("td:eq(6)").text(data);
                                var tichdiem = 0;
                                $('#tablehanghoa > tbody > tr').each(function () {
                                    tichdiem = tichdiem + parseInt($(this).find("td:eq(6)").text());
                                });
                                $("#tongdiemtichluyeditmobile").text(tichdiem);
                            },
                            error: function (request, status, error) {
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
                                Command: toastr["warning"]("Không kết nối được dữ liệu điểm tích lũy", "Thông báo")
                            },
                            timeout: 5000,
                        });
                    }
                    

                }
                if (typeof $("#cthotro option:selected").attr("data-tichdiem") != "undefined") {
                    if ($("#cthotro option:selected").attr("data-tichdiem") != "") {
                        $.ajax({
                            url: '/crm/GetDiemtichluy',
                            type: "POST",
                            datatype: 'json',
                            contentType: "application/json",
                            data: '{mahh: ' + JSON.stringify(x.find("td:eq(0)").attr("data-mahh")) + ', hop: ' + JSON.stringify(number) + ', mactkm: ' + JSON.stringify($("#cthotro").val()) + '}',
                            success: function (data) {
                                x.find("td:eq(6)").text(data);
                                var tichdiem = 0;
                                $('#tablehanghoa > tbody > tr').each(function () {
                                    tichdiem = tichdiem + parseInt($(this).find("td:eq(6)").text());
                                });
                                $("#tongdiemtichluyeditmobile").text(tichdiem);
                            },
                            error: function (request, status, error) {
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
                                Command: toastr["warning"]("Không kết nối được dữ liệu điểm tích lũy", "Thông báo")
                            },
                            timeout: 5000,
                        });
                    }


                }
                var float = parseInt($("#vat").val()) / (100 + parseInt($("#vat").val()));
                var count = 0;

                $('#tablehanghoa > tbody  > tr').each(function () {
                    count = count + parseInt($(this).find("td:eq(5)").text().replace(/[^\d.]/g, ''));

                });

                $("#tongtien").text(count.format());
                $("#tienvat").text(Math.floor(parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) * float).format());
                $("#thanhtien").text((parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) - Math.floor(parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) * float)).format());

            }
        }
    });
    
    $("#btnhuy").click(function () {
        $.confirm({
            title: '<b>THÔNG BÁO</b>',
            content: 'Bạn có chắc chắn muốn tạo lại đơn hàng này?',
            buttons: {
                confirm: {
                    text: 'Chắc chắn',
                    btnClass: 'btn-success',
                    keys: ['enter'],
                    action: function () {
                        window.location.href = "tao-don-dat-hang-mobile";
                    }
                },
                cancel: {
                    text: 'Hủy',
                    btnClass: 'btn-danger',
                    keys: ['esc'],
                    action: function () {

                    }
                }
            }
        });
    });
    $("#tablehanghoa").on("click", ".btnxoahh", function () {
        var x = this;
        $.confirm({
            title: '<b>THÔNG BÁO</b>',
            content: 'Bạn có chắc chắn muốn xóa sản phẩm này ?',
            buttons: {
                confirm: {
                    text: 'Chắc chắn',
                    btnClass: 'btn-success',
                    keys: ['enter'],
                    action: function () {
                        $(x).closest('tr').remove();
                        $("#slsp").text($('#tablehanghoa > tbody > tr').length);
                        var float = parseInt($("#vat").val()) / (100 + parseInt($("#vat").val()));
                        var count = 0;
                        var diem = 0;
                        $('#tablehanghoa > tbody  > tr').each(function () {
                            count = count + parseInt($(this).find("td:eq(5)").text().replace(/[^\d.]/g, ''));
                            diem = diem + parseInt($(this).find("td:eq(6)").text());
                        });
                        $("#tongdiemtichluyeditmobile").text(diem);
                        $("#tongtien").text(count.format());
                        $("#tienvat").text(Math.floor(parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) * float).format());
                        $("#thanhtien").text((parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) - Math.floor(parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) * float)).format());
                    }
                },
                cancel: {
                    text: 'Hủy',
                    btnClass: 'btn-danger',
                    keys: ['esc'],
                    action: function () {

                    }
                }
            }
        });
    });
    $('.NGAY').datepicker({
        format: 'dd/mm/yyyy',
        todayHighlight: true,
        autoclose: true,
    });
    $("#loctrangthai").change(function () {
        if ($("#loctrangthai").val() != '1') {
            $('#example23').DataTable().column(4).search($("#loctrangthai").val()).draw();
        }
        else {
            $('#example23').DataTable().column(4).search("").draw();
        }
    });
    $("#loctrangthai1").change(function () {
        if ($("#loctrangthai1").val() != '1') {

            $('#example24').DataTable().column(4).search($("#loctrangthai1").val()).draw();
        }
        else {
            $('#example24').DataTable().column(4).search("").draw();
        }
    });
    $("#btntaolai").click(function () {
        $("#madhtaolai").text($("#viewdonhang").text());
        $("#taolaighichu").val("");
        $("#taolaingaygiao").val("");
    });
    $("#btntaolaimobile").click(function () {
        $("#madhtaolai").text($("#viewdonhangmobile").text());
        $("#taolaighichu").val("");
        $("#taolaingaygiao").val("");
    });
    $("#add_row_them").click(function () {
        $("#themsanpham option:selected").each(function () {
            if ($('#tablehanghoaedit > tbody > tr').length == 10) {
                $.confirm({
                    title: '<b>THÔNG BÁO</b>',
                    content: 'Bạn đã chọn đủ tối đa 10 sản phẩm, hãy chọn lưu và tiếp tục để tạo sang đơn hàng mới !',

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
                return false;
            }
            var mahh = $(this).val();
            var trung = 0;

            $('#tablehanghoaedit > tbody > tr').each(function () {
                if (mahh == $(this).find("td:eq(1)").attr("data-mahh")) {
                    trung = 1;
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
                    Command: toastr["warning"]("Sản phẩm " + mahh + " bị trùng", "Thông báo")
                    return false;
                }
            });
            if (trung == 0) {
                var i = $('#tablehanghoaedit > tbody > tr').length;
                if ($(this).val() == '60.T07' || $(this).val() == '60.P41' || $(this).val() == '60.P53') {
                    $('#tablehanghoaedit > tbody').append('<tr>'
            + '<td class="text-center text-dark">' + (i + 1) + '</td>'
            + '<td class="left strong hanghoa text-dark" data-dvt="' + $(this).attr("data-dvt") + '" data-kiemsoat="' + $(this).attr("data-kiemsoat") + '" data-tenhh="' + $(this).attr("data-tenhh") + '" data-mahh="' + $(this).val() + '">' + $(this).val() + " - " + $(this).attr("data-tenhh") + '</td>'
            + '<td class="text-right paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl1") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl1"></td>'
            + '<td class="text-right paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl3") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl2"></td>'
            + '<td class="text-right paddingleft2 paddingright2 text-dark sl3" data-sl="' + $(this).attr("data-sl3") + '"></td>'
            + '<td class="text-right paddingleft2 paddingright2 text-dark">' + parseInt($(this).attr("data-giaban")).format() + '</td>'
            + '<td class="text-right paddingleft2 paddingright2 text-dark">0.00</td>'
              + '<td class="text-right paddingleft2 paddingright2 text-dark">0</td>'
            + '<td class="paddingleft2 paddingright2 text-center"><button type="button" class="btn btn-sm btn-danger waves-effect transition-3d-hover btnxoahh"><i class="fa fa-2x fa-times"></i></button></td>'
            + '</tr>');
                }
                else {
                    $('#tablehanghoaedit > tbody').append('<tr>'
            + '<td class="text-center text-dark">' + (i + 1) + '</td>'
            + '<td class="left strong hanghoa text-dark" data-dvt="' + $(this).attr("data-dvt") + '" data-kiemsoat="' + $(this).attr("data-kiemsoat") + '" data-tenhh="' + $(this).attr("data-tenhh") + '" data-mahh="' + $(this).val() + '">' + $(this).val() + " - " + $(this).attr("data-tenhh") + '</td>'
            + '<td class="text-right paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl1") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl1"></td>'
            + '<td class="text-right paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl2") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl2"></td>'
            + '<td class="text-right paddingleft2 paddingright2 text-dark sl3" data-sl="' + $(this).attr("data-sl3") + '"></td>'
            + '<td class="text-right paddingleft2 paddingright2 text-dark">' + parseInt($(this).attr("data-giaban")).format() + '</td>'
            + '<td class="text-right paddingleft2 paddingright2 text-dark">0.00</td>'
             + '<td class="text-right paddingleft2 paddingright2 text-dark">0</td>'
            + '<td class="paddingleft2 paddingright2 text-center"><button type="button" class="btn btn-sm btn-danger waves-effect transition-3d-hover btnxoahh"><i class="fa fa-2x fa-times"></i></button></td>'
            + '</tr>');
                }

            }
        });
        $("#themsanpham").val('default');
        $("#themsanpham").selectpicker("refresh");
        $(".selectpicker").selectpicker();
    });
    $("table").on("focus", "input:text", function () { $(this).select(); });
    //$("#tablehanghoaedit").on("change", ".sl3", function () {
    //    var x = $(this).closest('tr');
    //    if ($(this).val() == "") {
    //        $(this).val('0');
    //    }
    //    else {
    //        var number = parseInt($(this).val().toString().replace(/[^\d.]/g, ''));
    //        if (number > 2147483647) {
    //            toastr.options = {
    //                "closeButton": false,
    //                "debug": false,
    //                "newestOnTop": true,
    //                "progressBar": true,
    //                "positionClass": "toast-top-right",
    //                "preventDuplicates": false,
    //                "onclick": null,
    //                "showDuration": "300",
    //                "hideDuration": "1000",
    //                "timeOut": "5000",
    //                "extendedTimeOut": "1000",
    //                "showEasing": "swing",
    //                "hideEasing": "linear",
    //                "showMethod": "fadeIn",
    //                "hideMethod": "fadeOut"
    //            }
    //            Command: toastr["warning"]("Số lượng bạn nhập quá lớn !", "Cảnh báo")
    //            $(this).val("");
    //        }
    //        else {
    //            $(this).val(number.format());
    //            if (x.find(".sl3").val() != "") {
    //                x.find("td:eq(6)").text((parseInt(x.find("td:eq(5)").text().toString().replace(/[^\d.]/g, '')) * parseInt(x.find(".sl3").val().toString().replace(/[^\d.]/g, ''))).format());
    //                var count = 0;
    //                var float = parseInt($("#editvat").val()) / (100 + parseInt($("#editvat").val()));
    //                $('#tablehanghoaedit > tbody  > tr').each(function () {
    //                    count = count + parseInt($(this).find("td:eq(6)").text().replace(/[^\d.]/g, ''));
    //                });
    //                $("#tongtienedit").text(count.format());
    //                $("#tienvatedit").text(Math.floor(count * float).format());
    //                $("#thanhtienedit").text((parseInt($("#tongtienedit").text().replace(/[^\d.]/g, '')) - parseInt($("#tienvatedit").text().replace(/[^\d.]/g, ''))).format());
    //            }
    //        }
    //    }
    //});
    $("#editvat").change(function () {
        var count = 0;
        var float = parseInt($("#editvat").val()) / (100 + parseInt($("#editvat").val()));
        $('#tablehanghoaedit > tbody  > tr').each(function () {
            count = count + parseInt($(this).find("td:eq(6)").text().replace(/[^\d.]/g, ''));
        });
        $("#tongtienedit").text(count.format());
        $("#tienvatedit").text(Math.floor(count * float).format());
        $("#thanhtienedit").text((parseInt($("#tongtienedit").text().replace(/[^\d.]/g, '')) - parseInt($("#tienvatedit").text().replace(/[^\d.]/g, ''))).format());
    });
    $("#khuyenmai").change(function () {

        if (typeof $("#khuyenmai option:selected").attr("data-tichdiem") != "undefined") {
            if ($("#khuyenmai option:selected").attr("data-tichdiem") != "") {
                var diem = 0;
                $('#tablehanghoa > tbody  > tr').each(function () {
                    var x = $(this);
                    if (x.find(".sl2").val() != "") {
                        $.ajax({
                            url: '/crm/GetDiemtichluy',
                            type: "POST",
                            datatype: 'json',
                            contentType: "application/json",
                            data: '{mahh: ' + JSON.stringify(x.find("td:eq(0)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl2").val()) + ', mactkm: ' + JSON.stringify($("#khuyenmai").val()) + '}',
                            success: function (data) {
                                x.find("td:eq(5)").text(data);
                                diem = diem + parseInt(data);
                                $("#tongdiemtichluyeditmobile").text(diem);
                            },
                            error: function (request, status, error) {
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
                                Command: toastr["warning"]("Không kết nối được dữ liệu điểm tích lũy", "Thông báo")
                            },
                            timeout: 5000,
                        });
                    }
                });
            }
            else {
                $('#tablehanghoa > tbody  > tr').each(function () {
                    $(this).find("td:eq(5)").text("0");
                    $("#tongdiemtichluyeditmobile").text("0");
                });
            }
        }
        else {
            $('#tablehanghoa > tbody  > tr').each(function () {
                $(this).find("td:eq(5)").text("0");
                $("#tongdiemtichluyeditmobile").text("0");
            });
        }

    });
    $("#cthotro").change(function () {

        if (typeof $("#cthotro option:selected").attr("data-tichdiem") != "undefined") {
            if ($("#cthotro option:selected").attr("data-tichdiem") != "") {
                var diem = 0;
                $('#tablehanghoa > tbody  > tr').each(function () {
                    var x = $(this);
                    if (x.find(".sl2").val() != "") {
                        $.ajax({
                            url: '/crm/GetDiemtichluy',
                            type: "POST",
                            datatype: 'json',
                            contentType: "application/json",
                            data: '{mahh: ' + JSON.stringify(x.find("td:eq(0)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl2").val()) + ', mactkm: ' + JSON.stringify($("#cthotro").val()) + '}',
                            success: function (data) {
                                x.find("td:eq(5)").text(data);
                                diem = diem + parseInt(data);
                                $("#tongdiemtichluyeditmobile").text(diem);
                            },
                            error: function (request, status, error) {
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
                                Command: toastr["warning"]("Không kết nối được dữ liệu điểm tích lũy", "Thông báo")
                            },
                            timeout: 5000,
                        });
                    }
                });
            }
            else {
                $('#tablehanghoa > tbody  > tr').each(function () {
                    $(this).find("td:eq(5)").text("0");
                    $("#tongdiemtichluyeditmobile").text("0");
                });
            }
        }
        else {
            $('#tablehanghoa > tbody  > tr').each(function () {
                $(this).find("td:eq(5)").text("0");
                $("#tongdiemtichluyeditmobile").text("0");
            });
        }

    });
    $("#editkhuyenmai").change(function () {
        if (typeof $("#editkhuyenmai option:selected").attr("data-tichdiem") != "undefined") {
            if ($("#editkhuyenmai option:selected").attr("data-tichdiem") != "") {
                var diem = 0;
                $('#tablehanghoaedit > tbody  > tr').each(function () {
                    var x = $(this);
                    if (x.find(".sl3").text() != "") {

                        $.ajax({
                            url: '/crm/GetDiemtichluy',
                            type: "POST",
                            datatype: 'json',
                            contentType: "application/json",
                            data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").text().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#editkhuyenmai").val()) + '}',
                            success: function (data) {
                                x.find("td:eq(7)").text(data);
                                diem = diem + parseInt(data);
                                $("#tongdiemtichluyedit").text(diem);
                            },
                            error: function (request, status, error) {
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
                                Command: toastr["warning"]("Không kết nối được dữ liệu điểm tích lũy", "Thông báo")
                            },
                            timeout: 5000,
                        });
                    }
                });
            }
            else {
                $('#tablehanghoaedit > tbody  > tr').each(function () {
                    $(this).find("td:eq(7)").text("0");
                    $("#tongdiemtichluyedit").text("0");
                });
            }
        }
        else {
            $('#tablehanghoaedit > tbody  > tr').each(function () {
                $(this).find("td:eq(7)").text("0");
                $("#tongdiemtichluyedit").text("0");
            });
        }

    });
    $("#editcthotro").change(function () {
        if (typeof $("#editcthotro option:selected").attr("data-tichdiem") != "undefined") {
            if ($("#editcthotro option:selected").attr("data-tichdiem") != "") {
                var diem = 0;
                $('#tablehanghoaedit > tbody  > tr').each(function () {
                    var x = $(this);
                    if (x.find(".sl3").text() != "") {

                        $.ajax({
                            url: '/crm/GetDiemtichluy',
                            type: "POST",
                            datatype: 'json',
                            contentType: "application/json",
                            data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").text().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#editcthotro").val()) + '}',
                            success: function (data) {
                                x.find("td:eq(7)").text(data);
                                diem = diem + parseInt(data);
                                $("#tongdiemtichluyedit").text(diem);
                            },
                            error: function (request, status, error) {
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
                                Command: toastr["warning"]("Không kết nối được dữ liệu điểm tích lũy", "Thông báo")
                            },
                            timeout: 5000,
                        });
                    }
                });
            }
            else {
                $('#tablehanghoaedit > tbody  > tr').each(function () {
                    $(this).find("td:eq(7)").text("0");
                    $("#tongdiemtichluyedit").text("0");
                });
            }
        }
        else {
            $('#tablehanghoaedit > tbody  > tr').each(function () {
                $(this).find("td:eq(7)").text("0");
                $("#tongdiemtichluyedit").text("0");
            });
        }

    });
    $("#tablehanghoaedit").on("change", ".sl2", function () {
        var x = $(this).closest('tr');
        if ($(this).val() == "") {
            $(this).val('0');
        }

        var number = parseInt($(this).val().toString().replace(/[^\d.]/g, ''));
        if (number > 2147483647) {
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
            Command: toastr["warning"]("Số lượng bạn nhập quá lớn !", "Cảnh báo")
            $(this).val("");
        }
        else {
            $(this).val(number.format());
            var soluong = 0;
            if (x.find(".sl1").val() != "") {
                soluong = (number * x.find(".sl3").attr("data-sl") / $(this).attr("data-sl")) + (x.find(".sl1").val().toString().replace(/[^\d.]/g, '') * x.find(".sl3").attr("data-sl") / x.find(".sl1").attr("data-sl"));
            }
            else {
                soluong = (number * x.find(".sl3").attr("data-sl") / $(this).attr("data-sl"));
            }
            x.find(".sl3").text(soluong.format());
            x.find("td:eq(6)").text((parseInt(x.find("td:eq(5)").text().toString().replace(/[^\d.]/g, '')) * parseInt(x.find(".sl3").text().toString().replace(/[^\d.]/g, ''))).format());
            if (typeof $("#editkhuyenmai option:selected").attr("data-tichdiem") != "undefined") {
                if ($("#editkhuyenmai option:selected").attr("data-tichdiem") != "")
                {
                    $.ajax({
                        url: '/crm/GetDiemtichluy',
                        type: "POST",
                        datatype: 'json',
                        contentType: "application/json",
                        data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").text().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#editkhuyenmai").val()) + '}',
                        success: function (data) {
                            x.find("td:eq(7)").text(data);
                            var tichdiem = 0;
                            $('#tablehanghoaedit > tbody > tr').each(function () {
                                tichdiem = tichdiem + parseInt($(this).find("td:eq(7)").text());
                            });
                            $("#tongdiemtichluyedit").text(tichdiem);
                        },
                        error: function (request, status, error) {
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
                            Command: toastr["warning"]("Không kết nối được dữ liệu điểm tích lũy", "Thông báo")
                        },
                        timeout: 5000,
                    });
                }
            }
            if (typeof $("#editcthotro option:selected").attr("data-tichdiem") != "undefined") {
                if ($("#editcthotro option:selected").attr("data-tichdiem") != "") {
                    $.ajax({
                        url: '/crm/GetDiemtichluy',
                        type: "POST",
                        datatype: 'json',
                        contentType: "application/json",
                        data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").text().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#editcthotro").val()) + '}',
                        success: function (data) {
                            x.find("td:eq(7)").text(data);
                            var tichdiem = 0;
                            $('#tablehanghoaedit > tbody > tr').each(function () {
                                tichdiem = tichdiem + parseInt($(this).find("td:eq(7)").text());
                            });
                            $("#tongdiemtichluyedit").text(tichdiem);
                        },
                        error: function (request, status, error) {
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
                            Command: toastr["warning"]("Không kết nối được dữ liệu điểm tích lũy", "Thông báo")
                        },
                        timeout: 5000,
                    });
                }
            }
            var float = parseInt($("#editvat").val()) / (100 + parseInt($("#editvat").val()));
            var count = 0;
            $('#tablehanghoaedit > tbody  > tr').each(function () {
                var MAHH = $("option:selected", this).val();
                if (MAHH == "") {
                    return false;
                }
                count = count + parseInt($(this).find("td:eq(6)").text().replace(/[^\d.]/g, ''));
            });
            $("#tongtienedit").text(count.format());
            $("#tienvatedit").text(Math.floor(parseInt($("#tongtienedit").text().replace(/[^\d.]/g, '')) * float).format());
            $("#thanhtienedit").text((parseInt($("#tongtienedit").text().replace(/[^\d.]/g, '')) - Math.floor(parseInt($("#tongtienedit").text().replace(/[^\d.]/g, '')) * float)).format());
        }
    });
    $("#tablehanghoaedit").on("change", ".sl1", function () {
        var x = $(this).closest('tr');
        if ($(this).val() == "") {
            $(this).val('0');
        }
        var number = parseInt($(this).val().toString().replace(/[^\d.]/g, ''));
        if (number > 2147483647) {
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
            Command: toastr["warning"]("Số lượng bạn nhập quá lớn !", "Cảnh báo")
            $(this).val("");
        }
        else {
            $(this).val(number.format());
            var soluong = 0;
            if (x.find(".sl2").val() != "") {
                soluong = (number * x.find(".sl3").attr("data-sl") / $(this).attr("data-sl")) + (x.find(".sl2").val().toString().replace(/[^\d.]/g, '') * x.find(".sl3").attr("data-sl") / x.find(".sl2").attr("data-sl"));
            }
            else {
                soluong = (number * x.find(".sl3").attr("data-sl") / $(this).attr("data-sl"));
            }
            x.find(".sl3").text(soluong.format());
            x.find("td:eq(6)").text((parseInt(x.find("td:eq(5)").text().toString().replace(/[^\d.]/g, '')) * parseInt(x.find(".sl3").text().toString().replace(/[^\d.]/g, ''))).format());
            if (typeof $("#editkhuyenmai option:selected").attr("data-tichdiem") != "undefined") {
                if ($("#editkhuyenmai option:selected").attr("data-tichdiem") != "")
                {
                    $.ajax({
                        url: '/crm/GetDiemtichluy',
                        type: "POST",
                        datatype: 'json',
                        contentType: "application/json",
                        data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").text().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#editkhuyenmai").val()) + '}',
                        success: function (data) {
                            x.find("td:eq(7)").text(data);
                            var tichdiem = 0;
                            $('#tablehanghoaedit > tbody > tr').each(function () {
                                tichdiem = tichdiem + parseInt($(this).find("td:eq(7)").text());
                            });
                            $("#tongdiemtichluyedit").text(tichdiem);
                        },
                        error: function (request, status, error) {
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
                            Command: toastr["warning"]("Không kết nối được dữ liệu điểm tích lũy", "Thông báo")
                        },
                        timeout: 5000,
                    });
                }
            }
            if (typeof $("#editcthotro option:selected").attr("data-tichdiem") != "undefined") {
                if ($("#editcthotro option:selected").attr("data-tichdiem") != "") {
                    $.ajax({
                        url: '/crm/GetDiemtichluy',
                        type: "POST",
                        datatype: 'json',
                        contentType: "application/json",
                        data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").text().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#editcthotro").val()) + '}',
                        success: function (data) {
                            x.find("td:eq(7)").text(data);
                            var tichdiem = 0;
                            $('#tablehanghoaedit > tbody > tr').each(function () {
                                tichdiem = tichdiem + parseInt($(this).find("td:eq(7)").text());
                            });
                            $("#tongdiemtichluyedit").text(tichdiem);
                        },
                        error: function (request, status, error) {
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
                            Command: toastr["warning"]("Không kết nối được dữ liệu điểm tích lũy", "Thông báo")
                        },
                        timeout: 5000,
                    });
                }
            }
            var float = parseInt($("#editvat").val()) / (100 + parseInt($("#editvat").val()));
            var count = 0;
            $('#tablehanghoaedit > tbody  > tr').each(function () {
                var MAHH = $("option:selected", this).val();
                if (MAHH == "") {
                    return false;
                }
                count = count + parseInt($(this).find("td:eq(6)").text().replace(/[^\d.]/g, ''));
            });
            $("#tongtienedit").text(count.format());
            $("#tienvatedit").text(Math.floor(parseInt($("#tongtienedit").text().replace(/[^\d.]/g, '')) * float).format());
            $("#thanhtienedit").text((parseInt($("#tongtienedit").text().replace(/[^\d.]/g, '')) - Math.floor(parseInt($("#tongtienedit").text().replace(/[^\d.]/g, '')) * float)).format());
        }
    });
    $("#tablehanghoaedit").on("click", ".btnxoahh", function () {
        var x = this;
        $.confirm({
            title: '<b>THÔNG BÁO</b>',
            content: 'Bạn có chắc chắn muốn xóa sản phẩm này ?',
            buttons: {
                confirm: {
                    text: 'Chắc chắn',
                    btnClass: 'btn-success',
                    keys: ['enter'],
                    action: function () {
                        $(x).closest('tr').remove();
                        var i = 1;
                        $("#tablehanghoaedit > tbody >tr").each(function () {
                            $(this).closest('tr').find('td:eq(0)').text(i);

                            i = i + 1;
                        });
                        var float = parseInt($("#editvat").val()) / (100 + parseInt($("#editvat").val()));
                        var count = 0;
                        var diem = 0;
                        $('#tablehanghoaedit > tbody  > tr').each(function () {
                            var MAHH = $("option:selected", this).val();
                            if (MAHH == "") {
                                return false;
                            }
                            diem = diem + parseInt($(this).find("td:eq(7)").text());
                            count = count + parseInt($(this).find("td:eq(6)").text().replace(/[^\d.]/g, ''));
                        });
                        $("#tongdiemtichluyedit").text(diem);
                        $("#tongtienedit").text(count.format());
                        $("#tienvatedit").text(Math.floor(parseInt($("#tongtienedit").text().replace(/[^\d.]/g, '')) * float).format());
                        $("#thanhtienedit").text((parseInt($("#tongtienedit").text().replace(/[^\d.]/g, '')) - Math.floor(parseInt($("#tongtienedit").text().replace(/[^\d.]/g, '')) * float)).format());
                    }
                },
                cancel: {
                    text: 'Hủy',
                    btnClass: 'btn-danger',
                    keys: ['esc'],
                    action: function () {

                    }
                }
            }
        });
    });
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
});
String.prototype.lpad = function (padString, length) {
    var str = this;
    while (str.length < length)
        str = padString + str;
    return str;
}
Number.prototype.format = function () {
    var text = this.toString().split(/(?=(?:\d{3})+(?:\.|$))/g).join(",");
    if (text != "NaN") {
        return text + ".00";
    }
    else {
        return text;
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
