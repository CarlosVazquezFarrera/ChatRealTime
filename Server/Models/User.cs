using System;

namespace Server.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
