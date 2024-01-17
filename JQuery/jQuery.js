var userDetails = {};
var flag = true;
function copyAddress() {
    var sameAddressCheckbox = $('#sameAddress');
    var permanentAddress1 = $('#permanentAddress1');
    var permanentAddress2 = $('#permanentAddress2');
    var permanentPincode = $('#permanentPincode');
    var permanentCountry = $('#permanentCountry');
    var permanentState = $('#permanentState');

    if (sameAddressCheckbox.prop('checked')) {
        var currentAddress1 = $('#currentAddress1').val();
        var currentAddress2 = $('#currentAddress2').val();
        var currentPincode = $('#currentPincode').val();
        var currentCountry = $('#currentCountry').val();
        var currentState = $('#currentState').val();

        permanentAddress1.val(currentAddress1).prop('readonly', true);
        permanentAddress2.val(currentAddress2).prop('readonly', true);
        permanentPincode.val(currentPincode).prop('readonly', true);
        permanentCountry.val(currentCountry).prop('readonly', true);
        permanentState.val(currentState).prop('readonly', true);
    } else {
        permanentAddress1.prop('readonly', false);
        permanentAddress2.prop('readonly', false);
        permanentPincode.prop('readonly', false);
        permanentCountry.prop('readonly', false);
        permanentState.prop('readonly', false);
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
    } else if ((fieldName === 'currentPincode'||fieldName === 'permanentPincode') && (inputValue.length !== 6 || isNaN(inputValue))) {
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
     var flag2=true;

   
        var testArray = $('.details');
        for(var i = 0; i < testArray.length; i++)
        {
            element=testArray[i];
            var key = $(element).attr('id');
            var value = $(element).val();
            userDetails[key] = value;
            if (key === 'firstName' || key === 'currentAddress1' || key === 'permanentAddress1'|| key === 'currentPincode' ||key==='permanentPincode'|| key === 'dob' || key === 'aadhar' || key === 'photo' || key === 'resume' || key === 'marks10th' || key === 'marks12th' || key === 'graduateMarks' || key === 'email' || key === 'phone') {
                flag = validateField(key);
                if (flag==false)
                flag2=false;
                    
            }
        }
    
    if (flag2 == false)
        return;
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
    var popupDetails = $('#popup-details');
    popupDetails.html ( `
    <p><strong>Name:</strong> ${userDetails.firstName} ${userDetails.middleName} ${userDetails.lastName}</p>
    <p><strong> Current Address:</strong> ${userDetails.currentAddress1}&nbsp; ${userDetails.currentAddress2}</p>
    <p><strong>Pincode:</strong> ${userDetails.currentPincode}</p>
    <p><strong>Country:</strong> ${userDetails.currentCountry || 'NA'}&nbsp;&nbsp;<strong>State:</strong> ${userDetails.currentState || 'NA'}</p>
    <p><strong> Permanent Address:</strong> ${userDetails.permanentAddress1 || 'NA'}&nbsp; ${userDetails.permanentAddress2}</p>
    <p><strong>Pincode:</strong> ${userDetails.permanentPincode }</p>
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

$('#popup').css('display', 'block');
$('#overlay').css('display', 'block');

}

function clearForm() {
    localStorage.removeItem('userDetails');
    $('#registrationForm')[0].reset();
    $('#popup').css('display', 'none');
    $('#overlay').css('display', 'none');
}
function closePopup() {
    $('#popup').css('display', 'none');
    $('#overlay').css('display', 'none');
}
function confirmSubmit() {

    alert('Submitting form...');
    clearForm();
}
