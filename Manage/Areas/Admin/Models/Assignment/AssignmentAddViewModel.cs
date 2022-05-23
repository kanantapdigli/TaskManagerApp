using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Models.Assignment
{
    public class AssignmentAddViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Core.Constants.Task.TaskStatus Status { get; set; }

        public DateTime Deadline { get; set; }

        [Display(Name = "Staffs")]
        public List<string> StaffIds { get; set; }

        public List<Core.Entities.Staff> Staffs { get; set; }
    }

    public class AssignmentAddViewModelValidator : AbstractValidator<AssignmentAddViewModel>
    {
        public AssignmentAddViewModelValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty();
        }
    }
}
