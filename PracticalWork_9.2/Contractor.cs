using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticalWork_9._2
{
    class Contractor : Employee
    {
        public Contractor(string name, string position, double fixedPay)
            : base(name, position, fixedPay) { }
        public override double GetBudget()
        {
            return 0;
        }
        public override void Display(int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + $"{Name} ({Position}, контрактор) — Оплата: {base.Salary}");
        }
    }
}
