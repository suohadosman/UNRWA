using IUNRWA_DTOs.RelationshipDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.RelationshipService
{
    public interface IRelationshipService
    {
        public Task AddRelationship(List<string> relations);
        public Task<List<RelationshipDto>> GetAllRelationships();

    }
}
