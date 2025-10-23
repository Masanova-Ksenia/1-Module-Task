using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_7._3
{
    public interface IMediator
    {
        void RegisterUser(IUser user);
        void UnregisterUser(IUser user);
        void CreateChannel(string channelName);
        bool ChannelExists(string channelName);
        void JoinChannel(string channelName, IUser user);
        void LeaveChannel(string channelName, IUser user);
        void SendMessageToChannel(string channelName, string fromUsername, string message, bool createIfMissing = true);
        void SendPrivateMessage(string fromUsername, string toUsername, string message);
        void SendCrossChannelMessage(string fromChannel, string toChannel, string fromUsername, string message, bool createIfMissing = true);
        void BlockUser(string channelName, string username, TimeSpan duration);
        void UnblockUser(string channelName, string username);
    }
    public class ChatMediator : IMediator
    {
        private readonly Dictionary<string, ChannelMediator> _channels = new Dictionary<string, ChannelMediator>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, IUser> _users = new Dictionary<string, IUser>(StringComparer.OrdinalIgnoreCase);
        private readonly object _lock = new object();

        public void RegisterUser(IUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            lock (_lock)
            {
                if (!_users.ContainsKey(user.Username))
                {
                    _users[user.Username] = user;
                }
            }
        }

        public void UnregisterUser(IUser user)
        {
            if (user == null) return;
            lock (_lock)
            {
                _users.Remove(user.Username);
                foreach (var ch in _channels.Values) ch.RemoveUserSilently(user);
            }
        }

        public void CreateChannel(string channelName)
        {
            if (string.IsNullOrWhiteSpace(channelName)) throw new ArgumentException("channelName");
            lock (_lock)
            {
                if (!_channels.ContainsKey(channelName))
                    _channels[channelName] = new ChannelMediator(channelName, this);
            }
        }

        public bool ChannelExists(string channelName)
        {
            lock (_lock) return _channels.ContainsKey(channelName);
        }

        public void JoinChannel(string channelName, IUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            lock (_lock)
            {
                if (!_channels.ContainsKey(channelName))
                    _channels[channelName] = new ChannelMediator(channelName, this);
                _channels[channelName].AddUser(user);
            }
        }

        public void LeaveChannel(string channelName, IUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            lock (_lock)
            {
                if (!_channels.ContainsKey(channelName))
                {
                    user.ReceiveSystemMessage(channelName, $"Канал '{channelName}' не существует.");
                    return;
                }
                _channels[channelName].RemoveUser(user);
            }
        }

        public void SendMessageToChannel(string channelName, string fromUsername, string message, bool createIfMissing = true)
        {
            if (string.IsNullOrWhiteSpace(channelName) || string.IsNullOrWhiteSpace(fromUsername))
                return;

            ChannelMediator ch;
            lock (_lock)
            {
                if (!_channels.TryGetValue(channelName, out ch))
                {
                    if (createIfMissing)
                    {
                        ch = new ChannelMediator(channelName, this);
                        _channels[channelName] = ch;
                    }
                    else
                    {
                        if (_users.TryGetValue(fromUsername, out var usr))
                            usr.ReceiveSystemMessage(channelName, $"Канал '{channelName}' не существует.");
                        return;
                    }
                }
            }
            ch.BroadcastMessage(fromUsername, message);
        }

        public void SendPrivateMessage(string fromUsername, string toUsername, string message)
        {
            if (string.IsNullOrWhiteSpace(fromUsername) || string.IsNullOrWhiteSpace(toUsername)) return;
            IUser toUser = null;
            IUser fromUser = null;
            lock (_lock)
            {
                _users.TryGetValue(toUsername, out toUser);
                _users.TryGetValue(fromUsername, out fromUser);
            }
            if (fromUser == null)
                return;
            if (toUser == null)
            {
                fromUser.ReceiveSystemMessage("", $"Пользователь '{toUsername}' не найден.");
                return;
            }
            toUser.ReceivePrivateMessage(fromUsername, message);
        }

        public void SendCrossChannelMessage(string fromChannel, string toChannel, string fromUsername, string message, bool createIfMissing = true)
        {
            if (string.IsNullOrWhiteSpace(fromChannel) || string.IsNullOrWhiteSpace(toChannel)) return;
            ChannelMediator target;
            lock (_lock)
            {
                if (!_channels.TryGetValue(toChannel, out target))
                {
                    if (createIfMissing)
                    {
                        target = new ChannelMediator(toChannel, this);
                        _channels[toChannel] = target;
                    }
                    else
                    {
                        if (_users.TryGetValue(fromUsername, out var u))
                            u.ReceiveSystemMessage(toChannel, $"Канал '{toChannel}' не существует.");
                        return;
                    }
                }
            }
            target.BroadcastCrossChannelMessage(fromChannel, fromUsername, message);
        }

        public void BlockUser(string channelName, string username, TimeSpan duration)
        {
            if (string.IsNullOrWhiteSpace(channelName) || string.IsNullOrWhiteSpace(username)) return;
            ChannelMediator ch;
            lock (_lock)
            {
                if (!_channels.TryGetValue(channelName, out ch))
                {
                    if (_users.TryGetValue(username, out var u))
                        u.ReceiveSystemMessage(channelName, $"Нельзя заблокировать: канал '{channelName}' не существует.");
                    return;
                }
            }
            ch.BlockUser(username, duration);
        }

        public void UnblockUser(string channelName, string username)
        {
            if (string.IsNullOrWhiteSpace(channelName) || string.IsNullOrWhiteSpace(username)) return;
            ChannelMediator ch;
            lock (_lock)
            {
                if (!_channels.TryGetValue(channelName, out ch)) return;
            }
            ch.UnblockUser(username);
        }

        internal IUser GetUser(string username)
        {
            lock (_lock)
            {
                _users.TryGetValue(username, out var u);
                return u;
            }
        }
    }
}
