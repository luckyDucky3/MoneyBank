using MoneyLib;

namespace TestApp
{
    internal class ConsoleUI
    {
        public int GetUserChoice()
        {
            Console.WriteLine("1) Положить сумму на счет");
            Console.WriteLine("2) Вычесть сумму со счета");
            Console.WriteLine("3) Конвертировать счет в другую валюту");
            Console.WriteLine("4) Просмотреть готовый пример работы программы");
            Console.WriteLine("5) Проверить баланс счета");
            Console.WriteLine("6) Выйти из пользовательского меню");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            Console.WriteLine("Некорректный ввод");
            return 0;
        }

        public Money GetMoneyInput()
        {
            Console.WriteLine("Какую сумму вы хотите положить?");
            decimal sum = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Какую валюту вы выберите?");
            Console.WriteLine("USD    EUR    RUB    CNY");
            string currency = Console.ReadLine();
            return new Money(sum, currency);
        }
        public Money GetMoneyOutput()
        {
            Console.WriteLine("Какую сумму вы хотите вычесть?");
            decimal sum = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Какую валюту вы выберите?");
            Console.WriteLine("USD    EUR    RUB    CNY");
            string currency = Console.ReadLine();
            return new Money(sum, currency);
        }
    }
}
