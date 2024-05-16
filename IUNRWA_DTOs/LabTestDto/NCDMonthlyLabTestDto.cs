using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.LabTestDto
{
    public class NCDMonthlyLabTestDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public List<LabTestResultDto> LabTestResults { set; get; } = new();
    }
}
