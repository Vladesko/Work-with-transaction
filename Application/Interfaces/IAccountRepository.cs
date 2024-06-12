using Domain;

namespace Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAccountsAsync();
    }
}
