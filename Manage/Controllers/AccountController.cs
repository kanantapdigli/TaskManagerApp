using Core.Entities;
using Core.Services.Abstractions;
using Manage.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class AccountController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly SignInManager<Staff> _signInManager;

        public AccountController(IStaffService staffService,
            SignInManager<Staff> signInManager)
        {
            _staffService = staffService;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var staff = await _staffService.FindByEmailAsync(model.Email);
            if (staff != null)
            {
                var result = await _signInManager.PasswordSignInAsync(staff, model.Password, false, false);
                if (result.Succeeded) return RedirectToAction("index", "assignment");
            }

            ModelState.AddModelError(string.Empty, "Email or Password is incorrect");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Signout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }
    }
}
