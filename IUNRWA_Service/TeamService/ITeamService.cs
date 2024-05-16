using IUNRWA_DTOs.TeamDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.TeamService
{
    public interface ITeamService
    {
        public Task AddTeams(List<string> names);
        public Task<List<TeamDto>> GetAllTeams();


    }
}
