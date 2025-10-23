using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_7._3
{
    public class Program
    {
        public static void Main()
        {
            var mediator = new ChatMediator();

            var mary = new User("Mary", mediator);
            var john = new User("John", mediator);
            var robert = new User("Robert", mediator);
            var admin = new User("Admin", mediator, isAdmin: true);

            mediator.CreateChannel("general");
            mediator.CreateChannel("random");

            mary.Join("general");
            john.Join("general");
            robert.Join("random");
            admin.Join("general");
            admin.Join("random");

            mary.SendToChannel("general", "Всем привет!");
            john.SendToChannel("general", "Привет, Mary!");
            robert.SendToChannel("random", "Кто тут любит кофе?");
            mary.SendPrivate("Robert", "Я перехожу в random, подождите меня");
            mary.Join("random");
            mary.SendToChannel("random", "Присоединилась к разговору про кофе");

            Console.WriteLine("\n--- Кросс-канал ---");
            mary.SendCrossChannel("random", "general", "Отправка из random в general");

            Console.WriteLine("\n--- Приватное сообщение ---");
            john.SendPrivate("Mary", "Тсс, секрет");

            Console.WriteLine("\n--- Ошибки: отправка в канал, где не состоишь ---");
            john.SendToChannel("random", "Я не в random, проверка");

            Console.WriteLine("\n--- Автосоздание канала при отправке ---");
            admin.SendToChannel("new-channel", "Создал новый канал автоматически!");

            Console.WriteLine("\n--- Блокировка пользователя ---");
            admin.BlockUserInChannel("general", "John", TimeSpan.FromSeconds(5));
            Thread.Sleep(200);
            john.SendToChannel("general", "Пытаюсь писать после блокировки");
            Thread.Sleep(6000);
            john.SendToChannel("general", "Пишу после истечения блокировки");

            Console.WriteLine("\n--- Попытка блокировки не-админом ---");
            mary.BlockUserInChannel("general", "John", TimeSpan.FromSeconds(5));

            Console.WriteLine("\n--- Ошибка: отправка в несуществующий канал без создания ---");
            mediator.SendMessageToChannel("ghost", "Mary", "Проверка", createIfMissing: false);
        }
    }
}
