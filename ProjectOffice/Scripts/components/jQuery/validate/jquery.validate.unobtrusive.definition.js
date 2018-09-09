var settings = {
    errorElement: "span",
    errorClass: "help-block",
    errorPlacement: function (error, element) {
        var elm = $(element);
        var parent = elm.closest('.input-group,.input-group-custom');

        if (elm.parent('.input-group').length || elm.parent('.input-group-custom').length) {
            error.insertAfter(elm.parent());
        }
        else if (elm.prop('type') === 'checkbox' || elm.prop('type') === 'radio') {
            error.appendTo(elm.closest(':not(input, label, .checkbox, .radio)').first());
        } else {
            error.insertAfter(elm);
        }
    },
    submitHandler: function (form) {
        showLoading();
        form.submit();
    }
}
$.validator.unobtrusive.options = settings;