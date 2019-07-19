$(function () {
    $("#btnProceedToRecharge").click(function (e) {
        e.preventDefault();
        var _this = $(this);
        var _form = _this.closest("form");

        if (_form.validate().valid()) {
            //$.post(_form.attr("action"), _form.serialize(), function (data) {
            //    //check the result and do whatever you want
            //});
            loadRechargeDetailPreview();
        }
    });
});

$(document).ajaxStart(function () {
    $("#loading").show();
});

$(document).ajaxComplete(function () {
    $("#loading").hide();
});