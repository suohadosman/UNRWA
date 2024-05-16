let btn = document.getElementById("next-appointment-btn");
btn.onclick = function (e) {
    $.ajax(
        {
            url: '/Doctor/GetNextAppointment',
            type: "POST",
            success: function () {
                console.log("done ");
            },
            error: function () {
                console.log("faild");

            }
        }    );
}