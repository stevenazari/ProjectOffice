$(document).ready(function () {
    $('#Add_Support_Company_Form')
        .on('submit', function (e) {
            e.preventDefault();

            var items = submitForm(e);
            console.log(items);

            $.each(items, function (key, value) {
                alert("ID: " + this.ID);
                var rows = "<tr id='SupportRow" + this.ID + "'>" +
                    "<td class='table-list-td'>" + this.ID + "</td>" +
                    "<td class='table-list-td'>" + this.Name + "</td>" +
                    "<td class='table-list-td'>" + this.Address_1 + "</td>" +
                    "<td class='table-list-td'>" + this.Address_2 + "</td>" +
                    "<td class='table-list-td'>" + this.Post_Code + "</td>" +
                    "<td class='table-list-td'>" + this.Tel + "</td>" +
                    "<td class='table-list-td'>" + this.Email + "</td>" +
                    "<td class='table-list-td'>" + this.Website + "</td>" +
                    "<td class='table-list-td'>" + this.Out_Of_Hours + "</td>" +
                    "<td class='table-list-td'>" + this.Comment + "</td>" +
                    "</tr>";
                $("#SupportCompanies tr:first").after(rows);
            });

            $('#Support_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        });
});