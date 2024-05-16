using IUNRWA_DTOs.Views;
using IUNRWA_Model.UNRWAUsers;
using IUNRWA_Service.AuthenticationService;
using IUNRWA_ShareKernal.Enum.User;
using IUNRWA_ShareKernal.Enum.ViewsName;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace UNRWAHealthProgramme.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthenticationService _authService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public HomeController(IAuthenticationService authService, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _authService = authService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormDto formDto)
        {
           var result = await _authService.Login(formDto);
           return  result.Succeeded ?  Ok() :  NotFound(); 
        }

        public async Task<IActionResult> RedirectTheUser(LoginFormDto formDto)
        {
            var user = await _userManager.FindByNameAsync(formDto.UserName);
            if (await _userManager.IsInRoleAsync(user!, nameof(UserRoles.Doctor)))
            {
                //return RedirectToAction("Index", "UsersManager");
                return Json(new { redirectUrl = Url.Action("Index", nameof(ViewsName.Doctor) )});
            }

            else if (await _userManager.IsInRoleAsync(user!, nameof(UserRoles.Clerick)))
            {
                //  return RedirectToAction("Index", "Doctor"); 
                return Json(new { redirectUrl = Url.Action("Home", nameof(ViewsName.Clerick)) });
            }
            else if (await _userManager.IsInRoleAsync(user!, nameof(UserRoles.Pharmacist)))
            {
                //  return RedirectToAction("Index", "Doctor"); 
                return Json(new { redirectUrl = Url.Action("Index", nameof(ViewsName.Pharmacist) )});
            }
            else if (await _userManager.IsInRoleAsync(user!, nameof(UserRoles.Tester)))
            {
                //  return RedirectToAction("Index", "Doctor"); 
                return Json(new { redirectUrl = Url.Action("Index", nameof(ViewsName.Tester)) });
            }
            else if (await _userManager.IsInRoleAsync(user!, nameof(UserRoles.NCDNurse)))
            {
                //  return RedirectToAction("Index", "Doctor"); 
                //var ncdNurseRole = await _roleManager.FindByNameAsync(nameof(UserRoles.NCDNurse));
                //if (ncdNurseRole == null)
                //{
                //    await _roleManager.CreateAsync(new IdentityRole<int>(nameof(UserRoles.NCDNurse)));
                //}
                //await _userManager.AddToRoleAsync(user, nameof(UserRoles.NCDNurse));
                return Json(new { redirectUrl = Url.Action("Index", nameof(ViewsName.NCDNurse)) });
            }
            else if (await _userManager.IsInRoleAsync(user!, nameof(UserRoles.MeasurementNurse)))
            {
                //  return RedirectToAction("Index", "Doctor"); 
                return Json(new { redirectUrl = Url.Action("Index", nameof(ViewsName.MeasurementNurse)) });
            }
            else
            {
                return NotFound();
            }
        }
    }
}
