using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Threading.Tasks;
namespace Redmine.WebSocketFolder
{

    public class MyWebSocketManager
    {
        private ConcurrentDictionary<string, WebSocket> _connections = new ConcurrentDictionary<string, WebSocket>();


        public WebSocket GetWebSocketById(string id)
        {
            _connections.TryGetValue(id, out WebSocket socket);
            return socket;
        }

        public void AddWebSocket(string id, WebSocket socket)
        {
            _connections.TryAdd(id, socket);
        }


        public async Task RemoveWebSocketAsync(string id)
        {
            _connections.TryRemove(id, out WebSocket socket);
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed", System.Threading.CancellationToken.None);
        }

        public async Task SendAsync(string id, string message)
        {
            if (_connections.TryGetValue(id, out WebSocket socket))
            {
                var buffer = System.Text.Encoding.UTF8.GetBytes(message);
                await socket.SendAsync(new System.ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, System.Threading.CancellationToken.None);
            }
        }
    }
}