using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_9._1
{
    public class HotelFacade
    {
        private RoomBookingSystem roomSystem = new RoomBookingSystem();
        private RestaurantSystem restaurantSystem = new RestaurantSystem();
        private EventManagementSystem eventSystem = new EventManagementSystem();
        private CleaningService cleaningService = new CleaningService();
        private TaxiService taxiService = new TaxiService();
        public void BookRoomWithServices(string guestName, string roomType, List<string> dishes, string cleaningTime)
        {
            Console.WriteLine("\nБронирование номера");
            roomSystem.BookRoom(guestName, roomType);
            restaurantSystem.OrderFood(guestName, dishes);
            cleaningService.ScheduleCleaning(101, cleaningTime);
            Console.WriteLine("Все услуги успешно оформлены.\n");
        }
        public void OrganizeEvent(string eventName, int attendees, List<string> equipment, string roomType)
        {
            Console.WriteLine("\nОрганизация мероприятия");
            eventSystem.BookEvent(eventName, attendees);
            eventSystem.OrderEquipment(eventName, equipment);
            for (int i = 1; i <= attendees / 2; i++)
            {
                roomSystem.BookRoom($"Гость {i}", roomType);
            }
            Console.WriteLine("Мероприятие организовано с бронированием номеров и оборудования.\n");
        }
        public void BookTableWithTaxi(string guestName, int tableSize, string destination)
        {
            Console.WriteLine("\nБронирование стола и такси");
            restaurantSystem.BookTable(guestName, tableSize);
            taxiService.OrderTaxi(guestName, destination);
            Console.WriteLine("Стол забронирован и такси заказано.\n");
        }
        public void CancelRoomBooking(string guestName)
        {
            Console.WriteLine("\nОтмена бронирования");
            roomSystem.CancelBooking(guestName);
            Console.WriteLine("Бронирование успешно отменено.\n");
        }
        public void RequestCleaning(int roomNumber)
        {
            Console.WriteLine("\nЗапрос на уборку");
            cleaningService.CleanNow(roomNumber);
            Console.WriteLine("Уборка выполнена по запросу.\n");
        }
    }
}
