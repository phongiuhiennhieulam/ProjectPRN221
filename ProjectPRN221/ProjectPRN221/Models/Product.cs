using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage ="ProductName is not empty")]
        public string ProductName { get; set; }

        [Required(ErrorMessage ="Price is not empty")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage ="Color is not empty")]
        public int? ColorId { get; set; }

        [Required(ErrorMessage = "Quantity is not empty")]
        public int ProductQuantity { get; set; }

        [Required(ErrorMessage = "Image is not empty")]
        public string ProductImage { get; set; }

        [Required(ErrorMessage = "Category is not empty")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Status is not empty")]
        public int StatusProductId { get; set; }

        [Required(ErrorMessage = "Description is not empty")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Product Code is not empty")]
        public string ProductCode { get; set; }
        public DateTime ProductCreateDate { get; set; }
        public string ProductBacklink { get; set; }

        public virtual Category Category { get; set; }
        public virtual Color Color { get; set; }
        public virtual StatusProduct StatusProduct { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
