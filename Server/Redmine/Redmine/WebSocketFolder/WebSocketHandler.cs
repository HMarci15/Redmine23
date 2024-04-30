using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redmine.WebSocketFolder
{
    public class WebSocketHandler
    {
        public async Task Handle(WebSocket webSocket)
        {
            // WebSocket kezelő folyamata
            while (webSocket.State == WebSocketState.Open)
            {
                var buffer = new byte[1024 * 4];
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                // Ha az üzenet típusa Close, akkor lezárjuk a WebSocket kapcsolatot
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                    break;
                }
                else if (result.MessageType == WebSocketMessageType.Text)
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                    // Üzenet feldolgozása és válasz küldése
                    var responseMessage = $"Received: {message}";
                    var responseData = Encoding.UTF8.GetBytes(responseMessage);
                    await webSocket.SendAsync(new ArraySegment<byte>(responseData), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }
    }
}
