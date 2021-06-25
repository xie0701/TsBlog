using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Core.Model;
using TsBlog.Domain.Entities;
using TsBlog.Repositories;


namespace TsBlog.Services
{
    public class MenuService : GenericService<Menu>, IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository) : base(menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public List<Menu> GetMenuList()
        {
            return _menuRepository.FindAll().ToList();
        }

        public TData<object> GetMenuListByRoleId(int roleId)
        {
            IEnumerable<Menu> menuList = _menuRepository.GetMenuListByRoleId(roleId);
            List<MenuTree> menuTree = new List<MenuTree>();
            foreach (var menu in menuList.Where(m => m.ParentId == 0 && m.Status))
            {
                MenuTree menuRoot = new MenuTree();
                menuRoot.Name = menu.MenuName;
                menuRoot.Url = menu.MenuUrl;
                menuRoot.Icon = menu.Icon;
                menuRoot.subMenus = new List<MenuTree>();
                foreach (var secondMenu in menuList.Where(m => m.ParentId == menu.Id && m.Status))
                {
                    MenuTree menuSecond = new MenuTree();
                    menuSecond.Id = secondMenu.Id;
                    menuSecond.Name = secondMenu.MenuName;
                    menuSecond.Url = secondMenu.MenuUrl;
                    menuSecond.Icon = secondMenu.Icon;
                    menuRoot.subMenus.Add(menuSecond);
                }
                menuTree.Add(menuRoot);
            }
            TData<object> data = new TData<object>();
            data.Code = 1;
            data.Data = new { menuTree };
            return data;
        }

        public IEnumerable<Menu> GetTopMenu()
        {
            return _menuRepository.FindListByClause(m => m.ParentId == 0, "Id");
        }
    }
}
