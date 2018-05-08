$(document).ready(function () {
    $('#Add_Server_Form')
        .on('submit', function (e) {
            e.preventDefault();

            var Server_Submit = document.getElementById("Server_Submit");

            if (Server_Submit.classList.contains("disabled") == false) {
                submitForm(e, "addServerResponse");
            }
        });
});

function addServerResponse(message, results) {
    var environmentServer = document.getElementById("Environment_Server_ID");

    $.each(results, function (key, value) {
        var option = document.createElement('option');
        option.text = this.Name;
        option.value = this.ID;

        environmentServer.add(option, 0);
    });

    //$('#Server_Submit').prop('disabled', true);

    if (message == "Success") {
        $('#Server_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Server_Success_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Server_Success_Message").slideUp(500);
        });
    } else {
        $('#Server_Error_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Server_Error_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Server_Error_Message").slideUp(500);
        });
    }

}