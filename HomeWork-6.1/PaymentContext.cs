using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_6
{
    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void ExecutePayment(decimal amount)
        {
            if (_paymentStrategy == null)
            {
                Console.WriteLine("Ошибка: стратегия оплаты не выбрана");
                return;
            }

            _paymentStrategy.Pay(amount);
        }
    }
}
