using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_13_2
{
    class EventSystem
    {
        private UserService _userService;
        private EventService _eventService;
        private BookingService _bookingService;
        private User _currentUser;

        public EventSystem(UserService us, EventService es, BookingService bs)
        {
            _userService = us;
            _eventService = es;
            _bookingService = bs;
            _currentUser = null;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Система бронирования мероприятий");

                if (_currentUser == null)
                    LoginMenu();
                else
                    UserMenu();
            }
        }
        private void LoginMenu()
        {
            Console.WriteLine("\n1. Войти как пользователь");
            Console.WriteLine("2. Продолжить как гость");
            Console.WriteLine("0. Выход");
            Console.Write("Выбор: ");

            switch (Console.ReadLine())
            {
                case "1": Login(); break;
                case "2": _currentUser = _userService.GetGuest(); break;
                case "0": Environment.Exit(0); break;
            }
        }
        private void Login()
        {
            Console.Write("Введите ID пользователя: ");
            int id = int.Parse(Console.ReadLine());
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                Console.WriteLine("Пользователь не найден!");
                Console.ReadKey();
            }
            else
            {
                _currentUser = user;
            }
        }
        private void UserMenu()
        {
            Console.Clear();
            Console.WriteLine($"Вы вошли как: {_currentUser.Name} ({_currentUser.Role})\n");

            Console.WriteLine("1. Просмотр мероприятий");
            if (_currentUser.Role != Role.Guest)
            {
                Console.WriteLine("2. Бронирование мероприятия");
                Console.WriteLine("3. Отмена бронирования");
            }
            if (_currentUser.Role == Role.Admin)
            {
                Console.WriteLine("4. Управление мероприятиями");
                Console.WriteLine("5. Просмотр всех бронирований");
            }

            Console.WriteLine("9. Выйти из аккаунта");
            Console.WriteLine("0. Выход");
            Console.Write("Выбор: ");

            switch (Console.ReadLine())
            {
                case "1": _eventService.ShowEvents(); break;
                case "2": if (_currentUser.Role != Role.Guest) BookEvent(); break;
                case "3": if (_currentUser.Role != Role.Guest) _bookingService.CancelBooking(_currentUser); break;
                case "4": if (_currentUser.Role == Role.Admin) ManageEvents(); break;
                case "5": if (_currentUser.Role == Role.Admin) _bookingService.ShowAllBookings(); break;
                case "9": _currentUser = null; break;
                case "0": Environment.Exit(0); break;
            }
            Console.ReadKey();
        }
        private void BookEvent()
        {
            _eventService.ShowEvents();
            Console.Write("Введите ID мероприятия: ");
            int id = int.Parse(Console.ReadLine());
            var ev = _eventService.GetEventById(id);
            if (ev != null)
                _bookingService.CreateBooking(_currentUser, ev);
        }
        private void ManageEvents()
        {
            Console.Clear();
            Console.WriteLine("Управление мероприятиями");
            Console.WriteLine("1. Добавить");
            Console.WriteLine("2. Редактировать");
            Console.WriteLine("3. Удалить");
            Console.WriteLine("0. Назад");

            switch (Console.ReadLine())
            {
                case "1": AddEvent(); break;
                case "2": EditEvent(); break;
                case "3": DeleteEvent(); break;
            }
        }
        private void AddEvent()
        {
            Console.Write("Название: ");
            string title = Console.ReadLine();
            Console.Write("Дата (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Место: ");
            string place = Console.ReadLine();

            int id = _eventService.GetAllEvents().Count + 1;
            _eventService.AddEvent(new Event { ID = id, Title = title, Date = date, Place = place });

            Console.WriteLine("Мероприятие добавлено!");
        }
        private void EditEvent()
        {
            _eventService.ShowEvents();
            Console.Write("ID для редактирования: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Новое название: ");
            string title = Console.ReadLine();
            Console.Write("Новая дата (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Новое место: ");
            string place = Console.ReadLine();

            _eventService.EditEvent(id, title, date, place);
            Console.WriteLine("Обновлено!");
        }
        private void DeleteEvent()
        {
            _eventService.ShowEvents();
            Console.Write("ID для удаления: ");
            int id = int.Parse(Console.ReadLine());
            _eventService.DeleteEvent(id);
            Console.WriteLine("Удалено!");
        }
    }
}
