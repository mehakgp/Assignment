var flag=true;
function validateField(fieldName) {
    var inputElement = document.getElementById(fieldName);
    var errorElement = document.getElementById(fieldName + 'Error');

    inputElement.classList.remove('error-border');
    errorElement.textContent = '';

    if (userDetails[fieldName].trim() === '') {
        errorElement.textContent = fieldName + ' is required.';
        inputElement.classList.add('error-border');
        flag=false;
    }
}


function submitForm() {
    var userDetails = {};
    var elements = document.querySelectorAll('.details');
    elements.forEach(function(element) 
    {
        var id = element.id;
        var value = element.value;
        userDetails[id] = value;
    });
    for (var key in userDetails) {
        if (userDetails.hasOwnProperty(key))
         {
            if (key === 'firstName')
                validateField('firstName');
            if (key === 'address1')
                validateField('address1');
            if (key === 'code')
                validateField('code');
            if (key === 'email')
                validateField('email');
            if (key === 'dob')
                validateField('dob');
            if (key === 'phoneno')
                validateField('phoneno');
            if (key === 'age')
                validateField('age');
            if (key === '10thmarks')
                validateField('10thmarks');
            if (key === '12thmarks')
                validateField('12thmarks');
            if (key === 'cgpa')
                validateField('cgpa');
                if (key === 'photo')
                validateField('resume');            
                if(flag==false)
                return;
        
            
            

        }
    }
   
    
}
