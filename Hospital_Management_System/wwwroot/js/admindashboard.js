$(document).ready(function () {
    AdminDashBoardcount();
});

// use AdminAllDataViewModel
function AdminDashBoardcount() {
    $.ajax({
        type: "GET",
        url: "/AdminDashBoard/PopulateCount",
        success: function (data) {
            $('#Total_Patient').text(data.Total_Patient);
            $('#Total_Doctor').text(data.Total_Doctor);
            $('#Ongoing_Appointments').text(data.Ongoing_Appointments);
            $('#Completed_Appointments').text(data.Completed_Appointments);
        
            console.log(data);
        }
    });
}
