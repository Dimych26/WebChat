using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebChat.Hubs
{
    public class ChatHub: Hub
    {
        private static readonly List<string> _connections = new List<string>();

        public static ReadOnlyCollection<string> Connections => _connections.AsReadOnly();
        public async Task Send(string message)
        {
            var s = Context.ConnectionId;
            this.Clients.Others.SendAsync("Send", message).Wait();
        }

        public async Task SendPublicKey(int publicKey)
        {
            var s = Context.ConnectionId;
            this.Clients.Others.SendAsync("SendPublicKey", publicKey).Wait();
        }

        public async Task SendPartialKey(int partialKey)
        {
            var s = Context.ConnectionId;
            this.Clients.Others.SendAsync("SendPartialKey", partialKey).Wait();
        }

        public override async Task OnConnectedAsync()
        {
            _connections.Add(Context.ConnectionId);
            Clients.All.SendAsync("NewUserConnected").Wait();
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _connections.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("Notify", $"{Context.ConnectionId} покинул в чат");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
