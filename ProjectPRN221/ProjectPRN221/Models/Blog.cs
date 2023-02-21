using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogDescriptions { get; set; }
        public DateTime BlogCreatedate { get; set; }
        public string BlogCreateby { get; set; }
        public string BlogImages { get; set; }
        public DateTime? BlogModifydate { get; set; }
        public string BlogModifyby { get; set; }
        public string BlogDetail { get; set; }
        public string BlogBackLink { get; set; }
    }
}
