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
            $('#u_description').val(data.description);
            $('#u_status_id').val(data.status_id);
            $('#u_doctor').val(data.User.name);
            $('#u_status').val(data.statusModel.Status);

            $('#updatemodal').modal('show');
            console.log(data);
        }
    });
}
