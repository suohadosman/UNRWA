using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class Medicine:BaseEntity
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public MedicineType MedicineType { get; set; }
        public List<MedicinPreview> MedicinPreviews { get; set; }

    }
}
