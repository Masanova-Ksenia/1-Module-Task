using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_9._1
{
    public class LightingSystem
    {
        public void TurnOn()
        {
            Console.WriteLine("Lighting system is turned on");
        }
        public void SetBrightness(int level) 
        {
            Console.WriteLine($"The brightness is set to {level}");
        }
        public void TurnOff()
        {
            Console.WriteLine("Lighting system is turned off");
        }
    }
}
