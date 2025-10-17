using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_6._2
{
    public class Program
    {
        static void Main()
        {
            var station = new WeatherStation();

            var display1 = new WeatherDisplay("disp1", "Мобильное приложение");
            var display2 = new WeatherDisplay("disp2", "Электронное табло");
            var email = new EmailAlert("email1", "user@example.com", threshold: 0f);
            var alarm = new SoundAlarm("alarm1", triggerAbove: 30f);

            station.RegisterObserver(display1);
            station.RegisterObserver(display2);
            station.RegisterObserver(email);
            station.RegisterObserver(alarm);

            station.SetTemperature(25.0f);
            station.SetTemperature(30.5f);

            station.RemoveObserver(display2);
            station.SetTemperature(28.0f);

            station.RemoveObserver(display2);

            try
            {
                station.SetTemperature(float.NaN);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
