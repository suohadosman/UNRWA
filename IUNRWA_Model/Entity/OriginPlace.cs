using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class OriginPlace :BaseEntity
    {
        public string Place { get; set; }
        public List<person> People { get; set; }
    }
}
