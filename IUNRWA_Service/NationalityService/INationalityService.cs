using IUNRWA_DTOs.NationalityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.NationalityService
{
    public interface INationalityService
    {
        public Task AddNationalities(List<string> nationalities);
        public Task<List<NationalityDto>> GetAllNationality();
    }
}
