using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8._2
{
    public class StripePaymentAdapter : IPaymentProcessor
    {
        public StripePaymentService _stripeService;

        public StripePaymentAdapter(StripePaymentService stripeService)
        {
            _stripeService = stripeService;
        }
        public void ProcessPayment(double amount)
        {
            _stripeService.MakeTransaction(amount);
        }
    }
}
