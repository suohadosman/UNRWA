using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.NewFolder
{
    public class TheMeasurementFormDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Result { get; set; }

        public int? PersonId { get; set; }
        public int? PreviewId { get; set; }

        public int MeasurementId { get; set; }
    }
}
