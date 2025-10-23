using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_7._1
{
    public class Light
    {
        private readonly string location;
        private bool isOn;

        public Light(string location)
        {
            this.location = location;
        }

        public void On()
        {
            isOn = true;
            Console.WriteLine($"{location} свет включён");
        }

        public void Off()
        {
            isOn = false;
            Console.WriteLine($"{location} свет выключен");
        }
    }
}
