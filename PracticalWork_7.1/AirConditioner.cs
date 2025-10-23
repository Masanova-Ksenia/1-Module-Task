using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_7._1
{
    public class AirConditioner
    {
        private int temperature = 22;
        private bool isOn;

        public void On()
        {
            isOn = true;
            Console.WriteLine("Кондиционер включён");
        }

        public void Off()
        {
            isOn = false;
            Console.WriteLine("Кондиционер выключен");
        }

        public void SetTemperature(int temp)
        {
            temperature = temp;
            Console.WriteLine($"Температура установлена на {temperature}°C");
        }
    }
}
