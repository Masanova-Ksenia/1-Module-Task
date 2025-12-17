using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork_40
{
    public class LogModule : IModule
    {
        public string Name => "LogModule";
        public void HandleEvent(string eventName, object data)
        {
            Console.WriteLine($"Лог: событие {eventName}, данные: {data}");
        }
    }
}
