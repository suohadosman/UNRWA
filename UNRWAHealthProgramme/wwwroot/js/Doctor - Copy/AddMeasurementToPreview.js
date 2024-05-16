$(document).ready(function () {
    $('#saveMeasurement').on('click', function () {
        var previewId = $('#PreviewId').val();
        var measurementId = $('#PreviewMeasurementId').val();
        $.ajax({
            url: '/Doctor/AddMeasurementToPreview?previewId=' + previewId + '&mesurementId=' + measurementId,

            success: function () {
                var x = document.getElementById("snackbar");
                x.className = "show";
                x.innerText = "The measurement has been added successfully"
                setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
            },
            error: function () {
                var x = document.getElementById("snackbar");
                x.className = "error";
                x.innerText = "Add measurement failed"
                setTimeout(function () { x.className = x.className.replace("error", ""); }, 3000);
            }
        });

    });
});