
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


    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;


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



    if (email === '' || !emailPattern.test(email)) {
        displayValidationMessage('txtEmail', 'Invalid Email');
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

    return isValid;
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


