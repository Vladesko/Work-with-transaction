using Application.Models.AccountsViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Validations.AccountValidation
{
    internal class UpdateAccountValidator : AbstractValidator<UpdateAccountViewModel>
    {
        private const string BAD_REQUEST = "400";
        public UpdateAccountValidator()
        {
            //Id validation
            RuleFor(m => m.Id).NotEmpty().NotNull().NotEqual(Guid.Empty).WithMessage("Id is empty").WithErrorCode(BAD_REQUEST);
            RuleFor(m => m.Id).Must(BeGuid).WithMessage("Id is not incorrect").WithErrorCode(BAD_REQUEST);

            //Nickname validation
            RuleFor(m => m.Nickname).NotNull().NotEmpty().WithMessage("Nickname is empty").WithErrorCode(BAD_REQUEST);
            RuleFor(m => m.Nickname).MaximumLength(35).WithMessage("Your nick name is long").WithErrorCode(BAD_REQUEST);
            RuleFor(m => m.Nickname).MinimumLength(3).WithMessage("Your nickname is small").WithErrorCode(BAD_REQUEST);
        }
        protected bool BeGuid(Guid guid)
        {
            return Guid.TryParse(guid.ToString(), out guid);
        }

    }
}
