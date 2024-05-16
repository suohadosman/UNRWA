using IUNRWA_DTOs.PersonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.PersonService
{
    public interface  IPersonService
    {
        public Task<PersonFormDto> AddPeson(PersonFormDto formDto);
        public Task UpdatePerson(PersonFormDto formDto);
        public Task<List<PersonDto>> GetAll(string familyCardNumber = null);
        public Task<PersonDto> GetById(int personId);
        public Task<PersonDto> GetByChildCard(string childCardNumber);
        public Task<PersonDto> GetByNCD(string ncdNumber);
        public Task RemovePerson(int personId);

    }
}
