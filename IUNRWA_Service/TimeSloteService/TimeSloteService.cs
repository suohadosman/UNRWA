using IUNRWA_DTOs.TimeSloteDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.TimeSloteService
{
    public class TimeSloteService : ITimeSloteServices
    {
        private readonly AppDbContext context;

        public TimeSloteService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<TimeSloteDto>> GetAllTimeSlote()
        {
            return await context.TimeSlotes.Where(e => e.IsVaild).Select(e => new TimeSloteDto
            {
                Id = e.Id,
                Slote = e.Time,
            }).ToListAsync();
        }
        public async Task<List<TimeSloteDto>> GetAvilableTimeSlote(AvailableTimeSloteFormDto formDto)
        {
            var doctorReservations = await context.Reservations
                 
                 .Where(e => (e.IsVaild) 
                 && ((e.DoctorId == formDto.DoctorId && e.DoctorId.HasValue) || (e.NCDNurseId == formDto.DoctorId && e.NCDNurseId.HasValue))
                 && (e.Date.Year == formDto.Date.Year)
                 && (e.Date.Month == formDto.Date.Month)
                 &&(e.Date.DayOfWeek == formDto.Date.DayOfWeek)
                 ).ToListAsync();

            var timeSlotes = await context.TimeSlotes.Where(e => e.IsVaild).ToListAsync();

            var result = new List<TimeSloteDto>();
            foreach (var slote in timeSlotes)
            {
                if (doctorReservations.Any(e => (e.Date.Hour == slote.Time.Hours) && (e.Date.Minute == slote.Time.Minutes))) continue;
                result.Add(new TimeSloteDto { Id = slote.Id, Slote = slote.Time });
            }
            return result;


      }
        public async Task<TimeSloteFormDto> AddTimeSlote(TimeSloteFormDto formDto)
        {

            var slote = new TimeSlote { Time = formDto.Slote };
            await context.TimeSlotes.AddAsync(slote);
            await context.SaveChangesAsync();
            formDto.Id = slote.Id;
            return formDto;
        }
    }
}
