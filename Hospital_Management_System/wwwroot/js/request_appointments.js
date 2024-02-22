$(document).ready(function () {
    get();
    GetStatus();
});

function get() {
    debugger;
    // Destroy the existing DataTable
    if ($.fn.DataTable.isDataTable('#myTable')) {
        $('#myTable').DataTable().destroy();
    }

    $.ajax({
        type: "GET",
        url: "/Requested_appointments/RequestedPatientList",
        success: function (data) {
            $('#myTable').DataTable({
                data: data,
                columns: [
                    { data: 'id' },
                    { data: 'name' },
                    {
                        data: 'appointment_date',
                        render: function (data, type, row) {
                            // Parse the date with the correct format
                            var parsedDate = moment(data, 'M/D/YYYY h:mm:ss A');

                            // Check if the parsed date is valid
                            if (parsedDate.isValid()) {
                                // Format the valid date to display only the date part
                                return parsedDate.format('YYYY-MM-DD');
                            } else {
                                // Handle invalid date
                                return 'Invalid date';
                            }
                        }
                    },

                    { data: 'appointment_time' },
                    { data: 'department' },
                    { data: 'statusModel.Status' },
                    {
                        data: null,
                        render: function (data, type, row) {
                            return `<button type="button" onclick="popupdatedata(` + row.id + `); event.stopPropagation();" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#updatemodal"><i class="fa-solid fa-pen-to-square"></i></button>`;
                        }
                    }
                ],
                rowCallback: function (row, data) {
                    $(row).on('click', function () {
                        popupdatedata(data.id);
                    });
                }

            });
        },
        error: function (textStatus, errorThrown) {
            Success = false;
        }
    });
}


function GetStatus() {
    $.ajax({
        url: '/Requested_appointments/GetStatus',
        type: 'GET',
        dataType: 'json', // assuming your server returns JSON
        success: function (data) {
            var dropdown = $('#u_status_id');
            dropdown.empty();
            if (data) {
                $.each(data, function (i, doctor) {
                    if (doctor && doctor.Status && doctor.Status_id) {
                        dropdown.append($('<option></option>').text(doctor.Status).val(doctor.Status_id));
                    }
                });
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
}

function popupdatedata(id) {
    debugger;

    $.ajax({
        type: "GET",
        url: "/Requested_appointments/GetRequested_Appointment/" + id,
        success: function (data) {
            $('#update_id').val(data.id);
            $('#u_name').val(data.name);
            $('#u_email').val(data.email);
            // var date = moment(data.appointment_date);
            // $('#u_appointment_date').val(date.format('YYYY-MM-DD'));
            var date = moment(data.appointment_date, 'M/D/YYYY h:mm:ss A');

            // Ensure that date is valid before formatting
            if (date.isValid()) {
                $('#u_appointment_date').val(date.format('YYYY-MM-DD'));
            } else {
                // Handle invalid date
                console.error("Invalid date format:", data.appointment_date);
            }
            $('#u_appointment_time').val(data.appointment_time);
            $('#u_department').val(data.department);
            $('#u_status_id').val(data.status_id);
            $('#u_doctor').val(data.User.name);
            $('#u_status').val(data.statusModel.Status);

            $('#updatemodal').modal('show');
            console.log(data);
        }
    });
}

function updateStatus() {
    debugger;

    var updatedModel = {
        id: $('#update_id').val(),
        name: $('#u_name').val(),
        email: $('#u_email').val(),
        appointment_date: $('#u_appointment_date').val(),
        appointment_time: $('#u_appointment_time').val(),
        department: $('#u_department').val(),
        status_id: $('#u_status_id').val(),
    };
    console.log(updatedModel);
    debugger;

    $.ajax({
        type: "POST",
        url: "/Requested_appointments/UpdateStatus",
        data: JSON.stringify(updatedModel),
        contentType: 'application/json',  // Set the content type to application/json
        cache: false,
        success: function (data) {
            $('#updatemodal').modal('hide');
            Swal.fire({
                title: "Good job!",
                text: "Appointment Book successfully!",
                icon: "success",
                button: "Ok",
            });

            // datatable.destroy();
            get();
        },
        error: function () {
            Swal.fire({
                title: "Error while booking appointment!",
                text: "close",
                icon: "error"
            });
        }
    });

}

function AdminStatusUpdateForm() {

    $('#u_name').val('');
    $('#u_email').val('');
    $('#u_appointment_date').val('');
    $('#u_appointment_time').val('');
    $('#u_department').val('');
    $('#u_doctor').val('');
    $('#u_status_id').val('');
    $('#u_status').val('');
}
