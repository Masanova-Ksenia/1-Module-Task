using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product();
            Product product2 = new Product();
            Product product3 = new Product();

            Order order = new Order();

            order.AddProduct(product1);
            order.AddProduct(product2);
            order.AddProduct(product3);

            Console.Write("Выберите способ доставки (1-Почта, 2-Курьер): ");
            int deliveryMethod = Convert.ToInt32(Console.ReadLine());

            IDelivery delivery = null;
            if (deliveryMethod == 1)
            {
                delivery = new PostDelivery();
            }
            else if (deliveryMethod == 2)
            {
                delivery = new CourierDelivery();
            }
            delivery.DeliverOrder(order);
        }
    }
}