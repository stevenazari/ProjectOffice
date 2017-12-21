$(document).ready(function () {
    $('#Add_Support_Company_Form')
        .on('submit', function (e) {
            // Prevent form submission
            e.preventDefault();

            // Get the form instance
            var $form = $(e.target);

            // Get the BootstrapValidator instance
            var bv = $form.data('bootstrapValidator');

            // Use Ajax to submit form data
            $.ajax({
                url: $form.attr('action'),
                dataType: 'json',
                data: $form.serialize(),
                type: 'POST',
                success: function (SupportCompanies) {
                    $("#SupportCompanies tr").remove();
                    var items = '';

                    var rows = "<tr id='SupportHeadRow'>" +
                        "<th class='table-list-th'>ID</th>" +
                        "<th class='table-list-th'>Support Name</th>" +
                        "<th class='table-list-th'>Address 1</th>" +
                        "<th class='table-list-th'>Address 2</th>" +
                        "<th class='table-list-th'>Post Code</th>" +
                        "<th class='table-list-th'>Tel</th>" +
                        "<th class='table-list-th'>Email</th>" +
                        "<th class='table-list-th'>Website</th>" +
                        "<th class='table-list-th'>Contract</th>" +
                        "<th class='table-list-th'>Comment</th>" +
                        "</tr>";
                    $('#SupportCompanies').append(rows);

                    $.each(SupportCompanies, function (i, item) {
                        var rows = "<tr id='SupportRow" + item.SupportID + "'>" +
                            "<td class='table-list-td'>" + item.SupportID + "</td>" +
                            "<td class='table-list-td'>" + item.SupportName + "</td>" +
                            "<td class='table-list-td'>" + item.SupportAddress1 + "</td>" +
                            "<td class='table-list-td'>" + item.SupportAddress2 + "</td>" +
                            "<td class='table-list-td'>" + item.SupportPostCode + "</td>" +
                            "<td class='table-list-td'>" + item.SupportTel + "</td>" +
                            "<td class='table-list-td'>" + item.SupportEmail + "</td>" +
                            "<td class='table-list-td'>" + item.SupportWebsite + "</td>" +
                            "<td class='table-list-td'>" + item.SupportContract + "</td>" +
                            "<td class='table-list-td'>" + item.SupportComment + "</td>" +
                            "</tr>";
                        $('#SupportCompanies').append(rows);
                    });

                    $("#imgLoading").hide();
                    $('#Support_Success_Message').slideDown({ opacity: "show" }, "slow"); // Do something ...
                },
                error: function (message) {
                    alert("There was an error: " + message);
                }
            });

            clearForm($form);
        });
});

function clearForm(form) {
    form.validator('destroy');
    form.validator('validate');
    form.trigger('reset');
}