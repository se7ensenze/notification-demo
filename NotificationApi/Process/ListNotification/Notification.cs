using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Process.ListNotification
{
    public class Notification
    {
        public Guid Id { get; }
        public string Receiver { get; }
        public string Sender { get; }
        public string Message { get; }
        public DateTime CreatedDate { get; }
        public DateTime? ReadDate { get; }
        public bool IsRead => this.ReadDate.HasValue;
        public Notification() { }
    }
}
