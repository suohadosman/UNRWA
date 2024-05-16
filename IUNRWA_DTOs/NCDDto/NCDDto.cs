using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.NCDDto
{
    public class NCDDto
    {
        public int Id { get; set; }
        public string NCDNumber { get; set; }
        public DateTime DateOfCreated { get; set; } = DateTime.Now;
        public int Diabetes { get; set; }
        public bool Pressure { get; set; }
        public string? Sensitive { get; set; }
        public int PersonId { get; set; }

    }
}
