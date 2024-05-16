using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.LabTestDto
{
    public class NCDAnnualLabTestDto
    {
        public int Year { get; set; }
        public List<LabTestResultDto> LabTestResults { set; get; } = new();
    }
}
