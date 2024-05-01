using System.Net.WebSockets;
using System.Text;

namespace Redmine.WebSocketFolder.Handlers
{

    public class TaskHandler : WebSocketHandler
    {
        public TaskHandler(ConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }

        public override async Task ReceiveAsync(System.Net.WebSockets.WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var message = $"Új feladat lett rögzítve: {Encoding.UTF8.GetString(buffer, 0, result.Count)}";

            await SendMessageToAllAsync(message);
        }
    }
}
