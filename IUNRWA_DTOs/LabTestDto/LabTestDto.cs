using IUNRWA_ShareKernal.Enum.LabTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.LabTestDto
{
    public class LabTestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public double? NormalResultValue { get; set; }
        public bool IsAvaliable { get; set; }
        public string Unit { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
        public bool? PNNormalResult { set; get; } // positive or negative


    }
}
