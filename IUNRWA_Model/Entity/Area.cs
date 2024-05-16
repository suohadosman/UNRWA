using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class Area :BaseEntity
    {
        public string Name { get; set; }
        public List<AreaPlace> AreaPlaces { get; set; } = new();
    }
}
