using System;
using System.Collections.Generic;

namespace Server.Models
{
    public class Imbox
    {
        public Guid IdUser { get; set; }
        public List<Chat> Chats { get; set; }
    }
}
