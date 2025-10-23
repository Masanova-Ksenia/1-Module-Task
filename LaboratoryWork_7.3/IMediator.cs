using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_7._3
{
    public interface IMediator
    {
        void SendMessage(string message, Colleague sender, Colleague receiver = null);
    }
    public class ChatMediator : IMediator
    {
        private List<Colleague> _colleagues = new List<Colleague>();
        private List<string> _log = new List<string>();

        public void Register(Colleague colleague)
        {
            if (!_colleagues.Contains(colleague))
                _colleagues.Add(colleague);
        }

        public void Remove(Colleague colleague)
        {
            if (_colleagues.Contains(colleague))
                _colleagues.Remove(colleague);
        }

        public void SendMessage(string message, Colleague sender, Colleague receiver = null)
        {
            if (!_colleagues.Contains(sender))
            {
                Console.WriteLine($"{sender.Name} не зарегистрирован в чате.");
                return;
            }

            if (receiver != null)
            {
                if (_colleagues.Contains(receiver))
                {
                    receiver.ReceiveMessage($"(ЛС от {sender.Name}) {message}");
                    _log.Add($"ЛС {sender.Name}->{receiver.Name}: {message}");
                }
                else
                {
                    Console.WriteLine($"Получатель {receiver.Name} не найден.");
                }
                return;
            }

            foreach (var c in _colleagues)
            {
                if (c != sender)
                    c.ReceiveMessage($"{sender.Name}: {message}");
            }

            _log.Add($"{sender.Name}: {message}");
        }

        public void ShowLog()
        {
            Console.WriteLine("История сообщений:");
            foreach (var entry in _log)
                Console.WriteLine(entry);
        }
    }
}
