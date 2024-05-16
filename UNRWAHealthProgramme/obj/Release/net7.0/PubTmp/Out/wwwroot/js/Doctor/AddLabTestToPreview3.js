$(document).ready(function () {
    $('#saveLabtest').on('click', function () {
        var previewId = $('#PreviewId').val();
        var PreviewLabTestId = $('#PreviewLabTestId').val();
        var labTestDate = $('#LabTestDate').val();
        $.ajax({
            url: '/Doctor/AddLabTestToPreview?previewId=' + previewId + '&PreviewLabTestId=' + PreviewLabTestId + '&labTestDate=' + labTestDate,

            success: function () {
                var x = document.getElementById("snackbar");
                x.className = "show";
                x.innerText = "The lab test has been added successfully"
                setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
            },
            error: function () {
                var x = document.getElementById("snackbar");
                x.className = "error";
                x.innerText = "Add lab test failed"
                setTimeout(function () { x.className = x.className.replace("error", ""); }, 3000);
            }
        });

    });
});