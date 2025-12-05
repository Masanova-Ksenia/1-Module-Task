using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_13_3
{
    class Program
    {
        static void Main()
        {
            var products = new List<Product>
        {
            new Product { ID = 1, Name = "Книга", Price = 2000 },
            new Product { ID = 2, Name = "Наушники", Price = 25000 },
            new Product { ID = 3, Name = "Чехол для телефона", Price = 2500 }
        };
            var customer = new Customer { ID = 1, Name = "Иван", Address = "ул. Иванова, д. 10" };
            var order = new Order { ID = 1, Customer = customer };
            var processor = new OrderProcessor();
            order.AddProduct(products[0]);
            order.AddProduct(products[2]);
            Console.WriteLine($"Сумма к оплате: {order.TotalAmount}");
            order.Pay(5000);
            if (order.IsPaid)
            {
                processor.Process(order);
                processor.Ship(order);
            }
            Console.WriteLine("\nСостояние заказа:");
            Console.WriteLine($"Оплачен: {order.IsPaid}");
            Console.WriteLine($"Обработан: {order.IsProcessed}");
            Console.WriteLine($"Отправлен: {order.IsShipped}");
        }
    }
}