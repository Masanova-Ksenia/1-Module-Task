using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрактическаяРабота_5._3
{
    class Program
    {
        static void Main()
        {
            Character mage = new Character
            {
                Name = "Маг Арктур",
                Health = 80,
                Strength = 10,
                Agility = 15,
                Intelligence = 30,
                Weapon = new Weapon("Посох огня", 25),
                Armor = new Armor("Мантия мудреца", 10),
                Skills = new List<Skill>
            {
                new Skill("Огненный шар", "Магия", 40),
                new Skill("Щит маны", "Магия", 20)
            }
            };
            Character cloneMage = mage.Clone();
            cloneMage.Name = "Маг Клон";
            cloneMage.Weapon.Name = "Посох льда";
            cloneMage.Skills[0].Name = "Ледяная стрела";

            Console.WriteLine("=== Оригинал ===");
            Console.WriteLine(mage);

            Console.WriteLine("=== Клон ===");
            Console.WriteLine(cloneMage);
        }
    }
}
