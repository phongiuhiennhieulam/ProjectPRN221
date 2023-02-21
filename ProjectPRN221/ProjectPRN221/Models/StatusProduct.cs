using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class StatusProduct
    {
        public StatusProduct()
        {
            Products = new HashSet<Product>();
        }

        public int StatusProductId { get; set; }
        public string StatusProductStatus { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
