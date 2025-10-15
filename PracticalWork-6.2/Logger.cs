using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_6._2
{
    public static class Logger
    {
        private static readonly object _sync = new object();

        public static void Log(string message)
        {
            lock (_sync)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
            }
        }
    }
}
