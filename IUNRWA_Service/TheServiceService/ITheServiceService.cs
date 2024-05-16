using IUNRWA_DTOs.TheServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.TheServiceService
{
    public interface ITheServiceService
    {
        public Task<List<TheServiceDto>>  GetAllServices();
        public Task AddServices(List<string> services);

    }
}
