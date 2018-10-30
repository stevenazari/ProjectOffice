$(document).ready(function () {
    $('#Create_Application_Form')
        .on('submit', function (e) {
            e.preventDefault();

            var Application_Submit = document.getElementById("Application_Submit");

            if (Application_Submit.classList.contains("disabled") === false) {
                submitForm(e, "Create_Application_Response");
            }
        });
});

function Create_Application_Response(message, results, form) {
    if (message === "Success") {
        $('#Create_Application_Form').trigger("reset");
        $('#Application_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Application_Success_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Application_Success_Message").slideUp(500);
        });
    } else {
        var content = document.createTextNode(message);
        $('#Application_Error_Message').append(content);

        $('#Application_Error_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Application_Error_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Application_Error_Message").slideUp(500);
        });
    }
}

function Add_Application_Response(message, results, form) {
    if (message === "Success") {
        $('#Add_Application_Form').trigger("reset");
        $('#Add_Application_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Add_Application_Success_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Add_Application_Success_Message").slideUp(500);
        });
    } else {
        var content = document.createTextNode(message);
        $('#Add_Application_Error_Message').append(content);

        $('#Add_Application_Error_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Add_Application_Error_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Add_Application_Error_Message").slideUp(500);
        });
    }

}

