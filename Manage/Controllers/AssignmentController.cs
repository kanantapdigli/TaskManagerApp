using Core.Entities;
using Core.Services.Abstractions;
using Core.Services.Notification.Email.Abstraction;
using Core.Services.Notification.Email.Models;
using Manage.Models.Assignment;
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
    public class AssignmentController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly IAssignmentService _assignmentService;
        private readonly IOrganizationService _organizationService;
        private readonly IEmailService _emailService;

        public AssignmentController(IStaffService staffService,
            IAssignmentService assignmentService,
            IOrganizationService organizationService,
            IEmailService emailService)
        {
            _staffService = staffService;
            _assignmentService = assignmentService;
            _organizationService = organizationService;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var staff = await _staffService.GetStaffWithOrganizationAsync(User);
            if (staff == null) return NotFound();

            var model = new AssignmentIndexViewModel
            {
                OrganizationName = staff.Organization.Name,
                Email = staff.Email,
                Fullname = staff.Fullname,
                Assignments = await _assignmentService.GetAllByOrganizationWithStaffsAsync(staff.OrganizationId)
            };

            return View(model);
        }

        #region Add

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var staff = await _staffService.GetStaffWithOrganizationAsync(User);
            if (staff == null) return NotFound();

            var model = new AssignmentAddViewModel
            {
                Staffs = await _staffService.GetAllByOrganizationAsync(staff.OrganizationId)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AssignmentAddViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var staff = await _staffService.GetStaffWithOrganizationAsync(User);
            if (staff == null) return NotFound();

            var assignment = new Assignment
            {
                Title = model.Title,
                Description = model.Description,
                Status = model.Status,
                Deadline = model.Deadline,
                OrganizationId = staff.Organization.Id
            };

            if (model.StaffIds != null)
            {
                var staffs = new List<Staff>();

                foreach (var staffId in model.StaffIds)
                {
                    staff = await _staffService.GetAsync(staffId);
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

            var staff = await _staffService.GetStaffWithOrganizationAsync(User);
            if (staff == null) return NotFound();

            if (!await _organizationService.IsStaffAsync(assignment.OrganizationId, staff.Id)) return BadRequest();

            var model = new AssignmentEditViewModel
            {
                Id = assignment.Id,
                Title = assignment.Title,
                Description = assignment.Description,
                Status = assignment.Status,
                Deadline = assignment.Deadline,
                Staffs = await _staffService.GetAllByOrganizationAsync(staff.OrganizationId),
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

            var staff = await _staffService.GetUserAsync(User);
            if (staff == null) return NotFound();

            if (!await _organizationService.IsStaffAsync(assignment.OrganizationId, staff.Id)) return BadRequest();

            assignment.Title = model.Title;
            assignment.Description = model.Description;
            assignment.Status = model.Status;
            assignment.Deadline = model.Deadline;

            var staffs = new List<Staff>();

            if (model.StaffIds != null)
            {
                foreach (var staffId in model.StaffIds)
                {
                    staff = await _staffService.GetAsync(staffId);
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

            var staff = await _staffService.GetUserAsync(User);
            if (staff == null) return NotFound();

            if (!await _organizationService.IsStaffAsync(assignment.OrganizationId, staff.Id)) return BadRequest();

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

            var staff = await _staffService.GetUserAsync(User);
            if (staff == null) return NotFound();

            if (!await _organizationService.IsStaffAsync(assignment.OrganizationId, staff.Id)) return BadRequest();

            await _assignmentService.DeleteAsync(assignment);
            return RedirectToAction("index");
        }

        #endregion
    }
}
