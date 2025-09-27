using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_4
{
    public interface ITransport
    {
        string Model { get; set; }
        int Speed { get; set; }
        void Move();
        void FuelUp();
    }
    public class Car : ITransport
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public void Move()
        {
            Console.WriteLine($"Автомобиль {Model} едет со скоростью {Speed} км/ч.");
        }
        public void FuelUp()
        {
            Console.WriteLine($"Автомобиль {Model} заправляется бензином.");
        }
    }
    public class Motorcycle : ITransport
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public void Move()
        {
            Console.WriteLine($"Мотоцикл {Model} едет со скоростью {Speed} км/ч.");
        }
        public void FuelUp()
        {
            Console.WriteLine($"Мотоцикл {Model} заправляется бензином.");
        }
    }
    public class Plane : ITransport
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public void Move()
        {
            Console.WriteLine($"Самолет {Model} летит со скоростью {Speed} км/ч.");
        }
        public void FuelUp()
        {
            Console.WriteLine($"Самолет {Model} заправляется авиационным топливом.");
        }
    }
    public class Bicycle : ITransport
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public void Move()
        {
            Console.WriteLine($"Велосипед {Model} движется со скоростью {Speed} км/ч.");
        }
        public void FuelUp()
        {
            Console.WriteLine($"Велосипед {Model} не требует топлива — заправка не нужна.");
        }
    }        
}