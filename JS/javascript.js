var userDetails = {};

function validateField(fieldName) {
    var inputElement = document.getElementById(fieldName);
    var errorElement = document.getElementById(fieldName + 'Error');

    inputElement.classList.remove('error-border');
    errorElement.textContent = '';

    var inputValue = userDetails[fieldName] ? userDetails[fieldName].trim() : '';

   
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
    window.flag = true;

    var elements = document.querySelectorAll('input.details');
    elements.forEach(function (element) {
        var id = element.id;
        var value = element.value;
        userDetails[id] = value;

        // if (!validateField(id)) {
        //     window.flag = false;
        // }
    });


    // if (!window.flag) 
    //{
    //     return;
    // }
    localStorage.setItem('userDetails', JSON.stringify(userDetails));

    showPopup(userDetails);
}

function showPopup(userDetails) {
    
    var popupDetails = document.getElementById('popup-details');
    popupDetails.innerHTML = `
        <p><strong>Name:</strong> ${userDetails.firstName} ${userDetails.middleName} ${userDetails.lastName}</p>
        <p><strong>Address:</strong> ${userDetails.address1},${userDetails.address2}</p>
        <p><strong>Pincode:</strong> ${userDetails.code}</p>
        <p><strong>Country:</strong> ${userDetails.country} <strong>State:</strong> ${userDetails.state}</p>
        <p><strong>Gender:</strong> ${userDetails.gender}</p>
        <p><strong>DOB:</strong> ${userDetails.dob} <strong>Age:</strong> ${userDetails.age}</p>
        <p><strong>Photo:</strong> ${userDetails.photo} <strong>Resume:</strong> ${userDetails.resume}</p>
        <p><strong>10th Marks:</strong> ${userDetails.marks10th} <strong>Board:</strong> ${userDetails.board}</p>
        <p><strong>School:</strong> ${userDetails.school10th} <strong>Year:</strong> ${userDetails.year10th}</p>
        <p><strong>12th Marks:</strong> ${userDetails.marks12th} <strong>Board:</strong> ${userDetails.board2}</p>
        <p><strong>School:</strong> ${userDetails.school12th} <strong>Year:</strong> ${userDetails.year12th}</p>
        <p><strong>CGPA:</strong> ${userDetails.graduateMarks} <strong>University:</strong> ${userDetails.university} <strong>Year:</strong> ${userDetails.graduateYear}</p>
        <p><strong>Email:</strong> ${userDetails.email}</p>
        <p><strong>Phone:</strong> ${userDetails.phone}</p>
        <p><strong>Hobbies:</strong> ${userDetails.hobbies}</p>
        <p><strong>Feedback/comments:</strong> ${userDetails.comments}</p>

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

function confirmSubmit() {
   
    alert('Submitting form...');
    clearForm();
}
