using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.DoctorDto
{
    public interface IDoctorService
    {
        public Task<List<DoctorDto>> GetAllDoctor(int? teamId =0);

    }
}
