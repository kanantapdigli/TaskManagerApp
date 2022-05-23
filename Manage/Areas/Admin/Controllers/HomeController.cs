using Core.Services.Abstractions;
using Manage.Areas.Admin.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "OrganizationOwner")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserWithOrganizationAsync(User);
            if (user == null) return NotFound();

            var model = new HomeIndexViewModel
            {
                OrganizationName = user.Organization.Name
            };

            return View(model);
        }
    }
}
