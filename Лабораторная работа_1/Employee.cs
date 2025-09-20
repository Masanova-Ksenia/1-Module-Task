using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_1
{
    public abstract class Employee
    {
        public string Name { get; }
        public int Id { get; }
        public string Position { get; }
        protected Employee(string name, int id, string position)
        {
            Name = name;
            Id = id;
            Position = position;
        }
        public abstract decimal CalculateSalary();

        public override string ToString()
        {
            return $"Сотрудник: {Name}, ID: {Id}, Должность: {Position}";
        }
    }
}