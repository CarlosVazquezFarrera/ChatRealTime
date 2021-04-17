namespace Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Server.Models;
    using System;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private List<Imbox> Imbox = new List<Imbox>
        {
            new Imbox //Imbox de jaunito 1
            {
               IdUser = new Guid("35586006-78ef-4ab4-b707-39739f88ea30"),
               Chats = new List<Chat>
               {
                   new Chat //Janito 1 habló con Juanito 2
                   {
                       IdChat = 1,
                       LastMessage = "Ultimo Mensaje de Juanito 2",
                       User = "Janito 2",
                       FromUserId = new Guid("2a870d62-58c1-47c5-90f3-718e64e32ace")
                   },
                   new Chat //Juanito 1 habló con juanito 3
                   {
                       IdChat = 2,
                       LastMessage = "Ultimo mensaje con juanito 3",
                       User = "Juanito 3",
                       FromUserId = new Guid("95b48c1d-96a5-4e19-92e9-cdaf3bda763d")
                   }
               }
            },
            new Imbox    //Imbox de juanito 2
            {
                IdUser = new Guid("2a870d62-58c1-47c5-90f3-718e64e32ace"),
                Chats = new List<Chat>
                {
                    new Chat //Juanito 2 habló con juanito 1
                    {
                       IdChat = 1,
                       LastMessage = "Ultimo Mensaje de Juanito 2",
                       User = "Janito 1",
                       FromUserId = new Guid("2a870d62-58c1-47c5-90f3-718e64e32ace")
                    }
                }
            },
            new Imbox //Imbox de juanito 3
            {
                IdUser = new Guid("95b48c1d-96a5-4e19-92e9-cdaf3bda763d"),
                Chats = new List<Chat>
                {
                   new Chat //Juanito 3 habló con juanito 1
                   {
                       IdChat = 2,
                       LastMessage = "Ultimo mensaje con juanito 3",
                       User = "Juanito 3",
                       FromUserId = new Guid("35586006-78ef-4ab4-b707-39739f88ea30")
                   }
                }
            }
        };
        [HttpGet("ObtenerChats")]
        public IActionResult Login([FromQuery]Guid Idusuario)
        {
            var chats = this.Imbox.Find(i => i.IdUser == Idusuario).Chats;
            return Ok(chats);
        }
    }
}
