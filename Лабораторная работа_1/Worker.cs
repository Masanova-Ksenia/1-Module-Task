using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_1
{
    public class Worker : Employee
    {
        public decimal HourlyRate { get; }
        public int HoursWorked { get; }
        public Worker(string name, int id, decimal hourlyRate, int hoursWorked)
            : base(name, id, "Рабочий")
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }
        public override decimal CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }
        public override string ToString()
        {
            return base.ToString() + $" | Ставка: {HourlyRate} | Часы: {HoursWorked}";
        }
    }
}