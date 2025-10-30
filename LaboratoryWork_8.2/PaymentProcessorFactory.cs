using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_8._2
{
    public static class PaymentProcessorFactory
    {
        public static IPaymentProcessor GetProcessor(string regionOrCurrency)
        {
            switch (regionOrCurrency.ToUpper())
            {
                case "USD":
                case "USA":
                    Console.WriteLine("Using External Payment System A (USA / USD)");
                    return new PaymentAdapterA(new ExternalPaymentSystemA());

                case "EUR":
                case "EU":
                    Console.WriteLine("Using External Payment System B (EU / EUR)");
                    return new PaymentAdapterB(new ExternalPaymentSystemB());

                case "KZT":
                case "KZ":
                    Console.WriteLine("Using Internal Payment System (Kazakhstan / KZT)");
                    return new InternalPaymentProcessor();

                default:
                    Console.WriteLine("Defaulting to Internal Payment System");
                    return new InternalPaymentProcessor();
            }
        }
    }
}
