namespace Server.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using Server.Models;
    using System.Threading.Tasks;
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;
            
            return base.OnConnectedAsync();
        }
        public async Task ReceiveMessage(Message message)
        {
            //string[] users = new string[] { message.ToUserId.ToString(), message.FromUserId.ToString() };
            //await Clients.Users(users).SendAsync("ReceiveMessage", message);
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
