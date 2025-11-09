using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_9._1
{
    class Program
    {
        static void Main()
        {
            HotelFacade hotel = new HotelFacade();
            hotel.BookRoomWithServices(
                "Иван Иванов",
                "Люкс",
                new List<string> { "Стейк", "Салат 'Цезарь''", "Чай" },
                "10:00"
            );
            hotel.OrganizeEvent(
                "Бизнес-конференция",
                10,
                new List<string> { "Проектор", "Микрофоны", "Ноутбуки" },
                "Стандарт"
            );
            hotel.BookTableWithTaxi(
                "Анна Смирнова",
                2,
                "Аэропорт"
            );
            hotel.CancelRoomBooking("Иван Иванов");
            hotel.RequestCleaning(202);
        }
    }
}