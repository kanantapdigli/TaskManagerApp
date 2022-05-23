using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Manage.Areas.Admin.Models.Account
{
    public class AccountLoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class AccountLoginViewModelValidator : AbstractValidator<AccountLoginViewModel>
    {
        public AccountLoginViewModelValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty();
        }
    }
}
