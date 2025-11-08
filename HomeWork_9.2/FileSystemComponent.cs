using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_9._2
{
    public abstract class FileSystemComponent
    {
        public string Name { get; protected set; }
        public FileSystemComponent(string name)
        {
            Name = name;
        }
        public abstract void Display(int indent = 0);
        public abstract int GetSize();
    }
}
