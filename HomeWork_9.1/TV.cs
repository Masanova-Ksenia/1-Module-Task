using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_9._1
{
    public class TV
    {
        public void On() => Console.WriteLine("Телевизор включен");
        public void Off() => Console.WriteLine("Телевизор выключен");
        public void SetChannel(string channel) => Console.WriteLine($"Телевизор переключен на канал {channel}");
    }
}
