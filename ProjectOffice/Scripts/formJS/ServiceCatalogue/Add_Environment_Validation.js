$(document).ready(function () {
    $('#Add_Environment_Form')
        .on('submit', function (e) {
            e.preventDefault();

            var Environment_Submit = document.getElementById("Create_Environment_Submit");

            if (Environment_Submit.classList.contains("disabled") == false) {
                submitForm(e, "Environment_Response");
            }
        });
});

function Environment_Response(message, results, form) {
    if (message == "Success") {
        $('#Add_Environment_Form').trigger("reset");
        $('#Create_Environment_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Create_Environment_Success_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Create_Environment_Success_Message").slideUp(500);
        });
    } else {
        var content = document.createTextNode(message);
        $('#Create_Environment_Error_Message').append(content);

        $('#Create_Environment_Error_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Create_Environment_Error_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Create_Environment_Error_Message").slideUp(500);
        });
    }
}