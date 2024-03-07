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
$(document).ready(function () {
    $('.selectpicker').selectpicker();
    $("#btnluuvatiep").click(function () {
        var prevent = 0;
        var listhh = [];
        $('#tablehanghoa > tbody > tr.hanghoatr').each(function () {
            if ($(this).find('.sl3').val() == 0 || $(this).find('.sl3').val() == "") {
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
                Command: toastr["warning"]("Xin điền đẩy đủ số lượng cho sản phẩm " + $(this).closest('tr').find('td:eq(0)').text() + " hoặc xóa sản phẩm", "Thông báo")
                prevent = 1;
                return false;
            }
            //else if (listhh.indexOf($(this).closest('tr').find('td:eq(0)').attr("data-mahh")) != -1) {
            //    toastr.options = {
            //        "closeButton": false,
            //        "debug": false,
            //        "newestOnTop": true,
            //        "progressBar": true,
            //        "positionClass": "toast-top-right",
            //        "preventDuplicates": false,
            //        "onclick": null,
            //        "showDuration": "300",
            //        "hideDuration": "1000",
            //        "timeOut": "5000",
            //        "extendedTimeOut": "1000",
            //        "showEasing": "swing",
            //        "hideEasing": "linear",
            //        "showMethod": "fadeIn",
            //        "hideMethod": "fadeOut"
            //    }
            //    Command: toastr["warning"]("Sản phẩm " + $(this).closest('tr').find('td:eq(0)').text() + " bị trùng với sản phẩm trước đó vui lòng xóa 1 trong 2 sản phẩm", "Thông báo")
            //    prevent = 1;
            //    return false;
            //}
            if ($("option:selected", this).first().val() != "") {
                listhh.push($(this).closest('tr').find('td:eq(0)').attr("data-mahh"));
            }
        });

        if (prevent == 0) {

            if ($("#khachhang").val() == "" || $("#tablehanghoa > tbody > tr.hanghoatr").length == 0 || $("#hopdong").val() == "") {
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
                                var data1 = [];
                                var dem = 1;
                                $("#tablehanghoa > tbody >tr.hanghoatr").each(function () {
                                    data1.push({
                                        "NGAYGIAO": $("#ngaygiao").val()
                                        , "STT": dem
                                        , "DONVI": $("#khachhang option:selected").attr('tabindex')
                                        , "KHACHHANG": $("#khachhang").val()
                                        , "HOPDONG": $("#hopdong").val()
                                        , "ck": $("#hopdong option:selected").attr("data-ck")
                                        , "MAHH": $(this).find("td:eq(0)").attr("data-mahh")
                                        , "TENHH": $(this).find("td:eq(0)").attr("data-tenhh")
                                        , "DVT": $(this).find("td:eq(0)").attr("data-dvt")
                                        , "SOLUONG": Number($(this).find('.sl3').val().toString().replace(/[^\d.]/g, '').replace(".00", ""))
                                        , "GIABAN_VAT": Number($(this).closest('tr').find('td:eq(3)').text().toString().replace(/[^\d.]/g, '').replace(".00", ""))
                                        , "VAT": $("#vat").val()
                                        , "GHICHU": $("#ghichu").val()
                                        , "DATE": $(this).next('tr').find(".date").val()
                                        , "MALO": $(this).next('tr').next('tr').find(".malo").val()
                                        , "HANDUNG": $(this).next('tr').next('tr').find(".handung").val()
                                    });
                                    dem = dem + 1;
                                });
                                $.ajax({
                                    url: lang + '/crm/AddDonHangHCM',
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
                                                            $("#slsp").text("0");
                                                            $("#tongtien").text("0.00");
                                                            $("#tienvat").text("0.00");
                                                            $("#thanhtien").text("0.00");

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
    $("#btnluu").click(function () {
        var prevent = 0;
        var listhh = [];
        $('#tablehanghoa > tbody > tr.hanghoatr').each(function () {
            if ($(this).find('.sl3').val() == 0 || $(this).find('.sl3').val() == "") {
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
                Command: toastr["warning"]("Xin điền đẩy đủ số lượng cho sản phẩm " + $(this).closest('tr').find('td:eq(0)').text() + " hoặc xóa sản phẩm", "Thông báo")
                prevent = 1;
                return false;
            }
            //else if (listhh.indexOf($(this).closest('tr').find('td:eq(0)').attr("data-mahh")) != -1) {
            //    toastr.options = {
            //        "closeButton": false,
            //        "debug": false,
            //        "newestOnTop": true,
            //        "progressBar": true,
            //        "positionClass": "toast-top-right",
            //        "preventDuplicates": false,
            //        "onclick": null,
            //        "showDuration": "300",
            //        "hideDuration": "1000",
            //        "timeOut": "5000",
            //        "extendedTimeOut": "1000",
            //        "showEasing": "swing",
            //        "hideEasing": "linear",
            //        "showMethod": "fadeIn",
            //        "hideMethod": "fadeOut"
            //    }
            //    Command: toastr["warning"]("Sản phẩm " + $(this).closest('tr').find('td:eq(0)').text() + " bị trùng với sản phẩm trước đó vui lòng xóa 1 trong 2 sản phẩm", "Thông báo")
            //    prevent = 1;
            //    return false;
            //}


            if ($("option:selected", this).first().val() != "") {
                listhh.push($(this).closest('tr').find('td:eq(0)').attr("data-mahh"));
            }
        });

        if (prevent == 0) {
            if ($("#khachhang").val() == "" || $("#tablehanghoa > tbody > tr.hanghoatr").length == 0 || $("#hopdong").val() == "") {
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
                                var data1 = [];
                                var dem = 1;
                                $("#tablehanghoa > tbody >tr.hanghoatr").each(function () {
                                    data1.push({
                                        "NGAYGIAO": $("#ngaygiao").val()
                                        , "STT": dem
                                        , "DONVI": $("#khachhang option:selected").attr('tabindex')
                                        , "KHACHHANG": $("#khachhang").val()
                                        , "HOPDONG": $("#hopdong").val()
                                        , "ck": $("#hopdong option:selected").attr("data-ck")
                                        , "MAHH": $(this).find("td:eq(0)").attr("data-mahh")
                                        , "TENHH": $(this).find("td:eq(0)").attr("data-tenhh")
                                        , "DVT": $(this).find("td:eq(0)").attr("data-dvt")
                                       , "SOLUONG": Number($(this).find('.sl3').val().toString().replace(/[^\d.]/g, '').replace(".00", ""))
                                        , "GIABAN_VAT": Number($(this).closest('tr').find('td:eq(3)').text().toString().replace(/[^\d.]/g, '').replace(".00", ""))
                                        , "VAT": $("#vat").val()
                                        , "GHICHU": $("#ghichu").val()
                                        , "MALO": $(this).next('tr').next('tr').find(".malo").val()
                                        , "HANDUNG": $(this).next('tr').next('tr').find(".handung").val()
                                        , "DATE": $(this).next('tr').find(".date").val()
                                    });
                                    dem = dem + 1;
                                });
                                $.ajax({
                                    url: lang + '/crm/AddDonHangHCM',
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
    $("#btnclear").click(function () {
        $("#timkiem").val("");
        myFunction();
    });
    $("#btnthemhh").click(function () {
        var height = screen.height - 210;
        $("#dmhh").css("height", height + "px");
    });
    //$(".Checkboxlist2").change(function () {
    //    if ($('input[name=mahh]:checked').length >= 12) {
    //        $.confirm({
    //            title: '<b>THÔNG BÁO</b>',
    //            content: 'Bạn đã chọn đủ tối đa 11 sản phẩm, hãy chọn lưu và tiếp tục để tạo sang đơn hàng mới !',
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
    $("#btnthem").click(function () {

        $('input[name=mahh]:checked').each(function () {
            //if ($('#tablehanghoa > tbody > tr.hanghoatr').length == 11) {
            //    $.confirm({
            //        title: '<b>THÔNG BÁO</b>',
            //        content: 'Bạn đã chọn đủ tối đa 11 sản phẩm, hãy chọn lưu và tiếp tục để tạo sang đơn hàng mới !',
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
            $('#tablehanghoa > tbody').append('<tr class="hanghoatr">'
        + '<td class="left strong hanghoa text-dark" data-dvt="' + $(this).attr("data-dvt") + '" data-tenhh="' + $(this).attr("data-tenhh") + '" data-mahh="' + $(this).val() + '">' + $(this).val() + " - " + $(this).attr("data-tenhh") + '</td>'
        + '<td class="text-right paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl2") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl2"></td>'
        + '<td hidden class="text-right paddingleft2 paddingright2"><input onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl3") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl3"></td>'
        + '<td hidden class="text-right paddingleft2 paddingright2">' + $(this).attr("data-giaban").replace(/[^\d.]/g, '') + '</td>'
        + '<td hidden class="text-right paddingleft2 paddingright2">0</td>'
        + '<td class="paddingleft2 paddingright2 text-center"><button type="button" class="btn btn-sm btn-danger waves-effect transition-3d-hover btnxoahh"><i class="fa fa-2x fa-times"></i></button></td>'
        + '</tr>'
        + '<tr class="datetr"><td colspan="3"><input placeholder="Điền ghi chú..." class="date form-control form-control-sm font-weight-normal" type="text"></td></tr>'
        + '<tr class="malotr"><td colspan="1"><input onkeypress="validate(event)" maxlength="10" placeholder="Điền số lô..." class="malo form-control form-control-sm font-weight-normal" type="text"></td><td colspan="2"><input maxlength="6" onkeypress="validate(event)" placeholder="Điền hạn dùng..." class="handung form-control form-control-sm font-weight-normal" type="text"></td></tr>'
        );
            $(this).prop('checked', false);
        });
        $("#modalhh").modal("hide");
        $("#slsp").text($('#tablehanghoa > tbody > tr.hanghoatr').length);
    });
    $("#vat").change(function () {
        var float = parseInt($("#vat").val()) / (100 + parseInt($("#vat").val()));
        var count = 0;
        $('#tablehanghoa > tbody  > tr.hanghoatr').each(function () {
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
                x.find(".sl3").val((number * x.find(".sl3").attr("data-sl") / $(this).attr("data-sl")).format());
                x.find("td:eq(4)").text((parseInt(x.find("td:eq(3)").text().toString().replace(/[^\d.]/g, '')) * parseInt(x.find(".sl3").val().toString().replace(/[^\d.]/g, ''))));
                var float = parseInt($("#vat").val()) / (100 + parseInt($("#vat").val()));
                var count = 0;
                $('#tablehanghoa > tbody  > tr.hanghoatr').each(function () {
                    count = count + parseInt($(this).find("td:eq(4)").text().replace(/[^\d.]/g, ''));
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
                        window.location.href = "tao-don-dat-hang-ve-hcm-mobile";
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
                        $(x).closest('tr.hanghoatr').next('tr').remove();
                        $(x).closest('tr.hanghoatr').remove();
                        $("#slsp").text($('#tablehanghoa > tbody > tr.hanghoatr').length);
                        var float = parseInt($("#vat").val()) / (100 + parseInt($("#vat").val()));
                        var count = 0;
                        $('#tablehanghoa > tbody  > tr.hanghoatr').each(function () {
                            count = count + parseInt($(this).find("td:eq(4)").text().replace(/[^\d.]/g, ''));
                        });
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