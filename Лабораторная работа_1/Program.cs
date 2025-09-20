using System;
using System.Collections.Generic;

namespace Лабораторная_работа_1
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeSystem system = new EmployeeSystem();

            Worker worker1 = new Worker("Иван Иванов", 1, 2310, 160);
            Worker worker2 = new Worker("Петр Петров", 2, 2290, 120);

            Manager manager1 = new Manager("Анна Смирнова", 3, 300000, 80000);
            Manager manager2 = new Manager("Сергей Кузнецов", 4, 256000, 65000);

            system.AddEmployee(worker1);
            system.AddEmployee(worker2);
            system.AddEmployee(manager1);
            system.AddEmployee(manager2);

            system.ShowSalaries();
        }
    }
}