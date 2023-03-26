using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Slide
    {
		public int SlideId { get; set; }

		[Required(ErrorMessage = "Title is not empty")]
		public string SlideTitle { get; set; }
		[Required(ErrorMessage = "CreateDate is not empty")]
		public DateTime SlideCreatedate { get; set; }

		[Required(ErrorMessage = "CreateBy is not empty")]
		public string SlideCreateby { get; set; }
		public DateTime? SlideModifydate { get; set; }
		public string SlideModifyby { get; set; }
		public string SlideImageslide { get; set; }

		[Required(ErrorMessage = "Description is not empty")]
		public string SlideDescriptions { get; set; }
		public bool SlideStatusId { get; set; }
	}
}
