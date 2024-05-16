using IUNRWA_ShareKernal.Enum.LabTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class FollowUpLabTest:BaseEntity
    {
        public int FollwUpVisitId { get; set; }
        public FollwUpVisit FollwUpVisit { get; set; }

        public int LabTestId { get; set; }
        public LabTest LabTest { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfDone { get; set; }
        public bool IsDone { get; set; } = false;
        public bool? PNResult { get; set; }
        public float? Result { get; set; }
        public FollowUpLabTestType FollowUpLabTestType { set; get; } 
    }
}
