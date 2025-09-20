using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_1
{
    public class Manager : Employee
    {
        public decimal FixedSalary { get; }
        public decimal Bonus { get; }
        public Manager(string name, int id, decimal fixedSalary, decimal bonus)
            : base(name, id, "Менеджер")
        {
            FixedSalary = fixedSalary;
            Bonus = bonus;
        }
        public override decimal CalculateSalary()
        {
            return FixedSalary + Bonus;
        }
        public override string ToString()
        {
            return base.ToString() + $" | Оклад: {FixedSalary} | Премия: {Bonus}";
        }
    }
}