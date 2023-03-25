using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int? ColorId { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductImage { get; set; }
        public int? CategoryId { get; set; }
        public int StatusProductId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCode { get; set; }
        public DateTime ProductCreateDate { get; set; }
        public string ProductBacklink { get; set; }

        public virtual Category Category { get; set; }
        public virtual Color Color { get; set; }
        public virtual StatusProduct StatusProduct { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
