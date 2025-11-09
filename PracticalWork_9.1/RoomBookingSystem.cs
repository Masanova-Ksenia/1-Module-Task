using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_9._1
{
    public class RoomBookingSystem
    {
        public bool BookRoom(string guestName, string roomType)
        {
            Console.WriteLine($"[Бронирование номеров] Номер типа '{roomType}' забронирован для {guestName}.");
            return true;
        }
        public bool CancelBooking(string guestName)
        {
            Console.WriteLine($"[Бронирование номеров] Бронирование для {guestName} отменено.");
            return true;
        }
    }
}
