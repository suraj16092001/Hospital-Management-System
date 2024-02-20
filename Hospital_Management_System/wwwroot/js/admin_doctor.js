$(document).ready(function () {
    getDoctorList();
});



function getDoctorList() {
    $.ajax({
        type: "Get",
        url: "/Admin_DoctorPage/DoctorList",
        success: function (data) {
            var cardContainer = $('#cardContainer');
            data.forEach(function (item) {
                var card =
                    `<div class="col-md-4 mb-4">
                        <div class="card h-100 mb-4" onclick="Viewdata(${item.User.id})" data-bs-toggle="modal" data-bs-target="#ViewDoctorModal">
                            <img src="/DoctorImages/${item.admin_Doctor.profileImage}" class="card-img-top" style="width:100%; aspect-ratio:3/2; object-fit:contain" alt="Image">
                                <div class="card-body">
                                <h5 class="card-title fw-bold">${item.User.name}</h5>
                                <p class="card-text">specialist: ${item.admin_Doctor.specialist}</p>
                                <a class="btn btn-primary" onclick="popupdatedata(${item.User.id})" data-bs-toggle="modal" data-bs-target="#UpdateDoctorModal">Edit</a>
                                <a class="btn btn-primary" onclick="Viewdata(${item.User.id})" data-bs-toggle="modal" data-bs-target="#ViewDoctorModal">View</a>
                                <a class="btn btn-primary" onclick="DeleteDoctor(${item.User.id})">Delete</a>
                                </div>
                        </div>
                    </div>`
                    ;
                cardContainer.append(card);
            });
        },
        error: function (textStatus, errorThrown) {
            console.log('Error: ' + textStatus);
        }
    });
}

function AddDoctor() {
    if ($("#AddDoctor").valid()) {
        var oModel = {
            User: {
                name: $('#name').val(),
                email: $('#email').val(),
                password: $('#password').val(),
            },
            admin_Doctor: {
                qualification: $('#qualification').val(),
                specialist: $('#specialist').val(),
                gender: $('#gender').val(),
                phone: $('#phone').val(),
                DateOfBirth: $('#DateOfBirth').val(),
                address: $('#address').val(),
            }
        };

        var formData = new FormData();
        formData.append("model", JSON.stringify(oModel));
        formData.append("file", $('#imageFile')[0].files[0]);
        debugger;
        $.ajax({
            type: "POST",
            url: "/Admin_DoctorPage/AddDoctor",
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data.status === "success") {
                    alert(data.message);
                } else if (data.status === "warning") {
                    alert(data.message);
                }
                ClearAddDoctorForm();
                $('#AddDoctorModal').modal('hide');
                $('#cardContainer').empty();
                getDoctorList();
            },
            error: function (error) {
                console.log("Error saving Doctor:", error);
                Swal.fire("Oops", "An error occurred while saving your data, Please try again later.", "error");
            }
        });
    }
}


function DeleteDoctor(id) {
    // var ans = confirm("Are you sure you want to delete this Record?");
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
                url: "/Admin_DoctorPage/DeleteDoctor/" + id,
                success: function (data) {

                    swal.fire("Doctor deleted successfully!", {
                        icon: "success",
                    }).then(() => {
                        $('#cardContainer').empty();
                        getDoctorList(); // Refresh data after deletion
                    });
                },
                error: function (errormessage) {
                    Swal.fire({
                        title: "error while delete Doctor",
                        text: "close",
                        icon: "error"
                    });
                }
            });
        }
    });
}


