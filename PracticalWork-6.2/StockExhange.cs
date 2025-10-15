using System;
using System.Collections.Concurrent;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_6._2
{
    public class StockExchange : ISubject
    {
        private readonly ConcurrentDictionary<string, List<IObserver>> _subs = new ConcurrentDictionary<string, List<IObserver>>();
        private readonly ConcurrentDictionary<string, decimal> _prices = new ConcurrentDictionary<string, decimal>();
        private readonly ConcurrentDictionary<string, int> _notificationsCount = new ConcurrentDictionary<string, int>();

        public void AddOrUpdateSymbol(string symbol, decimal initialPrice)
        {
            _prices[symbol] = initialPrice;
            _subs.TryAdd(symbol, new List<IObserver>());
            Logger.Log($"Symbol added/updated: {symbol} = {initialPrice}");
        }

        public void Subscribe(string symbol, IObserver observer)
        {
            var list = _subs.GetOrAdd(symbol, _ => new List<IObserver>());
            lock (list)
            {
                if (!list.Contains(observer)) list.Add(observer);
            }
            _notificationsCount.TryAdd(observer.Id, 0);
            Logger.Log($"{observer.Id} subscribed to {symbol}");
        }

        public void Unsubscribe(string symbol, IObserver observer)
        {
            if (_subs.TryGetValue(symbol, out var list))
            {
                lock (list)
                {
                    list.Remove(observer);
                }
            }
            Logger.Log($"{observer.Id} unsubscribed from {symbol}");
        }

        public async Task PublishPriceAsync(string symbol, decimal price)
        {
            _prices[symbol] = price;
            var stock = new Stock(symbol, price);
            Logger.Log($"Price update: {symbol} -> {price}");
            if (_subs.TryGetValue(symbol, out var list))
            {
                List<IObserver> snapshot;
                lock (list)
                {
                    snapshot = list.ToList();
                }

                var tasks = snapshot.Select(async obs =>
                {
                    try
                    {
                        await obs.UpdateAsync(stock);
                        _notificationsCount.AddOrUpdate(obs.Id, 1, (_, v) => v + 1);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($"Error notifying {obs.Id}: {ex.Message}");
                    }
                });

                await Task.WhenAll(tasks);
            }
        }

        public IEnumerable<(string ObserverId, int Count)> GetNotificationsReport()
        {
            return _notificationsCount.Select(kv => (kv.Key, kv.Value));
        }

        public IEnumerable<string> GetSubscribers(string symbol)
        {
            if (_subs.TryGetValue(symbol, out var list))
            {
                lock (list) { return list.Select(o => o.Id).ToList(); }
            }
            return Enumerable.Empty<string>();
        }

        public decimal? GetPrice(string symbol) => _prices.TryGetValue(symbol, out var p) ? p : (decimal?)null;
    }
}
