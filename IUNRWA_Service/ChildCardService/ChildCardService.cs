using IUNRWA_DTOs.ChildCardDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.ChildCardService
{
    public class ChildCardService: IChildCardService
    {
        private readonly IBaseRepository<person> pesonRepo;
        private readonly IBaseRepository<ChildCard> childCardRepo;

        public ChildCardService(IBaseRepository<ChildCard> childCardRepo, IBaseRepository<person> pesonRepo)
        {
            this.childCardRepo = childCardRepo;
            this.pesonRepo = pesonRepo;
        }
        public async Task AddChildCard(ChildCardFormDto formDto)
        {
            var childCard = new ChildCard
            {
                CardNumber = formDto.ChildCardNumber,
                Person = await pesonRepo.GetById(formDto.PersonId),
                IsActive = true
            };
            await childCardRepo.Add(childCard);
        }


    }
}
