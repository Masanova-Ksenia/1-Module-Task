using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_13_3
{
    class OrderProcessor
    {
        public void Process(Order order)
        {
            if (!order.IsPaid)
            {
                Console.WriteLine("Заказ не оплачен. Обработка невозможна.");
                return;
            }
            order.IsProcessed = true;
            Console.WriteLine("Заказ обработан на складе.");
        }
        public void Ship(Order order)
        {
            if (!order.IsProcessed)
            {
                Console.WriteLine("Заказ ещё не обработан. Отправка невозможна.");
                return;
            }
            order.IsShipped = true;
            Console.WriteLine("Заказ отправлен на доставку.");
        }
    }
}
