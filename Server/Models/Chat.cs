using System;

namespace Server.Models
{
    public class Chat
    {
        public int IdChat { get; set; }
        public Guid FromUserId { get; set; }
        public string User { get; set; }
        public string LastMessage { get; set; }
    }
}
