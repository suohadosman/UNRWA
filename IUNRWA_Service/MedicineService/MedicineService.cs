using IUNRWA_DTOs.MedicineDto;
using IUNRWA_DTOs.MedicineTypeDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository;
using IUNRWA_ShareKernal.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.MedicineService
{
    public class MedicineService : IMedicineService
    {
        private readonly AppDbContext context;

        public MedicineService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<MedicineFormDto> AddMedicine(MedicineFormDto formDto)
        {
            var type =await context.MedicineTypes.Where(e => e.IsVaild).SingleOrDefaultAsync();
            if (type == null) throw new NotFoundException("medicine type dose not found");
            var entity = new Medicine { MedicineType = type, Name = formDto.Name, Amount= formDto.Amount };
            await context.Medicines.AddAsync(entity);
            await context.SaveChangesAsync();
            formDto.Id= entity.Id;
            return formDto;

        }

        public async Task<List<MedicineDto>> GetAllMedicine(int? typeId = 0)
        {
            var result = typeId == 0 ? await context.Medicines.Include(e => e.MedicineType).Where(e => e.IsVaild)
                .Select(e => new MedicineDto { Id = e.Id, TypeId = e.MedicineType.Id, Name = e.Name, Type = e.MedicineType.Type,Amount = e.Amount }).ToListAsync()
                : await context.Medicines.Include(e => e.MedicineType).Where(e => e.IsVaild && e.MedicineType.Id == typeId)
                .Select(e => new MedicineDto { Id = e.Id, TypeId = e.MedicineType.Id, Name = e.Name, Type = e.MedicineType.Type, Amount= e.Amount }).ToListAsync();
            return result;
        }

        public async Task AddMedicineType(string type)
        {
            var entity = new MedicineType { Type= type };
            await context.MedicineTypes.AddAsync(entity);
            await context.SaveChangesAsync();

        }
        public async Task<List<MedicineTypeDto>> GetAllMedicineType()
        {
            var result = await context.MedicineTypes.Where(e=>e.IsVaild).Select(e=> new MedicineTypeDto
            {
                Id= e.Id,
                Type = e.Type
            }).ToListAsync();
            return result;
        }
    }
}
