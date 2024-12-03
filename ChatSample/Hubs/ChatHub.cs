using Microsoft.AspNetCore.SignalR;

namespace ChatSample.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string name, string message)
        {
            await Clients.All.SendAsync("broadcastMessage", name, message);
            //await Clients.Others.SendAsync("broadcastMessage", name, message);
        }
    }
}
