$(document).ready(function () {
    DoctorDashBoardcount();
});

// use DoctorAllDataViewModel
function DoctorDashBoardcount() {
    $.ajax({
        type: "GET",
        url: "/DoctorDashBoard/PopulateCount",
        success: function (data) {

            $('#Ongoing_Appointments').text(data.Ongoing_Appointments);
            $('#Completed_Appointments').text(data.Completed_Appointments);

            console.log(data);
        }
    });
}
