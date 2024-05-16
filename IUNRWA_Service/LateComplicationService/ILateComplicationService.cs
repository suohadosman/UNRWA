using IUNRWA_DTOs.LateComplicationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.LateComplicationSevice
{
    public interface ILateComplicationService
    {
        public  Task<List<PersonLateComplicationDto>> GetAllPersonLateComplication(int personId);
        public Task AddFollowUpLateComplication(int followUpVisitId, int lateComplicationId, bool status);
        public Task<List<PersonLateComplicationDto>> GetAllLateComplications();

    }
}
