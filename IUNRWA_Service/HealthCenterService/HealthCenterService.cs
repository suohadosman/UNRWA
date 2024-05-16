using IUNRWA_DTOs.HealthCenterDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.HealthCenterService
{
    public class HealthCenterService : IHealthCenterService
    {
        private readonly IBaseRepository<HealthCenter> healthCenterRepo;
        private readonly IBaseRepository<Area> areaRepo;
        private readonly IBaseRepository<AreaPlace> areaPlaceRepo;

        public HealthCenterService(IBaseRepository<HealthCenter> healthCenterRepo, IBaseRepository<Area> areaRepo, IBaseRepository<AreaPlace> areaPlaceRepo)
        {
            this.healthCenterRepo = healthCenterRepo;
            this.areaRepo = areaRepo;
            this.areaPlaceRepo = areaPlaceRepo;
        }

        public async Task<HealthCenterFormDto> AddHealthCenter(HealthCenterFormDto formDto)
        {
            var area = await areaPlaceRepo.GetById(formDto.AreaPlaceId);
            var entity = await healthCenterRepo.Add(new HealthCenter
            {
                AreaPlace = area,
                Name = formDto.Name
            });
            formDto.Id = entity.Id;
            return formDto;
        }

        public async Task<List<HealthCenterDto>> GetAll()
        {
            var healthCenters = await healthCenterRepo.GetAll();
            var healthCenterDtos = healthCenters.Select(h => new HealthCenterDto
            {
                Id = h.Id,
                Name = h.Name,
                AreaPlaceId = h.AreaPlace.Id,
                AreaPlaceName = h.AreaPlace.Place
            }).ToList();
            return healthCenterDtos;
        }
    }
}
