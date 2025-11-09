using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_9._1
{
    public class CleaningService
    {
        public bool ScheduleCleaning(int roomNumber, string time)
        {
            Console.WriteLine($"[Уборка] Уборка в номере {roomNumber} запланирована на {time}.");
            return true;
        }
        public bool CleanNow(int roomNumber)
        {
            Console.WriteLine($"[Уборка] В номере {roomNumber} выполнена уборка по запросу.");
            return true;
        }
    }
}
