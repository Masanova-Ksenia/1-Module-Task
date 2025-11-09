using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_9._1
{
    public class TaxiService
    {
        public bool OrderTaxi(string guestName, string destination)
        {
            Console.WriteLine($"[Такси] Для {guestName} вызвано такси до {destination}.");
            return true;
        }
    }
}
