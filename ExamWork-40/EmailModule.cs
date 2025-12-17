using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork_40
{
    public class EmailModule : IModule
    {
        public string Name => "EmailModule";
        public void HandleEvent(string eventName, object data)
        {
            Console.WriteLine($"Email отправлен. Событие: {eventName}");
        }
    }
}
