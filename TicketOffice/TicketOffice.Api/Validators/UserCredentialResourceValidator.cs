using FluentValidation;
using TicketOffice.Api.Resources;

namespace TicketOffice.Api.Validators
{
    public class UserCredentialResourceValidator:AbstractValidator<UserCredentialResource>
    {
        public UserCredentialResourceValidator()
        {
            RuleFor(x => x.Username)
              .NotNull()
              .NotEmpty();
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty();
        }
    }
}
