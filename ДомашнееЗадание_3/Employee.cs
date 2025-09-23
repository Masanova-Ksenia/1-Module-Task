using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДомашнееЗадание_3
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }
        public abstract double CalculateSalary();
    }
    public class PermanentEmployee : Employee
    {
        public override double CalculateSalary() => BaseSalary * 1.2;
    }
    public class ContractEmployee : Employee
    {
        public override double CalculateSalary() => BaseSalary * 1.1;
    }
    public class Intern : Employee
    {
        public override double CalculateSalary() => BaseSalary * 0.8;
    }
    public class Freelancer : Employee
    {
        public override double CalculateSalary() => BaseSalary * 1.5;
    }
}