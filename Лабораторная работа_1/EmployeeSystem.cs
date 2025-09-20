using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_1
{
    public class EmployeeSystem
    {
        private List<Employee> employees;

        public EmployeeSystem()
        {
            employees = new List<Employee>();
        }
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
            Console.WriteLine($"Добавлен {employee}");
        }
        public void ShowSalaries()
        {
            Console.WriteLine("\n Зарплаты сотрудников:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name} ({employee.Position}) → {employee.CalculateSalary()} тенге");
            }
        }
    }
}