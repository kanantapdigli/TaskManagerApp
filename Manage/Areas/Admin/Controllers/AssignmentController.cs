using Core.Entities;
using Core.Services.Abstractions;
using Core.Services.Notification.Email.Abstraction;
using Core.Services.Notification.Email.Models;
using Manage.Areas.Admin.Models.Assignment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "OrganizationOwner")]
    public class AssignmentController : Controller
    {
        private readonly IAssignmentService _assignmentService;
        private readonly IStaffService _staffService;
        private readonly IOrganizationService _organizationService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public AssignmentController(IAssignmentService assignmentService,
            IStaffService staffService,
            IOrganizationService organizationService,
            IUserService userService,
            IEmailService emailService)
        {
            _assignmentService = assignmentService;
            _staffService = staffService;
            _organizationService = organizationService;
            _userService = userService;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserWithOrganizationAsync(User);
            if (user == null) return NotFound();

            var model = new AssignmentIndexViewModel
            {
                Assignments = await _assignmentService.GetAllByOrganizationWithStaffsAsync(user.Organization.Id)
            };

            return View(model);
        }

        #region Add

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var user = await _userService.GetUserWithOrganizationAsync(User);
            if (user == null) return NotFound();

            var model = new AssignmentAddViewModel
            {
                Staffs = await _staffService.GetAllByOrganizationAsync(user.Organization.Id)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AssignmentAddViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userService.GetUserWithOrganizationAsync(User);
            if (user == null) return NotFound();

            var assignment = new Assignment
            {
                Title = model.Title,
                Description = model.Description,
                Status = model.Status,
                Deadline = model.Deadline,
                OrganizationId = user.Organization.Id
            };

            if (model.StaffIds != null)
            {
                var staffs = new List<Staff>();

                foreach (var staffId in model.StaffIds)
                {
                    var staff = await _staffService.GetAsync(staffId);
                    staffs.Add(staff);

                    await _emailService.SendEmail(new Message
                        (new List<string> { staff.Email }, 
                        $"New Task - {assignment.Title}",
                        $"{assignment.Title} was assigned you by now"
                        ));
                }

                assignment.Staffs = staffs;
            }

            await _assignmentService.CreateAsync(assignment);
            return RedirectToAction("index");
        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var assignment = await _assignmentService.GetAsync(id);
            if (assignment == null) return NotFound();

            var user = await _userService.GetUserWithOrganizationAsync(User);
            if (user == null) return NotFound();

            if (!await _organizationService.IsOwnerAsync(assignment.OrganizationId, user.Id)) return BadRequest();

            var model = new AssignmentEditViewModel
            {
                Id = assignment.Id,
                Title = assignment.Title,
                Description = assignment.Description,
                Status = assignment.Status,
                Deadline = assignment.Deadline,
                Staffs = await _staffService.GetAllByOrganizationAsync(user.Organization.Id),
                StaffIds = await _assignmentService.GetStaffIdsAsync(assignment.Id)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AssignmentEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var assignment = await _assignmentService.GetWithStaffsAsync(model.Id);
            if (assignment == null) return NotFound();

            var user = await _userService.GetUserAsync(User);
            if (user == null) return NotFound();

            if (!await _organizationService.IsOwnerAsync(assignment.OrganizationId, user.Id)) return BadRequest();

            assignment.Title = model.Title;
            assignment.Description = model.Description;
            assignment.Status = model.Status;
            assignment.Deadline = model.Deadline;

            var staffs = new List<Staff>();

            if (model.StaffIds != null)
            {
                foreach (var staffId in model.StaffIds)
                {
                    var staff = await _staffService.GetAsync(staffId);
                    staffs.Add(staff);

                    await _emailService.SendEmail(new Message
                       (new List<string> { staff.Email },
                       $"New Task - {assignment.Title}",
                       $"{assignment.Title} was assigned you by now"
                       ));
                }
            }

            assignment.Staffs = staffs;

            await _assignmentService.UpdateAsync(assignment);
            return RedirectToAction("index");
        }

        #endregion

        #region Details

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var assignment = await _assignmentService.GetWithStaffsAsync(id);
            if (assignment == null) return NotFound();

            var user = await _userService.GetUserAsync(User);
            if (user == null) return NotFound();

            if (!await _organizationService.IsOwnerAsync(assignment.OrganizationId, user.Id)) return BadRequest();

            var model = new AssignmentDetailsViewModel
            {
                Id = assignment.Id,
                Title = assignment.Title,
                Description = assignment.Description,
                Status = assignment.Status,
                Deadline = assignment.Deadline,
                Staffs = assignment.Staffs
            };

            return View(model);
        }

        #endregion

        #region Delete

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var assignment = await _assignmentService.GetAsync(id);
            if (assignment == null) return NotFound();

            var user = await _userService.GetUserAsync(User);
            if (user == null) return NotFound();

            if (!await _organizationService.IsOwnerAsync(assignment.OrganizationId, user.Id)) return BadRequest();

            await _assignmentService.DeleteAsync(assignment);
            return RedirectToAction("index");
        }

        #endregion
    }
}
