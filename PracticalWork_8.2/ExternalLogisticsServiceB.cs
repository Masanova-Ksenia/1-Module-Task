using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._2
{
    public class ExternalLogisticsServiceB
    {
        private readonly ILogger _logger;
        private readonly Dictionary<string, (string status, decimal cost)> _db = new();
        public ExternalLogisticsServiceB(ILogger logger)
        {
            _logger = logger;
        }
        public string SendPackage(string packageInfo)
        {
            var tracking = Guid.NewGuid().ToString().Substring(0, 8);
            var cost = (decimal)(packageInfo.Length % 20 + 10);
            _db[tracking] = ("Shipped", cost);
            _logger.Info($"ExternalB: Package sent: {tracking}, info={packageInfo}, cost={cost}");
            return tracking;
        }
        public string CheckPackageStatus(string trackingCode)
        {
            if (_db.TryGetValue(trackingCode, out var value))
            {
                _logger.Info($"ExternalB: Status for {trackingCode} -> {value.status}");
                return value.status;
            }
            _logger.Warn($"ExternalB: Tracking {trackingCode} not found");
            return "Unknown";
        }
        public decimal GetPackageCost(string trackingCode)
        {
            if (_db.TryGetValue(trackingCode, out var v)) return v.cost;
            return 0m;
        }
    }
}