function previewImage(input) {
    var file = input.files[0];

    if (file) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imagePreviewUpdate').attr('src', e.target.result).show();
        };

        reader.readAsDataURL(file);
    } else {
        // Clear the image preview if no file is selected
        $('#imagePreviewUpdate').attr('src', '').hide();
    }
}
function popupdatedata(id) {
    debugger;

    $.ajax({
        type: "POST",
        url: "/Admin_DoctorPage/GetDoctorByID/" + id,
        success: function (data) {
            $('#u_id').val(data.User.id);
            $('#u_name').val(data.User.name);
            $('#u_email').val(data.User.email);
            $('#u_phone').val(data.admin_Doctor.phone);
            $('#u_specialist').val(data.admin_Doctor.specialist);
            $('#u_gender').val(data.admin_Doctor.gender);
            $('#u_qualification').val(data.admin_Doctor.qualification);
            var date = moment(data.admin_Doctor.DateOfBirth);
            $('#u_DateOfBirth').val(date.format('YYYY-MM-DD'));
            $('#u_address').val(data.admin_Doctor.address);

            var imagePreview = "/DoctorImages/" + data.admin_Doctor.profileImage;
            $('#imagePreviewUpdate').attr('src', imagePreview).show();
        }

    });
}



function UpdateDoctor() {

    var ID = {
        id: $('#u_id').val(),
    }
    var updatedModel = {
        User: {

            name: $('#u_name').val(),
            email: $('#u_email').val(),
        },
        admin_Doctor: {

            phone: $('#u_phone').val(),
            specialist: $('#u_specialist').val(),
            gender: $('#u_gender').val(),
            qualification: $('#u_qualification').val(),
            DateOfBirth: $('#u_DateOfBirth').val(),
            address: $('#u_address').val(),
        }
    };

    debugger;

    var formData = new FormData();
    formData.append("Id", ID.id);
    formData.append("model", JSON.stringify(updatedModel));
    formData.append("file", $('#u_imageFile')[0].files[0]);

    $.ajax({
        type: "POST",
        url: "/Admin_DoctorPage/UpdateDoctor",
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            $('#UpdateDoctorModal').modal('hide');
            Swal.fire({
                title: "Good job!",
                text: "Doctor update successfully!",
                icon: "success",
                button: "Ok",
            });
            $('#cardContainer').empty();
            getDoctorList();
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

function Viewdata(id) {
    debugger;

    $.ajax({
        type: "GET",
        url: "/Admin_DoctorPage/GetDoctorByID/" + id,
        success: function (data) {
            $('#v_id').val(data.User.id);
            $('#v_name').val(data.User.name);
            $('#v_email').val(data.User.email);
            $('#v_phone').val(data.admin_Doctor.phone);
            $('#v_specialist').val(data.admin_Doctor.specialist);
            $('#v_gender').val(data.admin_Doctor.gender);
            $('#v_qualification').val(data.admin_Doctor.qualification);
            var date = moment(data.admin_Doctor.DateOfBirth);
            $('#v_DateOfBirth').val(date.format('YYYY-MM-DD'));
            $('#v_address').val(data.admin_Doctor.address);
            var imagePreview = "/DoctorImages/" + data.admin_Doctor.profileImage;
            $('#imagePreviewView').attr('src', imagePreview).show();
        }

    });
}


function ClearViewDoctorForm() {
    $('#v_id').val('');
    $('#v_name').val('');
    $('#v_email').val('');
    $('#v_phone').val('');
    $('#v_specialist').val('');
    $('#v_gender').val('');
    $('#v_qualification').val('');
    $('#v_DateOfBirth').val('');
    $('#v_address').val('');
    $('#v_imageFile').val('');

}

function ClearUpdateDoctorForm() {
    $('#u_id').val('');
    $('#u_name').val('');
    $('#u_email').val('');
    $('#u_phone').val('');
    $('#u_specialist').val('');
    $('#u_gender').val('');
    $('#u_qualification').val('');
    $('#u_DateOfBirth').val('');
    $('#u_address').val('');
    $('#u_imageFile').val('');

}

function ClearAddDoctorForm() {

    $('#name').val('');
    $('#email').val('');
    $('#password').val('');
    $('#phone').val('');
    $('#address').val('');
    $('#gender').val('');
    $('#specialist').val('');
    $('#qualification').val('');
    $('#DateOfBirth').val('');
    $('#imageFile').val('');
}