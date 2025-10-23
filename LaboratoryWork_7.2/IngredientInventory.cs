using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_7._2
{
    public static class IngredientInventory
    {
       
        private static Dictionary<string, int> _stock = new Dictionary<string, int>()
        {
            { "tea_leaves", 10 },
            { "lemon", 2 },
            { "coffee_beans", 10 },
            { "sugar", 5 },
            { "cow_milk", 1 },
            { "soy_milk", 2 },
            { "oat_milk", 0 }, 
            { "cocoa_powder", 3 },
            { "marshmallows", 0 } 
        };

        
        public static void Use(string ingredient, int ingredientCount = 1)
        {
            if (!_stock.ContainsKey(ingredient) || _stock[ingredient] < ingredientCount)
                throw new IngredientUnavailableException($"Ингредиент '{ingredient}' отсутствует или недостаточно на складе.");
            _stock[ingredient] -= ingredientCount;
        }

        public static void AddStock(string ingredient, int count)
        {
            if (!_stock.ContainsKey(ingredient)) _stock[ingredient] = 0;
            _stock[ingredient] += count;
        }

        public static void ShowStock()
        {
            Console.WriteLine("--- Текущее состояние инвентаря ---");
            foreach (var kv in _stock)
                Console.WriteLine($"{kv.Key}: {kv.Value}");
            Console.WriteLine("------------------------------------");
        }
    }
    public class IngredientUnavailableException : Exception
    {
        public IngredientUnavailableException(string message) : base(message) { }
    }
}
