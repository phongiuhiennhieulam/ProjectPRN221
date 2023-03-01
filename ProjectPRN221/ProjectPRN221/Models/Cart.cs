using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int AccountId { get; set; }
        public decimal CartTotol { get; set; }

        public virtual Account Account { get; set; }
    }
}
