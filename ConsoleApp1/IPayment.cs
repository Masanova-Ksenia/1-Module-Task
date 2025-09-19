using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
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
}
