
$(document).ready(function () {
    $('.selectpicker').selectpicker();
    $('.form-control1').datepicker({
        format: 'dd/mm/yyyy',
        todayHighlight: true,
        autoclose: true,
    })
    $("#khachhang").change(function () {
        $("#nhaphanphoi").val($("#khachhang option:selected").data('macn'));
        try {
            $("#hanmuc").val(parseInt($("#khachhang option:selected").attr('data-hanmuc')).format());
        }
        catch (err) {
            $("#hanmuc").val($("#khachhang option:selected").attr('data-hanmuc'));
        }
        $.ajax({
            url: lang + '/crm/GETCONGNO',
            type: "POST",
            datatype: 'json',
            contentType: "application/json",
            data: '{makh: ' + JSON.stringify($("#khachhang").val()) + '}',
            success: function (data) {
                try {
                    $("#tienno").val(parseInt(data.tienno[0].tien).format());
                }
                catch (ex) {
                    $("#tienno").val("N/A");
                }
                try {
                    var count = 0;
                    $("#tabletiennoquahan").empty();
                    for (var i = 0; i < data.tienquahan.length; i++) {
                        count = count + parseInt(data.tienquahan[i].tien);
                        var milli1 = data.tienquahan[i].ngay.replace(/\/Date\((-?\d+)\)\//, '$1');
                        var d1 = new Date(parseInt(milli1));
                        var dformat1 = ("00" + d1.getDate()).slice(-2) + "/" + ("00" + (d1.getMonth() + 1)).slice(-2) + "/" + d1.getFullYear();
                        $("#tabletiennoquahan").append("<tr><td class='text-dark'>" + data.tienquahan[i].sct + "</td><td class='text-dark'>" + dformat1 + "</td><td class='text-dark text-right'>" + parseInt(data.tienquahan[i].tien).format() + "</td></tr>");
                    }
                    $("#tiennoquahan").val(parseInt(count).format());
                }
                catch (ex) {
                    $("#tiennoquahan").val("N/A");
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
                Command: toastr["warning"]("Không kết nối được dữ liệu công nợ", "Thông báo")
            },
            timeout: 5000,
        });

        if ($("#khuyenmai option:selected").attr("data-bbtt") == "1") {
            $.ajax({
                url: lang + '/crm/GETCKBBTT',
                type: "POST",
                datatype: 'json',
                contentType: "application/json",
                data: '{makh: ' + JSON.stringify($("#khachhang").val()) + ', mactkm: ' + JSON.stringify($("#khuyenmai").val()) + '}',
                success: function (data) {
                    $("#tilechietkhau").val(data);
                    $(".ck").val(data);
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
                    Command: toastr["warning"]("Không kết nối được dữ liệu tỉ lệ chiết khấu", "Thông báo")
                },
                timeout: 5000,
            });
        }
        else if (typeof $("#khuyenmai option:selected").attr("data-ck") != "undefined" && $("#khuyenmai option:selected").attr("data-ck") != "") {
            $("#tilechietkhau").val($("#khuyenmai option:selected").attr("data-ck"));

            $(".ck").val($("#khuyenmai option:selected").attr("data-ck"));
        }


        if ($("#khachhang option:selected").attr('data-matdv') == "") {
            $("#divmatdv").removeClass("hidden");
        }
        else {
            $("#divmatdv").addClass("hidden");
        }
    });
    $("#btnluu").click(function () {
        var prevent = 0;
        if (typeof $("#khuyenmai option:selected").attr("data-mahh") != "undefined") {
            if ($("#khuyenmai option:selected").attr("data-mahh") != "") {
                var mahhctkm = $("#khuyenmai option:selected").attr("data-mahh").split(",");
                var khongthuoc = []
                $('#tablehanghoa > tbody > tr').each(function () {
                    if (!mahhctkm.includes($(this).closest('tr').find('td:eq(1)').attr("data-mahh"))) {
                        khongthuoc.push($(this).closest('tr').find('td:eq(1)').attr("data-mahh"));
                    }
                });
                if (khongthuoc.length != 0) {
                    $.confirm({
                        title: '<b>CẢNH BÁO</b>',
                        content: 'Sản phẩm <b class="text-danger">' + khongthuoc.toString() + '</b> không nằm trong danh mục sản phẩm của CTKM <b class="text-danger">' + $("#khuyenmai").val() + '',
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
                    prevent = 1;
                    return false;
                }
            }
        }
        if (typeof $("#cthotro option:selected").attr("data-mahh") != "undefined") {
            if ($("#cthotro option:selected").attr("data-mahh") != "") {
                var mahhctht = $("#cthotro option:selected").attr("data-mahh").split(",");
                var khongthuocht = []
                $('#tablehanghoa > tbody > tr').each(function () {
                    if (!mahhctht.includes($(this).closest('tr').find('td:eq(1)').attr("data-mahh"))) {
                        khongthuocht.push($(this).closest('tr').find('td:eq(1)').attr("data-mahh"));
                    }
                });
                if (khongthuocht.length != 0) {
                    $.confirm({
                        title: '<b>CẢNH BÁO</b>',
                        content: 'Sản phẩm <b class="text-danger">' + khongthuocht.toString() + '</b> không nằm trong danh mục sản phẩm của CT hỗ trợ <b class="text-danger">' + $("#cthotro").val() + '',
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
                    prevent = 1;
                    return false;
                }
            }
        }
        if (typeof $("#cthotro option:selected").attr("data-mactkm") != "undefined") {
            if ($("#cthotro option:selected").attr("data-mactkm") != "") {
                var mactkmctht = $("#cthotro option:selected").attr("data-mactkm").split(",");
                if (!mactkmctht.includes($("#khuyenmai").val())) {
                    $.confirm({
                        title: '<b>CẢNH BÁO</b>',
                        content: 'Chương trình hỗ trợ <b class="text-danger">' + $("#cthotro").val() + '</b> không hỗ trợ cho CTKM <b class="text-danger">' + $("#khuyenmai").val() + '</b>. Vui lòng kiểm tra lại',
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
                    prevent = 1;
                    return false;
                }
            }
        }
        $('#tablehanghoa > tbody > tr').each(function () {
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
                Command: toastr["warning"]("Xin điền đẩy đủ số lượng cho sản phẩm thứ " + $(this).find('td:eq(0)').text() + " hoặc xóa sản phẩm", "Thông báo")
                prevent = 1;
                return false;
            }
        });
        if (typeof $("#khuyenmai option:selected").attr("data-tichdiem") != "undefined") {
            if ($("#khuyenmai option:selected").attr("data-tichdiem") != "") {
                if (parseInt($("#tongdiemtichluy").text()) < parseInt($("#khuyenmai option:selected").attr("data-tichdiem"))) {
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
                    Command: toastr["warning"]("Tổng điểm tích lũy không đủ " + $("#khuyenmai option:selected").attr("data-tichdiem") + " điểm để tạo đơn hàng vui lòng kiểm tra lại.", "Thông báo")
                    prevent = 1;
                    return false;
                }
            }
        }
        if (typeof $("#cthotro option:selected").attr("data-tichdiem") != "undefined") {
            if ($("#cthotro option:selected").attr("data-tichdiem") != "") {
                if (parseInt($("#tongdiemtichluy").text()) < parseInt($("#cthotro option:selected").attr("data-tichdiem"))) {
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
                    Command: toastr["warning"]("Tổng điểm tích lũy không đủ " + $("#cthotro option:selected").attr("data-tichdiem") + " điểm để tạo đơn hàng vui lòng kiểm tra lại.", "Thông báo")
                    prevent = 1;
                    return false;
                }
            }
        }
        var tpcn = []
        var ksdb = []
        var hh40 = []
        var hh99 = []
        $('#tablehanghoa > tbody > tr').each(function () {
            if ($(this).closest('tr').find('td:eq(1)').attr("data-kiemsoat") == 1) {
                ksdb.push($(this).closest('tr').find('td:eq(1)').attr("data-mahh"));
            }
            else if ($(this).closest('tr').find('td:eq(1)').attr("data-kiemsoat") == 2) {
                tpcn.push($(this).closest('tr').find('td:eq(1)').attr("data-mahh"));
            }
            else if ($(this).closest('tr').find('td:eq(1)').attr("data-kiemsoat") == 40) {
                hh40.push($(this).closest('tr').find('td:eq(1)').attr("data-mahh"));
            }
            else if ($(this).closest('tr').find('td:eq(1)').attr("data-kiemsoat") == 99) {
                hh99.push($(this).closest('tr').find('td:eq(1)').attr("data-mahh"));
            }
        });
        if ((tpcn.length != 0 && $('#tablehanghoa > tbody > tr').length > tpcn.length) || (ksdb.length != 0 && $('#tablehanghoa > tbody > tr').length > ksdb.length) || (hh40.length != 0 && $('#tablehanghoa > tbody > tr').length > hh40.length) || (hh99.length != 0 && $('#tablehanghoa > tbody > tr').length > hh99.length)) {
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
            Command: toastr["warning"]("Bạn vui lòng tách đơn hàng có sản phẩm <b>Kiểm soát đặc biệt - Thực phẩm chức năng hoặc Nhóm hàng 40,99</b> ra đơn hàng riêng", "Thông báo")
            prevent = 1;
            return false;
        }

        if (tpcn.length == 0 && ksdb.length == 0) {
            if (typeof $("#khuyenmai option:selected").attr("data-hanmuc") != "undefined") {
                if ($("#khuyenmai option:selected").attr("data-hanmuc") != "") {
                    if (parseInt($("#thanhtien").text().replace(/[^\d.]/g, '')) < parseInt($("#khuyenmai option:selected").attr("data-hanmuc"))) {
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
                        Command: toastr["warning"]("Tổng tiền đơn hàng phải từ " + parseInt($("#khuyenmai option:selected").attr("data-hanmuc").replace(/[^\d.]/g, '')).format() + " trở lên.", "Thông báo")
                        prevent = 1;
                        return false;
                    }
                }
            }
        }
        if (prevent == 0) {

            if ($("#khachhang").val() == "" || $("#tablehanghoa > tbody > tr").length == 0) {
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
                var url = lang + '/crm/AddHoaDon';
                var data1 = [];
                $("#tablehanghoa > tbody >tr").each(function () {
                    data1.push({
                        "NGAYGIAO": $("#editngaygiao").val()
                        , "STT": $(this).closest('tr').find('td:eq(0)').text()
                        , "DONVI": $("#khachhang option:selected").attr('tabindex')
                        , "MACH": $("#khachhang option:selected").data('macn')
                        , "KHACHHANG": $("#khachhang").val()
                        , "MACTKM": $("#khuyenmai").val()
                        , "TENCTKM": $("#khuyenmai option:selected").attr('tabindex')
                        , "MACTHT": $("#cthotro").val()
                        , "MAHH": $(this).find('td:eq(1)').attr("data-mahh")
                        , "MATDV": ($("#khachhang option:selected").attr('data-matdv') == "") ? $("#matdv").val() : $("#khachhang option:selected").attr('data-matdv')
                        , "TENHH": $(this).find('td:eq(1)').attr("data-tenhh")
                        , "DVT": $(this).find('td:eq(1)').attr("data-dvt")
                        , "SOLUONG": Number($(this).find('.sl3').val().toString().replace(/[^\d.]/g, '').replace(".00", ""))
                        , "SOLUONG2": Number($(this).find('.sl2').val().toString().replace(/[^\d.]/g, '').replace(".00", ""))
                        , "SOLUONG3": Number($(this).find('.sl1').val().toString().replace(/[^\d.]/g, '').replace(".00", ""))
                        , "GIABAN_VAT": Number($(this).find('.giaban_vat').val().replace(/[^\d.]/g, '').replace(".00", ""))
                        , "VAT": $("#vat").val()
                        , "GHICHU": $("#ghichu").val()
                        , "ck": Number($(this).find('.ck').val().replace(/[^\d.]/g, '').replace(".00", ""))
                    });

                });
                $.ajax({
                    url: url,
                    type: "POST",
                    datatype: 'json',
                    contentType: "application/json",
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
                                            window.location.href = "danh-sach-don-dat-hang";
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
        }
    });
    $("#add_row_them").click(function () {
        $("#themsanpham option:selected").each(function () {
            //if ($('#tablehanghoa > tbody > tr').length == 10) {
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
            var giaban = parseInt($(this).attr("data-giaban").replace(/[^\d.]/g, '')).format();
            if (typeof $("#khuyenmai option:selected").attr("data-mahh") != "undefined") {
                if ($("#khuyenmai option:selected").attr("data-mahh") != "" && $("#khuyenmai option:selected").attr("data-gia") != "") {
                    var mahhctkm = $("#khuyenmai option:selected").attr("data-mahh").split(",");
                    var gia = $("#khuyenmai option:selected").attr("data-gia").split(",");
                    var find_mahh = mahhctkm.findIndex((item) => {
                        return item == mahh;
                    });
                    if (find_mahh != -1) {
                        giaban = parseInt(gia[find_mahh].replace(/[^\d.]/g, '')).format();
                    }
                }
            }
            if (trung == 0) {
                var i = $('#tablehanghoa > tbody > tr').length;
                $('#tablehanghoa > tbody').append('<tr>'
                    + '<td class="text-center text-dark">' + (i + 1) + '</td>'
                    + '<td class="left strong hanghoa text-dark" data-dvt="' + $(this).attr("data-dvt") + '" data-kiemsoat="' + $(this).attr("data-kiemsoat") + '" data-tenhh="' + $(this).attr("data-tenhh") + '" data-mahh="' + $(this).val() + '">' + $(this).val() + " - " + $(this).attr("data-tenhh") + '</td>'
                    + '<td class="text-right paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl1") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl1"></td>'
                    + '<td class="text-right paddingleft2 paddingright2"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl2") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl2"></td>'

                    + '<td class="text-right paddingleft2 paddingright2 text-dark"><input autocomplete="off" onkeypress="validate(event)" data-sl="' + $(this).attr("data-sl3") + '" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right sl sl3"></td>'
                    + '<td class="text-right paddingleft2 paddingright2 text-dark">'
                    + '<select class="form-control form-control-sm giaban_vat">'
                    + '<option value="' + giaban + '">'
                    + giaban
                    + '</option>'
                    + '<option value="0">0'
                    + '</option>'
                    + '</select>'
                    + '</td>'
                    + '<td class="text-right paddingleft2 paddingright2 text-dark thanhtien">0.00</td>'
                    + '<td class="text-right paddingleft2 paddingright2 text-dark"><input autocomplete="off" name="number" type="text" class="form-control form-control-sm floatright font-weight-normal text-right ck" value="' + $("#tilechietkhau").val() + '"></td>'
                    + '<td class="text-right paddingleft2 paddingright2 text-dark diemtichluy">0</td>'
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
        if (typeof $("#khuyenmai option:selected").attr("data-mahh") != "undefined") {
            if ($("#khuyenmai option:selected").attr("data-mahh") != "") {
                var mahhctkm = $("#khuyenmai option:selected").attr("data-mahh").split(",");
                var khongthuoc = []
                $('#tablehanghoa > tbody > tr').each(function () {
                    if (!mahhctkm.includes($(this).closest('tr').find('td:eq(1)').attr("data-mahh"))) {
                        khongthuoc.push($(this).closest('tr').find('td:eq(1)').attr("data-mahh"));
                    }
                });
                if (khongthuoc.length != 0) {
                    $.confirm({
                        title: '<b>CẢNH BÁO</b>',
                        content: 'Sản phẩm <b class="text-danger">' + khongthuoc.toString() + '</b> không nằm trong danh mục sản phẩm của CTKM <b class="text-danger">' + $("#khuyenmai").val() + '',
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
                    prevent = 1;
                    return false;
                }
            }
        }
        if (typeof $("#cthotro option:selected").attr("data-mahh") != "undefined") {
            if ($("#cthotro option:selected").attr("data-mahh") != "") {
                var mahhctht = $("#cthotro option:selected").attr("data-mahh").split(",");
                var khongthuocht = []
                $('#tablehanghoa > tbody > tr').each(function () {
                    if (!mahhctht.includes($(this).closest('tr').find('td:eq(1)').attr("data-mahh"))) {
                        khongthuocht.push($(this).closest('tr').find('td:eq(1)').attr("data-mahh"));
                    }
                });
                if (khongthuocht.length != 0) {
                    $.confirm({
                        title: '<b>CẢNH BÁO</b>',
                        content: 'Sản phẩm <b class="text-danger">' + khongthuocht.toString() + '</b> không nằm trong danh mục sản phẩm của CT hỗ trợ <b class="text-danger">' + $("#cthotro").val() + '',
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
                    prevent = 1;
                    return false;
                }
            }
        }
        if (typeof $("#cthotro option:selected").attr("data-mactkm") != "undefined") {
            if ($("#cthotro option:selected").attr("data-mactkm") != "") {
                var mactkmctht = $("#cthotro option:selected").attr("data-mactkm").split(",");
                if (!mactkmctht.includes($("#khuyenmai").val())) {
                    $.confirm({
                        title: '<b>CẢNH BÁO</b>',
                        content: 'Chương trình hỗ trợ <b class="text-danger">' + $("#cthotro").val() + '</b> không hỗ trợ cho CTKM <b class="text-danger">' + $("#khuyenmai").val() + '</b>. Vui lòng kiểm tra lại',
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
                    prevent = 1;
                    return false;
                }
            }
        }
        $('#tablehanghoa > tbody > tr').each(function () {
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
                Command: toastr["warning"]("Xin điền đẩy đủ số lượng cho sản phẩm thứ " + $(this).find('td:eq(0)').text() + " hoặc xóa sản phẩm", "Thông báo")
                prevent = 1;
                return false;
            }
        });
        if (typeof $("#khuyenmai option:selected").attr("data-tichdiem") != "undefined") {
            if ($("#khuyenmai option:selected").attr("data-tichdiem") != "") {
                if (parseInt($("#tongdiemtichluy").text()) < parseInt($("#khuyenmai option:selected").attr("data-tichdiem"))) {
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
                    Command: toastr["warning"]("Tổng điểm tích lũy không đủ " + $("#khuyenmai option:selected").attr("data-tichdiem") + " điểm để tạo đơn hàng vui lòng kiểm tra lại.", "Thông báo")
                    prevent = 1;
                    return false;
                }
            }
        }
        if (typeof $("#cthotro option:selected").attr("data-tichdiem") != "undefined") {
            if ($("#cthotro option:selected").attr("data-tichdiem") != "") {
                if (parseInt($("#tongdiemtichluy").text()) < parseInt($("#cthotro option:selected").attr("data-tichdiem"))) {
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
                    Command: toastr["warning"]("Tổng điểm tích lũy không đủ " + $("#cthotro option:selected").attr("data-tichdiem") + " điểm để tạo đơn hàng vui lòng kiểm tra lại.", "Thông báo")
                    prevent = 1;
                    return false;
                }
            }
        }
        var tpcn = []
        var ksdb = []
        var hh40 = []
        var hh99 = []
        $('#tablehanghoa > tbody > tr').each(function () {
            if ($(this).closest('tr').find('td:eq(1)').attr("data-kiemsoat") == 1) {
                ksdb.push($(this).closest('tr').find('td:eq(1)').attr("data-mahh"));
            }
            else if ($(this).closest('tr').find('td:eq(1)').attr("data-kiemsoat") == 2) {
                tpcn.push($(this).closest('tr').find('td:eq(1)').attr("data-mahh"));
            }
            else if ($(this).closest('tr').find('td:eq(1)').attr("data-kiemsoat") == 40) {
                hh40.push($(this).closest('tr').find('td:eq(1)').attr("data-mahh"));
            }
            else if ($(this).closest('tr').find('td:eq(1)').attr("data-kiemsoat") == 99) {
                hh99.push($(this).closest('tr').find('td:eq(1)').attr("data-mahh"));
            }
        });
        if ((tpcn.length != 0 && $('#tablehanghoa > tbody > tr').length > tpcn.length) || (ksdb.length != 0 && $('#tablehanghoa > tbody > tr').length > ksdb.length) || (hh40.length != 0 && $('#tablehanghoa > tbody > tr').length > hh40.length) || (hh99.length != 0 && $('#tablehanghoa > tbody > tr').length > hh99.length)) {
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
            Command: toastr["warning"]("Bạn vui lòng tách đơn hàng có sản phẩm <b>Kiểm soát đặc biệt - Thực phẩm chức năng hoặc Nhóm hàng 40,99</b> ra đơn hàng riêng", "Thông báo")
            prevent = 1;
            return false;
        }
        if (tpcn.length == 0 && ksdb.length == 0) {
            if (typeof $("#khuyenmai option:selected").attr("data-hanmuc") != "undefined") {
                if ($("#khuyenmai option:selected").attr("data-hanmuc") != "") {
                    if (parseInt($("#thanhtien").text().replace(/[^\d.]/g, '')) < parseInt($("#khuyenmai option:selected").attr("data-hanmuc"))) {
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
                        Command: toastr["warning"]("Tổng tiền đơn hàng phải từ " + parseInt($("#khuyenmai option:selected").attr("data-hanmuc").replace(/[^\d.]/g, '')).format() + " trở lên.", "Thông báo")
                        prevent = 1;
                        return false;
                    }
                }
            }
        }
        if (prevent == 0) {
            if ($("#khachhang").val() == "" || $("#tablehanghoa > tbody > tr").length == 0) {
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
                var url = lang + '/crm/AddHoaDon';
                var data1 = [];
                $("#tablehanghoa > tbody >tr").each(function () {
                    data1.push({
                        "NGAYGIAO": $("#editngaygiao").val()
                        , "STT": $(this).closest('tr').find('td:eq(0)').text()
                        , "DONVI": $("#khachhang option:selected").attr('tabindex')
                        , "MACH": $("#khachhang option:selected").data('macn')
                        , "KHACHHANG": $("#khachhang").val()
                        , "MACTKM": $("#khuyenmai").val()
                        , "TENCTKM": $("#khuyenmai option:selected").attr('tabindex')
                        , "MACTHT": $("#cthotro").val()
                        , "MAHH": $(this).find('td:eq(1)').attr("data-mahh")
                        , "MATDV": ($("#khachhang option:selected").attr('data-matdv') == "") ? $("#matdv").val() : $("#khachhang option:selected").attr('data-matdv')
                        , "TENHH": $(this).find('td:eq(1)').attr("data-tenhh")
                        , "DVT": $(this).find('td:eq(1)').attr("data-dvt")
                        , "SOLUONG": Number($(this).find('.sl3').val().toString().replace(/[^\d.]/g, '').replace(".00", ""))
                        , "SOLUONG2": Number($(this).find('.sl2').val().toString().replace(/[^\d.]/g, '').replace(".00", ""))
                        , "SOLUONG3": Number($(this).find('.sl1').val().toString().replace(/[^\d.]/g, '').replace(".00", ""))
                        , "GIABAN_VAT": Number($(this).find('.giaban_vat').val().replace(/[^\d.]/g, '').replace(".00", ""))
                        , "VAT": $("#vat").val()
                        , "GHICHU": $("#ghichu").val()
                        , "ck": Number($(this).find('.ck').val().replace(/[^\d.]/g, '').replace(".00", ""))
                    });


                });

                $.ajax({
                    url: url,
                    type: "POST",
                    datatype: 'json',
                    contentType: "application/json",
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
                                    confirm1: {
                                        text: 'Giữ nguyên sản phẩm và tiếp tục',
                                        btnClass: 'btn-primary',

                                        action: function () {
                                            $(".sl1,.sl2").val("");
                                            $(".sl3").val("0.00");
                                            $("#tab_logic tr").find('.thanhtien').text("0.00");
                                            $("#tab_logic tr").find('.diemtichluy').text("0");
                                            $("#tienvat").text("0.00");
                                            $("#thanhtien").text("0.00");
                                            $("#tongtien").text("0.00");
                                            $("#tongdiemtichluy").text("0");
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
        }
    });
    $("#vat").change(function () {
        check_gia();
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
            x.find(".sl3").val(soluong.format());
            x.find(".thanhtien").text((parseInt(x.find(".giaban_vat").val().toString().replace(/[^\d.]/g, '')) * parseInt(x.find(".sl3").val().toString().replace(/[^\d.]/g, ''))).format());
            if (typeof $("#khuyenmai option:selected").attr("data-tichdiem") != "undefined") {
                if ($("#khuyenmai option:selected").attr("data-tichdiem") != "") {
                    $.ajax({
                        url: lang + '/crm/GetDiemtichluy',
                        type: "POST",
                        datatype: 'json',
                        contentType: "application/json",
                        data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").val().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#khuyenmai").val()) + '}',
                        success: function (data) {
                            x.find(".diemtichluy").text(data);
                            var tichdiem = 0;
                            $('#tablehanghoa > tbody > tr').each(function () {
                                tichdiem = tichdiem + parseInt($(this).find(".diemtichluy").text());
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
                        data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").val().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#cthotro").val()) + '}',
                        success: function (data) {
                            x.find(".diemtichluy").text(data);
                            var tichdiem = 0;
                            $('#tablehanghoa > tbody > tr').each(function () {
                                tichdiem = tichdiem + parseInt($(this).find(".diemtichluy").text());
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


            check_gia();
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
            x.find(".sl3").val(soluong.format());
            x.find(".thanhtien").text((parseInt(x.find(".giaban_vat").val().toString().replace(/[^\d.]/g, '')) * parseInt(x.find(".sl3").val().toString().replace(/[^\d.]/g, ''))).format());
            if (typeof $("#khuyenmai option:selected").attr("data-tichdiem") != "undefined") {
                if ($("#khuyenmai option:selected").attr("data-tichdiem") != "") {
                    $.ajax({
                        url: lang + '/crm/GetDiemtichluy',
                        type: "POST",
                        datatype: 'json',
                        contentType: "application/json",
                        data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").val().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#khuyenmai").val()) + '}',
                        success: function (data) {
                            x.find(".diemtichluy").text(data);
                            var tichdiem = 0;
                            $('#tablehanghoa > tbody > tr').each(function () {
                                tichdiem = tichdiem + parseInt($(this).find(".diemtichluy").text());
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
                        data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").val().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#cthotro").val()) + '}',
                        success: function (data) {
                            x.find(".diemtichluy").text(data);
                            var tichdiem = 0;
                            $('#tablehanghoa > tbody > tr').each(function () {
                                tichdiem = tichdiem + parseInt($(this).find(".diemtichluy").text());
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

            check_gia();
        }
    });
    $("#tablehanghoa").on("change", ".giaban_vat,.ck,.sl3", function () {
        var x = $(this).closest('tr');
        x.find(".thanhtien").text((parseInt(x.find(".giaban_vat").val().toString().replace(/[^\d.]/g, '')) * parseInt(x.find(".sl3").val().toString().replace(/[^\d.]/g, ''))).format());

        check_gia();
    });
    $("#btnhuy").click(function () {
        $.confirm({
            title: '<b>THÔNG BÁO</b>',
            content: 'Bạn có chắc chắn muốn tạo đơn hàng này ?',
            buttons: {
                confirm: {
                    text: 'Chắc chắn',
                    btnClass: 'btn-success',
                    keys: ['enter'],
                    action: function () {
                        window.location.href = "tao-moi-don-dat-hang";
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
    $("#cthotro").change(function () {
        if (typeof $("#cthotro option:selected").attr("data-tichdiem") != "undefined") {
            if ($("#cthotro option:selected").attr("data-tichdiem") != "") {
                var diem = 0;
                $('#tablehanghoa > tbody  > tr').each(function () {
                    var x = $(this);
                    if (x.find(".sl3").text() != "") {

                        $.ajax({
                            url: lang + '/crm/GetDiemtichluy',
                            type: "POST",
                            datatype: 'json',
                            contentType: "application/json",
                            data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").val().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#cthotro").val()) + '}',
                            success: function (data) {
                                x.find(".diemtichluy").text(data);
                                diem = diem + parseInt(data);
                                $("#tongdiemtichluy").text(diem);
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
                    $(this).find(".diemtichluy").text("0");
                    $("#tongdiemtichluy").text("0");
                });
            }
        }
        else {
            $('#tablehanghoa > tbody  > tr').each(function () {
                $(this).find(".diemtichluy").text("0");
                $("#tongdiemtichluy").text("0");
            });
        }
    });
    $("#khuyenmai").change(function () {
        //if ($("#khuyenmai option:selected").attr("data-bbtt") == "1") {
        //    $.ajax({
        //        url: lang + '/crm/GETCKBBTT',
        //        type: "POST",
        //        datatype: 'json',
        //        contentType: "application/json",
        //        data: '{makh: ' + JSON.stringify($("#khachhang").val()) + ', mactkm: ' + JSON.stringify($("#khuyenmai").val()) + '}',
        //        success: function (data) {
        //            $("#tilechietkhau").val(data);
        //            $(".ck").val(data);
        //        },
        //        error: function (request, status, error) {
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
        //            Command: toastr["warning"]("Không kết nối được dữ liệu tỉ lệ chiết khấu", "Thông báo")
        //        },
        //        timeout: 5000,
        //    });
        //}
        //else if (typeof $("#khuyenmai option:selected").attr("data-ck") != "undefined" && $("#khuyenmai option:selected").attr("data-ck") != "") {
        //    $("#tilechietkhau").val($("#khuyenmai option:selected").attr("data-ck"));
        //    $(".ck").val($("#khuyenmai option:selected").attr("data-ck"));
        //}

        //if (typeof $("#khuyenmai option:selected").attr("data-tichdiem") != "undefined") {
        //    if ($("#khuyenmai option:selected").attr("data-tichdiem") != "") {
        //        var diem = 0;
        //        $('#tablehanghoa > tbody  > tr').each(function () {
        //            var x = $(this);
        //            if (x.find(".sl3").text() != "") {

        //                $.ajax({
        //                    url: lang + '/crm/GetDiemtichluy',
        //                    type: "POST",
        //                    datatype: 'json',
        //                    contentType: "application/json",
        //                    data: '{mahh: ' + JSON.stringify(x.find("td:eq(1)").attr("data-mahh")) + ', hop: ' + JSON.stringify(x.find(".sl3").val().replace(/[^\d.]/g, '') * x.find(".sl2").attr("data-sl") / x.find(".sl3").attr("data-sl")) + ', mactkm: ' + JSON.stringify($("#khuyenmai").val()) + '}',
        //                    success: function (data) {
        //                        x.find(".diemtichluy").text(data);
        //                        diem = diem + parseInt(data);
        //                        $("#tongdiemtichluy").text(diem);
        //                    },
        //                    error: function (request, status, error) {
        //                        toastr.options = {
        //                            "closeButton": false,
        //                            "debug": false,
        //                            "newestOnTop": true,
        //                            "progressBar": true,
        //                            "positionClass": "toast-top-right",
        //                            "preventDuplicates": false,
        //                            "onclick": null,
        //                            "showDuration": "300",
        //                            "hideDuration": "1000",
        //                            "timeOut": "5000",
        //                            "extendedTimeOut": "1000",
        //                            "showEasing": "swing",
        //                            "hideEasing": "linear",
        //                            "showMethod": "fadeIn",
        //                            "hideMethod": "fadeOut"
        //                        }
        //                        Command: toastr["warning"]("Không kết nối được dữ liệu điểm tích lũy", "Thông báo")
        //                    },
        //                    timeout: 5000,
        //                });
        //            }
        //        });
        //    }
        //    else {
        //        $('#tablehanghoa > tbody  > tr').each(function () {
        //            $(this).find(".diemtichluy").text("0");
        //            $("#tongdiemtichluy").text("0");
        //        });
        //    }
        //}
        //else if (typeof $("#khuyenmai option:selected").attr("data-hanmuc") != "undefined") {
        //    if ($("#khuyenmai option:selected").attr("data-hanmuc") != "") {
        //        $("#tongdiemtichluy").text(parseInt(parseInt($("#thanhtien").text().replace(/[^\d.]/g, '')) / parseInt($("#khuyenmai option:selected").attr("data-hanmuc"))));
        //    }
        //}
        //else {
        //    $('#tablehanghoa > tbody  > tr').each(function () {
        //        $(this).find(".diemtichluy").text("0");
        //        $("#tongdiemtichluy").text("0");
        //    });
        //}
        $(".btnxoahh").each(function () {
            xoahh(this);
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
                        xoahh(x);
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
const check_gia = () => {
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
        console.log($(this).find(".ck"));
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
    if (typeof $("#khuyenmai option:selected").attr("data-hanmuc") != "undefined") {
        if ($("#khuyenmai option:selected").attr("data-hanmuc") != "") {
            $("#tongdiemtichluy").text(parseInt(parseInt($("#thanhtien").text().replace(/[^\d.]/g, '')) / parseInt($("#khuyenmai option:selected").attr("data-hanmuc"))));
        }
    }
}

const xoahh = (x) => {
    $(x).closest('tr').remove();
    var i = 1;
    $("#tablehanghoa > tbody >tr").each(function () {
        $(this).closest('tr').find('td:eq(0)').text(i);
        i = i + 1;
    });
    var float = parseInt($("#vat").val()) / (100 + parseInt($("#vat").val()));
    var count = 0;
    var diem = 0;
    $('#tablehanghoa > tbody  > tr').each(function () {
        var MAHH = $("option:selected", this).val();
        if (MAHH == "") {
            return false;
        }
        diem = diem + parseInt($(this).find(".diemtichluy").text());
        count = count + parseInt($(this).find(".thanhtien").text().replace(/[^\d.]/g, ''));
    });
    $("#tongdiemtichluy").text(diem);
    $("#tongtien").text(count.format());
    $("#tienvat").text(Math.floor(parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) * float).format());
    $("#thanhtien").text((parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) - Math.floor(parseInt($("#tongtien").text().replace(/[^\d.]/g, '')) * float)).format());

    check_gia();
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