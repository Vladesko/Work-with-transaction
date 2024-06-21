namespace WebApiBank.Models.AccountsDto
{
    public class UpdateAccountDto
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; } = string.Empty;
    }
}
