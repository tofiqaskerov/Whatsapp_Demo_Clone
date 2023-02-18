using Microsoft.AspNetCore.SignalR;

namespace SignalRServerProject.Hubs
{
    public class TestHub : Hub
    {
        public async Task SendMessageAsync(string message)
        {
            
            await Clients.All.SendAsync("Message", message);    

            // Burada qeyd olunun SendAsync methodunun ilk parametri client terefindede calisdirlacaq methodla eyni adli olmalidir
        } 
    }
}
