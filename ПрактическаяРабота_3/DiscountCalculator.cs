using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрактическаяРабота_3
{
    public interface DiscountCalculator
    {
        double Discount(double total);
    }
    public class NoDiscount : DiscountCalculator
    {
        public double Discount(double total) => total;
    }
    public class PercentageDiscount : DiscountCalculator
    {
        private readonly double _percentage;
        public PercentageDiscount(double percentage) => _percentage = percentage;

        public double Discount(double total) => total * (1 - _percentage);
    }

    public class FixedAmountDiscount : DiscountCalculator
    {
        private readonly double _amount;
        public FixedAmountDiscount(double amount) => _amount = amount;

        public double Discount(double total) =>
            total > _amount ? total - _amount : 0;
    }
}