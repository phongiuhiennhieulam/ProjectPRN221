using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Conversation
    {
        public Conversation()
        {
            Messages = new HashSet<Message>();
            Participates = new HashSet<Participate>();
        }

        public int CId { get; set; }
        public string Cname { get; set; }
        public int AccountId { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Participate> Participates { get; set; }
    }
}
