using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_9._2
{
    class Program
    {
        static void Main(string[] args)
        {
            File file1 = new File("Документ1.txt", 50);
            File file2 = new File("Фото1.jpg", 150);
            File file3 = new File("Музыка.mp3", 500);
            File file4 = new File("Документ2.txt", 75);
            Directory root = new Directory("Корневая папка");
            Directory folder1 = new Directory("Папка 1");
            Directory folder2 = new Directory("Папка 2");

            folder1.Add(file1);
            folder1.Add(file2);

            folder2.Add(file3);

            root.Add(folder1);
            root.Add(folder2);
            root.Add(file4);

            Console.WriteLine("\nСтруктура файловой системы");
            root.Display();

            Console.WriteLine($"\nОбщий размер '{root.Name}': {root.GetSize()} KB");

            folder1.Add(file1);

            folder2.Remove(file3);
            folder2.Remove(file3);

            Console.WriteLine("\nСтруктура после удаления");
            root.Display();

            Console.WriteLine($"\nОбщий размер '{root.Name}' после удаления: {root.GetSize()} KB");
        }
    }
}