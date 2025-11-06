using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_9._1
{
    public class HomeTheaterFacade
    {
        private AudioSystem _audioSystem;
        private VideoProjector _videoProjector;
        private LightingSystem _lightingSystem;
        public HomeTheaterFacade (AudioSystem audioSystem, VideoProjector videoProjector, LightingSystem lightingSystem)
        {
            _audioSystem = audioSystem;
            _videoProjector = videoProjector;
            _lightingSystem = lightingSystem;
        }
        public void TurnOn()
        {
            _audioSystem.TurnOn();
            _videoProjector.TurnOn();
            _lightingSystem.TurnOn();
        }
        public void Start()
        {
            Console.WriteLine("Movie is started");
            _audioSystem.SetVolume(10);
            _videoProjector.SetResolution("HD");
            _lightingSystem.SetBrightness(50);
        }
        public void Finish()
        {
            Console.WriteLine("Movie is finished");
        }
        public void TurnOff()
        {
            _audioSystem.TurnOff();
            _videoProjector.TurnOff();
            _lightingSystem.TurnOff();
        }
    }


}
