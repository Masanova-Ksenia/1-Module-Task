using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_7._3
{
    public class ChannelMediator
    {
        public string ChannelName { get; }
        private readonly ChatMediator _mediator;
        private readonly Dictionary<string, IUser> _members = new Dictionary<string, IUser>(StringComparer.OrdinalIgnoreCase);
        private readonly HashSet<string> _blocked = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly object _lock = new object();

        public ChannelMediator(string channelName, ChatMediator mediator)
        {
            ChannelName = channelName;
            _mediator = mediator;
        }

        public void AddUser(IUser user)
        {
            if (user == null) return;
            lock (_lock)
            {
                if (_members.ContainsKey(user.Username)) return;
                _members[user.Username] = user;
            }
            BroadcastSystem($"{user.Username} подключился к каналу {ChannelName}");
        }

        public void RemoveUser(IUser user)
        {
            if (user == null) return;
            lock (_lock)
            {
                if (!_members.Remove(user.Username))
                {
                    user.ReceiveSystemMessage(ChannelName, $"Вы не состоите в канале {ChannelName}");
                    return;
                }
            }
            BroadcastSystem($"{user.Username} покинул канал {ChannelName}");
        }

        internal void RemoveUserSilently(IUser user)
        {
            lock (_lock) _members.Remove(user.Username);
        }

        public void BroadcastMessage(string fromUsername, string message)
        {
            IUser fromUser = _mediator.GetUser(fromUsername);
            if (fromUser == null) return;
            lock (_lock)
            {
                if (!_members.ContainsKey(fromUsername))
                {
                    fromUser.ReceiveSystemMessage(ChannelName, $"Вы не состоите в канале {ChannelName}");
                    return;
                }
                if (_blocked.Contains(fromUsername))
                {
                    fromUser.ReceiveSystemMessage(ChannelName, $"Вы заблокированы в канале {ChannelName} и не можете отправлять сообщения.");
                    return;
                }
                foreach (var kv in _members.Values)
                {
                    if (!kv.Username.Equals(fromUsername, StringComparison.OrdinalIgnoreCase))
                        kv.ReceiveChannelMessage(ChannelName, fromUsername, message);
                }
            }
        }

        public void BroadcastCrossChannelMessage(string fromChannel, string fromUsername, string message)
        {
            IUser fromUser = _mediator.GetUser(fromUsername);
            if (fromUser == null) return;
            lock (_lock)
            {
                if (_blocked.Contains(fromUsername))
                {
                    fromUser.ReceiveSystemMessage(ChannelName, $"Вы заблокированы в канале {ChannelName} и не можете получать кросс-канальные сообщения.");
                    return;
                }
                foreach (var kv in _members.Values)
                {
                    if (!kv.Username.Equals(fromUsername, StringComparison.OrdinalIgnoreCase))
                        kv.ReceiveChannelMessage(ChannelName, $"{fromUsername}@{fromChannel}", message);
                }
            }
        }

        public void BroadcastSystem(string message)
        {
            List<IUser> snapshot;
            lock (_lock) snapshot = _members.Values.ToList();
            foreach (var u in snapshot) u.ReceiveSystemMessage(ChannelName, message);
        }

        public void BlockUser(string username, TimeSpan duration)
        {
            lock (_lock)
            {
                _blocked.Add(username);
            }
            BroadcastSystem($"Пользователь '{username}' был временно заблокирован в канале {ChannelName} на {duration.TotalSeconds} сек.");
            Task.Run(async () =>
            {
                await Task.Delay(duration);
                UnblockUser(username);
            });
        }

        public void UnblockUser(string username)
        {
            bool removed = false;
            lock (_lock) removed = _blocked.Remove(username);
            if (removed) BroadcastSystem($"Пользователь '{username}' был разблокирован в канале {ChannelName}.");
        }
    }
}
