$(document).ready(function () {
    $('#Add_Environment_Form')
        .on('submit', function (e) {
            e.preventDefault();

            var Environment_Submit = document.getElementById("Environment_Submit");

            if (Environment_Submit.classList.contains("disabled") == false) {
                submitForm(e, "addEnvironmentResponse");
            }
        });
});

function addEnvironmentResponse(message, results) {
    $.each(results, function (key, value) {
        var table = document.getElementById("environmentsBody");

        var headRow = table.insertRow(0);
            headRow.setAttribute("id", "environmentHead_" + this.Environment_ID, 0);
            headRow.setAttribute("class", "m-top-20", 0);
            headRow.setAttribute("data-toggle", "collapse", 0);
            headRow.setAttribute("data-target", "#environmentDetailsDiv_" + this.Environment_ID, 0);
            headRow.setAttribute("aria-expanded", "false", 0);
            headRow.setAttribute("aria-controls", "environmentContainer_" + this.Environment_ID, 0);

        var headCell1 = headRow.insertCell(0);
            headCell1.setAttribute("class", "table-list-td", 0);
        var headCell2 = headRow.insertCell(1);
            headCell2.setAttribute("class", "table-list-td", 0);
        var headCell3 = headRow.insertCell(2);
            headCell3.setAttribute("class", "table-list-td", 0);
        var headCell4 = headRow.insertCell(3);
            headCell4.setAttribute("class", "table-list-td", 0);
        var headCell5 = headRow.insertCell(4);
            headCell5.setAttribute("class", "table-list-td", 0);
        var headCell6 = headRow.insertCell(5);
            headCell6.setAttribute("class", "table-list-td", 0);

        headCell1.innerHTML = "<h5>" + this.Application_Name + "</h5>";
        headCell2.innerHTML = "<h5>" + this.Environment_Type + "</h5>";
        headCell3.innerHTML = "<h5>" + this.Server_Type + "</h5>";
        headCell4.innerHTML = "<h5>" + this.Server_Name + "</h5>";
        headCell5.innerHTML = "<h5>" + this.Environment_Comment + "</h5>";
        headCell6.innerHTML = "<h5>" + this.Support_Company_Name + "</h5>";

        var bodyRow = table.insertRow(1);
            bodyRow.setAttribute("id", "EnvironmentDetails_" + this.Environment_ID, 0);
        var bodyCell1 = bodyRow.insertCell(0);
            bodyCell1.setAttribute("class", "table-list-td", 0);
            bodyCell1.setAttribute("colspan", "6", 0);

            bodyCell1.innerHTML = "<div id='environmentDetailsDiv_" + this.Environment_ID + "' class='collapse'>" +
                "<div class='jumbotron'>" +
                    "<form role='form' class='environmentForm' data-toggle='validator' method='post' action='/ApplicationsList/Update' name='environmentForm' id='environmentForm_" + this.Environment_ID + "' novalidate='true'>" +
                        "<p>" +
                            "<h5>Details for " + this.Application_Name + " " + this.Environment_Type + " environment<br /></h5>" +
                            "<input name='ID' id='ID_" + this.Environment_ID + "' type='hidden' value='" + this.Environment_ID + "' />" +
                            "<input name='Application_ID' id='Application_ID_" + this.Environment_ID + "' type='hidden' value='" + this.Application_ID + "' />" +
                            "<input name='Server_ID' id='Server_ID_" + this.Environment_ID + "' type='hidden' value='" + this.Server_ID + "' />" +
                            "<input name='Environment_Type_ID' id='Environment_Type_ID_" + this.Environment_ID + "' type='hidden' value='" + this.Environment_Type_ID + "' />" +
                            "<input name='Support_Company_ID' id='Support_Company_ID_" + this.Environment_ID + "' type='hidden' value='" + this.Support_Company_ID + "' />" +
                            "<input name='Comment' id='Comment_" + this.Environment_ID + "' type='hidden' value='" + this.Environment_Comment + "' />" +
                            "<input name='Deleted' id='Deleted_" + this.Environment_ID + "' type='hidden' value='" + this.Environment_Deleted + "' />" +
                            "<b>Environment Created:</b> " + this.Environment_Created + " <br />" +
                            "<b>Application Comment:</b> " + this.Application_Comment + " <br />" +
                            "<b>Application Package Type:</b> " + this.Application_Type + " <br /><br />" +
                            "<b>Server:</b> " + this.Server_Name + " <br />" +
                            "<b>Server Type:</b> " + this.Server_Type + " <br />" +
                            "<b>Server Address:</b> " + this.IP_Address + " <br />" +
                        "</p>" +
                        "<div class='btn-group' role='group' aria-label='...'>" +
                            "<button type='button' class='btn btn-danger' name='Delete' id='Delete_" + this.Environment_ID + "' onclick=\"updateEnvironment('Delete', " + this.Environment_ID + ")\"> Delete <span class='glyphicon glyphicon-warning-sign'></span></button>" +
                        "</div >" +
                    "</form>" +
                "</div>" +
                "<!--Success message -->" +
                "<div class='alert alert-success collapse' role='alert' id='Application_List_Success_Message_" + this.Environment_ID + "'>" +
                    "message <i class='glyphicon glyphicon-thumbs-up' ></i >" +
                "</div >" +
                "<!--Error message -->" +
                "<div class='alert alert-danger collapse' role='alert' id='Application_List_Error_Message_" + this.Environment_ID + "'>" +
                    "message <i class='glyphicon glyphicon-thumbs-down'></i >" +
                "</div >" +
            "</div>";

//        $("#environmentsTable tbody:first").after(rows);
    });

    if (message == "Success") {
        $('#Environment_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Environment_Success_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Environment_Success_Message").slideUp(500);
        });
    } else {
        $('#Environment_Error_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
        $("#Environment_Error_Message").fadeTo(5000, 500).slideUp(500, function () {
            $("#Environment_Error_Message").slideUp(500);
        });
    }
}