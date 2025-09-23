using System;
using System.Collections.Generic;

namespace ДомашнееЗадание_3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("SRP");
            var order = new Order { ProductName = "Laptop", Quantity = 2, Price = 1000 };
            var calculator = new OrderCalculator();
            var payment = new PaymentProcessor();
            var notification = new NotificationService();

            Console.WriteLine($"Total price: {calculator.CalculateTotalPrice(order)}");
            payment.ProcessPayment("Credit Card");
            notification.SendConfirmationEmail("user@example.com");

            Console.WriteLine("\nOCP");
            List<Employee> employees = new List<Employee>
            {
                new PermanentEmployee { Name = "Alice", BaseSalary = 1000 },
                new ContractEmployee { Name = "Bob", BaseSalary = 800 },
                new Intern { Name = "Charlie", BaseSalary = 500 },
                new Freelancer { Name = "Diana", BaseSalary = 1200 }
            };

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.Name} salary: {emp.CalculateSalary()}");
            }

            Console.WriteLine("\nISP");
            IPrinter basic = new BasicPrinter();
            basic.Print("Basic document");

            AllInOnePrinter aio = new AllInOnePrinter();
            aio.Print("Full doc");
            aio.Scan("Full doc");
            aio.Fax("Full doc");

            Console.WriteLine("\nDIP");
            var senders = new List<IMessageSender> { new EmailSender(), new SmsSender(), new MessengerSender() };
            var manager = new NotificationManager(senders);
            manager.SendNotification("Hello from DIP demo!");
        }
    }
}