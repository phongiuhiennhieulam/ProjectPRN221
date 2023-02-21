using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Slide
    {
        public int SlideId { get; set; }
        public string SlideTitle { get; set; }
        public DateTime SlideCreatedate { get; set; }
        public string SlideCreateby { get; set; }
        public DateTime? SlideModifydate { get; set; }
        public string SlideModifyby { get; set; }
        public string SlideImageslide { get; set; }
        public string SlideDescriptions { get; set; }
        public bool SlideStatusId { get; set; }
    }
}
