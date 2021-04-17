using Cliente.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Cliente.Pages
{
    public partial class Index
    {
        [Inject]
        public HttpClient Http { get; set; }
        [Inject]
        public NavigationManager Router { get; set; }
        public User user { get; set; } = new User();

        public async Task Login()
        {
            Http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await Http.PostAsJsonAsync<User>("Login/Login", user);
            var usuario = await response.Content.ReadFromJsonAsync<User>();
            if (response.IsSuccessStatusCode)
            {
                UsuariooHelper.Login(usuario);
                Router.NavigateTo("chats");
            }
        }
    }
}
