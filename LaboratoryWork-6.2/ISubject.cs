using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_6._2
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }
    public class WeatherStation : ISubject
    {
        private readonly List<IObserver> _observers;
        private float _temperature;

        public WeatherStation()
        {
            _observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            if (observer == null) throw new ArgumentNullException(nameof(observer));
            lock (_observers)
            {
                if (!_observers.Contains(observer))
                    _observers.Add(observer);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            if (observer == null) throw new ArgumentNullException(nameof(observer));
            bool removed;
            lock (_observers)
            {
                removed = _observers.Remove(observer);
            }
            if (!removed)
                Console.WriteLine($"Warning: попытка удалить наблюдателя {observer.Id}, который не был подписан.");
        }

        public void NotifyObservers()
        {
            List<IObserver> snapshot;
            lock (_observers)
            {
                snapshot = new List<IObserver>(_observers);
            }
            foreach (var obs in snapshot)
            {
                try
                {
                    obs.Update(_temperature);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при уведомлении {obs.Id}: {ex.Message}");
                }
            }
        }

        public void SetTemperature(float newTemperature)
        {
            if (float.IsNaN(newTemperature) || float.IsInfinity(newTemperature))
                throw new ArgumentException("Недопустимое значение температуры.");

            if (newTemperature < -100f || newTemperature > 100f)
                throw new ArgumentOutOfRangeException(nameof(newTemperature), "Температура вне разумного диапазона (-100..100).");

            Console.WriteLine($"\n[WeatherStation] Температура изменена: {newTemperature}°C");
            _temperature = newTemperature;
            NotifyObservers();
        }
    }
}
