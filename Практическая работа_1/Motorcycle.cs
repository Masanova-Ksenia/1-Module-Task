using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_1
{
    public class Motorcycle : Vehicle
    {
        public string BodyType { get; }
        public bool HasBox { get; }
        public Motorcycle(string brand, string model, int year, string bodyType, bool hasBox)
            : base(brand, model, year)
        {
            BodyType = bodyType;
            HasBox = hasBox;
        }
        public override string ToString()
        {
            return base.ToString() + $" | Тип: {BodyType}, Бокс: {(HasBox ? "есть" : "нет")}";
        }
    }
}