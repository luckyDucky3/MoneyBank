namespace MoneyLib
{
    public interface ICurrencyConverter
    {
        decimal Convert(Money from, string toCurrency);
    }
}