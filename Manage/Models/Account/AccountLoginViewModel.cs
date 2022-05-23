using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Manage.Models.Account
{
    public class AccountLoginViewModel
    {
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
