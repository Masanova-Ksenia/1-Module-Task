using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_1
{
    public class Vehicle
    {
        public string Brand { get; }
        public string Model { get; }
        public int Year { get; }
        protected bool EngineRunning;
        public Vehicle(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
            EngineRunning = false;
        }
        public virtual void StartEngine()
        {
            if (!EngineRunning)
            {
                EngineRunning = true;
                Console.WriteLine($"{Brand} {Model} ({Year}) — двигатель запущен.");
            }
            else
            {
                Console.WriteLine($"{Brand} {Model} уже работает.");
            }
        }
        public virtual void StopEngine()
        {
            if (EngineRunning)
            {
                EngineRunning = false;
                Console.WriteLine($"{Brand} {Model} — двигатель остановлен.");
            }
            else
            {
                Console.WriteLine($"{Brand} {Model} уже заглушен.");
            }
        }
        public override string ToString()
        {
            return $"{Brand} {Model} ({Year})";
        }
    }
}