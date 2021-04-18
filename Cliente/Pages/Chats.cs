namespace Cliente.Pages
{
    using Cliente.Models;
    using Microsoft.AspNetCore.Components;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public partial class Chats
    {
        public Chats()
        {
        }
        [Inject]
        public HttpClient Http { get; set; }

        public bool CargandoChat = false;
        public int IdChatSeleccionado { get; set; }
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
        }

        public async Task AbrirChat(int IdChat)
        {
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
        List<Chat> ChatUser { get; set; } = new List<Chat>();
        List<Message> MensajesChat = new List<Message>();
    }
}
