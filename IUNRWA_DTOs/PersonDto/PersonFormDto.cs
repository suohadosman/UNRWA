using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.PersonDto
{
    public class PersonFormDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ArabicName { get; set; } //exp: arabic name
        public string? PhoneNumber { get; set; }
        public Boolean MaritalStatus { get; set; }
        public Boolean Gender { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public int? StudyLevelId { get; set; }
        public int? NationalityId { get; set; }
        public int? RelationShipId { get; set; }
        public int? FatherId { get; set; }
        public int? FamilyCardId { get; set; }
        public int? OrginalPlaceId { get; set; }
        public int? CurrentAddressId { get; set; }
        public List<PersonFormDto>? Children { get; set; }
        
       
    }
}
