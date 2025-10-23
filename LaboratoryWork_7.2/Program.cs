using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_7._2
{
    class Program
    {
        static void Main(string[] args)
        {
            IngredientInventory.ShowStock();

            Beverage tea = new Tea();
            tea.PrepareRecipe();

            
            Beverage coffeeNoSugar = new Coffee();
            coffeeNoSugar.Options.SugarUnits = 0;
            coffeeNoSugar.Options.MilkType = "cow_milk";
            Console.WriteLine();
            Console.WriteLine("Приготовление кофе без сахара (тест пропуска шага)");
            coffeeNoSugar.PrepareRecipe();

            
            Beverage coffeeOat = new Coffee();
            coffeeOat.Options.SugarUnits = 1;
            coffeeOat.Options.MilkType = "oat_milk"; 
            Console.WriteLine();
            Console.WriteLine("Приготовление кофе с овсяным молоком (тест ошибки отсутствия ингредиента)");
            coffeeOat.PrepareRecipe();

            HotChocolate hotChoc = new HotChocolate();
            hotChoc.Options.MilkType = "soy_milk";
            hotChoc.Options.ExtraCondiments.Add("marshmallows"); 
            Console.WriteLine();
            Console.WriteLine("Приготовление горячего шоколада с маршмеллоу (тест ошибки на шаге добавок)");
            hotChoc.PrepareRecipe();

            Console.WriteLine("\nПополняем инвентарь: добавляем marshmallows и oat_milk...");
            IngredientInventory.AddStock("marshmallows", 5);
            IngredientInventory.AddStock("oat_milk", 2);
            IngredientInventory.ShowStock();

            Console.WriteLine("Повторное приготовление кофе с овсяным молоком:");
            coffeeOat.PrepareRecipe();

            Console.WriteLine("Повторное приготовление горячего шоколада с маршмеллоу:");
            hotChoc.PrepareRecipe();
        }
    }
}
