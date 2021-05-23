using Dapper;
using NotificationApi.Process.PushNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationApi.Infrastructure.Repositories
{
    public class PushNotificationRepository
        : IPushNotificationRepository
    {
        private readonly NotificationDbContext _dbContext;

        public PushNotificationRepository(NotificationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(PushNotification notification)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Id", notification.Id);
            parameters.Add("@Receiver", notification.Receiver);
            parameters.Add("@Sender", notification.Sender);
            parameters.Add("@Message", notification.Message);
            parameters.Add("@CreatedDate", notification.CreateDate);

            _dbContext.ExecuteCommand(sqlCommand:"sp_AddNotification",
                param: parameters, 
                commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
