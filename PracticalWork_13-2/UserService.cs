using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_13_2
{
    class UserService
    {
        private List<User> _users;
        public UserService(List<User> users)
        {
            _users = users;
        }
        public User GetUserById(int id) => _users.FirstOrDefault(u => u.ID == id);
        public User GetGuest() => _users.First(u => u.Role == Role.Guest);
        public List<User> GetAllUsers() => _users;
    }
}
