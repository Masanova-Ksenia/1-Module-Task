using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeWork_9._2
{
    public class File : FileSystemComponent
    {
        private int size;
        public File(string name, int size) : base(name)
        {
            this.size = size;
        }
        public override void Display(int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + $"- Файл: {Name} ({size} KB)");
        }
        public override int GetSize()
        {
            return size;
        }
    }
}
