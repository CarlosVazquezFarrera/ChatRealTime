namespace Cliente.Pages
{
    using Cliente.Models;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.SignalR.Client;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public partial class Chats
    {
        List<Chat> ChatUser { get; set; } = new List<Chat>();
        private HubConnection hubConnection;
        List<Message> MensajesChat = new List<Message>();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public HttpClient Http { get; set; }
        Guid ToUserId;
        public bool CargandoChat = false;
        public int IdChatSeleccionado { get; set; }
        public string Mensaje { get; set; }

        bool IsConected => hubConnection.State == HubConnectionState.Connected;
        protected async override void OnInitialized()
        {
            this.Http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await Http.GetAsync($"Chat/ObtenerChats?Idusuario={UsuariooHelper.GetUser().Id}");
            if (response.IsSuccessStatusCode)
            {
                var chats = await response.Content.ReadFromJsonAsync<List<Chat>>();
                this.ChatUser = chats;
                StateHasChanged();
            }
            hubConnection = new HubConnectionBuilder()
            .WithUrl("http://localhost:63077/chathub")
            .WithAutomaticReconnect()
            .Build();

            hubConnection.On<Message>("ReceiveMessage", (message) =>
            {
                this.MensajesChat.Add(message);
                StateHasChanged();
            });

            await hubConnection.StartAsync();
        }

        public async Task AbrirChat(int IdChat, Guid IdUserChat)
        {
            this.ToUserId = IdUserChat;
            this.IdChatSeleccionado = IdChat;
            CargandoChat = true;
            this.Http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await Http.GetAsync($"Chat/ObtenerMensajes?IdChat={IdChat}");
            if (response.IsSuccessStatusCode)
            {
                var mensajes = await response.Content.ReadFromJsonAsync<List<Message>>();
                this.MensajesChat = mensajes;
                StateHasChanged();
            }
            CargandoChat = false;
        }

        public async Task EnviarMensaje()
        {
            Message mensaje = new Message
            {
                IdChat = this.IdChatSeleccionado,
                FromUserId = UsuariooHelper.GetUser().Id,
                ToUserId = this.ToUserId,
                MessageText = this.Mensaje
            };
            await hubConnection.SendAsync("ReceiveMessage", mensaje);
            this.Mensaje = string.Empty;
        }
    }
}
