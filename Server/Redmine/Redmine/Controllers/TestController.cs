using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Redmine.WebSocketFolder;
using Newtonsoft.Json;

[Route("api/[controller]")]
[ApiController]

public class WebSocketController : ControllerBase
{
    private readonly MyWebSocketManager _webSocketManager;

    public WebSocketController(MyWebSocketManager webSocketManager)
    {
        _webSocketManager = webSocketManager;
    }

    [HttpGet]
    public async Task<IActionResult> Connect()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            var socket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            var id = Guid.NewGuid().ToString(); // Generate unique ID for connection
            _webSocketManager.AddWebSocket(id, socket);

            // Perform handshake
            var buffer = new byte[1024 * 4];
            var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

            // Handle handshake message (if necessary)

            return Ok($"WebSocket connection established. ID: {id}");
        }
        else
        {
            return BadRequest("WebSocket connection required.");
        }
    }

    [HttpPost("get_projects")]
    public async Task<IActionResult> GetProjects([FromBody] string message)
    {
        // Assuming message contains client request
        var id = HttpContext.Items["WebSocket-ConnectionId"] as string; // Get the WebSocket connection ID
        if (id == null)
        {
            return BadRequest("WebSocket connection ID not found.");
        }

        // Here you should retrieve the project list based on client's request
        var projects = new List<string> { "Project1", "Project2", "Project3" }; // Implement this method to get the project list
        var projectsJson = JsonConvert.SerializeObject(projects);

        await _webSocketManager.SendAsync(id, projectsJson);

        return Ok("Project list sent successfully.");
    }
}
