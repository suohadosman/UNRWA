using IUNRWA_DTOs.LateComplicationDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository;
using IUNRWA_Service.LateComplicationSevice;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.LateComplicationService
{
    public class LateComplicationService:ILateComplicationService
    {
        private readonly AppDbContext context;

        public LateComplicationService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<PersonLateComplicationDto>> GetAllLateComplications()
        {
            var result = await context.LateComplications
               .Where(e => e.IsVaild)
               .Select(e => new PersonLateComplicationDto
               {
                   LateComplicationId = e.Id,
                   LateComplicationName = e.Name,
               })
               .ToListAsync();
            return result;
        }
        public async Task<List<PersonLateComplicationDto>> GetAllPersonLateComplication(int personId)
        {
           
            var result = await context.FollowUpLateComplication
                .Include(e=>e.LateComplication)
                .Include(e=>e.FollwUpVisit).ThenInclude(e=>e.NCDCard)
                .Where(e => e.IsVaild && e.FollwUpVisit.NCDCard.PersonId == personId)
                .Select(e=> new PersonLateComplicationDto
                {
                    Id = e.Id,
                    LateComplicationId = e.LateComplicationId,
                    LateComplicationName = e.LateComplication.Name,
                    FollowUpVisitDate = e.FollwUpVisit.DateOfVisit.ToShortDateString(),
                    Status = e.Status
                })
                .ToListAsync();
            return result;
        }
        public async Task AddFollowUpLateComplication(int followUpVisitId, int lateComplicationId, bool status)
        {
            FollowUpLateComplication entity = new FollowUpLateComplication
            {
                LateComplicationId = lateComplicationId,
                FollwUpVisitId = followUpVisitId,
                Status =status
            };
            await context.FollowUpLateComplication.AddAsync(entity);
            await context.SaveChangesAsync();
        }

    }
}
