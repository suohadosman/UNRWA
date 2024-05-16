using IUNRWA_Model.UNRWAUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class FollwUpVisit :BaseEntity
    {
        public DateTime DateOfVisit { get; set; }
        public bool TypeOfFollwUp { get; set; } // to remove it
        public NCDCard NCDCard { get; set; }
        public List<FollowUpLabTest> LabTests { set; get; } = new();
        public NCDNurse NCDNurse { get; set; }
        public List<PersonMeasurementResult> Measurements = new();
        public List<FollowUpLateComplication> LateComplications = new();

    }
}
