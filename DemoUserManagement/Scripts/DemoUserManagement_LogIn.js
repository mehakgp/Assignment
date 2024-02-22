function LogIn() {
    var email = $('#txtEmail').val().trim();
    var password = $('#txtPassword').val().trim();

    if (email === '' || password === '') {
        $('#lblMessage').text('Please enter Email and Password.');
        $('#lblMessage').show();
        return false;
    }
    else {
        $.ajax({
            type: "POST",
            url: "LogIn.aspx/ValidateUser",
            data: JSON.stringify({ email: email, password: password }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d.userID == -1) {
                    $('#lblMessage').text('Invalid Email or Password.');
                    $('#lblMessage').show();
                } else {
                    if (response.d.IsAdmin) {
                        window.location.href = "Users.aspx";
                    } else {
                        window.location.href = 'UserDetails2.aspx?UserID=' + response.d.userID;
                    }
                }
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    }
    return false;
}
