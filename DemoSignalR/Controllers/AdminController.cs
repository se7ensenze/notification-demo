using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoSignalR.Hubs;
using DemoSignalR.Interface;
using DemoSignalR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DemoSignalR.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHubContext<NotificationUserHub> _notificationUserHubContext;
        private readonly IUserConnectionManager _userConnectionManager;
        private readonly IHubContext<NotificationHub> _notificationHubContext;
        public AdminController(IHubContext<NotificationHub> notificationHubContext, 
            IHubContext<NotificationUserHub> notificationUserHubContext, 
            IUserConnectionManager userConnectionManager)
        {
            _notificationHubContext = notificationHubContext;
            _notificationUserHubContext = notificationUserHubContext;
            _userConnectionManager = userConnectionManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Article model)
        {
            await _notificationHubContext.Clients.All.SendAsync("sendToUser", 
                model.articleHeading, model.articleContent);

            return View();
        }

        public IActionResult SendToSpecificUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SendToSpecificUser(Article model)
        {
            var connections = _userConnectionManager.GetUserConnections(model.userId);
            if (connections != null && connections.Count > 0)
            {
                foreach (var connectionId in connections)
                {
                    await _notificationUserHubContext.Clients.Client(connectionId).SendAsync("sendToUser", model.articleHeading, model.articleContent);
                }
            }
            return View();
        }
    }
}
