using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manage.Models.Assignment
{
    public class AssignmentEditViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Core.Constants.Task.TaskStatus Status { get; set; }

        public DateTime Deadline { get; set; }

        [Display(Name = "Staffs")]
        public List<string> StaffIds { get; set; }

        public List<Core.Entities.Staff> Staffs { get; set; }
    }

    public class AssignmentEditViewModelValidator : AbstractValidator<AssignmentEditViewModel>
    {
        public AssignmentEditViewModelValidator()
        {
            RuleFor(x => x.Id)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.Title)
               .NotNull()
               .NotEmpty();
        }
    }
}
