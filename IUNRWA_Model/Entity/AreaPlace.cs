using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class AreaPlace :BaseEntity
    {
      
        public string Place { get; set; }
        public Area Area { get; set; }
        public List<HealthCenter> HealthCenters { get; set; } = new();

    }
}
