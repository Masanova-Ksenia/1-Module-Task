using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     public class Product
     {
         public int Id { get; set; }
         public String Name { get; set; }
         public double Price { get; set; }
     }
     public class Order
     {
        private List<Product> products;
        public Order()
        {
            products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
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
