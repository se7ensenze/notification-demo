using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Models
{
    public class PushNotificationRequest
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
    }
}
