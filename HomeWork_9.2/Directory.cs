using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeWork_9._2
{
    public class Directory : FileSystemComponent
    {
        private List<FileSystemComponent> components = new List<FileSystemComponent>();
        public Directory(string name) : base(name) { }
        public void Add(FileSystemComponent component)
        {
            if (!components.Contains(component))
            {
                components.Add(component);
                Console.WriteLine($"Компонент '{component.Name}' добавлен в '{Name}'");
            }
            else
            {
                Console.WriteLine($"Компонент '{component.Name}' уже существует в '{Name}'");
            }
        }
        public void Remove(FileSystemComponent component)
        {
            if (components.Contains(component))
            {
                components.Remove(component);
                Console.WriteLine($"Компонент '{component.Name}' удален из '{Name}'");
            }
            else
            {
                Console.WriteLine($"Компонент '{component.Name}' не найден в '{Name}'");
            }
        }
        public override void Display(int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + $"+ Папка: {Name}");
            foreach (var component in components)
            {
                component.Display(indent + 2);
            }
        }
        public override int GetSize()
        {
            int totalSize = 0;
            foreach (var component in components)
            {
                totalSize += component.GetSize();
            }
            return totalSize;

        }
    }
}
