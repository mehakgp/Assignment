$(document).ready(function () {
        $('#myModal').modal('hide');
    var storedDetails = localStorage.getItem('userDetails');

    if (storedDetails) {
        var userDetails = JSON.parse(storedDetails);
        for (var fieldName in userDetails) {
            if (userDetails.hasOwnProperty(fieldName)) {
                if (fieldName === 'photo' || fieldName === 'resume')
                    $('#' + fieldName + 'Error').text('Please select the file again!');
                else
                    $('#' + fieldName).val(userDetails[fieldName]);
            }
        }
    }
});
var userDetails = {};
var flag = true;
function copyAddress() {
    var sameAddressCheckbox = $('#sameAddress');
    var permanentFields = ['#permanentAddress1', '#permanentAddress2', '#permanentPincode', '#permanentCountry', '#permanentState'];

    if (sameAddressCheckbox.prop('checked')) {
        var currentFields = ['#currentAddress1', '#currentAddress2', '#currentPincode', '#currentCountry', '#currentState'];

        for (var i = 0; i < permanentFields.length; i++) {
            var currentField = $(currentFields[i]);
            var permanentField = $(permanentFields[i]);
            permanentField.val(currentField.val()).prop('readonly', true);
        }
    } else {
        for (var i = 0; i < permanentFields.length; i++) {
            $(permanentFields[i]).prop('readonly', false);
        }
    }
}
function isValidEmail(email) {
    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

function isValidDate(dateString) {
    var regex = /^\d{4}-\d{2}-\d{2}$/;
    return regex.test(dateString);
}

function validateField(fieldName) {
    var inputElement = $('#' + fieldName);
    var errorElement = $('#' + fieldName + 'Error');

    inputElement.removeClass('error-border');
    errorElement.text('');

    var inputValue = userDetails[fieldName] ? userDetails[fieldName].trim() : '';

    var isValid = true;

    if (inputValue === '') {
        errorElement.text(fieldName + ' is required.');
        inputElement.addClass('error-border');
        isValid = false;
    } else if ((fieldName === 'currentPincode' || fieldName === 'permanentPincode') && (inputValue.length !== 6 || isNaN(inputValue))) {
        errorElement.text('Invalid pincode. Must be a 6-digit number.');
        inputElement.addClass('error-border');
        isValid = false;
    } else if (fieldName === 'email' && !isValidEmail(inputValue)) {
        errorElement.text('Invalid email address.');
        inputElement.addClass('error-border');
        isValid = false;
    } else if (fieldName === 'dob' && !isValidDate(inputValue)) {
        errorElement.text('Invalid date of birth.');
        inputElement.addClass('error-border');
        isValid = false;
    } else if (fieldName === 'phone' && (inputValue.length !== 10 || isNaN(inputValue))) {
        errorElement.text('Invalid phone number. Must be a 10-digit number.');
        inputElement.addClass('error-border');
        isValid = false;
    } else if (fieldName === 'aadhar' && (inputValue.length !== 12 || isNaN(inputValue))) {
        errorElement.text('Invalid Aadhar Number. Must be a 12-digit number.');
        inputElement.addClass('error-border');
        isValid = false;
    } else if ((fieldName === 'marks10th' || fieldName === 'marks12th') && (isNaN(inputValue) || inputValue < 1 || inputValue > 100)) {
        errorElement.text('Invalid value. Must be a number in the range 1-100.');
        inputElement.addClass('error-border');
        isValid = false;
    } else if (fieldName === 'graduateMarks' && (isNaN(inputValue) || inputValue < 1 || inputValue > 10)) {
        errorElement.text('Invalid value. Must be a number in the range 1-10.');
        inputElement.addClass('error-border');
        isValid = false;
    } else if (fieldName === 'photo' && inputElement[0].files[0].type !== 'image/jpeg') {
        errorElement.text('Invalid file. Must be in jpeg');
        inputElement.addClass('error-border');
        isValid = false;
    } else if (fieldName === 'resume' && inputElement[0].files[0].type !== 'application/pdf') {
        errorElement.text('Invalid file. Must be in pdf');
        inputElement.addClass('error-border');
        isValid = false;
    }

    return isValid;
}

function submitForm() {
    flag = true;
    var flag2 = true;


    var testArray = $('.details');
    for (var i = 0; i < testArray.length; i++) {
        element = testArray[i];
        var key = $(element).attr('id');
        var value = $(element).val();
        userDetails[key] = value;
        if ($(element).attr('data-mandatory') === 'true') {
            flag = validateField(key);
            if (flag == false)
                flag2 = false;

        }
    }

    if (flag2 == false)
    {
            $('#myModal').modal('hide');
            return;
    }
       
    localStorage.setItem('userDetails', JSON.stringify(userDetails));

    showPopup(userDetails);
}
function calculateAge(dob) {

    var dobDate = new Date(dob);
    var currentDate = new Date();

    var age = currentDate.getFullYear() - dobDate.getFullYear();
    if (currentDate.getMonth() < dobDate.getMonth() || (currentDate.getMonth() === dobDate.getMonth() && currentDate.getDate() < dobDate.getDate())) {
        age--;
    }

    return age;
}

function showPopup(userDetails) {

    var age = calculateAge(userDetails.dob);
    var popupDetails = $('.modal-body');
    popupDetails.html(`
    <p><strong>Name:</strong> ${userDetails.firstName} ${userDetails.middleName} ${userDetails.lastName}</p>
    <p><strong> Current Address:</strong> ${userDetails.currentAddress1}&nbsp; ${userDetails.currentAddress2}</p>
    <p><strong>Pincode:</strong> ${userDetails.currentPincode}</p>
    <p><strong>Country:</strong> ${userDetails.currentCountry || 'NA'}&nbsp;&nbsp;<strong>State:</strong> ${userDetails.currentState || 'NA'}</p>
    <p><strong> Permanent Address:</strong> ${userDetails.permanentAddress1 || 'NA'}&nbsp; ${userDetails.permanentAddress2}</p>
    <p><strong>Pincode:</strong> ${userDetails.permanentPincode}</p>
    <p><strong>Country:</strong> ${userDetails.permanentCountry || 'NA'}&nbsp;&nbsp;<strong>State:</strong> ${userDetails.permanentState || 'NA'}</p>
    <p><strong>Gender:</strong> ${userDetails.gender || 'NA'}&nbsp;&nbsp;<strong>DOB:</strong> ${userDetails.dob || 'NA'} <strong>&nbsp;&nbsp;Age:</strong> ${age || 'NA'}</p>
    <p><strong>Photo:</strong> ${userDetails.photo || 'NA'}&nbsp;&nbsp;<strong>Resume:</strong> ${userDetails.resume || 'NA'}</p>
    <p><strong>10th Marks:</strong> ${userDetails.marks10th || 'NA'}&nbsp;&nbsp;<strong>Board:</strong> ${userDetails.board || 'NA'}
    <strong>School:</strong> ${userDetails.school10th || 'NA'}&nbsp;&nbsp;<strong>Year:</strong> ${userDetails.year10th || 'NA'}</p>
    <p><strong>12th Marks:</strong> ${userDetails.marks12th || 'NA'}&nbsp;&nbsp;<strong>Board:</strong> ${userDetails.board2 || 'NA'}
    <strong>School:</strong> ${userDetails.school12th || 'NA'}&nbsp;&nbsp;<strong>Year:</strong> ${userDetails.year12th || 'NA'}</p>
    <p><strong>CGPA:</strong> ${userDetails.graduateMarks || 'NA'}&nbsp;&nbsp;<strong>University:</strong> ${userDetails.university || 'NA'} <strong>Year:</strong> ${userDetails.graduateYear || 'NA'}</p>
    <p><strong>Email:</strong> ${userDetails.email || 'NA'}&nbsp;&nbsp;<strong>Phone:</strong> ${userDetails.phone || 'NA'}</p>
    <p><strong>Hobbies:</strong> ${userDetails.hobbies || 'NA'}</p>
    <p><strong>Feedback/comments:</strong> ${userDetails.comments || 'NA'}</p>
`)

$('#myModal').modal('show');
}

function resetForm() {
    localStorage.removeItem('userDetails');
    $('#registrationForm')[0].reset();
}
function clearForm() {
    localStorage.removeItem('userDetails');
    $('#registrationForm')[0].reset();
    $('#myModal').modal('hide');
}
function confirmSubmit() {
        $('#myModal').modal('hide');
    alert('Submitting form...');
    clearForm();
}
