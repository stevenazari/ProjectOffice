$(document).ready(function () {
    $('#Add_Support_Company_Form').bootstrapValidator({
        // To use feedback icons, ensure that you use Bootstrap v3.1.0 or later
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            Support_Name: {
                validators: {
                    stringLength: {
                        min: 2,
                        message: 'Please supply company name'
                    },
                    notEmpty: {
                        message: 'Please supply company name'
                    }
                }
            },
            Support_Email: {
                validators: {
                    notEmpty: {
                        message: 'Please supply a valid email address'
                    },
                    emailAddress: {
                        message: 'Please supply a valid email address'
                    }
                }
            },
            Support_Contract: {
                validators: {
                    notEmpty: {
                        message: 'Do we have a valid support contract?'
                    }
                }
            },
            Support_Comment: {
                validators: {
                    stringLength: {
                        min: 10,
                        max: 200,
                        message: 'Please enter at least 10 characters and no more than 200'
                    },
                    notEmpty: {
                        message: 'Please supply a description of the support company'
                    }
                }
            }
        }
    })
        .on('success.form.bv', function (e) {
            $('#Support_Success_Message').slideDown({ opacity: "show" }, "slow") // Do something ...
            $('#Add_Support_Company_Form').data('bootstrapValidator').resetForm();

            // Prevent form submission
            e.preventDefault();

            // Get the form instance
            var $form = $(e.target);

            // Get the BootstrapValidator instance
            var bv = $form.data('bootstrapValidator');

            // Use Ajax to submit form data
            $.post($form.attr('action'), $form.serialize(), function (result) {
                console.log(result);
            }, 'json');
        });
});