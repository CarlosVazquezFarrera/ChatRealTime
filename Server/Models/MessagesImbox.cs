using System;
using System.Collections.Generic;

namespace Server.Models
{
    public class MessagesImbox
    {
        public int IdChat { get; set; }
        public List<Message> Mensajes { get; set; }
    }
}
