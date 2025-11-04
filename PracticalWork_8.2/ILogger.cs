using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._2
{
    public interface ILogger
    {
        void Info(string message);
        void Warn(string message);
        void Error(string message);
    }
    public class ConsoleLogger : ILogger
    {
        public void Info(string message) => Console.WriteLine($"[INFO] {message}");
        public void Warn(string message) => Console.WriteLine($"[WARN] {message}");
        public void Error(string message) => Console.WriteLine($"[ERROR] {message}");
    }
}
