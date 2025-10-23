using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_7._3
{
    public abstract class Colleague
    {
        protected IMediator _mediator;
        public string Name { get; protected set; }

        public Colleague(IMediator mediator, string name)
        {
            _mediator = mediator;
            Name = name;
        }

        public abstract void ReceiveMessage(string message);
    }
    public class User : Colleague
    {
        public User(IMediator mediator, string name) : base(mediator, name) { }

        public void Send(string message)
        {
            Console.WriteLine($"{Name} отправляет сообщение: {message}");
            _mediator.SendMessage(message, this);
        }

        public void SendPrivate(string message, Colleague receiver)
        {
            Console.WriteLine($"{Name} отправляет ЛС {receiver.Name}: {message}");
            _mediator.SendMessage(message, this, receiver);
        }

        public override void ReceiveMessage(string message)
        {
            Console.WriteLine($"{Name} получил сообщение: {message}");
        }
    }
}
