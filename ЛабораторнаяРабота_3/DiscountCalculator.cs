using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_3
{
    public interface IDiscountType
    {
        double ApplyDiscount(double amount);
    }
    public class RegularDiscount : IDiscountType
    {
        public double ApplyDiscount(double amount) => amount;
    }
    public class SilverDiscount : IDiscountType
    {
        public double ApplyDiscount(double amount) => amount * 0.9;
    }

    public class GoldDiscount : IDiscountType
    {
        public double ApplyDiscount(double amount) => amount * 0.8;
    }
    public class PlatinumDiscount : IDiscountType
    {
        public double ApplyDiscount(double amount) => amount * 0.7;
    }

    public class DiscountCalculator
    {
        private readonly IDiscountType _type;

        public DiscountCalculator(IDiscountType type)
        {
            _type = type;
        }

        public double Calculate(double amount) => _type.ApplyDiscount(amount);
    }
}
