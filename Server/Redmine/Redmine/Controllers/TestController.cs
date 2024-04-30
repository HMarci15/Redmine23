using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Redmine.WebSocketFolder;


namespace Redmine.Controllers
{
    [Route("api/[controller]")]
    public class WebSocetController : ControllerBase
    {
        private readonly RedmineWebSocketHandler _webSocketHandler;

        public WebSocetController(RedmineWebSocketHandler webSocketHandler)
        {
            _webSocketHandler = webSocketHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await _webSocketHandler.Handle( webSocket);
            }
            else
            {
                return BadRequest("WebSocket is not supported.");
            }

            return Ok();
        }
    }
}