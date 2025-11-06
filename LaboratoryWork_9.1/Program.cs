using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_9._1
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeTheaterFacade homeCinema = new HomeTheaterFacade(new AudioSystem(), new VideoProjector(), new LightingSystem());
            homeCinema.TurnOn();
            homeCinema.Start();
            homeCinema.Finish();
            homeCinema.TurnOff();
        }
        
    }
}
