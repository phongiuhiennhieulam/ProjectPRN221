﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Color
    {
        public Color()
        {
            Products = new HashSet<Product>();
        }

        public int ColorId { get; set; }
        public string ColorName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
