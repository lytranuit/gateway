﻿$(function () { $("li a:not(.noa)").filter(function () { return this.href == location.href }).addClass("active").siblings().removeClass("active"), $("li a:not(.noa)").click(function () { $(this).addClass("active").siblings().removeClass("active") }) }), $(window).on("load resize", function () { $(window).width() < 800 || $(window).height() < 500 ? ($(".taodonhangclass").attr("href", lang + "/crm/tao-moi-don-dat-hang-mobile"), $(".taodonhangkdclass").attr("href", lang + "/crm/tao-don-dat-hang-ve-phong-kinh-doanh-mobile")) : ($(".taodonhangclass").attr("href", lang + "/crm/tao-moi-don-dat-hang"), $(".taodonhangkdclass").attr("href", lang + "/crm/tao-don-dat-hang-ve-phong-kinh-doanh")) }); var toggle = !0; $(".sidebar-icon").click(function () { toggle ? ($(".page-container").addClass("sidebar-collapsed").removeClass("sidebar-collapsed-back"), $("#menu span").css({ position: "absolute" })) : ($(".page-container").removeClass("sidebar-collapsed").addClass("sidebar-collapsed-back"), setTimeout(function () { $("#menu span").css({ position: "relative" }) }, 400)), toggle = !toggle }), $(document).ready(function () { $("[data-mask]").inputmask(), setInterval(function () { $.post(lang + "/he-thong/Beat") }, 1e4), $("#guigopy").click(function () { if ("" != $("#tieude").val() && "" != $("#noidung").val()) { document.getElementById("gopyclose").click(); $.post(lang + "/he-thong/Donggopykien", { tieude: $("#tieude").val(), noidung: $("#noidung").val(), email: $("#email").val() }, function (n) { $.confirm({ title: "<b>CẢM ƠN ĐÃ GÓP Ý CHO WEBSITE</b>", content: "", buttons: { cancel: { text: "Đóng", btnClass: "btn-blue", keys: ["enter", "shift"], action: function () { } } } }) }) } else toastr.options = { closeButton: !1, debug: !1, newestOnTop: !0, progressBar: !0, positionClass: "toast-top-right", preventDuplicates: !1, onclick: null, showDuration: "300", hideDuration: "1000", timeOut: "5000", extendedTimeOut: "1000", showEasing: "swing", hideEasing: "linear", showMethod: "fadeIn", hideMethod: "fadeOut" }, toastr.warning("Xin điền đầy đủ thông tin", "Thông báo") }), $("li a").click(function () { $(".collapse").collapse("hide"), $("li a").not(this).find(".fa").removeClass("open"), $(this).find(".fa").toggleClass("open") }) });