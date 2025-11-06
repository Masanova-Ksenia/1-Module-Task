using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_9._1
{
    public class VideoProjector
    {
        public void TurnOn()
        {
            Console.WriteLine("Video projector is turned on");
        }
        public void SetResolution(string resolution)
        {
            Console.WriteLine($"The resolution is set to {resolution}");
        }
        public void TurnOff()
        {
            Console.WriteLine("Video projector is turned off");
        }
    }
}
