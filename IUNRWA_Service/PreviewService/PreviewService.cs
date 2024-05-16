using IUNRWA_DTOs.PreviewDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository;
using IUNRWA_Repository.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.PreviewService
{
    public class PreviewService : IPreviewService
    {
        private readonly AppDbContext context;
        private readonly IUserRepository userRepository;
        public PreviewService(AppDbContext context, IUserRepository userRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
        }
        public async Task<PreviewFormDto> AddPreview(PreviewFormDto formDto)
        {
            try
            {
                var doctor = await userRepository.GetCurrentDoctor();
                var reservation = await context.Reservations.Where(e => e.Id == formDto.ReservationId && e.IsVaild).FirstOrDefaultAsync();
                var patient = await context.People.Where(e => e.IsVaild && e.Id == formDto.PatientId).SingleOrDefaultAsync();
                var entity = new Preview { Date = formDto.Date, Doctor = doctor, Patient= patient!, ReservationId = formDto.ReservationId  };
                await context.Previews.AddAsync(entity);
                reservation.IsDone = true;
                await context.SaveChangesAsync();
                formDto.Id = entity.Id;
                return formDto;
            }
            catch (Exception ex) { throw; }
        }
        public async Task<List<PreviewDto>> GetAllPreviews(int? personId =0, int? doctorId =0)
        {
            var result = await context.Previews.Include( e=> e.Doctor).ThenInclude(e=> e.Person).Include(e=> e.Patient)
                .Where(e => e.IsVaild 
                && ((personId == 0 && doctorId == 0) ? true 
                           : (personId != 0 && doctorId != 0) ? (e.Doctor.Id==doctorId && e.Patient.Id==personId)
                                      : ((doctorId != 0) ? e.Doctor.Id == doctorId : e.Patient.Id == personId)))
                .Select(e => new PreviewDto 
                { 
                    Id= e.Id,
                    PersonId = e.Patient.Id,
                    DoctorId = e.Doctor.Id,
                    Date = e.Date.ToShortDateString(), 
                    DoctorName= e.Doctor.Person.FirstName + " " + e.Doctor.Person.LastName,
                    PersonName = e.Patient.FirstName + " "+e.Patient.LastName,
                }).ToListAsync();
            return result;
        }
        public async Task<PreviewDto> GetPreviewById(int id)
        {
            var result = await context.Previews.Include(e => e.Doctor).ThenInclude(e => e.Person).Include(e => e.Patient)
                .Where(e => e.IsVaild && e.Id == id)
                .Select(e => new PreviewDto
                {
                    Id = e.Id,
                    PersonId = e.Patient.Id,
                    DoctorId = e.Doctor.Id,
                    Date = e.Date.ToShortDateString(),
                    DoctorName = e.Doctor.Person.FirstName + " " + e.Doctor.Person.LastName,
                    PersonName = e.Patient.FirstName + " " + e.Patient.LastName,
                }).SingleOrDefaultAsync();
            return result;
        }

    }
}
