
$(document).ready(function () {
    $('#saveIllness').on('click', function () {
        var previewId = $('#PreviewId').val();
        var PreviewIllnessId = $('#PreviewIllnessId').val();
        var idValidation = document.getElementById("IllnessIdValidation");
        if (PreviewIllnessId == '') {
            idValidation.style.display = "block";
        }
        else {
            $.ajax({
                url: '/Doctor/AddPreviewIllness?previewId=' + previewId + '&previewIllnessId=' + PreviewIllnessId,
                success: function () {
                    idValidation.style.display = "none"
                    var x = document.getElementById("snackbar");
                    x.className = "show";
                    x.innerText = "The Illness has been added successfully"
                    setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
                },
                error: function () {
                    var x = document.getElementById("snackbar");
                    x.className = "error";
                    x.innerText = "Add Illness failed"
                    setTimeout(function () { x.className = x.className.replace("error", ""); }, 3000);
                }
            });
        }

    });
});