using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_6._1
{
    public class TravelBookingContext
    {
        private ICostCalculationStrategy _strategy;

        public void SetStrategy(ICostCalculationStrategy strategy)
        {
            _strategy = strategy;
        }

        public double Calculate(double distance, string serviceClass, int passengers, bool hasDiscount, int luggageCount, int transfers)
        {
            if (_strategy == null)
                throw new InvalidOperationException("Стратегия не выбрана");

            return _strategy.CalculateCost(distance, serviceClass, passengers, hasDiscount, luggageCount, transfers);
        }
    }
}
