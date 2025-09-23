using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ПрактическаяРабота_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product{Id = 1, Name = "Телефон", Price = 60000 };
            Product product2 = new Product{ Id = 2, Name = "Чехол", Price = 2000};
            Product product3 = new Product{ Id = 3, Name = "Наушники", Price = 15000};

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

            Console.Write("Выберите способ оплаты (1-Карта, 2-PayPal, 3-Банк): ");
            int paymentMethod = Convert.ToInt32(Console.ReadLine());

            if (paymentMethod == 1)
                order.PaymentMethod = new CreditCard();
            else if (paymentMethod == 2)
                order.PaymentMethod = new PaypPal();
            else
                order.PaymentMethod = new BankTransferPayment();

            Console.Write("Действующая скидка 10% на весь ассортимент активирована");
            order.DiscountCalculator = new PercentageDiscount(0.1);

            order.CompleteOrder();

        }
    }
}