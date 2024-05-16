using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.MedicinePreviewDto
{
    public class MedicinePreviewDto
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public string MedicineType { get; set; }
        public bool IsTaken { get; set; }
        public string Date { get; set; }
    }
}
