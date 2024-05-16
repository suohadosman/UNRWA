using IUNRWA_DTOs.TheMeasurementDto;
using IUNRWA_Model.UNRWAUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.Views
{
    public class MeasurementNurseViewDto
    {
        public List<MeasurementQueueDto> Queue { get; set; } = new();
        public List<TheMeasurementDto.TheMeasurementDto> UnDonePersonMeasurement { get; set; } = new();
        public int MeasurementResultID { get; set; }    
        public float Result { set; get; }
        public int PersonId { set; get; }
        public MeasurementNurse User { set; get; }
    }
}
