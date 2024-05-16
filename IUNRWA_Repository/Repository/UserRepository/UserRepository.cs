using IUNRWA_Model.UNRWAUsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Repository.Repository.UserRepository
{
    public class UserRepository :IUserRepository
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext context;
        public UserRepository(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, AppDbContext context)
        {
            this.httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            this.context = context;
        }

        public async Task<User> GetCurrentUser()
        {
            var _httpcontext = httpContextAccessor.HttpContext;
            if (_httpcontext != null
                    && _httpcontext.User != null
                    && _httpcontext.User.Identity != null
                    && _httpcontext.User.Identity.IsAuthenticated)
            {
                User? user = (User?)await _userManager.GetUserAsync(_httpcontext.User);
                
                return user!;
            }
            else
                return null;
        }
        public async Task<Doctor> GetCurrentDoctor()
        {
            var _httpcontext = httpContextAccessor.HttpContext;
            if (_httpcontext != null
                    && _httpcontext.User != null
                    && _httpcontext.User.Identity != null
                    && _httpcontext.User.Identity.IsAuthenticated)
            {
                Doctor? user = (Doctor?)await _userManager.GetUserAsync(_httpcontext.User);

                var dbUser = await context.Doctors.Include(e => e.Person).Include(e => e.HealthCenter).Include(e => e.Team).Where(e => e.Id == user.Id).SingleOrDefaultAsync();
                return dbUser!;
            }
            else
                return null;
        }
        public async Task<NCDNurse> GetCurrentNCDNurse()
        {
            var _httpcontext = httpContextAccessor.HttpContext;
            if (_httpcontext != null
                    && _httpcontext.User != null
                    && _httpcontext.User.Identity != null
                    && _httpcontext.User.Identity.IsAuthenticated)
            {
                NCDNurse? user = (NCDNurse?)await _userManager.GetUserAsync(_httpcontext.User);
                var dbUser = await context.NCDNurses.Include(e => e.Person).Include(e => e.HealthCenter).Include(e => e.Team).Where(e => e.Id == user.Id).SingleOrDefaultAsync();
                return dbUser!;
            }
            else
                return null;
        }
        public async Task<Clerick> GetClerick()
        {
            var _httpcontext = httpContextAccessor.HttpContext;
            if (_httpcontext != null
                    && _httpcontext.User != null
                    && _httpcontext.User.Identity != null
                    && _httpcontext.User.Identity.IsAuthenticated)
            {
                Clerick? user = (Clerick?)await _userManager.GetUserAsync(_httpcontext.User);
                var dbUser = await context.Clericks.Include(e=>e.Person).Include(e=>e.HealthCenter).Include(e=>e.Team).Where(e => e.Id == user.Id).SingleOrDefaultAsync();
                return dbUser!;
            }
            else
                return null;
        }
        public async Task<Pharmacist> GetCurrentPharmascist()
        {
            var _httpcontext = httpContextAccessor.HttpContext;
            if (_httpcontext != null
                    && _httpcontext.User != null
                    && _httpcontext.User.Identity != null
                    && _httpcontext.User.Identity.IsAuthenticated)
            {
                Pharmacist? user = (Pharmacist?)await _userManager.GetUserAsync(_httpcontext.User);

                var dbUser = await context.Pharmacists.Include(e => e.Person).Include(e => e.HealthCenter).Include(e => e.Team).Where(e => e.Id == user.Id).SingleOrDefaultAsync();
                return dbUser!;
            }
            else
                return null;
        }
        public async Task<Tester> GetCurrentTester()
        {
            var _httpcontext = httpContextAccessor.HttpContext;
            if (_httpcontext != null
                    && _httpcontext.User != null
                    && _httpcontext.User.Identity != null
                    && _httpcontext.User.Identity.IsAuthenticated)
            {
                Tester? user = (Tester?)await _userManager.GetUserAsync(_httpcontext.User);

                var dbUser = await context.Testers.Include(e => e.Person).Include(e => e.HealthCenter).Include(e => e.Team).Where(e => e.Id == user.Id).SingleOrDefaultAsync();
                return dbUser!;
            }
            else
                return null;
        }
        public async Task<MeasurementNurse> GetCurrentMeasurementNurse()
        {
            var _httpcontext = httpContextAccessor.HttpContext;
            if (_httpcontext != null
                    && _httpcontext.User != null
                    && _httpcontext.User.Identity != null
                    && _httpcontext.User.Identity.IsAuthenticated)
            {
               MeasurementNurse? user = (MeasurementNurse?)await _userManager.GetUserAsync(_httpcontext.User);

                var dbUser = await context.MeasurementNurses.Include(e => e.Person).Include(e => e.HealthCenter).Include(e => e.Team).Where(e => e.Id == user.Id).SingleOrDefaultAsync();
                return dbUser!;
            }
            else
                return null;
        }
    }
}
