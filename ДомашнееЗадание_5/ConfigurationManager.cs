using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДомашнееЗадание_5
{
    public sealed class ConfigurationManager
    {
        private static ConfigurationManager _instance = null;
        private static readonly object _lock = new object();

        private Dictionary<string, string> _settings;

        private ConfigurationManager()
        {
            _settings = new Dictionary<string, string>();
        }
        public static ConfigurationManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null) 
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }
            return _instance;
        }
        public void SetSetting(string key, string value)
        {
            lock (_lock)
            {
                _settings[key] = value;
            }
        }
        public string GetSetting(string key)
        {
            lock (_lock)
            {
                if (_settings.ContainsKey(key))
                    return _settings[key];
                else
                    throw new KeyNotFoundException($"Настройка '{key}' не найдена");
            }
        }
        public void LoadFromFile(string filePath)
        {
            lock (_lock)
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("Файл настроек не найден", filePath);

                foreach (var line in File.ReadAllLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                        continue;

                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        _settings[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
        }
        public void SaveToFile(string filePath)
        {
            lock (_lock)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var kvp in _settings)
                    {
                        writer.WriteLine($"{kvp.Key}={kvp.Value}");
                    }
                }
            }
        }
    }
}
