using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Process.ListNotification.v1
{
    public class ListNotificationManager
        : IListNotificationManager
    {
        private readonly IListNotificationRepository _listNotificationRepository;

        public ListNotificationManager(IListNotificationRepository listNotificationRepository)
        {
            _listNotificationRepository = listNotificationRepository;
        }
        public IEnumerable<Notification> Find(string agentId, PageNo pageNo)
        {
            return _listNotificationRepository.Find(agentId, pageNo);
        }
    }
}
