using System.Collections.Concurrent;
using System.Net.WebSockets;

namespace Redmine.WebSocketFolder
{
    public class RedmineConnectionManager
    {
        private readonly ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();

        public void AddSocket(string id, WebSocket socket)
        {
            _sockets.TryAdd(id, socket);
        }

        public WebSocket GetSocketById(string id)
        {
            _sockets.TryGetValue(id, out WebSocket socket);
            return socket;
        }

        public ConcurrentDictionary<string, WebSocket> GetAllSockets()
        {
            return _sockets;
        }

        public void RemoveSocket(WebSocket socket)
        {
            foreach (var (id, value) in _sockets)
            {
                if (value == socket)
                {
                    _sockets.TryRemove(id, out _);
                    break;
                }
            }
        }
    }
}
