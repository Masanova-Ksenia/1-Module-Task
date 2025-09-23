using System;
using System.Collections.Generic;

namespace ПрактическаяРабота_2
{
    class Program
    {
        static void Main()
        {
            var manager = new UserManager();

            manager.AddUser(new User("Анна", "anna@example.com", "Admin"));
            manager.AddUser(new User("Иван", "ivan@example.com", "User"));

            manager.PrintAllUsers();

            manager.UpdateUser("ivan@example.com", "Иван Петров", "Moderator");

            manager.RemoveUser("anna@example.com");

            manager.PrintAllUsers();
        }
    }
}