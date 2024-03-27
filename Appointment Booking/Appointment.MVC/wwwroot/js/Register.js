$(document).ready(function () {
    var emailExists = false;
    $('#txtEmail').blur(function () {
        var email = $('#txtEmail').val();
        $.ajax({
            url: '/Home/CheckEmailExists',
            type: 'GET',
            data: { email: email },
            success: function (response) {
                if (response.exists) {
                    $('#email-error').text('Email already exists.');
                    emailExists = true;
                } else {
                    $('#email-error').text('');
                    emailExists = false;
                }
            }
        });
    });
    $('#registerForm').submit(function (e) {
        if (emailExists) {
            e.preventDefault();
            alert('Email already exists. Please use a different email.');
            return false;
        }
    });
    $('.timepicker').timepicker({
        timeFormat: 'HH:mm',
        interval: 15,
        dropdown: true,
        scrollbar: true
    });
});
