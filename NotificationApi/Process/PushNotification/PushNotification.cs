using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Process.PushNotification
{
    public class PushNotification
    {
        public Guid Id { get; }
        public string Receiver { get; }
        public string Sender { get; }
        public string Message { get; }
        public DateTime CreateDate { get; }

        public PushNotification(string receiver, string sender, string message)
        {
            if (string.IsNullOrEmpty(receiver))
                throw new ArgumentException($"{nameof(receiver)} is null or empty");

            if (string.IsNullOrEmpty(sender))
                throw new ArgumentException($"{nameof(sender)} is null or empty");

            if (string.IsNullOrEmpty(message))
                throw new ArgumentException($"{nameof(message)} is null or empty");

            this.Id = Guid.NewGuid();
            this.Receiver = receiver;
            this.Sender = sender;
            this.Message = message;
            this.CreateDate = DateTime.Now;

        }
    }
}
