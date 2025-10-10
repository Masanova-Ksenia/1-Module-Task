using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрактическаяРабота_5._3
{
    public interface IPrototype<T>
    {
        T Clone();
    }
    public class Weapon : IPrototype<Weapon>
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
        public Weapon Clone()
        {
            return new Weapon(Name, Damage);
        }

        public override string ToString()
        {
            return $"{Name} (урон: {Damage})";
        }
    }
    public class Armor : IPrototype<Armor>
    {
        public string Name { get; set; }
        public int Defense { get; set; }
        public Armor(string name, int defense)
        {
            Name = name;
            Defense = defense;
        }
        public Armor Clone()
        {
            return new Armor(Name, Defense);
        }
        public override string ToString()
        {
            return $"{Name} (защита: {Defense})";
        }
    }
    public class Skill : IPrototype<Skill>
    {
        public string Name { get; set; }
        public string Type { get; set; } 
        public int Power { get; set; }
        public Skill(string name, string type, int power)
        {
            Name = name;
            Type = type;
            Power = power;
        }
        public Skill Clone()
        {
            return new Skill(Name, Type, Power);
        }
        public override string ToString()
        {
            return $"{Name} ({Type}, сила: {Power})";
        }
    }
    public class Character : IPrototype<Character>
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }

        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();

        public Character Clone()
        {
            Character clone = (Character)this.MemberwiseClone();
            clone.Weapon = Weapon?.Clone();
            clone.Armor = Armor?.Clone();
            clone.Skills = new List<Skill>();
            foreach (var skill in Skills)
                clone.Skills.Add(skill.Clone());
            return clone;
        }
        public override string ToString()
        {
            string skills = string.Join(", ", Skills);
            return $"Персонаж: {Name}\n" +
                   $"Здоровье: {Health}, Сила: {Strength}, Ловкость: {Agility}, Интеллект: {Intelligence}\n" +
                   $"Оружие: {Weapon}\n" +
                   $"Броня: {Armor}\n" +
                   $"Способности: {skills}\n";
        }
    }
}
