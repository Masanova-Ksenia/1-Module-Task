using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрактическаяРабота_3
{
    public interface INotification
    {
        void SendNotification(string message);
    }
    public class EmailNotification : INotification
    {
        public void SendNotification(string message)
        {
            Console.WriteLine("Email уведомление: " + message);
        }
    }
    public class SmsNotification : INotification
    {
        public void SendNotification(string message)
        {
            Console.WriteLine("Sms уведомление: " + message);
        }
    }
}
