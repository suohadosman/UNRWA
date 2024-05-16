using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_DTOs.PersonDto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ArabicName { get; set; } //exp: arabic name
        public string PhoneNumber { get; set; }
        public bool MaritalStatus { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public int StudyLevelId { get; set; }
        public string StudyLevel { get; set; }

        public int NationalityId { get; set; }
        public string Nationality { get; set; }
        public int RelationShipId { get; set; }
        public string RelationShip { get; set; }
        public int FatherId { get; set; }
        public string FatherName { get; set; }
        public int FamilyCardId { get; set; }
        public string FamilyCard { get; set; }
        public int OrginalPlaceId { get; set; }
        public string OriginalPlace { get; set; }
        public int CurrentAddressId { get; set; }
        public string CurrentAddress { get; set; }
        public int? CildCardId { get; set; }
        public string? CildCard { get; set; }

        public int? NCDId { get; set; }
        public string? NCD { get; set; }
        public List<PersonDto> Children { get; set; } = new();
        public int Age { get; set; }
    }
}
