$(document).ready(function () {
    $('#Create_Server_Form')
    .on('submit', function (form) {
        form.preventDefault();
        form.stopImmediatePropagation();

        var Server_Submit = document.getElementById("Create_Server_Submit");

        Validate_Submit(form, Server_Submit, "Server_Response");
    });
});

function Add_Server_Response(message, results, form) {
    if (message === "Success") {
        $('#Add_Server_Form').trigger("reset");
        $('#Add_Server_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Add_Server_Success_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Add_Server_Success_Message").slideUp(500);
        });
    } else {
        var content = document.createTextNode(message);
        $('#Add_Server_Error_Message').append(content);

        $('#Add_Server_Error_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Add_Server_Error_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Add_Server_Error_Message").slideUp(500);
        });
    }

}

function Server_Response(message, results, form) {
    if (message === "Success") {
        $('#Create_Server_Form').trigger("reset");
        $('#Server_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Server_Success_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Server_Success_Message").slideUp(500);
        });
    } else {
        var content = document.createTextNode(message);
        $('#Add_Server_Error_Message').append(content);

        $('#Server_Error_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Server_Error_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Server_Error_Message").slideUp(500);
        });
    }

}