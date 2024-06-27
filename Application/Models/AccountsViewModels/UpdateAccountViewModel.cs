namespace Application.Models.AccountsViewModels
{
    public class UpdateAccountViewModel
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; } = string.Empty;
    }
}
