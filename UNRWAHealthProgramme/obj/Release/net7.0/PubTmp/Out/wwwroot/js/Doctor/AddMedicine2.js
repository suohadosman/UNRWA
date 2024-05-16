$(document).ready(function () {
    $('#saveMedicine').on('click', function () {
        var previewId = $('#PreviewId').val();
        var previewMedicineId = $('#PreviewMedicineId').val();
        var medicineAmount = $('#medicineAmount').val();
        $.ajax({
            url: '/Doctor/AddPreviewMedicin?previewId=' + previewId + '&previewMedicineId=' + previewMedicineId + '&medicineAmount=' + medicineAmount,
            success: function () {
                var x = document.getElementById("snackbar");
                x.className = "show";
                x.innerText ="The medicine has been added successfully"
                setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
            },
            error: function () {
                var x = document.getElementById("snackbar");
                x.className = "error";
                x.innerText = "Add medicine failed"
                setTimeout(function () { x.className = x.className.replace("error", ""); }, 3000);            }
        });

    });
});