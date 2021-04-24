namespace Server.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using Server.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class ChatHub : Hub
    {

        public static List<Conexion> Conexiones = new List<Conexion>();
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Conexiones.RemoveAll(c => c.IdConexion.Equals(Context.ConnectionId, StringComparison.OrdinalIgnoreCase)) ;
            return base.OnDisconnectedAsync(exception);
        }
        public async Task ReceiveMessage(Message message)
        {
            await Clients.Group(message.IdChat.ToString()).SendAsync("ReceiveMessage", message);
        }

        public async Task JoinToGroup(int IdChat)
        {
            if (!Conexiones.Exists( c=> c.IdConexion.Equals(Context.ConnectionId, StringComparison.OrdinalIgnoreCase) && c.Grupo.Equals(IdChat.ToString())))
            {
                Conexiones.Add(new Conexion { IdConexion =Context.ConnectionId, Grupo = IdChat.ToString()});
                await Groups.AddToGroupAsync(Context.ConnectionId, IdChat.ToString());
            }
        }
    }
}
