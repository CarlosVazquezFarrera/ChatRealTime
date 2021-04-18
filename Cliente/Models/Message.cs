using System;

namespace Cliente.Models
{
    public class Message
    {
        public int IdChat { get; set; }
        public Guid ToUserId { get; set; }
        public Guid FromUserId { get; set; }
        public string MessageText { get; set; }
    }
}
