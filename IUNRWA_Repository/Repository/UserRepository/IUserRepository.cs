using IUNRWA_Model.UNRWAUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Repository.Repository.UserRepository
{
    public interface IUserRepository
    {
        public Task<User> GetCurrentUser();
        public Task<Doctor> GetCurrentDoctor();
        public Task<NCDNurse> GetCurrentNCDNurse();
        public Task<Clerick> GetClerick();
        public Task<Pharmacist> GetCurrentPharmascist();
        public Task<Tester> GetCurrentTester();
        public Task<MeasurementNurse> GetCurrentMeasurementNurse();

    }
}
