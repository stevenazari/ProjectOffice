$(document).ready(function () {
    $('#Add_Application_Form').bootstrapValidator({
        // To use feedback icons, ensure that you use Bootstrap v3.1.0 or later
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            // Application validation
            Application_Name: {
                validators: {
                    stringLength: {
                        min: 2,
                    },
                    notEmpty: {
                        message: 'Please supply application name'
                    }
                }
            },
            Application_Version: {
                validators: {
                    stringLength: {
                        min: 1,
                    },
                    notEmpty: {
                        message: 'Please supply version number'
                    }
                }
            },
            Application_Package_Type_ID: {
                validators: {
                    notEmpty: {
                        message: 'Please choose a package type'
                    }
                }
            },
            Application_Support_Company_ID: {
                validators: {
                    notEmpty: {
                        message: 'Please select a support company, or create a new one'
                    }
                }
            },
            Application_Status: {
                validators: {
                    notEmpty: {
                        message: 'Please state status'
                    }
                }
            },
            Application_Comment: {
                validators: {
                    stringLength: {
                        min: 10,
                        max: 200,
                        message: 'Please enter at least 10 characters and no more than 200'
                    },
                    notEmpty: {
                        message: 'Please supply a description of the application'
                    }
                }
            }
        }
    })
        .on('success.form.bv', function (e) {
            $('#Application_Success_Message').slideDown({ opacity: "show" }, "slow") // Do something ...
            $('#Add_Application_form').data('bootstrapValidator').resetForm();

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