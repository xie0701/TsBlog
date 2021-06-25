using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;

namespace TsBlog.Repositories
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {

        public IEnumerable<Menu> GetMenuListByRoleId(int roleId)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var list = db.Queryable<MenuRoleAction, Menu>((mra, m) => new JoinQueryInfos(
                    JoinType.Inner, m.Id == mra.MenuId)).Where((mra, m) => mra.RoleId == roleId)
                    .Select((mra, m) => new Menu
                    {
                        Id = m.Id,
                        ParentId = m.ParentId,
                        MenuName = m.MenuName,
                        Icon = m.Icon,
                        MenuUrl = m.MenuUrl,
                        Status = m.Status
                    }).ToList();
                return list;
            }
        }

        public IEnumerable<Menu> GetMenuListOrderByOrderNo(string orderBy)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var list = db.Queryable<Menu>().OrderBy(orderBy).ToList();

                return list;
            }
        }
    }
}
