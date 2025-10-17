using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_6._2
{
    public interface IObserver
    {
        void Update(float temperature);
        string Id { get; }
    }
    public class WeatherDisplay : IObserver
    {
        public string Id { get; }
        private readonly string _name;

        public WeatherDisplay(string id, string name)
        {
            Id = id;
            _name = name;
        }

        public void Update(float temperature)
        {
            Console.WriteLine($"{_name} ({Id}) показывает: {temperature}°C");
        }
    }
    public class EmailAlert : IObserver
    {
        public string Id { get; }
        private readonly string _email;
        private readonly float? _threshold;

        public EmailAlert(string id, string email, float? threshold = null)
        {
            Id = id;
            _email = email;
            _threshold = threshold;
        }

        public void Update(float temperature)
        {
            if (_threshold.HasValue && temperature < _threshold.Value) return;

            Task.Run(() =>
            {
                Console.WriteLine($"[Email -> {_email}] Оповещение: текущая температура {temperature}°C (получатель: {Id})");
            });
        }
    }
    public class SoundAlarm : IObserver
    {
        public string Id { get; }
        private readonly float _triggerAbove;

        public SoundAlarm(string id, float triggerAbove)
        {
            Id = id;
            _triggerAbove = triggerAbove;
        }

        public void Update(float temperature)
        {
            if (temperature > _triggerAbove)
                Console.WriteLine($"[ALARM {Id}] Температура {temperature}°C выше {_triggerAbove}°C — включаю сигнал!");
        }
    }
}
