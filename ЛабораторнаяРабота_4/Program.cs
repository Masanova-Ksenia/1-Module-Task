using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип транспорта: 1 - Автомобиль, 2 - Мотоцикл, 3 - Самолет, 4 - Велосипед");
            string type = Console.ReadLine();

            Console.Write("Введите модель транспорта: ");
            string model = Console.ReadLine();

            Console.Write("Введите скорость транспорта: ");
            int speed = int.Parse(Console.ReadLine());

            TransportFactory factory = null;

            switch (type)
            {
                case "1":
                    factory = new CarFactory(); break;
                case "2":
                    factory = new MotorcycleFactory(); break;
                case "3":
                    factory = new PlaneFactory(); break;
                case "4":
                    factory = new BicycleFactory(); break;
                default:
                    Console.WriteLine("Неизвестный тип транспорта");
                    return;
            }

            ITransport transport = factory.CreateTransport(model, speed);
            transport.Move();
            transport.FuelUp();            
        }
    }
}