using Domain;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<List<Account>> GetAccountsAsync();
    }
}
