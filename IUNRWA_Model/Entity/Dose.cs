using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class Dose :BaseEntity
    {
        public string DoseOrder { get; set; }
        public List<ImmunizationProgramme> ImmunizationProgrammes { set; get; }

    }
}
