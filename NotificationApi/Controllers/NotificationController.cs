using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotificationApi.Models;
using NotificationApi.Process.ListNotification;
using NotificationApi.Process.PushNotification;

namespace NotificationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(ILogger<NotificationController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("push")]
        public void Push([FromBody]PushNotificationRequest request,
            [FromServices]IPushNotificationManager pushNotificationManager)
        {
            try
            {
                pushNotificationManager.ApplyAsync(
                    receiver: request.Receiver,
                    sender: request.Sender,
                    message: request.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("PushNotification", ex);
            }
        }

        [HttpGet]
        [Route("list/{agentId}/{pageNo}")]
        public IEnumerable<Notification> List(string agentId, int pageNo,
            [FromServices]IListNotificationManager listNotificationManager)
        {
            try
            {
                return listNotificationManager.Find(agentId, new PageNo(pageNo));
            }
            catch (Exception ex)
            {
                _logger.LogError("PushNotification", ex);
                return null;
            }
        }
    }
}
