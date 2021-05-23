using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Infrastructure.Hubs
{
    public class NotificationHub
        :Hub
    {
        private readonly ConnectionManager _connectionManager;

        public NotificationHub(ConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public void Register(string agentId)
        {
            _connectionManager.Register(Context.ConnectionId, agentId);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _connectionManager.Remove(Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
