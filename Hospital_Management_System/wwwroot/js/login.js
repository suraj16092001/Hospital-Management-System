
function Login() {
    if ($("#login_form").valid()) {
        var emailData = {
            email: $("#email").val()
        };

        var passData = {
            password: $("#password").val()
        };

        debugger;
        console.log(emailData);
        console.log(passData);
        var formData = new FormData();
        formData.append("email", emailData.email);
        formData.append("password", passData.password);
        debugger;
        $.ajax({
            type: "POST",
            url: "/Login/LoginPost",
            data: formData,
            contentType: false,
            processData: false,
            Cache: false,
            success: function (data) {
                if (data.status === "warning") {
                    alert(data.message);
                }
                else if (data.status === "success" && data.role === "1") {
                    alert(data.message);
                    window.location.href = "/AdminDashBoard/AdminDashBoard";
                }
                else if (data.status === "success" && data.role === "2") {
                    alert(data.message);
                    window.location.href = "/PatientDashBoard/PatientDashBoard";
                }
                else if (data.status === "success" && data.role === "3") {
                    alert(data.message);
                    window.location.href = "/DoctorDashboard/DoctorDashboard";
                }
            },
            error: function (error) {
                console.log("Register Data Error: ", error);
            },

        });

    }
}
