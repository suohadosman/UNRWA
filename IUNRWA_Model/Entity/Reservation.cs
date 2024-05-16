using IUNRWA_Model.UNRWAUsers;
using IUNRWA_ShareKernal.Enum.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    public class Reservation:BaseEntity
    {
        public DateTime Date { set; get; }
        public ReservationType Type { get; set; }
        public Clerick? Clerick { set; get; }
        public int? DoctorId { set; get; }
        public Doctor? Doctor { set; get; }
        public Service Service { set; get; }
        public person Person { get; set; }
        public bool IsDone { set; get; }
        public List<Preview> Previews { set; get; } = new();
        public int? NCDNurseId { set; get; }
        public NCDNurse NCDNurse { set; get; }


    }
}
