namespace Server.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using Server.Models;
    using System.Threading.Tasks;
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
