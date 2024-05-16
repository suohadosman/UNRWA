using IUNRWA_DTOs.FamilyCardDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.FamilyCardService
{
    public interface IFamilyCardService
    {
        public Task<FamilyCardFormDto> AddFamilyCard(FamilyCardFormDto formDto);
        public Task<List<FamilyCardDto>> GetAllFamilyCards();
        public Task<FamilyCardDto> GetFamilyCard(int id = 0, string familyCardNumber = null);
        public Task RemoveFamilyCard(int id);
    }
}
