$(document).ready(function () {
    $('#Add_Support_Company_Form')
        .on('submit', function (e) {
            e.preventDefault();

            var submitSupport = document.getElementById("#Support_Company_Submit");

            if (submitSupport.classList.contains("disabled") == false) {
                submitForm(e, "Support_Company_Response");
            }
        });
});

function Support_Company_Response(message, results, form) {
    //$('#Support_Company_Submit').prop('disabled', true);

    if (message == "Success") {
        var applicationSupportCompany = document.getElementById("Application_Support_Company_ID");

        $.each(results, function (key, value) {
            var option = document.createElement('option');
            option.text = this.Name;
            option.value = this.ID;

            applicationSupportCompany.add(option, 0);
        });

        $('#Add_Support_Company_Form').trigger("reset");
        $('#Support_Company_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Support_Company_Success_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Support_Company_Success_Message").slideUp(500);
        });
    } else {
        message = message.replace("object", "Company Name");

        var content = document.createTextNode(message);
        $('#Support_Company_Error_Message').html(content);

        $('#Support_Company_Error_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Support_Company_Error_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Support_Company_Error_Message").slideUp(500);
        });
    }
}