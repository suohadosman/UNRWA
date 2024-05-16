$(document).ready(function () {
    $('#MedicineTypeId').on('change', function () {
        var typeId = $(this).val();
        if (typeId == '') typeId = 0;
        if (typeId !== '') {
            $.ajax({
                url: '/Doctor/MedicinesInType?typeId=' + typeId,
                success: function (result) {
                    $('#MedicineTable').empty();
                    //$('#MedicineTable').append($('<option></option>'));
                    $.each(result, function (i, medicine) {
                        ////$('#MedicineTable').append($('<tr></tr>').attr('value', medicine.id).text(medicine.name));
                        //var row = ('#MedicineTable').append($('<tr id="name"></tr>').text(medicine.name));
                        //row.className = medicine.id;
                        ////$('#AjaxDoctorByTeamId').append($('<option></option>').attr('value', doctor.id).text(doctor.name));
                        var table = document.getElementById("MedicineTable");
                        var row = document.createElement("tr");
                        var td1 = document.createElement("td");
                        var td2 = document.createElement("td");
                        var td3 = document.createElement("td");
                        var td4 = document.createElement("td");

                        var text1 = document.createTextNode(medicine.name);
                        var text2 = document.createTextNode(medicine.type)
                        var text3 = document.createTextNode(medicine.amount)

                        td1.appendChild(text1);
                        td2.appendChild(text2);
                        td3.appendChild(text3);

                        var icon = document.createElement("i");
                        if (medicine.amount > 0) {
                            icon.className = "bx bxs-message-square-check";
                            icon.style = "color:#21762f; font-size: 25px;";

                        }
                        else {
                            icon.className = "bx bxs-message-square-x";
                            icon.style = "color:#c5091b ;font-size: 25px;";
                        }
                        td4.appendChild(icon);
                        row.appendChild(td1);
                        row.appendChild(td2);
                        row.appendChild(td3);
                        row.appendChild(td4);

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