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
const check_gia_view = (data) => {
    var vat = data[0].VAT;
    var count = 0;
    var tongtienvat = 0;
    var tongchuavat = 0;
    var tongck = 0;
    var float1 = (100 + vat) / 100;
    for (var i = 0; i < data.length; i++) {
        var giaban_vat = data[i].GIABAN_VAT
        var dongiachuavat = giaban_vat / float1;
        var sl = data[i].SOLUONG;
        var ck = data[i].ck;
        var tienck = (dongiachuavat * ck / 100) * sl;
        var thanhtienchuavat = dongiachuavat * sl;
        tongchuavat += thanhtienchuavat;
        tongck += tienck;
    }
    //console.log(data);
    tongtienvat = (tongchuavat - tongck) * vat / 100;
    count = tongchuavat - tongck + tongtienvat;
    $("#tongtienview").text(Math.round(count).format());
    $("#tienvatview").text(Math.round(tongtienvat).format());
    $("#thanhtienview").text(Math.round(tongchuavat).format());
    $("#tienckview").text(Math.round(tongck).format());
}
const check_gia_view_mobile = (data) => {

    var vat = data[0].VAT;
    var count = 0;
    var tongtienvat = 0;
    var tongchuavat = 0;
    var tongck = 0;
    var float1 = (100 + vat) / 100;
    for (var i = 0; i < data.length; i++) {
        var giaban_vat = data[i].GIABAN_VAT
        var dongiachuavat = giaban_vat / float1;
        var sl = data[i].SOLUONG;
        var ck = data[i].ck;
        var tienck = (dongiachuavat * ck / 100) * sl;
        var thanhtienchuavat = dongiachuavat * sl;
        tongchuavat += thanhtienchuavat;
        tongck += tienck;
    }
    tongtienvat = (tongchuavat - tongck) * vat / 100;
    count = tongchuavat - tongck + tongtienvat;
    $("#slspviewmobile").text(data.length);
    $("#tongtienviewmobile").text(Math.round(count).format());
    $("#tienvatviewmobile").text(Math.round(tongtienvat).format());
    $("#thanhtienviewmobile").text(Math.round(tongchuavat).format());
    $("#tienckviewmobile").text(Math.round(tongck).format());

}

