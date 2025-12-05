using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_13_2
{
    class Program
    {
        static void Main()
        {
            var users = new List<User>
            {
                new User { ID = 1, Name = "Гость", Role = Role.Guest },
                new User { ID = 2, Name = "Иван", Role = Role.User },
                new User { ID = 3, Name = "Админ", Role = Role.Admin }
            };
            var events = new List<Event>
            {
                new Event { ID = 1, Title = "Концерт", Date = DateTime.Now.AddDays(10), Place = "Арена" },
                new Event { ID = 2, Title = "Выставка", Date = DateTime.Now.AddDays(20), Place = "Галерея" },
                new Event { ID = 3, Title = "Мастер-класс", Date = DateTime.Now.AddDays(5), Place = "Центр искусств" }
            };
            var bookings = new List<Booking>();
            var userService = new UserService(users);
            var eventService = new EventService(events);
            var bookingService = new BookingService(bookings);
            var system = new EventSystem(userService, eventService, bookingService);
            system.Run();
        }
    }
}
