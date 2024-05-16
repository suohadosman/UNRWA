using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class Relationship : BaseEntity
    {
        public string Relatioship { set; get; }
        public List<person> People {get; set;}
    }
}
