using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.Account
{
    public class AccountRegisterViewModel
    {
        [Display(Name = "Username")]
        public string Fullname { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    public class AccountRegisterViewModelValidator : AbstractValidator<AccountRegisterViewModel>
    {
        public AccountRegisterViewModelValidator()
        {
            RuleFor(x => x.Fullname)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.OrganizationName)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Address)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .NotEmpty();

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

        private bool ComparePasswords(AccountRegisterViewModel model)
        {
            return model.Password == model.ConfirmPassword;
        }
    }
}
