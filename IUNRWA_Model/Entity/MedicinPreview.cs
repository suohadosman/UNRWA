using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class MedicinPreview : BaseEntity 
    {
        public int Amount { get; set; }
        public bool IsTaken { get; set; }

        public int MedicineId { set; get; }
        public Medicine Medicine { get; set; }
        public int PreviewId { set; get; }

        public Preview Preview { get; set; }
        public int? NCDCardId { set; get; }

        public NCDCard? NCDCard { get; set; }
    }
}
