using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_7._2
{
    public abstract class Beverage
    {
        public string Name { get; protected set; }
        public RecipeOptions Options { get; set; } = new RecipeOptions();

        public void PrepareRecipe()
        {
            Console.WriteLine($"\n--- Приготовление: {Name} ---");
            try
            {
                BoilWater();
                Brew();
                PourInCup();

                if (!Options.SkipCondiments)
                {
                    AddCondiments();
                }
                else
                {
                    Console.WriteLine("Шаг 'Добавление добавок/сахара' пропущен по настройке.");
                }


                if (Options.ExtraCondiments.Count > 0)
                {
                    AddExtraCondiments();
                }

                Console.WriteLine($"--- {Name} готов! ---");
            }
            catch (IngredientUnavailableException ex)
            {

                Console.WriteLine($"Ошибка при приготовлении {Name}: {ex.Message}");
                Console.WriteLine("Приготовление прервано.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неожиданная ошибка при приготовлении {Name}: {ex.Message}");
            }
        }

        private void BoilWater()
        {
            Console.WriteLine("Кипячение воды...");
        }

        private void PourInCup()
        {
            Console.WriteLine("Наливание в чашку...");
        }
        protected abstract void Brew();
        protected abstract void AddCondiments();


        protected virtual void AddExtraCondiments()
        {
            foreach (var c in Options.ExtraCondiments)
            {

                IngredientInventory.Use(c);
                Console.WriteLine($"Добавлено дополнительное: {c}");
            }
        }
    }
    public class Tea : Beverage
    {
        public Tea()
        {
            Name = "Чай";
        }

        protected override void Brew()
        {
            Console.WriteLine("Заваривание чая...");
            IngredientInventory.Use("tea_leaves");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Добавление лимона...");
            IngredientInventory.Use("lemon");
        }
    }

    
    public class Coffee : Beverage
    {
        public Coffee()
        {
            Name = "Кофе";
        }

        protected override void Brew()
        {
            Console.WriteLine("Заваривание кофе (смалывание/варка)...");
            IngredientInventory.Use("coffee_beans");
        }

        protected override void AddCondiments()
        {
            if (Options.SugarUnits > 0)
            {
                Console.WriteLine($"Добавление сахара: {Options.SugarUnits} ед.");
                IngredientInventory.Use("sugar", Options.SugarUnits);
            }
            else
            {
                Console.WriteLine("Сахар не добавляется (настроено пользователем).");
            }

            if (!string.IsNullOrEmpty(Options.MilkType))
            {
                Console.WriteLine($"Добавление молока: {Options.MilkType}");
                IngredientInventory.Use(Options.MilkType);
            }
            else
            {
                Console.WriteLine("Молоко не добавляется.");
            }
        }
    }

    public class HotChocolate : Beverage
    {
        public HotChocolate()
        {
            Name = "Горячий шоколад";
        }

        protected override void Brew()
        {
            Console.WriteLine("Растворение какао-порошка в горячей воде/молоке...");
            IngredientInventory.Use("cocoa_powder");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Добавление молока (по умолчанию коровье)...");

            var milk = string.IsNullOrEmpty(Options.MilkType) ? "cow_milk" : Options.MilkType;
            IngredientInventory.Use(milk);

            if (Options.ExtraCondiments.Contains("marshmallows"))
            {
                Console.WriteLine("Добавление маршмеллоу...");
                IngredientInventory.Use("marshmallows");
            }
        }
    }
}
