
function copyCurrentAddress() {
    var isChecked = document.getElementById("chkSameAsCurrent").checked;
    var currentAddress = ["txtCurrentAddressLine1", "txtCurrentAddressLine2", "ddlCurrentCountry", "ddlCurrentState", "txtCurrentPincode"];
    var permanentAddress = ["txtPermanentAddressLine1", "txtPermanentAddressLine2", "ddlPermanentCountry", "ddlPermanentState", "txtPermanentPincode"];

    var fields = isChecked ? currentAddress : permanentAddress;
    fields.forEach(function (field, index) {
        document.getElementById(permanentAddress[index]).value = document.getElementById(field).value;
    });
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
    
    var elements = document.querySelectorAll('.validate-input');
    var isValid = true;
    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    elements.forEach(function (element) {
        var value = element.value.trim();
        switch (element.id) {
            case 'txtFirstName':
                if (value === '') {
                    displayValidationMessage('txtFirstName', 'First Name is required');
                    isValid = false;
                }
                break;

            case 'ddlGender':
                if (value === '') {
                    displayValidationMessage('ddlGender', 'Gender is required');
                    isValid = false;
                }
                break;
            case 'txtDateOfBirth':
                if (value === '') {
                    displayValidationMessage('txtDateOfBirth', 'Date of Birth is required');
                    isValid = false;
                }
                break;
            case 'txtAadharNo':
                if (value === '' || isNaN(value) || value.length !== 12) {
                    displayValidationMessage('txtAadharNo', 'Aadhar No is required and must be a 12 digit number');
                    isValid = false;
                }
                break;
            case 'txtPassword':
                if (value === '' || value.length <= 8) {
                    displayValidationMessage('txtPassword', 'Password is required and must be more than 8 characters');
                    isValid = false;
                }
                break;
            case 'txtPhoneNumber':
                var phonePattern = /^\d{10}$/;
                if (value === '' || !phonePattern.test(value)) {
                    displayValidationMessage('txtPhoneNumber', 'Phone Number is required and must be a 10 digit number');
                    isValid = false;
                }
                break;
            case 'txtCurrentAddressLine1':
                if (value === '') {
                    displayValidationMessage('txtCurrentAddressLine1', 'Address Line1 is mandatory');
                    isValid = false;
                }
                break;
            case 'txtCurrentPincode':
                if (value === '') {
                    displayValidationMessage('txtCurrentPincode', 'Pincode is mandatory');
                    isValid = false;
                }
                break;
            case 'ddlCurrentState':
                if (value === '') {
                    displayValidationMessage('ddlCurrentState', 'State is mandatory');
                    isValid = false;
                }
                break;
            case 'ddlCurrentCountry':
                if (value === '') {
                    displayValidationMessage('ddlCurrentCountry', 'Country is mandatory');
                    isValid = false;
                }
                break;
            case 'txtPermanentAddressLine1':
                if (value === '') {
                    displayValidationMessage('txtPermanentAddressLine1', 'Address Line1 is mandatory');
                    isValid = false;
                }
                break;
            case 'txtPermanentPincode':
                if (value === '') {
                    displayValidationMessage('txtPermanentPincode', 'Pincode is mandatory');
                    isValid = false;
                }
                break;
            case 'ddlPermanentState':
                if (value === '') {
                    displayValidationMessage('ddlPermanentState', 'State is mandatory');
                    isValid = false;
                }
                break;
            case 'ddlPermanentCountry':
                if (value === '') {
                    displayValidationMessage('ddlPermanentCountry', 'Country is mandatory');
                    isValid = false;
                }
                break;
            case 'txtMarks10th':
                if (value === '' || isNaN(value) || value < 1 || value > 100) {
                    displayValidationMessage('txtMarks10th', 'Percentage is required and must be a number between 1 and 100');
                    isValid = false;
                }
                break;
            case 'txtMarks12th':
                if (value === '' || isNaN(value) || value < 1 || value > 100) {
                    displayValidationMessage('txtMarks12th', 'Percentage is required and must be a number between 1 and 100');
                    isValid = false;
                }
                break;
            case 'txtCGPA':
                if (value === '' || isNaN(value) || value < 1 || value > 10) {
                    displayValidationMessage('txtCGPA', 'CGPA is required and must be a number between 1 and 10');
                    isValid = false;
                }
                break;
            case 'txtEmail':
                if (value === '' || !emailPattern.test(value)) {
                    displayValidationMessage('txtEmail', 'Invalid Email');
                    isValid = false;
                }
                break;
            default:
                break;
        }
    });

    if (isValid) {
        validateEmailAndSubmitForm();
    }

    return false;
}

