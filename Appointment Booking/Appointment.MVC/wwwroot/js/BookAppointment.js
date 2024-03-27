$(document).ready(function () {
    $("#appointmentDate").change(function () {
        var doctorId = $("#doctorId").val();
        var appointmentDate = $("#appointmentDate").val();

        $.ajax({
            url: "/Appointment/GetTimeSlots",
            type: "GET",
            data: { doctorId: doctorId, appointmentDate: appointmentDate },
            success: function (data) {
                var options = "<option value=''>Select Time</option>";
                for (var i = 0; i < data.length; i++) {
                    options += "<option value='" + data[i] + "'>" + data[i] + "</option>";
                }
                $("#appointmentTime").html(options);
            },
            error: function () {
                alert("Error fetching time slots.");
            }
        });
    });
});