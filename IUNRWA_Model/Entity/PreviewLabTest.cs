using IUNRWA_ShareKernal.Enum.LabTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class PreviewLabTest :BaseEntity
    {
        public int PreviewId { get; set; }
        public Preview Preview { get; set; }

        public int LabTestId { get; set; }
        public LabTest LabTest { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfDone { get; set; }
        public bool IsDone { get; set; } = false;
        public bool? PNResult {  get; set; }
        public float? Result { get; set; }
    }
}
