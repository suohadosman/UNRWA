using IUNRWA_DTOs.AreaDto;
using IUNRWA_DTOs.NationalityDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.NationalityService
{
    public class NationalityService :INationalityService
    {
        private readonly IBaseRepository<Nationality> nationalityRepo;

        public NationalityService(IBaseRepository<Nationality> nationalityRepo)
        {
            this.nationalityRepo = nationalityRepo;
        }
        public async Task AddNationalities(List<string> nationalities)
        {
            await nationalityRepo.AddRange(nationalities.Select(e => new Nationality { Name = e }).ToList());
        }
        public async Task<List<NationalityDto>> GetAllNationality()
        {
            var areas = await nationalityRepo.GetAll();
            return areas.Select(e => new NationalityDto { Id = e.Id, Name = e.Name }).ToList();

        }
    }
}
