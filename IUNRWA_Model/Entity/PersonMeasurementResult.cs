using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class PersonMeasurementResult:BaseEntity
    {
        public float? Result { get; set; }

        public person? Person { get; set; }

        public TheMeasurement Measurement { get; set; }
        public DateTime DateOfMeasurement { get; set; }
        public Preview? Preview { get; set; }
        public int? FollwUpVisitId { get; set; }
        public FollwUpVisit FollwUpVisit { get; set; }

    }
}
