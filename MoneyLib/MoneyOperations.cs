namespace MoneyLib
{
    public class MoneyOperations
    {
        private ICurrencyConverter currencyConverter { get; set; }
        public MoneyOperations(ICurrencyConverter currencyConverter)
        {
            this.currencyConverter = currencyConverter;
        }
        public Money Addition(Money money1, Money money2)
        {
            return new Money(money1.Balance + currencyConverter.Convert(money2, money1.Currency), money1.Currency);
        }

        public Money Subtraction(Money money1, Money money2)
        {
            return new Money(money1.Balance - currencyConverter.Convert(money2, money1.Currency), money1.Currency);
        }
    }
}