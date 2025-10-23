using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_7._1
{
    public class SmartHomeReceiver
    {
        public void TurnOnLight()
        {
            Console.WriteLine("Свет включен");
        }

        public void TurnOffLight()
        {
            Console.WriteLine("Свет выключен");
        }

        public void TurnOnAC()
        {
            Console.WriteLine("Кондиционер включен");
        }

        public void TurnOffAC()
        {
            Console.WriteLine("Кондиционер выключен");
        }

        public void OpenCurtains()
        {
            Console.WriteLine("Шторы открыты");
        }

        public void CloseCurtains()
        {
            Console.WriteLine("Шторы закрыты");
        }
    }
}
