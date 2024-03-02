
function copyCurrentAddress() {
    var isChecked = document.getElementById("chkSameAsCurrent").checked;
    var currentAddress = ["txtCurrentAddressLine1", "txtCurrentAddressLine2", "ddlCurrentCountry", "ddlCurrentState", "txtCurrentPincode"];
    var permanentAddress = ["txtPermanentAddressLine1", "txtPermanentAddressLine2", "ddlPermanentCountry", "ddlPermanentState", "txtPermanentPincode"];

    var fields = isChecked ? currentAddress : permanentAddress;
    fields.forEach(function (field, index) {
        document.getElementById(permanentAddress[index]).value = document.getElementById(field).value;
    });
}

$(document).ready(function () {

    $('#submitBtn').click(uploadResume);

    $('#ddlCurrentCountry').change(function () {
        var countryId = $(this).val();
        if (countryId) {
            var url = "/UserDetails/GetStatesByCountry";
            $.ajax({
                url: url,
                type: 'GET',
                data: { countryId: countryId },
                async: false,
                success: function (data) {
                    $('#ddlCurrentState').empty();
                    $('#ddlCurrentState').append($('<option>').text('Select State').attr('value', ''));
                    $.each(data, function (i, state) {
                        $('#ddlCurrentState').append($('<option>').text(state.StateName).attr('value', state.StateID));
                    });
                }
            });
        } else {
            $('#ddlCurrentState').empty();
        }
    });


    $('#ddlPermanentCountry').change(function () {
        var countryId = $(this).val();
        if (countryId) {
            var url = "/UserDetails/GetStatesByCountry";
            $.ajax({
                url: url,
                type: 'GET',
                data: { countryId: countryId },
                async:false,
                success: function (data) {
                    $('#ddlPermanentState').empty();
                    $('#ddlPermanentState').append($('<option>').text('Select State').attr('value', ''));
                    $.each(data, function (i, state) {
                        $('#ddlPermanentState').append($('<option>').text(state.StateName).attr('value', state.StateID));
                    });
                }
            });
        } else {
            $('#ddlPermanentState').empty();
        }
    });


    $('#txtEmail').blur(function () {
        var email = $(this).val();
        $.ajax({
            url: '/UserDetails/CheckEmailExists',
            type: 'POST',
            data: {
                Email: email, UserID: userID
            },
            success: function (response) {
                if (response.exists) {
                    $('#emailErrorMessage').text('Email already exists.');
                } else {
                    $('#emailErrorMessage').text('');
                }
            },
            error: function (error) {
                console.log(error);
                }
        });
    });

});

function uploadResume(event) {
    event.preventDefault();
    var fileInput = document.getElementById('resume');
    var file = fileInput.files[0];
    if (!file) {
        alert("Please select a file.");
        return;
    }
    var formData = new FormData();
    formData.append("file", file);
    $.ajax({
        url: '/File/Upload',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            console.log('Success callback triggered');
            console.log(response);
            if (response) {
                var uniqueFileName = response;
                $('#OriginalFileName').val(file.name);
                $('#UniqueFileName').val(uniqueFileName);
                $('#userDetailsForm').submit();
            }
        },
        error: function () {
            alert("File upload failed. Please try again.");
        }
    });
}


