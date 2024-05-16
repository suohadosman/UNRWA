using IUNRWA_DTOs.IllnessDto;
using IUNRWA_DTOs.LabTestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.Views
{
    public class PatientViewDto
    {
        public int PersonIdToSearch { get; set; }
        public PersonDto.PersonDto PersonInfo { get; set; }
        public List<ReservationDto.ReservationDto> AllNextReservations { get; set; } = new();
        public List<TheMeasurementDto.TheMeasurementDto> AllMeasurements { get; set; } = new();
        public List<MedicineDto.MedicineDto> AllMedicines { get; set; } = new();
        public List<LabTestResultDto>? AllPatientLabTests { get; set; } = new();
        public List<IUNRWA_ShareKernal.Enum.LabTest.LabTestTypeDto>? LabTestTypes { get; set; } = new();
        public int? LabTestTypeId { get; set; }
        public int? IllnessTypeId { get; set; }
        public List<IllnessDto.IllnessDto> AllIllness { get; set; } = new();
        public List<IllnessTypDto>? illnessTyps { get; set; } = new();
        public List<NCDAnnualLabTestDto> PersonAnnualLabTest { get; set; } = new();
        public List<LabTestDto.LabTestDto> AllNCDAnnualLabTest { get; set; } = new();
        public List<LabTestResultDto> PersonMonthlyLabTest { get; set; } = new();
        public List<TheMeasurementDto.TheMeasurementDto> PersonMesurements { get; set; } = new();
        public List<LateComplicationDto.PersonLateComplicationDto> PersonLateComplications { get; set; } = new();
        public List<LateComplicationDto.PersonLateComplicationDto> AllLateComplications { get; set; } = new();
    }
}
