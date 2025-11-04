using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._2
{
    public class ExternalLogisticsServiceC
    {
        private readonly ILogger _logger;
        private readonly Dictionary<Guid, (string state, decimal cost)> _db = new();
        public ExternalLogisticsServiceC(ILogger logger)
        {
            _logger = logger;
        }
        public (bool success, string state, decimal cost) DispatchOrder(Guid orderGuid)
        {
            _logger.Info($"ExternalC: DispatchOrder({orderGuid})");
            var cost = (decimal)(orderGuid.ToString().Length % 30 + 15);
            _db[orderGuid] = ("EnRoute", cost);
            return (true, "EnRoute", cost);
        }
        public string GetDispatchState(Guid orderGuid)
        {
            if (_db.TryGetValue(orderGuid, out var v)) return v.state;
            return "NotFound";
        }
        public decimal QueryCost(Guid orderGuid)
        {
            if (_db.TryGetValue(orderGuid, out var v)) return v.cost;
            return 0m;
        }
    }
}
