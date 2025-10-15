using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_6._1
{
    public interface ICostCalculationStrategy
    {
        double CalculateCost(double distance, string serviceClass, int passengers, bool hasDiscount, int luggageCount, int transfers);
    }
    public class AirplaneCostStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(double distance, string serviceClass, int passengers, bool hasDiscount, int luggageCount, int transfers)
        {
            double baseRate = 10.0;
            double classMultiplier = serviceClass == "Бизнес" ? 2.0 : 1.0;
            double cost = distance * baseRate * classMultiplier * passengers;

            cost += luggageCount * 500;
            cost += transfers * 0.05 * cost;

            if (hasDiscount) cost *= 0.9;
            if (passengers > 5) cost *= 0.9;

            return cost;
        }
    }

    public class TrainCostStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(double distance, string serviceClass, int passengers, bool hasDiscount, int luggageCount, int transfers)
        {
            double baseRate = 5.0;
            double classMultiplier = serviceClass == "Бизнес" ? 1.5 : 1.0;
            double cost = distance * baseRate * classMultiplier * passengers;

            cost += luggageCount * 200;
            cost += transfers * 0.03 * cost;

            if (hasDiscount) cost *= 0.85;
            if (passengers > 5) cost *= 0.9;

            return cost;
        }
    }

    public class BusCostStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(double distance, string serviceClass, int passengers, bool hasDiscount, int luggageCount, int transfers)
        {
            double baseRate = 3.0;
            double classMultiplier = serviceClass == "Бизнес" ? 1.2 : 1.0;
            double cost = distance * baseRate * classMultiplier * passengers;

            cost += luggageCount * 100;
            cost += transfers * 0.02 * cost;

            if (hasDiscount) cost *= 0.8;
            if (passengers > 5) cost *= 0.9;

            return cost;
        }
    }
}
