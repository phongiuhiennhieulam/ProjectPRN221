using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Account
    {
        public Account()
        {
            Carts = new HashSet<Cart>();
            Conversations = new HashSet<Conversation>();
            Messages = new HashSet<Message>();
            Orders = new HashSet<Order>();
            Participates = new HashSet<Participate>();
        }

        public int AccountId { get; set; }

		[Required(ErrorMessage = "FullName is not empty")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Username should be between 2 and 50 characters")]
		public string AccountUsername { get; set; }

		[Required(ErrorMessage = "Password is not empty")]
		[StringLength(20, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 20 characters")]
		public string AccountPassword { get; set; }

		[Required(ErrorMessage = "Email is not empty")]
		[StringLength(20, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 20 characters")]
		public string AccountEmail { get; set; }

		[Required(ErrorMessage = "AccountName is not empty ")]
		public string AccountName { get; set; }

		[Required(ErrorMessage = "Phone is not empty")]
		public string AccountPhone { get; set; }

		[Required(ErrorMessage = "Address is not empty")]
		public string AccountAddress { get; set; }
		public int AccountRoleId { get; set; }
        public bool? AccountGender { get; set; }
        public bool AccountStatus { get; set; }
        public DateTime? AccountCreatedate { get; set; }
        public string AccountImage { get; set; }
        public DateTime? AccountDob { get; set; }

        public virtual Role AccountRole { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Conversation> Conversations { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Participate> Participates { get; set; }
    }
}
