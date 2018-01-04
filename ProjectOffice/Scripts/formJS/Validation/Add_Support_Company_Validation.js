$(document).ready(function () {
    $('#Add_Support_Company_Form')
        .on('submit', function (e) {
            e.preventDefault();

            submitForm(e, "addSupportCompanyResponse");
        });
});

function addSupportCompanyResponse(message, results) {
    var applicationSupportCompany = document.getElementById("Application_Support_Company_ID");

    $.each(results, function (key, value) {
        var option = document.createElement('option');
        option.text = this.Support_Company_Name;
        option.value = this.Support_Company_ID;

        applicationSupportCompany.add(option, 0);
    });

    $('#Support_Company_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
}