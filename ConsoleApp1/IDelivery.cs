using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IDelivery
    {
        void DeliverOrder(Order order);
    }
     public class PostDelivery : IDelivery
     {
         public void DeliverOrder(Order order)
         {
             Console.WriteLine("Доставка осуществляется почтой");
         }
     }
     public class CourierDelivery : IDelivery
     {
         public void DeliverOrder(Order order)
         {
             Console.WriteLine("Доставка осуществляется курьером");
         }
     }
}
