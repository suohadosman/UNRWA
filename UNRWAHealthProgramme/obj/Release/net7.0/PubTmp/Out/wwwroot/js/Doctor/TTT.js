
$(document).ready(function () {
    $('#saveIllness').on('click', function () {
        var previewId = $('#PreviewId').val();
        var PreviewIllnessId = $('#PreviewIllnessId').val();
        $.ajax({
            url: '/Doctor/AddPreviewIllness?previewId=' + previewId + '&previewIllnessId=' + PreviewIllnessId,
            success: function (result) {
                window.onload = function what() {
                    var toast = document.getElementById('#toast');
                    
                };
                toast.innerText = "Hello World!";
                toast.className = "toater";
                setTimeout(function () {
                    toast.className = "toater";
                }, 3000);
            },
            error: function () {
                alert('something wrong!');
            }
        });

    });
});

