using IUNRWA_DTOs.NCDDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.NCDService
{
    public interface INCDService
    {
        public Task<NCDFormDto> AddNCDCard(NCDFormDto formDto);
        public Task<NCDDto?> GetNCDCard(string number);
        public Task Remove(string number);

    }
}
