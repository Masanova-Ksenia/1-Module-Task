using System;
using System.IO;
using System.Threading;

namespace ЛабораторнаяРабота_5._1
{
    class Program
    {
        static void Main()
        {
            Logger logger = Logger.GetInstance();
            logger.SetLogFilePath("game_logs.txt");
            logger.SetLogLevel(LogLevel.INFO);

            Thread t1 = new Thread(() => LogWorker("Thread 1", LogLevel.INFO));
            Thread t2 = new Thread(() => LogWorker("Thread 2", LogLevel.WARNING));
            Thread t3 = new Thread(() => LogWorker("Thread 3", LogLevel.ERROR));

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            logger.ReadLogs();
        }

        static void LogWorker(string name, LogLevel level)
        {
            Logger log = Logger.GetInstance();
            for (int i = 0; i < 5; i++)
            {
                log.Log($"{name} - message {i + 1}", level);
                Thread.Sleep(100);
            }
        }
    }
}