using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_6._1
{
    public interface IShippingStrategy
    {
        decimal CalculateShippingCost(decimal weight, decimal distance);
    }
    public class StandardShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            return weight * 0.5m + distance * 0.1m;
        }
    }
    public class ExpressShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            return (weight * 0.75m + distance * 0.2m) + 10m;
        }
    }
    public class InternationalShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            return weight * 1.0m + distance * 0.5m + 15m;
        }
    }
    public class NightShippingStrategy : IShippingStrategy
    {
        private readonly decimal _nightSurcharge;

        public NightShippingStrategy(decimal nightSurcharge = 7.5m)
        {
            _nightSurcharge = nightSurcharge;
        }

        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            decimal baseCost = weight * 0.6m + distance * 0.15m;
            return baseCost + _nightSurcharge;
        }
    }
}
