
$(document).ready(function () {
    $('.selectpicker').selectpicker();
    $("#btnluu").click(function () {
        var prevent = 0;
        $('#tablehanghoa > tbody > tr').each(function () {
            if ($(this).find('.sl3').text() == 0 || $(this).find('.sl3').text() == "") {
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
                Command: toastr["warning"]("Xin điền đẩy đủ số lượng cho sản phẩm thứ " + $(this).find('td:eq(0)').text() + " hoặc xóa sản phẩm", "Thông báo")
                prevent = 1;
                return false;
            }
        });

        if (prevent == 0) {
            if ($("#khachhang").val() == "" || $("#tablehanghoa > tbody > tr").length == 0 || $("#hopdong").val() == "") {
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
                Command: toastr["warning"]("Xin điền đầy đủ thông tin đơn hàng", "Thông báo")
            }
            else {

                $.confirm({
                    title: '<b>THÔNG BÁO</b>',
                    content: 'Bạn có chắc chắn muốn tạo đơn hàng này ?',
                    buttons: {
                        confirm: {
                            text: 'Chắc chắn',
                            btnClass: 'btn-success',
                            keys: ['enter'],
                            action: function () {
                                var url = lang + '/crm/AddDonHangHCM';
                                var data1 = [];
                                $("#tablehanghoa > tbody >tr").each(function () {
                                    data1.push({
                                        "STT": $(this).closest('tr').find('td:eq(0)').text()
                                        , "DONVI": $("#khachhang option:selected").attr('tabindex')
                                        , "KHACHHANG": $("#khachhang").val()
                                        , "HOPDONG": $("#hopdong").val()
                                        , "ck": $("#hopdong option:selected").attr("data-ck")
                                        , "MAHH": $(this).find('td:eq(1)').attr("data-mahh")
                                        , "TENHH": $(this).find('td:eq(1)').attr("data-tenhh")
                                        , "DVT": $(this).find('td:eq(1)').attr("data-dvt")
                                        , "SOLUONG": Number($(this).find('.sl3').text().toString().replace(/[^\d.]/g, '').replace(".00", ""))
                                      , "GIABAN_VAT": Number($(this).find('td:eq(5)').text().toString().replace(/[^\d.]/g, '').replace(".00", ""))
                                        , "VAT": $("#vat").val()
                                        , "GHICHU": $("#ghichu").val()
                                        , "MALO": $(this).find(".malo").val()
                                        , "HANDUNG": $(this).find(".handung").val()
                                        , "DATE": $(this).find(".datenote").val()
                                    });
                                });

                                $.ajax({
                                    url: url,
                                    type: "POST",
                                    datatype: 'json',
                                    contentType: "application/json;charset=utf-8",
                                    data: JSON.stringify(data1),
                                    success: function (data) {
                                        if (data == 0) {
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
                                            Command: toastr["warning"]("Tạo không thành công vui lòng thử lại !", "Thông báo")
                                        }
                                        else {
                                            $.confirm({
                                                title: '<b>THÔNG BÁO</b>',
                                                content: 'Đã tạo thành công đơn hàng số <b>' + data + '</b>. Bạn có muốn chuyển đến trang danh sách đơn hàng để kiểm tra ?',
                                                buttons: {
                                                    confirm: {
                                                        text: 'Chuyển trang',
                                                        btnClass: 'btn-success',
                                                        keys: ['enter'],
                                                        action: function () {
                                                            window.location.href = "quan-ly-don-hang-ve-hcm";
                                                        }
                                                    },
                                                    cancel: {
                                                        text: 'Hủy',
                                                        btnClass: 'btn-danger',
                                                        keys: ['esc'],
                                                        action: function () {
                                                            window.location.reload();
                                                        }
                                                    }
                                                }
                                            });
                                        }
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
                                        Command: toastr["warning"]("Không thành công. Vui lòng kiểm tra lại kết nối Internet !", "Thông báo")
                                    },
                                    timeout: 5000,
                                });

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
            }
        }
    });
    $("#add_row_them").click(function () {
        $("#themsanpham option:selected").each(function () {
            //if ($('#tablehanghoa > tbody > tr').length == 11) {
            //    $.confirm({
            //        title: '<b>THÔNG BÁO</b>',
            //        content: 'Bạn đã chọn đủ tối đa 11 sản phẩm, hãy chọn lưu và tiếp tục để tạo sang đơn hàng mới !',

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
            //$('#tablehanghoa > tbody > tr').each(function () {
            //    if (mahh == $(this).find("td:eq(1)").attr("data-mahh")) {
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
                var i = $('#tablehanghoa > tbody > tr').length;
                $('#tablehanghoa > tbody').append('<tr class="' + $(this).val().replace(".", "") + '">'
                + '<td class="text-center text-dark">' + (i + 1) + '</td>'
                + '<td class="left strong hanghoa text-dark" data-dvt="' + $(this).attr("data-dvt") + '" data-tenhh="' + $(this).attr("data-tenhh") + '" data-mahh="' + $(this).val() + '">' + $(this).val() + " - " + $(this).attr("data-tenhh") + '</td>'

                + '<td class="text-right paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl1") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl1"></td>'
                + '<td class="text-right paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl2") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl2"></td>'
                //+ '<td class="text-right paddingleft2 paddingright2"><input readonly autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl3") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl3"></td>'
                 + '<td class="text-right paddingleft2 paddingright2 sl3 text-dark" data-sl="' + $(this).attr("data-sl3") + '"></td>'
                + '<td class="text-right paddingleft2 paddingright2 text-dark">' + parseInt($(this).attr("data-giaban").replace(/[^\d.]/g, '')).format() + '</td>'
                + '<td class="text-right paddingleft2 paddingright2 text-dark">0.00</td>'
                                 + '<td class="paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" maxlength="10" type="text" class="form-control form-control-sm font-weight-normal malo"></td>'
                  + '<td class="paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" maxlength="6" type="text" class="form-control form-control-sm font-weight-normal handung"></td>'
                + '<td class="text-right paddingleft2 paddingright2"><input  maxlength="30" autocomplete="on" type="text" class="form-control form-control-sm font-weight-normal datenote"></td>'
                + '<td class="paddingleft2 paddingright2 text-center"><button type="button" class="btn btn-sm btn-danger waves-effect transition-3d-hover btnxoahh"><i class="fa fa-2x fa-times"></i></button></td>'
                + '</tr>');
            }
        });
        $("#themsanpham").val('default');
        $("#themsanpham").selectpicker("refresh");
        $(".selectpicker").selectpicker();
    });
    $("#btnluuvatiep").click(function () {
        var prevent = 0;
        $('#tablehanghoa > tbody > tr').each(function () {
            if ($(this).find('.sl3').text() == 0 || $(this).find('.sl3').text() == "") {
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
                Command: toastr["warning"]("Xin điền đẩy đủ số lượng cho sản phẩm thứ " + $(this).find('td:eq(0)').text() + " hoặc xóa sản phẩm", "Thông báo")
                prevent = 1;
                return false;
            }
        });

        if (prevent == 0) {
            if ($("#khachhang").val() == "" || $("#tablehanghoa > tbody > tr").length == 0 || $("#hopdong").val() == "") {
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
                Command: toastr["warning"]("Xin điền đầy đủ thông tin đơn hàng", "Thông báo")
            }
            else {
                $.confirm({
                    title: '<b>THÔNG BÁO</b>',
                    content: 'Bạn có chắc chắn muốn tạo đơn hàng này ?',
                    buttons: {
                        confirm: {
                            text: 'Chắc chắn',
                            btnClass: 'btn-success',
                            keys: ['enter'],
                            action: function () {
                                var url = lang + '/crm/AddDonHangHCM';
                                var data1 = [];
                                $("#tablehanghoa > tbody >tr").each(function () {
                                    data1.push({
                                        "STT": $(this).closest('tr').find('td:eq(0)').text()
                                       , "DONVI": $("#khachhang option:selected").attr('tabindex')
                                       , "KHACHHANG": $("#khachhang").val()
                                       , "HOPDONG": $("#hopdong").val()
                                       , "ck": $("#hopdong option:selected").attr("data-ck")
                                       , "MAHH": $(this).find('td:eq(1)').attr("data-mahh")
                                       , "TENHH": $(this).find('td:eq(1)').attr("data-tenhh")
                                       , "DVT": $(this).find('td:eq(1)').attr("data-dvt")
                                       , "SOLUONG": Number($(this).find('.sl3').text().toString().replace(/[^\d.]/g, '').replace(".00", ""))
                                       , "GIABAN_VAT": Number($(this).find('td:eq(5)').text().toString().replace(/[^\d.]/g, '').replace(".00", ""))
                                       , "VAT": $("#vat").val()
                                       , "GHICHU": $("#ghichu").val()
                                       , "MALO": $(this).find(".malo").val()
                                       , "HANDUNG": $(this).find(".handung").val()
                                       , "DATE": $(this).find(".datenote").val()
                                    });
                                });

                                $.ajax({
                                    url: url,
                                    type: "POST",
                                    datatype: 'json',
                                    contentType: "application/json;charset=utf-8",
                                    data: JSON.stringify(data1),
                                    success: function (data) {

                                        if (data == 0) {
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
                                            Command: toastr["warning"]("Tạo không thành công vui lòng thử lại !", "Thông báo")
                                        }
                                        else {
                                            $.confirm({
                                                title: '<b>THÔNG BÁO</b>',
                                                content: 'Đã tạo thành công đơn hàng số <b>' + data + '</b>. Chọn tiếp tục để tạo tiếp đơn hàng với thông tin khách hàng vừa tạo',
                                                buttons: {
                                                    confirm: {
                                                        text: 'Tiếp tục',
                                                        btnClass: 'btn-success',
                                                        keys: ['enter'],
                                                        action: function () {
                                                            $("#tab_logic").empty();
                                                            $("#tienvat").text("0.00");
                                                            $("#thanhtien").text("0.00");
                                                            $("#tongtien").text("0.00");
                                                            $("#ghichu").val("");
                                                        }
                                                    },
                                                    cancel: {
                                                        text: 'Hủy',
                                                        btnClass: 'btn-danger',
                                                        keys: ['esc'],
                                                        action: function () {
                                                            window.location.reload();
                                                        }
                                                    }
                                                }
                                            });
                                        }
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
                                        Command: toastr["warning"]("Không thành công. Vui lòng kiểm tra lại kết nối Internet !", "Thông báo")
                                    },
                                    timeout: 5000,
                                });
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
            }
        }
    });
    $("#vat").change(function () {
        var float = parseInt($("#vat").val()) / (100 + parseInt($("#vat").val()));
        var count = 0;
        $('#tablehanghoa > tbody  > tr').each(function () {
            var MAHH = $("option:selected", this).val();
            if (MAHH == "") {
                return false;
            }
            count = count + parseInt($(this).find("td:eq(6)").text().replace(/[^\d.]/g, ''));
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

            var float = parseInt($("#vat").val()) / (100 + parseInt($("#vat").val()));
            var count = 0;
            var hop = 0;
            $('#tablehanghoa > tbody  > tr').each(function () {
                var MAHH = $("option:selected", this).val();
                if (MAHH == "") {
                    return false;
                }
                count = count + parseInt($(this).find("td:eq(6)").text().replace(/[^\d.]/g, ''));
                if ($(this).find(".sl2").val() != "") {
                    hop = hop + parseInt($(this).find(".sl2").val().replace(/[^\d.]/g, ''));
                }
            });
            $("#tongtien").text(count.format());
            $("#tonghop").text(hop);
            $("#tienvat").text(Math.floor(parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) * float).format());
            $("#thanhtien").text((parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) - Math.floor(parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) * float)).format());
        }

    });
    $("#tablehanghoa").on("change", ".sl1", function () {
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
            var float = parseInt($("#vat").val()) / (100 + parseInt($("#vat").val()));
            var count = 0;
            var thung = 0;
            $('#tablehanghoa > tbody  > tr').each(function () {
                var MAHH = $("option:selected", this).val();
                if (MAHH == "") {
                    return false;
                }

                count = count + parseInt($(this).find("td:eq(6)").text().replace(/[^\d.]/g, ''));
                if ($(this).find(".sl1").val() != "") {
                    thung = thung + parseInt($(this).find(".sl1").val().replace(/[^\d.]/g, ''));
                }
            });
            $("#tongtien").text(count.format());
            $("#tongthung").text(thung);
            $("#tienvat").text(Math.floor(parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) * float).format());
            $("#thanhtien").text((parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) - Math.floor(parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) * float)).format());
        }
    });
    $("#btnhuy").click(function () {
        $.confirm({
            title: '<b>THÔNG BÁO</b>',
            content: 'Bạn có chắc chắn muốn tạo lại đơn hàng này ?',
            buttons: {
                confirm: {
                    text: 'Chắc chắn',
                    btnClass: 'btn-success',
                    keys: ['enter'],
                    action: function () {
                        window.location.href = "tao-don-dat-hang-ve-hcm";
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
                        var i = 1;
                        $("#tablehanghoa > tbody >tr").each(function () {
                            $(this).closest('tr').find('td:eq(0)').text(i);
                            i = i + 1;
                        });
                        var float = parseInt($("#vat").val()) / (100 + parseInt($("#vat").val()));
                        var count = 0;
                        var thung = 0;
                        var hop = 0;
                        $('#tablehanghoa > tbody  > tr').each(function () {
                            var MAHH = $("option:selected", this).val();
                            if (MAHH == "") {
                                return false;
                            }
                            if ($(this).find(".sl1").val() != "") {
                                thung = thung + parseInt($(this).find(".sl1").val().replace(/[^\d.]/g, ''));
                            }
                            if ($(this).find(".sl2").val() != "") {
                                hop = hop + parseInt($(this).find(".sl2").val().replace(/[^\d.]/g, ''));
                            }
                            count = count + parseInt($(this).find("td:eq(6)").text().replace(/[^\d.]/g, ''));
                        });
                        $("#tongtien").text(count.format());
                        $("#tongthung").text(thung);
                        $("#tonghop").text(hop);
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
});
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