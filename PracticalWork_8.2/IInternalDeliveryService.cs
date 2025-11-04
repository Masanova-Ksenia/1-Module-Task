using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._2
{
    public interface IInternalDeliveryService
    {
        DeliveryResult DeliverOrder(string orderId);
        DeliveryResult GetDeliveryStatus(string orderId);
        decimal CalculateDeliveryCost(string orderId);
    }
}
