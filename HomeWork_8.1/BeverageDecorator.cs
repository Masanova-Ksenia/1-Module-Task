using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8._1
{
    public abstract class BeverageDecorator : Beverage
    {
        protected Beverage _beverage;

        public BeverageDecorator(Beverage beverage)
        {
            this._beverage = beverage;
        }

        public override string GetDescription() => _beverage.GetDescription();
        public override double Cost() => _beverage.Cost();
    }
    public class Milk : BeverageDecorator
    {
        public Milk(Beverage beverage) : base(beverage) { }

        public override string GetDescription() => base.GetDescription() + ", Milk";
        public override double Cost() => base.Cost() + 30;
    }

    public class Sugar : BeverageDecorator
    {
        public Sugar(Beverage beverage) : base(beverage) { }

        public override string GetDescription() => base.GetDescription() + ", Sugar";
        public override double Cost() => base.Cost() + 10;
    }

    public class WhippedCream : BeverageDecorator
    {
        public WhippedCream(Beverage beverage) : base(beverage) { }

        public override string GetDescription() => base.GetDescription() + ", Whipped Cream";
        public override double Cost() => base.Cost() + 50;
    }

    public class Syrup : BeverageDecorator
    {
        private string flavor;
        public Syrup(Beverage beverage, string flavor) : base(beverage)
        {
            this.flavor = flavor;
        }

        public override string GetDescription() => base.GetDescription() + $", Syrup {flavor}";
        public override double Cost() => base.Cost() + 40;
    }

    public class Ice : BeverageDecorator
    {
        public Ice(Beverage beverage) : base(beverage) { }

        public override string GetDescription() => base.GetDescription() + ", Ice";
        public override double Cost() => base.Cost() + 15;
    }
}
