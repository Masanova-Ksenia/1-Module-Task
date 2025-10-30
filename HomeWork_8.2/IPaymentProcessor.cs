using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8._2
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }
    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Оплата {amount} через PayPal успешно выполнена.");
        }
    }
}
