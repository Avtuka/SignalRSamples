using Microsoft.AspNetCore.SignalR;

namespace GroupChatSample.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendToGroup(string groupName, string name, string message)
        {
            await Clients.Group(groupName).SendAsync("broadcastMessage", name, message);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Caller.SendAsync("groupMessage", $"You have joined the group: {groupName}");

        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Caller.SendAsync("groupMessage", $"You have left the group: {groupName}");
        }
    }
}
