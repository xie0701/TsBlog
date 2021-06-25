using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Core.Model;
using TsBlog.Domain.Entities;

namespace TsBlog.Services
{
    public interface IMenuService : IService<Menu>
    {
        List<Menu> GetMenuList();

        TData<object> GetMenuListByRoleId(int roleId);

        IEnumerable<Menu> GetTopMenu();
    }
}
