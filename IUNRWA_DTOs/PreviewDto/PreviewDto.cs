using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.PreviewDto
{
    public class PreviewDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int DoctorId { get; set; }
        public string Date { get; set; }
        public string PersonName { get; set; }
        public string DoctorName { get; set; }

    }
}
