var userDetails = {};

function validateField(fieldName) {
    var inputElement = document.getElementById(fieldName);
    var errorElement = document.getElementById(fieldName + 'Error');

    // Reset previous error styles
    inputElement.classList.remove('error-border');
    errorElement.textContent = '';

    var inputValue = userDetails[fieldName] ? userDetails[fieldName].trim() : '';

    // Reset the flag for each field validation
    var isValid = true;

    if (inputValue === '' ) {
        errorElement.textContent = fieldName + ' is required.';
        inputElement.classList.add('error-border');
        isValid = false;
    } else if (fieldName === 'code' && (inputValue.length !== 6 || isNaN(inputValue))) {
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
    } else if (fieldName === 'age' && (inputValue.length !== 2 || isNaN(inputValue))) {
        errorElement.textContent = 'Invalid age. Must be a 2-digit number.';
        inputElement.classList.add('error-border');
        isValid = false;
    } else if ((fieldName === 'marks10th' || fieldName === 'marks12th') && (isNaN(inputValue) || inputValue < 1 || inputValue > 100)) {
        errorElement.textContent = 'Invalid value. Must be a number in the range 1-100.';
        inputElement.classList.add('error-border');
        isValid = false;
    } else if (fieldName === 'graduateMarks' && (isNaN(inputValue) || inputValue < 1 || inputValue > 10)) {
        errorElement.textContent = 'Invalid value. Must be a number in the range 1-10.';
        inputElement.classList.add('error-border');
        isValid = false;
    }

    return isValid;
}

function isValidEmail(email) {
    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

function isValidDate(dateString) {
    var regex = /^\d{4}-\d{2}-\d{2}$/;
    return regex.test(dateString);
}

function submitForm() {
    // Reset the global flag for each form submission
    window.flag = true;

    var elements = document.querySelectorAll('input.details');
    elements.forEach(function (element) {
        var id = element.id;
        var value = element.value;
        userDetails[id] = value;

        // Validate each field and update the global flag
        if (!validateField(id)) {
            window.flag = false;
        }
    });

    if (!window.flag) {
        return;
    }
    localStorage.setItem('userDetails', JSON.stringify(userDetails));

    // Show popup for user verification
    showPopup(userDetails);
}

function showPopup(userDetails) {
    // Display details in the popup
    var popupDetails = document.getElementById('popup-details');
    popupDetails.innerHTML = `
        <p><strong>First Name:</strong> ${userDetails.firstName}</p>
        <p><strong>Last Name:</strong> ${userDetails.lastName}</p>
        <p><strong>Email:</strong> ${userDetails.email}</p>
    `;

    // Show the popup and overlay
    document.getElementById('popup').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';
}

function clearForm() {
    // Clear local storage and form inputs
    localStorage.removeItem('userDetails');
    document.getElementById('registrationForm').reset();

    // Hide the popup and overlay
    document.getElementById('popup').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}

function confirmSubmit() {
    // Add your logic to handle the confirmed submission
    alert('Submitting form...');
    clearForm();
}
