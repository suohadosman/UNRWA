$(document).ready(function () {
    $('#MedicineTypeId').on('change', function () {
        var typeId = $(this).val();
        if (typeId == '') typeId = 0;
        if (typeId !== '') {
            $.ajax({
                url: '/Doctor/CreatePreviewMedicinesInType?typeId=' + typeId,
                success: function (result) {
                    $('#PreviewMedicineId').empty();
                    $('#PreviewMedicineId').append($('<option></option>'));
                    $.each(result, function (i, medicine) {
                        $('#PreviewMedicineId').append($('<option></option>').attr('value', medicine.id).text(medicine.name));
                    });
                },
                error: function () {
                    alert('something wrong!');
                }
            });
        }
    });
});