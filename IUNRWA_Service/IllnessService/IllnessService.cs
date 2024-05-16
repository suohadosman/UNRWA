using IUNRWA_DTOs.IllnessDto;
using IUNRWA_DTOs.PreviewIllnessDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository;
using IUNRWA_ShareKernal.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.IllnessService
{
    public class IllnessService :IIllnessService
    {
        private readonly AppDbContext context;

        public IllnessService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IllnessFormDto> AddIllness(IllnessFormDto formDto)
        {
            var type = await context.IllnessTypes.Where(e => e.IsVaild && e.Id == formDto.TypeId).SingleOrDefaultAsync();
            if (type is null) throw new NotFoundException("type not found");
            var entity = new Illness
            {
                Name = formDto.Name,
                IllnessType = type
            };
            await context.Illnesses.AddAsync(entity);
            await context.SaveChangesAsync();
            formDto.Id = entity.Id;
            return formDto;
        }

        public async Task AddIllnessType(string Name)
        {
            await context.IllnessTypes.AddAsync(new IllnessType { Name = Name });
            await context.SaveChangesAsync();
                
        }
        public async Task<PreviewIllnessFormDto> AddPreviewIllness(PreviewIllnessFormDto formDto)
        {
            var illness = await context.Illnesses.Where(e => e.IsVaild && e.Id == formDto.IllnessId).SingleOrDefaultAsync();
            if (illness is null) throw new NotFoundException("illness not found");
            var preview = await context.Previews.Where(e => e.IsVaild && e.Id == formDto.PreviewId).SingleOrDefaultAsync();
            if (preview is null) throw new NotFoundException("preview not found");
            var entity = new PreviewIllness
            {
               Preview = preview,
               Illness= illness
            };
            await context.PreviewIllnesses.AddAsync(entity);
            await context.SaveChangesAsync();
            formDto.Id = entity.Id;
            return formDto;
        }

        public async Task<List<IllnessTypDto>> GetAllIllnessType()
        {
            return await context.IllnessTypes.Where(e => e.IsVaild)
                .Select(e=> new IllnessTypDto { Id= e.Id, Name= e.Name}).ToListAsync();
        }
        public async Task<List<IllnessDto>> GetAllIllness(int? typeId=0)
        {
            return await context.Illnesses.Include(e=>e.IllnessType).Where(e => e.IsVaild && (typeId == 0 ? true : e.IllnessType.Id == typeId))
                .Select(e => new IllnessDto { Id = e.Id, Name = e.Name, TypeId= e.IllnessType.Id, TypeName= e.IllnessType.Name }).ToListAsync();
        }
        public async Task<List<IllnessDto>> GetAllPatientIllness(int personId)
        {
            var result = await context.PreviewIllnesses
                   .Include(e => e.Preview).ThenInclude(e => e.Patient)
                   .Include(e => e.Illness).ThenInclude(e => e.IllnessType)
                   .Where(e => e.IsVaild && e.Preview.Patient.Id == personId)
                   .Select(e => new IllnessDto
                   {
                       Id = e.Id,
                       TypeId = e.Illness.IllnessType.Id,
                       TypeName = e.Illness.IllnessType.Name,
                       Name = e.Illness.Name,
                       Date = e.CreationDate.ToShortDateString()
                   }).ToListAsync();
            return result;
        }
        public async Task<List<IllnessDto>> GetAllPatientIllnessInType(int personId, int typeId)
        {
            if (typeId == 0) return await GetAllPatientIllness(personId);
            var result = await context.PreviewIllnesses
                   .Include(e => e.Preview).ThenInclude(e => e.Patient)
                   .Include(e => e.Illness).ThenInclude(e => e.IllnessType)
                   .Where(e => e.IsVaild && e.Preview.Patient.Id == personId && e.Illness.IllnessType.Id == typeId)
                   .Select(e => new IllnessDto
                   {
                       Id = e.Id,
                       TypeId = e.Illness.IllnessType.Id,
                       TypeName = e.Illness.IllnessType.Name,
                       Name = e.Illness.Name,
                       Date = e.CreationDate.ToShortDateString()
                   }).ToListAsync();
            return result;
        }
    }
}
