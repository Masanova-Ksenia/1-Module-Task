using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticalWork_9._2
{
    class Employee : OrganisationComponent
    {
        public string Position { get; private set; }
        public double Salary { get; private set; }
        public Employee(string name, string position, double salary)
            : base(name)
        {
            Position = position;
            Salary = salary;
        }
        public void SetSalary(double newSalary)
        {
            Salary = newSalary;
        }
        public override void Display(int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + $"{Name} ({Position}) — Зарплата: {Salary}");
        }
        public override double GetBudget()
        {
            return Salary;
        }
        public override int GetEmployeeCount()
        {
            return 1;
        }
        public override OrganisationComponent FindEmployee(string name)
        {
            return Name.Equals(name, StringComparison.OrdinalIgnoreCase) ? this : null;
        }
        public override List<Employee> GetAllEmployees()
        {
            return new List<Employee> { this };
        }
    }
}
