using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redmine.WebSocketFolder
{
    public class RedmineWebSocketHandler
    {
        private readonly RedmineConnectionManager _webSocketManager;

        public RedmineWebSocketHandler(RedmineConnectionManager webSocketManager)
        {
            _webSocketManager = webSocketManager;
        }

        public async Task Handle(WebSocket webSocket)
        {
            try
            {
                // Add the WebSocket to the WebSocketManager
                _webSocketManager.AddSocket(Guid.NewGuid().ToString(), webSocket);

                var buffer = new byte[1024 * 4];
                WebSocketReceiveResult result = null;

                // Handle incoming messages
                while (webSocket.State == WebSocketState.Open)
                {
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        Console.WriteLine($"Received message: {message}");

                        // Process and send response if needed
                        // Example: await SendMessageToAllAsync(message);
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WebSocket handling error: {ex.Message}");
            }
            finally
            {
                // Remove the WebSocket from the WebSocketManager when done
                _webSocketManager.RemoveSocket(webSocket);
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "WebSocket connection closed", CancellationToken.None);
            }
        }

        // Additional methods to send messages, etc. can be added here
    }
}
