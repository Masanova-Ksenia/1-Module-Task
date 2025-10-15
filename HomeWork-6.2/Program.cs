using System;

namespace HomeWork_6._2
{
    class Program
    {
        static void Main()
        {
            CurrencyExchange exchange = new CurrencyExchange();

            var bank = new BankObserver();
            var investor = new InvestorObserver();
            var news = new NewsAgencyObserver();

            exchange.Attach(bank);
            exchange.Attach(investor);
            exchange.Attach(news);

            exchange.UsdToKztRate = 480;
            exchange.UsdToKztRate = 505;

            exchange.Detach(news);

            exchange.UsdToKztRate = 495;
        }
    }
}