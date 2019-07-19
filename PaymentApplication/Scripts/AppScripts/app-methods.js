function loadRechargeDetailPreview() {

    var modelData = {
        MobileNumber: $('#MobileNumber').val(),
        MobileOperator: $('#MobileOperator').val(),
        MobileCircle: $('#MobileCircle').val(),
        Amount: $('#Amount').val(),
    };

    $.ajax({
        url: '/Services/MobileRechargePreview',
        type: 'GET',
        data: modelData,
        cache: false,
        //context: myDiv,
        success: function (result) {
            $('#dvRechargePreview').html(result);
            $('#dvRechargeInput').hide();
        }
    });
}