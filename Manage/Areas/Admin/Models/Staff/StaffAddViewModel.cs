using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.Staff
{
    public class StaffAddViewModel
    {
        [Display(Name = "Full name")]
        public string Fullname { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }

    public class StaffAddViewModelValidator : AbstractValidator<StaffAddViewModel>
    {
        public StaffAddViewModelValidator()
        {
            RuleFor(x => x.Fullname)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Password)
               .Must(x => x.Length >= 6)
               .WithMessage("Length must be greater than or equals to 6");

            RuleFor(x => x.ConfirmPassword)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.ConfirmPassword)
               .Must(x => x.Length >= 6)
               .WithMessage("Length must be greater than or equals to 6");

            RuleFor(x => x)
                .Must(ComparePasswords)
                .WithMessage("Password and Confirm Password must be the same.");
        }

        private bool ComparePasswords(StaffAddViewModel model)
        {
            return model.Password == model.ConfirmPassword;
        }
    }
}
