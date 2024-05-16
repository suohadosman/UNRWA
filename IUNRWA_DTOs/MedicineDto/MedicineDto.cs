using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.MedicineDto
{
    public class MedicineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public int Amount{ get; set; }
        public bool isTaken { set; get; }
        public DateTime LastDate { set; get; }
    }
}
