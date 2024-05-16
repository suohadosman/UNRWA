using IUNRWA_ShareKernal.Enum.Reservation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.ReservationDto
{
    public class ReservationFormDto
    {
        public int? Id { get; set; }
        public int PersonId { get; set; }
        public int DoctorId { get; set; }
        [Display(Name = "Service")]
        public int ServiceId { get; set; }
        [Display(Name = "Time")]

        public int TimeSlotId { get; set; }
        public DateTime Date { set; get; }

    }
}
