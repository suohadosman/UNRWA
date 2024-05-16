using IUNRWA_DTOs.AreaPlaceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.AreaPlaceService
{
    public interface IAreaPlaceService
    {
        public Task AddAreaPlace(AreaPlaceFormDto formDto);

        public Task<List<AreaPlaceDto>> GetAllAreaPlace(int? areaId);
    }
}
