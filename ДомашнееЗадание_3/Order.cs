using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДомашнееЗадание_3
{
    public class Order
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
    public class OrderCalculator
    {
        public double CalculateTotalPrice(Order order)
        {
            return order.Quantity * order.Price * 0.9;
        }
    }
    public class PaymentProcessor
    {
        public void ProcessPayment(string paymentDetails)
        {
            Console.WriteLine("Payment processed using: " + paymentDetails);
        }
    }
    public class NotificationService
    {
        public void SendConfirmationEmail(string email)
        {
            Console.WriteLine("Confirmation email sent to: " + email);
        }
    }
}