using IUNRWA_DTOs.TheServiceDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.TheServiceService
{
    public class TheServiceService : ITheServiceService
    {
        private readonly AppDbContext context;

        public TheServiceService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<TheServiceDto>> GetAllServices()
        {
            return  await context.Services.Where(e => e.IsVaild)
                .Select(e => new TheServiceDto
                {
                    Id = e.Id,
                    Name = e.Name
                }).ToListAsync();
        }
        public async Task AddServices(List<string> services)
        {
            foreach (var service in services)
            {
                await context.Services.AddAsync(new Service { Name = service });
                await context.SaveChangesAsync();
            }
        }

    }
}
