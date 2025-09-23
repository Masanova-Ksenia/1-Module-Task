using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДомашнееЗадание_3
{
    public interface IMessageSender
    {
        void Send(string message);
    }
    public class EmailSender : IMessageSender
    {
        public void Send(string message) => Console.WriteLine("Email sent: " + message);
    }
    public class SmsSender : IMessageSender
    {
        public void Send(string message) => Console.WriteLine("SMS sent: " + message);
    }
    public class MessengerSender : IMessageSender
    {
        public void Send(string message) => Console.WriteLine("Messenger message sent: " + message);
    }
    public class NotificationManager
    {
        private readonly List<IMessageSender> _senders;

        public NotificationManager(List<IMessageSender> senders)
        {
            _senders = senders;
        }
        public void SendNotification(string message)
        {
            foreach (var sender in _senders)
            {
                sender.Send(message);
            }
        }
    }
}