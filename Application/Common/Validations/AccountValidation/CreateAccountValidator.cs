using Application.Models.AccountsViewModels;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Common.Validations.AccountValidation
{
    internal class CreateAccountValidator : AbstractValidator<CreateAccountViewModel>
    {
        private const string BAD_REQUEST = "400";
        public CreateAccountValidator()
        {
            //Name validation
            RuleFor(m => m.Name).NotEmpty().NotNull().WithMessage("Name is empty").WithErrorCode(BAD_REQUEST);
            RuleFor(m => m.Name).MaximumLength(70).WithMessage("Your name is long").WithErrorCode(BAD_REQUEST);
            RuleFor(m => m.Name).MinimumLength(2).WithMessage("Your name is small").WithErrorCode(BAD_REQUEST);

            //Nickname validation
            RuleFor(m => m.Nickname).NotNull().NotEmpty().WithMessage("Nickname is empty").WithErrorCode(BAD_REQUEST);
            RuleFor(m => m.Nickname).MaximumLength(35).WithMessage("Your nick name is long").WithErrorCode(BAD_REQUEST);
            RuleFor(m => m.Nickname).MinimumLength(3).WithMessage("Your nickname is small").WithErrorCode(BAD_REQUEST);
        }
    }
}
