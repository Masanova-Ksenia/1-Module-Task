using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_9._1
{
    public class AudioSystem
    {
        public void TurnOn()
        {
            Console.WriteLine("Audio system is turned on");
        }
        public void SetVolume(int level)
        {
            Console.WriteLine($"The volume is set to {level}");
        }
        public void TurnOff()
        {
            Console.WriteLine("Audio system is turned off");
        }
    }
}
