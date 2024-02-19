
function copyCurrentAddress() {
    var isChecked = document.getElementById("chkSameAsCurrent").checked;

    if (isChecked) {
        // Copy values from current address fields to permanent address fields
        document.getElementById("txtPermanentAddressLine1").value = document.getElementById("txtCurrentAddressLine1").value;
        document.getElementById("txtPermanentAddressLine2").value = document.getElementById("txtCurrentAddressLine2").value;
        document.getElementById("ddlPermanentCountry").value = document.getElementById("ddlCurrentCountry").value;
        document.getElementById("ddlPermanentState").value = document.getElementById("ddlCurrentState").value;
        document.getElementById("txtPermanentPincode").value = document.getElementById("txtCurrentPincode").value;
    } else {
        // Clear permanent address fields
        document.getElementById("txtPermanentAddressLine1").value = "";
        document.getElementById("txtPermanentAddressLine2").value = "";
        document.getElementById("ddlPermanentCountry").value = "";
        document.getElementById("ddlPermanentState").value = "";
        document.getElementById("txtPermanentPincode").value = "";
    }
}
function resetForm() {

    var textboxes = document.querySelectorAll('input[type=text], input[type=date], textarea');
    textboxes.forEach(function (textbox) {
        textbox.value = '';
    });

    var dropdowns = document.querySelectorAll('select');
    dropdowns.forEach(function (dropdown) {
        dropdown.selectedIndex = 0;
    });

    var checkboxes = document.querySelectorAll('input[type=checkbox]');
    checkboxes.forEach(function (checkbox) {
        checkbox.checked = false;
    });
}

