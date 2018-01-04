function submitForm(formObject, callback) {
    // Prevent form submission
    $("#loading").show();

    // Get the form instance
    var form = $(formObject.target);
    var formResults = {};
    var message = "";

    // Get the BootstrapValidator instance
    var bv = form.data('bootstrapValidator');

    doAjax(form, callback);
}

function doAjax(form, callback) {
    var message = "";
    var results = "";

    // Use Ajax to submit form data
    $.ajax({
        url: form.attr('action'),
        dataType: 'json',
        data: form.serialize(),
        type: 'POST',
        success: function(ajaxResults){
            message = ajaxResults.message;
            results = JSON.parse(ajaxResults.results);
            window[callback](message, results);
        },
        error: function (err) {
            message = "There was an error: " + err;
            window[callback](message, results);
        }
    });
    clearForm(form);
    $("#loading").hide();
}
function clearForm(form) {
    form.validator('destroy');
    form.validator('validate');
    form.trigger('reset');
}