using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_9._1
{
    public class GameConsole
    {
        public void On() => Console.WriteLine("Игровая консоль включена");
        public void StartGame(string gameName) => Console.WriteLine($"Игра '{gameName}' запущена");
    }
}
