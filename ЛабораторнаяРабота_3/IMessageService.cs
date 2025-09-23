using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_3
{
    public interface IMessageService
    {
        void Send(string message);
    }
    public class EmailService : IMessageService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Отправка Email: {message}");
        }
    }
    public class SmsService : IMessageService
    {
        public void Send(string message)
        {
            Console.WriteLine($"Отправка SMS: {message}");
        }
    }
    public class Notification
    {
        private readonly IMessageService _messageService;
        public Notification(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public void Send(string message)
        {
            _messageService.Send(message);
        }
    }
}
