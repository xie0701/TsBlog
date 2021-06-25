using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace TsBlog.Domain.Entities
{
    [SugarTable("tb_menu_role_action")]
    public class MenuRoleAction
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int RoleId { get; set; }
        public int ActionId { get; set; }
    }
}
