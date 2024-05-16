using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.MedicineDto
{
    public class MedicineFormDto
    {
        public int Id { get; set; }
        public int MedicineTypeId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
