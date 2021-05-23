using NotificationApi.Infrastructure.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Process.PushNotification.v1
{
    public class PushNotificationManager
        : IPushNotificationManager
    {
        private readonly IPushNotificationRepository _notificationRepository;
        private readonly NotificationHubManager _noficationHubManager;

        public PushNotificationManager(IPushNotificationRepository notificationRepository,
            NotificationHubManager noficationHubManager)
        {
            _notificationRepository = notificationRepository;
            _noficationHubManager = noficationHubManager;
        }

        public void ApplyAsync(string receiver, string sender, string message)
        {
            var notification = new PushNotification(
                receiver: receiver,
                sender: sender,
                message: message);

            _notificationRepository.Save(notification);

            _noficationHubManager.NotifyAgent(receiver, "notificationCreated");

        }
    }
}
