using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IHubContext<BaseHub> _hub;
        public MessageController(IHubContext<BaseHub> hub, IConfiguration configuration)
        {
            _hub = hub;
            _configuration = configuration;
        }

        [Route("")]
        public async Task<IActionResult> Index(string title, string body, string password)
        {
            if (password == "")
            {
                var messageObject = new { title, body };
                await _hub.Clients.All.SendAsync("OnServerMessage", messageObject);
                return Ok(new { result = true });
            }
            else
            {
                return BadRequest(new { error = "Wrong password" });
            }
        }
    }
}