using NotificationApi.Process.ListNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NotificationApi.Infrastructure.Repositories
{
    public class NotificationDbContext
    {

        private readonly string _connectionString;

        public NotificationDbContext(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:NotificationDB"];
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public int ExecuteCommand(string sqlCommand, object param = null, CommandType commandType = CommandType.Text)
        {
            using var con = CreateConnection();

            con.Open();

            return con.Execute(sql: sqlCommand,
                param: param,
                commandType: commandType);
        }

        public IEnumerable<T> Query<T>(string sqlCommand, object param = null, CommandType commandType = CommandType.Text)
        {
            using var con = CreateConnection();

            con.Open();

            return con.Query<T>(sql: sqlCommand, 
                param: param, 
                commandType: commandType);
        }
    }
}
