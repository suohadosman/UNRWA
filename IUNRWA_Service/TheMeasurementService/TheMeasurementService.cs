using IUNRWA_DTOs.NewFolder;
using IUNRWA_DTOs.TheMeasurementDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository;
using IUNRWA_ShareKernal.Enum;
using IUNRWA_ShareKernal.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.TheMeasurementService
{
    public class TheMeasurementService:ITheMeasurementService
    {
        private readonly AppDbContext context;

        public TheMeasurementService(AppDbContext context)
        {
            this.context = context;
        }
        #region Action
        public async Task<TheMeasurementFormDto> AddMeasurement(TheMeasurementFormDto formDto)
        {
            try
            {
                var entity = new TheMeasurement { Name = formDto.Name! };
                await context.TheMeasurements.AddAsync(entity);
                await context.SaveChangesAsync();
                formDto.Id = entity.Id;
                return formDto;
            }
            catch { throw; }
        }
        public async Task<TheMeasurementFormDto> AddPersonMeasurement(TheMeasurementFormDto formDto)
        {
            try
            {
                var person = await context.People.Where(e => e.IsVaild && e.Id == formDto.PersonId).SingleOrDefaultAsync();
                if (person is null) throw new NotFoundException("person not Found");
                var me = await context.TheMeasurements.Where(e => e.IsVaild && e.Id == formDto.MeasurementId).SingleOrDefaultAsync();
                if (me is null) throw new NotFoundException("TheMeasurement not Found");
                var entity = new PersonMeasurementResult
                {
                    Person = person!,
                    Measurement = me!,
                    DateOfMeasurement = DateTime.Now,
                };
                await context.PersonMeasurementResults.AddAsync(entity);
                await context.SaveChangesAsync();
                formDto.Id = entity.Id;
                return formDto;
            }
            catch { throw; }
        }
        public async Task<TheMeasurementFormDto> AddPreviewMeasurement(TheMeasurementFormDto formDto)
        {
            try
            {
                var preview = await context.Previews.Where(e => e.IsVaild && e.Id == formDto.PreviewId).SingleOrDefaultAsync();
                if (preview is null) throw new NotFoundException(ErrorMessages.PreviewNotFound);
                var me = await context.TheMeasurements.Where(e => e.IsVaild && e.Id == formDto.MeasurementId).SingleOrDefaultAsync();
                if (me is null) throw new NotFoundException(ErrorMessages.MeasurementNotFound);
                var entity = new PersonMeasurementResult
                {
                    Preview = preview,
                    Measurement = me!,
                    DateOfMeasurement = DateTime.Now,
                };
                await context.PersonMeasurementResults.AddAsync(entity);
                await context.SaveChangesAsync();
                formDto.Id = entity.Id;
                return formDto;
            }
            catch { throw; }
        }
        public async Task AddMeasurementResult(int id , float result)
        {
            var entity = await context.PersonMeasurementResults.Where(e => e.IsVaild && e.Id == id).FirstOrDefaultAsync();
            entity.Result = result;
            context.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task RequestNCDMeasurement(int personId, int followUpVisitId)
        {
            try
            {
                var person = await context.People.Where(e => e.IsVaild && e.Id == personId).FirstOrDefaultAsync();
                if (person is null) throw new NotFoundException(ErrorMessages.PersonNotFound);
                var followUpVisit = await context.FollwUpVisits.Where(e => e.IsVaild && e.Id == followUpVisitId).FirstOrDefaultAsync();
                if (followUpVisit is null) throw new NotFoundException(ErrorMessages.FollowUpNotFound);
                List<int> mesIds = new List<int> { 1, 2 };
                List<PersonMeasurementResult> entities = new List<PersonMeasurementResult> ();

                foreach (var item in mesIds)
                {
                    var me = await context.TheMeasurements.Where(e => e.IsVaild && e.Id == item).FirstOrDefaultAsync();
                    if (me is null) throw new NotFoundException(ErrorMessages.MeasurementNotFound);
                    var entity = new PersonMeasurementResult
                    {
                        Person = person,
                        Measurement = me!,
                        DateOfMeasurement = DateTime.Now,
                        FollwUpVisit = followUpVisit
                    };
                    entities.Add(entity);
                  
                }
                await context.PersonMeasurementResults.AddRangeAsync(entities);
                await context.SaveChangesAsync();
            }
            catch { throw; }
        }
        #endregion

        #region Get
        public async Task<List<TheMeasurementDto>> GetAllMeasurements()
        {
            try
            {
                var result = await context.TheMeasurements.Where(e => e.IsVaild).Select(e => new TheMeasurementDto { Id = e.Id, Name = e.Name }).ToListAsync();
                return result != null ? result : new List<TheMeasurementDto>();
            }
            catch { throw; }
        }
        public async Task<List<TheMeasurementDto>> GetAllPersonMeasurements(int? personId =0, int? meId =0)
        {
            try
            {
                var result = await context.PersonMeasurementResults.Include(e=> e.Measurement).Include(e=> e.Preview).ThenInclude(e=>e.Patient)
                .Where(e => (e.IsVaild) && (e.Result != null)
                &&
                (
                   ((personId !=0 && meId != 0) ? (e.Preview.Patient.Id == personId && e.Measurement.Id == meId) 
                  : ( (personId != 0) ? (e.Preview.Patient.Id == personId) : (e.Measurement.Id == meId))
                   ))
                )  
                .Select(e => new TheMeasurementDto 
                {
                    Id = e.Id,
                    Name = e.Measurement.Name,
                    Result = e.Result,
                    PersonId = e.Preview.Patient.Id,
                    MeasurementId = e.Measurement.Id,
                    Date = e.DateOfMeasurement.ToShortDateString(),
                    Unit = e.Measurement.Unit
                }).ToListAsync();
                return result;
            }
            catch { throw; }
        }
        public async Task<List<TheMeasurementDto>> GetAllUnDonePersonMeasurements(int personId)
        {
            try
            {
                var result = await context.PersonMeasurementResults
                    .Include(e => e.Measurement)
                    .Include(e => e.Preview).ThenInclude(e=>e.Patient)
                    .Include(e=>e.FollwUpVisit).ThenInclude(e=>e.NCDCard)
                .Where(e => (e.IsVaild) && (e.Result == null)
                && ((e.FollwUpVisitId.HasValue) ? (e.FollwUpVisit.NCDCard.PersonId == personId) : (e.Preview!.Patient.Id == personId )))
                .Select(e => new TheMeasurementDto
                {
                    Id = e.Id,
                    Name = e.Measurement.Name,
                    Result = e.Result,
                    PersonId = personId,
                    MeasurementId = e.Measurement.Id,
                    Date = e.DateOfMeasurement.ToShortDateString(),
                    Unit = e.Measurement.Unit
                }).ToListAsync();
                return result;
            }
            catch { throw; }
        }
        public async Task<List<MeasurementQueueDto>> GetMeasurementQueue()
        {
            var result = await context.PersonMeasurementResults
                .Include(e=>e.Measurement)
                .Include(e=>e.Preview).ThenInclude(e=>e.Patient).Include(e=>e.FollwUpVisit).ThenInclude(e=>e.NCDCard).ThenInclude(e=>e.Person)
                .Where(e => e.IsVaild &&  e.Result == null 
                && e.DateOfMeasurement.Year == DateTime.Now.Year && e.DateOfMeasurement.Month == DateTime.Now.Month && e.DateOfMeasurement.Day == DateTime.Now.Day)
               .Select(e => new MeasurementQueueDto
               {
                   PersonId = e.Preview != null ? e.Preview.Patient.Id : e.FollwUpVisit.NCDCard.PersonId,
                   PersonName = e.Preview != null ? $"{e.Preview.Patient.FirstName} {e.Preview.Patient.LastName}" : $"{e.FollwUpVisit.NCDCard.Person.FirstName} {e.FollwUpVisit.NCDCard.Person.LastName}",
               }).GroupBy(e => e.PersonId).Select(e => new MeasurementQueueDto
               {
                   PersonId = e.Key,
                   PersonName = e.Where(d => d.PersonId == e.Key).Select(e => e.PersonName).FirstOrDefault()
               })
                .ToListAsync();
            return result;
        }
       
        #endregion

    }
}
