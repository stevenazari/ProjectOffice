$(document).ready(function () {
    $('#Add_Support_Company_Form')
        .on('submit', function (e) {
            e.preventDefault();

            submitForm(e, "addSupportCompanyResponse");
        });
});

function addSupportCompanyResponse(message, results) {
    var applicationSupportCompany = document.getElementById("Application_Support_Company_ID");

    $.each(results, function (key, value) {
        var option = document.createElement('option');
        option.text = this.Name;
        option.value = this.ID;

        applicationSupportCompany.add(option, 0);
    });

    //$('#Support_Company_Submit').prop('disabled', true);

    if (message == "Success") {
        $('#Support_Company_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Support_Company_Success_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Support_Company_Success_Message").slideUp(500);
        });
    } else {
        $('#Support_Company_Error_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Support_Company_Error_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Support_Company_Error_Message").slideUp(500);
        });
    }
}