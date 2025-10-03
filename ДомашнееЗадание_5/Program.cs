using System;
using System.Threading;
using ДомашнееЗадание_5;

namespace ДомашнееЗадание_5
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationManager config1 = ConfigurationManager.GetInstance();
            ConfigurationManager config2 = ConfigurationManager.GetInstance();

            Console.WriteLine(object.ReferenceEquals(config1, config2)
                ? "Singleton работает: один и тот же экземпляр"
                : "Ошибка: разные экземпляры");

            config1.SetSetting("Database", "SQLServer");
            config1.SetSetting("Port", "1433");

            Console.WriteLine("Database = " + config2.GetSetting("Database"));
            Console.WriteLine("Port = " + config2.GetSetting("Port"));

            config1.SaveToFile("settings.txt");

            config2.LoadFromFile("settings.txt");
            Console.WriteLine("После загрузки: Database = " + config2.GetSetting("Database"));

            Thread t1 = new Thread(() =>
            {
                var c = ConfigurationManager.GetInstance();
                c.SetSetting("Thread1Key", "Value1");
                Console.WriteLine("Thread1: " + c.GetSetting("Thread1Key"));
            });

            Thread t2 = new Thread(() =>
            {
                var c = ConfigurationManager.GetInstance();
                c.SetSetting("Thread2Key", "Value2");
                Console.WriteLine("Thread2: " + c.GetSetting("Thread2Key"));
            });

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }
    }
}