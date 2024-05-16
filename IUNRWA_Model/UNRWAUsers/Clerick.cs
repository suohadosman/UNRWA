using IUNRWA_Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.UNRWAUsers
{
    [Table("Clericks")]
    public class Clerick :User
    {
        public person Person { get; set; }
        public int PersonId { get; set; }
        public Team Team { get; set; }
        public HealthCenter HealthCenter { get; set; }

    }
}
