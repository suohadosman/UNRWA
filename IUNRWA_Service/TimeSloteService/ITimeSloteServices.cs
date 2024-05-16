using IUNRWA_DTOs.TimeSloteDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.TimeSloteService
{
    public interface ITimeSloteServices
    {
        public Task<List<TimeSloteDto>> GetAllTimeSlote();
        public Task<List<TimeSloteDto>> GetAvilableTimeSlote(AvailableTimeSloteFormDto formDto);
        public Task<TimeSloteFormDto> AddTimeSlote(TimeSloteFormDto formDto);


    }
}
