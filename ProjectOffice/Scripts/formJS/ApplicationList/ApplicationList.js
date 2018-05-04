$(document).ready(function () {
    $(document)
        .on('submit', '.environmentForm', function (e) {
            e.preventDefault();

            submitForm(e, "removeEnvironmentResponse");
        });

});



function removeEnvironmentResponse(message, results) {
    $.each(results, function (key, value) {
       if (message == "Success") {
           $("#Application_List_Success_Message_" + this.Environment_ID).slideDown({ opacity: "show" }, "slow"); // Do something ...

           $("#environmentDetailsDiv_" + this.Environment_ID).fadeTo(5000, 500).slideUp(500, function () {
               $("#environmentDetailsDiv_" + this.Environment_ID).slideUp(500, function () {
                   $(this).remove();
                });
            });
            $("#environmentHead_" + this.Environment_ID).remove();
        } else {
            $("#Application_List_Error_Message_" + this.Environment_ID).slideDown({ opacity: "show" }, "slow"); // Do something ...
            $("#Application_List_Error_Message_" + this.Environment_ID).fadeTo(5000, 500).slideUp(500, function () {
               $("#Application_List_Error_Message_" + this.Environment_ID).slideUp(500);
            });
        }
    });
}