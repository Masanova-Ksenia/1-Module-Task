using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_6._2
{
    public interface IObserver
    {
        string Id { get; }
        Task UpdateAsync(Stock stock);
    }
    public class Trader : IObserver
    {
        public string Id { get; }

        public Trader(string id)
        {
            Id = id;
        }

        public Task UpdateAsync(Stock stock)
        {
            Logger.Log($"Trader {Id} received update: {stock.Symbol} = {stock.Price}");
            return Task.CompletedTask;
        }
    }
    public class TradingBot : IObserver
    {
        public string Id { get; }
        private readonly decimal _buyBelow;
        private readonly decimal _sellAbove;

        public TradingBot(string id, decimal buyBelow, decimal sellAbove)
        {
            Id = id;
            _buyBelow = buyBelow;
            _sellAbove = sellAbove;
        }

        public Task UpdateAsync(Stock stock)
        {
            if (stock.Price <= _buyBelow)
            {
                Logger.Log($"Bot {Id}: BUY {stock.Symbol} at {stock.Price}");
            }
            else if (stock.Price >= _sellAbove)
            {
                Logger.Log($"Bot {Id}: SELL {stock.Symbol} at {stock.Price}");
            }
            else
            {
                Logger.Log($"Bot {Id}: HOLD {stock.Symbol} at {stock.Price}");
            }
            return Task.CompletedTask;
        }
    }
    public class EmailNotifier : IObserver
    {
        public string Id { get; }
        private readonly decimal? _threshold;
        public EmailNotifier(string id, decimal? threshold = null)
        {
            Id = id;
            _threshold = threshold;
        }

        public async Task UpdateAsync(Stock stock)
        {
            if (_threshold.HasValue && stock.Price < _threshold.Value)
                return;

            await Task.Run(() =>
            {
                Logger.Log($"Email to {Id}: {stock.Symbol} price {stock.Price}");
            });
        }
    }
}

