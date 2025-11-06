using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_9._2
{
    public abstract class Component
    {
        protected string _name;
        public Component(string name)
        {
            _name = name;
        }
        public abstract void Display(int depth);
        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }
        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }
        public virtual Component GetChild(int index)
        {
            throw new NotImplementedException();
        }
    }
}
