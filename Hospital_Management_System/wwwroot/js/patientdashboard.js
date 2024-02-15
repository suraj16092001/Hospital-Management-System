
// retrive doctors list of specific department/ specialization
function FetchDoctors(department) {
    debugger;
    $.ajax({
        url: '/Admin_PatientPage/GetDoctors',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ specialist: department }),
        success: function (data) {
            var dropdown = $('#doctor');
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


// Requested_appointments
function BookAppointment() {
    var oModel = {
        name: $('#name').val(),
        email: $('#email').val(),
        appointment_date: $('#appointment_date').val(),
        appointment_time: $('#appointment_time').val(),
        department: $('#department').val(),
        description: $('#message').val(),
        doctor_id: $('#doctor').val(),
    }

    debugger;

    $.ajax({
        type: "POST",
        url: "/PatientDashBoard/RequestedAppointment",
        contentType: "application/json",
        data: JSON.stringify(oModel),
        dataType: 'json',
        cache: false,
        async: false,
        success: function (data) {

            alert("Your appointment request has been sent we will contact you soon");
            ClearForm();
        },
        error: function (error) {
            console.log("Error saving employee:", error);
            Swal.fire("Oops", "An error occurred while saving your request, Please try again later.", "error");
        }
    })
}

function ClearForm() {
    $('#name').val('');
    $('#email').val('');
    $('#appointment_date').val('');
    $('#appointment_time').val('');
    $('#department').val('');
    $('#message').val('');
    $('#doctor').val('');
}


// // Get reference to the select element
// var selectElement = document.getElementById("appointment_time");

// // Function to add options with 15-minute intervals from 9:00 AM to 7:00 PM
// function populateTimeIntervals() {
//     var startTime = 9 * 60; // Start time in minutes (9:00 AM)
//     var endTime = 19 * 60; // End time in minutes (7:00 PM)
//     var interval = 15; // Interval in minutes

//     var selectElement = document.getElementById("appointment_time");
//     selectElement.size = 5; // Set the size of the select element to 5 to display 5 options initially

//     for (var i = startTime; i <= endTime; i += interval) {
//         var hours = Math.floor(i / 60);
//         var minutes = i % 60;
//         var ampm = hours >= 12 ? 'PM' : 'AM';
//         hours = hours % 12;
//         hours = hours ? hours : 12; // Convert 0 to 12
//         minutes = minutes < 10 ? '0' + minutes : minutes; // Add leading zero to minutes
//         var timeString = hours + ':' + minutes + ' ' + ampm;

//         var option = document.createElement("option");
//         option.text = timeString;
//         option.value = timeString;
//         selectElement.add(option);

//         // After adding the first 5 options, remove the size attribute to allow scrolling
//         if (i === (startTime + (interval * 4))) {
//             selectElement.removeAttribute("size");
//         }
//     }
// }


// // Call the function to populate time intervals when the page loads
// window.onload = function () {
//     populateTimeIntervals();
// };
