using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_6._2
{
    public class Stock
    {
        public string Symbol { get; }
        public decimal Price { get; }

        public Stock(string symbol, decimal price)
        {
            Symbol = symbol;
            Price = price;
        }
    }
}
