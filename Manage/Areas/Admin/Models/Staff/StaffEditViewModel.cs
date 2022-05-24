using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.Staff
{
    public class StaffEditViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Full name")]
        public string Fullname { get; set; }

        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; }
    }

    public class StaffEditViewModelValidator : AbstractValidator<StaffEditViewModel>
    {
        public StaffEditViewModelValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Fullname)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.NewPassword)
                .NotNull()
                .NotEmpty()
                .When(x => x.ConfirmNewPassword != null);

            RuleFor(x => x.NewPassword)
               .Must(x => x.Length >= 6)
               .When(x => x.NewPassword != null)
               .WithMessage("Length must be greater than or equals to 6");

            RuleFor(x => x.ConfirmNewPassword)
                .NotNull()
                .NotEmpty()
                .When(x => x.NewPassword != null);

            RuleFor(x => x.ConfirmNewPassword)
               .Must(x => x.Length >= 6)
               .When(x => x.ConfirmNewPassword != null)
               .WithMessage("Length must be greater than or equals to 6");

            RuleFor(x => x)
                .Must(ComparePasswords)
                .WithMessage("New Password and Confirm New Password must be the same.");
        }

        private bool ComparePasswords(StaffEditViewModel model)
        {
            return model.NewPassword == model.ConfirmNewPassword;
        }
    }
}
