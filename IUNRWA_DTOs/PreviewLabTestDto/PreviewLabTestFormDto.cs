using IUNRWA_ShareKernal.Enum.LabTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.PreviewLabTestDto
{
    public class PreviewLabTestFormDto
    {
        public int Id { get; set; }
        public int FollowUpId { set; get; }
        public int PreviewId { get; set; }
        public int LabTestId { get; set; }
        public DateTime Date { get; set; }
        public FollowUpLabTestType FollowUpLabTestType { get; set; }
    }
}
