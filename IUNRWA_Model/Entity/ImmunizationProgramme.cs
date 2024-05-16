using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class ImmunizationProgramme :BaseEntity
    {
        public string AgeOfChild { get; set; }

        public Vaccine Vaccine { get; set; }
        public Dose Dose { get; set; }
        public List<ImmunizationDate> ImmunizationDates { get; set; }

    }
}
