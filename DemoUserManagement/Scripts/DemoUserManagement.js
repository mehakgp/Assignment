
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
    //validation logic
}

