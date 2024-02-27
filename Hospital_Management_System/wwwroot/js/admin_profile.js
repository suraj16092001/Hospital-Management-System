$(document).ready(function () {
    popupdatedata();
});


function popupdatedata() {
    debugger;

    $.ajax({
        type: "GET",
        url: "/AdminProfile/GetAdmin_Profile",
        success: function (data) {
            $('#u_Id').val(data.User.id);
            $('#name').val(data.User.name);
            $('#email').val(data.User.email);
            $('#gender').val(data.AdminPage.gender);
            $('#contact').val(data.AdminPage.phone);
            var date = moment(data.AdminPage.DateOfBirth);
            $('#DOB').val(date.format('YYYY-MM-DD'));
            $('#address').val(data.AdminPage.address);
        }
    });
}

function UpdateAdmin() {
    debugger;
    if ($("#AdminProfile").valid()) {
        var updatedModel = {
            User: {
                id: $('#u_Id').val(),
                name: $('#name').val(),
                email: $('#email').val(),
            },
            AdminPage: {

                gender: $('#gender').val(),
                phone: $('#contact').val(),
                DateOfBirth: $('#DOB').val(),
                address: $('#address').val()
            }
        };

        console.log(updatedModel);
        debugger;
        $.ajax({
            type: "POST",
            url: "/AdminProfile/UpdateAdmin",
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