$(document).ready(function () {
    popupdatedata();
});


function popupdatedata() {
    debugger;

    $.ajax({
        type: "GET",
        url: "/PatientProfile/GetPatient_Profile",
        success: function (data) {
            $('#u_Id').val(data.User.id);
            $('#name').val(data.User.name);
            $('#email').val(data.User.email);
            $('#gender').val(data.Admin_PatientPage.gender);
            $('#contact').val(data.Admin_PatientPage.phone);
            var date = moment(data.Admin_PatientPage.DateOfBirth);
            $('#DOB').val(date.format('YYYY-MM-DD'));
            $('#address').val(data.Admin_PatientPage.address);
        }
    });
}

function UpdateProfile() {
    debugger;
    if ($("#PatientProfile").valid()) {
        var updatedModel = {
            User: {
                id: $('#u_Id').val(),
                name: $('#name').val(),
                email: $('#email').val(),
            },
            Admin_PatientPage: {

                gender: $('#gender').val(),
                phone: $('#contact').val(),
                DateOfBirth: $('#DOB').val(),
                address: $('#address').val()
            }
        };

        $.ajax({
            type: "POST",
            url: "/PatientProfile/UpdatePatient",
            data: JSON.stringify(updatedModel),
            contentType: 'application/json',  // Set the content type to application/json
            cache: false,
            success: function (data) {
                $('#updatemodal').modal('hide');
                if (data.status === "success") {
                    alert(data.message);
                }
                else if (data.status === "warning") {
                    alert(data.message);
                }
                // datatable.destroy();
                get();
            },
            error: function () {
                Swal.fire({
                    title: "Error while updating!",
                    text: "close",
                    icon: "error"
                });
            }
        });
    }
}