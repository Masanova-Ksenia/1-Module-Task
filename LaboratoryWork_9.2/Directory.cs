using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LaboratoryWork_9._2
{
    public class Directory : Component
    {
        private List<Component> _children = new List<Component>();
        public Directory(string name) : base(name) { }
        public override void Add(Component component)
        {
            _children.Add(component);
        }
        public override void Remove(Component component)
        {
            _children.Remove(component);
        }
        public override Component GetChild(int index)
        {
            return _children[index];
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " Directory: " + _name);
            foreach (var component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }
}
