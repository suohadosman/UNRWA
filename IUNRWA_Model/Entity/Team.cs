using IUNRWA_Model.UNRWAUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class Team :BaseEntity
    {
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Clerick> Clericks { get; set; }

    }
}
