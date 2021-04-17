using System;

namespace Cliente.Models
{
    public class Message
    {
        public Guid ToUserId { get; set; }
        public Guid FromUserId { get; set; }
        public string MessageText { get; set; }
    }
}
