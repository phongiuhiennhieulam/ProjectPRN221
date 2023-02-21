using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailsId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public decimal? OrderDetailsPrice { get; set; }
        public int? OrderDetailsNum { get; set; }
        public double? OrderDetailsTotalNumber { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
