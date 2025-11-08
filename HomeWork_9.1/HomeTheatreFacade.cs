using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_9._1
{
    public class HomeTheatreFacade
    {
        private TV tv;
        private AudioSystem audio;
        private DVDPlayer dvd;
        private GameConsole console;
        public HomeTheatreFacade(TV tv, AudioSystem audio, DVDPlayer dvd, GameConsole console)
        {
            this.tv = tv;
            this.audio = audio;
            this.dvd = dvd;
            this.console = console;
        }
        public void WatchMovie(string channel = "Movie Channel", int volume = 20)
        {
            Console.WriteLine("\nПодготовка к просмотру фильма");
            tv.On();
            tv.SetChannel(channel);
            audio.On();
            audio.SetVolume(volume);
            dvd.Play();
        }
        public void EndMovie()
        {
            Console.WriteLine("\nЗавершение просмотра фильма");
            dvd.Stop();
            audio.Off();
            tv.Off();
        }
        public void PlayGame(string gameName)
        {
            Console.WriteLine("\nПодготовка к игре");
            tv.On();
            console.On();
            console.StartGame(gameName);
        }
        public void ListenMusic(int volume = 15)
        {
            Console.WriteLine("\nВключение музыки");
            tv.On();
            audio.On();
            audio.SetVolume(volume);
            Console.WriteLine("Аудиосистема настроена для воспроизведения музыки с TV");
        }
        public void SetVolume(int volume)
        {
            Console.WriteLine($"\nРегулировка громкости");
            audio.SetVolume(volume);
        }
        public void SetChannel(string channel)
        {
            Console.WriteLine($"\nПереключение канала");
            tv.SetChannel(channel);
        }
        public void TurnOffAll()
        {
            Console.WriteLine("\nВыключение всей системы");
            dvd.Stop();
            audio.Off();
            tv.Off();
            Console.WriteLine("Все устройства выключены");
        }
    }
}
