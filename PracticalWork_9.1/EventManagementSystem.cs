using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_9._1
{
    public class EventManagementSystem
    {
        public bool BookEvent(string eventName, int attendees)
        {
            Console.WriteLine($"[Мероприятия] Мероприятие '{eventName}' для {attendees} участников организовано.");
            return true;
        }
        public bool OrderEquipment(string eventName, List<string> equipmentList)
        {
            Console.WriteLine($"[Мероприятия] Для '{eventName}' заказано оборудование: {string.Join(", ", equipmentList)}.");
            return true;
        }
    }
}
