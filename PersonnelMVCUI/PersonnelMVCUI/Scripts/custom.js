$(function () {
    $("#tblDepartments").DataTable();
    $("#tblDepartments").on("click", ".btnDeleteDepartment", function () {
        var btn = $(this);
        bootbox.confirm("Are you sure you want to delete the department?", function (result) {
            if (result) {
                var id = btn.data("id");
                $.ajax({
                    type: "GET",
                    url: "/Department/Delete/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                });
            }
        });
    });
});

function CheckDateTypeIsValid(dateElement) {
    var value = $(dateElement).val();
    if (value == '') {
        $(dateElement).valid("false");
    }
    else {
        $(dateElement).valid();
    }
}