$(document).ready(function () {
    popupdatedata();
});


function previewProfile(input) {
    var file = input.files[0];

    if (file) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#ProfileUpdate').attr('src', e.target.result).show();
        };

        reader.readAsDataURL(file);
    } else {
        // Clear the image preview if no file is selected
        $('#ProfileUpdate').attr('src', '').hide();
    }
}

function popupdatedata(id) {
    debugger;

    $.ajax({
        type: "POST",
        url: "/DoctorProfile/GetDoctor_Profile/" + id,
        success: function (data) {
            $('#u_Id').val(data.User.id);
            $('#name').val(data.User.name);
            $('#email').val(data.User.email);
            $('#contact').val(data.admin_Doctor.phone);
            $('#specialist').val(data.admin_Doctor.specialist);
            $('#gender').val(data.admin_Doctor.gender);
            $('#qualification').val(data.admin_Doctor.qualification);
            var date = moment(data.admin_Doctor.DateOfBirth);
            $('#DOB').val(date.format('YYYY-MM-DD'));
            $('#address').val(data.admin_Doctor.address);

            var imagePreview = "/DoctorImages/" + data.admin_Doctor.profileImage;
            $('#ProfileUpdate').attr('src', imagePreview).show();
            console.log(data);
        }

    });
}


function UpdateDoctor() {
    if ($("#DoctorProfile").valid()) {
        var ID = {
            id: $('#u_Id').val(),
        }
        var updatedModel = {
            User: {

                name: $('#name').val(),
                email: $('#email').val(),
            },
            admin_Doctor: {

                phone: $('#contact').val(),
                specialist: $('#specialist').val(),
                gender: $('#gender').val(),
                qualification: $('#qualification').val(),
                DateOfBirth: $('#DOB').val(),
                address: $('#address').val(),
            }
        };

        debugger;

        var formData = new FormData();
        formData.append("Id", ID.id);
        formData.append("model", JSON.stringify(updatedModel));
        formData.append("file", $('#u_ProfileFile')[0].files[0]);

        $.ajax({
            type: "POST",
            url: "/DoctorProfile/UpdateDoctor",
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                if (data.status === "success") {
                    alert(data.message);
                }
                else if (data.status === "warning") {
                    alert(data.message);
                }
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

