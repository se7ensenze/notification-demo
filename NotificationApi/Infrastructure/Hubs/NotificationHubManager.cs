using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Infrastructure.Hubs
{
    public class NotificationHubManager
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ConnectionManager _connectionManager;

        public NotificationHubManager(IHubContext<NotificationHub> hubContext,
            ConnectionManager connectionManager)
        {
            _hubContext = hubContext;
            _connectionManager = connectionManager;
        }


        public void NotifyAgent(string agentId, string eventName)
        {
            var connectionIds = _connectionManager.Find(agentId);

            _hubContext.Clients.Clients(connectionIds).SendAsync(eventName);
        }
    }
}