function validateForm() {

    resetValidation();


    var firstName = document.getElementById('txtFirstName').value.trim();
    var dob = document.getElementById('txtDateOfBirth').value.trim();
    var aadharNo = document.getElementById('txtAadharNo').value.trim();
    var email = document.getElementById('txtEmail').value.trim();
    var password = document.getElementById('txtPassword').value.trim();
    var phoneNumber = document.getElementById('txtPhoneNumber').value.trim();
    var currentAddressLine1 = document.getElementById('txtCurrentAddressLine1').value.trim();
    var currentPincode = document.getElementById('txtCurrentPincode').value.trim();
    var currentState = document.getElementById('ddlCurrentState').value.trim();
    var currentCountry = document.getElementById('ddlCurrentCountry').value.trim();
    var permanentAddressLine1 = document.getElementById('txtPermanentAddressLine1').value.trim();
    var permanentPincode = document.getElementById('txtPermanentPincode').value.trim();
    var permanentState = document.getElementById('ddlPermanentState').value.trim();
    var permanentCountry = document.getElementById('ddlPermanentCountry').value.trim();

    var marks10th = document.getElementById('txtMarks10th').value.trim();
    var marks12th = document.getElementById('txtMarks12th').value.trim();
    var cgpa = document.getElementById('txtCGPA').value.trim();


    //  var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;


    var phonePattern = /^\d{10}$/;

    var isValid = true;

    if (firstName === '') {
        displayValidationMessage('txtFirstName', 'First Name is required');
        isValid = false;
    }

    if (dob === '') {
        displayValidationMessage('txtDateOfBirth', 'Date of Birth is required');
        isValid = false;
    }

    if (aadharNo === '' || isNaN(aadharNo) || aadharNo.length !== 12) {
        displayValidationMessage('txtAadharNo', 'Aadhar No is required and must be a 12 digit number');
        isValid = false;
    }



    //if (email === '' || !emailPattern.test(email)) {
    //    displayValidationMessage('txtEmail', 'Invalid Email');
    //    isValid = false;
    //}
    //else {
    //    $.ajax({
    //        type: "POST",
    //        url: "UserDetails.aspx/CheckEmailExists",
    //        data: JSON.stringify({ email: email }),
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        success: function (response) {
    //            if (response.d) {
    //                displayValidationMessage('txtEmail', 'Email already exists. Please use a different email.');
    //                isValid = false;
    //            }
    //        },
    //        error: function (xhr, status, error) {
    //            console.log(error);
    //        }
    //    });
    //}


    if (password === '' || password.length <= 8) {
        displayValidationMessage('txtPassword', 'Password is required and must be more than 8 characters');
        isValid = false;
    }

    if (phoneNumber === '' || !phonePattern.test(phoneNumber)) {
        displayValidationMessage('txtPhoneNumber', 'Phone Number is required and must be a 10 digit number');
        isValid = false;
    }

    if (currentAddressLine1 === '') {
        displayValidationMessage('txtCurrentAddressLine1', 'Address Line1 is mandatory');
        isValid = false;
    }

    if (currentPincode === '') {
        displayValidationMessage('txtCurrentPincode', 'Pincode is mandatory');
        isValid = false;
    }

    if (currentState === '') {
        displayValidationMessage('ddlCurrentState', 'State is mandatory');
        isValid = false;
    }

    if (currentCountry === '') {
        displayValidationMessage('ddlCurrentCountry', 'Country is mandatory');
        isValid = false;
    }

    if (permanentAddressLine1 === '') {
        displayValidationMessage('txtPermanentAddressLine1', 'Address Line1 is mandatory');
        isValid = false;
    }

    if (permanentPincode === '') {
        displayValidationMessage('txtPermanentPincode', 'Pincode is mandatory');
        isValid = false;
    }

    if (permanentState === '') {
        displayValidationMessage('ddlPermanentState', 'State is mandatory');
        isValid = false;
    }

    if (permanentCountry === '') {
        displayValidationMessage('ddlPermanentCountry', 'Country is mandatory');
        isValid = false;
    }


    if (marks10th === '' || isNaN(marks10th) || marks10th < 1 || marks10th > 100) {
        displayValidationMessage('txtMarks10th', 'Percentage is required and must be a number between 1 and 100');
        isValid = false;
    }


    if (marks12th === '' || isNaN(marks12th) || marks12th < 1 || marks12th > 100) {
        displayValidationMessage('txtMarks12th', 'Percentage is required and must be a number between 1 and 100');
        isValid = false;
    }

    if (cgpa === '' || isNaN(cgpa) || cgpa < 1 || cgpa > 10) {
        displayValidationMessage('txtCGPA', 'CGPA is required and must be a number between 1 and 10');
        isValid = false;
    }

    if (isValid) {
        validateEmailAndSubmitForm();
    }

    return false;
}


function validateEmailAndSubmitForm() {
    var email = document.getElementById('txtEmail').value.trim();
    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (email === '' || !emailPattern.test(email)) {
        displayValidationMessage('txtEmail', 'Invalid Email');
        isValid = false;
        return;
    }

    $.ajax({
        type: "POST",
        url: "UserDetails2.aspx/CheckEmailExists",
        data: JSON.stringify({ email: email }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d) {
                displayValidationMessage('txtEmail', 'Email already exists. Please use a different email.');
                isValid = false;
            } else {
                submitFormData();
            }
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
}
function displayValidationMessage(elementId, message) {
    var validationMessage = document.createElement('div');
    validationMessage.className = 'text-danger';
    validationMessage.innerHTML = message;
    document.getElementById(elementId).parentNode.appendChild(validationMessage);
    document.getElementById(elementId).style.borderColor = 'red';
}

function resetValidation() {
    var validationMessages = document.querySelectorAll('.text-danger');
    validationMessages.forEach(function (message) {
        message.parentNode.removeChild(message);
    });

    var inputs = document.querySelectorAll('.form-control');
    inputs.forEach(function (input) {
        input.style.borderColor = '';
    });
}


function populateCountries(dropdownId) {
    $.ajax({
        type: "POST",
        url: "UserDetails2.aspx/GetCountries",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var dropdown = $("#" + dropdownId);
            dropdown.empty();
            dropdown.append($("<option></option>").val("").text("Select Country"));
            $.each(response.d, function (key, value) {
                dropdown.append($("<option></option>").val(value.CountryID).text(value.CountryName));
            });
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
}

function populateStates(countryId, dropdownId) {
    $.ajax({
        type: "POST",
        url: "UserDetails2.aspx/GetStates",
        data: JSON.stringify({ CountryID: countryId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var dropdown = $("#" + dropdownId);
            dropdown.empty();
            dropdown.append($("<option></option>").val("").text("Select State"));
            $.each(response.d, function (key, value) {
                dropdown.append($("<option></option>").val(value.StateID).text(value.StateName));
            });
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
}
function submitFormData() {
    var userDetails = {
        FirstName: $("#txtFirstName").val(),
        LastName: $("#txtLastName").val(),
        MiddleName: $("#txtMiddleName").val(),
        Gender: $("#ddlGender option:selected").text(),
        DateOfBirth: $("#txtDateOfBirth").val(),
        AadharNo: $("#txtAadharNo").val(),
        Email: $("#txtEmail").val(),
        Password: $("#txtPassword").val(),
        PhoneNumber: $("#txtPhoneNumber").val(),
        Marks10th: $("#txtMarks10th").val(),
        Board10th: $("#ddlBoard10th option:selected").text(),
        School10th: $("#txtSchool10th").val(),
        YearOfCompletion10th: $("#txtYearOfCompletion10th").val(),
        Marks12th: $("#txtMarks12th").val(),
        Board12th: $("#ddlBoard12th option:selected").text(),
        School12th: $("#txtSchool12th").val(),
        YearOfCompletion12th: $("#txtYearOfCompletion12th").val(),
        CGPA: $("#txtCGPA").val(),
        University: $("#txtUniversity").val(),
        YearOfCompletionGraduation: $("#txtYearOfCompletionGraduation").val(),
        Hobbies: $("#txtHobbies").val(),
        Comments: $("#txtComments").val()
    };

    var currentAddress = {
        AddressType: 1,
        AddressLine1: $("#txtCurrentAddressLine1").val(),
        AddressLine2: $("#txtCurrentAddressLine2").val(),
        Pincode: $("#txtCurrentPincode").val(),
        CountryID: $("#ddlCurrentCountry").val(),
        StateID: $("#ddlCurrentState").val()
    };

    var permanentAddress = {
        AddressType: 2,
        AddressLine1: $("#txtPermanentAddressLine1").val(),
        AddressLine2: $("#txtPermanentAddressLine2").val(),
        Pincode: $("#txtPermanentPincode").val(),
        CountryID: $("#ddlPermanentCountry").val(),
        StateID: $("#ddlPermanentState").val()
    };

    var isAdmin = '<%= ((UserSessionInfo)Session["UserSessionInfo"]).IsAdmin %>';

    $.ajax({
        type: "POST",
        url: "UserDetails2.aspx/SubmitFormData",
        data: JSON.stringify({ userDetails: userDetails, currentAddress: currentAddress, permanentAddress: permanentAddress, isAdmin: isAdmin }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.success) {
                if (isAdmin) {
                    window.location.href = "Users.aspx";
                } else {
                    alert("User details saved successfully.");
                }
            } else {
                alert("Failed to save user details: " + response.d.message);
            }
        },
        error: function (xhr, status, error) {
            alert("An error occurred while saving user details: " + error);
        }
    });
}

$(document).ready(function () {
    populateCountries("ddlCurrentCountry");
    populateCountries("ddlPermanentCountry");

    $("#ddlCurrentCountry").change(function () {
        var countryId = $(this).val();
        populateStates(countryId, "ddlCurrentState");
    });

    $("#ddlPermanentCountry").change(function () {
        var countryId = $(this).val();
        populateStates(countryId, "ddlPermanentState");
    });

    var userSessionJson = $("#hdnUserSessionInfo").val();
    if (userSessionJson) {
        var userSessionInfo = JSON.parse(userSessionJson);
        var SessionUserID = userSessionInfo.UserID;
        var SessionIsAdmin = userSessionInfo.IsAdmin;
        // Get the query string parameters
        const urlParams = new URLSearchParams(window.location.search);
        const userID = urlParams.has("UserID") ? parseInt(urlParams.get("UserID")) : 0;


        if (userID === SessionUserID || SessionIsAdmin) {
            $.ajax({
                type: "POST",
                url: "UserDetails2.aspx/GetUserDetails",
                data: JSON.stringify({ userId: userID }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var userDetails = JSON.parse(response.d);
                    // Populate fields with userDetails
                    txtFirstName.val(userDetails.FirstName);
                    txtLastName.val(userDetails.LastName);
                    txtMiddleName.val(userDetails.MiddleName);
                    ddlGender.val(userDetails.Gender);
                    txtDateOfBirth.val(userDetails.DateOfBirth !== null ? userDetails.DateOfBirth.split('T')[0] : '');
                    txtAadharNo.val(userDetails.AadharNo);
                    txtEmail.val(userDetails.Email);
                    txtPassword.val(userDetails.Password);
                    txtPhoneNumber.val(userDetails.PhoneNumber);
                    txtMarks10th.val(userDetails.Marks10th !== null ? userDetails.Marks10th.toFixed(2) : '');
                    ddlBoard10th.val(userDetails.Board10th);
                    txtSchool10th.val(userDetails.School10th);
                    txtYearOfCompletion10th.val(userDetails.YearOfCompletion10th !== null ? userDetails.YearOfCompletion10th.split('T')[0] : '');
                    txtMarks12th.val(userDetails.Marks12th !== null ? userDetails.Marks12th.toFixed(2) : '');
                    ddlBoard12th.val(userDetails.Board12th);
                    txtSchool12th.val(userDetails.School12th);
                    txtYearOfCompletion12th.val(userDetails.YearOfCompletion12th !== null ? userDetails.YearOfCompletion12th.split('T')[0] : '');
                    txtCGPA.val(userDetails.CGPA !== null ? userDetails.CGPA.toFixed(2) : '');
                    txtUniversity.val(userDetails.University);
                    txtYearOfCompletionGraduation.val(userDetails.YearOfCompletionGraduation !== null ? userDetails.YearOfCompletionGraduation.split('T')[0] : '');
                    txtHobbies.val(userDetails.Hobbies);
                    txtComments.val(userDetails.Comments);
                },
                error: function (xhr, status, error) {
                    console.log(error);
                }
            });

            $.ajax({
                type: "POST",
                url: "UserDetails.aspx/GetAddressDetails",
                data: JSON.stringify({ userID: userID, addresssType: 1 }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var currentAddress = JSON.parse(response.d);
                    // Populate fields with currentAddress
                    txtCurrentAddressLine1.val(currentAddress.AddressLine1);
                    txtCurrentAddressLine2.val(currentAddress.AddressLine2);
                    txtCurrentPincode.val(currentAddress.Pincode);
                    ddlCurrentCountry.val(currentAddress.CountryID.toString());
                    populateStates(currentAddress.CountryID.toString(), "ddlCurrentState");
                    ddlCurrentState.val(currentAddress.StateID.toString());
                },
                error: function (xhr, status, error) {
                    console.log(error);
                }
            });

            $.ajax({
                type: "POST",
                url: "UserDetails2.aspx/GetAddressDetails",
                data: JSON.stringify({ userID: userID, addresssType: 2 }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var permanentAddress = JSON.parse(response.d);
                    // Populate fields with permanentAddress
                    txtPermanentAddressLine1.val(permanentAddress.AddressLine1);
                    txtPermanentAddressLine2.val(permanentAddress.AddressLine2);
                    txtPermanentPincode.val(permanentAddress.Pincode);
                    ddlPermanentCountry.val(permanentAddress.CountryID.toString());
                    populateStates(permanentAddress.CountryID.toString(), "ddlPermanentState");
                    ddlPermanentState.val(permanentAddress.StateID.toString());
                },
                error: function (xhr, status, error) {
                    console.log(error);
                }
            });
        }
    }
});
