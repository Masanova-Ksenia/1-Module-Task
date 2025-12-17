using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork_40
{
    class Program
    {
        static void Main(string[] args)
        {
            var scenarios = new Dictionary<string, List<string>>{
            { "OrderModule.OrderCreated", new List<string> { "EmailModule", "LogModule" } }
            };
            IMediator mediator = new EventMediator(scenarios);
            var orderModule = new OrderModule(mediator);
            var emailModule = new EmailModule();
            var logModule = new LogModule();
            mediator.Register(orderModule);
            mediator.Register(emailModule);
            mediator.Register(logModule);
            orderModule.CreateOrder();
        }
    }
}