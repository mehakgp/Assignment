var userDetails = {};
var flag = true;
function copyAddress() {
    var sameAddressCheckbox = document.getElementById('sameAddress');
    var permanentAddress1 = document.getElementById('permanentAddress1');
    var permanentAddress2 = document.getElementById('permanentAddress2');
    var permanentPincode = document.getElementById('permanentPincode');
    var permanentCountry = document.getElementById('permanentCountry');
    var permanentState = document.getElementById('permanentState');

    if (sameAddressCheckbox.checked) {
        permanentAddress1.value = document.getElementById('currentAddress1').value;
        permanentAddress2.value = document.getElementById('currentAddress2').value;
        permanentPincode.value = document.getElementById('currentPincode').value;
        permanentCountry.value = document.getElementById('currentCountry').value;
        permanentState.value = document.getElementById('currentState').value;

        // Set the "readonly" attribute for permanent address fields
        permanentAddress1.setAttribute('readonly', true);
        permanentAddress2.setAttribute('readonly', true);
        permanentPincode.setAttribute('readonly', true);
        permanentCountry.setAttribute('readonly', true);
        permanentState.setAttribute('readonly', true);
    } else {
        // If checkbox is unchecked, remove the "readonly" attribute
        permanentAddress1.removeAttribute('readonly');
        permanentAddress2.removeAttribute('readonly');
        permanentPincode.removeAttribute('readonly');
        permanentCountry.removeAttribute('readonly');
        permanentState.removeAttribute('readonly');
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
    var inputElement = document.getElementById(fieldName);
    var errorElement = document.getElementById(fieldName + 'Error');

    inputElement.classList.remove('error-border');
    errorElement.textContent = '';

    var inputValue = userDetails[fieldName] ? userDetails[fieldName].trim() : '';


    var isValid = true;

    if (inputValue === '') {
        errorElement.textContent = fieldName + ' is required.';
        inputElement.classList.add('error-border');
        isValid = false;
    } else if ((fieldName === 'currentPincode'|| fieldName === 'permanentPincode') && (inputValue.length !== 6 || isNaN(inputValue))) {
        errorElement.textContent = 'Invalid pincode. Must be a 6-digit number.';
        inputElement.classList.add('error-border');
        isValid = false;
    } else if (fieldName === 'email' && !isValidEmail(inputValue)) {
        errorElement.textContent = 'Invalid email address.';
        inputElement.classList.add('error-border');
        isValid = false;
    } else if (fieldName === 'dob' && !isValidDate(inputValue)) {
        errorElement.textContent = 'Invalid date of birth.';
        inputElement.classList.add('error-border');
        isValid = false;
    } else if (fieldName === 'phone' && (inputValue.length !== 10 || isNaN(inputValue))) {
        errorElement.textContent = 'Invalid phone number. Must be a 10-digit number.';
        inputElement.classList.add('error-border');
        isValid = false;
    } else if (fieldName === 'aadhar' && (inputValue.length !== 12 || isNaN(inputValue))) {
        errorElement.textContent = 'Invalid Aadhar Number. Must be a 12-digit number.';
        inputElement.classList.add('error-border');
        isValid = false;
    }
    else if ((fieldName === 'marks10th' || fieldName === 'marks12th') && (isNaN(inputValue) || inputValue < 1 || inputValue > 100)) {
        errorElement.textContent = 'Invalid value. Must be a number in the range 1-100.';
        inputElement.classList.add('error-border');
        isValid = false;
    } else if (fieldName === 'graduateMarks' && (isNaN(inputValue) || inputValue < 1 || inputValue > 10)) {
        errorElement.textContent = 'Invalid value. Must be a number in the range 1-10.';
        inputElement.classList.add('error-border');
        isValid = false;
    } else if (fieldName === "photo" && inputElement.files[0].type != 'image/jpeg') {
        errorElement.textContent = 'Invalid file. Must be in jpeg';
        inputElement.classList.add('error-border');
        isValid = false;
    } else if (fieldName === "resume" && inputElement.files[0].type != 'application/pdf') {
        errorElement.textContent = 'Invalid file. Must be in pdf';
        inputElement.classList.add('error-border');
        isValid = false;
    }


    return isValid;
}

function submitForm() {
    flag = true;
     var flag2=true;
    var elements = document.querySelectorAll('.details');
    elements.forEach(function (element) {
        var key = element.id;
        var value = element.value;
        userDetails[key] = value;
        if (key === 'firstName' || key === 'currentAddress1'|| key === 'permanentAddress1' || key === 'currentPincode' ||key === 'permanentPincode'|| key === 'dob' || key === 'aadhar' || key === 'photo' || key === 'resume' || key === 'marks10th' || key === 'marks12th' || key === 'graduateMarks' || key === 'email' || key === 'phone') {
            flag = validateField(key);
            if (flag == false)
               flag2=false; 

        }

    });
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
    var popupDetails = document.getElementById('popup-details');
    popupDetails.innerHTML = `
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
`;

    document.getElementById('popup').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';
}

function clearForm() {
    localStorage.removeItem('userDetails');
    document.getElementById('registrationForm').reset();

    document.getElementById('popup').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}
function closePopup() {
    document.getElementById('popup').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}
function confirmSubmit() {

    alert('Submitting form...');
    clearForm();
}
