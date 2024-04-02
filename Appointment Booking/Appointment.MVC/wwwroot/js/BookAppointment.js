$(document).ready(function () {
    $("#appointmentDate").change(function () {
        var doctorId = $("#doctorId").val();
        var appointmentDate = $("#appointmentDate").val();

        $.ajax({
            url: "/Appointment/GetTimeSlots",
            type: "GET",
            data: { doctorId: doctorId, appointmentDate: appointmentDate },
            success: function (data)
            {
                var timeSlotsDiv = $("#timeSlots");
                timeSlotsDiv.empty();

                for (var i = 0; i < data.length; i++) {
                    var timeSlot = $("<div class='time-slot'></div>")
                        .text(formatTime(data[i]))
                        .attr("data-time", data[i])
                        .click(function () {
                            $(".time-slot").removeClass("selected");
                            $(this).addClass("selected");
                            $("#selectedTimeSlot").val($(this).attr("data-time"));
                        });

                    timeSlotsDiv.append(timeSlot);
                }
                $("#appointmentTimeLabel").show();
            },
            error: function ()
            {
                alert("Error fetching time slots.");
            }
        });
    });
});
function formatTime(time) {
    var hours = parseInt(time.split(":")[0]);
    var minutes = parseInt(time.split(":")[1]);

    var ampm = hours >= 12 ? 'PM' : 'AM';
    hours = hours % 12;
    hours = hours ? hours : 12; 

    return hours.toString().padStart(2, '0') + ':' + minutes.toString().padStart(2, '0') + ' ' + ampm;
}
