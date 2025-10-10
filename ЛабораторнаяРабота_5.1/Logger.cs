using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_5._1
{
    public enum LogLevel
    {
        INFO = 1,
        WARNING = 2,
        ERROR = 3
    }
    public sealed class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();
        private static LogLevel _currentLevel = LogLevel.INFO;

        private string _logFilePath;
        private Logger()
        {
            _logFilePath = "log.txt";
        }
        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }
        public void SetLogFilePath(string path)
        {
            lock (_lock)
            {
                _logFilePath = path;
            }
        }
        public void SetLogLevel(LogLevel level)
        {
            lock (_lock)
            {
                _currentLevel = level;
            }
        }
        public void Log(string message, LogLevel level)
        {
            if (level < _currentLevel)
                return;

            lock (_lock)
            {
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
                File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
                Console.WriteLine(logMessage);
            }
        }
        public void ReadLogs()
        {
            lock (_lock)
            {
                if (File.Exists(_logFilePath))
                {
                    Console.WriteLine("\n=== Log file content ===");
                    Console.WriteLine(File.ReadAllText(_logFilePath));
                }
                else
                {
                    Console.WriteLine("Log file not found.");
                }
            }
        }
    }
}
