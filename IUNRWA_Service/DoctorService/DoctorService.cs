using IUNRWA_DTOs.DoctorDto;
using IUNRWA_Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.DoctorService
{
    public class DoctorService :IDoctorService
    {
        private readonly AppDbContext context;

        public DoctorService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<DoctorDto>> GetAllDoctor(int? teamId =0)
        {
            var doctors = teamId == 0 ? await context.Doctors.Include(e=> e.Person).Select( e=> new DoctorDto { Id = e.Id, Name = e.Person.FirstName + " "+ e.Person.LastName}).ToListAsync() 
                : await context.Doctors.Include(e => e.Person).Include(e=> e.Team).Where(e => e.Team.Id == teamId).Select(e => new DoctorDto { Id = e.Id, Name = e.Person.FirstName + " " + e.Person.LastName }).ToListAsync();
            var ncdNurses = teamId == 0 ? await context.NCDNurses.Include(e => e.Person).Select(e => new DoctorDto { Id = e.Id, Name = e.Person.FirstName + " " + e.Person.LastName }).ToListAsync()
                : await context.NCDNurses.Include(e => e.Person).Include(e => e.Team).Where(e => e.Team.Id == teamId).Select(e => new DoctorDto { Id = e.Id, Name = e.Person.FirstName + " " + e.Person.LastName }).ToListAsync();
            doctors.AddRange(ncdNurses);
            return doctors;
        }
       
    }
}
