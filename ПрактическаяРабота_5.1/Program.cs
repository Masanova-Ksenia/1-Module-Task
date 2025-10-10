using System;
using System.Threading;
using ПрактическаяРабота_5._1;

public class Program
{
    public static void Main(string[] args)
    {
        var logger = Logger.GetInstance();
        Thread t1 = new Thread(() =>
        {
            for (int i = 0; i < 5; i++)
                logger.Log("Message INFO from flow 1", LogLevel.INFO);
        });
        Thread t2 = new Thread(() =>
        {
            for (int i = 0; i < 5; i++)
                logger.Log("Message WARNING from flow 2", LogLevel.WARNING);
        });
        Thread t3 = new Thread(() =>
        {
            for (int i = 0; i < 5; i++)
                logger.Log("Message ERROR from flow 3", LogLevel.ERROR);
        });

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine("Logging completed");
    }
}