using IUNRWA_DTOs.FamilyCardDto;
using IUNRWA_DTOs.PersonDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository;
using IUNRWA_Repository.Repository.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.FamilyCardService
{
    public class FamilyCardService :IFamilyCardService
    {
        private readonly IBaseRepository<FamilyRegestrationCard> familyCardRepo;
        private readonly IBaseRepository<person> pesonRepo;
        private readonly AppDbContext Context;
        public FamilyCardService(IBaseRepository<FamilyRegestrationCard> familyCardRepo, IBaseRepository<person> pesonRepo, AppDbContext context)
        {
            this.familyCardRepo = familyCardRepo;
            this.pesonRepo = pesonRepo;
            Context = context;
        }
        public async Task<FamilyCardFormDto> AddFamilyCard(FamilyCardFormDto formDto)
        {
            var familyCard = await familyCardRepo.Add(new FamilyRegestrationCard { CardNumber = formDto.CardNumber });
            formDto.Id = familyCard.Id;
            return formDto;
        }
        public async Task<List<FamilyCardDto>> GetAllFamilyCards()
        {
            var familyCards = await familyCardRepo.GetAll();
            var familyCardsDtos = familyCards.Select(c => new FamilyCardDto
            {
                Id = c.Id,
                FamilyCardNumber = c.CardNumber,
                People = c.People.Select( e=> new PersonDto
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    FatherName = e.Father== null ? "": e.Father.FirstName,
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
                    NCDId = e.NCDCard == null ? 0: e.NCDCard.Id,
                    NCD  =  e.NCDCard==null ? "": e.NCDCard.CardNumber,
                    CildCard =e.CildCard == null ? null : e.CildCard.CardNumber,
                    Children = e.Children.Select(e => new PersonDto
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
                        FamilyCardId =  e.FamilyCard.Id,
                        FamilyCard = e.FamilyCard.CardNumber,
                        NCDId = e.NCDCard == null ? 0 : e.NCDCard.Id,
                        NCD =e.NCDCard == null ? null: e.NCDCard.CardNumber,
                        CildCard = e.CildCard == null ? null: e.CildCard.CardNumber
                    }).ToList()
                }).ToList()
            }).ToList();
            return familyCardsDtos;
        }
        public async Task <FamilyCardDto> GetFamilyCard(int id =0 , string familyCardNumber = null)
        {
            var familyCard = (id != 0) ? await Context.FamilyRegestrationCards.Where(e=>e.IsVaild && e.Id== id).FirstOrDefaultAsync()
                : await Context.FamilyRegestrationCards.Where(c => c.CardNumber.Equals(familyCardNumber)).FirstOrDefaultAsync();
            if (familyCard == null) return new FamilyCardDto();
            return new FamilyCardDto
            {
                Id = familyCard.Id,
                FamilyCardNumber = familyCard.CardNumber,
                People = familyCard.People.Select(e => new PersonDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    FatherName =e.Father == null ? "" : e.Father.FirstName,
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
                    NCDId =e.NCDCard == null ? 0 : e.NCDCard.Id,
                    NCD = e.NCDCard == null ? "" : e.NCDCard.CardNumber,
                    CildCard = e.CildCard == null ? " " : e.CildCard.CardNumber,
                    Children = e.Children == null ? new() : e.Children.Select(e => new PersonDto
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
                        FamilyCardId = e.FamilyCard.Id,
                        FamilyCard = e.FamilyCard.CardNumber,
                        NCDId = e.NCDCard == null ? 0 : e.NCDCard.Id,
                        NCD = e.NCDCard == null ? "" : e.NCDCard.CardNumber,
                        CildCard = e.CildCard == null ? " " : e.CildCard.CardNumber,
                    }).ToList()
                }).ToList()
            };
        }
        public async Task RemoveFamilyCard(int id)
        {
            var familyCard = await familyCardRepo.GetById(id);
            await familyCardRepo.Remove(familyCard.Id);
        }
    }
}
