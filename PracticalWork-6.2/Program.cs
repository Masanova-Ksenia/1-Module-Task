using PracticalWork_6._2;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StockExchangeObserver
{
    class Program
    {
        static async Task Main()
        {
            var exchange = new StockExchange();
            exchange.AddOrUpdateSymbol("AAPL", 150m);
            exchange.AddOrUpdateSymbol("MSFT", 310m);
            exchange.AddOrUpdateSymbol("TSLA", 700m);

            var trader1 = new Trader("TraderAlice");
            var trader2 = new Trader("TraderBob");
            var bot1 = new TradingBot("BotAlpha", buyBelow: 145m, sellAbove: 160m);
            var bot2 = new TradingBot("BotBeta", buyBelow: 300m, sellAbove: 330m);
            var email1 = new EmailNotifier("alerts@alice.com");
            var email2 = new EmailNotifier("highprice@service.com", threshold: 650m);

            exchange.Subscribe("AAPL", trader1);
            exchange.Subscribe("AAPL", bot1);
            exchange.Subscribe("AAPL", email1);

            exchange.Subscribe("MSFT", trader2);
            exchange.Subscribe("MSFT", bot2);
            exchange.Subscribe("MSFT", email1);

            exchange.Subscribe("TSLA", trader1);
            exchange.Subscribe("TSLA", bot1);
            exchange.Subscribe("TSLA", email2);

            var rnd = new Random();
            var symbols = new List<string> { "AAPL", "MSFT", "TSLA" };

            for (int i = 0; i < 10; i++)
            {
                foreach (var s in symbols)
                {
                    var basePrice = exchange.GetPrice(s) ?? 100m;
                    var change = (decimal)(rnd.NextDouble() * 10 - 5);
                    var newPrice = Math.Max(1m, basePrice + change);
                    await exchange.PublishPriceAsync(s, Math.Round(newPrice, 2));
                }
                await Task.Delay(700);
            }

            Logger.Log("Отчёт по уведомлениям:");
            foreach (var r in exchange.GetNotificationsReport())
            {
                Logger.Log($"{r.ObserverId} получил уведомлений: {r.Count}");
            }

            Logger.Log("Список подписчиков на AAPL:");
            foreach (var id in exchange.GetSubscribers("AAPL"))
            {
                Logger.Log(id);
            }

            Logger.Log("Готово.");
        }
    }
}
