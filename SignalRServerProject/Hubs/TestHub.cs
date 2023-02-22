using Microsoft.AspNetCore.SignalR;

namespace SignalRServerProject.Hubs
{
    public class TestHub : Hub
    {
        static List<string> clients = new();
        public async Task SendMessageAsync(string message)
        {
            
            await Clients.All.SendAsync("Message", message);    

            // Burada qeyd olunun SendAsync methodunun ilk parametri client terefindede calisdirlacaq methodla eyni adli olmalidir
        }
        public override async Task OnConnectedAsync()   // OnConnectedAsync methodu sisteme her hansi bir client daxil olarken ise dusur
        {
           clients.Add(Context.ConnectionId);
           await Clients.All.SendAsync("allClients", clients);
           await Clients.All.SendAsync("userJoin", Context.ConnectionId);      //ConnectionId sistemdeki clientleri bir-birinden ayira bilen bir id-dir.
            
        }

        public override async Task OnDisconnectedAsync(Exception? exception) // OnDisconnectedAsync methodu sistemden her hansi bir client cixis ederken ise dusur
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("allClients", clients);
            await Clients.All.SendAsync("userLeft", Context.ConnectionId);
        }
    }
}
