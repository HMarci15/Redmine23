using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;


namespace Redmine.WebSocketFolder
{
    public class WebSocketManager
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

        public string GetId(WebSocket socket)
        {
            foreach (var item in _sockets)
            {
                if (item.Value == socket)
                    return item.Key;
            }
            return null;
        }
    }
}