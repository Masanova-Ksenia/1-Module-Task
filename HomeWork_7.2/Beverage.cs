using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7._2
{
    public abstract class Beverage
    {
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if (CustomerWantsCondiments())
                AddCondiments();
        }

        protected abstract void Brew();
        protected abstract void AddCondiments();

        private void BoilWater() => Console.WriteLine("Кипятим воду");
        private void PourInCup() => Console.WriteLine("Наливаем в чашку");

        protected virtual bool CustomerWantsCondiments()
        {
            Console.Write("Добавить добавки (y/n)? ");
            string input = Console.ReadLine()?.Trim().ToLower();
            while (input != "y" && input != "n")
            {
                Console.Write("Некорректный ввод. Введите 'y' или 'n': ");
                input = Console.ReadLine()?.Trim().ToLower();
            }
            return input == "y";
        }
    }
    public class Tea : Beverage
    {
        protected override void Brew() => Console.WriteLine("Завариваем чай");
        protected override void AddCondiments() => Console.WriteLine("Добавляем лимон");
    }
    public class Coffee : Beverage
    {
        protected override void Brew() => Console.WriteLine("Завариваем кофе");
        protected override void AddCondiments() => Console.WriteLine("Добавляем молоко и сахар");
    }
    public class HotChocolate : Beverage
    {
        protected override void Brew() => Console.WriteLine("Растапливаем шоколад и смешиваем с молоком");
        protected override void AddCondiments() => Console.WriteLine("Добавляем маршмеллоу");
    }

}
