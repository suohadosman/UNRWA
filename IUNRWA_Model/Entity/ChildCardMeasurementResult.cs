using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class ChildCardMeasurementResult :BaseEntity
    {
        public float Result { get; set; }
        public DateTime DateOfMeasurement { get; set; }

        public ChildCard ChildCard { get; set; }

        public TheMeasurement Measurement { get; set; }
    }
}
