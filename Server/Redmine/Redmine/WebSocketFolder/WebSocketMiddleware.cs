using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Redmine.WebSocketFolder{



public class WebSocketMiddleware
{
    private readonly RequestDelegate _next;
    private readonly WebSocketHandler _webSocketHandler;

    public WebSocketMiddleware(RequestDelegate next, WebSocketHandler webSocketHandler)
    {
        _next = next;
        _webSocketHandler = webSocketHandler;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            await _webSocketHandler.Handle(webSocket);
        }
        else
        {
            await _next(context);
        }
    }
    }
}