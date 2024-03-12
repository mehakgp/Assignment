$(document).ready(function () {
    $('#selectedZoneIds').select2();

    $('[id^="vehicleRegistrationNumber"]').blur(function () {
        var regex = /^[A-Z]{2}[ -]?[0-9]{2}[ -]?[A-Z]{1,2}[ -]?[0-9]{4}$/;
        var vehicleRegNumber = $(this).val();
        var parkingSpaceId = $(this).attr('id').replace('vehicleRegistrationNumber_', '');

        if (!regex.test(vehicleRegNumber)) {
            $('#vehicleRegistrationNumberError').show();
            $('#bookParkingSpaceButton_' + parkingSpaceId).prop('disabled', true);
        } else {
            $('#vehicleRegistrationNumberError').hide();
            $('#bookParkingSpaceButton_' + parkingSpaceId).prop('disabled', false);
        }
    });

    //setTimeout(function () {
    //    location.reload();
    //}, 30000);

});

