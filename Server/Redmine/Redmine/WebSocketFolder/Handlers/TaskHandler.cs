using NuGet.Protocol;
using System.Net.WebSockets;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace Redmine.WebSocketFolder.Handlers
{

    public class TaskHandler : WebSocketHandler
    {
        
        public TaskHandler(ConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }

        public override async Task ReceiveAsync(System.Net.WebSockets.WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var UserId = WebSocketConnectionManager.GetId(socket);
            var message =  Encoding.UTF8.GetString(buffer, 0, result.Count);
            int DCount = 0;
            Console.WriteLine(message);
            if(message == "0")
            {
                DCount = 0;
            }
            else
            {
                
                JArray jsonArray = JArray.Parse(message);

                // A JSON tömb elemeinek feldolgozása
                foreach (JObject jsonObject in jsonArray)
                {
                    // Az objektum tulajdonságainak kinyerése és kiírása
                    int id = (int)jsonObject["id"];
                    string name = (string)jsonObject["name"];
                    string description = (string)jsonObject["description"];
                    DateTime date = (DateTime)jsonObject["date"];

                    Console.WriteLine($"ID: {id}, Name: {name}, Description: {description}, Date: {date}");
                    DCount++;
                }
            }
            


            await SendMessageAsync(socket, DCount.ToString()) ;
        }
    }
}
