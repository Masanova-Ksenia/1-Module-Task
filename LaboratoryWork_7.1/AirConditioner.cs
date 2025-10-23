using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_7._1
{
    public class AirConditioner
    {
        public void On()
        {
            Console.WriteLine("Кондиционер включен.");
        }
        public void Off()
        {
            Console.WriteLine("Кондиционер выключен.");
        }
        public void EcoMode()
        {
            Console.WriteLine("Кондиционер переведён в эконом-режим.");
        }
    }
}
