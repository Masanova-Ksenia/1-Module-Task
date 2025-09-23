using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрактическаяРабота_3
{
     public class Product
     {
         public int Id { get; set; }
         public String Name { get; set; }
         public double Price { get; set; }
         public override string ToString() => $"{Name} - {Price}";
    }
     public class Order
     {
        private List<Product> products;
        public IPayment PaymentMethod;
        public IDelivery DeliveryMethod;
        public DiscountCalculator DiscountCalculator;
        public Order()
        {
            products = new List<Product>();
            DiscountCalculator = new NoDiscount();
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public double GetTotalPrice()
        {
            double total = products.Sum(p => p.Price);
            return DiscountCalculator.Discount(total);
        }
        public void CompleteOrder()
        {
            Console.WriteLine("\nВаш заказ:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            double total = GetTotalPrice();
            Console.WriteLine($"Итого к оплате: {total}");

            PaymentMethod?.ProcessPayment(total);
            DeliveryMethod?.DeliverOrder(this);
        }
    }
     public class PriceCalculation
     {
        public double Calculate(List<Product> products)
        {
            return products.Sum(s => s.Price);
        }
     }
}