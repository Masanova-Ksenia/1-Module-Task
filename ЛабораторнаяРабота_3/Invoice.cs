using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_3
{
    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class Invoice
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public double TaxRate { get; set; }
        
    }
    public class InvoiceCalculator
    {
        public double CalculateTotal(Invoice invoice)
        {
            double subTotal = invoice.Items.Sum(i => i.Price);
            return subTotal + (subTotal * invoice.TaxRate);
        }
    }
    public class InvoiceRepository
    {
        public void SaveToDatabase(Invoice invoice)
        {
            Console.WriteLine($"Счёт №{invoice.Id} сохранён в базе данных.");
        }
    }
}
