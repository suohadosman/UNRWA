$(document).ready(function () {
    $('#LabTestTypeId').on('change', function () {
        var typeId = $(this).val();
        if (typeId == '') typeId = 0;
        if (typeId !== '') {
            $.ajax({
                url: '/Doctor/CreatePreviewLabTestInType?typeId=' + typeId,
                success: function (result) {
                    $('#PreviewLabTestId').empty();
                    $('#PreviewLabTestId').append($('<option></option>'));
                    $.each(result, function (i, labtest) {
                        $('#PreviewLabTestId').append($('<option></option>').attr('value', labtest.id).text(labtest.name));
                    });
                },
                error: function () {
                    alert('something wrong!');
                }
            });
        }
    });
});