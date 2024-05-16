using IUNRWA_DTOs.MedicineDto;
using IUNRWA_DTOs.MedicinePreviewDto;
using IUNRWA_DTOs.PreviewDto;
using IUNRWA_DTOs.PreviewMedicineDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.PreviewMedicineService
{
    public class PreviewMedicineService : IPreviewMedicineService
    {
        private readonly AppDbContext context;

        public PreviewMedicineService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<PreviewMedicineFormDto> AddPreviewMedicine(PreviewMedicineFormDto formDto)
        {
            try
            {
                var medicine = await context.Medicines.Where(e => e.IsVaild && e.Id == formDto.MedicineId).SingleOrDefaultAsync();
                var preview = await context.Previews.Where(e => e.IsVaild && e.Id == formDto.PreviewId).SingleOrDefaultAsync();
                var entity = new MedicinPreview
                {
                    Amount = formDto.Amount,
                    MedicineId = formDto.MedicineId,
                    PreviewId = formDto.PreviewId,
                    IsTaken = false
                };
                await context.MedicinPreviews.AddAsync(entity);
                await context.SaveChangesAsync();
                formDto.Id = entity.Id;
                return formDto;
            }
            catch (Exception){ throw; }

        }
        public async Task<PreviewMedicineFormDto> RequestNcdPreviewMedicine(PreviewMedicineFormDto formDto)
        {
            try
            {
                List<int> medicinesIds = new List<int> { 1, 2 };
                foreach (var item in medicinesIds)
                {
                    var medicine = await context.Medicines.Where(e => e.IsVaild && e.Id == item).SingleOrDefaultAsync();
                    var preview = await context.Previews.Where(e => e.IsVaild && e.Id == formDto.PreviewId).SingleOrDefaultAsync();
                    var entity = new MedicinPreview
                    {
                        Amount = 10,
                        MedicineId = item,
                        PreviewId = formDto.PreviewId,
                        IsTaken = false,
                        NCDCardId = formDto.NCDId
                    };
                    await context.MedicinPreviews.AddAsync(entity);
                }
                await context.SaveChangesAsync();
                return formDto;
            }
            catch (Exception) { throw; }
        }
        public async Task<List<PreviewMedicineDto>> GetAllTakenPreviewMedicine(int? personId = 0, int? typeId = 0) // is taken
        {
            var result = await context.MedicinPreviews
                .Include(e => e.Medicine).ThenInclude(e => e.MedicineType)
                .Include(e => e.Preview).ThenInclude(e=>e.Patient)
                .Where(e => (e.IsVaild) && (e.IsTaken)
                && ( (personId != 0 && typeId != 0) ? (e.Medicine.MedicineType.Id == typeId && e.Preview.Patient.Id == personId) : (personId == 0 ? true : e.Preview.Patient.Id == personId )))
                .OrderBy(e=>e.Preview.Patient.Id).ThenBy(e=>e.Preview.Date)
                .Select(e => new PreviewMedicineDto
                {
                    Id = e.Id,
                    Medicine = new MedicineDto { Id = e.Medicine.Id, Name = e.Medicine.Name, Type = e.Medicine.MedicineType.Type },
                    PreviewId = e.Preview.Id,
                    PreviewDate = e.Preview.Date.ToShortDateString(),
                    IsTaken = e.IsTaken,
                    Amount = e.Amount,
                    PersonName = e.Preview.Patient.FirstName + " " + e.Preview.Patient.LastName
                })
                .ToListAsync();
            return result;
        }
        public async Task<List<PreviewMedicineDto>> GetAllPreviewMedicine(int? personId = 0, int? typeId = 0) //  taken and unTaken, unNcd
        {
            var result = await context.MedicinPreviews
                .Include(e => e.Medicine).ThenInclude(e => e.MedicineType)
                .Include(e => e.Preview).ThenInclude(e => e.Patient)
                .Where(e => (e.IsVaild) && (e.NCDCardId == null)
                && ((personId != 0 && typeId != 0) ? (e.Medicine.MedicineType.Id == typeId && e.Preview.Patient.Id == personId) : (personId == 0 ? true : e.Preview.Patient.Id == personId)))
                .OrderBy(e => e.Preview.Patient.Id).ThenBy(e => e.Preview.Date)
                .Select(e => new PreviewMedicineDto
                {
                    Id = e.Id,
                    Medicine = new MedicineDto { Id = e.Medicine.Id, Name = e.Medicine.Name, Type = e.Medicine.MedicineType.Type },
                    PreviewId = e.Preview.Id,
                    PreviewDate = e.Preview.Date.ToShortDateString(),
                    IsTaken = e.IsTaken,
                    Amount = e.Amount,
                    PersonName = e.Preview.Patient.FirstName + " " + e.Preview.Patient.LastName,
                    NCdCardId = e.NCDCardId
                })
                .ToListAsync();
            return result;
        }
        public async Task<List<PreviewMedicineDto>> GetAllNCDPreviewMedicine(int? personId = 0, int? typeId = 0) //  taken and unTaken, Ncd
        {
            var result = await context.MedicinPreviews
                .Include(e => e.Medicine).ThenInclude(e => e.MedicineType)
                .Include(e => e.Preview).ThenInclude(e => e.Patient)
                .Where(e => (e.IsVaild) && (e.NCDCardId.HasValue)
                && ((personId != 0 && typeId != 0) ? (e.Medicine.MedicineType.Id == typeId && e.Preview.Patient.Id == personId) : (personId == 0 ? true : e.Preview.Patient.Id == personId)))
                .OrderBy(e => e.Preview.Patient.Id).ThenBy(e => e.Preview.Date)
                .Select(e => new PreviewMedicineDto
                {
                    Id = e.Id,
                    Medicine = new MedicineDto { Id = e.Medicine.Id, Name = e.Medicine.Name, Type = e.Medicine.MedicineType.Type },
                    PreviewId = e.Preview.Id,
                    PreviewDate = e.Preview.Date.ToShortDateString(),
                    IsTaken = e.IsTaken,
                    Amount = e.Amount,
                    PersonName = e.Preview.Patient.FirstName + " " + e.Preview.Patient.LastName,
                    NCdCardId = e.NCDCardId
                })
                .ToListAsync();
            return result;
        }
        public async Task UpdatePreviewMedicine(PreviewMedicineFormDto formDto)
        {
            var entity = await context.MedicinPreviews.Where(e => e.IsVaild && e.Id == formDto.Id).SingleOrDefaultAsync();
            entity!.IsTaken = formDto.IsTaken;
            context.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<List<PeronToTakePreviewMedicineDto>> GetAllPersonNamesToTakePreviewMedicine()
        {
            var entity = await context.MedicinPreviews
                .Include(e=>e.Preview).ThenInclude(e=>e.Patient)
                .Where(e => e.IsVaild && !e.IsTaken)
                .ToListAsync();
          var result = entity.GroupBy(e => e.Preview.Patient.Id).Select(e =>new PeronToTakePreviewMedicineDto {
          PersonId = e.Key,
          PersonName = e.Where(d=>d.Preview.Patient.Id == e.Key).Select(e=> e.Preview.Patient.FirstName).FirstOrDefault() }).ToList();

            return result;

        }
        public async Task<List<PreviewMedicineDto>> GetAllUnTakenPreviewMedicine()
        {
            var entity = await context.MedicinPreviews.IgnoreAutoIncludes()
               .Include(e => e.Preview).ThenInclude(e => e.Patient).Include(e=>e.Medicine).ThenInclude(e=>e.MedicineType)
               .Where(e => e.IsVaild && !e.IsTaken)
               .ToListAsync();
            var result = entity.Select(e => new PreviewMedicineDto
            {
                Id = e.Id,
                Medicine = new MedicineDto { Id = e.Medicine.Id, Name = e.Medicine.Name, Type = e.Medicine.MedicineType.Type },
                PreviewId = e.Preview.Id,
                PreviewDate = e.Preview.Date.ToShortDateString(),
                IsTaken = e.IsTaken,
                Amount = e.Amount,
                PersonId= e.Preview.Patient.Id,
            }).ToList();

            return result;
        }
        public async Task TakePreviewMedicine(int personId)
        {
            var entity = await context.MedicinPreviews.IgnoreAutoIncludes()
               .Include(e => e.Preview).ThenInclude(e => e.Patient).Include(e => e.Medicine).ThenInclude(e => e.MedicineType)
               .Where(e => e.IsVaild && !e.IsTaken && e.Preview.Patient.Id == personId)
               .ToListAsync();
            entity.ForEach(e=>e.IsTaken = true);
            await context.SaveChangesAsync();
        }
        public async Task UnTakePreviewMedicine(int previewMedicineId)
        {
            var entity = await context.MedicinPreviews.IgnoreAutoIncludes()
               .Include(e => e.Preview).ThenInclude(e => e.Patient).Include(e => e.Medicine).ThenInclude(e => e.MedicineType)
               .Where(e => e.IsVaild && e.Id == previewMedicineId)
               .FirstOrDefaultAsync();
            entity.IsTaken = false;
            await context.SaveChangesAsync();
        }
        public async Task<List<MedicineDto>> GetAllPatientMedicines(int personId)
        {
            var result = await context.MedicinPreviews
                .Include(e=>e.Medicine)
                .Include(e=>e.Preview).ThenInclude(e=>e.Patient)
                .Where(e => e.IsVaild && e.Preview.Patient.Id == personId).OrderByDescending(e => e.CreationDate)
                .GroupBy(e => e.MedicineId).Select(e => new MedicineDto
                {
                    Id = e.Key,
                    Name = e.Where(m => m.MedicineId == e.Key).OrderByDescending(e=>e.CreationDate).Select(e => e.Medicine.Name).FirstOrDefault(),
                    LastDate = e.Where(m => m.MedicineId == e.Key).OrderByDescending(e => e.CreationDate).Select(e => e.CreationDate).FirstOrDefault(),
                    isTaken = !e.Where(m => m.MedicineId == e.Key).OrderByDescending(e => e.CreationDate).Select(e => e.IsTaken).FirstOrDefault(),
                    Amount = e.Where(m => m.MedicineId == e.Key).OrderByDescending(e => e.CreationDate).Select(e => e.Amount).FirstOrDefault(),
                }).ToListAsync();
            return result;
        }

    }
}
