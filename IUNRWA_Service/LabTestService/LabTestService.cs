using IUNRWA_DTOs.LabTestDto;
using IUNRWA_Model.Entity;
using IUNRWA_Model.UNRWAUsers;
using IUNRWA_Repository;
using IUNRWA_ShareKernal.Enum.LabTest;
using IUNRWA_ShareKernal.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.LabTestService
{
    public class LabTestService : ILabTestService
    {
        private readonly AppDbContext context;

        public LabTestService( AppDbContext context)
        {
            this.context = context;
        }

        public async Task<LabTestFormDto> AddLabTest(LabTestFormDto formDto)
        {
            var type = await context.labTestTypes.Where(e => e.IsVaild && e.Id == formDto.TypeId).SingleOrDefaultAsync();
            if (type == null) throw new NotFoundException("labeTest type dose not found");
            var entity = new LabTest
            {
                Name = formDto.Name,
                IsAvaliable = formDto.IsAvaliable,
                Unit = formDto.Unit,
                LabTestType = type,
                 NormalResultValue = formDto.NormalResultValue,
                 MinNormalResult = formDto.MinNormalResult,
                 MaxNormalResult =formDto.MaxNormalResult,
                 PNNormalResult = formDto.NormalResultValue.HasValue ? null :formDto.PNNormalResult
            };
            if(string.IsNullOrEmpty(formDto.Unit))
            {
                entity.LabTestResultType = LabTestResultType.TR;
            }
            else
            {
                entity.LabTestResultType = LabTestResultType.Value;
            }
            await context.LabTests.AddAsync(entity);
            await context.SaveChangesAsync();
            formDto.Id = entity.Id;
            return formDto; 
        }
        public async Task<LabTestFormDto> UpdateLabTest(LabTestFormDto formDto)
        {
            var type = await context.labTestTypes.Where(e => e.IsVaild && e.Id == formDto.TypeId).SingleOrDefaultAsync();
            if (type == null) throw new NotFoundException("labeTest type dose not found");

            var labtest = await context.LabTests.Where(e => e.IsVaild && e.Id == formDto.Id).SingleOrDefaultAsync();

            if (labtest == null) throw new NotFoundException("labeTest dose not found");

            labtest.Name = formDto.Name;
            labtest.IsAvaliable = formDto.IsAvaliable;
            labtest.Unit = formDto.Unit;
            labtest.LabTestType = type;
            labtest.NormalResultValue = formDto.NormalResultValue;
            labtest.MinNormalResult = formDto.MinNormalResult;
            labtest.MaxNormalResult = formDto.MaxNormalResult;
           
            context.LabTests.Update(labtest);
            await context.SaveChangesAsync();
            return formDto;
        }

        public async Task AddLabTestType(string type)
        {
            await context.labTestTypes.AddAsync(new LabTestType { Name = type }) ;
            await context.SaveChangesAsync();
        }

        public async Task<LabTestFormDto> AddPreviewLabTest(LabTestFormDto formDto)
        {
            var preview = await context.Previews.Where(e => e.IsVaild && e.Id == formDto.PreviewId).SingleOrDefaultAsync();
            if (preview is null) throw new NotFoundException("preview type dose not found");
            var labtest = await context.LabTests.Where(e => e.IsVaild && e.Id == formDto.Id).SingleOrDefaultAsync();
            if (labtest == null) throw new NotFoundException("labeTest dose not found");
            var entity = new PreviewLabTest
            {
              Preview = preview,
              LabTest = labtest,
              Date = formDto.Date ?? DateTime.Now,
            };
            await context.PreviewLabTests.AddAsync(entity);
            await context.SaveChangesAsync();
            formDto.PreviewLabTestId = entity.Id;
            return formDto;
        }

        #region Get
        public async Task<List<IUNRWA_DTOs.LabTestDto.LabTestDto>> GetAllLabTest(int? typeId = 0)
        {
            var result = (typeId == 0 || typeId == null )? await context.LabTests.Include(e => e.LabTestType).Where(e => e.IsVaild)
                .Select(e => new IUNRWA_DTOs.LabTestDto.LabTestDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Type = e.LabTestType.Name,
                    TypeId = e.LabTestType.Id,
                    NormalResultValue = e.NormalResultValue,
                    Unit = e.Unit,
                    IsAvaliable = e.IsAvaliable,
                    MinValue= e.MinNormalResult,
                    MaxValue = e.MaxNormalResult,
                    PNNormalResult= e.PNNormalResult
                }).ToListAsync()
                : await context.LabTests.Include(e => e.LabTestType).Where(e => e.IsVaild && e.LabTestType.Id == typeId)
                .Select(e => new IUNRWA_DTOs.LabTestDto.LabTestDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Type = e.LabTestType.Name,
                    TypeId = e.LabTestType.Id,
                    NormalResultValue = e.NormalResultValue,
                    Unit = e.Unit,
                    IsAvaliable = e.IsAvaliable,
                    MinValue = e.MinNormalResult,
                    MaxValue = e.MaxNormalResult,
                    PNNormalResult = e.PNNormalResult

                }).ToListAsync();
            return result;
        }

        public async Task<List<LabTestTypeDto>> GetAllLabTestTypes()
        {
            var result = await context.labTestTypes.Where(e => e.IsVaild).Select(e => new LabTestTypeDto { Id = e.Id, Type = e.Name }).ToListAsync();
            return result;
        }
       
        public async Task<List<IUNRWA_DTOs.LabTestDto.LabTestDto>> GetNCDAnnualOrMonthlyLabTest()
        {
            List<int> labTestIds = new List<int> { 20, 21, 22, 23, 24, 25, 26, 27 };
            var result = await context.LabTests.Include(e=>e.LabTestType).Where(e=> labTestIds.Contains(e.Id)).Select(e => new IUNRWA_DTOs.LabTestDto.LabTestDto
            {
                Id = e.Id,
                Name = e.Name,
                Type = e.LabTestType.Name,
                TypeId = e.LabTestType.Id,
                NormalResultValue = e.NormalResultValue,
                Unit = e.Unit,
                IsAvaliable = true,
                MinValue = e.MinNormalResult,
                MaxValue = e.MaxNormalResult,
                PNNormalResult = e.PNNormalResult

            }).ToListAsync(); 
            return result;
        }
       
        #endregion
        public async Task MakeLabTestAvailable(int labTestId)
        {
            var entity = await context.LabTests.Where(e=>e.IsVaild && e.Id ==  labTestId).FirstOrDefaultAsync();
            entity!.IsAvaliable = true;
            context.LabTests.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task MakeLabTestUnAvailable(int labTestId)
        {
            var entity = await context.LabTests.Where(e => e.IsVaild && e.Id == labTestId).FirstOrDefaultAsync();
            entity!.IsAvaliable = false;
            context.LabTests.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task RemoveLabTest(int labTestId)
        {
            var entity = await context.LabTests.Where(e => e.IsVaild && e.Id == labTestId).FirstOrDefaultAsync();
            context.LabTests.Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task RemoveAllLabTestTypes()
        {
            var entity = await context.labTestTypes.Where(e => e.IsVaild).ToListAsync();
            context.labTestTypes.RemoveRange(entity);
            await context.SaveChangesAsync();
        }
        public async Task RemoveAllLabTests()
        {
            var entity = await context.LabTests.Where(e => e.IsVaild).ToListAsync();
            context.LabTests.RemoveRange(entity);
            await context.SaveChangesAsync();
        }

    }
}
