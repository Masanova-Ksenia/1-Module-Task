using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._2
{
    public class LogisticsAdapterB : IInternalDeliveryService
    {
        private readonly ExternalLogisticsServiceB _external;
        private readonly ILogger _logger;
        private readonly Dictionary<string, string> _mapOrderToTracking = new();
        public LogisticsAdapterB(ExternalLogisticsServiceB external, ILogger logger)
        {
            _external = external;
            _logger = logger;
        }
        public DeliveryResult DeliverOrder(string orderId)
        {
            try
            {
                _logger.Info($"AdapterB: DeliverOrder({orderId}) -> SendPackage(packageInfo)");
                var packageInfo = $"order:{orderId};date:{DateTime.UtcNow:O}";
                var tracking = _external.SendPackage(packageInfo);
                _mapOrderToTracking[orderId] = tracking;
                var cost = _external.GetPackageCost(tracking);
                return new DeliveryResult { Success = true, Status = "Shipped", Cost = cost };
            }
            catch (Exception ex)
            {
                _logger.Error($"AdapterB: Error delivering {orderId}: {ex.Message}");
                return new DeliveryResult { Success = false, ErrorMessage = ex.Message };
            }
        }
        public DeliveryResult GetDeliveryStatus(string orderId)
        {
            try
            {
                if (!_mapOrderToTracking.TryGetValue(orderId, out var tracking))
                {
                    _logger.Warn($"AdapterB: No tracking for {orderId}");
                    return new DeliveryResult { Success = false, ErrorMessage = "NotMapped" };
                }
                var status = _external.CheckPackageStatus(tracking);
                var cost = _external.GetPackageCost(tracking);
                return new DeliveryResult { Success = true, Status = status, Cost = cost };
            }
            catch (Exception ex)
            {
                _logger.Error($"AdapterB: Error getting status for {orderId}: {ex.Message}");
                return new DeliveryResult { Success = false, ErrorMessage = ex.Message };
            }
        }
        public decimal CalculateDeliveryCost(string orderId)
        {
            try
            {
                if (_mapOrderToTracking.TryGetValue(orderId, out var tracking))
                    return _external.GetPackageCost(tracking);
                var estimate = (decimal)(orderId.Length % 20 + 5);
                _logger.Info($"AdapterB: Estimated cost for {orderId} = {estimate}");
                return estimate;
            }
            catch (Exception ex)
            {
                _logger.Error($"AdapterB: Error estimating cost for {orderId}: {ex.Message}");
                return 0m;
            }
        }
    }
}
