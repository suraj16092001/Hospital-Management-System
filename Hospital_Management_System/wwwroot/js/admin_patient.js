﻿
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
        url: "/Admin_PatientPage/PatientList",
        success: function (data) {
            $('#myTable').DataTable({
                data: data,
                columns: [
                    { data: 'User.id' },
                    { data: 'User.name' },
                    { data: 'User.email' },
                    // { data: 'Admin_PatientPage.phone' },
                    // { data: 'Admin_PatientPage.address' },
                    {
                        data: null,
                        render: function (data, type, row) {
                            return `<button type="button" onclick="popupdatedata(` + row.User.id + `)" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#updatemodal"><i class="fa-solid fa-pen-to-square"></i></button>|<button type="button" onclick="ViewModal(` + row.User.id + `)" class="btn btn-info" data-bs-toggle="modal" data-bs-target="#ViewModal"><i class="fa-solid fa-eye"></i></button>|<button type="button" onclick="DeletePatient(` + row.User.id + `)" class="btn btn-danger" ><i class="fa-solid fa-trash-can-arrow-up"></i></button>|<button type="button" class="btn btn-secondary"  data-bs-toggle="modal" data-bs-target="#appointmentModal"><i class="fa-solid fa-clipboard-list"></i></button>`;
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

function BookAppointment() {
    var oModel = {
        doctor: $('#a_doctor').val(),
        disease: $('#a_disease').val(),
        appointment_date: $('#a_appointment_date').val(),
        appointment_time: $('#a_appointment_time').val(),
    }

    debugger;
    var formData = new FormData();
    for (var key in oModel) {
        formData.append(key, oModel[key])
    }
    $.ajax({
        type: "POST",
        url: "/Admin_PatientPage/BookAppointment",
        data: formData,
        processData: false,
        contentType: false,
        cache: false,
        success: function (data) {

            Swal.fire({
                title: "Good job!",
                text: "Appointment saved successfully!",
                icon: "success",
                button: "Ok",
            });
            $('#appointmentModal').modal('hide');
            get();
        },
        error: function (error) {
            console.log("Error saving employee:", error);
            Swal.fire("Oops", "An error occurred while saving your data, Please try again later.", "error");
        }
    })
}

function FetchDoctors(specialist) {
    debugger;
    $.ajax({
        url: '/Admin_PatientPage/GetDoctors',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ specialist: specialist }),
        success: function (data) {
            var dropdown = $('#a_doctor');
            dropdown.empty();

            $.each(data, function (i, doctor) {
                dropdown.append($('<option></option>').text(doctor.name));
            });
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
}



function AddPatient() {
    if ($("#AddPatient").valid()) {
        var oModel = {
            User: {
                name: $('#name').val(),
                email: $('#email').val(),
                password: $('#password').val(),
            },
            Admin_PatientPage: {
                phone: $('#phone').val(),
                DateOfBirth: $('#DOB').val(),
                address: $('#address').val(),
                gender: $('#gender').val(),
            }
        }

        $.ajax({
            type: "POST",
            url: "/Admin_PatientPage/AddPatientDetails",
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
                $('#exampleModal').modal('hide');
                get();
            },
            error: function (error) {
                console.log("Error saving employee:", error);
                Swal.fire("Oops", "An error occurred while saving your data, Please try again later.", "error");
            }
        });
    }
}

function DeletePatient(id) {
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
                url: "/Admin_PatientPage/DeletePatient/" + id,
                success: function (data) {

                    swal.fire("Patient deleted successfully!", {
                        icon: "success",
                    }).then(() => {
                        get(); // Refresh data after deletion
                    });
                },
                error: function (errormessage) {
                    Swal.fire({
                        title: "error while delete employee",
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
        url: "/Admin_PatientPage/GetPatientByID/" + id,
        success: function (data) {
            $('#update_id').val(data.User.id);
            $('#u_email').val(data.User.email);
            $('#u_name').val(data.User.name);
            $('#u_phone').val(data.Admin_PatientPage.phone);
            var date = moment(data.Admin_PatientPage.DateOfBirth);
            $('#u_DOB').val(date.format('YYYY-MM-DD'));
            $('#u_address').val(data.Admin_PatientPage.address);
            $('#u_gender').val(data.Admin_PatientPage.gender);
        }
    });
}


function updatePatient() {
    debugger;

    var updatedModel = {

        User: {
            id: $('#update_id').val(),
            name: $('#u_name').val(),
            email: $('#u_email').val(),
        },
        Admin_PatientPage: {
            
            phone: $('#u_phone').val(),
            DateOfBirth: $('#u_DOB').val(),
            address: $('#u_address').val(),
            gender: $('#u_gender').val()
        }
    };
    debugger;

    $.ajax({
        type: "POST",
        url: "/Admin_PatientPage/UpdatePatient",
        data: JSON.stringify(updatedModel),
        contentType: 'application/json',  // Set the content type to application/json
        cache: false,
        success: function (data) {
            $('#updatemodal').modal('hide');
            Swal.fire({
                title: "Good job!",
                text: "Patient update successfully!",
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

function ViewModal(id) {
    debugger;

    $.ajax({
        type: "POST",
        url: "/Admin_PatientPage/GetPatientByID/" + id,
        success: function (data) {
            $('#view_id').val(data.User.id);
            $('#view_email').val(data.User.email);
            $('#view_name').val(data.User.name);
            $('#view_phone').val(data.Admin_PatientPage.phone);
            var date = moment(data.Admin_PatientPage.DateOfBirth);
            $('#viev_DOB').val(date.format('YYYY-MM-DD'));
            $('#view_address').val(data.Admin_PatientPage.address);
            $('#view_gender').val(data.Admin_PatientPage.gender);

        }
    });
}

function ClearUpdatePatientForm() {

    $('#u_name').val('');
    $('#u_email').val('');
    $('#update_id').val('');
    $('#u_phone').val('');
    $('#u_DOB').val('');
    $('#u_address').val('');
    $('#u_gender').val('');

}
function ClearAddPatientForm() {

    $('#name').val('');
    $('#email').val('');
    $('#password').val('');
    $('#phone').val('');
    $('#DOB').val('');
    $('#address').val('');
    $('#gender').val('');

}
function ClearViewPatientForm() {

    $('#view_id').val('');
    $('#view_email').val('');
    $('#view_name').val('');
    $('#view_phone').val('');
    $('#viev_DOB').val('');
    $('#view_address').val('');
    $('#view_gender').val('');

}

function ClearBookingForm() {

    $('#a_doctor').val('');
    $('#a_disease').val('');
    $('#a_appointment_date').val('');
    $('#a_appointment_time').val('');
}
