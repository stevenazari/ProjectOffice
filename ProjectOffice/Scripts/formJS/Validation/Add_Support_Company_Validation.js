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
                success: function (JSONResult) {
                    //$("#SupportCompanies tr").remove();
                    var items = JSON.parse(JSONResult.results);
                    var rows = ""
                   
                    $.each(items, function (name, item) {
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