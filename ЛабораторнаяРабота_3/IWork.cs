using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_3
{
    public interface IWork
    {
        void Work();
    }
    public interface IEat
    {
        void Eat();
    }
    public interface ISleep
    {
        void Sleep();
    }
    public class HumanWorker : IWork, IEat, ISleep
    {
        public void Work() => Console.WriteLine("Человек работает");
        public void Eat() => Console.WriteLine("Человек ест");
        public void Sleep() => Console.WriteLine("Человек спит");
    }
    public class RobotWorker : IWork
    {
        public void Work() => Console.WriteLine("Робот работает");
    }
}
