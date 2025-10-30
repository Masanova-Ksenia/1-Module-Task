using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8._2
{
    public class KaspiPaymentService
    {
        public void SendTransfer(double totalAmount)
        {
            Console.WriteLine($"Перевод на {totalAmount} выполнен через Kaspi.");
        }
    }
}
