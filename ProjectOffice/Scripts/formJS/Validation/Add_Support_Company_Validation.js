$(document).ready(function(){
    $('#Add_Support_Company_Form')
    .on('submit', function(e){
        // Prevent form submission
        e.preventDefault();

       // Get the form instance
        var $form = $(e.target);

        // Get the BootstrapValidator instance
        var bv = $form.data('bootstrapValidator');

        // Use Ajax to submit form data
 //       alert($form.serialize());
        $.post($form.attr('action'), $form.serialize(), function (result) {
            console.log(result);
        }, 'json');

        $('#Support_Success_Message').slideDown({ opacity: "show" }, "slow") // Do something ...

        clearForm($form);
    });
});