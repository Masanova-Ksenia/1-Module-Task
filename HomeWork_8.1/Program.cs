using System;
using System.Collections.Generic;
using System.Drawing;

namespace HomeWork_8._1
{
    class Program
    {
        static void Main()
        {
            //1
            Beverage espresso = new Espresso();
            Console.WriteLine($"{espresso.GetDescription()} : {espresso.Cost()}");

            espresso = new Syrup(espresso, "caramel");
            Console.WriteLine($"{espresso.GetDescription()} : {espresso.Cost()}");

            //2
            Beverage tea = new Tea();
            Console.WriteLine($"{tea.GetDescription()} : {tea.Cost()}");

            tea = new Milk(tea);
            Console.WriteLine($"{tea.GetDescription()} : {tea.Cost()}");

            tea = new Sugar(tea);
            Console.WriteLine($"{tea.GetDescription()} : {tea.Cost()}");

            //3
            Beverage latte = new Latte();
            Console.WriteLine($"{latte.GetDescription()} : {latte.Cost()}");

            latte = new WhippedCream(latte);
            Console.WriteLine($"{latte.GetDescription()} : {latte.Cost()}");

            //4
            Beverage mocha = new Mocha();
            Console.WriteLine($"{mocha.GetDescription()} : {mocha.Cost()}");

            mocha = new Ice(mocha);
            Console.WriteLine($"{mocha.GetDescription()} : {mocha.Cost()}");
        }
    }
}
