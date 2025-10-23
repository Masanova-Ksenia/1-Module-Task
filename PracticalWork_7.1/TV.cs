using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_7._1
{
    public class TV
    {
        public void On() => Console.WriteLine("Телевизор включён");
        public void Off() => Console.WriteLine("Телевизор выключен");
        public void SetChannel(int ch) => Console.WriteLine($"Канал переключен на {ch}");
    }
}
