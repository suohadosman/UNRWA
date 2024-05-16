$(document).ready(function () {
    $('#LabTestTypeId').on('change', function () {
        var typeId = $(this).val();
        if (typeId == '') typeId = 0;
        if (typeId !== '') {
            $.ajax({
                url: '/Doctor/LabTestInType?typeId=' + typeId,
                success: function (result) {
                    $('#LabTestTable').empty();
                    //$('#MedicineTable').append($('<option></option>'));
                    $.each(result, function (i, labtest) {
                        ////$('#MedicineTable').append($('<tr></tr>').attr('value', medicine.id).text(medicine.name));
                        //var row = ('#MedicineTable').append($('<tr id="name"></tr>').text(medicine.name));
                        //row.className = medicine.id;
                        ////$('#AjaxDoctorByTeamId').append($('<option></option>').attr('value', doctor.id).text(doctor.name));
                        var table = document.getElementById("LabTestTable");
                        var row = document.createElement("tr");
                        var td1 = document.createElement("td");
                        var td2 = document.createElement("td");
                        var td3 = document.createElement("td");

                        var text1 = document.createTextNode(labtest.name);
                        var text2 = document.createTextNode(labtest.type)

                        td1.appendChild(text1);
                        td2.appendChild(text2);

                        var icon = document.createElement("i");
                        if (labtest.isAvilable == true) {
                            icon.className = "bx bxs-message-square-check";
                            icon.style = "color:#21762f; font-size: 25px;";
                        }
                        else {
                            icon.className = "bx bxs-message-square-x";
                            icon.style = "color:#c5091b ;font-size: 25px;";
                        }
                        td3.appendChild(icon);
                        row.appendChild(td1);
                        row.appendChild(td2);
                        row.appendChild(td3);

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