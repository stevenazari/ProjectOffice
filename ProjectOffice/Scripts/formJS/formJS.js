function submitForm(formObject, callback) {
    // Prevent form submission
    $("#loading").show();

    // Get the form instance
    var form = $(formObject.target);

    doAjax(form, callback);
    $("#loading").hide();
}

function doAjax(form, callback) {
    var message = "";
    var results = "";

    formSerialized = form.serialize

    // Use Ajax to submit form data
    $.ajax({
        url: form.attr('action'),
        dataType: 'json',
        data: form.serialize(),
        type: 'POST',

        success: function (ajaxResults) {
            message = ajaxResults.message;
            window[callback](message, JSON.parse(ajaxResults.results));
        },
        error: function (err1) {
            message = "There was an error: " + err1 ;
            window[callback](message, results);
        }
    });
}