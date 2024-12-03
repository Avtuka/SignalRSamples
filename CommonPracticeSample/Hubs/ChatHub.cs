using Microsoft.AspNetCore.SignalR;

namespace CommonPracticeSample.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        //Loosely typed hub
        public async Task SendToGroup(string groupName, string name, string message)
        {
            await Clients.Group(groupName).BroadcastMessage(name, message);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Caller.GroupMessage($"You have joined the group: {groupName}");
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Caller.GroupMessage($"You have left the group: {groupName}");
        }

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"Client disconnected: {Context.ConnectionId}");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