const check_gia_mobile = () => {
    var vat = parseInt($("#vat").val());
    var count = 0;
    var tongtienvat = 0;
    var tongchuavat = 0;
    var tongck = 0;
    var float1 = (100 + vat) / 100;
    $('#tablehanghoa > tbody  > tr').each(function () {

        var MAHH = $("option:selected", this).val();
        if (MAHH == "") {
            return false;
        }
        var giaban_vat = parseInt($(this).find(".giaban_vat").val().replace(/[^\d.]/g, '').replace(".00", ""))
        var dongiachuavat = giaban_vat / float1;
        var sl = parseInt($(this).find(".sl3").val().toString().replace(/[^\d.]/g, '').replace(".00", ""));
        var ck = $(this).find(".ck").val();
        //console.log($(this).find(".ck"));
        //var tienvat = (dongiachuavat * vat / 100) * sl;
        var tienck = (dongiachuavat * ck / 100) * sl;
        var thanhtienchuavat = dongiachuavat * sl;
        //tongtienvat += tienvat;
        tongchuavat += thanhtienchuavat;
        tongck += tienck;

        //count = count + parseInt($(this).find(".thanhtien").text().replace(/[^\d.]/g, ''));
    });
    tongtienvat = (tongchuavat - tongck) * vat / 100;
    count = tongchuavat - tongck + tongtienvat;
    $("#tongtien").text(Math.round(count).format());
    $("#tienvat").text(Math.round(tongtienvat).format());
    $("#thanhtien").text(Math.round(tongchuavat).format());
    $("#tienck").text(Math.round(tongck).format());
}
const check_gia = () => {
    var vat = parseInt($("#editvat").val());
    var count = 0;
    var tongtienvat = 0;
    var tongchuavat = 0;
    var tongck = 0;
    var float1 = (100 + vat) / 100;
    $('#tablehanghoaedit > tbody  > tr').each(function () {

        var MAHH = $("option:selected", this).val();
        if (MAHH == "") {
            return false;
        }
        var giaban_vat = parseInt($(this).find(".giaban_vat").val().replace(/[^\d.]/g, '').replace(".00", ""))
        var dongiachuavat = giaban_vat / float1;
        var sl = parseInt($(this).find(".sl3").val().toString().replace(/[^\d.]/g, '').replace(".00", ""));
        var ck = $(this).find(".ck").val();
        //console.log($(this).find(".ck"));
        //var tienvat = (dongiachuavat * vat / 100) * sl;
        var tienck = (dongiachuavat * ck / 100) * sl;
        var thanhtienchuavat = dongiachuavat * sl;
        //tongtienvat += tienvat;
        tongchuavat += thanhtienchuavat;
        tongck += tienck;

        //count = count + parseInt($(this).find(".thanhtien").text().replace(/[^\d.]/g, ''));
    });
    tongtienvat = (tongchuavat - tongck) * vat / 100;
    count = tongchuavat - tongck + tongtienvat;
    $("#tongtienedit").text(Math.round(count).format());
    $("#tienvatedit").text(Math.round(tongtienvat).format());
    $("#thanhtienedit").text(Math.round(tongchuavat).format());
    $("#tienckedit").text(Math.round(tongck).format());
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
    $("table").on("focus", "input:text", function () { $(this).select(); });

    $('.NGAY').datepicker({
        format: 'dd/mm/yyyy',
        todayHighlight: true,
        autoclose: true,
    });
    //$(".Checkboxlist2").change(function () {
    //    if ($('input[name=mahh]:checked').length >= 11) {
    //        $.confirm({
    //            title: '<b>THÔNG BÁO</b>',
    //            content: 'Bạn đã chọn đủ tối đa 10 sản phẩm, hãy chọn lưu và tiếp tục để tạo sang đơn hàng mới !',
    //            buttons: {
    //                confirm: {
    //                    text: 'Đóng',
    //                    btnClass: 'btn-primary',
    //                    keys: ['enter'],
    //                    action: function () {

    //                    }
    //                }
    //            }
    //        });
    //        $(this).prop('checked', false);
    //    }
    //});


    ////Mobile
    $("#btnthem").click(function () {
        $('input[name=mahh]:checked').each(function () {
            console.log($(this));
            //if ($('#tablehanghoa > tbody > tr').length == 10) {
            //    $.confirm({
            //        title: '<b>THÔNG BÁO</b>',
            //        content: 'Bạn đã chọn đủ tối đa 10 sản phẩm, hãy chọn lưu và tiếp tục để tạo sang đơn hàng mới !',
            //        buttons: {
            //            confirm: {
            //                text: 'Đóng',
            //                btnClass: 'btn-primary',
            //                keys: ['enter'],
            //                action: function () {

            //                }
            //            }

            //        }
            //    });
            //    return false;
            //}
            $('#tablehanghoa > tbody').append('<tr>'
                + '<td class="left strong hanghoa text-dark" data-dvt="' + $(this).attr("data-dvt") + '" data-kiemsoat="' + $(this).attr("data-kiemsoat") + '" data-tenhh="' + $(this).attr("data-tenhh") + '" data-mahh="' + $(this).val() + '">' + $(this).val() + " - " + $(this).attr("data-tenhh") + '</td>'
                + '<td class="text-right paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" data-sl="1" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl1"></td>'
                + '<td class="text-right paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl2") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl2"></td>'

                + '<td class="text-right paddingleft2 paddingright2 text-dark"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl3") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl3"></td>'
                + '<td class="text-right paddingleft2 paddingright2 text-dark">'
                + '<select class="form-control form-control-sm giaban_vat">'
                + '<option value="' + parseInt($(this).attr("data-giaban").replace(/[^\d.]/g, '')).format() + '">'
                + parseInt($(this).attr("data-giaban").replace(/[^\d.]/g, '')).format()
                + '</option>'
                + '<option value="0.00">0'
                + '</option>'
                + '</select>'
                + '</td>'
                + '<td class="text-right paddingleft2 paddingright2 text-dark"><input autocomplete="off" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right ck" value="0"></td>'
                + '<td class="paddingleft2 paddingright2 text-center"><button type="button" class="btn btn-sm btn-danger waves-effect transition-3d-hover btnxoahh"><i class="fa fa-2x fa-times"></i></button></td>'
                + '</tr>');
            $(this).prop('checked', false);

        });
        $("#modalhh").modal("hide");
        $("#slsp").text($('#tablehanghoa > tbody > tr').length);
    });
    $("#vat").change(function () {
        check_gia_mobile();
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

                x.find(".sl3").val((number * x.find(".sl3").attr("data-sl") / $(this).attr("data-sl")) + (x.find(".sl1").val().toString().replace(/[^\d.]/g, '') * x.find(".sl3").attr("data-sl") / x.find(".sl1").attr("data-sl")));
                x.find(".thanhtien").text((parseInt(x.find(".giaban_vat").val().toString().replace(/[^\d.]/g, '')) * parseInt(x.find(".sl3").val().toString().replace(/[^\d.]/g, ''))));
                if (typeof $("#khuyenmai option:selected").attr("data-tichdiem") != "undefined") {
                    if ($("#khuyenmai option:selected").attr("data-tichdiem") != "") {
                        $.ajax({
                            url: '/crm/GetDiemtichluy',
                            type: "POST",
                            datatype: 'json',
                            contentType: "application/json",
                            data: '{mahh: ' + JSON.stringify(x.find("td:eq(0)").attr("data-mahh")) + ', hop: ' + JSON.stringify(number) + ', mactkm: ' + JSON.stringify($("#khuyenmai").val()) + '}',
                            success: function (data) {
                                x.find(".diemtichluy").text(data);
                                var tichdiem = 0;
                                $('#tablehanghoa > tbody > tr').each(function () {
                                    tichdiem = tichdiem + parseInt($(this).find(".diemtichluy").text());
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
                                x.find(".diemtichluy").text(data);
                                var tichdiem = 0;
                                $('#tablehanghoa > tbody > tr').each(function () {
                                    tichdiem = tichdiem + parseInt($(this).find(".diemtichluy").text());
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
                check_gia_mobile();
            }
        }
    });
    $("#tablehanghoa").on("change", ".sl1", function () {
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

                x.find(".sl3").val((number * x.find(".sl3").attr("data-sl") / $(this).attr("data-sl")) + (x.find(".sl2").val().toString().replace(/[^\d.]/g, '') * x.find(".sl3").attr("data-sl") / x.find(".sl2").attr("data-sl")));
                x.find(".thanhtien").text((parseInt(x.find(".giaban_vat").val().toString().replace(/[^\d.]/g, '')) * parseInt(x.find(".sl3").val().toString().replace(/[^\d.]/g, ''))));
                if (typeof $("#khuyenmai option:selected").attr("data-tichdiem") != "undefined") {
                    if ($("#khuyenmai option:selected").attr("data-tichdiem") != "") {
                        $.ajax({
                            url: lang + '/crm/GetDiemtichluy',
                            type: "POST",
                            datatype: 'json',
                            contentType: "application/json",
                            data: '{mahh: ' + JSON.stringify(x.find(".hanghoa").attr("data-mahh")) + ', hop: ' + JSON.stringify(number) + ', mactkm: ' + JSON.stringify($("#khuyenmai").val()) + '}',
                            success: function (data) {
                                x.find(".tichdiem").text(data);
                                var tichdiem = 0;
                                $('#tablehanghoa > tbody > tr').each(function () {
                                    tichdiem = tichdiem + parseInt($(this).find(".tichdiem").text());
                                });
                                $("#tongdiemtichluy").text(tichdiem);
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
                            url: lang + '/crm/GetDiemtichluy',
                            type: "POST",
                            datatype: 'json',
                            contentType: "application/json",
                            data: '{mahh: ' + JSON.stringify(x.find(".hanghoa").attr("data-mahh")) + ', hop: ' + JSON.stringify(number) + ', mactkm: ' + JSON.stringify($("#cthotro").val()) + '}',
                            success: function (data) {
                                x.find(".tichdiem").text(data);
                                var tichdiem = 0;
                                $('#tablehanghoa > tbody > tr').each(function () {
                                    tichdiem = tichdiem + parseInt($(this).find(".tichdiem").text());
                                });
                                $("#tongdiemtichluy").text(tichdiem);
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
                check_gia_mobile();
            }
        }
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
                        check_gia_mobile();
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
    $("#tablehanghoa").on("change", ".giaban_vat,.ck,.sl3", function () {
        var x = $(this).closest('tr');
        x.find(".thanhtien").text((parseInt(x.find(".giaban_vat").val().toString().replace(/[^\d.]/g, '')) * parseInt(x.find(".sl3").val().toString().replace(/[^\d.]/g, ''))).format());

        check_gia_mobile();
    });

    $("#loctrangthai").change(function () {
        if ($("#loctrangthai").val() != '1') {
            $('#example23').DataTable().column(4).search($("#loctrangthai").val()).draw();
        }
        else {
            $('#example23').DataTable().column(4).search("").draw();
        }
    });
    $("#btntaolai").click(function () {
        $("#madhtaolai").text($("#viewdonhang").text());
        $("#taolaighichu").val("");
        $("#taolaingaygiao").val("");
    });

    /////DESKTOP
    $("#add_row_them").click(function () { // Mobile
        $("#themsanpham option:selected").each(function () {
            //if ($('#tablehanghoaedit > tbody > tr').length == 10) {
            //    $.confirm({
            //        title: '<b>THÔNG BÁO</b>',
            //        content: 'Bạn đã chọn đủ tối đa 10 sản phẩm, hãy chọn lưu và tiếp tục để tạo sang đơn hàng mới !',

            //        buttons: {
            //            cancel: {
            //                text: 'Đóng',
            //                btnClass: 'btn-blue',
            //                keys: ['enter', 'shift'],
            //                action: function () {

            //                }
            //            }
            //        }
            //    });
            //    return false;
            //}
            var mahh = $(this).val();
            var trung = 0;

            //$('#tablehanghoaedit > tbody > tr').each(function () {
            //    if (mahh == $(this).find(".hanghoa").attr("data-mahh")) {
            //        trung = 1;
            //        toastr.options = {
            //            "closeButton": false,
            //            "debug": false,
            //            "newestOnTop": true,
            //            "progressBar": true,
            //            "positionClass": "toast-top-right",
            //            "preventDuplicates": false,
            //            "onclick": null,
            //            "showDuration": "300",
            //            "hideDuration": "1000",
            //            "timeOut": "5000",
            //            "extendedTimeOut": "1000",
            //            "showEasing": "swing",
            //            "hideEasing": "linear",
            //            "showMethod": "fadeIn",
            //            "hideMethod": "fadeOut"
            //        }
            //        Command: toastr["warning"]("Sản phẩm " + mahh + " bị trùng", "Thông báo")
            //        return false;
            //    }
            //});
            if (trung == 0) {
                var i = $('#tablehanghoaedit > tbody > tr').length;
                $('#tablehanghoaedit > tbody').append('<tr>'
                    + '<td class="text-center text-dark">' + (i + 1) + '</td>'
                    + '<td class="left strong hanghoa text-dark" data-dvt="' + $(this).attr("data-dvt") + '" data-kiemsoat="' + $(this).attr("data-kiemsoat") + '" data-tenhh="' + $(this).attr("data-tenhh") + '" data-mahh="' + $(this).val() + '">' + $(this).val() + " - " + $(this).attr("data-tenhh") + '</td>'
                    + '<td class="text-right paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl1") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl1"></td>'
                    + '<td class="text-right paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl2") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl2"></td>'

                    + '<td class="text-right paddingleft2 paddingright2 text-dark"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl3") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl3"></td>'
                    + '<td class="text-right paddingleft2 paddingright2 text-dark">'
                    + '<select class="form-control form-control-sm giaban_vat">'
                    + '<option value="' + parseInt($(this).attr("data-giaban").replace(/[^\d.]/g, '')).format() + '">'
                    + parseInt($(this).attr("data-giaban").replace(/[^\d.]/g, '')).format()
                    + '</option>'
                    + '<option value="0">0'
                    + '</option>'
                    + '</select>'
                    + '</td>'
                    + '<td class="text-right paddingleft2 paddingright2 text-dark thanhtien">0.00</td>'
                    + '<td class="text-right paddingleft2 paddingright2 text-dark"><input autocomplete="off" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right ck" value="0"></td>'
                    + '<td class="text-right paddingleft2 paddingright2 text-dark diemtichluy">0</td>'
                    + '<td class="paddingleft2 paddingright2 text-center"><button type="button" class="btn btn-sm btn-danger waves-effect transition-3d-hover btnxoahh"><i class="fa fa-2x fa-times"></i></button></td>'
                    + '</tr>');
            }


        });
        $("#themsanpham").val('default');
        $("#themsanpham").selectpicker("refresh");
        $(".selectpicker").selectpicker();
    });
    $("#editvat").change(function () {
        check_gia();
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
                    if (x.find(".sl3").val() != "") {

                        $.ajax({
                            url: '/crm/GetDiemtichluy',
                            type: "POST",
                            datatype: 'json',
                            contentType: "application/json",
                            data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").val().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#editkhuyenmai").val()) + '}',
                            success: function (data) {
                                x.find(".diemtichluy").text(data);
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
                    $(this).find(".diemtichluy").text("0");
                    $("#tongdiemtichluyedit").text("0");
                });
            }
        }
        else {
            $('#tablehanghoaedit > tbody  > tr').each(function () {
                $(this).find(".diemtichluy").text("0");
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
                    if (x.find(".sl3").val() != "") {

                        $.ajax({
                            url: '/crm/GetDiemtichluy',
                            type: "POST",
                            datatype: 'json',
                            contentType: "application/json",
                            data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").val().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#editcthotro").val()) + '}',
                            success: function (data) {
                                x.find(".diemtichluy").text(data);
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
                    $(this).find(".diemtichluy").text("0");
                    $("#tongdiemtichluyedit").text("0");
                });
            }
        }
        else {
            $('#tablehanghoaedit > tbody  > tr').each(function () {
                $(this).find(".diemtichluy").text("0");
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
            x.find(".sl3").val(soluong.format());
            x.find(".thanhtien").text((parseInt(x.find(".giaban_vat").val().toString().replace(/[^\d.]/g, '')) * parseInt(x.find(".sl3").val().toString().replace(/[^\d.]/g, ''))).format());
            if (typeof $("#editkhuyenmai option:selected").attr("data-tichdiem") != "undefined") {
                if ($("#editkhuyenmai option:selected").attr("data-tichdiem") != "") {
                    $.ajax({
                        url: '/crm/GetDiemtichluy',
                        type: "POST",
                        datatype: 'json',
                        contentType: "application/json",
                        data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").val().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#editkhuyenmai").val()) + '}',
                        success: function (data) {
                            x.find(".diemtichluy").text(data);
                            var tichdiem = 0;
                            $('#tablehanghoaedit > tbody > tr').each(function () {
                                tichdiem = tichdiem + parseInt($(this).find(".diemtichluy").text());
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
                        data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").val().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#editcthotro").val()) + '}',
                        success: function (data) {
                            x.find(".diemtichluy").text(data);
                            var tichdiem = 0;
                            $('#tablehanghoaedit > tbody > tr').each(function () {
                                tichdiem = tichdiem + parseInt($(this).find(".diemtichluy").text());
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
            check_gia();
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
            x.find(".sl3").val(soluong.format());
            x.find(".thanhtien").text((parseInt(x.find(".giaban_vat").val().toString().replace(/[^\d.]/g, '')) * parseInt(x.find(".sl3").val().toString().replace(/[^\d.]/g, ''))).format());
            if (typeof $("#editkhuyenmai option:selected").attr("data-tichdiem") != "undefined") {
                if ($("#editkhuyenmai option:selected").attr("data-tichdiem") != "") {
                    $.ajax({
                        url: '/crm/GetDiemtichluy',
                        type: "POST",
                        datatype: 'json',
                        contentType: "application/json",
                        data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").val().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#editkhuyenmai").val()) + '}',
                        success: function (data) {
                            x.find(".diemtichluy").text(data);
                            var tichdiem = 0;
                            $('#tablehanghoaedit > tbody > tr').each(function () {
                                tichdiem = tichdiem + parseInt($(this).find(".diemtichluy").text());
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
                        data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").val().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#editcthotro").val()) + '}',
                        success: function (data) {
                            x.find(".diemtichluy").text(data);
                            var tichdiem = 0;
                            $('#tablehanghoaedit > tbody > tr').each(function () {
                                tichdiem = tichdiem + parseInt($(this).find(".diemtichluy").text());
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

            check_gia();
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

                        check_gia();
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
    $("#tablehanghoaedit").on("change", ".giaban_vat,.ck,.sl3", function () {
        var x = $(this).closest('tr');
        x.find(".thanhtien").text((parseInt(x.find(".giaban_vat").val().toString().replace(/[^\d.]/g, '')) * parseInt(x.find(".sl3").val().toString().replace(/[^\d.]/g, ''))).format());

        check_gia();
    });
    $("#loctrangthai1").change(function () {
        if ($("#loctrangthai1").val() != '1') {

            $('#example24').DataTable().column(4).search($("#loctrangthai1").val()).draw();
        }
        else {
            $('#example24').DataTable().column(4).search("").draw();
        }
    });
    $("#btntaolaimobile").click(function () {
        $("#madhtaolai").text($("#viewdonhangmobile").text());
        $("#taolaighichu").val("");
        $("#taolaingaygiao").val("");
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
