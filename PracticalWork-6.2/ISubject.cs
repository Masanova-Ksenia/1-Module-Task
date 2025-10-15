using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_6._2
{
    public interface ISubject
    {
        void Subscribe(string symbol, IObserver observer);
        void Unsubscribe(string symbol, IObserver observer);
        Task PublishPriceAsync(string symbol, decimal price);
    }
}
