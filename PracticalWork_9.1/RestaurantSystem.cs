using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_9._1
{
    public class RestaurantSystem
    {
        public bool BookTable(string guestName, int tableSize)
        {
            Console.WriteLine($"[Ресторан] Стол на {tableSize} человек забронирован для {guestName}.");
            return true;
        }
        public bool OrderFood(string guestName, List<string> dishes)
        {
            Console.WriteLine($"[Ресторан] {guestName} заказал блюда: {string.Join(", ", dishes)}.");
            return true;
        }
    }
}
