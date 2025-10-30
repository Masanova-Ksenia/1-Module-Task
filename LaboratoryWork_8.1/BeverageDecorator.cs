using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_8._1
{
    public abstract class BeverageDecorator : IBeverage
    {
        protected IBeverage _beverage;
        public BeverageDecorator (IBeverage beverage)
        {
            _beverage = beverage;
        }
        public virtual double GetCost()
        {
            return _beverage.GetCost();
        }
        public virtual string GetDescription()
        {
            return _beverage.GetDescription();
        }
    }
    public class MilkDecorator : BeverageDecorator
    {
        public MilkDecorator(IBeverage beverage) : base(beverage) { }
        public override double GetCost()
        {
            return base.GetCost() + 15.0;
        }
        public override string GetDescription()
        {
            return base.GetDescription() + ", Milk";
        }
    }
    public class SugarDecorator : BeverageDecorator
    {
        public SugarDecorator(IBeverage beverage) : base(beverage) { }
        public override double GetCost()
        {
            return base.GetCost() + 10.0;
        }
        public override string GetDescription()
        {
            return base.GetDescription() + ", Sugar";
        }
    }
    public class ChocolateDecorator : BeverageDecorator
    {
        public ChocolateDecorator(IBeverage beverage) : base(beverage) { }
        public override double GetCost()
        {
            return base.GetCost() + 30.0;
        }
        public override string GetDescription()
        {
            return base.GetDescription() + ", Chocolate";
        }
    }
    public class VanillaDecorator : BeverageDecorator
    {
        public VanillaDecorator(IBeverage beverage) : base(beverage) { }
        public override double GetCost()
        {
            return base.GetCost() + 12.0;
        }
        public override string GetDescription()
        {
            return base.GetDescription() + ", Vanilla";
        }
    }
    public class CinnamonDecorator : BeverageDecorator
    {
        public CinnamonDecorator(IBeverage beverage) : base(beverage) { }
        public override double GetCost()
        {
            return base.GetCost() + 10.0;
        }
        public override string GetDescription()
        {
            return base.GetDescription() + ", Cinnamon";
        }
    }
}
