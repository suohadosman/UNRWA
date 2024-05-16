using IUNRWA_Model.UNRWAUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Model.Entity
{
    [Table("People")]
    public class person :BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ArabicName { get; set; } //exp: arabic name
        public string PhoneNumber { get; set; }
        public bool MaritalStatus { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirthday { get; set; }

        public person? Father { get; set; }
        public List<person>? Children { get; set; } = new();

        public Doctor? Doctor { get; set; }
        public Clerick? Clerick { get; set; }
        public int? ClerickId { get; set; }
        public Relationship Relationship { get; set; }
        public int RelationshipId { get; set; }

        public Nationality Nationality { get; set; }
        public int NationalityId { get; set; }

        public AreaPlace OriginAdress { get; set; }
        public int OriginAdressId { get; set; }

        public AreaPlace CurrentAddress { get; set; }
        public int CurrentAddressId { get; set; }

        public FamilyRegestrationCard FamilyCard { get; set; }
        public int FamilyCardId { get; set; }

        public ChildCard? CildCard { get; set; }
        public int? CildCardId { get; set; }

        public NCDCard? NCDCard { get; set; }
        public StudyLevel StudyLevel { get; set; }
        public int StudyLevelId { get; set; }

        public List<Reservation> Reservations { get; set; } = new();
        public List<PersonMeasurementResult> IndividualMeasurementResults { get; set; } = new();
        public List<Preview> Previews { get; set; }

    }
}
