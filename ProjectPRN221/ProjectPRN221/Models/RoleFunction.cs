using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class RoleFunction
    {
        public int RoleFunctionId { get; set; }
        public int? FunctionId { get; set; }
        public int? RoleId { get; set; }
        public int RoleFunctionView { get; set; }
        public int RoleFunctionInsert { get; set; }
        public int RoleFunctionUpdate { get; set; }
        public int RoleFunctionDelete { get; set; }

        public virtual Function Function { get; set; }
        public virtual Role Role { get; set; }
    }
}
