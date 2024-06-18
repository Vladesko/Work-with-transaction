namespace WebApiBank.Models
{
    public class UpdateAccountDto
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; } = string.Empty;
    }
}
