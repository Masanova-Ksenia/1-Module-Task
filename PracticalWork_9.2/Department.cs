using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticalWork_9._2
{
    class Department : OrganisationComponent
    {
        private List<OrganisationComponent> _components = new List<OrganisationComponent>();
        public Department(string name) : base(name) { }
        public override void Add(OrganisationComponent component)
        {
            _components.Add(component);
        }
        public override void Remove(OrganisationComponent component)
        {
            _components.Remove(component);
        }
        public override void Display(int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + $"Отдел: {Name}");
            foreach (var c in _components)
            {
                c.Display(indent + 4);
            }
        }
        public override double GetBudget()
        {
            return _components.Sum(c => c.GetBudget());
        }
        public override int GetEmployeeCount()
        {
            return _components.Sum(c => c.GetEmployeeCount());
        }
        public override OrganisationComponent FindEmployee(string name)
        {
            foreach (var c in _components)
            {
                var found = c.FindEmployee(name);
                if (found != null)
                    return found;
            }
            return null;
        }
        public override List<Employee> GetAllEmployees()
        {
            return _components.SelectMany(c => c.GetAllEmployees()).ToList();
        }
    }
}
