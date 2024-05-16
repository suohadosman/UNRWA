using IUNRWA_DTOs.TeamDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.TeamService
{
    public class TeamService:ITeamService
    {
        private readonly IBaseRepository<Team> teamRepo;

        public TeamService(IBaseRepository<Team> teamRepo)
        {
            this.teamRepo = teamRepo;
        }
        public async Task AddTeams( List<string> names)
        {
            await teamRepo.AddRange(names.Select(e => new Team() { Name = e }).ToList());
        }
        public async Task<List<TeamDto>> GetAllTeams()
        {
            var teams = await teamRepo.GetAll();
            return teams.Select(e => new TeamDto { Name = e.Name }).ToList();
        }
    }
}
