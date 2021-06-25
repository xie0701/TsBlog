using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Core.Operator
{
    public class OperatorInfo
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public int RoleId { get; set; }

        public string LoginIPAddress { get; set; }

        public string LoginIPAddressName { get; set; }

        public string LoginToken { get; set; }

        public DateTime LoginDate { get; set; }
    }
}
