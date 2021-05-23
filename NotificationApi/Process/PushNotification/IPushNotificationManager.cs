using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Process.PushNotification
{
    public interface IPushNotificationManager
    {
        void ApplyAsync(string receiver, string sender, string message);
    }
}
