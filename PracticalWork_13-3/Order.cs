using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_13_3
{
    class Order
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Cart { get; set; } = new List<Product>();
        public double TotalAmount => Cart.Sum(p => p.Price);
        public bool IsPaid { get; set; } = false;
        public bool IsProcessed { get; set; } = false;
        public bool IsShipped { get; set; } = false;
        public void AddProduct(Product product)
        {
            Cart.Add(product);
            Console.WriteLine($"Товар {product.Name} добавлен в корзину.");
        }
        public void Pay(double amount)
        {
            if (amount >= TotalAmount)
            {
                IsPaid = true;
                Console.WriteLine("Оплата прошла успешно.");
            }
            else
            {
                Console.WriteLine("Недостаточно средств для оплаты.");
            }
        }
    }
}
