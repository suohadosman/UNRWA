$(document).ready(function () {
    $('#saveMedicine').on('click', function () {
        var previewId = $('#PreviewId').val();
        var previewMedicineId = $('#PreviewMedicineId').val();
        var medicineAmount = $('#medicineAmount').val();
        var idValidation = document.getElementById("medicineIdValidation");
        var amountValidation = document.getElementById("amountValidation");
        if (previewMedicineId == '') {
            idValidation.style.display = "block";
        }
        if (medicineAmount == 0) {
            amountValidation.style.display = "block";
        }
        else {
            $.ajax({
                url: '/Doctor/AddPreviewMedicin?previewId=' + previewId + '&previewMedicineId=' + previewMedicineId + '&medicineAmount=' + medicineAmount,
                success: function () {
                    idValidation.style.display = "none";
                    amountValidation.style.display = "none";
                    var x = document.getElementById("snackbar");
                    x.className = "show";
                    x.innerText = "The medicine has been added successfully"
                    setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
                },
                error: function () {
                    var x = document.getElementById("snackbar");
                    x.className = "error";
                    x.innerText = "Add medicine failed"
                    setTimeout(function () { x.className = x.className.replace("error", ""); }, 3000);
                }
            });

        }
    });
});