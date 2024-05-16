using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.PreviewMedicineDto
{
    public class PreviewMedicineFormDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public bool IsTaken { get; set; }

        public int MedicineId { get; set; }

        public int PreviewId { get; set; }
        public int NCDId { get; set; }

    }
}
