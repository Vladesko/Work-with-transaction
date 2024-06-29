using Application.Models.AccountsViewModels;

namespace Application.Interfaces.AccountsInterfaces
{
    internal interface IAccountValidator
    {
        Task ValidateAsync(CreateAccountViewModel model);
        Task ValidateAsync(UpdateAccountViewModel model);
    }
}
