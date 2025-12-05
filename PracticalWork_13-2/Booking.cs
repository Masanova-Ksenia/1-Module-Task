using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_13_2
{
    class Booking
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
        public string Status { get; set; }
    }
}
