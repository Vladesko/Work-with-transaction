namespace Domain
{
    public class Account
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public decimal AmountOfMoney { get; set; }

    }
}
