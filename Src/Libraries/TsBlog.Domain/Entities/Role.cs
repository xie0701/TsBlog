using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace TsBlog.Domain.Entities
{
    [SugarTable("tb_role")]
    public class Role
    {
        [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
        public int Id { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string Remark { get; set; }
        public bool Status { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }
    }
}
