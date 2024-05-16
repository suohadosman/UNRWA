$(document).ready(function () {
    $('#PreviewIllnessTypeId').on('change', function () {
        var typeId = $(this).val();
        if (typeId == '') typeId = 0;
        if (typeId !== '') {
            $.ajax({
                url: '/Doctor/IllnessInInType?typeId=' + typeId,
                success: function (result) {
                    $('#PreviewIllnessId').empty();
                    $('#PreviewIllnessId').append($('<option></option>'));
                    $.each(result, function (i, illness) {
                        $('#PreviewIllnessId').append($('<option></option>').attr('value', illness.id).text(illness.name));
                    });
                },
                error: function () {
                    alert('something wrong!');
                }
            });
        }
    });
});