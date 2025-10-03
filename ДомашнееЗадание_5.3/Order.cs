using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДомашнееЗадание_5._3
{
    public interface IDeepCloneable<T>
    {
        T Clone();
    }
    public class Order : IDeepCloneable<Order>
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Discount> Discounts { get; set; } = new List<Discount>();
        public decimal DeliveryCost { get; set; }
        public string PaymentMethod { get; set; }
        public Order Clone()
        {
            var newOrder = new Order
            {
                DeliveryCost = this.DeliveryCost,
                PaymentMethod = this.PaymentMethod
            };
            foreach (var product in Products)
                newOrder.Products.Add(product.Clone());

            foreach (var discount in Discounts)
                newOrder.Discounts.Add(discount.Clone());

            return newOrder;
        }
        public override string ToString()
        {
            string productsInfo = string.Join(", ", Products);
            string discountsInfo = Discounts.Count > 0 ? string.Join("; ", Discounts) : "нет скидок";
            return $"Заказ:\nТовары: {productsInfo}\nДоставка: {DeliveryCost}\nСкидки: {discountsInfo}\nОплата: {PaymentMethod}";
        }
    }
    public class Product : IDeepCloneable<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public Product Clone()
        {
            return new Product(Name, Price, Quantity);
        }
        public override string ToString()
        {
            return $"{Name} (Цена: {Price}, Кол-во: {Quantity})";
        }
    }
    public class Discount : IDeepCloneable<Discount>
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public Discount(string description, decimal amount)
        {
            Description = description;
            Amount = amount;
        }
        public Discount Clone()
        {
            return new Discount(Description, Amount);
        }
        public override string ToString()
        {
            return $"{Description}: -{Amount}";
        }
    }
}
