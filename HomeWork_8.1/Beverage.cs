using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8._1
{
    public abstract class Beverage
    {
        public abstract string GetDescription();
        public abstract double Cost();
    }
    public class Espresso : Beverage
    {
        public override string GetDescription() => "Espresso";
        public override double Cost() => 150;
    }

    public class Tea : Beverage
    {
        public override string GetDescription() => "Tea";
        public override double Cost() => 100;
    }

    public class Latte : Beverage
    {
        public override string GetDescription() => "Latte";
        public override double Cost() => 200;
    }

    public class Mocha : Beverage
    {
        public override string GetDescription() => "Mocha";
        public override double Cost() => 220;
    }
}
