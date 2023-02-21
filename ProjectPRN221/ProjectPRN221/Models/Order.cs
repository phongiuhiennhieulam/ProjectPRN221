using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? AccountId { get; set; }
        public string OrderNote { get; set; }
        public int OrderStatusId { get; set; }
        public double OrderTotalMoney { get; set; }
        public DateTime? OrderDate { get; set; }
        public int ShippingId { get; set; }

        public virtual Account Account { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Shipping Shipping { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
