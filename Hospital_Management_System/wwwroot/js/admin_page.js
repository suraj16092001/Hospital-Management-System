$(document).ready(function () {

    get();
});


function get() {
    debugger;
    // Destroy the existing DataTable
    if ($.fn.DataTable.isDataTable('#myTable')) {
        $('#myTable').DataTable().destroy();
    }

    $.ajax({

        type: "GET",
        url: "/AdminPage/AdminList",

        success: function (data) {
            $('#myTable').DataTable({
                data: data,
                columns: [
                    { data: 'AdminPage.id' },
                    { data: 'User.name' },
                    { data: 'User.email' },
                    {
                        data: null,
                        render: function (data, type, row) {
                            return `<button type="button" onclick="popupdatedata(` + row.AdminPage.id + `)" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#updatemodal"><i class="fa-solid fa-pen-to-square"></i></button>|<button type="button" onclick="ViewAdmin(` + row.AdminPage.id + `)" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#Viewmodal"><i class="fa-solid fa-eye"></i></button>|<button type="button" onclick="DeleteAdmin(` + row.AdminPage.id + `)" class="btn btn-primary" ><i class="fa-solid fa-trash-can-arrow-up"></i></button>`;
                        }
                    }
                ]
            });
        },
        error: function (textStatus, errorThrown) {
            Success = false;
        }
    });
}

function ClearForm() {

    $('#name').val('');
    $('#email').val('');
    $('#password').val('');
    $('#phone').val('');
    $('#DOB').val('');
    $('#address').val('');
    $('#gender').val('');

}

function AddAdmin() {

    if ($("#AddAdmin").valid()) {
        var oModel = {
            User: {
                name: $('#name').val(),
                email: $('#email').val(),
                password: $('#password').val(),
            },
            AdminPage: {
                phone: $('#phone').val(),
                DateOfBirth: $('#DOB').val(),
                gender: $('#gender').val(),
                address: $('#address').val(),
            }
        }
        debugger;
        debugger;
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, add it!"
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: "POST",
                    url: "/AdminPage/AddAdmin",
                    contentType: "application/json",
                    data: JSON.stringify(oModel),
                    dataType: 'json',
                    cache: false,
                    async: false,
                    success: function (data) {
                        if (data.status === "success") {
                            alert(data.message);
                        }
                        else if (data.status === "warning") {
                            alert(data.message);
                        }
                        $('#AdminModal').modal('hide');
                        get();
                        ClearForm();
                    },
                    error: function (error) {
                        console.log("Error saving User:", error);
                        Swal.fire("Oops", "An error occurred while saving your data, Please try again later.", "error");
                    }
                });
            }
        });
    }
}

function DeleteAdmin(id) {
    // var ans = confirm("are you sure you want to delete this record?");
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                type: "POST",
                url: "/AdminPage/DeleteAdmin/" + id,
                success: function (data) {

                    swal.fire("Admin deleted successfully!", {
                        icon: "success",
                    }).then(() => {
                        get(); // refresh data after deletion
                    });
                },
                error: function (errormessage) {
                    swal.fire({
                        title: "error while delete admin",
                        text: "close",
                        icon: "error"
                    });
                }
            });
        }
    });
}


function popupdatedata(id) {
    debugger;

    $.ajax({
        type: "POST",
        url: "/AdminPage/GetAdminByID/" + id,
        success: function (data) {
            $('#u_id').val(data.AdminPage.id);
            $('#u_name').val(data.User.name);
            $('#u_email').val(data.User.email);
            $('#u_gender').val(data.AdminPage.gender);
            $('#u_phone').val(data.AdminPage.phone);
            var date = moment(data.AdminPage.DateOfBirth);
            $('#u_DOB').val(date.format('YYYY-MM-DD'));
            $('#u_address').val(data.AdminPage.address);
        }
    });
}


function UpdateAdmin() {
    debugger;

    var updatedModel = {
        User: {
            name: $('#u_name').val(),
            email: $('#u_email').val(),
        },
        AdminPage: {
            id: $('#u_id').val(),
            gender: $('#u_gender').val(),
            phone: $('#u_phone').val(),
            DateOfBirth: $('#u_DOB').val(),
            address: $('#u_address').val()
        }
    };

    console.log(updatedModel);
    debugger;
    $.ajax({
        type: "POST",
        url: "/AdminPage/UpdateAdmin",
        data: JSON.stringify(updatedModel),
        contentType: 'application/json',  // Set the content type to application/json
        cache: false,
        success: function (data) {
            $('#updatemodal').modal('hide');
            Swal.fire({
                title: "Good job!",
                text: "Admin update successfully!",
                icon: "success",
                button: "Ok",
            });

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


function ViewAdmin(id) {
    debugger;

    $.ajax({
        type: "POST",
        url: "/AdminPage/GetAdminByID/" + id,
        success: function (data) {
            $('#v_id').val(data.AdminPage.id);
            $('#v_name').val(data.User.name);
            $('#v_email').val(data.User.email);
            $('#v_phone').val(data.AdminPage.phone);
            var date = moment(data.AdminPage.DateOfBirth);
            $('#v_DOB').val(date.format('YYYY-MM-DD'));
            $('#v_address').val(data.AdminPage.address);
            $('#v_gender').val(data.AdminPage.gender);
        }

    });
}

