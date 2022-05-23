using Core.Services.Abstractions;
using Manage.Areas.Admin.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IStaffService _staffService;

        public HomeController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var staff = await _staffService.GetStaffWithOrganizationAsync(User);
            if (staff == null) return NotFound();

            var model = new Models.Home.HomeIndexViewModel
            {
                OrganizationName = staff.Organization.Name
            };

            return View(model);
        }
    }
}
