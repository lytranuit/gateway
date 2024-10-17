function myFunction() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("timkieminput");
    filter = input.value.toUpperCase();
    table = document.getElementById("SanPhamList");
    tr = table.getElementsByClassName("Checkboxlist5");
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
function myFunction1() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("timkiemkhinput1");
    filter = input.value.toUpperCase();
    table = document.getElementById("KhachHangList");
    tr = table.getElementsByClassName("Checkboxlist8");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("label")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                if (i > 199) {
                    tr[i].style.display = "none";
                }
                else {
                    tr[i].style.display = "";
                }
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
function myFunction5() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("timkieminput5");
    filter = input.value.toUpperCase();
    table = document.getElementById("KhuVucList");
    tr = table.getElementsByClassName("Checkboxlist6");
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
function myFunction2() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("timkiemkminput2");
    filter = input.value.toUpperCase();
    table = document.getElementById("KhuyenMaiList");
    tr = table.getElementsByClassName("Checkboxlist9");
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
function myFunction6() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("timkiemkminput6");
    filter = input.value.toUpperCase();
    table = document.getElementById("HotroList");
    tr = table.getElementsByClassName("Checkboxlist14");
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
function myFunction3() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("timkiemtdvinput");
    filter = input.value.toUpperCase();
    table = document.getElementById("TrinhDuocVienList");
    tr = table.getElementsByClassName("Checkboxlist10");
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
function myFunction4() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("timkiemhopdonginput");
    filter = input.value.toUpperCase();
    table = document.getElementById("HopDongList");
    tr = table.getElementsByClassName("Checkboxlist12");
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

