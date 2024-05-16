using IUNRWA_ShareKernal.Enum.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.ReservationDto
{
    public class ReservationDto
    {
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }
        public int PersonId { get; set ; }
        public int ServiceId { get; set; }
        public int? DoctorId { get; set; }
        public ReservationStatus Status { get; set; }
        public ReservationType Type{ get; set; }

        public string ServiceName { get;set; }
        public string DoctorName { get; set; }
        public string ? PersonName { get; set ; }
        public string? NCDCard { set; get; }
        public string CenterName { set; get; }
    }
}
