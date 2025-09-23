using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрактическаяРабота_3
{
     public interface IPayment
     {
         void ProcessPayment(double amount);
     }
     public class CreditCard : IPayment
     {
         public void ProcessPayment(double amount)
         {
             Console.WriteLine("Оплата прошла кредитной картой");
         }
     }
     public class PaypPal : IPayment
     {
         public void ProcessPayment(double amount)
         {
             Console.WriteLine("Оплата прошла по PayPal");
         }
     }
    public class BankTransferPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine("Оплата прошла банковским переводом");
        }
    }
}
