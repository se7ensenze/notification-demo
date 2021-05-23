using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NotificationApi.Process.ListNotification
{
    public class PageNo
    {
        public int Value { get; }
        public PageNo(int value)
        {
            if (value < 1)
            {
                throw new ArgumentException($"pageNo is than one");
            }

            this.Value = value;
        }
    }
}
