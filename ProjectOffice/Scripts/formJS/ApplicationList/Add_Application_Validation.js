$(document).ready(function () {
    $('#Add_Application_Form')
        .on('submit', function (e) {
            e.preventDefault();

            var Application_Submit = document.getElementById("Application_Submit");

            if (Application_Submit.classList.contains("disabled") == false) {
                submitForm(e, "addApplicationResponse");
            }
        });
});

function addApplicationResponse(message, results) {
    var environmentApplication = document.getElementById("Environment_Application_ID");

    $.each(results, function (key, value) {
        var option = document.createElement('option');
        option.text = this.Name;
        option.value = this.ID;

        environmentApplication.add(option, 0);
    });

    //$('#Application_Company_Submit').prop('disabled', true);

    if (message == "Success") {
        $('#Application_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Application_Success_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Application_Success_Message").slideUp(500);
        });
    } else {
        $('#Application_Error_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Application_Error_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Application_Error_Message").slideUp(500);
        });
    }
}