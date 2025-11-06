using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LaboratoryWork_9._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory root = new Directory("Root");
            File file1 = new File("File1.txt");
            File file2 = new File("File2.txt");

            Directory subDir = new Directory("SubDirectory");
            File subFile1 = new File("SubFile1.txt");

            root.Add(file1);
            root.Add(file2);
            subDir.Add(subFile1);
            root.Add(subDir);

            root.Display(1);
        }
    }
}