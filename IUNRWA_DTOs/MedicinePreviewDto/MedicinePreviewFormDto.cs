using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.MedicinePreviewDto
{
    public class MedicinePreviewFormDto
    {
        public int Id { get; set; }
        public int MedicinId { get; set; }
        public int PreviewId { get; set; }
        public int Amount { get; set ; }
    }
}
