using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_8._2
{
    public class ExternalPaymentSystemB
    {
        public void SendPayment(double amount)
        {
            Console.WriteLine($"Sending payment of {amount} via External Payment System B.");
        }
        public void ProcessRefund(double amount)
        {
            Console.WriteLine($"Processing refund of {amount} via External Payment System B.");
        }
    }
    public class PaymentAdapterB : IPaymentProcessor
    {
        private ExternalPaymentSystemB _externalSystemB;

        public PaymentAdapterB(ExternalPaymentSystemB externalSystemB)
        {
            _externalSystemB = externalSystemB;
        }
        public void ProcessPayment(double amount)
        {
            _externalSystemB.SendPayment(amount);
        }
        public void RefundPayment(double amount)
        {
            _externalSystemB.ProcessRefund(amount);
        }
    }
}
