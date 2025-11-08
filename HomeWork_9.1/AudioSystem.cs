using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_9._1
{
    public class AudioSystem
    {
        public void On() => Console.WriteLine("Аудиосистема включена");
        public void Off() => Console.WriteLine("Аудиосистема выключена");
        public void SetVolume(int level) => Console.WriteLine($"Громкость аудиосистемы установлена на {level}");

    }
}
