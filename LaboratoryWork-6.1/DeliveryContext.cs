using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_6._1
{
    public class DeliveryContext
    {
        private IShippingStrategy _shippingStrategy;

        public void SetShippingStrategy(IShippingStrategy strategy)
        {
            _shippingStrategy = strategy;
        }

        public decimal CalculateCost(decimal weight, decimal distance)
        {
            if (_shippingStrategy == null)
                throw new InvalidOperationException("Стратегия доставки не установлена.");

            return _shippingStrategy.CalculateShippingCost(weight, distance);
        }
    }
}
