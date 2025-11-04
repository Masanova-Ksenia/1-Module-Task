using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._2
{
    public class InternalDeliveryService : IInternalDeliveryService
    {
        private readonly ILogger _logger;
        private readonly Dictionary<string, (string status, decimal cost)> _store = new();
        public InternalDeliveryService(ILogger logger)
        {
            _logger = logger;
        }
        public DeliveryResult DeliverOrder(string orderId)
        {
            try
            {
                _logger.Info($"Internal: Start delivery for {orderId}");
                var cost = new Random().Next(100, 1000) / 10m;
                _store[orderId] = ("InTransit", cost);
                _logger.Info($"Internal: Order {orderId} shipped. Cost={cost}");
                return new DeliveryResult { Success = true, Status = "InTransit", Cost = cost };
            }
            catch (Exception ex)
            {
                _logger.Error($"Internal: Error delivering {orderId}: {ex.Message}");
                return new DeliveryResult { Success = false, ErrorMessage = ex.Message };
            }
        }
        public DeliveryResult GetDeliveryStatus(string orderId)
        {
            try
            {
                if (_store.TryGetValue(orderId, out var data))
                {
                    _logger.Info($"Internal: Status for {orderId} = {data.status}");
                    return new DeliveryResult { Success = true, Status = data.status, Cost = data.cost };
                }
                _logger.Warn($"Internal: No record for {orderId}");
                return new DeliveryResult { Success = false, ErrorMessage = "NotFound" };
            }
            catch (Exception ex)
            {
                _logger.Error($"Internal: Error getting status for {orderId}: {ex.Message}");
                return new DeliveryResult { Success = false, ErrorMessage = ex.Message };
            }
        }
        public decimal CalculateDeliveryCost(string orderId)
        {
            if (_store.TryGetValue(orderId, out var data)) return data.cost;
            var estimate = 50m;
            _logger.Info($"Internal: Estimate cost for {orderId} = {estimate}");
            return estimate;
        }
    }
}
