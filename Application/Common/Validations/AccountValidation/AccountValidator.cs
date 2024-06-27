using Application.Common.Exceptions;
using Application.Interfaces.AccountsInterfaces;
using Application.Models.AccountsViewModels;
using FluentValidation;

namespace Application.Common.Validations.AccountValidation
{
    internal class AccountValidator(IValidator<CreateAccountViewModel> createModelValidator,
                                    IValidator<UpdateAccountViewModel> updateModelValidator) : IAccountValidator
    {
        private readonly IValidator<CreateAccountViewModel> createModelValidator = createModelValidator;
        private readonly IValidator<UpdateAccountViewModel> updateAccountValidator = updateModelValidator;
        public async Task ValidateAsync(CreateAccountViewModel model)
        {
            var result = await createModelValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)     
                    throw new CustomValidationException(error.ErrorMessage, int.Parse(error.ErrorCode));
            }
        }

        public async Task ValidateAsync(UpdateAccountViewModel model)
        {
            var result = await updateAccountValidator.ValidateAsync(model);
            if(result.IsValid)
            {
                foreach (var error in result.Errors)
                    throw new CustomValidationException(error.ErrorMessage, int.Parse(error.ErrorCode));
            }
        }
    }
}
