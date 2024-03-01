function Register() {
    debugger;
    if ($('#signup_form').valid()) {
        var RegisterData = {
            name: $('#name').val(),
            email: $('#email').val(),
            password: $('#password').val(),
            confirm_password: $('#confirm_password').val(),
           /* role: $('#role').val(),*/
        };

        console.log(RegisterData);

        var formData = new FormData();
        formData.append("model", JSON.stringify(RegisterData));
        debugger;

        $.ajax({
            type: "POST",
            url: "/Login/SignUpPost",
            data: formData,
            contentType: false,
            processData: false,
            Cache: false,
            success: function (data) {

                if (data.status === "success") {
                    alert(data.message);
                    window.location.href = "/Login/Login";
                }
                else if (data.status === "warning") {
                    alert(data.message);
                }


            },
            error: function (error) {
                console.log("Register Data Error: ", error);
            },
        });
    }
}