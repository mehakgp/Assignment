function submitForm() {
    var userDetails = {};
    var elements = document.querySelectorAll('.details');
    elements.forEach(function(element) 
    {
        var id = element.id;
        var value = element.value;
        userDetails[id] = value;
    });

}