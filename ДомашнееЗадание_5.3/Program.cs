using System;
using System.Collections.Generic;

namespace ДомашнееЗадание_5._3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var order1 = new Order
            {
                DeliveryCost = 500,
                PaymentMethod = "Карта"
            };
            order1.Products.Add(new Product("Ноутбук", 300000, 1));
            order1.Products.Add(new Product("Мышь", 5000, 2));
            order1.Discounts.Add(new Discount("Скидка постоянного клиента", 10000));

            Console.WriteLine("Оригинальный заказ:");
            Console.WriteLine(order1);

            var order2 = order1.Clone();
            order2.Products[0].Quantity = 2;
            order2.PaymentMethod = "Наличные";

            Console.WriteLine("\nКлон заказа:");
            Console.WriteLine(order2);

            Console.WriteLine("\nПроверка, что оригинал не изменился:");
            Console.WriteLine(order1);
        }
    }
}