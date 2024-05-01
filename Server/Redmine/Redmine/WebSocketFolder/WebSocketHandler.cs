using System.Net.WebSockets;
using System.Threading.Tasks;

public abstract class MyWebSocketHandler
{
    public abstract Task OnConnected(WebSocket socket);
    public abstract Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer);
    public abstract Task OnDisconnected(WebSocket socket);
}
