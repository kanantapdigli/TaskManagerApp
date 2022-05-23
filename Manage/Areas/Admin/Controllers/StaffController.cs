using Core.Constants.User;
using Core.Entities;
using Core.Services.Abstractions;
using Manage.Areas.Admin.Models.Staff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "OrganizationOwner")]
    public class StaffController : Controller
    {
        private readonly IUserService _userService;
        private readonly IStaffService _staffService;

        public StaffController(IUserService userService,
            IStaffService staffService)
        {
            _userService = userService;
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserWithOrganizationAsync(User);
            if (user == null) return NotFound();

            var model = new StaffIndexViewModel
            {
                Staffs = await _staffService.GetAllByOrganizationAsync(user.Organization.Id)
            };

            return View(model);
        }

        #region Add

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(StaffAddViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userService.GetUserWithOrganizationAsync(User);
            if (user == null) return NotFound();

            var staff = new Staff
            {
                Fullname = model.Fullname,
                Email = model.Email,
                UserName = model.Email,
                OrganizationId = user.Organization.Id,
            };

            var result = await _staffService.CreateAsync(staff, model.Password);
            if (result.Succeeded)
            {
                if (result.Succeeded) return RedirectToAction("index", "staff");

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                return View(model);
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var staff = await _staffService.GetAsync(id);
            if (staff == null) return NotFound();

            var model = new StaffEditViewModel
            {
                Id = staff.Id,
                Fullname = staff.Fullname,
                Email = staff.Email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StaffEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var staff = await _staffService.GetAsync(model.Id);
            if (staff == null) return NotFound();

            staff.Fullname = model.Fullname;
            staff.Email = model.Email;

            var result = await _staffService.UpdateWithResultAsync(staff);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    return View(model);
                }
            }

            if (model.NewPassword != null)
                await _staffService.ResetPasswordAsync(staff, model.NewPassword);

            return RedirectToAction("index");
        }

        #endregion

        #region Details

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var staff = await _staffService.GetAsync(id);
            if (staff == null) return NotFound();

            var model = new StaffDetailsViewModel
            {
                Id = staff.Id,
                Fullname = staff.Fullname,
                Email = staff.Email
            };

            return View(model);
        }

        #endregion

        #region Delete

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var staff = await _staffService.GetAsync(id);
            if (staff == null) return NotFound();

            await _staffService.DeleteAsync(staff);
            return RedirectToAction("index");
        }

        #endregion
    }
}
