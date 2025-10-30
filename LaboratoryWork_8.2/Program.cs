using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_8._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            IPaymentProcessor processorKZ = PaymentProcessorFactory.GetProcessor("KZT");
            processorKZ.ProcessPayment(1500.0);
            processorKZ.RefundPayment(500.0);
            Console.WriteLine();

            IPaymentProcessor processorUSA = PaymentProcessorFactory.GetProcessor("USD");
            processorUSA.ProcessPayment(250.0);
            processorUSA.RefundPayment(100.0);
            Console.WriteLine();

            IPaymentProcessor processorEU = PaymentProcessorFactory.GetProcessor("EUR");
            processorEU.ProcessPayment(300.0);
            processorEU.RefundPayment(50.0);
            Console.WriteLine();

            IPaymentProcessor processorUnknown = PaymentProcessorFactory.GetProcessor("JPY");
            processorUnknown.ProcessPayment(1000.0);
            processorUnknown.RefundPayment(100.0);
        }
    }
}
