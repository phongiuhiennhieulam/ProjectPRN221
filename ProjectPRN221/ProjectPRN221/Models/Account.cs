using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Account
    {
        public Account()
        {
            Orders = new HashSet<Order>();
        }

        public int AccountId { get; set; }
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }
        public string AccountEmail { get; set; }
        public string AccountName { get; set; }
        public string AccountPhone { get; set; }
        public string AccountAddress { get; set; }
        public int AccountRoleId { get; set; }
        public bool? AccountGender { get; set; }
        public bool AccountStatus { get; set; }
        public DateTime? AccountCreatedate { get; set; }
        public string AccountImage { get; set; }
        public DateTime? AccountDob { get; set; }

        public virtual Role AccountRole { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
