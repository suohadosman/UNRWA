using IUNRWA_DTOs.ReservationDto;
using IUNRWA_Model.Entity;
using IUNRWA_Model.UNRWAUsers;
using IUNRWA_Repository;
using IUNRWA_ShareKernal.Enum.Reservation;
using IUNRWA_ShareKernal.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.ReservationService
{
    public class ReservationService: IReservationService
    {
        private readonly AppDbContext context;

        public ReservationService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddNormalReservation(ReservationFormDto formDto)
        {
            var time = await context.TimeSlotes.Where(time => time.IsVaild && time.Id == formDto.TimeSlotId).SingleOrDefaultAsync();
            if (time == null) throw new NotFoundException("TimeSlote dose not Found");

            var service = await context.Services.Where(s => s.IsVaild && s.Id == formDto.ServiceId).FirstOrDefaultAsync();
            if (service == null) throw new NotFoundException("service dose not Found");

            var doctor = await context.Doctors.Where(e =>  e.Id == formDto.DoctorId).FirstOrDefaultAsync();
            var ncdNurse = await context.NCDNurses.Where(e => e.Id == formDto.DoctorId).FirstOrDefaultAsync();

            var person = await context.People.Where(e =>e.IsVaild && e.Id == formDto.PersonId).FirstOrDefaultAsync();
            if (person == null) throw new NotFoundException("person dose not Found");

            TimeSpan s = new TimeSpan(time!.Time.Hours, time.Time.Minutes, time.Time.Seconds);
            formDto.Date= formDto.Date.Date + s;
            var entity = new Reservation
            {
                Date = formDto.Date,
                Service = service!,
                Doctor = doctor,
                NCDNurse= ncdNurse,
                Person = person!,
                Type = ReservationType.Nourmal,

            };
            await context.Reservations.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task UpdateNormalReservation(ReservationFormDto formDto)
        {
            var reservation = await context.Reservations.Where( e=> e.IsVaild && e.Id == formDto.Id).SingleOrDefaultAsync();
            if (reservation == null) throw new NotFoundException("reservation dose not Found");
            var time = await context.TimeSlotes.Where(time => time.IsVaild && time.Id == formDto.TimeSlotId).SingleOrDefaultAsync();
            if (time == null) throw new NotFoundException("TimeSlote dose not Found");

            var service = await context.Services.Where(s => s.IsVaild && s.Id == formDto.ServiceId).SingleOrDefaultAsync();
            if (service == null) throw new NotFoundException("service dose not Found");

            var doctor = await context.Doctors.Where(e => e.Id == formDto.DoctorId).SingleOrDefaultAsync();
            if (doctor == null) throw new NotFoundException("doctor dose not Found");

            var person = await context.People.Where(e => e.IsVaild && e.Id == formDto.PersonId).SingleOrDefaultAsync();
            if (person == null) throw new NotFoundException("person dose not Found");

            TimeSpan s = new TimeSpan(time!.Time.Hours, time.Time.Minutes, time.Time.Seconds);
            formDto.Date = formDto.Date.Date + s;
            reservation.Date = formDto.Date;
            reservation.Service = service!;
            reservation.Doctor = doctor!;
            reservation.Person = person!;
            context.Reservations.Update(reservation);
            await context.SaveChangesAsync();
        }
        public async Task AddQuickReservation(ReservationFormDto formDto)
        {
            var service = await context.Services.Where(s => s.IsVaild && s.Id == formDto.ServiceId).SingleOrDefaultAsync();
            if (service == null) throw new NotFoundException("service dose not Found");

            var doctor = await context.Doctors.Where(e => e.Id == formDto.DoctorId).SingleOrDefaultAsync();
            var ncdNurse = await context.NCDNurses.Where(e => e.Id == formDto.DoctorId).SingleOrDefaultAsync();

            var person = await context.People.Where(e => e.IsVaild && e.Id == formDto.PersonId).SingleOrDefaultAsync();
            if (person == null) throw new NotFoundException("person dose not Found");
            var entity = new Reservation
            {
                Date = DateTime.Now,
                Service = service!,
                Doctor =  doctor,
                NCDNurse = ncdNurse,
                Person = person!,
                Type = ReservationType.Quick
            };
            await context.Reservations.AddAsync(entity);
            await context.SaveChangesAsync();
        }


        public async Task<List<ReservationDto>> GetReservations(int? personId = 0 , int? doctorId = 0 )
        {
            var result = doctorId == 0 ? await context.Reservations
                .Include(e=> e.Person).Include(e=> e.Service).Include(e=> e.Doctor).ThenInclude(e=> e.Person)
                .Where(e => e.Person.Id == personId && e.IsVaild).Select(e=> new ReservationDto
                {
                    ReservationId = e.Id,
                    Date = e.Date ,
                    PersonId = e.Person.Id,
                    ServiceId = e.Service.Id,
                    DoctorId = e.DoctorId.HasValue ? (e.DoctorId) : (e.NCDNurseId.HasValue ? e.NCDNurseId : 0) ,
                    Status = e.IsDone ? ReservationStatus.Done : (e.Date < DateTime.Now ? ReservationStatus.Missing : ReservationStatus.Waitting),
                    ServiceName = e.Service.Name,
                    DoctorName = e.DoctorId.HasValue ? (e.Doctor.Person.FirstName + " "+ e.Doctor.Person.LastName) :(e.NCDNurseId.HasValue ? (e.NCDNurse.Person.FirstName + " " + e.NCDNurse.Person.LastName) : ("")),
                    Type = e.Type
                }).OrderByDescending(e => e.Date).ToListAsync() 
                :
                await context.Reservations
                .Include(e => e.Person).Include(e => e.Service).Include(e => e.Doctor).ThenInclude(e => e.Person)
                .Where(e => e.Doctor.Id == doctorId && e.IsVaild).Select(e => new ReservationDto
                {
                    ReservationId = e.Id,
                    Date = e.Date,
                    PersonId = e.Person.Id,
                    ServiceId = e.Service.Id,
                    DoctorId = e.Doctor.Id,
                    Status = e.Date < DateTime.Now ? ReservationStatus.Missing : ReservationStatus.Waitting,
                    ServiceName = e.Service.Name,
                    DoctorName = e.Doctor.Person.FirstName + e.Doctor.Person.LastName,
                    PersonName = e.Person.FirstName + " " + e.Person.LastName,
                    Type = e.Type
                }).OrderByDescending(e=> e.Date).ToListAsync();
            return result;
        }
        public async Task<List<ReservationDto>> GetAllNextDoctorReservations(int? personId = 0, int? doctorId = 0)
        {
            var result = doctorId == 0 ? await context.Reservations
                .Include(e => e.Person).Include(e => e.Service).Include(e => e.Doctor).ThenInclude(e => e.Person)
                .Where(e => e.Person.Id == personId && e.IsVaild && (e.Date >= DateTime.Now)).Select(e => new ReservationDto
                {
                    ReservationId = e.Id,
                    Date = e.Date,
                    PersonId = e.Person.Id,
                    ServiceId = e.Service.Id,
                    DoctorId = e.DoctorId.HasValue ? (e.DoctorId) : (e.NCDNurseId.HasValue ? e.NCDNurseId : 0),
                    Status = e.IsDone ? ReservationStatus.Done : (e.Date < DateTime.Now ? ReservationStatus.Missing : ReservationStatus.Waitting),
                    ServiceName = e.Service.Name,
                    DoctorName = e.DoctorId.HasValue ? (e.Doctor.Person.FirstName + " " + e.Doctor.Person.LastName) : (e.NCDNurseId.HasValue ? (e.NCDNurse.Person.FirstName + " " + e.NCDNurse.Person.LastName) : ("")),
                    Type = e.Type
                }).ToListAsync()
                :
                await context.Reservations
                .Include(e => e.Person).Include(e => e.Service).Include(e => e.Doctor).ThenInclude(e => e.Person)
                .Where(e => e.Doctor.Id == doctorId && e.IsVaild &&(e.Date >= DateTime.Now)).Select(e => new ReservationDto
                {
                    ReservationId = e.Id,
                    Date = e.Date,
                    PersonId = e.Person.Id,
                    ServiceId = e.Service.Id,
                    DoctorId = e.Doctor.Id,
                    Status = e.Date < DateTime.Now ? ReservationStatus.Missing : ReservationStatus.Waitting,
                    ServiceName = e.Service.Name,
                    DoctorName = e.Doctor.Person.FirstName + e.Doctor.Person.LastName,
                    PersonName = e.Person.FirstName + " " + e.Person.LastName,
                    Type = e.Type
                }).OrderByDescending(e => e.Date).ToListAsync();
            return result;
        }

        public async Task<List<ReservationDto>> GetAllPreview(int? personId = 0, int? doctorId = 0)
        {
            var result = doctorId == 0 ? await context.Reservations
                .Include(e => e.Person).Include(e => e.Service).Include(e => e.Doctor).ThenInclude(e => e.Person)
                .Where(e => e.Person.Id == personId && e.IsVaild && e.IsDone).Select(e => new ReservationDto
                {
                    ReservationId = e.Id,
                    Date = e.Date,
                    PersonId = e.Person.Id,
                    ServiceId = e.Service.Id,
                    DoctorId = e.DoctorId.HasValue ? (e.DoctorId) : (e.NCDNurseId.HasValue ? e.NCDNurseId : 0),
                    Status = e.Date < DateTime.Now ? ReservationStatus.Missing : ReservationStatus.Waitting,
                    ServiceName = e.Service.Name,
                    DoctorName = e.Doctor.Person.FirstName + " " + e.Doctor.Person.LastName,
                    Type = e.Type
                }).ToListAsync()
                :
                await context.Reservations
                .Include(e => e.Person).Include(e => e.Service).Include(e => e.Doctor).ThenInclude(e => e.Person)
                .Where(e => e.Doctor.Id == doctorId && e.IsVaild && e.Date < DateTime.Now).Select(e => new ReservationDto
                {
                    ReservationId = e.Id,
                    Date = e.Date,
                    PersonId = e.Person.Id,
                    ServiceId = e.Service.Id,
                    DoctorId = e.DoctorId.HasValue ? (e.DoctorId) : (e.NCDNurseId.HasValue ? e.NCDNurseId : 0),
                    Status = e.Date < DateTime.Now ? ReservationStatus.Missing : ReservationStatus.Waitting,
                    ServiceName = e.Service.Name,
                    DoctorName = e.Doctor.Person.FirstName + e.Doctor.Person.LastName,
                    PersonName = e.Person.FirstName + " " + e.Person.LastName,
                    Type = e.Type
                }).ToListAsync();
            return result;
        }

        public async Task<List<ReservationDto>> GetDoctorQueueReservations( int doctorId )
        {
            var result = await context.Reservations
                .Include(e => e.Person).Include(e => e.Service).Include(e => e.Doctor).ThenInclude(e => e.Person).ThenInclude(e=>e.NCDCard)
                .Where(e =>
               (e.DoctorId.HasValue ? (e.DoctorId == doctorId) : (e.NCDNurseId.HasValue ? e.NCDNurseId== doctorId : false))
                && e.IsVaild && !e.IsDone 
                &&
                ((e.Type == ReservationType.Quick && (e.Date.Year == DateTime.Now.Year) && (e.Date.Month == DateTime.Now.Month) && (e.Date.Day == DateTime.Now.Day)) ? true 
                : (e.Date.Year == DateTime.Now.Year) && (e.Date.Month == DateTime.Now.Month) && (e.Date.Day == DateTime.Now.Day)
                && ((e.Date.Hour > DateTime.Now.Hour) ? true : (e.Date.Hour == DateTime.Now.Hour && e.Date.Minute >= DateTime.Now.Minute)))
               
                )
                .Select(e => new ReservationDto
                {
                    ReservationId = e.Id,
                    Date = e.Date,
                    PersonId = e.Person.Id,
                    ServiceId = e.Service.Id,
                    DoctorId = e.DoctorId.HasValue ? (e.DoctorId) : (e.NCDNurseId.HasValue ? e.NCDNurseId : 0),
                    Status = e.Date < DateTime.Now ? ReservationStatus.Missing : ReservationStatus.Waitting,
                    ServiceName = e.Service.Name,
                    DoctorName = e.Doctor.Person.FirstName + " " + e.Doctor.Person.LastName,
                    PersonName = e.Person.FirstName + " " + e.Person.LastName,
                    Type = e.Type,
                    NCDCard = e.Person.NCDCard.CardNumber
                }).ToListAsync();
            return result;
        }
        public async Task RemoveReservation(int id)
        {
            try
            {
                var entity = await context.Reservations.Where(e => e.IsVaild && e.Id == id).SingleOrDefaultAsync();
                if (entity == null) throw new NotFoundException("reservation dose not found");
                context.Reservations.Remove(entity);
                await context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw;
            }
        }
        public async Task MakeReservationDone(int id)
        {
            try
            {
                var entity = await context.Reservations.Where(e => e.IsVaild && e.Id == id).SingleOrDefaultAsync();
                if (entity == null) throw new NotFoundException("reservation dose not found");
                entity.IsDone = true;
                context.Reservations.Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<List<ReservationDto>> GetAllNextPersonReservations(int personId)
        {
            var result = await context.Reservations
                .Include(e => e.Person).Include(e=>e.Service)
                .Include(e=>e.Doctor).ThenInclude(e=>e.Person)
                .Include(e => e.Doctor).ThenInclude(e => e.HealthCenter)
                .Include(e=>e.NCDNurse).ThenInclude(e=>e.Person)
                .Include(e => e.NCDNurse).ThenInclude(e => e.HealthCenter)
                .Where(e => (e.IsVaild) && (e.Person.Id == personId) && e.Date >= DateTime.Now && (e.IsDone == false))
                .Select(e => new ReservationDto
                {
                    ReservationId = e.Id,
                    Date = e.Date,
                    PersonId = e.Person.Id,
                    ServiceId = e.Service.Id,
                    DoctorId = e.DoctorId.HasValue ? (e.DoctorId) : (e.NCDNurseId.HasValue ? e.NCDNurseId : 0),
                    ServiceName = e.Service.Name,
                    DoctorName = e.DoctorId.HasValue ? (e.Doctor.Person.FirstName + " " + e.Doctor.Person.LastName) : (e.NCDNurseId.HasValue ? (e.NCDNurse.Person.FirstName + " " + e.NCDNurse.Person.LastName) : ("")),
                    Type = e.Type,
                    CenterName = e.DoctorId.HasValue ? e.Doctor.HealthCenter.Name : e.NCDNurse.HealthCenter.Name
                })
                .ToListAsync();
            return result;
        }
       
    }
}
