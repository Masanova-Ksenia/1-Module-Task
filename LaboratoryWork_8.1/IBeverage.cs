using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_8._1
{
    public interface IBeverage
    {
        double GetCost();
        string GetDescription();
    }
    public class Coffee : IBeverage
    {
        public double GetCost()
        {
            return 50.0;
        }
        public string GetDescription()
        {
            return "Coffee";
        }
    }
    public class Cocoa : IBeverage
    {
        public double GetCost()
        {
            return 40.0;
        }
        public string GetDescription()
        {
            return "Cocoa";
        }
    }
    public class Tea : IBeverage
    {
        public double GetCost()
        {
            return 40.0;
        }

        public string GetDescription()
        {
            return "Tea";
        }
    }
}
