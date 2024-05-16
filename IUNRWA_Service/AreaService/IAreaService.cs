using IUNRWA_DTOs.AreaDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.AreaService
{
    public interface IAreaService
    {
        public Task AddArea(List<string> areas);
        public Task<List<AreaDto>> GetAllArea();

    }
}
