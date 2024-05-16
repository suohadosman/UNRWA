using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_ShareKernal.Enum.LabTest
{
    public class LabTestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public string ReferenceValue { get; set; }
        public bool IsAvaliable { get; set; }
        public LabeTestUnit Unit { get; set; }
    }
}
