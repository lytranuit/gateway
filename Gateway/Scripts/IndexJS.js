$(document).ready(function () {
    var date_input = $('.form-control1'); //our date input has the name "date"
    var container = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : "body";
    var options = {
        format: 'dd/mm/yyyy',
        container: container,
        todayHighlight: true,
        autoclose: true,
    };
    date_input.datepicker(options);
    $("#chon").change(function () {
        if ($("#chon").val() == 0) {
            $('#Checkboxlist1').selectpicker('destroy').removeClass('show-tick').removeAttr("multiple");
            $("#theomien").addClass('hidden');
        }
        else {
            $('#Checkboxlist1').selectpicker('destroy').addClass('show-tick').attr("multiple", "true");
            $('#Checkboxlist1 .bs-title-option').remove();
            $("#theomien").removeClass('hidden');
        }
        $('#Checkboxlist1').selectpicker();
        $('#Checkboxlist1').selectpicker('deselectAll');
    });
    $("#submit").click(function () {
        if ($('#Checkboxlist1').val() == "") {
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
            Command: toastr["warning"]((lang == "/vi") ? "Bạn chưa chọn chi nhánh" : "Please choose branch", (lang == "/vi") ? "Thông báo" : "Error")
        }
        else if ($('#tungay').val() == "" || $('#denngay').val() == "") {
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
            Command: toastr["warning"]("Bạn chưa chọn ngày", "Thông báo")
        }
        else {
            $('#loading').modal({ backdrop: 'static', keyboard: false })
            $.ajax({
                url: lang + '/he-thong/doanh-so-theo-thang',
                type: "POST",
                datatype: 'json',
                contentType: "application/json",
                data: '{tungay1: ' + JSON.stringify($("#tungay").val()) + ', denngay1: ' + JSON.stringify($("#denngay").val()) + ', sltopkhachhang: ' + JSON.stringify($("#sltopkhachhang").val()) + ', sltophanghoa: ' + JSON.stringify($("#sltophanghoa").val()) + ', sltopkhuvuc: ' + JSON.stringify($("#sltopkhuvuc").val()) + ', nhomhang: ' + JSON.stringify($("#nhomhang").val()) + ', maphanloai: ' + JSON.stringify($("#maphanloai").val()) + ', Checkboxlist1: ' + JSON.stringify($("#Checkboxlist1").val()) + ', Checkboxlist2: ' + JSON.stringify($("#Checkboxlist2").val()) + ', Checkboxlist3: ' + JSON.stringify($("#Checkboxlist3").val()) + '}',
                success: function (data) {
                    $('#loading').modal('hide')
                    $("#chartContainer").height(data.Chart1Height)
                    var chart = new CanvasJS.Chart("chartContainer", {
                        animationEnabled: true,
                        theme: "light2",
                        title: {
                        },
                        legend: {
                            fontSize: 16,
                        },
                        axisY: {
                            labelFontColor: "black",
                            labelFontSize: 12,
                            minimum: 0
                        },
                        axisX: {
                            interval: 1,
                            labelFontColor: "black",
                            labelFontSize: 12
                        },
                        data: [{
                            indexLabelPlacement: "outside",
                            indexLabelFontWeight: "bold",
                            indexLabelFontColor: "black",
                            type: "bar",
                            indexLabelFontSize: 13,
                            yValueFormatString: "#,##0.0#",
                            indexLabel: "{y}",
                            dataPoints: JSON.parse(data.DataPoints),
                        }]
                    });
                    var chart4 = new CanvasJS.Chart("chartContainer4", {
                        animationEnabled: true,
                        theme: "light2",
                        title: {
                        },
                        axisY: {
                            labelFontColor: "black",
                            labelFontSize: 12,
                            minimum: 0
                        },
                        axisX: {
                            labelFontColor: "black",
                            interval: 1,
                            labelFontSize: 12
                        },
                        legend: {
                            fontSize: 16,
                        },
                        data: [{
                            type: "bar",
                            indexLabelPlacement: "outside",
                            indexLabelFontWeight: "bold",
                            indexLabelFontColor: "black",
                            yValueFormatString: "#,##0.0#",
                            indexLabelFontSize: 14,
                            indexLabel: "{y}",
                            dataPoints: JSON.parse(data.DataPoints3),
                        }]
                    });
                    var chart3 = new CanvasJS.Chart("chartContainer3", {
                        theme: "light2",
                        animationEnabled: true,
                        title: {
                        },
                        legend: {
                            fontSize: 16,
                        },
                        data: [{
                            type: "doughnut",
                            radius: "80%",
                            toolTipContent: "<b>{label}</b>: {y} <b>(#percent%)</b>",
                            indexLabelPlacement: "outside",
                            indexLabelFontWeight: "bold",
                            indexLabelFontColor: "black",
                            yValueFormatString: "#,##0.0#",
                            showInLegend: "true",
                            legendText: "{label}",
                            indexLabelFontSize: 12,
                            indexLabel: "{label} - {y}(#percent%)",
                            dataPoints: JSON.parse(data.DataPoints2),
                        }]
                    });
                    var chart5 = new CanvasJS.Chart("chartContainer5", {
                        animationEnabled: true,
                        theme: "light2",
                        title: {
                        },
                        legend: {
                            fontSize: 16,
                        },
                        axisX: {
                            interval: 1,
                            labelFontColor: "black",
                            labelFontSize: 12
                        },
                        axisY: {
                            labelFontColor: "black",
                            minimum: 0,
                            labelFontSize: 12
                        },
                        data: [{
                            yValueFormatString: "#,##0.0#",
                            type: "bar",
                            indexLabelFontWeight: "bold",
                            indexLabelFontColor: "black",
                            indexLabelPlacement: "outside",
                            indexLabelFontSize: 12,
                            dataPoints: JSON.parse(data.DataPoints5),
                        }]
                    });
                    var chart2 = new CanvasJS.Chart("chartContainer2", {
                        animationEnabled: true,
                        theme: "light2",
                        title: {
                        },
                        legend: {
                            fontSize: 16,
                        },
                        axisY: {
                            labelFontColor: "black"
                        },
                        axisX: {
                            labelFontColor: "black",
                            interval: 1,
                            intervalType: "Tháng"
                        },
                        data: [{
                            indexLabelFontWeight: "bold",
                            indexLabelFontColor: "black",
                            type: "line",
                            toolTipContent: "<b>Tháng {x}</b>: {y} Tỷ",
                            yValueFormatString: "#,##0.0#",
                            indexLabelPlacement: "outside",
                            indexLabel: "{y}",
                            indexLabelMaxWidth: 55,
                            indexLabelWrap: true,
                            indexLabelFontSize: 11,
                            dataPoints: JSON.parse(data.DataPoints1),
                        }]
                    });
                    var chart6 = new CanvasJS.Chart("chartContainer6", {
                        theme: "light2",
                        animationEnabled: true,
                        title: {
                        },
                        legend: {
                            fontSize: 16,
                        },
                        data: [{
                            type: "doughnut",
                            radius: "80%",
                            indexLabelPlacement: "outside",
                            indexLabelFontWeight: "bold",
                            indexLabelFontColor: "black",
                            toolTipContent: "<b>{label}</b>: {y} Tỷ <b>(#percent%)</b>",
                            showInLegend: "true",
                            legendText: "{label}",
                            yValueFormatString: "#,##0.0#",
                            indexLabelFontSize: 12,
                            indexLabel: "{label} - {y}(#percent%)",
                            dataPoints: JSON.parse(data.DataPoints6),
                        }]
                    });
                    var chart7 = new CanvasJS.Chart("chartContainer7", {
                        theme: "light2",
                        animationEnabled: true,
                        internal: 1,
                        title: {
                        },
                        axisY: {
                        },
                        legend: {
                            fontSize: 13,
                        },
                        data: [{
                            type: "doughnut",
                            radius: "80%",
                            yValueFormatString: "#,##0.0#",
                            toolTipContent: "<b>{label}</b>: {y} Tỷ <b>(#percent%)</b>",
                            showInLegend: "true",
                            indexLabelPlacement: "outside",
                            indexLabelFontWeight: "bold",
                            indexLabelFontColor: "black",
                            legendText: "{label}",
                            indexLabelFontSize: 12,
                            indexLabel: "{label} - {y}(#percent%)",
                            dataPoints: JSON.parse(data.DataPoints7),
                        }]
                    });
                    var chart9 = new CanvasJS.Chart("chartContainer9", {
                        animationEnabled: true,
                        theme: "light2",
                        title: {
                        },
                        legend: {
                            fontSize: 16,
                        },
                        axisY: {
                            labelFontColor: "black",
                            labelFontSize: 12,
                            minimum: 0
                        },
                        axisX: {
                            labelFontColor: "black",
                            interval: 1,
                            labelFontFamily: "tahoma",
                            labelFontSize: 11,
                            minimum: 0
                        },
                        data: [{
                            indexLabelPlacement: "outside",
                            indexLabelFontWeight: "bold",
                            indexLabelFontColor: "black",
                            type: "bar",
                            indexLabel: "{y}",
                            indexLabelFontSize: 12,
                            yValueFormatString: "#,##0.0#",
                            dataPoints: JSON.parse(data.DataPoints9),
                        }]
                    });
                    //var chart10 = new CanvasJS.Chart("chartContainer10", {
                    //    animationEnabled: true,
                    //    theme: "light2",
                    //    axisX: {
                    //        labelFontFamily: "tahoma",
                    //        labelFontSize: 13
                    //    },
                    //    axisY: {
                    //    },

                    //    toolTip: {
                    //        shared: true
                    //    },
                    //    legend: {
                    //        cursor: "pointer",
                    //        fontFamily: "tahoma",
                    //        itemmouseover: function (e) {
                    //            e.dataSeries.lineThickness = e.chart.data[e.dataSeriesIndex].lineThickness * 2;
                    //            e.dataSeries.markerSize = e.chart.data[e.dataSeriesIndex].markerSize + 2;
                    //            e.chart.render();
                    //        },
                    //        itemmouseout: function (e) {
                    //            e.dataSeries.lineThickness = e.chart.data[e.dataSeriesIndex].lineThickness / 2;
                    //            e.dataSeries.markerSize = e.chart.data[e.dataSeriesIndex].markerSize - 2;
                    //            e.chart.render();
                    //        },
                    //        itemclick: function (e) {
                    //            if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                    //                e.dataSeries.visible = false;
                    //            } else {
                    //                e.dataSeries.visible = true;
                    //            }
                    //            e.chart.render();
                    //        }
                    //    },
                    //    data: [{
                    //        indexLabel: "{y} 100%",
                    //        indexLabelFontSize: 11,
                    //        type: "column",
                    //        name: "Kế hoạch",
                    //        indexLabelFontWeight: "bold",
                    //        indexLabelFontColor: "black",
                    //        indexLabelPlacement: "outside",
                    //        indexLabelMaxWidth: 50,
                    //        indexLabelWrap: true,
                    //        showInLegend: true,
                    //        yValueFormatString: "#,##0.0#",
                    //        dataPoints: JSON.parse(data.DataPoints811),
                    //    },
                    //    {
                    //        type: "column",
                    //        indexLabelFontSize: 11,
                    //        name: "Thực hiện",
                    //        indexLabelFontWeight: "bold",
                    //        indexLabelFontColor: "black",
                    //        indexLabelPlacement: "outside",
                    //        indexLabelMaxWidth: 50,
                    //        indexLabelWrap: true,
                    //        showInLegend: true,
                    //        yValueFormatString: "#,##0.0#",
                    //        dataPoints: JSON.parse(data.DataPoints88),
                    //    }]
                    //});

                    chart5.render();
                    chart4.render();
                    chart3.render();
                    chart.render();

                    chart2.render();
                    chart6.render();
                    chart7.render();
                    chart9.render();
                    //chart10.render();

                },
                error: function (request, status, error) {
                    $('#loading').modal('hide')
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
                    Command: toastr["warning"]("Không kết nối được dữ liệu", "Thông báo")
                },
                timeout: 300000,
            });
        }

    });
    $("#btnin").click(function () {
        try {
            var DataChart1 = $("#chartContainer .canvasjs-chart-canvas").get(0).toDataURL();
            var DataChart2 = $("#chartContainer2 .canvasjs-chart-canvas").get(0).toDataURL();
            var DataChart3 = $("#chartContainer3 .canvasjs-chart-canvas").get(0).toDataURL();
            var DataChart4 = $("#chartContainer4 .canvasjs-chart-canvas").get(0).toDataURL();
            var DataChart5 = $("#chartContainer5 .canvasjs-chart-canvas").get(0).toDataURL();
            var DataChart6 = $("#chartContainer6 .canvasjs-chart-canvas").get(0).toDataURL();
            var DataChart7 = $("#chartContainer7 .canvasjs-chart-canvas").get(0).toDataURL();
            var DataChart9 = $("#chartContainer9 .canvasjs-chart-canvas").get(0).toDataURL();

            var windowContent = '<!DOCTYPE html>';
            windowContent += '<html>'
            windowContent += '<head><title></title></head>';
            windowContent += '<body>'
            windowContent += '<p>Từ ngày ' + $("#tungay").val() + ' Đến ngày  ' + $("#denngay").val() + '</p>'
            windowContent += '<div style="text-align: center;margin-bottom:40px;"><h2>DOANH SỐ CHI TIẾT </h2><div style="right:10px; position:absolute;">TỶ ĐỒNG</div> </div>'
            windowContent += '<div style="margin-bottom:5px;border:3px solid black;text-align: center;">';
            windowContent += '<p> DOANH THU CHI NHÁNH</p>'
            windowContent += '<img style="display:block; margin: 0 auto; width:95%;" src="' + DataChart1 + '">';
            windowContent += '</div>'
            windowContent += '<div style="margin-bottom:5px;border:3px solid black;text-align: center;">';
            windowContent += '<p> DOANH THU HÀNG THÁNG</p>'
            windowContent += '<img style="display:block; margin: 0 auto; width:95%;" src="' + DataChart2 + '">';
            windowContent += '</div>'
            windowContent += '<div style="margin-bottom:5px;border:3px solid black;text-align: center;">';
            windowContent += '<p> TỈ LỆ DOANH THU VÙNG MIỀN</p>'
            windowContent += '<img style="display:block; margin: 0 auto; width:95%;" src="' + DataChart3 + '">';
            windowContent += '</div>'
            windowContent += '<div style="margin-bottom:5px;border:3px solid black;text-align: center;">';
            windowContent += '<p> TOP DOANH THU MÃ HÀNG HÓA</p>'
            windowContent += '<img style="display:block; margin: 0 auto; width:95%;" src="' + DataChart4 + '">';
            windowContent += '</div>'
            windowContent += '<div style="margin-bottom:5px; border:3px solid black;text-align: center;">';
            windowContent += '<p> TOP DOANH THU KHU VỰC</p>'
            windowContent += '<img style="display:block; margin: 0 auto; width:95%;" src="' + DataChart5 + '">';
            windowContent += '</div>'
            windowContent += '<h2 style="text-align: center; margin-top:100px;">DOANH SỐ PHÂN LOẠI KHÁCH HÀNG</h2>'
            windowContent += '<div style="margin-bottom:10px ;border:3px solid black;text-align: center;">';
            windowContent += '<p> TỈ LỆ DOANH THU ETC/OTC</p>'
            windowContent += '<img style="display:block; margin: 0 auto; width:95%;" src="' + DataChart6 + '">';
            windowContent += '</div>'
            windowContent += '<div style=" margin-bottom:10px;border:3px solid black;text-align: center;">';
            windowContent += '<p> TỈ LỆ DOANH THU PHÂN LOẠI KHÁCH HÀNG</p>'
            windowContent += '<img style="display:block; margin: 0 auto; width:95%;" src="' + DataChart7 + '">';
            windowContent += '</div>'
            //windowContent += '<div style="margin-bottom:10px; border:3px solid black;text-align: center;">';
            //windowContent += '<p> DOANH SỐ / KẾ HOẠCH</p>'
            //windowContent += '<img style="display:block; margin: 0 auto;" src="' + DataChart10 + '">';
            //windowContent += '</div>'
            windowContent += '<div style="margin-bottom:10px; border:3px solid black;text-align: center; margin-top:100px;">';
            windowContent += '<p> TOP DOANH THU KHÁCH HÀNG</p>'
            windowContent += '<img style="display:block; margin: 0 auto; width:95%;" src="' + DataChart9 + '">';
            windowContent += '</div>'
            windowContent += '</body>';
            windowContent += '</html>';
            var printWin = window.open('', '', 'width=800,height=600');
            printWin.document.open();
            printWin.document.write(windowContent);
            printWin.addEventListener('load', function () { printWin.print(); printWin.close(); }, false);
            printWin.document.close();
            printWin.focus();
        }
        catch (err) {
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
            Command: toastr["warning"]("Bạn phải chọn thực hiện trước khi in", "Thông báo")
        }

    });
});
jQuery('<div class="quantity-nav"><div class="quantity-button quantity-up">+</div><div class="quantity-button quantity-down">-</div></div>').insertAfter('.quantity input');
jQuery('.quantity').each(function () {
    var spinner = jQuery(this),
      input = spinner.find('input[type="number"]'),
      btnUp = spinner.find('.quantity-up'),
      btnDown = spinner.find('.quantity-down'),
      min = input.attr('min'),
      max = input.attr('max');

    btnUp.click(function () {
        var oldValue = parseFloat(input.val());
        if (oldValue >= max) {
            var newVal = oldValue;
        } else {
            var newVal = oldValue + 5;
        }
        spinner.find("input").val(newVal);
        spinner.find("input").trigger("change");
    });

    btnDown.click(function () {
        var oldValue = parseFloat(input.val());
        if (oldValue <= min) {
            var newVal = oldValue;
        } else {
            var newVal = oldValue - 5;
        }
        spinner.find("input").val(newVal);
        spinner.find("input").trigger("change");
    });
});