function getBoLoc() {
    $.post(lang + '/he-thong/GetBoLocNPP', {},
        function (data) {
            $("#NhaphanphoiList").empty();
            if (data.NPP) {
                for (var i = 0; i < data.NPP.length; i++) {
                    $("#NhaphanphoiList").append('<div id="NPP' + data.NPP[i].macn.replace(".", "") + '" class="checkbox checkbox-primary Checkboxlist33"><input class="Checkboxlist33" value="' + data.NPP[i].macn + '" id="AA' + data.NPP[i].macn.replace(".", "") + '" type="checkbox" name="Checkboxlist33"><label for="AA' + data.NPP[i].macn.replace(".", "") + '">' + data.NPP[i].macn + " &bull; " + data.NPP[i].tencn + '</label></div>');
                }
            }
            $("#SanPhamList").empty();
            for (var i = 0; i < data.SP.length; i++) {
                $("#SanPhamList").append('<div id="A' + data.SP[i].MaHH.replace(".", "") + '" class="checkbox checkbox-primary Checkboxlist5"><input class="Checkboxlist5" value="' + data.SP[i].MaHH + '" id="AA' + data.SP[i].MaHH.replace(".", "") + '" type="checkbox" name="Checkboxlist5"><label for="AA' + data.SP[i].MaHH.replace(".", "") + '">' + data.SP[i].MaHH + " &bull; " + data.SP[i].TenHH + '</label></div>');
            }
            $("#LoaiHopDongList").empty();
            if (data.LOAIHD != null) {
                for (var i = 0; i < data.LOAIHD.length; i++) {
                    $("#LoaiHopDongList").append('<div id="A' + data.LOAIHD[i].loaihd + '" class="checkbox checkbox-primary Checkboxlist13"><input class="Checkboxlist13" value="' + data.LOAIHD[i].loaihd + '" id="AA' + data.LOAIHD[i].loaihd + '" type="checkbox" name="Checkboxlist13"><label for="AA' + data.LOAIHD[i].loaihd + '">' + data.LOAIHD[i].loaihd + '</label></div>');
                }
            }
            $("#KhuVucList").empty();
            for (var i = 0; i < data.KV.length; i++) {
                $("#KhuVucList").append('<div id="B' + data.KV[i].matinh + '" class="checkbox checkbox-primary Checkboxlist6"><input class="Checkboxlist6" value="' + data.KV[i].matinh + '" id="BB' + data.KV[i].matinh + '" type="checkbox" name="Checkboxlist6"><label for="BB' + data.KV[i].matinh + '">' + data.KV[i].matinh + " &bull; " + data.KV[i].tentinh + '</label></div>');
            }
            $("#KhuyenMaiList").empty();
            for (var i = 0; i < data.KM.length; i++) {
                $("#KhuyenMaiList").append('<div id="D' + data.KM[i].MAKM + '" class="checkbox checkbox-primary Checkboxlist9 ' + ((data.KM[i].hieuluc == 1) ? "text-primary" : "text-danger") + '"><input class="Checkboxlist9" value="' + data.KM[i].MAKM + '" id="DD' + data.KM[i].MAKM + '" type="checkbox" name="Checkboxlist9"><label for="DD' + data.KM[i].MAKM + '">' + data.KM[i].MAKM + " &bull; " + data.KM[i].TENKM + '</label></div>');
            }
            $("#TrinhDuocVienList").empty();
            for (var i = 0; i < data.TDV.length; i++) {
                $("#TrinhDuocVienList").append('<div id="E' + data.TDV[i].MATDV + '" class="checkbox checkbox-primary Checkboxlist10"><input class="Checkboxlist10" value="' + data.TDV[i].MATDV + '" id="EE' + data.TDV[i].MATDV + '" type="checkbox" name="Checkboxlist10"><label for="EE' + data.TDV[i].MATDV + '">' + data.TDV[i].MATDV + " &bull; " + data.TDV[i].TENTDV + '</label></div>');
            }
            $("#QuanhuyenList").empty();
            if (data.Quan != null) {
                for (var i = 0; i < data.Quan.length; i++) {
                    $("#QuanhuyenList").append('<div id="F' + data.Quan[i].maquan + '" class="checkbox checkbox-primary Checkboxlist11"><input class="Checkboxlist11" value="' + data.Quan[i].maquan + '" id="FF' + data.Quan[i].maquan + '" type="checkbox" name="Checkboxlist11"><label for="FF' + data.Quan[i].maquan + '">' + data.Quan[i].maquan + " &bull; " + data.Quan[i].tenquan + '</label></div>');
                }
            }
            $("#Nhomcol").empty();
            for (var i = 0; i < data.NHOM.length; i++) {
                $("#Nhomcol").append('<div class="checkbox checkbox-primary col-lg-6 col-sm-12 mt-1 mb-1 Checkboxlist4"><input class="Checkboxlist4" value="' + data.NHOM[i].MANHOM + '" id="NHOM1' + data.NHOM[i].MANHOM + '" type="checkbox" name="Checkboxlist4"><label for="NHOM1' + data.NHOM[i].MANHOM + '">' + data.NHOM[i].MANHOM + " - " + data.NHOM[i].TENNHOM + '</label></div>')
            }
        });
    $.post(lang + '/he-thong/PartialKhachHang', { ChiNhanhId: "ALL", phanloai: $("#Checkboxlist2").val() },
        function (data) {
            $("#KhachHangList").html(data);
        });
}
$(document).ready(function () {
    $(".poc").hide();
    getBoLoc();

    $("#id05").on("change", ".Checkboxlist5", function () {
        $("#sanphamcount").text($(".Checkboxlist5:checked").length);
    });
    $("#id08").on("change", ".Checkboxlist8", function () {
        $("#sanphamcountkh").text($(".Checkboxlist8:checked").length);
    });
    $("#Checkboxlist2").change(function () {
        var khuvuc = "";
        if ($("#khuvuc").is(":checked")) {

            khuvuc = $('.Checkboxlist6:checked').map(function () { return this.value; }).get().join(',');
        }
        else {
            khuvuc = "";
        }
        $.post(lang + '/he-thong/PartialKhachHang', { ChiNhanhId: $('#donvi').val(), phanloai: $("#Checkboxlist2").val(), khuvuc: khuvuc },
            function (data) {
                $("#KhachHangList").html(data);
            });
    });
    $("#Checkboxlist2").change(function () {
        var khuvuc = "";
        if ($("#khuvuc").is(":checked")) {
            khuvuc = $('.Checkboxlist6:checked').map(function () { return this.value; }).get().join(',');
        }
        else {
            khuvuc = "";
        }
        $.post(lang + '/he-thong/PartialKhachHang', { ChiNhanhId: $('#donvi').val(), phanloai: $("#Checkboxlist2").val(), khuvuc: khuvuc },
            function (data) {
                $("#KhachHangList").html(data);

            });
    });
    $("#id06").on("change", ".Checkboxlist6", function () {

        var khuvuc = "";
        if ($("#khuvuc").is(":checked")) {
            khuvuc = $('.Checkboxlist6:checked').map(function () { return this.value; }).get().join(',');
        }
        else {
            khuvuc = "";
        }
        $.post(lang + '/he-thong/PartialKhachHang', { ChiNhanhId: $('#donvi').val(), phanloai: $("#Checkboxlist2").val(), khuvuc: khuvuc },
            function (data) {
                $("#KhachHangList").html(data);
            });
    });
    $("#btnexcel").click(function () {
        if ($("#excelvalue").val() == "") {
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["warning"]("Bạn chưa copy dữ liệu từ excel vào ô", "THÔNG BÁO")
        }
        else {
            var data = $("#excelvalue").val();
            var rows = data.split("\n");
            for (var y in rows) {

                $("#AA" + rows[y].replace(".", "").toUpperCase()).prop('checked', true);
            }
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["success"]("Đã Check thành công " + (rows.length - 1) + " mã hàng hóa được nhập vào", "THÔNG BÁO")
            $("#excelvalue").val("");
            $("#sanphamcount").text($(".Checkboxlist5:checked").length);
        }
    });
    $("#btnexcelkh").click(function () {
        if ($("#excelvaluekh").val() == "") {
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["warning"]("Bạn chưa copy dữ liệu từ excel vào ô", "THÔNG BÁO")
        }
        else {
            var data = $("#excelvaluekh").val();
            var rows = data.split("\n");
            for (var y in rows) {
                $("#CC" + rows[y].replaceAll(".", "")).prop('checked', true);
            }
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["success"]("Đã Check thành công " + (rows.length - 1) + " mã khách hàng được nhập vào", "THÔNG BÁO")
            $("#excelvaluekh").val("");
            $("#sanphamcountkh").text($(".Checkboxlist8:checked").length);
        }
    });
    $("#chon").change(function () {
        if ($("#chon").val() == 0) {
            $('#donvi').selectpicker('destroy').removeClass('show-tick').removeAttr("multiple");
            $("#theomien").addClass('hidden');
            $(".poc").hide();
        }
        else {

            $('#donvi').selectpicker('destroy').addClass('show-tick').attr("multiple", "true");
            $('#donvi .bs-title-option').remove();
            $("#theomien").removeClass('hidden');
            $("#QuanhuyenList").empty();
            $("#TrinhDuocVienList").empty();
            $(".poc").show();
            $.post(lang + '/he-thong/GetBoLocTH',
                function (data) {
                    $("#SanPhamList").empty();
                    for (var i = 0; i < data.SP.length; i++) {
                        $("#SanPhamList").append('<div id="A' + data.SP[i].MaHH.replace(".", "") + '" class="checkbox checkbox-primary Checkboxlist5"><input class="Checkboxlist5" value="' + data.SP[i].MaHH + '" id="AA' + data.SP[i].MaHH.replace(".", "") + '" type="checkbox" name="Checkboxlist5"><label for="AA' + data.SP[i].MaHH.replace(".", "") + '">' + data.SP[i].MaHH + " &bull; " + data.SP[i].TenHH + '</label></div>');
                    }
                    console.log($("#SanPhamList"));
                    console.log(data.SP)
                    $("#LoaiHopDongList").empty();
                    for (var i = 0; i < data.HD.length; i++) {
                        $("#LoaiHopDongList").append('<div id="A' + data.HD[i].MaHH + '" class="checkbox checkbox-primary Checkboxlist13"><input class="Checkboxlist13" value="' + data.HD[i].loaihd + '" id="AA' + data.HD[i].loaihd + '" type="checkbox" name="Checkboxlist13"><label for="AA' + data.HD[i].loaihd + '">' + data.HD[i].loaihd + '</label></div>');
                    }
                    $("#KhuVucList").empty();
                    for (var i = 0; i < data.TINH.length; i++) {
                        $("#KhuVucList").append('<div id="B' + data.TINH[i].matinh + '" class="checkbox checkbox-primary Checkboxlist6"><input class="Checkboxlist6" value="' + data.TINH[i].matinh + '" id="BB' + data.TINH[i].matinh + '" type="checkbox" name="Checkboxlist6"><label for="BB' + data.TINH[i].matinh + '">' + data.TINH[i].matinh + " &bull; " + data.TINH[i].tentinh + '</label></div>');
                    }
                    $("#KhuyenMaiList").empty();
                    for (var i = 0; i < data.KM.length; i++) {
                        $("#KhuyenMaiList").append('<div id="D' + data.KM[i].MAKM + '" class="checkbox checkbox-primary Checkboxlist9"><input class="Checkboxlist9" value="' + data.KM[i].MAKM + '" id="DD' + data.KM[i].MAKM + '" type="checkbox" name="Checkboxlist9"><label for="DD' + data.KM[i].MAKM + '">' + data.KM[i].MAKM + " &bull; " + data.KM[i].TENKM + '</label></div>');
                    }
                });
            //$.post(lang + '/he-thong/GetKhuyenMai', { ChiNhanhId: $('#donvi').val().toString() },
            //    function (data) {

            //    });
            $.post(lang + '/he-thong/PartialKhachHang', { ChiNhanhId: "ALL" },
                function (data) {
                    $("#KhachHangList").html(data);
                });
        }
        $('#donvi').selectpicker();
        $('#donvi').selectpicker('deselectAll');
    });
    if (screen.width > 600) {
        $(".overflow-auto").css("max-height", "400px");
    }
    else {
        var height = screen.height - 220;
        $(".overflow-auto:not(#SanPhamList)").css("max-height", height + "px");
        $("#SanPhamList").css("max-height", (height - 50) + "px");
    }
    $("#CheckAll3").change(function () {
        $(".Checkboxlist3").prop('checked', $(this).prop("checked"));
    });
    $("#CheckAll33").change(function () {
        $(".Checkboxlist33").prop('checked', $(this).prop("checked"));
    });
    $("#CheckAll4").change(function () {
        $(".Checkboxlist4").prop('checked', $(this).prop("checked"));
    });
    $("#CheckAll5").change(function () {
        $(".Checkboxlist5:visible").prop('checked', $(this).prop("checked"));
        $("#sanphamcount").text($(".Checkboxlist5:checked").length);
    });
    $("#CheckAll6").change(function () {
        $(".Checkboxlist6").prop('checked', $(this).prop("checked"));
    });
    $("#CheckAll7").change(function () {
        $(".Checkboxlist").prop('checked', $(this).prop("checked"));
    });
    $("#CheckAll8").change(function () {
        $(".Checkboxlist8:visible").prop('checked', $(this).prop("checked"));
        $("#sanphamcountkh").text($(".Checkboxlist8:checked").length);
    });
    $("#CheckAll9").change(function () {
        $(".Checkboxlist9:visible").prop('checked', $(this).prop("checked"));
    });
    $("#CheckAll10").change(function () {
        $(".Checkboxlist10:visible").prop('checked', $(this).prop("checked"));
    });
    $("#CheckAll11").change(function () {
        $(".Checkboxlist11").prop('checked', $(this).prop("checked"));
    });
    $("#CheckAll12").change(function () {
        $(".Checkboxlist12:visible").prop('checked', $(this).prop("checked"));
    });
    $("#CheckAll13").change(function () {
        $(".Checkboxlist13:visible").prop('checked', $(this).prop("checked"));
    });
    $("#CheckAll14").change(function () {
        $(".Checkboxlist14:visible").prop('checked', $(this).prop("checked"));
    });
    $("#nhaphanphoi").click(function () {
        if ($("#nhaphanphoi").is(":checked")) {
            $('#id02').modal({ backdrop: 'static' })
        }
        else {
        }
    });
    $("#phanloaichitiet").click(function () {
        if ($("#phanloaichitiet").is(":checked")) {
            $('#id03').modal({ backdrop: 'static' })
            $(".Checkboxlist3").attr("disabled", false);
        }
        else {
            $(".Checkboxlist3").attr("disabled", true);
        }
    });
    $("#nhomhangkhac").click(function () {
        if ($("#nhomhangkhac").is(":checked")) {
            $('#id04').modal({ backdrop: 'static' })
            $(".Checkboxlist4").attr("disabled", false);
        }
        else {
            $(".Checkboxlist4").attr("disabled", true);
        }
    });

    $("#hotro").click(function () {
        if ($("#hotro").is(":checked")) {

            $('#id14').modal({ backdrop: 'static' })
            $(".Checkboxlist14").attr("disabled", false);
        }
        else {
            $(".Checkboxlist14").attr("disabled", true);
        }
    });
    $("#sanpham").change(function () {
        if ($("#sanpham").is(":checked")) {
            $('#id05').modal({ backdrop: 'static' })

            $(".Checkboxlist5").attr("disabled", false);
        }
        else {
            $(".Checkboxlist5").attr("disabled", true);
        }
    });
    $("#khachhang").change(function () {
        if ($("#khachhang").is(":checked")) {
            $('#id08').modal({ backdrop: 'static' })
            $(".Checkboxlist8").attr("disabled", false);
        }
        else {
            $(".Checkboxlist8").attr("disabled", true);
        }
    });
    $("#loaikhachhang").change(function () {
        if ($("#loaikhachhang").is(":checked")) {
            $('#id15').modal({ backdrop: 'static' })
            $(".Checkboxlist15").attr("disabled", false);
        }
        else {
            $(".Checkboxlist15").attr("disabled", true);
        }
    });
    $("#khuyenmai").change(function () {
        if ($("#khuyenmai").is(":checked")) {
            $('#id09').modal({ backdrop: 'static' })
            $(".Checkboxlist9").attr("disabled", false);
        }
        else {
            $(".Checkboxlist9").attr("disabled", true);
        }
    });
    $("#quanhuyen").change(function () {
        if ($("#quanhuyen").is(":checked")) {
            $('#id11').modal({ backdrop: 'static' })
            $(".Checkboxlist11").attr("disabled", false);
        }
        else {
            $(".Checkboxlist11").attr("disabled", true);
        }
    });
    $("#trinhduocvien").change(function () {
        if ($("#trinhduocvien").is(":checked")) {
            $('#id10').modal({ backdrop: 'static' })
            $(".Checkboxlist10").attr("disabled", false);
        }
        else {
            $(".Checkboxlist10").attr("disabled", true);
        }
    });
    $("#hopdong").change(function () {
        if ($("#hopdong").is(":checked")) {
            $('#id12').modal({ backdrop: 'static' })
            $(".Checkboxlist12").attr("disabled", false);
        }
        else {
            $(".Checkboxlist12").attr("disabled", true);
        }
    });
    $("#loaihopdong").change(function () {
        if ($("#loaihopdong").is(":checked")) {
            $('#id13').modal({ backdrop: 'static' })
            $(".Checkboxlist13").attr("disabled", false);
        }
        else {
            $(".Checkboxlist13").attr("disabled", true);
        }
    });
    $("#khuvuc").change(function () {
        if ($("#khuvuc").is(":checked")) {
            $('#id06').modal({ backdrop: 'static' })
            $(".Checkboxlist6").attr("disabled", false);
        }
        else {
            $(".Checkboxlist6").attr("disabled", true);
        }
    });

    $('.amenu2').addClass('active');
    $("#chonbaocao").change(function () {
        if ($("#chonbaocao").val() != 26 && $("#chonbaocao").val() != 24 && $("#chonbaocao").val() != 27 && $("#chonbaocao").val() != 28 && $("#chonbaocao").val() != 25) {
            $(".divnam").css("display", "none");
            $(".divngay").css("display", "block");
        }
        if ($("#chonbaocao").val() == 14 || $("#chonbaocao").val() == 29) {
            $(".divtop").css("display", "block");
        }
        else {
            $(".divtop").css("display", "none");
        }
        if ($("#chonbaocao").val() == 2) {
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["info"]("Báo cáo này bắt buộc phải chọn khách hàng hoặc quận huyện hoặc khu vực.", "Ghi chú")
        }
        //else if ($("#chonbaocao").val() == 3) {
        //    toastr.options = {
        //        "closeButton": true,
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
        //    Command: toastr["info"]("Báo cáo này bắt buộc phải chọn 1 trong các bộ lọc khách hàng - mã trình dược viên - khu vực.", "Ghi chú")
        //}
        else if ($("#chonbaocao").val() == 17) {
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["info"]("Báo cáo này bắt buộc phải chọn 1 khách hàng.", "Ghi chú")
        }
        else if ($("#chonbaocao").val() == 7) {
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["info"]("Báo cáo này bắt buộc phải chọn khách hàng hoặc trình dược viên.", "Ghi chú")
        }
        else if ($("#chonbaocao").val() == 30 || $("#chonbaocao").val() == 31 || $("#chonbaocao").val() == 32) {
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["info"]("Báo cáo này bắt buộc phải chọn một CTKM có tích điểm trong bộ lọc CT KHUYẾN MÃI hoặc CTHT có tích điểm trong bộ lọc CT HỖ TRỢ", "Ghi chú")
        }
        else if ($("#chonbaocao").val() == 24) {
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["info"]("Báo cáo này bắt buộc phải chọn CT khuyến mãi.</br>Mẹo: Chọn khách hàng cụ thể để tăng tốc độ truy xuất dữ liệu.", "Ghi chú")
            $('#qui').prop('disabled', true);
            $(".divnam").css("display", "block");
            $(".divngay").css("display", "none");
            $('#qui').selectpicker('refresh');
        }
        else if ($("#chonbaocao").val() == 26) {
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["info"]("Báo cáo này bắt buộc phải chọn CT khuyến mãi.</br>Mẹo: Chọn khách hàng cụ thể để tăng tốc độ truy xuất dữ liệu.", "Ghi chú")
            $('#qui').prop('disabled', false);
            $(".divnam").css("display", "block");
            $(".divngay").css("display", "none");
            $('#qui').selectpicker('refresh');
        }
        else if ($("#chonbaocao").val() == 27 || $("#chonbaocao").val() == 55 || $("#chonbaocao").val() == 56) {
            $('#qui').prop('disabled', false);
            $(".divnam").css("display", "block");
            $(".divngay").css("display", "none");
            $('#qui').selectpicker('refresh');
        }
        else if ($("#chonbaocao").val() == 28) {
            $('#qui').prop('disabled', true);
            $(".divnam").css("display", "block");
            $(".divngay").css("display", "none");
            $('#qui').selectpicker('refresh');
        }
        else if ($("#chonbaocao").val() == 25 || $("#chonbaocao").val() == 53 || $("#chonbaocao").val() == 54) {
            $('#qui').prop('disabled', true);
            $(".divnam").css("display", "block");
            $(".divngay").css("display", "none");
            $('#qui').selectpicker('refresh');
        }
        //else if ($("#chonbaocao").val() == 29) {
        //    $('#qui').prop('disabled', false);
        //    $(".divnam").css("display", "block");
        //    $(".divngay").css("display", "none");
        //    $('#qui').selectpicker('refresh');
        //}
        else if ($("#chonbaocao").val() == 33 || $("#chonbaocao").val() == 34 || $("#chonbaocao").val() == 35) {
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["info"]("Báo cáo này bắt buộc phải chọn một CT Khuyến mãi hoặc CT hỗ trợ", "Ghi chú")
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
    var date_input = $('.form-control1'); //our date input has the name "date"
    var container = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : "body";
    var options = {
        format: 'dd/mm/yyyy',
        container: container,
        todayHighlight: true,
        autoclose: true,
    };
    date_input.datepicker(options);
    $("#taidrop").click(function (e) {
        if ($('#donvi').val() == "") {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn đơn vị.", "Lỗi !")
        }
        else if ($("#chonbaocao").val() == 2) {
            if ($(".Checkboxlist8").is(":checked") == false && $(".Checkboxlist6").is(":checked") == false && $(".Checkboxlist11").is(":checked") == false) {
                e.preventDefault();
                toastr.options = {
                    "closeButton": true,
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
                Command: toastr["error"]("Bạn chưa chọn khách hàng , khu vực hoặc quận/huyện.", "Lỗi !")
            }
            else if ($("#khachhang").is(":checked") == false && $("#khuvuc").is(":checked") == false && $("#quanhuyen").is(":checked") == false) {
                e.preventDefault();
                toastr.options = {
                    "closeButton": true,
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
                Command: toastr["error"]("Bạn chưa chọn khách hàng , khu vực hoặc quận/huyện.", "Lỗi !")
            }
        }
        //else if ($("#chonbaocao").val() == 3 && (($(".Checkboxlist8").is(":checked") == false || $("#khachhang").is(":checked") == false) && ($(".Checkboxlist10").is(":checked") == false || $("#trinhduocvien").is(":checked") == false) && ($(".Checkboxlist6").is(":checked") == false || $("#khuvuc").is(":checked") == false))) {
        //    e.preventDefault();
        //    toastr.options = {
        //        "closeButton": true,
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
        //    Command: toastr["error"]("Bạn chưa chọn khách hàng, trình dược viên hoặc khu vực.", "Lỗi !")
        //}
        else if ($("#chonbaocao").val() == 17 && (($(".Checkboxlist8").is(":checked") == false || $("#khachhang").is(":checked") == false))) {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn khách hàng.", "Lỗi !")
        }
        else if ($("#chonbaocao").val() == 7 && (($(".Checkboxlist8").is(":checked") == false || $("#khachhang").is(":checked") == false) && ($(".Checkboxlist10").is(":checked") == false || $("#trinhduocvien").is(":checked") == false))) {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn khách hàng hoặc trình dược viên.", "Lỗi !")
        }
        else if ($("#chonbaocao").val() == 24 && (($(".Checkboxlist9").is(":checked") == false || $("#khuyenmai").is(":checked") == false))) {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn chương trình khuyến mãi.", "Lỗi !")
        }
        else if ($("#chonbaocao").val() == 26 && (($(".Checkboxlist9").is(":checked") == false || $("#khuyenmai").is(":checked") == false))) {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn chương trình khuyến mãi.", "Lỗi !")
        }
        else if ($("#chonbaocao").val() == 35 && (($(".Checkboxlist9").is(":checked") == false || $("#khuyenmai").is(":checked") == false))) {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn chương trình khuyến mãi.", "Lỗi !")
        }
        else if (($("#chonbaocao").val() == 30 || $("#chonbaocao").val() == 31 || $("#chonbaocao").val() == 32 || $("#chonbaocao").val() == 33 || $("#chonbaocao").val() == 34) && ((($(".Checkboxlist9").is(":checked") == false || $("#khuyenmai").is(":checked") == false) && ($(".Checkboxlist14").is(":checked") == false || $("#hotro").is(":checked") == false)))) {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn chương trình khuyến mãi hoặc chương trình hỗ trợ.", "Lỗi !")
        }
        else if ($("#tungay").val() == "" || $("#denngay").val() == "") {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn ngày.", "Lỗi !")
        }
    });
    $("#btnin").click(function (e) {
        if ($('#donvi').val() == "") {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]((lang == "/vi") ? "Bạn chưa chọn đơn vị." : "Please choose branch", (lang == "/vi") ? "Lỗi !" : "Error !")
        }
        else if ($("#chonbaocao").val() == 2) {
            if ($(".Checkboxlist8").is(":checked") == false && $(".Checkboxlist6").is(":checked") == false && $(".Checkboxlist11").is(":checked") == false) {
                e.preventDefault();
                toastr.options = {
                    "closeButton": true,
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
                Command: toastr["error"]("Bạn chưa chọn khách hàng , khu vực hoặc quận/huyện.", "Lỗi !")
            }
            else if ($("#khachhang").is(":checked") == false && $("#khuvuc").is(":checked") == false && $("#quanhuyen").is(":checked") == false) {
                e.preventDefault();
                toastr.options = {
                    "closeButton": true,
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
                Command: toastr["error"]("Bạn chưa chọn khách hàng , khu vực hoặc quận/huyện.", "Lỗi !")
            }
        }
        //else if ($("#chonbaocao").val() == 3 && (($(".Checkboxlist8").is(":checked") == false || $("#khachhang").is(":checked") == false) && ($(".Checkboxlist10").is(":checked") == false || $("#trinhduocvien").is(":checked") == false) && ($(".Checkboxlist6").is(":checked") == false || $("#khuvuc").is(":checked") == false))) {
        //    e.preventDefault();
        //    toastr.options = {
        //        "closeButton": true,
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
        //    Command: toastr["error"]("Bạn chưa chọn khách hàng, trình dược viên hoặc khu vực.", "Lỗi !")
        //}
        else if ($("#chonbaocao").val() == 17 && (($(".Checkboxlist8").is(":checked") == false || $("#khachhang").is(":checked") == false))) {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn khách hàng.", "Lỗi !")
        }
        else if ($("#chonbaocao").val() == 7 && (($(".Checkboxlist8").is(":checked") == false || $("#khachhang").is(":checked") == false) && ($(".Checkboxlist10").is(":checked") == false || $("#trinhduocvien").is(":checked") == false))) {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn khách hàng hoặc trình dược viên.", "Lỗi !")
        }
        else if ($("#chonbaocao").val() == 24 && (($(".Checkboxlist9").is(":checked") == false || $("#khuyenmai").is(":checked") == false))) {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn chương trình khuyến mãi.", "Lỗi !")
        }
        else if ($("#chonbaocao").val() == 26 && (($(".Checkboxlist9").is(":checked") == false || $("#khuyenmai").is(":checked") == false))) {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn chương trình khuyến mãi.", "Lỗi !")
        }
        else if ($("#chonbaocao").val() == 35 && (($(".Checkboxlist9").is(":checked") == false || $("#khuyenmai").is(":checked") == false))) {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn chương trình khuyến mãi.", "Lỗi !")
        }
        else if (($("#chonbaocao").val() == 30 || $("#chonbaocao").val() == 31 || $("#chonbaocao").val() == 32 || $("#chonbaocao").val() == 33 || $("#chonbaocao").val() == 34) && ((($(".Checkboxlist9").is(":checked") == false || $("#khuyenmai").is(":checked") == false) && ($(".Checkboxlist14").is(":checked") == false || $("#hotro").is(":checked") == false)))) {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn chương trình khuyến mãi hoặc chương trình hỗ trợ.", "Lỗi !")
        }
        else if ($("#tungay").val() == "" || $("#denngay").val() == "") {
            e.preventDefault();
            toastr.options = {
                "closeButton": true,
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
            Command: toastr["error"]("Bạn chưa chọn ngày.", "Lỗi !")
        }
    });
});
function taiclick() {
    var x = document.getElementById("taidrop");
    if (x.className.indexOf("w3-show") == -1) {
        x.className += " w3-show";
    } else {
        x.className = x.className.replace(" w3-show", "");
    }
}