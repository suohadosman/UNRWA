using IUNRWA_DTOs.AreaPlaceDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.AreaPlaceService
{
    public class AreaPlaceService: IAreaPlaceService
    {
        private readonly IBaseRepository<AreaPlace> areaPlaceRepo;
        private readonly IBaseRepository<Area> areaRepo;

        public AreaPlaceService(IBaseRepository<AreaPlace> areaPlaceRepo, IBaseRepository<Area> areaRepo)
        {
            this.areaPlaceRepo = areaPlaceRepo;
            this.areaRepo = areaRepo;
        }
        public async Task AddAreaPlace(AreaPlaceFormDto formDto)
        {
            var area = await areaRepo.GetById(formDto.AreaId);
            area.AreaPlaces.AddRange(formDto.Places.Select(e => new AreaPlace { Place = e }));
            await areaRepo.SaveChanges();
        }
        public async Task<List<AreaPlaceDto>> GetAllAreaPlace(int? areaId)
        {
            var places = await areaPlaceRepo.GetAll();
            return places.Select(e => new AreaPlaceDto { AreaId = e.Area.Id, Place = e.Place }).ToList();
        }

    }
}
