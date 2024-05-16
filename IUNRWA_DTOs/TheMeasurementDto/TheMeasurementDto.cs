using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.TheMeasurementDto
{
    public class TheMeasurementDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Result { get; set; }
        public string Date { get; set; }
        public int PersonId { get; set; }
        public int MeasurementId { get; set; }
        public string Unit { get; set; }

    }
}
