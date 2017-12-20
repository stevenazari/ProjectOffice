$(document).ready(function () {
    $('#Add_Server_Form').bootstrapValidator({
        // To use feedback icons, ensure that you use Bootstrap v3.1.0 or later
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            Server_Name: {
                validators: {
                    stringLength: {
                        min: 2,
                    },
                    notEmpty: {
                        message: 'Please supply server name'
                    }
                }
            },
            Server_IP_Address: {
                validators: {
                    stringLength: {
                        min: 5,
                    },
                    notEmpty: {
                        message: 'Please supply server IP address'
                    }
                }
            },
            Server_Operating_System: {
                validators: {
                    notEmpty: {
                        message: 'Please choose operating system'
                    }
                }
            },
            Server_Type: {
                validators: {
                    stringLength: {
                        min: 8,
                    },
                    notEmpty: {
                        message: 'Please supply your street address'
                    }
                }
            },
            Server_Status: {
                validators: {
                    notEmpty: {
                        message: 'Please state if enabled or disabled'
                    }
                }
            },
            Server_Comment: {
                validators: {
                    stringLength: {
                        min: 10,
                        max: 200,
                        message: 'Please enter at least 10 characters and no more than 200'
                    },
                    notEmpty: {
                        message: 'Please supply a description of the server'
                    }
                }
            }
        }
    })
        .on('success.form.bv', function (e) {
            alert("test");
            $('#Server_Success_Message').slideDown({ opacity: "show" }, "slow") // Do something ...
//            $('#Add_Server_Form').data('bootstrapValidator').resetForm();

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