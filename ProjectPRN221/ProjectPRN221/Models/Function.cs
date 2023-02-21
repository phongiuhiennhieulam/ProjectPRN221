using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Function
    {
        public Function()
        {
            RoleFunctions = new HashSet<RoleFunction>();
        }

        public int FunctionId { get; set; }
        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }
        public int FunctionOrdernumber { get; set; }
        public DateTime FunctionCreateday { get; set; }

        public virtual ICollection<RoleFunction> RoleFunctions { get; set; }
    }
}
