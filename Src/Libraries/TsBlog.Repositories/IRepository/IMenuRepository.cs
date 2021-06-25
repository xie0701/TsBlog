using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;

namespace TsBlog.Repositories
{
    public interface IMenuRepository : IRepository<Menu>
    {
        IEnumerable<Menu> GetMenuListByRoleId(int roleId);

        IEnumerable<Menu> GetMenuListOrderByOrderNo(string orderBy);
    }
}
