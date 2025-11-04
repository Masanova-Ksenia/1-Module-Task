using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._2
{
    public static class Program
    {
        public static void Main()
        {
            ILogger logger = new ConsoleLogger();

            var internalService = DeliveryServiceFactory.Create(DeliveryProviderType.Internal, logger);
            var r1 = internalService.DeliverOrder("ORDER-1001");
            Console.WriteLine($"Internal deliver -> success={r1.Success}, status={r1.Status}, cost={r1.Cost}");
            Console.WriteLine($"Internal estimated cost: {internalService.CalculateDeliveryCost("ORDER-1001")}\n");

            var adapterA = DeliveryServiceFactory.Create(DeliveryProviderType.ExternalA, logger);
            var r2 = adapterA.DeliverOrder("1002");
            Console.WriteLine($"AdapterA deliver -> success={r2.Success}, status={r2.Status}, cost={r2.Cost}");
            Console.WriteLine($"AdapterA status: {adapterA.GetDeliveryStatus("1002").Status}");
            Console.WriteLine($"AdapterA estimated cost: {adapterA.CalculateDeliveryCost("1002")}\n");

            var adapterB = DeliveryServiceFactory.Create(DeliveryProviderType.ExternalB, logger);
            var orderB = "B-ORD-777";
            var r3 = adapterB.DeliverOrder(orderB);
            Console.WriteLine($"AdapterB deliver -> success={r3.Success}, status={r3.Status}, cost={r3.Cost}");
            Console.WriteLine($"AdapterB status: {adapterB.GetDeliveryStatus(orderB).Status}");
            Console.WriteLine($"AdapterB estimated cost: {adapterB.CalculateDeliveryCost(orderB)}\n");

            var adapterC = DeliveryServiceFactory.Create(DeliveryProviderType.ExternalC, logger);
            var orderC = "C-AAA-123";
            var r4 = adapterC.DeliverOrder(orderC);
            Console.WriteLine($"AdapterC deliver -> success={r4.Success}, status={r4.Status}, cost={r4.Cost}");
            Console.WriteLine($"AdapterC status: {adapterC.GetDeliveryStatus(orderC).Status}");
            Console.WriteLine($"AdapterC estimated cost: {adapterC.CalculateDeliveryCost(orderC)}\n");

            var bad = adapterA.GetDeliveryStatus("nonexistent");
            Console.WriteLine($"Bad status -> success={bad.Success}, err={bad.ErrorMessage}");
        }
    }
}
