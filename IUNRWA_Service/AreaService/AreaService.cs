using IUNRWA_DTOs.AreaDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.AreaService
{
    public class AreaService :IAreaService
    {
        private readonly IBaseRepository<Area> areaRepo;

        public AreaService(IBaseRepository<Area> areaRepo)
        {
            this.areaRepo = areaRepo;
        }
        public async Task AddArea(List<string> areas)
        {
            await areaRepo.AddRange(areas.Select(e => new Area { Name = e }).ToList());
        }
        public async Task<List<AreaDto>> GetAllArea()
        {
            var areas = await areaRepo.GetAll();
            return areas.Select(e => new AreaDto { Id = e.Id, Name = e.Name }).ToList();

       }
    }
}
