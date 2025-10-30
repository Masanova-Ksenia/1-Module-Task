using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8._2
{
    public class KaspiPaymentAdapter : IPaymentProcessor
    {
        public KaspiPaymentService _kaspiService;

        public KaspiPaymentAdapter(KaspiPaymentService kaspiService)
        {
            _kaspiService = kaspiService;
        }
        public void ProcessPayment(double amount)
        {
            _kaspiService.SendTransfer(amount);
        }
    }
}
