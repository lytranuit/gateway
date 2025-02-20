$(document).ready(function () {
    $(".selectpicker").selectpicker();
    $('.form-control1').datepicker({
        format: 'dd/mm/yyyy',
        todayHighlight: true,
        autoclose: true,
    });

    $("#btncreate").click(function () {
        //if ($('#tablecreate > tbody > tr').length > 0) {
        $.confirm({
            title: '<b>THÔNG BÁO</b>',
            content: 'Bạn có chắc chắn muốn tạo kế hoạch này ?',
            buttons: {
                confirm: {
                    text: 'Chắc chắn',
                    btnClass: 'btn-success',
                    keys: ['enter'],
                    action: function () {
                        var url = lang + '/cong-tac-trinh-duoc/Addkehoach';
                        var formData = new FormData();
                        formData.append("ngay", moment($("#ngaycreate").text(), 'DD/MM/YYYY').format('YYYY-MM-DD'));
                        $("#tablecreate > tbody >tr").each(function (index) {
                            formData.append('data1[' + index + '][id]', $(this).find('td').eq(1).attr("data-id"));
                            formData.append('data1[' + index + '][makh]', $(this).find('td').eq(1).attr("data-makh"));
                            formData.append('data1[' + index + '][tenkh]', $(this).find('td').eq(1).attr("data-tenkh"));
                            formData.append('data1[' + index + '][ngay]', moment($("#ngaycreate").text(), 'DD/MM/YYYY').format('YYYY-MM-DD'));
                            formData.append('data1[' + index + '][checkin]', false);
                            formData.append('data1[' + index + '][khoa]', false);
                        });
                        $.ajax({
                            url: url,
                            headers: { '__RequestVerificationToken': $("input[name='__RequestVerificationToken']").val() },
                            type: "POST",
                            datatype: 'json',
                            contentType: "application/json",
                            data: formData,
                            contentType: false,
                            processData: false,
                            success: function (data) {
                                $.confirm({
                                    title: '<b>THÔNG BÁO</b>',
                                    content: 'Đã tạo thành công kế hoạch ngày <b>' + data + '</b>.',
                                    buttons: {
                                        confirm: {
                                            text: 'Tải lại trang',
                                            btnClass: 'btn-primary',
                                            keys: ['enter'],
                                            action: function () {
                                                window.location.reload();
                                            }
                                        },

                                    }
                                });
                            }
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
        //}
        //else {
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
        //    Command: toastr["warning"]("Bạn phải thêm ít nhất một khách hàng!", "Thông báo")
        //}
    });
    $("#btnluutatca").click(function () {
        //if ($('#tabletdv > tbody > tr').length == 0) {
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
        //    Command: toastr["warning"]("Bạn không có kế hoạch trong ngày này để lưu!", "Thông báo")
        //    return false;
        //}
        $.confirm({
            title: '<b>THÔNG BÁO</b>',
            content: 'Bạn có chắc chắn muốn lưu tất cả các kế hoạch/báo cáo trong bảng này ?',
            buttons: {
                confirm: {
                    text: 'Chắc chắn',
                    btnClass: 'btn-success',
                    keys: ['enter'],
                    action: function () {
                        var url = lang + '/cong-tac-trinh-duoc/Addkehoach';
                        var formData = new FormData();
                        formData.append("ngay", moment($("#ngay").text(), 'DD/MM/YYYY').format('YYYY-MM-DD'));
                        $('#tabletdv > tbody > tr.stt').each(function (index) {
                            var x = $(this);
                            if (x.find('input[type=checkbox]').is(":checked") == true) {
                                var ketqua = x.next('tr').find('select').val();
                                var ghichu = x.next('tr').find('.ghichu').val();
                                var ketqua_text = x.next('tr').find('.ketqua').val();
                                var khoa = true;
                            }
                            else if (x.find('input[type=checkbox]').is(":checked") == false && x.next('tr').find('input[type=text]').val() != "") {
                                var ketqua = null;
                                var ghichu = x.next('tr').find('.ghichu').val();
                                var ketqua_text = x.next('tr').find('.ketqua').val();
                                var khoa = true;
                            }
                            else {
                                var ketqua = null;
                                var ghichu = x.next('tr').find('.ghichu').val();
                                var ketqua_text = x.next('tr').find('.ketqua').val();
                                var khoa = false;
                            }

                            formData.append('data1[' + index + '][id]', x.find('td').eq(1).attr("data-id"));
                            formData.append('data1[' + index + '][makh]', x.find('td').eq(1).attr("data-makh"));
                            formData.append('data1[' + index + '][tenkh]', x.find('td').eq(1).attr("data-tenkh"));
                            formData.append('data1[' + index + '][ngay]', moment($("#ngay").text(), 'DD/MM/YYYY').format('YYYY-MM-DD'));
                            formData.append('data1[' + index + '][checkin]', x.find('.largerCheckbox').is(":checked"));
                            formData.append('data1[' + index + '][ketqua]', ketqua);
                            formData.append('data1[' + index + '][ketqua_text]', ketqua_text);
                            formData.append('data1[' + index + '][ghichu]', ghichu);
                            formData.append('data1[' + index + '][khoa]', khoa);
                            formData.append('data1[' + index + '][checkgps]', (x.find('button').hasClass('btn-success') == true) ? 1 : null);


                        });
                        $.ajax({
                            url: url,
                            headers: { '__RequestVerificationToken': $("input[name='__RequestVerificationToken']").val() },
                            type: "POST",
                            datatype: 'json',
                            contentType: "application/json",
                            data: formData,
                            contentType: false,
                            processData: false,
                            success: function (data) {
                                window.location.reload();
                            }
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
    });


    $("#add_row").click(function () {
        if ($("#khachhang option:selected").length == 0) {
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
            Command: toastr["error"]("Bạn chưa chọn khách hàng !", "Thông báo")
        }
        else {
            var data = $("#khachhang option:selected");
            $(data).each(function () {
                var donvi = $(this).attr('value');
                var prevent = 0;
                $('#tablecreate > tbody > tr').each(function () {

                    if ($(this).find('td').eq(1).attr("data-makh") == donvi) {
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
                        Command: toastr["warning"]("Khách hàng thêm bị trùng với khách hàng số " + $(this).find('td').eq(0).text() + "!", "Thông báo")
                        prevent = 1;
                        return false;
                    }
                });
                if (prevent == 0) {
                    var i = $('#tablecreate > tbody > tr').last().find('td:eq(0)').text();

                    if (i == "") {
                        b = 1;
                    }
                    else {
                        b = parseInt(i) + 1;
                    }
                    $("#tablecreate").find("tbody").append(
                        '<tr>'// need to change closing tag to an opening `<tr>` tag.
                        + '<td class="text-center text-dark">' + b + '</td>'
                        + '<td data-makh="' + $(this).val() + '" data-tenkh="' + $(this).attr('tabindex') + '" class="left strong text-dark font-weight-normal">' + $(this).val() + " - " + $(this).attr('tabindex') + '</td>'
                        + '<td class="text-center"><button type="button" class="btn btn-sm p-1 btn-danger waves-effect transition-3d-hover btnxoa"><i class="fa fa-2x fa-times"></i></button></td>'
                        + '</tr>');
                }
                $("#khachhang").val('default');
                $("#khachhang").selectpicker("refresh");
                $(".selectpicker").selectpicker();
            });
        }
    });
    $("#add_row_them").click(function () {
        if ($("#khachhangthem option:selected").length == "") {
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
            Command: toastr["error"]("Bạn chưa chọn khách hàng !", "Thông báo")
        }
        else {
            var data = $("#khachhangthem option:selected");
            $(data).each(function () {
                var donvi = $(this).attr('value');
                var prevent = 0;
                $('#tabletdv > tbody > tr').each(function () {
                    if ($(this).find('td').eq(1).attr("data-makh") == donvi) {
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
                        Command: toastr["warning"]("Khách hàng thêm bị trùng với khách hàng số " + $(this).find('td').eq(0).text() + "!", "Thông báo")
                        prevent = 1;
                        return false;
                    }
                });
                if (prevent == 0) {
                    var i = $('#tabletdv > tbody > tr:not(:last-child)').last().find('td:eq(0)').text();

                    if (i == "") {
                        b = 1;
                    }
                    else {
                        b = parseInt(i) + 1;
                    }
                    $("#tabletdv").find("tbody").append(
                        '<tr class="stt">'// need to change closing tag to an opening `<tr>` tag.
                        + '<td rowspan="2" class="text-center text-dark">' + b + '</td>'
                        + '<td data-makh="' + $(this).val() + '" data-tenkh="' + $(this).attr('tabindex') + '" class="left strong text-dark font-weight-normal">' + $(this).val() + " - " + $(this).attr('tabindex') + '</td>'
                        + '<td class="text-center"><input class="largerCheckbox align-middle" type="checkbox"><button type="button" class="btn btn-primary btngps"><i class="fa fa-map-marker p-1"></i></button></td>'

                        //+ '<td class="text-center text-dark"><button type="button" class="btn btn-primary btnluu"><i class="fa fa-check-circle"></i></button></td>'
                        + '<td class="text-center text-dark"><button type="button" class="btn btn-danger btndelete"><i class="fa fa-times"></i></button></td>'
                        + '</tr><tr><td class="p-0" colspan="4"><input type="text" class="form-control ghichu" placeholder="Nội dung trao đổi"><input type="text" class="form-control ketqua mt-2" placeholder="Kết quả"><div class="input-group mt-2"><select class="custom-select hidden"><option selected value="1">Ghé thăm</option><option value="2">Có toa hàng</option></select><div class="input-group-append"><button type="button" title="Thêm đơn hàng" class="btn btn-outline-primary waves-effect m-0 btnadddonhang hidden"><i class="fa fa-plus"></i></button></div></div></td></tr>');
                }
                $("#khachhangthem").val('default');
                $("#khachhangthem").selectpicker("refresh");
                $(".selectpicker").selectpicker();
            });
        }
    });
    $("#tablecreate").on("click", ".btnxoa", function () {
        var x = this;
        $.confirm({
            title: '<b>THÔNG BÁO</b>',
            content: 'Bạn có chắc chắn muốn xóa khách hàng này ?',
            buttons: {
                confirm: {
                    text: 'Chắc chắn',
                    btnClass: 'btn-success',
                    keys: ['enter'],
                    action: function () {
                        $(x).closest('tr').remove();
                        var i = 1;
                        $("#tablecreate > tbody >tr").each(function () {
                            $(this).closest('tr').find('td:eq(0)').empty();
                            $(this).closest('tr').find('td:eq(0)').append(i);
                            i = i + 1;
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

    });
    $("#tabletdv").on("click", ".largerCheckbox", function () {
        var x = this;
        if ($(this).is(":checked") == true) {
            $(x).closest('tr').next('tr').find('select').removeClass("hidden");

            //$(x).closest('tr').next('tr').find('input[type=text]').addClass("hidden");
            if ($(x).closest('tr').next('tr').find('select').val() == 2) {
                $(x).closest('tr').next('tr').find('button').removeClass("hidden");
            }
        }
        else {
            $(x).closest('tr').next('tr').find('input[type=text]').removeClass("hidden");
            $(x).closest('tr').next('tr').find('select').addClass("hidden");
            $(x).closest('tr').next('tr').find('button.btnadddonhang').addClass("hidden");
        }
    });
    $("#tabletdv").on("change", "select", function () {
        var x = this;
        if ($(this).val() == 1) {

            $(x).closest('tr').find('button.btnadddonhang').addClass("hidden");

        }
        else {
            $(x).closest('tr').find('button.btnadddonhang').removeClass("hidden");
        }

    });
});