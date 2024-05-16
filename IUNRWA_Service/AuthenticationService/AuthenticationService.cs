using IUNRWA_DTOs.AuthenticationDto;
using IUNRWA_DTOs.Views;
using IUNRWA_Model.Entity;
using IUNRWA_Model.UNRWAUsers;
using IUNRWA_Repository.Repository.BaseRepository;
using IUNRWA_ShareKernal.Enum.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUNRWA_Service.AuthenticationService
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IBaseRepository<HealthCenter> healthCenterRepo;
        private readonly IBaseRepository<Team> teamRepo;
        private readonly IBaseRepository<person> personRepo;

        public AuthenticationService(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, IBaseRepository<HealthCenter> healthCenterRepo, IBaseRepository<Team> teamRepo, IBaseRepository<person> personRepo, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.healthCenterRepo = healthCenterRepo;
            this.teamRepo = teamRepo;
            this.personRepo = personRepo;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult?> SingnUpEmployee(SignUpEmployeeFormDto formDto)
        {
            try
            {
                //User user = new Clerick
                //{
                //    Person = await personRepo.GetById(formDto.PersonId),
                //    Team = await teamRepo.GetById(formDto.TeamId),
                //    HealthCenter = await healthCenterRepo.GetById(formDto.HealthCenterId),
                //    UserName = formDto.UserName
                //};

                //var result = await _userManager.CreateAsync(user, formDto.Password);
                IdentityResult? result = new();
                switch (formDto.EmployeeType)
                {
                    case UserType.Doctor:
                        Doctor doctor = new Doctor
                        {
                            Person = await personRepo.GetById(formDto.PersonId),
                            Team = await teamRepo.GetById(formDto.TeamId),
                            HealthCenter = await healthCenterRepo.GetById(formDto.HealthCenterId),
                            UserName = formDto.UserName
                        };

                        result = await _userManager.CreateAsync(doctor, formDto.Password);
                        var doctorRole = await _roleManager.FindByNameAsync(nameof(UserRoles.Doctor));
                        if (doctorRole == null)
                        {
                            await _roleManager.CreateAsync(new IdentityRole<int>(nameof(UserRoles.Doctor)));
                        }
                        await _userManager.AddToRoleAsync(doctor, nameof(UserRoles.Doctor));
                        break;


                    case UserType.Clerick:
                        Clerick clerick = new Clerick
                        {
                            Person = await personRepo.GetById(formDto.PersonId),
                            Team = await teamRepo.GetById(formDto.TeamId),
                            HealthCenter = await healthCenterRepo.GetById(formDto.HealthCenterId),
                            UserName = formDto.UserName
                        };

                        result = await _userManager.CreateAsync(clerick, formDto.Password);
                        var clerickRole = await _roleManager.FindByNameAsync(nameof(UserRoles.Clerick));
                        if (clerickRole == null)
                        {
                            await _roleManager.CreateAsync(new IdentityRole<int>(nameof(UserRoles.Clerick)));
                        }
                        await _userManager.AddToRoleAsync(clerick, nameof(UserRoles.Clerick));
                        break;


                    case UserType.Pharmacist:
                        Pharmacist ph = new Pharmacist
                        {
                            Person = await personRepo.GetById(formDto.PersonId),
                            Team = await teamRepo.GetById(formDto.TeamId),
                            HealthCenter = await healthCenterRepo.GetById(formDto.HealthCenterId),
                            UserName = formDto.UserName
                        };
                        result = await _userManager.CreateAsync(ph, formDto.Password);
                        var phRole = await _roleManager.FindByNameAsync(nameof(UserRoles.Pharmacist));
                        if (phRole == null)
                        {
                            await _roleManager.CreateAsync(new IdentityRole<int>(nameof(UserRoles.Pharmacist)));
                        }
                        await _userManager.AddToRoleAsync(ph, nameof(UserRoles.Pharmacist));
                        break;


                    case UserType.Tester:
                        Tester tester = new Tester
                        {
                            Person = await personRepo.GetById(formDto.PersonId),
                            Team = await teamRepo.GetById(formDto.TeamId),
                            HealthCenter = await healthCenterRepo.GetById(formDto.HealthCenterId),
                            UserName = formDto.UserName
                        };
                        result = await _userManager.CreateAsync(tester, formDto.Password);
                        var testerRole = await _roleManager.FindByNameAsync(nameof(UserRoles.Tester));
                        if (testerRole == null)
                        {
                            await _roleManager.CreateAsync(new IdentityRole<int>(nameof(UserRoles.Tester)));
                        }
                        await _userManager.AddToRoleAsync(tester, nameof(UserRoles.Tester));
                        break;


                    case UserType.NCDNurse:
                        IUNRWA_Model.UNRWAUsers.NCDNurse nurse = new IUNRWA_Model.UNRWAUsers.NCDNurse
                        {
                            Person = await personRepo.GetById(formDto.PersonId),
                            Team = await teamRepo.GetById(formDto.TeamId),
                            HealthCenter = await healthCenterRepo.GetById(formDto.HealthCenterId),
                            UserName = formDto.UserName
                        };
                        result = await _userManager.CreateAsync(nurse, formDto.Password);
                        var ncdNurseRole = await _roleManager.FindByNameAsync(nameof(UserRoles.NCDNurse));
                        if (ncdNurseRole == null)
                        {
                            await _roleManager.CreateAsync(new IdentityRole<int>(nameof(UserRoles.NCDNurse)));
                        }
                        await _userManager.AddToRoleAsync(nurse, nameof(UserRoles.NCDNurse));
                        break;
                    case UserType.MeasurementNurse:
                        MeasurementNurse meaNurse = new MeasurementNurse
                        {
                            Person = await personRepo.GetById(formDto.PersonId),
                            Team = await teamRepo.GetById(formDto.TeamId),
                            HealthCenter = await healthCenterRepo.GetById(formDto.HealthCenterId),
                            UserName = formDto.UserName
                        };
                        result = await _userManager.CreateAsync(meaNurse, formDto.Password);
                        var meaNurseRole = await _roleManager.FindByNameAsync(nameof(UserRoles.MeasurementNurse));
                        if (meaNurseRole == null)
                        {
                            await _roleManager.CreateAsync(new IdentityRole<int>(nameof(UserRoles.MeasurementNurse)));
                        }
                        await _userManager.AddToRoleAsync(meaNurse, nameof(UserRoles.MeasurementNurse));
                        break;
                    default:
                        break;
                }

                await personRepo.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SignInResult> Login(LoginFormDto formDto)
        {
            try
            {
                await _signInManager.SignOutAsync();
                var user = await _userManager.FindByNameAsync(formDto.UserName);
                SignInResult result = await _signInManager.PasswordSignInAsync(user, formDto.Password, false, false);
                return result;
            }
            catch(Exception ex) { throw; }
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
