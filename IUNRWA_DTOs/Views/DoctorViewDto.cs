using IUNRWA_DTOs.IllnessDto;
using IUNRWA_DTOs.LabTestDto;
using IUNRWA_DTOs.MedicinePreviewDto;
using IUNRWA_DTOs.PersonDto;
using IUNRWA_DTOs.PreviewMedicineDto;
using IUNRWA_DTOs.ReservationDto;
using IUNRWA_Model.UNRWAUsers;
using IUNRWA_ShareKernal.Enum.LabTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IUNRWA_DTOs.Views
{
    public class DoctorViewDto
    {
        public string? DoctorName { get; set; }
        public List<ReservationDto.ReservationDto>? DoctorReservations { get; set; } = new();
        public List<MedicineDto.MedicineDto>? Medicines { get; set; } = new();
        public List<MedicineTypeDto.MedicineTypeDto>? MedicineTypes { get; set; } = new();
        public List<LabTestDto.LabTestDto>? LabTests { get; set; } = new();
        public List<IUNRWA_ShareKernal.Enum.LabTest.LabTestTypeDto>? LabTestTypes { get; set; } = new();
        public List<LabTestResultDto>? LabTestResults { get; set; } = new();
        public List<LabTestResultDto>? AllPatientLabTests { get; set; } = new();

        public PersonDto.PersonDto? PersonInfo { set; get; }
        public PreviewMedicineDto.PreviewMedicineDto? LastMedicine{ get; set; }
        public List<PreviewMedicineDto.PreviewMedicineDto>? AllPatientMedicine { get; set; } = new();
        public List<TheMeasurementDto.TheMeasurementDto>? AllPatientMeasurements { get; set; } = new();
        public List<TheMeasurementDto.TheMeasurementDto>? AllMeasurements { get; set; } = new();
        public List<IllnessTypDto>? IllnessTypes { get; set; } = new();
        public List<IllnessDto.IllnessDto>? AllIllnesses { get; set; } = new();

        public PreviewMedicineFormDto? PreviewMedicineFormDto { get; set; }
        public int? MedicineTypeId { get; set; }
        public int? LabTestTypeId { get; set; }
        public int? MeasurementId { get; set; }

        public int? PreviewId { get; set; }
        public int? PreviewMedicineId { get; set; }
        public int? MedicineAmount { get; set; }
        public int? IllnessTypeId { get; set; }
        public int? IllnessId { get; set; }
        public int? LabTestId { get; set; }
        public int ReservationId { get; set; }
        public List<PreviewMedicineDto.PreviewMedicineDto>? PersonNCdMedicines { get; set; } = new();

        public Doctor User { get; set; }


    }
}
