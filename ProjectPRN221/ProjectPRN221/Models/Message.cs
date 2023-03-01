using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Message
    {
        public int MId { get; set; }
        public int AccountId { get; set; }
        public int CId { get; set; }
        public string Message1 { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual Account Account { get; set; }
        public virtual Conversation CIdNavigation { get; set; }
    }
}
