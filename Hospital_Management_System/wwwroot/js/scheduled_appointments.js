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
        url: "/Scheduled_Appointments/ScheduledPatientList",
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
                    {
                        data: null,
                        render: function (data, type, row) {
                            return `<button type="button" onclick="GetScheduledAppointments(` + row.id + `);  event.stopPropagation();" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#updatemodal"><i class="fa-solid fa-pen-to-square"></i></button>`;
                        }
                    }
                ],
                rowCallback: function (row, data) {
                    $(row).on('click', function () {
                        GetScheduledAppointments(data.id);
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
        url: '/Scheduled_Appointments/GetStatusForDoctor',
        type: 'GET',
        dataType: 'json', // assuming your server returns JSON
        success: function (data) {
            var dropdown = $('#u_status_id');
            dropdown.empty();
            dropdown.append($('<option></option>').text("Select Status").val(""));
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
function GetScheduledAppointments(id) {
    debugger;
    $.ajax({
        type: "GET",
        url: "/Scheduled_Appointments/GetScheduledAppointments/" + id,
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
            $('#u_description').val(data.description);
/*            $('#u_status_id').val(data.status_id);*/
            $('#updatemodal').modal('show');
            console.log(data);
        }
    });
}

function clearScheduledForm() {
    $('#update_id').val('');
    $('#u_name').val('');
    $('#u_email').val('');
    $('#u_appointment_date').val('');
    $('#u_appointment_time').val('');
    $('#u_description').val('');
    $('#u_status_id').val('');
}