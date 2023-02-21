using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Productsize
    {
        public int? ProductId { get; set; }
        public int? SizeId { get; set; }
        public int ProductQuantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}
