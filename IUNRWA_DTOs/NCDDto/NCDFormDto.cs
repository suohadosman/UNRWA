using IUNRWA_DTOs.PreviewLabTestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.NCDDto
{
    public class NCDFormDto 
    {
        public int Id { get; set; }
        public int personId { get; set; }
        public string CardNumber { get; set; }
        public string? Sensitive { get; set; }
        public string CreationDate { set; get; }
        public string PersonName { set; get; }
    }
}
