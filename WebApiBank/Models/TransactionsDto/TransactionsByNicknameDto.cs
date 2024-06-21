namespace WebApiBank.Models.TransactionsDto
{
    public class TransactionsByNicknameDto
    {
        public string NickNameFrom { get; set; } = string.Empty;
        public string NickNameTo { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
