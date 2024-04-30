using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Redmine.WebSocketFolder
{
    public class RedmineWebSocketMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RedmineWebSocketHandler _webSocketHandler;

        public RedmineWebSocketMiddleware(RequestDelegate next, RedmineWebSocketHandler webSocketHandler)
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
