using System;

namespace ДомашнееЗадание_4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Выберите транспорт (1-Авто, 2-Мото, 3-Грузовик, 4-Автобус): ");
            int choice = int.Parse(Console.ReadLine());

            VehicleFactory factory = null;

            switch (choice)
            {
                case 1:
                    Console.Write("Марка: ");
                    string brand = Console.ReadLine();
                    Console.Write("Модель: ");
                    string model = Console.ReadLine();
                    Console.Write("Тип топлива: ");
                    string fuel = Console.ReadLine();
                    factory = new CarFactory(brand, model, fuel);
                    break;

                case 2:
                    Console.Write("Тип мотоцикла (спортивный/туристический/эндуро/городской/классический): ");
                    string type = Console.ReadLine();
                    Console.Write("Объем двигателя: ");
                    int engine = int.Parse(Console.ReadLine());
                    factory = new MotorcycleFactory(type, engine);
                    break;

                case 3:
                    Console.Write("Грузоподъемность (тонн): ");
                    double capacity = double.Parse(Console.ReadLine());
                    Console.Write("Количество осей: ");
                    int axles = int.Parse(Console.ReadLine());
                    factory = new TruckFactory(capacity, axles);
                    break;

                case 4:
                    Console.Write("Количество мест: ");
                    int seats = int.Parse(Console.ReadLine());
                    Console.Write("Маршрут: ");
                    string route = Console.ReadLine();
                    factory = new BusFactory(seats, route);
                    break;
            }

            if (factory != null)
            {
                IVehicle vehicle = factory.CreateVehicle();
                vehicle.Drive();
                vehicle.Refuel();
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
            }
        }
    }
}