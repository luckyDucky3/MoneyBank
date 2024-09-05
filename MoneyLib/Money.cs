namespace MoneyLib
{
    public class Money
    {
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public Money(decimal balance, string currency)
        {
            Balance = balance;
            Currency = currency;
        }
    }
}
