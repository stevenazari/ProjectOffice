function submitForm(formObject) {
    // Prevent form submission
    $("#loading").show();

    // Get the form instance
    var form = $(formObject.target);
    var formResults = {};
    var message = "";

    // Get the BootstrapValidator instance
    var bv = form.data('bootstrapValidator');

    doAjax(form, function (ajaxResults) {
        console.log(JSON.parse(ajaxResults.results));
        message = ajaxResults.message;

        clearForm(form);
        $("#loading").hide();

        return JSON.parse(ajaxResults.results);
    });

//    console.log(formResults);
}

function doAjax(form, callback) {
    // Use Ajax to submit form data
    $.ajax({
        url: form.attr('action'),
        dataType: 'json',
        data: form.serialize(),
        type: 'POST',
        success: callback,
        error: function (err) {
            alert("There was an error: " + err);
        }
    });
}
function clearForm(form) {
    form.validator('destroy');
    form.validator('validate');
    form.trigger('reset');
}