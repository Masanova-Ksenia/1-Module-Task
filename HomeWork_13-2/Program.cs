using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13_2
{
    class Program
    {
        static void Main()
        {
            TicketMachine machine = new TicketMachine();
            machine.SelectTicket();
            machine.InsertMoney();
            machine.DispenseTicket();
            machine.SelectTicket();
        }
    }
}
