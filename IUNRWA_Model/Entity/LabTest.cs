using IUNRWA_ShareKernal.Enum.LabTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class LabTest :BaseEntity
    {
        public String Name { get; set; }
        public double? NormalResultValue { get; set; }
        public double? MaxNormalResult { set; get; }
        public double? MinNormalResult { set; get; }
        public bool? PNNormalResult { set; get; } // positive or negative
        public bool IsAvaliable { get; set; }
        public string? Unit { get; set; } = string.Empty;
        public LabTestResultType LabTestResultType { get; set; }
        public LabTestType LabTestType { get; set; }

        public List<PreviewLabTest> PreviewLabTests { get; set; } = new();
        public List<FollowUpLabTest> FollowUpLabTests { set; get; } = new();


    }
}
