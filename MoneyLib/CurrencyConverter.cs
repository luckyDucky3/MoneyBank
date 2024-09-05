
namespace MoneyLib
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private Dictionary<(string from, string to), decimal> ratesDictionary;
        public CurrencyConverter(Dictionary<(string from, string to), decimal> ratesDict)
        {
            ratesDictionary = ratesDict;
        }
        public decimal Convert(Money from, string toCurrency)
        {
            if (from.Currency == toCurrency)
            {
                Console.WriteLine("*** Конвертация не требуется ***");
                return from.Balance;
            }
            else if (ratesDictionary.TryGetValue((from.Currency, toCurrency), out decimal directRate))
            {
                Console.WriteLine("*** Конвертация прямым курсом ***");
                return from.Balance * directRate;
            }
            else
            {
                Console.WriteLine("*** Конвертация через кросс-курс ***");
                foreach (var rate in ratesDictionary)
                {
                    if (rate.Key.from == from.Currency)
                    {
                        var middleBalance = from.Balance * rate.Value;
                        if (ratesDictionary.TryGetValue((rate.Key.to, toCurrency), out decimal crossRate))
                        {
                            return middleBalance * crossRate;
                        }
                    }
                }
                throw new Exception($"Не удалось выполнить конвертацию из {from.Currency} в {toCurrency}");
            }
        }
    }
}