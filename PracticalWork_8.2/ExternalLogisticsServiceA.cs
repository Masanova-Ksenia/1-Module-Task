using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._2
{
    public class ExternalLogisticsServiceA
    {
        private readonly ILogger _logger;
        private readonly Dictionary<int, (int shipmentId, string status, decimal cost)> _db = new();
        private int _nextShipmentId = 1;
        public ExternalLogisticsServiceA(ILogger logger)
        {
            _logger = logger;
        }
        public int ShipItem(int itemId)
        {
            _logger.Info($"ExternalA: ShipItem({itemId}) requested");
            var shipmentId = _nextShipmentId++;
            _db[itemId] = (shipmentId, "Dispatched", (decimal)(itemId % 10 + 5) * 1.5m);
            _logger.Info($"ExternalA: Created shipment {shipmentId} for item {itemId}");
            return shipmentId;
        }
        public string TrackShipment(int shipmentId)
        {
            foreach (var kv in _db)
            {
                if (kv.Value.shipmentId == shipmentId)
                {
                    _logger.Info($"ExternalA: TrackShipment({shipmentId}) -> {kv.Value.status}");
                    return kv.Value.status;
                }
            }
            _logger.Warn($"ExternalA: Shipment {shipmentId} not found");
            return "Unknown";
        }
        public decimal GetShipmentCost(int shipmentId)
        {
            foreach (var kv in _db)
            {
                if (kv.Value.shipmentId == shipmentId) return kv.Value.cost;
            }
            return 0m;
        }
    }
}
