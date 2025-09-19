using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public enum CustomerType
    {
        Regular,
        Silver,
        Gold
    }
    internal class DiscountCalculator
    {
        public double CalculateDiscount(CustomerType customerType, double amount)
        {
            if (customerType == CustomerType.Regular)
            {
                return amount;
            }
            else if (customerType == CustomerType.Silver)
            {
                return amount * 0.9; // 10% скидка
            }
            else if (customerType == CustomerType.Gold)
            {
                return amount * 0.8; // 20% скидка
            }
            else
            {
                throw new ArgumentException("Неизвестный тип клиента");
            }
        }
    }
}
