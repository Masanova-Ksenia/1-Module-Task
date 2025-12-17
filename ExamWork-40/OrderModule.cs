using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork_40
{
    public class OrderModule : IModule
    {
        public string Name => "OrderModule";
        private readonly IMediator _mediator;
        public OrderModule(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void CreateOrder()
        {
            Console.WriteLine("Заказ создан");
            _mediator.Notify(Name, "OrderCreated", new { OrderId = 1 });
        }
        public void HandleEvent(string eventName, object data) { }
    }
}
