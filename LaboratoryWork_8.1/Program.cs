using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_8._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            IBeverage coffee = new Coffee();
            Console.WriteLine($"{coffee.GetDescription()} : {coffee.GetCost()}");

            coffee = new MilkDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} : {coffee.GetCost()}");

            coffee = new CinnamonDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} : {coffee.GetCost()}");

            IBeverage tea = new Tea();
            Console.WriteLine($"{tea.GetDescription()} : {tea.GetCost()}");

            tea = new SugarDecorator(tea);
            Console.WriteLine($"{tea.GetDescription()} : {tea.GetCost()}");

            IBeverage cocoa = new Cocoa();
            Console.WriteLine($"{cocoa.GetDescription()} : {cocoa.GetCost()}");

            cocoa = new ChocolateDecorator(cocoa);
            Console.WriteLine($"{cocoa.GetDescription()} : {cocoa.GetCost()}");

            cocoa = new VanillaDecorator(cocoa);
            Console.WriteLine($"{cocoa.GetDescription()} : {cocoa.GetCost()}");

            
        }
    }
}