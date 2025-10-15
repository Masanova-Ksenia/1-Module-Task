using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_6._2
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
    public class CurrencyExchange : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private decimal _usdToKztRate;

        public decimal UsdToKztRate
        {
            get => _usdToKztRate;
            set
            {
                if (_usdToKztRate != value)
                {
                    _usdToKztRate = value;
                    Console.WriteLine($"\n>>> Курс доллара изменился: 1 USD = {_usdToKztRate} KZT");
                    Notify();
                }
            }
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine($"{observer.GetType().Name} подписан на обновления курса.");
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine($"{observer.GetType().Name} отписан от обновлений курса.");
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_usdToKztRate);
            }
        }
    }
    public class BankObserver : IObserver
    {
        public void Update(decimal usdToKztRate)
        {
            Console.WriteLine($"Банк: обновился внутренний курс обмена — теперь {usdToKztRate} тенге за доллар.");
        }
    }
    public class InvestorObserver : IObserver
    {
        public void Update(decimal usdToKztRate)
        {
            if (usdToKztRate > 500)
                Console.WriteLine($"Инвестор: доллар растёт. Целесообразно купить больше акций в долларах.");
            else
                Console.WriteLine($"Инвестор: доллар падает, время продавать");
        }
    }
    public class NewsAgencyObserver : IObserver
    {
        public void Update(decimal usdToKztRate)
        {
            Console.WriteLine($"Новости: курс доллара изменился и теперь составляет {usdToKztRate} тенге.");
        }
    }
}
