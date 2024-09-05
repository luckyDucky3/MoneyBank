using MoneyLib;

namespace TestApp
{
    internal class Program
    {
        static void ReadyExample(Dictionary<(string, string), decimal> ratesDictionary, CurrencyConverter converter, MoneyOperations operations)
        {
            Money moneyEUR = new Money(1000, "EUR");
            Money moneyUSD = new Money(1000, "USD");
            Money moneyRUB = new Money(50000, "RUB");

            Console.WriteLine($"Конвертация из RUB в RUB: {moneyRUB.Balance} -> {converter.Convert(moneyRUB, "RUB")}\n");
            Console.WriteLine($"Конвертация из USD в RUB: {moneyUSD.Balance} -> {converter.Convert(moneyUSD, "RUB")}\n");
            Console.WriteLine($"Конвертация из EUR в RUB: {moneyEUR.Balance} -> {converter.Convert(moneyEUR, "RUB")}\n");

            Money AddEURUSD = operations.Addition(moneyEUR, moneyUSD);
            Console.WriteLine($"{moneyEUR.Balance}:{moneyEUR.Currency} + {moneyUSD.Balance}:{moneyUSD.Currency} = {AddEURUSD.Balance}:{AddEURUSD.Currency}\n");

            Money SubEURUSD = operations.Subtraction(moneyEUR, moneyUSD);
            Console.WriteLine($"{moneyEUR.Balance}:{moneyEUR.Currency} - {moneyUSD.Balance}:{moneyUSD.Currency} = {SubEURUSD.Balance}:{SubEURUSD.Currency}\n");

            Money AddRUBEUR = operations.Addition(moneyRUB, moneyEUR);
            Console.WriteLine($"{moneyRUB.Balance}:{moneyRUB.Currency} + {moneyEUR.Balance}:{moneyEUR.Currency} = {AddRUBEUR.Balance}:{AddRUBEUR.Currency}\n");

            Money SubRUBEUR = operations.Subtraction(moneyRUB, moneyEUR);
            Console.WriteLine($"{moneyRUB.Balance}:{moneyRUB.Currency} - {moneyEUR.Balance}:{moneyEUR.Currency} = {SubRUBEUR.Balance}:{SubRUBEUR.Currency}\n");
        }


        static void Main(string[] args)
        {
            Dictionary<(string, string), decimal> ratesDictionary = new Dictionary<(string, string), decimal>()
            {
                { ("USD", "RUB"), 88.93m },
                { ("RUB", "USD"), 0.0112m },
                { ("CNY", "RUB"), 12.51m },
                { ("RUB", "CNY"), 0.079m },
                { ("CNY", "USD"), 0.14m },
                { ("USD", "CNY"), 7.09m },
                { ("USD", "EUR"), 0.9m },
                { ("EUR", "USD"), 1.11m },
            };
            CurrencyConverter converter = new CurrencyConverter(ratesDictionary);
            MoneyOperations operations = new MoneyOperations(converter);
            CommandHandler handler = new CommandHandler(operations, converter);
            ConsoleUI ui = new ConsoleUI();

            int choice = 0;
            Money money = new Money(0, "RUB");
            while (choice != 6)
            {
                choice = ui.GetUserChoice();
                switch (choice)
                {
                    case 1:
                        {
                            var tempMoney = ui.GetMoneyInput();
                            money = handler.Addition(money, tempMoney);
                        }
                        break;
                    case 2:
                        {
                            var tempMoney = ui.GetMoneyOutput();
                            money = handler.Subtraction(money, tempMoney);
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Выберите валюту для конвертации:");
                            Console.WriteLine("USD    EUR    RUB    CNY");
                            string newCurrency = Console.ReadLine();
                            money = handler.ConvertBalance(money, newCurrency);
                        }
                        break;
                    case 4:
                        ReadyExample(ratesDictionary, converter, operations);
                        break;
                    case 5:
                        Console.WriteLine("*** Баланс счета: ***\n");
                        Console.WriteLine($"{money.Balance}:{money.Currency}\n");
                        break;
                    case 6:
                        Console.WriteLine("----------\nВыход");
                        break;

                }
            }
            //Отрицательную разность оставляю в связи с тем, что она возможна и в условии не написано иное.
            //На мой взгляд SRP и IoC выполнены
        }
    }
}