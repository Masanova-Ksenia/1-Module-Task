using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8._2
{
    class Program
    {
        static void Main(string[] args)
        {
            IPaymentProcessor paypal = new PayPalPaymentProcessor();
            paypal.ProcessPayment(5000.0);

            StripePaymentService stripe = new StripePaymentService();
            IPaymentProcessor stripeAdapter = new StripePaymentAdapter(stripe);
            stripeAdapter.ProcessPayment(7500.0);

            KaspiPaymentService kaspi = new KaspiPaymentService();
            IPaymentProcessor kaspiAdapter = new KaspiPaymentAdapter(kaspi);
            kaspiAdapter.ProcessPayment(3000.0);
        }
    }
}
