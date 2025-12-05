using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_13_2
{
    enum Role
    {
        Guest,
        User,
        Admin
    }
    class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
