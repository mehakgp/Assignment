$(document).ready(function () {
    $('#selectedZoneIds').select2();

    $('[id^="vehicleRegistrationNumber"]').blur(function () {
        var regex = /^[A-Z]{2}[ -]?[0-9]{2}[ -]?[A-Z]{1,2}[ -]?[0-9]{4}$/;
        var vehicleRegNumber = $(this).val();
        var parkingSpaceId = $(this).attr('id').replace('vehicleRegistrationNumber_', '');

        if (!regex.test(vehicleRegNumber)) {
            alert("Invalid Vehicle Registration Number.")
            $('#bookParkingSpaceButton_' + parkingSpaceId).prop('disabled', true);
        } else {
            $('#bookParkingSpaceButton_' + parkingSpaceId).prop('disabled', false);
        }
    });
});
