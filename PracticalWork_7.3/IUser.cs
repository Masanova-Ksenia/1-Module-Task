using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_7._3
{
    public interface IUser
    {
        string Username { get; }
        bool IsAdmin { get; }
        void ReceiveChannelMessage(string channelName, string fromUsername, string message);
        void ReceivePrivateMessage(string fromUsername, string message);
        void ReceiveSystemMessage(string channelName, string message);
    }
    public class User : IUser
    {
        public string Username { get; }
        public bool IsAdmin { get; }
        private readonly IMediator _mediator;

        public User(string username, IMediator mediator, bool isAdmin = false)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            IsAdmin = isAdmin;
            _mediator.RegisterUser(this);
        }

        public void Join(string channelName) => _mediator.JoinChannel(channelName, this);
        public void Leave(string channelName) => _mediator.LeaveChannel(channelName, this);

        public void SendToChannel(string channelName, string message) => _mediator.SendMessageToChannel(channelName, Username, message, createIfMissing: true);

        public void SendPrivate(string toUsername, string message) => _mediator.SendPrivateMessage(Username, toUsername, message);

        public void SendCrossChannel(string fromChannel, string toChannel, string message) => _mediator.SendCrossChannelMessage(fromChannel, toChannel, Username, message, createIfMissing: true);

        public void BlockUserInChannel(string channelName, string username, TimeSpan duration)
        {
            if (!IsAdmin)
            {
                ReceiveSystemMessage(channelName, "Ошибка: команда блокировки доступна только администраторам.");
                return;
            }
            _mediator.BlockUser(channelName, username, duration);
        }

        public void ReceiveChannelMessage(string channelName, string fromUsername, string message)
        {
            Console.WriteLine($"[{channelName}] {fromUsername} -> {Username}: {message}");
        }

        public void ReceivePrivateMessage(string fromUsername, string message)
        {
            Console.WriteLine($"[Личное] {fromUsername} -> {Username}: {message}");
        }

        public void ReceiveSystemMessage(string channelName, string message)
        {
            if (string.IsNullOrEmpty(channelName))
                Console.WriteLine($"[Система] {message}");
            else
                Console.WriteLine($"[Система @ {channelName}] {message} -> {Username}");
        }
    }
}
