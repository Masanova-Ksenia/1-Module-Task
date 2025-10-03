using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрактическаяРабота_5._1
{
    public class LogReader
    {
        private readonly string _logFilePath;
        public LogReader(string logFilePath)
        {
            _logFilePath = logFilePath;
        }
        public void ReadLogs(LogLevel? filter = null)
        {
            if (!File.Exists(_logFilePath))
            {
                Console.WriteLine("Файл логов не найден.");
                return;
            }
            foreach (var line in File.ReadAllLines(_logFilePath))
            {
                if (filter == null || line.Contains($"[{filter}]"))
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}