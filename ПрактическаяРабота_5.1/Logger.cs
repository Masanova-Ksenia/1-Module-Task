using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ПрактическаяРабота_5._1
{
    public enum LogLevel
    {
        INFO = 1,
        WARNING = 2,
        ERROR = 3
    }
    public interface ILogTarget
    {
        void Write(string message);
    }
    public class FileLogTarget : ILogTarget
    {
        private readonly string _filePath;
        private readonly long _maxFileSize;
        private readonly object _lock = new object();
        public FileLogTarget(string filePath, long maxFileSize = 5_000_000)
        {
            _filePath = filePath;
            _maxFileSize = maxFileSize;
        }
        public void Write(string message)
        {
            lock (_lock)
            {
                RotateIfNeeded();
                File.AppendAllText(_filePath, message + Environment.NewLine);
            }
        }
        private void RotateIfNeeded()
        {
            FileInfo fi = new FileInfo(_filePath);
            if (fi.Exists && fi.Length > _maxFileSize)
            {
                string newName = $"{Path.GetFileNameWithoutExtension(_filePath)}_{DateTime.Now:yyyyMMdd_HHmmss}{Path.GetExtension(_filePath)}";
                string newPath = Path.Combine(fi.DirectoryName, newName);
                File.Move(_filePath, newPath);
            }
        }
    }
    public class ConsoleLogTarget : ILogTarget
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
    public sealed class Logger
    {
        private static readonly object _lock = new object();
        private static Logger _instance;
        private LogLevel _currentLevel;
        private List<ILogTarget> _targets = new List<ILogTarget>();
        private Logger(string configPath = "loggerConfig.json")
        {
            LoadConfig(configPath);
        }
        public static Logger GetInstance(string configPath = "loggerConfig.json")
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger(configPath);
                    }
                }
            }
            return _instance;
        }
        public void Log(string message, LogLevel level)
        {
            if (level < _currentLevel) return;
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            lock (_lock)
            {
                foreach (var target in _targets)
                {
                    target.Write(logEntry);
                }
            }
        }
        public void SetLogLevel(LogLevel level)
        {
            lock (_lock)
            {
                _currentLevel = level;
            }
        }
        private void LoadConfig(string configPath)
        {
            if (File.Exists(configPath))
            {
                string json = File.ReadAllText(configPath);
                var config = JsonSerializer.Deserialize<LoggerConfig>(json);
                _currentLevel = config.LogLevel;
                _targets.Clear();
                if (!string.IsNullOrEmpty(config.LogFilePath))
                {
                    _targets.Add(new FileLogTarget(config.LogFilePath, config.MaxFileSize));
                }
                if (config.EnableConsole)
                {
                    _targets.Add(new ConsoleLogTarget());
                }
            }
            else
            {
                _currentLevel = LogLevel.INFO;
                _targets.Add(new FileLogTarget("default.log"));
                _targets.Add(new ConsoleLogTarget());
            }
        }
        private class LoggerConfig
        {
            public string LogFilePath { get; set; }
            public LogLevel LogLevel { get; set; }
            public long MaxFileSize { get; set; } = 5_000_000;
            public bool EnableConsole { get; set; } = true;
        }
    }
}
