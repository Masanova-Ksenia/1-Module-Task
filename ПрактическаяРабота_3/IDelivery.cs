using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрактическаяРабота_3
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
    public class PickUpPointDelivery : IDelivery
    {
        public void DeliverOrder(Order order)
        {
            Console.WriteLine("Доставка осуществляется до места выдачи");
        }
    }
}
