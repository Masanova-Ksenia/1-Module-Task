using PracticalWork_8._2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._2
{
    public class LogisticsAdapterC : IInternalDeliveryService
    {
        private readonly ExternalLogisticsServiceC _external;
        private readonly ILogger _logger;
        private readonly Dictionary<string, Guid> _mapOrderToGuid = new();
        public LogisticsAdapterC(ExternalLogisticsServiceC external, ILogger logger)
        {
            _external = external;
            _logger = logger;
        }
        public DeliveryResult DeliverOrder(string orderId)
        {
            try
            {
                _logger.Info($"AdapterC: DeliverOrder({orderId}) -> DispatchOrder(Guid)");
                var guid = Guid.NewGuid();
                var (success, state, cost) = _external.DispatchOrder(guid);
                if (success) _mapOrderToGuid[orderId] = guid;
                return new DeliveryResult { Success = success, Status = state, Cost = cost };
            }
            catch (Exception ex)
            {
                _logger.Error($"AdapterC: Error delivering {orderId}: {ex.Message}");
                return new DeliveryResult { Success = false, ErrorMessage = ex.Message };
            }
        }
        public DeliveryResult GetDeliveryStatus(string orderId)
        {
            try
            {
                if (!_mapOrderToGuid.TryGetValue(orderId, out var guid))
                {
                    _logger.Warn($"AdapterC: No GUID for {orderId}");
                    return new DeliveryResult { Success = false, ErrorMessage = "NotMapped" };
                }
                var state = _external.GetDispatchState(guid);
                var cost = _external.QueryCost(guid);
                return new DeliveryResult { Success = true, Status = state, Cost = cost };
            }
            catch (Exception ex)
            {
                _logger.Error($"AdapterC: Error getting status for {orderId}: {ex.Message}");
                return new DeliveryResult { Success = false, ErrorMessage = ex.Message };
            }
        }
        public decimal CalculateDeliveryCost(string orderId)
        {
            try
            {
                if (_mapOrderToGuid.TryGetValue(orderId, out var guid))
                    return _external.QueryCost(guid);
                var tempGuid = Guid.NewGuid();
                var cost = _external.QueryCost(tempGuid);
                _logger.Info($"AdapterC: Estimated cost for {orderId} = {cost}");
                return cost;
            }
            catch (Exception ex)
            {
                _logger.Error($"AdapterC: Error estimating cost for {orderId}: {ex.Message}");
                return 0m;
            }
        }
    }
}
