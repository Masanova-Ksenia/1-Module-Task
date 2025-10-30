using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_8._2
{
    public class ExternalPaymentSystemA
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Making payment of {amount} via External Payment System A.");
        }
        public void MakeRefund(double amount)
        {
            Console.WriteLine($"Making refund of {amount} via External Payment System A.");
        }
    }
    public class PaymentAdapterA : IPaymentProcessor
    {
        private ExternalPaymentSystemA _externalSystemA;

        public PaymentAdapterA(ExternalPaymentSystemA externalSystemA)
        {
            _externalSystemA = externalSystemA;
        }
        public void ProcessPayment(double amount)
        {
            _externalSystemA.MakePayment(amount);
        }
        public void RefundPayment(double amount)
        {
            _externalSystemA.MakeRefund(amount);
        }
    }
}
