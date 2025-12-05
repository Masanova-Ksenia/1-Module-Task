using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_13_2
{
    class BookingService
    {
        private List<Booking> _bookings;
        private int _nextId = 1;

        public BookingService(List<Booking> bookings)
        {
            _bookings = bookings;
            if (_bookings.Count > 0)
                _nextId = _bookings.Max(b => b.ID) + 1;
        }
        public void CreateBooking(User user, Event ev)
        {
            _bookings.Add(new Booking { ID = _nextId++, User = user, Event = ev });
            Console.WriteLine("Бронирование создано!");
        }
        public void CancelBooking(User user)
        {
            var myBookings = _bookings.Where(b => b.User.ID == user.ID && b.Status == "Active").ToList();
            if (!myBookings.Any())
            {
                Console.WriteLine("Нет активных бронирований.");
                return;
            }
            Console.WriteLine("Ваши бронирования:");
            foreach (var b in myBookings)
                Console.WriteLine($"{b.ID}. {b.Event.Title} — {b.Status}");

            Console.Write("Введите ID для отмены: ");
            int id = int.Parse(Console.ReadLine());

            var booking = myBookings.FirstOrDefault(b => b.ID == id);
            if (booking != null)
                booking.Status = "Cancelled";

            Console.WriteLine("Отменено!");
        }
        public void ShowAllBookings()
        {
            Console.WriteLine("=== Все бронирования ===");
            foreach (var b in _bookings)
                Console.WriteLine($"{b.ID}. {b.User.Name} → {b.Event.Title} — {b.Status}");
        }
        public List<Booking> GetBookings() => _bookings;
    }
}
