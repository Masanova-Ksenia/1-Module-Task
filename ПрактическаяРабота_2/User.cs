using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрактическаяРабота_2
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public User(string name, string email, string role)
        {
            Name = name;
            Email = email;
            Role = role;
        }
        public override string ToString()
        {
            return $"{Name} ({Email}) - {Role}";
        }
    }
}