using Cliente.Models;

namespace Cliente
{
    public class UsuariooHelper
    {
        public static User Usuario { get; set; } = new User();

        public static void Login(User user)
        {
            Usuario = user;
        }

        public static User GetUser()
        {
            return Usuario;
        }
    }
}
