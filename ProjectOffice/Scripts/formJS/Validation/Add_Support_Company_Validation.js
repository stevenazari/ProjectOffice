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
        $.post($form.attr('action'), $form.serialize(), function (result) {
            console.log(result);
        }, 'json');

        $('#Support_Success_Message').slideDown({ opacity: "show" }, "slow") // Do something ...
        clearForm($('#Support_Success_Message'));
    });
});

function clearForm($form) {
    $('#Add_Support_Company_Form').validator('destroy');
    $('#Add_Support_Company_Form').validator('options');
    $('#Add_Support_Company_Form')[0].reset();
}