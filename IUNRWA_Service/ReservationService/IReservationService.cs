using IUNRWA_DTOs.ReservationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.ReservationService
{
    public interface IReservationService
    {
        public Task AddNormalReservation(ReservationFormDto formDto);
        public Task UpdateNormalReservation(ReservationFormDto formDto);

        public Task AddQuickReservation(ReservationFormDto formDto);
        public Task<List<ReservationDto>> GetReservations(int? personId = 0, int? doctorId = 0);
        public Task<List<ReservationDto>> GetAllPreview(int? personId = 0, int? doctorId = 0);

        public Task<List<ReservationDto>> GetDoctorQueueReservations(int doctorId);
        public Task RemoveReservation(int id);
        public Task MakeReservationDone(int id);
        public Task<List<ReservationDto>> GetAllNextPersonReservations(int personId);
        public Task<List<ReservationDto>> GetAllNextDoctorReservations(int? personId = 0, int? doctorId = 0);

    }
}
