using System;

namespace HomeWork_6
{
    class Program
    {
        static void Main()
        {
            PaymentContext context = new PaymentContext();

            Console.WriteLine("Выберите способ оплаты:");
            Console.WriteLine("1 - Банковская карта");
            Console.WriteLine("2 - PayPal");
            Console.WriteLine("3 - Криптовалюта");

            string choice = Console.ReadLine();
            Console.Write("Введите сумму оплаты: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    Console.Write("Введите номер карты: ");
                    string card = Console.ReadLine();
                    context.SetPaymentStrategy(new CreditCardPayment(card));
                    break;

                case "2":
                    Console.Write("Введите email PayPal: ");
                    string email = Console.ReadLine();
                    context.SetPaymentStrategy(new PayPalPayment(email));
                    break;

                case "3":
                    Console.Write("Введите адрес криптокошелька: ");
                    string wallet = Console.ReadLine();
                    context.SetPaymentStrategy(new CryptoPayment(wallet));
                    break;

                default:
                    Console.WriteLine("Неверный выбор способа оплаты");
                    return;
            }

            Console.WriteLine();
            context.ExecutePayment(amount);
            Console.WriteLine("\nОплата успешно выполнена");
        }
    }
}
