using IUNRWA_DTOs.LabTestDto;
using IUNRWA_DTOs.NCDDto;
using IUNRWA_Model.UNRWAUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.Views
{
    public class NCDNurseViewDto
    {
        public List<ReservationDto.ReservationDto>? Reservations { get; set; } = new();
        public NCDFormDto CreatedNCDCardInfo { get; set; }
        public int PersonId { set; get; }
        public int FollowUpVisitId { set; get; }

        public List<NCDAnnualLabTestDto> PersonAnnualLabTest { get; set; } = new();
        public List<LabTestResultDto> PersonMonthlyLabTest { get; set; } = new();

        public List<LabTestDto.LabTestDto> AllNCDAnnualLabTest { get; set; } = new();
        public List<TheMeasurementDto.TheMeasurementDto> PersonMesurements { get; set; } = new();
        public List<LateComplicationDto.PersonLateComplicationDto> PersonLateComplications  { get; set; } = new();
        public List<LateComplicationDto.PersonLateComplicationDto> AllLateComplications { get; set; } = new();

        public bool LateComplicationStatus { get; set; }
        public int LateComplicationId{ get; set; }
        public NCDNurse User { get; set; }
    }
}
