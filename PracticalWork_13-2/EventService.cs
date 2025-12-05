using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_13_2
{
    class EventService
    {
        private List<Event> _events;
        public EventService(List<Event> events)
        {
            _events = events;
        }
        public void ShowEvents()
        {
            Console.WriteLine("Список мероприятий");
            foreach (var ev in _events)
                Console.WriteLine($"{ev.ID}. {ev.Title} — {ev.Date.ToShortDateString()} ({ev.Place})");
        }
        public Event GetEventById(int id) => _events.FirstOrDefault(e => e.ID == id);
        public void AddEvent(Event ev) => _events.Add(ev);
        public void EditEvent(int id, string title, DateTime date, string place)
        {
            var ev = GetEventById(id);
            if (ev != null)
            {
                ev.Title = title;
                ev.Date = date;
                ev.Place = place;
            }
        }
        public void DeleteEvent(int id) => _events.RemoveAll(e => e.ID == id);
        public List<Event> GetAllEvents() => _events;
    }
}
