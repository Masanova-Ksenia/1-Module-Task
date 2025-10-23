using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7._3
{
    public class Program
    {
        public static void Main()
        {
            var chat = new ChatRoom();

            var robert = new ChatUser("Robert");
            var john = new ChatUser("John");
            var mary = new ChatUser("Mary");

            chat.Register(robert);
            chat.Register(john);
            chat.Register(mary);

            mary.Send("Привет всем!");
            john.Send("Привет, Мэри!");
            robert.SendPrivate("Mary", "Привет, Мэри, у меня вопрос");
            john.SendPrivate("Дейв", "Это приватное сообщение тому, кого нет");

            chat.Unregister(john);

            john.Send("Я попытался отправить сообщение после выхода");

            mary.Send("Джон уже ушёл");
        }
    }
}