function validateEmailAndSubmitForm() {
    var email = document.getElementById('txtEmail').value.trim();
    const urlParams = new URLSearchParams(window.location.search);
    const userID = urlParams.has("UserID") ? parseInt(urlParams.get("UserID")) : 0;

    $.ajax({
        type: "POST",
        url: "UserDetails2.aspx/CheckEmailExists",
        data: JSON.stringify({ email: email, userID: userID }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response);
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


function submitFormData() {
    var fileInput = document.getElementById('resume');
    var file = fileInput.files[0];
    if (!file) {
        alert("Please select a file.");
        return;
    }
    var formData = new FormData();
    formData.append("file", file);
    $.ajax({
        type: "POST",
        url: "UploadFileHandler.ashx",
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            var uniqueFileName = response;

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
                Comments: $("#txtComments").val(),
                OriginalFileName: file.name,
                UniqueFileName: uniqueFileName
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

            const urlParams = new URLSearchParams(window.location.search);
            const userID = urlParams.has("UserID") ? parseInt(urlParams.get("UserID")) : 0;

            $.ajax({
                type: "POST",
                url: "UserDetails2.aspx/SubmitFormData",
                data: JSON.stringify({ userDetails: userDetails, currentAddress: currentAddress, permanentAddress: permanentAddress, userID: userID }),
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    if (response.d.EditSuccess) {
                        if (response.d.IsAdmin) {
                            window.location.href = "Users.aspx";
                        } else {
                            alert('Form edited successfully.');
                        }
                    }
                    else
                    {
                        if (response.d.NewUserSuccess) {
                            window.location.href = "LogIn.aspx";
                        }
                    }

                },
                error: function (xhr, status, error) {
                    console.log("Error:", error);
                }
            });
        },
        error: function (xhr, status, error) {
            console.log("Error:", error);
        }
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

function PopulateStates(countryId, isCurrent, callback) {
    var stateDropdownId = isCurrent ? "ddlCurrentState" : "ddlPermanentState";
    var stateUrl = isCurrent ? "UserDetails2.aspx/GetStates" : "UserDetails2.aspx/GetStates";

    $.ajax({
        type: "POST",
        url: stateUrl,
        data: JSON.stringify({ CountryID: countryId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var dropdown = $("#" + stateDropdownId);
            dropdown.empty();
            dropdown.append($("<option></option>").val("").text("Select State"));
            $.each(response.d, function (key, value) {
                dropdown.append($("<option></option>").val(value.StateID).text(value.StateName));
            });
            if (callback) {
                callback();
            }
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
}
function populateFields(userDetails) {
    $('[data-field]').each(function () {
        var fieldName = $(this).data('field');
        var value = userDetails[fieldName];
        if (value !== null && value !== undefined) {
            if ($(this).is('select')) {
                $(this).val(value);
            } else if ($(this).is('input[type="date"]')) {
                var date = new Date(parseInt(value.substr(6)));
                var formattedDate = date.toISOString().split('T')[0];
                $(this).val(formattedDate);
            } else {
                $(this).val(value.toString());
            }
        } else {
            $(this).val('');
        }
    });
}


function populateCurrentAddressFields(addressDetails) {
    if (addressDetails) {
        document.getElementById("txtCurrentAddressLine1").value = addressDetails.AddressLine1;
        document.getElementById("txtCurrentAddressLine2").value = addressDetails.AddressLine2;
        document.getElementById("ddlCurrentCountry").value = addressDetails.CountryID.toString();
        PopulateStates(addressDetails.CountryID,true, function () {
            document.getElementById("ddlCurrentState").value = addressDetails.StateID.toString();
        });
        document.getElementById("txtCurrentPincode").value = addressDetails.Pincode;
    }
}

function populatePermanentAddressFields(addressDetails) {
    if (addressDetails) {
        document.getElementById("txtPermanentAddressLine1").value = addressDetails.AddressLine1;
        document.getElementById("txtPermanentAddressLine2").value = addressDetails.AddressLine2;
        document.getElementById("ddlPermanentCountry").value = addressDetails.CountryID.toString();
        PopulateStates(addressDetails.CountryID,false, function () {
            document.getElementById("ddlPermanentState").value = addressDetails.StateID.toString();
        });
        document.getElementById("txtPermanentPincode").value = addressDetails.Pincode;
    }
}


$(document).ready(function () {
    populateCountries("ddlCurrentCountry");
    populateCountries("ddlPermanentCountry");

    $("#ddlCurrentCountry").change(function () {
        var countryId = $(this).val();
        PopulateStates(countryId,true);
    });

    $("#ddlPermanentCountry").change(function () {
        var countryId = $(this).val();
        PopulateStates(countryId,false);
    });


    const urlParams = new URLSearchParams(window.location.search);
    const userID = urlParams.has("UserID") ? parseInt(urlParams.get("UserID")) : 0;

    if (userID != 0) {
        $.ajax({
            type: "POST",
            url: "UserDetails2.aspx/GetUserDetails",
            data: JSON.stringify({ userId: userID }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response.d);
                var userDetails = response.d;
                populateFields(userDetails);

                $.ajax({
                    type: "POST",
                    url: "UserDetails2.aspx/GetAddressDetails",
                    data: JSON.stringify({ userId: userID, addressType: 1 }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        console.log(response.d);
                        var addressDetails = response.d;
                        populateCurrentAddressFields(addressDetails);

                        $.ajax({
                            type: "POST",
                            url: "UserDetails2.aspx/GetAddressDetails",
                            data: JSON.stringify({ userId: userID, addressType: 2 }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                console.log(response.d);
                                var addressDetails = response.d;
                                populatePermanentAddressFields(addressDetails);
                            },
                            error: function (xhr, status, error) {
                                console.log(error);
                            }
                        });
                    },
                    error: function (xhr, status, error) {
                        console.log(error);
                    }
                });
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    }

});
