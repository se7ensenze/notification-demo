using Dapper;
using NotificationApi.Process.ListNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Infrastructure.Repositories
{
    public class ListNotificationRepository
        : IListNotificationRepository
    {
        private readonly NotificationDbContext _dbContext;

        public ListNotificationRepository(NotificationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Notification> Find(string agentId, PageNo pageNo)
        {
            if (pageNo == null)
            {
                throw new ArgumentException("pageNo is null");
            }

            var param = new DynamicParameters();
            param.Add("@Receiver", agentId);
            param.Add("@PageNo", pageNo.Value);
            param.Add("@PageSize", 5);

            return _dbContext.Query<Notification>(
                sqlCommand: "sp_ListNotification",
                param: param,
                commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
