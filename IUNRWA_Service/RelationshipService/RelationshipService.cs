using IUNRWA_DTOs.NationalityDto;
using IUNRWA_DTOs.RelationshipDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.RelationshipService
{
    public class RelationshipService: IRelationshipService
    {
        private readonly IBaseRepository<Relationship> relationshioRepo;

        public RelationshipService(IBaseRepository<Relationship> relationshioRepo)
        {
            this.relationshioRepo = relationshioRepo;
        }
        public async Task AddRelationship(List<string> relations)
        {
            await relationshioRepo.AddRange(relations.Select(e => new Relationship { Relatioship = e }).ToList());
        }
        public async Task<List<RelationshipDto>> GetAllRelationships()
        {
            var areas = await relationshioRepo.GetAll();
            return areas.Select(e => new RelationshipDto { Id = e.Id, Name = e.Relatioship }).ToList();

        }
    }
}
