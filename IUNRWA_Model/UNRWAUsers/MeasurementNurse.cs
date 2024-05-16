using IUNRWA_Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.UNRWAUsers
{
    public class MeasurementNurse :User
    {
        public Team Team { get; set; }
        public person Person { get; set; }
        public int PersonId { get; set; }
        public HealthCenter HealthCenter { get; set; }
    }
}
