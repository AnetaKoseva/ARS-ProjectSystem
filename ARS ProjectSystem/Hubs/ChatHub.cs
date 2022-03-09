﻿namespace ARS_ProjectSystem.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;

    public class ChatHub:Hub
    {
        public Task JoinGroup(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task SendMessage(string sender, string message)
        {
            await Clients.All.SendAsync("SendMessage", sender, message);
        }

       
    }
}
