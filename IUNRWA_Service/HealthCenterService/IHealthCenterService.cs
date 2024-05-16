using IUNRWA_DTOs.HealthCenterDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.HealthCenterService
{
    public interface IHealthCenterService
    {
        public Task<HealthCenterFormDto> AddHealthCenter(HealthCenterFormDto formDto);
        public Task<List<HealthCenterDto>> GetAll();
    }
}
