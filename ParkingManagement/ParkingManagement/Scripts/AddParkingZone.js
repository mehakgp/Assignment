$(function () {
    $('#parkingZoneTitle').blur(function () {
        var title = $(this).val();
        $.ajax({
            url: "/Initialize/IsParkingZoneTitleExists",
            type: 'GET',
            data: { parkingZoneTitle: title },
            success: function (data) {
                if (data) {
                    $('#errorMessage').text('Parking Zone Title already exists.');
                    $('#submitButton').prop('disabled', true);
                } else {
                    $('#errorMessage').text('');
                    $('#submitButton').prop('disabled', false);
                }
            }
        });
    });
});
