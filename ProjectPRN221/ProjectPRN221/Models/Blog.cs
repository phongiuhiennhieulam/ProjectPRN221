using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        [Required(ErrorMessage ="Title is not empty")]
        public string BlogTitle { get; set; }

        [Required(ErrorMessage = "Author is not empty")]
        public string BlogAuthor { get; set; }

        [Required(ErrorMessage = "Description is not empty")]
        public string BlogDescriptions { get; set; }

        [Required(ErrorMessage = "CreateDate is not empty")]
        public DateTime BlogCreatedate { get; set; }

        [Required(ErrorMessage = "CreateBy is not empty")]
        public string BlogCreateby { get; set; }
        public string BlogImages { get; set; }
        public DateTime? BlogModifydate { get; set; }
        public string BlogModifyby { get; set; }

        [Required(ErrorMessage ="Detail is not empty")]
        public string BlogDetail { get; set; }

        [Required(ErrorMessage = "BackLink is not empty")]
        public string BlogBackLink { get; set; }
    }
}
