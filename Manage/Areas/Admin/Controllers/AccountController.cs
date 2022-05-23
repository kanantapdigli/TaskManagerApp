using Core.Constants.User;
using Core.Entities;
using Core.Services.Abstractions;
using Manage.Areas.Admin.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrganizationService _organizationService;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IUserService userService,
            IOrganizationService organizationService,
            SignInManager<User> signInManager)
        {
            _userService = userService;
            _organizationService = organizationService;
            _signInManager = signInManager;
        }

        #region Register

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new User
            {
                Fullname = model.Fullname,
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userService.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {

                var organization = new Organization
                {
                    Name = model.OrganizationName,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    OwnerId = user.Id
                };

                await _organizationService.CreateAsync(organization);

                await _userService.AddToRoleAsync(user, Roles.OrganizationOwner.ToString());

                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        #endregion

        #region Login

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded) return RedirectToAction("index", "home");

            ModelState.AddModelError(string.Empty,"Email or Password is incorrect");
            return View(model);
        }
        #endregion

        #region SignOut

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login");
        }

        #endregion
    }
}
