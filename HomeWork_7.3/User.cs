using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7._3
{
    public abstract class User
    {
        public string Username { get; }
        protected IMediator Mediator { get; private set; }

        protected User(string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }

        internal void SetMediator(IMediator mediator)
        {
            Mediator = mediator;
        }

        public void Send(string message)
        {
            if (Mediator == null)
            {
                Console.WriteLine($"Ошибка: пользователь '{Username}' не подключён к чату");
                return;
            }
            Mediator.SendMessage(Username, message);
        }

        public void SendPrivate(string toUsername, string message)
        {
            if (Mediator == null)
            {
                Console.WriteLine($"Ошибка: пользователь '{Username}' не подключён к чату");
                return;
            }
            Mediator.SendPrivateMessage(Username, toUsername, message);
        }

        public abstract void Receive(string fromUsername, string message);
        public virtual void ReceivePrivate(string fromUsername, string message) => Receive(fromUsername + " (личное)", message);
        public virtual void ReceiveSystem(string message) => Console.WriteLine($"[Система -> {Username}] {message}");
    }
}
