
$(document).ready(function () {
    get();
    populateTimeIntervals();
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
                            return `<button type="button" onclick="popupdatedata(` + row.User.id + `); event.stopPropagation();" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#updatemodal"><i class="fa-solid fa-pen-to-square"></i></button>|<button type="button" onclick="DeletePatient(` + row.User.id + `); event.stopPropagation();" class="btn btn-danger" ><i class="fa-solid fa-trash-can-arrow-up"></i></button>|<button type="button" onclick="popupdatedataforBooking(` + row.User.id + `); event.stopPropagation();" class="btn btn-secondary"  data-bs-toggle="modal" data-bs-target="#appointmentModal"><i class="fa-solid fa-clipboard-list"></i></button>`;
                        }
                    }
                ],
                rowCallback: function (row, data) {
                    $(row).on('click', function () {
                        ViewModal(data.User.id);
                    });
                }
            });
        },
        error: function (textStatus, errorThrown) {
            Success = false;
        }
    });
} 

function FetchDoctors(department) {
    debugger;
    $.ajax({
        url: '/Admin_PatientPage/GetDoctors',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ specialist: department }),
        success: function (data) {
            var dropdown = $('#a_doctor');
            dropdown.empty();
            if (data) {
                $.each(data, function (i, doctor) {
                    if (doctor && doctor.name && doctor.id) {
                        dropdown.append($('<option></option>').text(doctor.name).val(doctor.id));
                    }
                });
            }
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
}

// Get reference to the select element
var selectElement = document.getElementById("a_appointment_time");

// Function to add options with 15-minute intervals from 9:00 AM to 7:00 PM
function populateTimeIntervals() {
    var startTime = 9 * 60; // Start time in minutes (9:00 AM)
    var endTime = 19 * 60; // End time in minutes (7:00 PM)
    var interval = 15; // Interval in minutes

    var selectElement = document.getElementById("a_appointment_time");
    selectElement.size = 5; // Set the size of the select element to 5 to display 5 options initially

    for (var i = startTime; i <= endTime; i += interval) {
        var hours = Math.floor(i / 60);
        var minutes = i % 60;
        var ampm = hours >= 12 ? 'PM' : 'AM';
        hours = hours % 12;
        hours = hours ? hours : 12; // Convert 0 to 12
        minutes = minutes < 10 ? '0' + minutes : minutes; // Add leading zero to minutes
        var timeString = hours + ':' + minutes + ' ' + ampm;

        var option = document.createElement("option");
        option.text = timeString;
        option.value = timeString;
        selectElement.add(option);

        // After adding the first 5 options, remove the size attribute to allow scrolling
        if (i === (startTime + (interval * 4))) {
            selectElement.removeAttribute("size");
        }
    }
}


// Call the function to populate time intervals when the page loads
//window.onload = function () {
//    populateTimeIntervals();
//};

// Requested_appointmentsModel
function BookAppointment() {
    var oModel = {
        patient_id: $('#a_id').val(),
        name: $('#a_name').val(),
        email: $('#a_email').val(),
        appointment_date: $('#a_appointment_date').val(),
        appointment_time: $('#a_appointment_time').val(),
        department: $('#a_department').val(),
        description: $('#a_Description').val(),
        doctor_id: $('#a_doctor').val(),
    }

    debugger;

    $.ajax({
        type: "POST",
        url: "/Admin_PatientPage/AdminSidePatientAppointment",
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
            $('#appointmentModal').modal('hide');
            get();
        },
        error: function (error) {
            console.log("Error saving employee:", error);
            Swal.fire("Oops", "An error occurred while saving your request, Please try again later.", "error");
        }
    })
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



function popupdatedataforBooking(id) {
    debugger;
   /* $('#ViewModal').modal('hide');*/
    $.ajax({
        type: "POST",
        url: "/Admin_PatientPage/GetPatientByID/" + id,
        success: function (data) {
            $('#a_id').val(data.User.id);
            $('#a_name').val(data.User.name);
            $('#a_email').val(data.User.email);
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


            $('#ViewModal').modal('show');
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
    $('#name').val('');
    $('#email').val('');
    $('#appointment_date').val('');
    $('#appointment_time').val('');
    $('#department').val('');
    $('#message').val('');
    $('#doctor').val('');
}