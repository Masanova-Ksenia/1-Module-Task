using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LaboratoryWork_9._2
{
    public class File : Component
    {
        public File(string name) : base(name) { }
        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " File: " + _name);
        }
    }
}
