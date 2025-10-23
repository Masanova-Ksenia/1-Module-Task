using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork_7._3
{
    class Program
    {
        static void Main()
        {
            ChatMediator chat = new ChatMediator();

            User alice = new User(chat, "Алиса");
            User bob = new User(chat, "Боб");
            User charlie = new User(chat, "Чарли");

            chat.Register(alice);
            chat.Register(bob);
            chat.Register(charlie);

            alice.Send("Привет всем!");
            bob.Send("Привет, Алиса!");
            charlie.Send("Всем привет!");

            alice.SendPrivate("Как дела?", bob);

            chat.Remove(charlie);
            charlie.Send("Я все еще здесь!");

            chat.ShowLog();
        }
    }
}
