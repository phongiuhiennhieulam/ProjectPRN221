using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
            RoleFunctions = new HashSet<RoleFunction>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<RoleFunction> RoleFunctions { get; set; }
    }
}
