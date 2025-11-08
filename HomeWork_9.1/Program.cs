using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_9._1
{
    class Program
    {
        static void Main(string[] args)
        {
            TV tv = new TV();
            AudioSystem audio = new AudioSystem();
            DVDPlayer dvd = new DVDPlayer();
            GameConsole console = new GameConsole();
            HomeTheatreFacade homeTheater = new HomeTheatreFacade(tv, audio, dvd, console);
            homeTheater.WatchMovie("HBO", 25);
            homeTheater.SetVolume(30);
            homeTheater.EndMovie();
            homeTheater.PlayGame("Minecraft");
            homeTheater.ListenMusic(20);
            homeTheater.SetChannel("Discovery");
            homeTheater.TurnOffAll();
        }
    }
}
