using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._1
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Product { get; set; }
        public decimal Amount { get; set; }
        public string Customer { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}, Дата: {Date:dd.MM.yyyy}, Товар: {Product}, " +
                   $"Сумма: {Amount}, Клиент: {Customer}";
        }
    }
}
