using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Process.PushNotification
{
    public interface IPushNotificationRepository
    {
        void Save(PushNotification notification);
    }
}
