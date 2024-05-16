using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class ImmunizationDate :BaseEntity
    {
        public DateTime Date { set; get; }

        public ChildCard ChildCard { set; get; }

        public ImmunizationProgramme ImmunizationProgramme { set; get; }
        public List<ImmunizationDateSideEffect> ImmunizationDateSideEffects { get; set; }

    }
}
