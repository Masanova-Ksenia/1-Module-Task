using System;

namespace PracticalWork_6._1
{
    class Program
    {
        static void Main()
        {
            var context = new TravelBookingContext();

            Console.WriteLine("Выберите тип транспорта: 1 - Самолёт, 2 - Поезд, 3 - Автобус");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": context.SetStrategy(new AirplaneCostStrategy()); break;
                case "2": context.SetStrategy(new TrainCostStrategy()); break;
                case "3": context.SetStrategy(new BusCostStrategy()); break;
                default:
                    Console.WriteLine("Неверный выбор транспорта");
                    return;
            }

            Console.Write("Введите расстояние (км): ");
            if (!double.TryParse(Console.ReadLine(), out double distance) || distance <= 0)
            {
                Console.WriteLine("Некорректное расстояние!");
                return;
            }

            Console.Write("Класс обслуживания (Эконом/Бизнес): ");
            string serviceClass = Console.ReadLine();

            Console.Write("Количество пассажиров: ");
            if (!int.TryParse(Console.ReadLine(), out int passengers) || passengers <= 0)
            {
                Console.WriteLine("Некорректное количество пассажиров!");
                return;
            }

            Console.Write("Есть скидка (да/нет): ");
            bool hasDiscount = Console.ReadLine()?.ToLower() == "да";

            Console.Write("Количество мест багажа: ");
            int luggageCount = int.TryParse(Console.ReadLine(), out int l) ? l : 0;

            Console.Write("Количество пересадок: ");
            int transfers = int.TryParse(Console.ReadLine(), out int t) ? t : 0;

            double cost = context.Calculate(distance, serviceClass, passengers, hasDiscount, luggageCount, transfers);

            Console.WriteLine($"\nИтоговая стоимость поездки: {cost:F2}");
        }
    }
}