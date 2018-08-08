function Add_Item(form, submit, response) {
    $(form)
    .on('submit', function (e) {
        e.preventDefault();

        Validate_Submit(e, submit, response, form);
        refreshDetails(form.ID);
    });
}

function Delete_Item(form, submit, response) {
    $(form)
    .on('submit', function (e) {
        e.preventDefault();

        Validate_Submit(e, submit, response, form);
        refreshDetails(form.ID);
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
function refreshDetails(row, $detail) {
 /*   $table.('expand-row.bs.table', function (e, index, row, $detail) {
        $detail.html('Loading from ajax request...');

        $.ajax({
            type: 'POST',
            url: '@Url.Content("/Environment/EnvironmentDetails")',
            data: row,
            success: function (data) {
                $detail.html(data);
            }
        })

    });
*/
}
