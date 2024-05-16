using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.PreviewMedicineDto
{
    public class PreviewMedicineDto
    {
        public int Id { get; set; }
        public MedicineDto.MedicineDto Medicine { get; set; }
        public int PreviewId { get; set; }
        public string PreviewDate { get; set; }
        public bool IsTaken { get; set; }
        public int Amount { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int? NCdCardId { set; get; }
    }
}
