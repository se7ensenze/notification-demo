using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Process.ListNotification
{
    public interface IListNotificationManager
    {
        IEnumerable<Notification> Find(string agentId, PageNo pageNo);
    }
}
