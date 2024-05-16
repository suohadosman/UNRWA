using IUNRWA_ShareKernal.Enum.LabTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.LabTestDto
{
    public class LabTestFormDto
    {
        public int Id { get; set ; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public double? NormalResultValue { get; set; }
        public double? MaxNormalResult { set; get; }
        public double? MinNormalResult { set; get; }
        public bool IsAvaliable { get; set; }
        public string Unit { get; set; }
        public int? PreviewId { get; set; }
        public DateTime? Date { get; set; }
        public int? PreviewLabTestId { get; set; }
        public bool? PNNormalResult {get; set; }
    }
}
