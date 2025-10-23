using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7._2
{
    public class Program
    {
        public static void Main()
        {
            Beverage tea = new Tea();
            Beverage coffee = new Coffee();
            Beverage chocolate = new HotChocolate();

            Console.WriteLine("\nПриготовление чая:");
            tea.PrepareRecipe();

            Console.WriteLine("\nПриготовление кофе:");
            coffee.PrepareRecipe();

            Console.WriteLine("\nПриготовление горячего шоколада:");
            chocolate.PrepareRecipe();
        }
    }
}