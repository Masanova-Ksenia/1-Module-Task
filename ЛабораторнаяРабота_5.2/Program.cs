using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_5._2
{
    public class Program
    {
        static void Main(string[] args)
        {
            IComputerBuilder officeBuilder = new OfficeComputerBuilder();
            ComputerDirector director = new ComputerDirector(officeBuilder);
            director.ConstructComputer();
            Computer officeComputer = director.GetComputer();
            Console.WriteLine(officeComputer);

            IComputerBuilder gamingBuilder = new GamingComputerBuilder();
            director = new ComputerDirector(gamingBuilder);
            director.ConstructComputer();
            Computer gamingComputer = director.GetComputer();
            Console.WriteLine(gamingComputer);

            IComputerBuilder graphicBuilder = new GraphicWorkstationBuilder();
            director = new ComputerDirector(graphicBuilder);
            director.ConstructComputer();
            Computer graphicComputer = director.GetComputer();
            Console.WriteLine(graphicComputer);
        }
    }
}
