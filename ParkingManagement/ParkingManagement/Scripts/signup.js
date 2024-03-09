$(document).ready(function () {
    var emailExists = false; 
    $('#txtEmail').blur(function () {
        var email = $('#txtEmail').val();
        $.ajax({
            url: '/Account/CheckEmailExists',
            type: 'GET',
            data: { email: email },
            success: function (response) {
                if (response.exists) {
                    $('#txtEmail').addClass('input-validation-error');
                    $('#email-error').text('Email already exists.');
                    emailExists = true;
                } else {
                    $('#txtEmail').removeClass('input-validation-error');
                    $('#email-error').text('');
                    emailExists = false; 
                }
            }
        });
    });

    $('#signupForm').submit(function (e) {
        if (emailExists) {
            e.preventDefault(); 
            alert('Email already exists. Please use a different email.');
            return false;
        }
    });

});
