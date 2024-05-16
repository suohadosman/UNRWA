using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.PreviewDto
{
    public class PreviewFormDto
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public int PatientId { get; set; }
        public int Id { get; set; }
        public int ReservationId { set; get; }
    }
}
