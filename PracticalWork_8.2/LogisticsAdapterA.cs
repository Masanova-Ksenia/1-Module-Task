using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._2
{
    public class LogisticsAdapterA : IInternalDeliveryService
    {
        private readonly ExternalLogisticsServiceA _external;
        private readonly ILogger _logger;
        private readonly Dictionary<string, int> _mapOrderToShipment = new();
        public LogisticsAdapterA(ExternalLogisticsServiceA external, ILogger logger)
        {
            _external = external;
            _logger = logger;
        }
        public DeliveryResult DeliverOrder(string orderId)
        {
            try
            {
                _logger.Info($"AdapterA: DeliverOrder({orderId}) -> map to ShipItem(int)");
                if (!int.TryParse(FilterDigits(orderId), out var itemId)) itemId = orderId.GetHashCode();
                var shipmentId = _external.ShipItem(itemId);
                _mapOrderToShipment[orderId] = shipmentId;
                var cost = _external.GetShipmentCost(shipmentId);
                return new DeliveryResult { Success = true, Status = "Dispatched", Cost = cost };
            }
            catch (Exception ex)
            {
                _logger.Error($"AdapterA: Error delivering {orderId}: {ex.Message}");
                return new DeliveryResult { Success = false, ErrorMessage = ex.Message };
            }
        }
        public DeliveryResult GetDeliveryStatus(string orderId)
        {
            try
            {
                if (!_mapOrderToShipment.TryGetValue(orderId, out var shipmentId))
                {
                    _logger.Warn($"AdapterA: No shipment mapping for {orderId}");
                    return new DeliveryResult { Success = false, ErrorMessage = "NotMapped" };
                }
                var status = _external.TrackShipment(shipmentId);
                var cost = _external.GetShipmentCost(shipmentId);
                return new DeliveryResult { Success = true, Status = status, Cost = cost };
            }
            catch (Exception ex)
            {
                _logger.Error($"AdapterA: Error getting status for {orderId}: {ex.Message}");
                return new DeliveryResult { Success = false, ErrorMessage = ex.Message };
            }
        }
        public decimal CalculateDeliveryCost(string orderId)
        {
            try
            {
                if (_mapOrderToShipment.TryGetValue(orderId, out var shipmentId))
                    return _external.GetShipmentCost(shipmentId);
                if (!int.TryParse(FilterDigits(orderId), out var itemId)) itemId = Math.Abs(orderId.GetHashCode());
                var temporary = _external.GetShipmentCost(_external.ShipItem(itemId));
                _logger.Info($"AdapterA: Estimated cost for {orderId} = {temporary}");
                return temporary;
            }
            catch (Exception ex)
            {
                _logger.Error($"AdapterA: Error estimating cost for {orderId}: {ex.Message}");
                return 0m;
            }
        }
        private string FilterDigits(string s)
        {
            var chars = System.Linq.Enumerable.Where(s, char.IsDigit);
            return new string(System.Linq.Enumerable.ToArray(chars));
        }
    }
}
