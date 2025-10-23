using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7._3
{
    public interface IMediator
    {
        void Register(User user);
        void Unregister(User user);
        void SendMessage(string fromUsername, string message);
        void SendPrivateMessage(string fromUsername, string toUsername, string message);
    }
    public class ChatRoom : IMediator
    {
        private readonly Dictionary<string, User> users = new Dictionary<string, User>(StringComparer.OrdinalIgnoreCase);

        public void Register(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(user.Username)) throw new ArgumentException("Username required", nameof(user));
            if (users.ContainsKey(user.Username))
            {
                Console.WriteLine($"Пользователь с именем '{user.Username}' уже в чате");
                return;
            }
            users[user.Username] = user;
            user.SetMediator(this);
            BroadcastSystemMessage($"Пользователь '{user.Username}' присоединился к чату");
        }

        public void Unregister(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (!users.Remove(user.Username))
            {
                Console.WriteLine($"Нельзя удалить: пользователь '{user.Username}' не найден в чате");
                return;
            }
            user.SetMediator(null);
            BroadcastSystemMessage($"Пользователь '{user.Username}' покинул чат");
        }

        public void SendMessage(string fromUsername, string message)
        {
            if (!users.ContainsKey(fromUsername))
            {
                Console.WriteLine($"Ошибка: отправитель '{fromUsername}' не в чате");
                return;
            }
            foreach (var kv in users)
            {
                if (!kv.Key.Equals(fromUsername, StringComparison.OrdinalIgnoreCase))
                    kv.Value.Receive(fromUsername, message);
            }
        }

        public void SendPrivateMessage(string fromUsername, string toUsername, string message)
        {
            if (!users.ContainsKey(fromUsername))
            {
                Console.WriteLine($"Ошибка: отправитель '{fromUsername}' не в чате");
                return;
            }
            if (!users.ContainsKey(toUsername))
            {
                Console.WriteLine($"Ошибка: получатель '{toUsername}' не в чате");
                return;
            }
            users[toUsername].ReceivePrivate(fromUsername, message);
        }

        private void BroadcastSystemMessage(string message)
        {
            foreach (var user in users.Values)
                user.ReceiveSystem(message);
        }
    }
    public class ChatUser : User
    {
        public ChatUser(string username) : base(username) { }

        public override void Receive(string fromUsername, string message)
        {
            Console.WriteLine($"[{fromUsername} -> {Username}]: {message}");
        }

        public override void ReceivePrivate(string fromUsername, string message)
        {
            Console.WriteLine($"[Личное от {fromUsername} -> {Username}]: {message}");
        }
    }
}