using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class PreviewComplaint :BaseEntity
    {
        public Preview Preview { get; set; }
        public Complaint Complaint { get; set; }
    }
}
