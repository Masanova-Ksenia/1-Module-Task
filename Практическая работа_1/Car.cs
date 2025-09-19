using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_1
{
    public class Car : Vehicle
    {
        public int Doors { get; }
        public string Transmission { get; }
        public Car(string brand, string model, int year, int doors, string transmission)
            : base(brand, model, year)
        {
            Doors = doors;
            Transmission = transmission;
        }
        public override string ToString()
        {
            return base.ToString() + $" | Дверей: {Doors}, Трансмиссия: {Transmission}";
        }
    }
}