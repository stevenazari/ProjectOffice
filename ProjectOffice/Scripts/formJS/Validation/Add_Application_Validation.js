$(document).ready(function () {
    $('#Add_Application_Form')
        .on('submit', function (e) {
            e.preventDefault();

            submitForm(e, "addApplicationResponse");
        });
});

function addApplicationResponse(message, results) {
    $.each(results, function (key, value) {
        alert("ID: " + this.ID);
        var rows = "<tr id='environment" + this.Environment_ID + "'>" +
            "<td class='table-list-td'>" + this.Application_Name + "</td>" +
            "<td class='table-list-td'>" + this.Support_Company_Name + "</td>" +
            "<td class='table-list-td'>" + this.Application_Type + "</td>" +
            "<td class='table-list-td'>" + this.IP_Address + "</td>" +
            "<td class='table-list-td'>" + this.Application_Comment + "</td>" +
            "</tr>";
        $("#environmentsTable tr:first").after(rows);
    });

    alert(message);
    $('#Server_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
}