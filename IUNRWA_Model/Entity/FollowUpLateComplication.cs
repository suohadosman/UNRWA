using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class FollowUpLateComplication :BaseEntity
    {
        public bool Status { get; set; }
        public int FollwUpVisitId { get; set; }
        public FollwUpVisit FollwUpVisit { get; set; }
        public int LateComplicationId { get; set; }

        public LateComplication LateComplication { get; set; }

    }
}
