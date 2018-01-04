$(document).ready(function () {
    $('#Add_Environment_Form')
        .on('submit', function (e) {
            e.preventDefault();

            submitForm(e, "addEnvironmentResponse");
        });
});

function addEnvironmentResponse(message, results) {
    $.each(results, function (key, value) {
        var rows = "<tr id='environment" + this.Environment_ID + "'>" +
            "<td class='table-list-td'>" + this.Environment_Comment + "</td>" +
            "<td class='table-list-td'>" + this.Environment_Type + "</td>" +
            "<td class='table-list-td'>" + this.Support_Company_Name + "</td>" +
            "<td class='table-list-td'>" + this.Application_Name + "</td>" +
            "<td class='table-list-td'>" + this.Application_Type + "</td>" +
            "</tr>";
        $("#environmentsTable tr:first").after(rows);
    });

    $('#Environment_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
}