using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрактическаяРабота_2
{
    public class UserManager
    {
        private readonly List<User> users = new List<User>();
        public void AddUser(User user)
        {
            users.Add(user);
            Console.WriteLine($"Добавлен: {user}");
        }
        public void RemoveUser(string email)
        {
            var user = FindUserByEmail(email);
            if (user != null)
            {
                users.Remove(user);
                Console.WriteLine($"Удалён: {user}");
            }
            else
            {
                Console.WriteLine($"Пользователь с email {email} не найден.");
            }
        }
        public void UpdateUser(string email, string newName, string newRole)
        {
            var user = FindUserByEmail(email);
            if (user != null)
            {
                user.Name = newName;
                user.Role = newRole;
                Console.WriteLine($"Обновлён: {user}");
            }
            else
            {
                Console.WriteLine($"Пользователь с email {email} не найден.");
            }
        }

        private User FindUserByEmail(string email)
        {
            return users.Find(u => u.Email == email);
        }
        public void PrintAllUsers()
        {
            Console.WriteLine("\nТекущий список пользователей:");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}