using IUNRWA_DTOs.PersonDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository;
using IUNRWA_Repository.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly IBaseRepository<person> pesonRepo;
        private readonly IBaseRepository<Nationality> nationalityRepo;
        private readonly IBaseRepository<Relationship> relationshipRepo;
        private readonly IBaseRepository<AreaPlace> areaPlaceRepo;
        private readonly IBaseRepository<StudyLevel> studyLevelRepo;
        private readonly IBaseRepository<FamilyRegestrationCard> familyCardRepo;
        private readonly AppDbContext Context;
        public PersonService(IBaseRepository<person> pesonRepo, IBaseRepository<Nationality> nationalityRepo, IBaseRepository<StudyLevel> studyLevelRepo, IBaseRepository<FamilyRegestrationCard> familyCardRepo, IBaseRepository<Relationship> relationshipRepo, IBaseRepository<AreaPlace> areaPlaceRepo, AppDbContext context)
        {
            this.pesonRepo = pesonRepo;
            this.nationalityRepo = nationalityRepo;
            this.studyLevelRepo = studyLevelRepo;
            this.familyCardRepo = familyCardRepo;
            this.relationshipRepo = relationshipRepo;
            this.areaPlaceRepo = areaPlaceRepo;
            Context = context;
        }

        public async Task<PersonFormDto> AddPeson(PersonFormDto formDto)
        {
            var nationality = await nationalityRepo.GetById(formDto.NationalityId ?? 0);
            var relationship = await relationshipRepo.GetById(formDto.RelationShipId ?? 0);
            var originalPlace = await areaPlaceRepo.GetById(formDto.OrginalPlaceId ?? 0) ;
            var currenAddress = await areaPlaceRepo.GetById(formDto.CurrentAddressId ?? 0);
            var studyLevel = await studyLevelRepo.GetById(formDto.StudyLevelId ?? 0);
            var familyCard = await familyCardRepo.GetById(formDto.FamilyCardId ?? 0);

            var person = new person
            {

                FirstName = formDto.FirstName,
                LastName = formDto.LastName,
                Father = formDto.FatherId is null ? null : await pesonRepo.GetById(formDto.FatherId ?? 0),
                ArabicName = formDto.ArabicName is null ? "" : formDto.ArabicName,
                PhoneNumber = formDto.PhoneNumber is null ? "" : formDto.PhoneNumber,
                MaritalStatus = formDto.MaritalStatus,
                Gender = formDto.Gender,
                DateOfBirthday = formDto.DateOfBirthday,
                Nationality = nationality,
                Relationship = relationship,
                OriginAdress = originalPlace,
                CildCard = null,
                StudyLevel = studyLevel,
                CurrentAddress = currenAddress,
                FamilyCard = familyCard,
                Children = formDto.Children == null ? null : formDto.Children!.Select(e => new person
                {
                    FirstName = formDto.FirstName,
                    LastName = formDto.LastName,
                    ArabicName = formDto.ArabicName is null ? "" : formDto.ArabicName,
                    PhoneNumber = formDto.PhoneNumber is null ? "" : formDto.PhoneNumber,
                    MaritalStatus = formDto.MaritalStatus,
                    Gender = formDto.Gender,
                    DateOfBirthday = formDto.DateOfBirthday,
                    Nationality = nationality,
                    Relationship = relationship,
                    OriginAdress = originalPlace,
                    CurrentAddress = currenAddress,
                    FamilyCard = familyCard,
                    CildCard = null,
                    Children = formDto.Children!.Select(e => new person
                    {
                    }).ToList()
                }).ToList()
            };
            var entity = await pesonRepo.Add(person);
            formDto.Id = entity.Id;
            return formDto;
        }

        public async Task<List<PersonDto>> GetAll(string familyCardNumber = null)
        {
            var persons = await pesonRepo.GetAll(e => familyCardNumber == null  ? true : e.FamilyCard.CardNumber.Equals(familyCardNumber));
            var personDtos = persons.Select(e => new PersonDto
            {
                Id= e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                FatherName = e.Father==null ? "" : e.Father.FirstName,

                ArabicName = e.ArabicName,
                Gender = e.Gender,
                MaritalStatus = e.MaritalStatus,
                DateOfBirthday = e.DateOfBirthday,
                StudyLevelId = e.StudyLevel.Id,
                StudyLevel = e.StudyLevel.Level,
                NationalityId = e.Nationality.Id,
                Nationality = e.Nationality.Name,
                RelationShipId = e.Relationship.Id,
                RelationShip = e.Relationship.Relatioship,
                OrginalPlaceId = e.OriginAdress.Id,
                OriginalPlace = e.OriginAdress.Place,
                CurrentAddressId = e.CurrentAddress.Id,
                CurrentAddress = e.CurrentAddress.Place,
                FamilyCardId = e.FamilyCard == null ? 0: e.FamilyCard.Id,
                FamilyCard =e.FamilyCard==null ? "": e.FamilyCard.CardNumber,
                NCDId = e.NCDCard == null ? 0 : e.NCDCard.Id,
                NCD = e.NCDCard == null ? "": e.NCDCard.CardNumber,
                CildCard =e.CildCard == null ? "": e.CildCard.CardNumber,
                Children = e.Children!.Select(e => new PersonDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Gender = e.Gender,
                    MaritalStatus = e.MaritalStatus,
                    DateOfBirthday = e.DateOfBirthday,
                    StudyLevelId = e.StudyLevel.Id,
                    StudyLevel = e.StudyLevel.Level,
                    NationalityId = e.Nationality.Id,
                    Nationality = e.Nationality.Name,
                    RelationShipId = e.Relationship.Id,
                    RelationShip = e.Relationship.Relatioship,
                    OrginalPlaceId = e.OriginAdress.Id,
                    OriginalPlace = e.OriginAdress.Place,
                    CurrentAddressId = e.CurrentAddress.Id,
                    CurrentAddress = e.CurrentAddress.Place,
                    FamilyCardId = e.FamilyCard.Id,
                    FamilyCard = e.FamilyCard.CardNumber,
                    NCDId = e.NCDCard ==null ? null: e.NCDCard.Id,
                    NCD = e.NCDCard == null ? null :  e.NCDCard.CardNumber,
                    CildCard = e.CildCard == null ? "" : e.CildCard.CardNumber,
                }).ToList()
            }).ToList();
            return personDtos;
        }

        public async Task<PersonDto?> GetById(int personId)
        {
            var e = await Context.People.Where(e=> e.IsVaild && e.Id == personId).FirstOrDefaultAsync();
            if (e == null) return null;
            var personDto = new PersonDto
            {
                Age = DateTime.Now.Year - e.DateOfBirthday.Year,
                Id = e.Id,
                ArabicName = e.ArabicName,
                PhoneNumber = e.PhoneNumber,
                FirstName = e.FirstName,
                LastName = e.LastName,
                FatherName = e.Father == null ? "" : e.Father.FirstName,
                Gender = e.Gender,
                MaritalStatus = e.MaritalStatus,
                DateOfBirthday = e.DateOfBirthday,
                StudyLevelId = e.StudyLevel.Id,
                StudyLevel = e.StudyLevel.Level,
                NationalityId = e.Nationality.Id,
                Nationality = e.Nationality.Name,
                RelationShipId = e.Relationship.Id,
                RelationShip = e.Relationship.Relatioship,
                OrginalPlaceId = e.OriginAdress.Id,
                OriginalPlace = e.OriginAdress.Place,
                CurrentAddressId = e.CurrentAddress.Id,
                CurrentAddress = e.CurrentAddress.Place,
                FamilyCard = e.FamilyCard == null ? "" : e.FamilyCard.CardNumber,
                NCDId = e.NCDCard == null ? 0 : e.NCDCard.Id,
                NCD = e.NCDCard == null ? "" : e.NCDCard.CardNumber,
                CildCard = e.CildCard == null ? "" : e.CildCard.CardNumber,
                Children = e.Children!.Select(e => new PersonDto
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Gender = e.Gender,
                    MaritalStatus = e.MaritalStatus,
                    DateOfBirthday = e.DateOfBirthday,
                    StudyLevelId = e.StudyLevel.Id,
                    StudyLevel = e.StudyLevel.Level,
                    NationalityId = e.Nationality.Id,
                    Nationality = e.Nationality.Name,
                    RelationShipId = e.Relationship.Id,
                    RelationShip = e.Relationship.Relatioship,
                    OrginalPlaceId = e.OriginAdress.Id,
                    OriginalPlace = e.OriginAdress.Place,
                    CurrentAddressId = e.CurrentAddress.Id,
                    CurrentAddress = e.CurrentAddress.Place,
                    FamilyCardId = e.FamilyCard.Id,
                    FamilyCard = e.FamilyCard.CardNumber,
                    NCDId = e.NCDCard == null ? null : e.NCDCard.Id,
                    NCD = e.NCDCard == null ? null : e.NCDCard.CardNumber,
                    CildCard = e.CildCard == null ? "" : e.CildCard.CardNumber,
                }
                ).ToList()
            };
            return personDto;
        }
        public async Task<PersonDto?> GetByChildCard(string childCardNumber)
        {
            var e = await Context.People.Where(e=> e.CildCard != null ? e.CildCard.CardNumber.Equals(childCardNumber) : false).FirstOrDefaultAsync();
            if (e == null) return null;
            var personDto = new PersonDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                FatherName = e.Father == null ? "" : e.Father.FirstName,
                Gender = e.Gender,
                MaritalStatus = e.MaritalStatus,
                DateOfBirthday = e.DateOfBirthday,
                StudyLevelId = e.StudyLevel.Id,
                StudyLevel = e.StudyLevel.Level,
                NationalityId = e.Nationality.Id,
                Nationality = e.Nationality.Name,
                RelationShipId = e.Relationship.Id,
                RelationShip = e.Relationship.Relatioship,
                OrginalPlaceId = e.OriginAdress.Id,
                OriginalPlace = e.OriginAdress.Place,
                CurrentAddressId = e.CurrentAddress.Id,
                CurrentAddress = e.CurrentAddress.Place,
                FamilyCard = e.FamilyCard == null ? "" : e.FamilyCard.CardNumber,
                NCDId = e.NCDCard == null ? 0 : e.NCDCard.Id,
                NCD = e.NCDCard == null ? "" : e.NCDCard.CardNumber,
                CildCard = e.CildCard == null ? "" : e.CildCard.CardNumber,
                Children = e.Children!.Select(e => new PersonDto
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Gender = e.Gender,
                    MaritalStatus = e.MaritalStatus,
                    DateOfBirthday = e.DateOfBirthday,
                    StudyLevelId = e.StudyLevel.Id,
                    StudyLevel = e.StudyLevel.Level,
                    NationalityId = e.Nationality.Id,
                    Nationality = e.Nationality.Name,
                    RelationShipId = e.Relationship.Id,
                    RelationShip = e.Relationship.Relatioship,
                    OrginalPlaceId = e.OriginAdress.Id,
                    OriginalPlace = e.OriginAdress.Place,
                    CurrentAddressId = e.CurrentAddress.Id,
                    CurrentAddress = e.CurrentAddress.Place,
                    FamilyCardId = e.FamilyCard.Id,
                    FamilyCard = e.FamilyCard.CardNumber,
                    NCDId = e.NCDCard == null ? null : e.NCDCard.Id,
                    NCD = e.NCDCard == null ? null : e.NCDCard.CardNumber,
                    CildCard = e.CildCard == null ? "" : e.CildCard.CardNumber,
                }).ToList()
            };
            return personDto;
        }
        public async Task<PersonDto?> GetByNCD(string ncdNumber)
        {
            var e = await Context.People.Where(e => e.NCDCard != null ? e.NCDCard.CardNumber.Equals(ncdNumber) : false).FirstOrDefaultAsync();
            if (e == null) return null;
            var personDto = new PersonDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                FatherName = e.Father == null ? "" : e.Father.FirstName,
                Gender = e.Gender,
                MaritalStatus = e.MaritalStatus,
                DateOfBirthday = e.DateOfBirthday,
                StudyLevelId = e.StudyLevel.Id,
                StudyLevel = e.StudyLevel.Level,
                NationalityId = e.Nationality.Id,
                Nationality = e.Nationality.Name,
                RelationShipId = e.Relationship.Id,
                RelationShip = e.Relationship.Relatioship,
                OrginalPlaceId = e.OriginAdress.Id,
                OriginalPlace = e.OriginAdress.Place,
                CurrentAddressId = e.CurrentAddress.Id,
                CurrentAddress = e.CurrentAddress.Place,
                FamilyCard = e.FamilyCard == null ? "" : e.FamilyCard.CardNumber,
                NCDId = e.NCDCard == null ? 0 : e.NCDCard.Id,
                NCD = e.NCDCard == null ? "" : e.NCDCard.CardNumber,
                CildCard = e.CildCard == null ? "" : e.CildCard.CardNumber,
                Children = e.Children!.Select(e => new PersonDto
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Gender = e.Gender,
                    MaritalStatus = e.MaritalStatus,
                    DateOfBirthday = e.DateOfBirthday,
                    StudyLevelId = e.StudyLevel.Id,
                    StudyLevel = e.StudyLevel.Level,
                    NationalityId = e.Nationality.Id,
                    Nationality = e.Nationality.Name,
                    RelationShipId = e.Relationship.Id,
                    RelationShip = e.Relationship.Relatioship,
                    OrginalPlaceId = e.OriginAdress.Id,
                    OriginalPlace = e.OriginAdress.Place,
                    CurrentAddressId = e.CurrentAddress.Id,
                    CurrentAddress = e.CurrentAddress.Place,
                    FamilyCardId = e.FamilyCard.Id,
                    FamilyCard = e.FamilyCard.CardNumber,
                    NCDId = e.NCDCard == null ? null : e.NCDCard.Id,
                    NCD = e.NCDCard == null ? null : e.NCDCard.CardNumber,
                    CildCard = e.CildCard == null ? "" : e.CildCard.CardNumber,
                }).ToList()
            };
            return personDto;
        }

        public async Task RemovePerson(int personId)
        {
            var person = await pesonRepo.GetById(personId);
            await pesonRepo.Remove(personId);
        }

        public async Task UpdatePerson(PersonFormDto formDto)
        {
            var person = await pesonRepo.GetById(formDto.Id);
            person.Gender = formDto.Gender;
            person.MaritalStatus = formDto.MaritalStatus;
            person.StudyLevel = formDto.StudyLevelId == null ? person.StudyLevel: await studyLevelRepo.GetById(formDto.StudyLevelId??0);
            person.Relationship = formDto.RelationShipId == null ? person.Relationship:await relationshipRepo.GetById( formDto.RelationShipId??0);
            person.PhoneNumber = formDto.PhoneNumber == null ? person.PhoneNumber : formDto.PhoneNumber;
            person.ArabicName = formDto.ArabicName == null ? person.ArabicName : formDto.ArabicName;

            await pesonRepo.Update(person);
            
                   
        }
    }
}
