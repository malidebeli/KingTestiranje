using FluentValidation;
using TicketOffice.Api.Resources;

namespace TicketOffice.Api.Validators
{
    public class SaveOrderResourceValidator : AbstractValidator<SaveOrderResource>
    {
        public SaveOrderResourceValidator()
        {
            RuleFor(x => x.CustomerId)
               .NotNull()
               .NotEmpty();             
            RuleFor(x => x.Tickets)
                .NotNull()
                .NotEmpty();
        }
    }
}
