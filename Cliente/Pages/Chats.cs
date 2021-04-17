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
        [Inject]
        public HttpClient Http { get; set; }
        public bool CargandoChat { get; set; }
        public int IdChatSeleccionado { get; set; }
        protected async override void OnInitialized()
        {
            Console.WriteLine(UsuariooHelper.GetUser().Id);
            Http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await Http.GetAsync($"Chat/ObtenerChats?Idusuario={UsuariooHelper.GetUser().Id}");
            if (response.IsSuccessStatusCode)
            {
                var chats = await response.Content.ReadFromJsonAsync<List<Chat>>();
                this.ChatUser = chats;
                StateHasChanged();
            }
        }

        public void AbrirChat(int IdChat)
        {
            this.IdChatSeleccionado = IdChat;
            Console.WriteLine(IdChat);
        }
        public List<Chat> ChatUser { get; set; } = new List<Chat>();

    }
}
