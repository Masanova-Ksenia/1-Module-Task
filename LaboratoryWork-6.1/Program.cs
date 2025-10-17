using System;
using System.Globalization;

namespace LaboratoryWork_6._1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var context = new DeliveryContext();

            Console.WriteLine("Выберите тип доставки:");
            Console.WriteLine("1 - Стандартная");
            Console.WriteLine("2 - Экспресс");
            Console.WriteLine("3 - Международная");
            Console.WriteLine("4 - Ночная");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    context.SetShippingStrategy(new StandardShippingStrategy());
                    break;
                case "2":
                    context.SetShippingStrategy(new ExpressShippingStrategy());
                    break;
                case "3":
                    context.SetShippingStrategy(new InternationalShippingStrategy());
                    break;
                case "4":
                    context.SetShippingStrategy(new NightShippingStrategy());
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Выход.");
                    return;
            }

            if (!ReadDecimal("Введите вес посылки (кг): ", out decimal weight)) return;
            if (!ReadDecimal("Введите расстояние доставки (км): ", out decimal distance)) return;

            try
            {
                decimal cost = context.CalculateCost(weight, distance);
                Console.WriteLine($"Стоимость доставки: {cost}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при расчёте: {ex.Message}");
            }
        }

        static bool ReadDecimal(string prompt, out decimal value)
        {
            value = 0;
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (!decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out value))
            {
                Console.WriteLine("Некорректное число. Выход.");
                return false;
            }

            if (value < 0)
            {
                Console.WriteLine("Значение не может быть отрицательным. Выход.");
                return false;
            }

            return true;
        }
    }
}
