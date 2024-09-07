using MoneyLib;

namespace TestApp
{
    public class CommandHandler
    {
        private readonly MoneyOperations _operations;
        private readonly ICurrencyConverter _converter;

        public CommandHandler(MoneyOperations operations, ICurrencyConverter converter)
        {
            _operations = operations;
            _converter = converter;
        }

        public Money Addition(Money money1, Money money2)
        {
            money1 = _operations.Addition(money1, money2);
            Console.WriteLine($"Баланс после пополнения: {money1.Balance} {money1.Currency}");
            return money1;
        }

        public Money Subtraction(Money money1, Money money2)
        {
            money1 = _operations.Subtraction(money1, money2);
            Console.WriteLine($"Баланс после снятия: {money1.Balance} {money1.Currency}");
            return money1;
        }

        public Money ConvertBalance(Money money, string newCurrency)
        {
            money.Balance = _converter.Convert(money, newCurrency);
            money.Currency = newCurrency;
            Console.WriteLine($"Баланс после конвертации: {money.Balance} {money.Currency}");
            return money;
        }
    }
}
