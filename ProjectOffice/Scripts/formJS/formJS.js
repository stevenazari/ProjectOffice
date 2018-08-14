function Add_Item(form, submit, response) {
    $(form)
    .on('submit', function (e) {
        e.preventDefault();

        Validate_Submit(e, submit, response, form);
        refreshDetails(e, submit, form);
    });
}

function Delete_Item(form, submit, response) {
    $(form)
    .on('submit', function (e) {
        e.preventDefault();

        Validate_Submit(e, submit, response, form);
        //alert(form.elements.ID.value);
        //refreshDetails(form.elements.ID.value);
    });
}

function Validate_Submit(e, submit, response, form) {
    if (submit.classList.contains("disabled") === false) {
        submitForm(e, response, form);
    }
}

function submitForm(e, callback, form) {
    // Prevent form submission
    $("#loading").show();

    doAjax(e, callback, form);
    $("#loading").hide();
}

function doAjax(e, callback, form) {
    var message = "";
    var results = "";

    // Get the form instance
    var formTarget = $(e.target);

    formSerialized = formTarget.serialize;

    // Use Ajax to submit form data
    $.ajax({
        url: formTarget.attr('action'),
        dataType: 'json',
        data: formTarget.serialize(),
        type: 'POST',

        success: function (ajaxResults) {
            message = ajaxResults.message;
            window[callback](message, JSON.parse(ajaxResults.results), form);
        },
        error: function (err1) {
            message = "There was an error: " + err1;
            window[callback](message, results, form);
        }
    });
}

function itemResponse(message, results, form) {
    var Item_Action = form.elements.Item_Action.value;
    var EI_ID = form.elements.ID.value;

    if (Item_Action === "Delete") {
        var element = document.getElementById("EI_" + EI_ID);
        element.parentNode.removeChild(element);
    }

}
function refreshDetails(e, callback, form) {
    $detail = $("#environmentDetails_" + form.elements.Parent_ID.value).parent();
    var formTarget = $(e.target);

    $detail.html('Loading from ajax request...');

    $.ajax({
        url: "/Environment/EnvironmentDetails",
        data: {Environment_ID : form.elements.Parent_ID.value},
        type: 'POST',

        success: function (ajaxResults) {
            $detail.html(ajaxResults);
        }
    });
}     
