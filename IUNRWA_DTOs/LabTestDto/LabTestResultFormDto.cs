using IUNRWA_ShareKernal.Enum.LabTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.LabTestDto
{
    public class LabTestResultFormDto
    {
        public int PreviewLabTestId { get; set; }
        public float Result { get; set; }
        public bool PNResult { set; get;  }
        public int FollowUpLabTestId { get; set; }


    }
}
