
        $(document).ready(function(){
         
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
                if ($('#Checkboxlist1').val() == "")
                {
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
                    Command: toastr["warning"]((lang =="/vi")?"Bạn chưa chọn chi nhánh":"Please choose branch", (lang =="/vi")?"Thông báo":"Error")
                }
                else
                {
                    $('#loading').modal({ backdrop: 'static', keyboard: false })
                    $.ajax({
                        url: lang + '/he-thong/so-sanh-theo-nam',
                        type: "POST",
                        datatype: 'json',
                        contentType: "application/json",
                        data: '{tuthang: ' + JSON.stringify($("#tuthang").val()) + ', denthang: ' + JSON.stringify($("#denthang").val()) + ', nam: ' + JSON.stringify($("#nam").val()) + ', nhomhang: ' + JSON.stringify($("#nhomhang").val()) + ', maphanloai: ' + JSON.stringify($("#maphanloai").val()) + ', Checkboxlist1: ' + JSON.stringify($("#Checkboxlist1").val()) + ', Checkboxlist2: ' + JSON.stringify($("#Checkboxlist2").val()) + ', Checkboxlist3: ' + JSON.stringify($("#Checkboxlist3").val()) + '}',
                        success: function (data) {
                            $('#loading').modal('hide')
                            $("#chartContainer").height(data.Chart1Height)
                            $("#chartContainer5").height(data.Chart5Height)
                            
                            var chart = new CanvasJS.Chart("chartContainer", {
                                animationEnabled: true,
                                theme: "light2",
                                title: {

                                },
                                axisY: {
                                    labelFontColor: "black",
                                    labelFontSize: 12
                                },
                                toolTip: {
                                    shared: true
                                },
                                legend:{
                                    fontSize: 18,
                                    cursor: "pointer",
                                    itemmouseover: function(e) {
                                        e.dataSeries.lineThickness = e.chart.data[e.dataSeriesIndex].lineThickness * 2;
                                        e.dataSeries.markerSize = e.chart.data[e.dataSeriesIndex].markerSize + 2;
                                        e.chart.render();
                                    },
                                    itemmouseout: function(e) {
                                        e.dataSeries.lineThickness = e.chart.data[e.dataSeriesIndex].lineThickness / 2;
                                        e.dataSeries.markerSize = e.chart.data[e.dataSeriesIndex].markerSize - 2;
                                        e.chart.render();
                                    },
                                    itemclick: function (e) {
                                        if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                            e.dataSeries.visible = false;
                                        } else {
                                            e.dataSeries.visible = true;
                                        }
                                        e.chart.render();
                                    }
                                },
                                axisX: {
                                    interval: 1,
                                    labelFontSize: 12,
                                    labelFontColor: "black"
                                    //title: "Countries"
                                },
                                data: [{
                                    indexLabelPlacement: "inside",
                                    indexLabelFontWeight: "bold",
                                    indexLabelFontColor: "black",
                                    type: "stackedBar",

                                    indexLabelFontSize: 13,
                                    yValueFormatString: "#,##0.0#",
                                    //indexLabel: "{y}",
                                    name:"" + ($("#nam").val() -1),
                                    showInLegend: true,
                                    dataPoints: JSON.parse(data.DataPoints),
                                },{
                                    indexLabelPlacement: "inside",
                                    indexLabelFontWeight: "bold",
                                    indexLabelFontColor: "black",

                                    type: "stackedBar",
                                    indexLabelFontSize: 13,
                                    yValueFormatString: "#,##0.0#",
                                    //indexLabel: "{y}",
                                    name:"" + $("#nam").val(),
                                    showInLegend: true,
                                    dataPoints: JSON.parse(data.DataPoints0),
                                },{
                                    indexLabelPlacement: "outside",
                                    indexLabelFontWeight: "bold",
                                    indexLabelFontColor: "black",
                                    type: "stackedBar",
                                    indexLabelFontSize: 13,
                                    yValueFormatString: "#,##0\"%\"",
                                    indexLabel: "{y}",
                                    name:(lang =="/vi")?"Tỉ lệ":"Rate",
                                    showInLegend: true,
                                    dataPoints: JSON.parse(data.DataPoints00),
                                }]
                            });
                            var chart3 = new CanvasJS.Chart("chartContainer3", {
                                animationEnabled: true,
                                theme: "light2",
                                axisX: {
                                    labelFontFamily: "tahoma",
                                    labelFontSize: 13
                                },
                                axisY: {
                                },

                                toolTip: {
                                    shared: true
                                },
                                legend: {
                                    cursor: "pointer",
                                    fontFamily: "tahoma",
                                    itemmouseover: function(e) {
                                        e.dataSeries.lineThickness = e.chart.data[e.dataSeriesIndex].lineThickness * 2;
                                        e.dataSeries.markerSize = e.chart.data[e.dataSeriesIndex].markerSize + 2;
                                        e.chart.render();
                                    },
                                    itemmouseout: function(e) {
                                        e.dataSeries.lineThickness = e.chart.data[e.dataSeriesIndex].lineThickness / 2;
                                        e.dataSeries.markerSize = e.chart.data[e.dataSeriesIndex].markerSize - 2;
                                        e.chart.render();
                                    },
                                    itemclick: function (e) {
                                        if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                            e.dataSeries.visible = false;
                                        } else {
                                            e.dataSeries.visible = true;
                                        }
                                        e.chart.render();
                                    }
                                },
                                data: [{
                                    indexLabel: "{y}",
                                    indexLabelFontSize: 11,
                                    type: "column",
                                    name:"" + ($("#nam").val() -1),
                                    indexLabelFontWeight: "bold",
                                    indexLabelFontColor: "black",
                                    indexLabelPlacement: "outside",
                                    indexLabelMaxWidth: 50,
                                    indexLabelWrap: true ,
                                    showInLegend: true,
                                    yValueFormatString: "#,##0.0#",
                                    dataPoints:JSON.parse(data.DataPoints2),
                                },
                                {
                                    type: "column",
                                    indexLabelFontSize: 11,
                                    name:"" + $("#nam").val(),
                                    indexLabelFontWeight: "bold",
                                    indexLabelFontColor: "black",
                                    indexLabelPlacement: "outside",
                                    indexLabelMaxWidth: 50,
                                    indexLabelWrap: true ,
                                    showInLegend: true,
                                    yValueFormatString: "#,##0.0#",
                                    dataPoints: JSON.parse(data.DataPoints22),
                                }]
                            });
                            var chart5 = new CanvasJS.Chart("chartContainer5", {
                                animationEnabled: true,
                                theme: "light2",
                                axisY: {
                                    labelFontColor: "black",
                                    labelFontSize: 15,
                                },
                                axisX: {
                                    interval: 1,
                                    labelFontSize: 15
                                },
                                toolTip: {
                                    shared: true
                                },
                                legend:{
                                    fontSize: 18,
                                    cursor: "pointer",
                                    itemmouseover: function(e) {
                                        e.dataSeries.lineThickness = e.chart.data[e.dataSeriesIndex].lineThickness * 2;
                                        e.dataSeries.markerSize = e.chart.data[e.dataSeriesIndex].markerSize + 2;
                                        e.chart.render();
                                    },
                                    itemmouseout: function(e) {
                                        e.dataSeries.lineThickness = e.chart.data[e.dataSeriesIndex].lineThickness / 2;
                                        e.dataSeries.markerSize = e.chart.data[e.dataSeriesIndex].markerSize - 2;
                                        e.chart.render();
                                    },
                                    itemclick: function (e) {
                                        if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                            e.dataSeries.visible = false;
                                        } else {
                                            e.dataSeries.visible = true;
                                        }
                                        e.chart.render();
                                    }
                                },
                                data: [{
                                    yValueFormatString: "#,##0.0#",
                                    type: "stackedBar",
                                    indexLabelFontWeight: "bold",
                                    name:"" + ($("#nam").val() -1),
                                    indexLabelFontColor: "black",
                                    indexLabelPlacement: "inside",
                                    showInLegend: true,
                                    indexLabelFontSize: 13,
                                    dataPoints: JSON.parse(data.DataPoints5),
                                },{
                                    yValueFormatString: "#,##0.0#",
                                    name:"" + $("#nam").val(),
                                    type: "stackedBar",
                                    indexLabelFontWeight: "bold",
                                    indexLabelFontColor: "black",
                                    indexLabelPlacement: "inside",
                                    showInLegend: true,
                                    indexLabelFontSize: 13,
                                    dataPoints: JSON.parse(data.DataPoints50),
                                },{
                                    yValueFormatString: "#,##0.0#",
                                    name: (lang == "/vi") ? "Tỉ lệ" : "Rate",
                                    type: "stackedBar",
                                    indexLabelFontWeight: "bold",
                                    indexLabelFontColor: "black",
                                    indexLabelPlacement: "outside",
                                    yValueFormatString: "#,##0\"%\"",
                                    indexLabel: "{y}",
                                    indexLabelFontSize: 13,
                                    showInLegend: true,
                                    dataPoints: JSON.parse(data.DataPoints500),
                                }]
                            });
                            var chart2 = new CanvasJS.Chart("chartContainer2", {
                                animationEnabled: true,
                                theme: "light2",
                                title: {

                                },
                                axisY: {
                                    labelFontColor: "black"
                                },
                                toolTip: {
                                    shared: true
                                },
                                axisX: {
                                    labelFontColor: "black",
                                    interval: 1,
                                    intervalType: "Tháng"
                                },
                                legend:{
                                    fontSize: 18,
                                    cursor: "pointer",
                                    itemmouseover: function(e) {
                                        e.dataSeries.lineThickness = e.chart.data[e.dataSeriesIndex].lineThickness * 2;
                                        e.dataSeries.markerSize = e.chart.data[e.dataSeriesIndex].markerSize + 2;
                                        e.chart.render();
                                    },
                                    itemmouseout: function(e) {
                                        e.dataSeries.lineThickness = e.chart.data[e.dataSeriesIndex].lineThickness / 2;
                                        e.dataSeries.markerSize = e.chart.data[e.dataSeriesIndex].markerSize - 2;
                                        e.chart.render();
                                    },
                                    itemclick: function (e) {
                                        if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                            e.dataSeries.visible = false;
                                        } else {
                                            e.dataSeries.visible = true;
                                        }
                                        e.chart.render();
                                    }
                                },
                                data: [{

                                    indexLabelFontWeight: "bold",
                                    indexLabelFontColor: "black",
                                    type: "line",
                                    name:"" + ($("#nam").val() -1),
                                    showInLegend: true,
                                    yValueFormatString: "#,##0.0#",
                                    dataPoints: JSON.parse(data.DataPoints1),
                                },{
                                    indexLabelFontWeight: "bold",
                                    indexLabelFontColor: "black",
                                    type: "line",
                                    name:"" + $("#nam").val(),
                                    showInLegend: true,
                                    yValueFormatString: "#,##0.0#",

                                    dataPoints: JSON.parse(data.DataPoints10),
                                }]
                            });
                            var chart6 = new CanvasJS.Chart("chartContainer6", {
                                animationEnabled: true,
                                theme: "light2",
                                axisX: {
                                    labelFontFamily: "tahoma",
                                    labelFontSize: 13
                                },
                                axisY: {
                                },

                                toolTip: {
                                    shared: true
                                },
                                legend: {
                                    cursor: "pointer",
                                    fontFamily: "tahoma",
                                    itemmouseover: function(e) {
                                        e.dataSeries.lineThickness = e.chart.data[e.dataSeriesIndex].lineThickness * 2;
                                        e.dataSeries.markerSize = e.chart.data[e.dataSeriesIndex].markerSize + 2;
                                        e.chart.render();
                                    },
                                    itemmouseout: function(e) {
                                        e.dataSeries.lineThickness = e.chart.data[e.dataSeriesIndex].lineThickness / 2;
                                        e.dataSeries.markerSize = e.chart.data[e.dataSeriesIndex].markerSize - 2;
                                        e.chart.render();
                                    },
                                    itemclick: function (e) {
                                        if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                                            e.dataSeries.visible = false;
                                        } else {
                                            e.dataSeries.visible = true;
                                        }
                                        e.chart.render();
                                    }
                                },
                                data: [{
                                    indexLabel: "{y}",
                                    indexLabelFontSize: 11,
                                    type: "column",
                                    name:"" + ($("#nam").val() -1),
                                    indexLabelFontWeight: "bold",
                                    indexLabelFontColor: "black",
                                    indexLabelPlacement: "outside",
                                    indexLabelMaxWidth: 50,
                                    indexLabelWrap: true ,
                                    showInLegend: true,
                                    yValueFormatString: "#,##0.0#",
                                    dataPoints:JSON.parse(data.DataPoints6),
                                },
                                {
                                    type: "column",
                                    indexLabelFontSize: 11,
                                    name:"" + $("#nam").val(),
                                    indexLabelFontWeight: "bold",
                                    indexLabelFontColor: "black",
                                    indexLabelPlacement: "outside",
                                    indexLabelMaxWidth: 50,
                                    indexLabelWrap: true ,
                                    showInLegend: true,
                                    yValueFormatString: "#,##0.0#",
                                    dataPoints: JSON.parse(data.DataPoints66),
                                }]
                            });
                            var chart7 = new CanvasJS.Chart("chartContainer7", {
                                theme: "light2",
                                animationEnabled: true,
                                internal: 1,
                                title: {
                                    text: "" + ($("#nam").val() -1)
                                },
                                axisY: {
                                },
                                legend:{
                                    fontSize: 13,
                                },
                                data: [{
                                    type: "doughnut",
                                    startAngle: 25,
                                    yValueFormatString: "#,##0.0#",
                                    toolTipContent: "<b>{label}</b>: {y} Tỷ <b>(#percent%)</b>",
                                    showInLegend: "true",
                                    indexLabelPlacement: "outside",
                                    indexLabelFontWeight: "bold",
                                    indexLabelFontColor: "black",
                                    legendText: "{label}",
                                    indexLabelFontSize: 11,
                                    radius: "70%",
                                    indexLabel: "{label} - {y}(#percent%)",
                                    dataPoints: JSON.parse(data.DataPoints7),
                                }]
                            });
                            var chart71 = new CanvasJS.Chart("chartContainer71", {
                                theme: "light2",
                                animationEnabled: true,
                                internal: 1,
                                title: {
                                    text: "" + $("#nam").val()
                                },

                                axisY: {
                                },
                                legend:{
                                    fontSize: 13,
                                },
                                data: [{
                                    type: "doughnut",
                                    startAngle: 25,
                                    radius: "70%",
                                    yValueFormatString: "#,##0.0#",
                                    toolTipContent: "<b>{label}</b>: {y} Tỷ <b>(#percent%)</b>",
                                    showInLegend: "true",
                                    indexLabelPlacement: "outside",
                                    indexLabelFontWeight: "bold",
                                    indexLabelFontColor: "black",
                                    legendText: "{label}",
                                    indexLabelFontSize: 12,
                                    indexLabel: "{label} - {y}(#percent%)",
                                    dataPoints: JSON.parse(data.DataPoints70),
                                }]
                            });
                          
                            chart5.render();

                            chart6.render();
                            chart3.render();
                            chart.render();
                            chart2.render();
                            chart7.render();
                            chart71.render();
                         
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
                    //
                    //$("#click").click();
                    var DataChart1 = $("#chartContainer .canvasjs-chart-canvas").get(0).toDataURL();
                    var DataChart2 = $("#chartContainer2 .canvasjs-chart-canvas").get(0).toDataURL();
                    var DataChart3 = $("#chartContainer3 .canvasjs-chart-canvas").get(0).toDataURL();
                    var DataChart5 = $("#chartContainer5 .canvasjs-chart-canvas").get(0).toDataURL();
                    var DataChart6 = $("#chartContainer6 .canvasjs-chart-canvas").get(0).toDataURL();
                    var DataChart7 = $("#chartContainer7 .canvasjs-chart-canvas").get(0).toDataURL();
                    var DataChart71 = $("#chartContainer71 .canvasjs-chart-canvas").get(0).toDataURL();
                    //var DataChart8 = $("#chartContainer8 .canvasjs-chart-canvas").get(0).toDataURL();
                    //var DataChart81 = $("#chartContainer81 .canvasjs-chart-canvas").get(0).toDataURL();
                    var windowContent = '<!DOCTYPE html>';

                    windowContent += '<html>'
                    windowContent += '<head><title></title></head>';
                    windowContent += '<body>'
                    windowContent += '<p>Từ tháng ' + $("#tuthang").val() + ' Đến tháng  '+  $("#denthang").val() + ' Năm  ' + $("#nam").val()  + '</p>'
                    windowContent += '<div style="text-align: center;margin-bottom:40px;"><h2>DOANH SỐ CHI TIẾT </h2><div style="right:10px; position:absolute;">TỶ ĐỒNG</div> </div>'
                    windowContent += '<div style="margin-bottom:5px;border:3px solid black;text-align: center;">';
                    windowContent += '<p> DOANH THU CHI NHÁNH</p>'
                    windowContent += '<img  style="display:block; margin: 0 auto; width:95%;" src="' + DataChart1 + '">';
                    windowContent += '</div>'
                    windowContent += '<div style="margin-bottom:100px;border:3px solid black;text-align: center;">';
                    windowContent += '<p> DOANH THU HÀNG THÁNG</p>'
                    windowContent += '<img  style="display:block; margin: 0 auto; width:95%;" src="' + DataChart2 + '">';
                    windowContent += '</div>'
                    windowContent += '<div style="margin-bottom:50px;border:3px solid black;text-align: center;">';
                    windowContent += '<p> DOANH THU VÙNG MIỀN</p>'
                    windowContent += '<img  style="display:block; margin: 0 auto; width:95%;" src="' + DataChart3 + '">';
                    windowContent += '</div>'
                    windowContent += '<div style="margin-bottom:150px; border:3px solid black;text-align: center;">';
                    windowContent += '<p> DOANH THU KHU VỰC</p>'
                    windowContent += '<img  style="display:block; margin: 0 auto; width:95%;" src="' + DataChart5 + '">';
                    windowContent += '</div>'
                    // DOANH SỐ PHÂN LOẠI KHÁCH HÀNG
                    windowContent += '<h2 style="text-align: center; margin-top:100px;">DOANH SỐ PHÂN LOẠI KHÁCH HÀNG</h2>'
                    windowContent += '<div style="margin-bottom:10px ;border:3px solid black;text-align: center;">';
                    windowContent += '<p>DOANH THU ETC/OTC</p>'
                    windowContent += '<img  style="display:block; margin: 0 auto; width:95%;" src="' + DataChart6 + '">';
                    windowContent += '</div>'
                    windowContent += '<div style=" margin-bottom:10px;border:3px solid black;text-align: center;">';
                    windowContent += '<p> TỈ LỆ DOANH THU PHÂN LOẠI KHÁCH HÀNG</p>'
                    windowContent += '<img  style="display:block; margin: 0 auto; width:95%;" src="' + DataChart7 + '">';
                    windowContent += '<img  style="display:block; margin: 0 auto; width:95%;" src="' + DataChart71 + '">';
                    windowContent += '</div>'
                    windowContent += '<div style="margin-bottom:10px; border:3px solid black;text-align: center;">';
                    //windowContent += '<p> DOANH SỐ / KẾ HOẠCH</p>'
                    //windowContent += '<img style="display:block; margin: 0 auto;" src="' + DataChart8 + '">';
                    //windowContent += '<img style="display:block; margin: 0 auto;" src="' + DataChart81 + '">';
                    windowContent += '</div>'
                    windowContent += '</body>';
                    windowContent += '</html>';
                    var printWin = window.open('','','width=800,height=600');
                    printWin.document.open();
                    printWin.document.write(windowContent);
                    printWin.addEventListener('load', function(){printWin.print(); printWin.close(); }, false);
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