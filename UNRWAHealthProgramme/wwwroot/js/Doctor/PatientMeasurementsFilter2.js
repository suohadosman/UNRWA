$(document).ready(function () {
    $('#MeasurementId').on('change', function () {
        var meId = $(this).val();
        var personId = $('#personId').val();
        if (meId == '') meId = 0;
        if (meId !== 0) {
            $.ajax({
                url: '/Doctor/PatientMeasurementResultInMesurementName?personId=' + personId + '&meId=' + meId,
                success: function (result) {
                    $('#Table').empty();
                    $.each(result, function (i, result) {
                        var table = document.getElementById("Table");
                        var row = document.createElement("tr");
                        var td1 = document.createElement("td");
                        var td2 = document.createElement("td");
                        var td3 = document.createElement("td");

                        var text1 = document.createTextNode(result.name);
                        var text2 = document.createTextNode(result.date)
                        var text3 = document.createTextNode(result.result result.unit)


                        td1.appendChild(text1);
                        td2.appendChild(text2);
                        td3.appendChild(text3);

                 
                        row.appendChild(td1);
                        row.appendChild(td2);
                        row.appendChild(td3);
                        table.appendChild(row);

                    });
                },
                error: function () {
                    alert('something wrong!');
                }
            });
        }
    });
});