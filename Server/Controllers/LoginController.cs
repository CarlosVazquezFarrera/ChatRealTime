using Microsoft.AspNetCore.Mvc;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        List<User> Usuarios = new List<User> { 
        new User{ Correo = "Correo1@gmail.com", Password = "12345", Id = new Guid("35586006-78ef-4ab4-b707-39739f88ea30")}, // Juanito 1
        new User{ Correo = "Correo2@gmail.com", Password = "12345", Id = new Guid("2a870d62-58c1-47c5-90f3-718e64e32ace")}, //Juanito 2
        new User{ Correo = "Correo3@gmail.com", Password = "12345", Id = new Guid("95b48c1d-96a5-4e19-92e9-cdaf3bda763d")} //Juanito 3
        };
        [HttpPost("Login")]
        public IActionResult Login([FromBody] User usuario)
        {
            var user = this.Usuarios.Find(u => u.Correo.Equals(usuario.Correo) && u.Password.Equals(usuario.Password));
            return Ok(user);
        }
    }
}
