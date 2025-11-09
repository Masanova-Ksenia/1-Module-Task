using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_9._2
{
    abstract class OrganisationComponent
    {
        public string Name { get; protected set; }
        public OrganisationComponent(string name)
        {
            Name = name;
        }
        public abstract void Display(int indent = 0);
        public abstract double GetBudget();
        public abstract int GetEmployeeCount();
        public virtual void Add(OrganisationComponent component)
        {
            throw new NotImplementedException("Невозможно добавить элемент к этому компоненту.");
        }
        public virtual void Remove(OrganisationComponent component)
        {
            throw new NotImplementedException("Невозможно удалить элемент из этого компонента.");
        }
        public virtual OrganisationComponent FindEmployee(string name)
        {
            return null;
        }
        public virtual List<Employee> GetAllEmployees()
        {
            return new List<Employee>();
        }
    }
}
