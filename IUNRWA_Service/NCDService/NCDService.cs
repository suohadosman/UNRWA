using IUNRWA_DTOs.NCDDto;
using IUNRWA_Model.Entity;
using IUNRWA_Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IUNRWA_Service.NCDService
{
    public class NCDService: INCDService
    {
        private readonly AppDbContext _context;

        public NCDService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<NCDFormDto> AddNCDCard(NCDFormDto formDto)
        {
            var entity = new NCDCard();
            var person = await _context.People.Where(x => x.Id == formDto.personId && x.IsVaild).FirstOrDefaultAsync();
            entity.CardNumber = DateTime.UtcNow.ToShortDateString();
            entity.Sensitive = formDto.Sensitive == null ? null : formDto.Sensitive;
            entity.PersonId = formDto.personId;
            await _context.NCDCards.AddAsync(entity);
            await _context.SaveChangesAsync();
            formDto.Id = entity.Id;
            entity.CardNumber = entity.CardNumber+"-"+entity.Id;
            await _context.SaveChangesAsync();
            formDto.CardNumber = entity.CardNumber;
            formDto.CreationDate = entity.CreationDate.ToShortDateString();
            formDto.personId = formDto.personId;
            formDto.PersonName = person.FirstName + " " + person.LastName;
            return formDto;
        }
        public async Task<NCDDto?> GetNCDCard(string number)
        {
            var entity = await _context.NCDCards.Where(e => e.IsVaild && e.CardNumber.Equals(number)).SingleOrDefaultAsync();
            if(entity == null) { return null; }
            return new NCDDto
            {
                Id= entity!.Id,
                PersonId = entity.PersonId,
                Sensitive = entity.Sensitive,
                DateOfCreated = entity.DateOfCreated,
                Diabetes = entity.Diabetes,
                Pressure = entity.Pressure,
                NCDNumber = entity.CardNumber
            };
        }
        public async Task Remove(string number)
        {
            var entity = await _context.NCDCards.Where(e => e.IsVaild && e.CardNumber.Equals(number)).SingleOrDefaultAsync();
            _context.Remove(entity!);
             await  _context.SaveChangesAsync();
        }
    }
}
