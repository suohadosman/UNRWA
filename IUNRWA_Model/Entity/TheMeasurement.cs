
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class TheMeasurement:BaseEntity
    {
        public string Name { get; set; }
        public List<ChildCardMeasurementResult> ChildCardMeasurementResults { get; set; }
        public List<PersonMeasurementResult> IndividualMeasurementResults { get; set; }
        public string Unit { set; get; }

    }
}
