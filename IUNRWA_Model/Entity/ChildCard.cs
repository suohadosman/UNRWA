using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class ChildCard :BaseEntity
    {
        public string CardNumber { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public person Person { get; set; }
        public int PersonId { get; set; }
        public List<ImmunizationDate> ImmunizationDates { get; set; }
        public List<ChildCardMeasurementResult> ChildCardMeasurementResults { get; set; }

    }
}
