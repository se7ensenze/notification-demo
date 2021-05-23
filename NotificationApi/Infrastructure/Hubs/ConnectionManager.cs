using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Infrastructure.Hubs
{
    public class ConnectionManager
    {
        readonly ConcurrentDictionary<string, string> _clients;

        public ConnectionManager()
        {
            _clients = new ConcurrentDictionary<string, string>();
        }

        public void Register(string connectionId, string agentId)
        {
            _clients.AddOrUpdate(connectionId, agentId, (key, oldValue) => agentId);
        }

        public void Remove(string connectionId)
        {
            _clients.TryRemove(connectionId, out string _);
        }

        internal string[] Find(string agentId)
        {
            return _clients.Where(kv => kv.Value == agentId)
                .Select(kv => kv.Key)
                .ToArray();
        }
    }
}
